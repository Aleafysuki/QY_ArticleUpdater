using QieYouArticleUpdater.Main;

namespace QieYouArticleUpdater
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

		private async void PageProcessButton_Click(object sender, EventArgs e)
		{
			if (PageLink.InputText.Length < 5)
			{
				MessageBox.Show("尚未检测到有效的链接！", "无指定链接", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			WebpageAccess webpage = new WebpageAccess();
			WebCommunication communication = new WebCommunication();
			//测试用
			//Article.Text = webpage.GetWebpageContent(PageLink.InputText);

			//Article.Text = webpage.ExtractTextByClass(webpage.GetWebpageContent(PageLink.InputText), PageDivClassList.SelectedItem.ToString());
			//Thread ProgressBarRefresh = new Thread(new ThreadStart(ProgressBarRefreshTask));

			//ProgressBarRefresh.Start();
			Article.Text = await communication.DS_Message(webpage.ExtractTextByClass(webpage.GetWebpageContent(PageLink.InputText), PageDivClassList.SelectedItem.ToString()));
			//ProgressBarRefresh.Abort();
			ArticleGeneratorProgressBar.Value = 100;
		}
		private void ProgressBarRefreshTask()
		{
			/*while (ArticleGeneratorProgressBar.Value < 100)
			{
				System.Threading.Thread.Sleep(20);
				ArticleGeneratorProgressBar.Value += 1;
			}*/
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
				LinkList += (item + '\n');
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
				{ "zh_detail", Article.Text }
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
	}
}
