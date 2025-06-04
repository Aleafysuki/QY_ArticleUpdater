using QYArticleUpdater.FileRW;
using QYArticleUpdater.Main;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QYArticleUpdater
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			PageDivClassList.SelectedIndex = 0;
			_client = new HttpClient();
			_client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
			_client.DefaultRequestHeaders.Add("Referer", "http://laoliu666.qieyou.com/");
			ArticleTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			ArticleUploadNow.Checked = true;
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
			string gameName = ArticleGameName.InputText;
			int ArticleID = 10;//游戏攻略
			string Description = Article.Text.Split('\n')[0];
			SystemData QData = new SystemData();
			try
			{
				string response = await UploadArticleAsync(new ArticleData
				{
					Title = ArticleTitle.InputText,
					ShortTitle = "",
					TagId = ArticleTags.InputText,
					GameId = await QData.GetGameFromName(gameName),
					ColumnId = ArticleID,
					Source = ArticleSource.InputText,
					Author = ArticleAuthor.InputText,
					Description = Description,
					ImagePath = posterFilePath,
					AdminId = Convert.ToInt32(_uid),
					ZhDetail = Article.Text,
					Sign = UserSignTextBox.Text
				});
				/*
				var formData = new Dictionary<string, string>
				{
					{ "title",  },//标题
					{ "shortTitle", String.Empty },//缩略标题，一般不填
					{ "tagId", ArticleTags.InputText  },//文章标签，手动填写
					{ "gameId", QData.GetGameFromName(gameName).ToString() },//对应游戏的id，进行正则查询匹配
					{ "columnId", ArticleID.ToString() },//文章分类，通常为游戏攻略（10）
					{ "source", ArticleSource.InputText  },//文章来源，通常为网络
					{ "author", ArticleAuthor.InputText  },//作者署名
					{ "isMore", "2" },//不知道是啥，一般都是2
					{ "zh_poster",File.ReadAllText(posterFilePath)},//封面图片，将图片以纯文本形式打开但上传时是jpeg格式
					{ "description", Description },//文章简介，一般为第一段话
					{ "isVisit", "2"  },//可否浏览，1为不可浏览，2为可以浏览
					{ "isReply", "2"  },//可否回复，1为可以回复，2为不可回复
					{ "isPublish", "2"  },//是否公开，1为存草稿，2为发出来
					{ "action", "2"  },//不知道是啥，先填2
					{ "admin_id", "94"  },//不知道是啥，其他文章都填这个我也这么填
					{ "system", "1"  },
					{ "sign", UserSignTextBox.Text },//用户凭据，用于验证
					{ "zh_posterUp","2" },
					{ "zh_posterUp2", "1" },
					{ "zh_posterUp3", "1" },//三张poster设置为2，1，1即为单封面
					{ "zh_detail", TransformText(Article.Text) }//文章正文，以HTML正文的形式进行传输
				};
				*/


				// = await uploader.UploadArticle(formData, posterFilePath);
				MessageBox.Show(Regex.Unescape(response));

			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}");
			}
		}
		private readonly HttpClient _client;
		private string _uid;
		//public QieyouClient()
		//{

		//}
		public async Task<bool> LoginAsync(string username, string password)
		{
			string sign = SignatureGenerator.GenerateSign();  // 调用你已有的加密函数

			var formData = new Dictionary<string, string>
		{
			{ "account", username },
			{ "password", password },
			{ "sign", sign },
			{ "system", "1" }
		};

			var content = new FormUrlEncodedContent(formData);

			var response = await _client.PostAsync("https://api.qieyou.com/admin/User/loginAccount", content);
			var body = await response.Content.ReadAsStringAsync();

			Console.WriteLine("登录返回：" + body);

			if (response.IsSuccessStatusCode && body.Contains("\"code\":200"))
			{
				// 提取 uid
				var start = body.IndexOf("\"data\":") + 7;
				var end = body.IndexOf(",", start);
				_uid = body.Substring(start, end - start).Trim();
				MessageBox.Show($"登录成功，UID: {_uid}");
				return true;
			}

			return false;
		}
		public async Task<string> GetCurrentUserInfoAsync()
		{
			string sign = SignatureGenerator.GenerateSign();  // 再次生成 sign

			var formData = new Dictionary<string, string>
		{
			{ "uid", _uid },
			{ "system", "1" },
			{ "sign", sign }
		};

			var content = new FormUrlEncodedContent(formData);
			var response = await _client.PostAsync("https://api.qieyou.com/admin/User/currentUser", content);
			return await response.Content.ReadAsStringAsync();
		}
		private async Task<string> DecompressResponse(HttpResponseMessage response)
		{
			if (response.Content.Headers.ContentEncoding.Contains("gzip"))
			{
				using (var originalStream = await response.Content.ReadAsStreamAsync())
				using (var decompressedStream = new GZipStream(originalStream, CompressionMode.Decompress))
				using (var reader = new StreamReader(decompressedStream))
				{
					return await reader.ReadToEndAsync();
				}
			}
			else
			{
				return await response.Content.ReadAsStringAsync();
			}
		}
		public async Task<string> UploadArticleAsync(ArticleData article)
		{
			using (var client = new HttpClient())
			{

				// 设置请求头
				client.DefaultRequestHeaders.Add("Host", "api.qieyou.com");
				client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Not/A)Brand\";v=\"8\", \"Chromium\";v=\"126\", \"Google Chrome\";v=\"126\"");
				client.DefaultRequestHeaders.Add("Accept", "application/json");
				client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
				client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36");
				client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
				client.DefaultRequestHeaders.Add("Origin", "http://laoliu666.qieyou.com");
				client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "cross-site");
				client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
				client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
				client.DefaultRequestHeaders.Add("Referer", "http://laoliu666.qieyou.com/");
				client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br, zstd");
				client.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.9");

				// 创建多部分表单数据
				var boundary = "----WebKitFormBoundarysWwv37W48BX148z0";
				using (var content = new MultipartFormDataContent(boundary))
				{
					// 添加文本字段
					AddTextContent(content, "title", article.Title);
					AddTextContent(content, "shortTitle", article.ShortTitle);
					AddTextContent(content, "tagId", article.TagId);
					AddTextContent(content, "gameId", article.GameId.ToString());
					AddTextContent(content, "columnId", article.ColumnId.ToString());
					AddTextContent(content, "source", article.Source);
					AddTextContent(content, "author", article.Author);
					AddTextContent(content, "isMore", "2");

					// 添加图片文件
					if (!string.IsNullOrEmpty(article.ImagePath))
					{
						var imageContent = new ByteArrayContent(File.ReadAllBytes(article.ImagePath));
						imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
						content.Add(imageContent, "zh_poster", Path.GetFileName(article.ImagePath));
					}

					// 添加其他字段
					AddTextContent(content, "description", article.Description);
					AddTextContent(content, "isVisit", "2");
					AddTextContent(content, "isReply", "2");
					AddTextContent(content, "isPublish", "2");

					//isPublish这里的说明
					//若isPublish=1，则为存草稿，若为2则是直接发出来，下面的publish_time可以不保留
					//此时需要额外的内容：publish_time，具体内容格式为：
					//2025-06-05 09:21:25

					AddTextContent(content, "action", "2");
					AddTextContent(content, "admin_id", article.AdminId.ToString());
					AddTextContent(content, "system", "1");

					AddTextContent(content, "sign", SignatureGenerator.GenerateSign());
					//AddTextContent(content, "sign", article.Sign);
					AddTextContent(content, "zh_posterUp", "2");
					AddTextContent(content, "zh_posterUp2", "1");
					AddTextContent(content, "zh_posterUp3", "1");
					AddTextContent(content, "zh_detail", article.ZhDetail);

					// 发送请求
					var response = await client.PostAsync("https://api.qieyou.com/admin/Article/articleAdd", content);
					string responseBody = await DecompressResponse(response);
					Console.WriteLine($"Response body: {responseBody}");

					return responseBody;
				}
			}
		}


		// 测试代码
		//public class Program
		//{
		//	public static void Main()
		//	{
		//		string account = "user123";
		//		string password = "password123";
		//
		//		string sign = SignatureGenerator.GenerateSign(account, password);
		//		Console.WriteLine("Generated Sign: " + sign);
		//	}
		//}
		/*
		public class ArticleData
		{
			public string Title { get; set; }
			public string ShortTitle { get; set; }
			public string TagId { get; set; }
			public int GameId { get; set; }
			public int ColumnId { get; set; }
			public string Source { get; set; }
			public string Author { get; set; }
			public string Description { get; set; }
			public string ZhDetail { get; set; }
			public string ImagePath { get; set; }
			public int AdminId { get; set; }
			public string Sign { get; set; }
		}
		*/
		private void AddTextContent(MultipartFormDataContent content, string name, string value)
		{
			var stringContent = new StringContent(value ?? "");
			stringContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
			{
				Name = name
			};
			content.Add(stringContent);
		}
		static string TransformText(string input)
		{
			// 使用正则表达式匹配所有的 <p> 标签，并确保它们不是包含 <img> 的标签
			string pattern = @"<p>(?!.*?<img\b).*?</p>";
			string replacement = "<p style=\"text-align: start;\">$&</p>";

			// 替换所有匹配的 <p> 标签
			string html = Regex.Replace(input, pattern, replacement, RegexOptions.Singleline);
			// 去除空段落 <p><br></p> 或 <p>&nbsp;</p>
			html = Regex.Replace(html, @"<p>\s*(<br\s*/?>)?\s*</p>", "", RegexOptions.IgnoreCase);

			// 去除多个连续换行 <br><br><br>
			string result = Regex.Replace(html, @"(<br\s*/?>\s*){2,}", "<br>", RegexOptions.IgnoreCase);
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
					PosterPictureView.Image = Image.FromFile(posterFilePath);
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
			PictureFileNameLabel.Text = string.Format($"共有{ArticleImages.Length - 1}张图片 - 当前{ArticlePicNum + 1} / {ArticleImages.Length + 1}\n分辨率{ArticlePicturePreview.Image.Width}*{ArticlePicturePreview.Image.Height}");
			if (ArticleImagesStr != null)
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

		private async void LoginButton_Click(object sender, EventArgs e)
		{
			await LoginAsync("qy2025001", "CX!Lfk8jR&3JU%KP");
		}
	}
}