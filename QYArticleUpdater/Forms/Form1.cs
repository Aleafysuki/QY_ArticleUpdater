using QYArticleUpdater.FileRW;
using QYArticleUpdater.Main;
using System.Text.RegularExpressions;

namespace QYArticleUpdater
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			PageDivClassList.SelectedIndex = 0;
		}

		private void PromptSettingButton_Click(object sender, EventArgs e)
		{
			PromptEditWindow promptEdit = new PromptEditWindow();
			if (PromptPreviewList.SelectedIndex == -1)
			{
				//PromptPreviewList.SelectedIndex = 0;
			}

			promptEdit.ShowDialog();
		}
		#region 文章编辑器快捷键
		/// <summary>
		/// 文章内容编辑工具快捷键
		/// </summary>
		private void TextShortcutKey(object sender, KeyEventArgs e)
		{
			//Ctrl+E居中（编辑器已内置）
			//Ctrl+B加粗
			if (e.Control && e.KeyCode == Keys.B)
			{
				TextBolder();
			}

		}

		/// <summary>
		/// 选中文字加粗
		/// </summary>
		private void TextBolder()
		{
			if (Article.SelectionLength == 0)
			{
				return;
			}
			Font? CurrentFont = Article.SelectionFont;
			FontStyle BoldSelection;
			if (CurrentFont != null)
			{
				if (CurrentFont.Bold)
				{
					BoldSelection = CurrentFont.Style & ~FontStyle.Bold;
				}
				else
				{
					BoldSelection = CurrentFont.Style | FontStyle.Bold;
				}
				Article.SelectionFont = new Font(CurrentFont, BoldSelection);
			}
			else return;
		}
		private void TextBoldButton_Click(object sender, EventArgs e)
		{
			TextBolder();
		}
		private void TextAlignCenter()
		{
			if (Article.SelectionAlignment == HorizontalAlignment.Left)
			{
				Article.SelectionAlignment = HorizontalAlignment.Center;
			}
			else Article.SelectionAlignment = HorizontalAlignment.Left;
		}
		private void TextAlignButton_Click(object sender, EventArgs e)
		{
			TextAlignCenter();
		}
		#endregion
		Image[] ArticleImages;
		string[] ArticleImagesStr;
		private async void PageProcessButton_Click(object sender, EventArgs e)
		{
			/* log的调用方法：Log("TYPE", "INFO");
			 * log包含下面几种，每种都要有【OK】【ERROR】至少两种预案：
			 * 1.获取文章链接
			 * 2.获取页面内容
			 * 3.获取指定的content并转化为纯文字
			 * 4.连接AI API
			 * 5.上传内容
			 * 6.获得改写后内容
			 * 7.上传文章
			 * 8.文章上传完成
			 */
			WebpageAccess webpage = new WebpageAccess();
			WebCommunication communication = new WebCommunication();
			if (PageLink.InputText.Length < 5)
			{
				MessageBox.Show("尚未检测到有效的链接！", "无指定链接", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string WebContent = string.Empty;
			string OriginalArticle = string.Empty;

			// 获取页面内容
			try
			{
				WebContent = webpage.GetWebpageContent(PageLink.InputText);
				Log("OK", "已链接指定网页");
			}
			catch (Exception)
			{
				Log("ERROR", "无法获取页面内容");
				return;
			}
			Log("OK", "已获取页面内容");
			// 获取指定div
			try
			{
				OriginalArticle = webpage.ExtractTextByClass(WebContent, PageDivClassList.SelectedItem.ToString());
				Log("OK", "指定的网页div元素已找到");
				//ArticleImages = webpage.GetImages(WebContent, PageDivClassList.SelectedItem.ToString());
				ArticleImages = webpage.GetImages(WebContent, "article");
				Log("OK", "已获取内文图片");
			}
			catch (Exception)
			{

				Log("ERROR", "页面指定部分的div未找到");
				return;
			}

			if (ArticleImages.Length > 0) ArticlePicturePreview.Image = ArticleImages[0];
			//测试用
			//Article.Text = webpage.GetWebpageContent(PageLink.InputText);

			//Article.Text = webpage.ExtractTextByClass(webpage.GetWebpageContent(PageLink.InputText), PageDivClassList.SelectedItem.ToString());
			//Thread ProgressBarRefresh = new Thread(new ThreadStart(ProgressBarRefreshTask));
			if (SkipAI.Checked)
			{
				Article.Text = OriginalArticle;
				return;
			}
			try
			{
				Log("INFO", "已向AI发送请求，正在等待回复");
				Article.Text = await communication.DS_Message(OriginalArticle);
				Log("OK", "已获取AI返回信息");
			}
			catch (Exception exp)
			{
				Log("ERROR", string.Format($"与AI API通信出现错误:{0}", exp));
			}

		}
		public void Log(string type, string info)
		{
			ArticleGenerateLog.Items.Add(string.Format($"[{type}] {info}"));
			ArticleGenerateLog.SelectedIndex = ArticleGenerateLog.Items.Count - 1;
		}
		private void PlatformVisibleButton_Click(object sender, EventArgs e)
		{
			if (UserSignTextBox.Visible)
			{
				UserSignTextBox.Visible = false;
			}
			else
			{
				UserSignTextBox.Visible = true;
			}
		}

		private void PageLinkListBoxManageButton_Click(object sender, EventArgs e)
		{
			PromptEditWindow editWindow = new PromptEditWindow();
			string LinkList = string.Empty;
			foreach (string item in PageLinkListBox.Items)
			{
				LinkList += item + '\n';
			}
			//editWindow.Controls.Find("PromptText",true). PageLinkListBox.Items
			editWindow.SetContent(LinkList);
			//editWindow.ShowDialog();
			if (editWindow.ShowDialog() == DialogResult.OK && editWindow.Content != null)
			{
				PageLinkListBox.Items.Clear();
				foreach (string item in editWindow.Content.Split('\n'))
				{
					PageLinkListBox.Items.Add(item);
				}
			}
		}

		private void PageLinkListBox_SelectedIndexChanged(object sender, EventArgs e)
		{

			if (PageLinkListBox.SelectedItem != null)
			{
				PageLink.InputText = PageLinkListBox.SelectedItem.ToString();
			}
		}
		private ArticleUploader uploader = new ArticleUploader();
		private string posterFilePath = "";
		private async void UploadButton_Click(object sender, EventArgs e)
		{
			/*var formData = new Dictionary<string, string>
			{
				{ "title", ArticleTitle.InputText },
				{ "shortTitle", String.Empty },
				{ "tagId", ArticleTags.InputText  },
				{ "gameId", txtGameId.Text },//
				{ "columnId", txtColumnId.Text },
				{ "source", ArticleSource.InputText  },
				{ "author", ArticleAuthor.InputText  },
				{ "isMore", "2" },
				{ "zh_poster",File.ReadAllText(posterFilePath)},//
				{ "description", txtDescription.Text },
				{ "isVisit", "2"  },
				{ "isReply", "2"  },
				{ "isPublish", "2"  },
				{ "action", "2"  },
				{ "admin_id", "94"  },
				{ "system", "1"  },
				{ "sign", UserSignTextBox.Text },
				{ "zh_posterUp","2" },
				{ "zh_posterUp2", "1" },
				{ "zh_posterUp3", "1" },
				{ "zh_detail", TransformText(Article.Text) }
			};

			try
			{
				string response = await uploader.UploadArticle(formData, posterFilePath);
				MessageBox.Show(response);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}*/
		}
		static string TransformText(string input)
		{
			// 使用正则表达式匹配所有的 <p> 标签，并确保它们不是包含 <img> 的标签
			string pattern = @"<p>(?!.*?<img\b).*?</p>";
			string replacement = "<p style=\"text-align: start;\">$&</p>";

			// 替换所有匹配的 <p> 标签
			string result = Regex.Replace(input, pattern, replacement, RegexOptions.Singleline);

			return result;
		}
		private void SelectPosterButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					posterFilePath = openFileDialog.FileName;
					//lblSelectedFile.Text = $"Selected File: {Path.GetFileName(posterFilePath)}";
				}
			}
		}

		private void PictureEditButton_Click(object sender, EventArgs e)
		{
			PictureIO picedit = new PictureIO();
			picedit.PicTransmission(ArticleImages);
			picedit.ShowDialog();
		}
		int ArticlePicNum = 0;
		private async void PictureInsertButton_Click(object sender, EventArgs e)
		{
			//插图
			//<p style="text-align: center;"><img src="https://img.qieyou.com/editor/6835125b76104.jpg" alt="" data-href="" style=""></p>
			PicUpload uploader = new PicUpload();
			Regex reg = new Regex("https.*(jpe?g|png)");
			if (ArticlePicturePreview.Image == null) return;
			ArticleImagesStr = new string[ArticleImages.Length];
			var picReturnStr = ArticleImagesStr[ArticlePicNum];
			if (ArticleImagesStr[ArticlePicNum] == null)
			{
				picReturnStr = await uploader.PictureUpload(ArticlePicturePreview.Image);
			}

			Match match = reg.Match(picReturnStr);
			string PictureURL = match.Value.Replace(@"\", string.Empty);
			if (match.Success && picReturnStr.Contains("\"errno\":0"))
			{
				Log("OK", $"已上传图片 - {PictureURL}");
				ArticleImagesStr[ArticlePicNum] = picReturnStr;
			}
			else
			{
				MessageBox.Show($"图片上传失败 - {picReturnStr}");
				Log("ERROR", $"图片上传失败 - {picReturnStr}");
				return;
			}
			if (PictureURL != null)
			{
				InsertCustomStringAtCursor(Article, string.Format($"<p style=\"text-align: center;\"><img src=\"{PictureURL}\" alt=\"\" data-href=\"\" style=\"\"></p>"));
			}
		}
		private void InsertCustomStringAtCursor(RichTextBox richTextBox, string customString)
		{
			// 获取当前光标位置
			int cursorPosition = richTextBox.SelectionStart;

			// 在光标位置插入自定义字符串
			richTextBox.SelectedText = customString;

			// 可选：将光标移动到插入文本之后
			richTextBox.SelectionStart = cursorPosition + customString.Length;
			richTextBox.ScrollToCaret(); // 滚动到光标位置
		}
		private void PrevPicButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (ArticlePicNum <= 0)
				{
					return;
				}
				else
				{
					ArticlePicturePreview.Image = ArticleImages[--ArticlePicNum];
				}
			}
			catch { }
		}

		private void NextPicButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (ArticlePicNum > ArticleImages.Length - 1)
				{
					return;
				}
				else
				{
					ArticlePicturePreview.Image = ArticleImages[++ArticlePicNum];
				}
			}
			catch { }
		}
		/// <summary>
		/// 清除所有编辑器内的内容，为下一篇文章做准备
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ArticleClearButton_Click(object sender, EventArgs e)
		{
			ArticleGenerateLog.Items.Clear();
			foreach (var item in ArticleImages)
			{
				item.Dispose();
			}
			ArticlePicNum = 0;
			ArticlePicturePreview.Image = null;
			PosterPictureView.Image = null;
			PictureFileNameLabel.Text = string.Empty;
			Article.Text = string.Empty;
			ArticleTitle.InputText = string.Empty;
			ArticleTags.InputText = string.Empty;
			if (LinkReloadChecker.Checked)
			{
				try
				{
					++PageLinkListBox.SelectedIndex;
					PageLink.InputText = PageLinkListBox.SelectedItem.ToString();
					Log("INFO", "已清空并装填下一个链接");
				}
				catch { }
			}
		}

		private void ArticlePicturePreview_Paint(object sender, PaintEventArgs e)
		{
			if (ArticlePicturePreview.Image == null) return;
			PictureFileNameLabel.Text = string.Format($"共有{ArticleImages.Length}张图片 - 当前{ArticlePicNum + 1} / {ArticleImages.Length + 1}\n分辨率{ArticlePicturePreview.Image.Width}*{ArticlePicturePreview.Image.Height}");
			if (ArticleImagesStr[ArticlePicNum] != string.Empty)
			{
				PictureFileNameLabel.Text += $"\nlink={ArticleImagesStr[ArticlePicNum]}";
			}
		}

		private void FileImportButton_Click(object sender, EventArgs e)
		{

		}

		private void PictureQuickSizeButton_Click(object sender, EventArgs e)
		{
			PictureIO picIO = new PictureIO();
			for (int i = 0; i < ArticleImages.Length; i++)
			{
				if (ArticleImages[i] != null)
				{
					ArticleImages[i] = picIO.ResizeImage(ArticleImages[i], new Size(800, 9999));
				}
			}
			ArticlePicturePreview.Image = ArticleImages[ArticlePicNum];
		}
	}
}