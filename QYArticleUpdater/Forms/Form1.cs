using QYArticleUpdater.FileRW;
using QYArticleUpdater.Main;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;
using static QYArticleUpdater.Main.ContentMatch;
using static QYArticleUpdater.Main.DSCommunication;

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
			UploadButton.Enabled = false;
			ArticleTimePicker.Enabled = ArticleUploadLater.Checked;
			notify.Icon = SystemIcons.Information;
		}
		NotifyIcon notify = new NotifyIcon();

		const string jsonGenerator = @"
请生成一个包含下面信息的JSON，具体要求如下：
- 文章标题：字符串类型
- 文章关联游戏名称：字符串类型
- 文章的标签：字符串类型

说明：1.文章标题应为20到24个汉字长度，不能包含除空格外的标点符号，每个空格算作0.5个汉字。
2.文章关联游戏名应为字符串类型，表示这篇文章关联的游戏名称。游戏名请使用正式的官方的游戏名称，例如《原神》《明日方舟：终末地》或《地下城与勇士：起源》（注意后两个示例中的冒号）等。
3.文章标签应为字符串类型，多个标签之间用半角逗号分隔。
4.请确保JSON格式正确，使用双引号包裹键和值。
5.请不要包含任何额外的文本或说明，只返回JSON格式的内容。
6.标题撰写提示：可以考虑受众会怎样搜索文章，例如介绍角色技能的文章，读者一般会搜索“有什么技能”“技能怎么升级”一类的词汇；介绍游戏更新时间的文章，读者一般会搜索“什么时候更新”。
7.标题参考：***有什么技能 ***技能介绍、***什么时候公测 ***公测时间、***怎么过 **关卡打法攻略流程
8.标签撰写提示：标签以可以联系到更多相关文章为佳，并且每个标签中间用半角逗号分隔，'游戏攻略'、'游戏资讯'这两个标签不要写（因为这两个标签是系统默认的），其他标签可以写，例如'角色技能'、'游戏公测'、'游戏更新'等。
9.标签撰写要领：标签应当与文章内容相关联，且标签之间用半角逗号分隔。标签可以是游戏名、角色名等关键词。标签尽量与标题相关联，最好不要包含与标题无关的内容。
10.标签需要包含：游戏名或游戏简称，例如《地下城与勇士：起源》游戏文章需要添加名为“DNF手游”的标签（原游戏名太长）。
11.每个标签都不要超过12个字节的数据量，即最多不要超过6个汉字。每个标签内都不要带有任何符号

标题范例（请不要直接使用这些标题，但这些是可以作为符合要求的标题的参考）：
绝区零1.7版本卡池安排是什么 最新调频卡池时间
崩坏星穹铁道风堇是什么定位 风堇配队定位攻略
原神爱可菲是哪里人 新角色爱可菲出身地详细解答
原神无极限超激格斗赛攻略 第五天高难关卡打法
燕云十六声万事知穿风织魂怎么过 穿风织魂任务流程
Steam卸载游戏后存档还在吗 Steam游戏存档位置
崩坏星穹铁道登不上怎么办 崩铁上不了号解决方法

标题反例（这样的标题由于会降低读者点进来的概率，所以是实际上不合格的，在实际撰写中需要尽量避免）：
龙魂旅人洛瑞琳技能解析 光系辅助治疗全攻略 （该标题直接将角色的技能用途写出来了，读者看到标题之后获取了信息就不会点进来看了。可以改成《龙魂旅人洛瑞琳有什么技能 洛瑞琳技能介绍》）
米姆米姆哈怎么玩 庄园经营冒险玩法介绍 （该标题也有类似的问题，直接把前半句问的问题给回答出来了，需要让读者点进来之后通过正文来获得解答。可以改成《米姆米姆哈怎么玩 米姆米姆哈游戏玩法一览》）


标签范例（仅供参考）：
游戏赛事资讯标签范例：电子竞技,王者荣耀,线下活动,电竞派对（原标题为：王者荣耀电竞派对官宣 *月*日正式亮相某城）
游戏角色介绍标签范例：原神,茜特菈莉,深径螺旋（原标题为：原神茜特菈莉打深渊怎么样 茜特菈莉神经螺旋攻略）
游戏关卡攻略标签范例：三角洲行动,密码,彩蛋门,每日活动,密码门（原标题为：三角洲行动6月5日密码 每日彩蛋密码门密钥）
游戏成就获取标签范例：崩坏星穹铁道,隐藏成就,成就,翁法罗斯

请严格按照以下格式返回结果：

```json
{
 ""title"": ""示例文章标题"",
 ""game"": ""示例关联游戏名"",
 ""tag"": ""示例标签1,示例标签2,示例标签3""
}

";
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
			Article.SelectedText = "</b>" + Article.SelectedText + "</b>";
			System.Drawing.Font? CurrentFont = Article.SelectionFont;
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
				Article.SelectionFont = new System.Drawing.Font(CurrentFont, BoldSelection);
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
		System.Drawing.Image[] ArticleImages;
		string[] ArticleImagesStr;
		private async void PageProcessButton_Click(object sender, EventArgs e)
		{
			bool ignoreMessageBox = false;
			if (PageLinkListBox.Items.Count <= 0)
			{
				MessageBox.Show("已一键转写并上传全部链接内容。", "链接已全部清理", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (!FullAutoMode.Checked)
			{

				await WebPageProcess(PageLink.InputText);
			}
			else
			{
				PageLinkListBox.SelectedIndex = 0;
			}
			while (PageLinkListBox.SelectedIndex <= PageLinkListBox.Items.Count && FullAutoMode.Checked)
			{
				try
				{
					await AutoArticleDeploy(PageLink.InputText);
					if (ignoreMessageBox) continue; // 如果设置了忽略消息框，则跳过提示
					switch (MessageBox.Show("已完成本篇的处理与上传,是否处理下一篇？\n[Yes]=处理下一篇\n[No]=停止处理\n[Cancel]=不再询问，处理直至全部完成", "处理完成", MessageBoxButtons.YesNoCancel))
					{
						case DialogResult.Yes:
							continue; // 继续处理下一篇
						case DialogResult.No:
							return; // 停止处理
						case DialogResult.Cancel:
							ignoreMessageBox = true; // 不再询问，继续处理下一篇
							continue; // 不再询问，继续处理下一篇
					}

				}
				catch (Exception ex)
				{
					Log("ERROR", $"处理链接时发生错误: {ex.Message}");
					PageLinkListBox.SelectedIndex++; // 继续处理下一个链接
				}
			}
		}

		private async Task AutoArticleDeploy(string link)
		{

			await WebPageProcess(link);

			PosterPictureView.Image = ArticlePicturePreview.Image;
			//PosterPaint();
			SelectDefaultPosterButton_Click(this.SelectDefaultPosterButton, EventArgs.Empty); // 选择默认海报按钮点击事件处理
																							  //ArticlePicQuickSize();
			AdjustPosterSize_Click(this.AdjustPosterSize, EventArgs.Empty); // 调整海报大小按钮点击事件处理
			ArticlePicQuickSize();

			//var result = new System.Text.StringBuilder();
			//int replaceIndex = 0;
			//Article.Text = RemoveTitle(Article.Text, 30).TrimStart('\n');

			//ArticleImagesStr = new string[ArticleImages.Length];
			ArticlePicNum = 0;
			for (int i = 0; i < Article.Text.Length - 10; i++)
			{
				if (Article.Text[i] == '\n' && Article.Text[i + 1] == '\n')
				{
					Article.SelectionStart = i + 1;// 定位到换行符位置
					Article.SelectionLength = 1;// 选中换行符
					await PicInsert(ArticlePicNum);// 插入图片
					ArticlePicNum++;// 图片编号自增
					i += 140;// 跳过140个字符，避免重复插入图片
				}
				if (ArticlePicNum >= ArticleImages.Length)
				{
					break;
				}
			}
			if (Convert.ToInt32(_uid) < 30)
			{
				await LoginAsync("qy2025001", "CX!Lfk8jR&3JU%KP");
			}

			ArticleUploadLater.Checked = true;
			TimeRandomizeButton_Click(TimeRandomizeButton, EventArgs.Empty); // 随机时间按钮点击事件处理

			await UploadArticle();

			Thread.Sleep(1000); // 等待图片上传完成
			ArticleReload();
		}
		// 移除被认为是标题的短段落
		public static string RemoveTitle(string input, int titleThreshold = 5)
		{
			var lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
			var resultBuilder = new System.Text.StringBuilder();

			foreach (var line in lines)
			{
				var trimmedLine = line.Trim();
				if (!string.IsNullOrWhiteSpace(trimmedLine) && trimmedLine.Length > titleThreshold)
				{
					resultBuilder.AppendLine(trimmedLine);
				}
			}

			return resultBuilder.ToString().Trim(); // 返回结果并去掉首尾可能产生的多余空白
		}
		private async Task WebPageProcess(string url)
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
			//WebCommunication communication = new WebCommunication();
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
				WebContent = webpage.GetWebpageContent(url);
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
				//OriginalArticle = webpage.ExtractTextByClass(WebContent, PageDivClassList.SelectedItem.ToString());
				OriginalArticle = webpage.ExtractTextByClass(WebContent, GetDivClass(PageLink.InputText));
				Log("OK", "指定的网页div元素已找到");
				//ArticleImages = webpage.GetImages(WebContent, PageDivClassList.SelectedItem.ToString());
				ArticleImages = webpage.GetImages(WebContent, "article");
				Log("OK", "已获取内文图片");
				ArticleImagesStr = new string[ArticleImages.Length];
				pictureHTMLcontents = new string[ArticleImages.Length];
				ArticleOriginalImages = new Image[ArticleImages.Length];
				Array.Copy(ArticleImages, ArticleOriginalImages, ArticleImages.Length);
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

			try
			{
				if (SkipAI.Checked)
				{
					Log("INFO", "已开启跳过AI生成【调试】，直接使用原文");
					Article.Text = OriginalArticle;
					return;
				}
				Log("INFO", "已向AI发送请求，正在等待回复");
				Connect();
				string prompt = @"【游戏攻略】将提供给你的内容撰写成一份游戏攻略文章。
你是游戏资讯/攻略网站(网站名称为切游网)的编辑，需要对提供给你的内容进行重新伪原创，并且不要出现AI特征（例如使用AI常用词等）。

只提供文章即可，文章的引用、说明等内容请不要输出。
标题先不要输出，之后需要你在下一个回复中，单独生成标题。

##注意事项:
- 撰写时，剔除原网站的相关信息。
- 需要注意标点符号的运用，不能丢失标点。
- 需要写得尽可能详细，但不要自行点评以及升华，不要自己添油加醋，不要出现例如“这个技能可以xxx”“xxx对于xxx至关重要”“值得注意的是”等内容。
- 正文尽量不要分条罗列。但例如介绍角色技能等内容，可以用小标题+一个完整段落的形式进行撰写。小标题只写成正文加粗，不要使用Head标签（撰写的时候不要使用两个井号来提升小标题权重）。
- 若使用小标题，则小标题和对应段落之间不要使用一个分行或者两个分行，而是应该使用段落标记（不要用换行符<br>，而是和其他段落一样使用段落符号<p>）。
- 不到万不得已尽量少用小标题。因为你的取标题能力很容易让读者看出来这篇文章非常水。
- 剔除掉不需要的部分，例如要求撰写介绍角色技能的文章，如果提供的材料中包括了角色装备的介绍，也请不要在文中出现这些和主题无关的内容。
- 若原文出现多个文章写作方向（例如提到某角色的攻略介绍了角色定位、技能、配队等多方面的内容），默认选择第一个。
- 不要添加过多敬语，不要总是动不动就您您您的，应该拉近读者距离。
- 攻略全文应该包含关于页面所述游戏名的关键词。关键词密度应大于2%。
- 攻略开头和结尾段落应该针对所涉及到的游戏进行SEO。
- 除部分有需要的内容需要写成表格之外，不应该出现任何其他格式（例如标题、有序/无序列表、分隔线）。但是允许加粗、斜体的格式。
- 每句话的结尾必须是句号/问号/叹号等中文全角标点符号，不可以是点号(.)。每段的结尾都应该使用段落标记而不是换行符。小标题也使用段落标记而不是换行符。
- 撰写时查找互联网相关资料，尽量将“玩家”一词替换为游戏官方给玩家安排的称呼（例如《原神》中的玩家被称呼为“旅行者”），如果查不到或者拿不准主意就称呼玩家即可。
- 攻略需要有SEO友好的开头和结尾段落。如果原文没有则自行添加。开头段落应该自成一段，不能裹挟本来应该在正文的一部分内容。
- 如果有明确的回答，在正文中用一段话的空间来明确回答文章所提到的问题（例如将某某游戏什么时候公测的文章，可以在正文中使用单独的一段写“某某游戏公测时间为x月x日”）。
- 如果游戏为《地下城与勇士：起源》or《地下城与勇士手游》，则将其替换为《DNF手游》（即所有的“地下城与勇士”替换为“DNF”）。
- 若文中出现洛克王国世界的字样，《洛克王国世界》是游戏名。
- 全文中的游戏名都可以不加书名号。
- 不要出现向其他任何平台导流的内容，例如“使用TapTap/豌豆荚/好游快爆预约”这样的字样一律不可以出现。

##对初始语句的要求示例（可以进行适度的修改和美化）:
xxx（游戏）的xxx（问题）？很多玩家都不清楚/想要了解/在询问小编xx（问题但是换一种问法），切游小编整理了一下关于xxx（文章主题）的一些资料，其实xxx（一句补充内容），下面我们一起来看一下xxx（问题）。
（举例：原神甘雨用什么圣遗物最好？很多旅行者在培养甘雨的时候不清楚该给她配备什么圣遗物比较好，切游小编整理了一下原神甘雨的圣遗物配装相关资料，甘雨的圣遗物还是尽量靠扩大输出为目标，下面我们来看看详细的原神甘雨圣遗物配装相关攻略。）

##开头段落长度要求：尽量不要多于150字。

##中间段落长度要求：
每段尽量不要超过200字或150token，正文部分的内容需要根据内容需求进行合理分段，但不是分条罗列。以2~5段为佳，不能写成一整段！

##结尾语句要求示例（可以进行适度的润色、修改和美化）:
{用一句话总结回应主题}，{\""以上就是\""+主题内容}了/啦。如果这篇攻略对你有帮助，还请点个收藏关注一下切游网，各位读者的支持就是我们持续更新的最大动力。
（举例：原神甘雨的圣遗物配装以攻、冰、双爆为主要配装目标，这样可以最大化她的输出。以上就是原神甘雨的圣遗物配装攻略啦，如果这篇甘雨的圣遗物搭配攻略对你有帮助的话，还请点个收藏关注一下切游网，各位读者的支持就是我们持续更新的最大动力。";
				SendSystemPrompt(prompt);
				Log("OK", "已发送Prompt");
				for (int i=0;i<5;i++)
				{
					try
					{
						Article.Text = Regex.Replace(await SendUserMessageAsync(OriginalArticle), @"\*\*(.*?)\*\*", "<p>$1</p>");
						break;
					}
					catch (Exception exp)
					{
						if (FullAutoMode.Checked)
						{ 
							Log("ERROR", $"与AI API通信出现错误:{exp}，正在第{i+1}/{5}次重试");
							Thread.Sleep(1000);//等待1秒后重试
						}
						else
						{
							Log("ERROR", $"与AI API通信出现错误:{exp}");
							MessageBox.Show($"与AI API通信出现错误:{exp}", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
							if (DialogResult == DialogResult.Cancel) return;//如果用户选择取消，则退出循环
						}
					}
				}
				Article.Text = Article.Text.Replace("<p>", "").Replace("</p>", "").Replace("strong>", "b>");//去除段落标签
				notify.ShowBalloonTip(1000, "AI文章生成", "已生成文章内容，正在获取AI返回信息", ToolTipIcon.Info);
				Log("OK", "已获取AI返回信息");
				System.Media.SystemSounds.Asterisk.Play();
				Log("INFO", "正在生成文章标题、标签以及关联游戏");


				await GetArticleInfo();
				//notify.ShowBalloonTip(1000, "AI文章生成", "已获取文章信息", ToolTipIcon.Info);
				Log("OK", "已获取文章标题等内容");
			}
			catch (Exception exp)
			{
				Log("ERROR", $"与AI API通信出现错误:{exp}");
			}
		}
		Image[] ArticleOriginalImages = new Image[0];
		private async Task GetArticleInfo()
		{
			string ArticleInfo = " " + await SendUserMessageAsync(jsonGenerator);//生成一个固定格式的回复，目前考虑json
																				 //Log("INFO", $"获取原始返回数据如下：{ArticleInfo}");
			try
			{
				ArticleInfo = ArticleInfo.Split(new string[] { "```json" }, StringSplitOptions.RemoveEmptyEntries)[1].Split('}')[0] + '}';//
				Log("INFO", "已获取文章信息，正在进行校验");
				ArticleTitle.InputText = JsonSerializer.Deserialize<ArticleInfoData>(ArticleInfo).title;
				ArticleGameName.InputText = JsonSerializer.Deserialize<ArticleInfoData>(ArticleInfo).game;
				ArticleTags.InputText = JsonSerializer.Deserialize<ArticleInfoData>(ArticleInfo).tag;
				Log("OK", "已填写文章相关信息");
			}
			catch (Exception exp)
			{
				// 处理异常，可能是JSON解析错误或格式不正确
				MessageBox.Show($"从AI API获得的返回数据[文章信息]有误:{exp}，正在重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Log("ERROR", $"从AI API获得的返回数据[文章信息]有误:{exp}，正在重试");
				return;
			}
		}
		private class ArticleInfoData
		{
			public string title { get; set; }
			public string game { get; set; }
			public string tag { get; set; }
		}
		public void Log(string type, string info)
		{
			ArticleGenerateLog.Items.Add(string.Format($"[{type}] {info}"));

			ArticleGenerateLog.SelectedIndex = ArticleGenerateLog.Items.Count - 1;
			if (type == "ERROR")
			{
				System.Media.SystemSounds.Asterisk.Play();
			}
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
		private void DeleteSelectedItemFromListBox(ListBox listBox)
		{
			int selectedIndex = listBox.SelectedIndex;

			if (selectedIndex >= 0 && listBox.Items.Count > 0)
			{
				// 删除选中的项目
				listBox.Items.RemoveAt(selectedIndex);

				int newCount = listBox.Items.Count;

				if (newCount == 0)
				{
					// 删除后列表为空，无需选中
					return;
				}

				// 计算新要选中的索引
				int newIndex = selectedIndex < newCount ? selectedIndex : newCount - 1;
				listBox.SelectedIndex = newIndex;
			}
		}
		private void PageLinkListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Text = $"Laoliu666_QY文章快速填充工具 - {PageLinkListBox.Items.Count}项目剩余 - " + PageLinkListBox.SelectedItem?.ToString() ?? "未选择链接";
			if (PageLinkListBox.SelectedItem != null)
			{
				PageLink.InputText = PageLinkListBox.SelectedItem.ToString();
			}
		}
		private bool RandomTimeSet = false;
		private ArticleUploader uploader = new ArticleUploader();
		private string posterFilePath = "";
		private async void UploadButton_Click(object sender, EventArgs e)
		{
			if (!RandomTimeSet && ArticleUploadLater.Checked)
			{
				if
					(MessageBox.Show("请先设置文章发布时间！\n点击[是]则设置一个随机时间，点[否]返回", "未设置时间", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					RandomTimeGenerator();
					RandomTimeSet = true;
				}
				else
				{
					return; // 如果用户选择否，则返回，不执行上传操作
				}

			}
			await UploadArticle();
			RandomTimeSet = false; // 重置随机时间设置状态
		}
		private async Task UploadArticle()
		{
			string gameName = ArticleGameName.InputText;
			int ArticleID = 10;//游戏攻略
			string Description = FullAutoMode.Checked ? Article.Text.Split("<p ")[0] : Article.Text.Split('\n')[0];
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
					ZhDetail = TransformText(Article.Text),
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

				if (Regex.Unescape(response).Contains("20"))
				{
					Disconnect();
					System.Media.SystemSounds.Asterisk.Play();
					if (!FullAutoMode.Checked)
					{
						MessageBox.Show(Regex.Unescape(response));
					}

					else
					{

						notify.ShowBalloonTip(1000, "文章上传成功", '\n' + Regex.Unescape(response), ToolTipIcon.Info);
					}
					Log("OK", "文章上传成功");
				}
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
				UploadButton.Enabled = true; // 启用上传按钮
				if (!FullAutoMode.Checked) MessageBox.Show($"登录成功，UID: {_uid}");
				else
				{
					Log("OK", $"登录成功，UID: {_uid}");
				}
				UploadButton.Text = $"上传到系统（{_uid}）";
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
			if (Convert.ToInt32(_uid) < 20)
			{
				throw new Exception("UID异常，请点击登录按钮进行用户登录获取UID");
			}
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
					if (ArticleUploadNow.Checked)
					{
						AddTextContent(content, "isPublish", "2");
					}
					else if (ArticleUploadLater.Checked)
					{
						AddTextContent(content, "isPublish", "1");
						AddTextContent(content, "publish_time", ArticleTimePicker.Text);
					}
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
			// 根据换行符拆分文本
			var lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			var htmlBuilder = new System.Text.StringBuilder();

			foreach (var line in lines)
			{
				var trimmedLine = line.Trim();
				if (string.IsNullOrWhiteSpace(trimmedLine))
				{
					// 跳过空白行
					continue;
				}
				if (trimmedLine.Length < 15)
				{
					trimmedLine = "<b>"+ trimmedLine + "</b>"; // 小标题，如果行长度小于15，则将其包裹在<b>标签中
				}
				// 检查是否是仅包含图片的段落
				if (Regex.IsMatch(trimmedLine, @"^\s*<img [^>]+>\s*$"))
				{
					// 如果是图片，则直接添加到htmlBuilder中
					htmlBuilder.AppendLine(trimmedLine);
				}
				else
				{
					// 否则将其包裹在<p>标签中
					htmlBuilder.AppendLine($"<p>{trimmedLine}</p>");
				}
			}

			return htmlBuilder.ToString().Replace("</p></p>", "</p>").Replace("<p><p", "<p");
		}
		private void SelectPosterButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					posterFilePath = openFileDialog.FileName;
					PosterPictureView.Image = System.Drawing.Image.FromFile(posterFilePath);
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
		string[] pictureHTMLcontents = Array.Empty<string>();

		private async void PictureInsertButton_Click(object sender, EventArgs e)
		{
			await PicInsert(ArticlePicNum);
		}
		private async Task PicInsert(int picIndex)
		{
			PicUpload uploader = new PicUpload();//图片上传类
			Regex reg = new Regex("https.*(jpe?g|png)");// 正则表达式匹配图片链接
			if (ArticlePicturePreview.Image == null) return;//如果没有图片则返回

			//var picReturnStr = ArticleImagesStr[picIndex];// 获取图片上传返回的字符串
			if (picIndex >= ArticleImages.Length) return;// 如果图片索引超出范围则返回
			if (ArticleImagesStr[picIndex] == null)
			{
				ArticleImagesStr[picIndex] = await uploader.PictureUpload(ArticleImages[picIndex]);// 上传图片并获取返回字符串
			}

			Match match = reg.Match(ArticleImagesStr[picIndex]);
			string PictureURL = match.Value.Replace(@"\", string.Empty);
			if (match.Success && ArticleImagesStr[picIndex].Contains("\"errno\":0"))
			{
				Log("OK", $"已上传图片 - {PictureURL}");
				ArticleImagesStr[picIndex] = ArticleImagesStr[picIndex];
				pictureHTMLcontents[picIndex] = string.Format($"<p style=\"text-align: center;\"><img src=\"{PictureURL}\" alt=\"\" data-href=\"\" style=\"\"></p><p>");
			}
			else
			{
				MessageBox.Show($"图片上传失败 - {ArticleImagesStr[picIndex]}");
				Log("ERROR", $"图片上传失败 - {ArticleImagesStr[picIndex]}");
				return;
			}
			if (PictureURL != null)
			{
				InsertCustomStringAtCursor(Article, string.Format($"<p style=\"text-align: center;\"><img src=\"{PictureURL}\" alt=\"\" data-href=\"\" style=\"\"></p><p>"));
			}
		}
		public void InsertImagesIntoRichTextBox(RichTextBox Article, string[] ArticleImages)
		{
			// Step 1: 提取段落（按两个换行符或换行+空格等逻辑段落划分）
			string articleText = Article.Text;
			var paragraphs = Regex.Split(articleText.Trim(), @"(\r?\n\s*\r?\n)+")  // 匹配空行作为段落分隔
								  .Where(p => !string.IsNullOrWhiteSpace(p))
								  .ToList();

			int paragraphCount = paragraphs.Count;
			int imageCount = ArticleImages.Length;

			if (paragraphCount == 0 || imageCount == 0) return;

			// Step 2: 均匀计算插入位置（段与段之间有 n-1 个间隔）
			int gapCount = paragraphCount - 1;
			var result = new System.Text.StringBuilder();

			int imageIndex = 0;
			for (int i = 0; i < paragraphCount; i++)
			{
				result.AppendLine(paragraphs[i].Trim());

				// 尝试在段落之间插入图片（最后一段后不插）
				if (i < gapCount)
				{
					// 根据图片数量和间隔比例决定当前是否插入
					int expectedInsertions = (int)Math.Round((double)imageCount * (i + 1) / gapCount);
					while (imageIndex < expectedInsertions && imageIndex < imageCount)
					{
						//result.AppendLine(); // 空一行
						result.AppendLine(ArticleImages[imageIndex]); // 可以根据需要换成 HTML 或自定义格式
						imageIndex++;
					}

					result.AppendLine(); // 插入一段后空行
				}
			}

			// Step 3: 赋值回 RichTextBox
			Article.Text = result.ToString().Trim();
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
				if (ArticlePicNum >= ArticleImages.Length - 1)
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
			ArticleReload();
		}
		private void ArticleReload()
		{
			if (PageLinkListBox.Items.Count == 0)
			{
				MessageBox.Show("列表中已无可用链接，清更换弹夹", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
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
			UploadButton.Enabled = Convert.ToInt32(_uid) > 30;
			ArticleOriginalImages.Cast<Image>().ToList().ForEach(img => img.Dispose());

			if (LinkReloadChecker.Checked)
			{
				try
				{
					DeleteSelectedItemFromListBox(PageLinkListBox);
					//++PageLinkListBox.SelectedIndex;
					PageLink.InputText = PageLinkListBox.SelectedItem.ToString();
					Log("INFO", "已清空并装填下一个链接");
				}
				catch { }
			}
		}

		private void ArticlePicturePreview_Paint(object sender, PaintEventArgs e)
		{
			if (ArticlePicturePreview.Image == null) return;
			PictureFileNameLabel.Text = string.Format($"共有{ArticleImages.Length}张图片 - 当前{ArticlePicNum + 1} / {ArticleImages.Length}\n分辨率{ArticlePicturePreview.Image.Width}*{ArticlePicturePreview.Image.Height}");
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
			ArticlePicQuickSize();
		}
		private void ArticlePicQuickSize()
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

		private void AdjustPosterSize_Click(object sender, EventArgs e)
		{
			//打开图片编辑窗口PictureIO

			PosterPaint();

		}
		private void PosterPaint()
		{
			if (PosterPictureView.Image == null) return;
			var posterImage = PictureIO.AdjustToSelectedResolution(PosterPictureView.Image, new int[] { 1000, 600 });
			PosterPictureView.Image = posterImage;
			if (!Directory.Exists(@"D:\Poster\")) Directory.CreateDirectory(@"D:\Poster\");
			posterImage.Save(@"D:\Poster\temp_poster.jpg", ImageFormat.Jpeg);
			posterFilePath = @"D:\Poster\temp_poster.jpg";
		}
		private void SelectDefaultPosterButton_Click(object sender, EventArgs e)
		{
			PosterPictureView.Image = ArticlePicturePreview.Image;
		}

		private void ArticleUploadLater_CheckedChanged(object sender, EventArgs e)
		{

			ArticleTimePicker.Enabled = ArticleUploadLater.Checked;

		}

		private void ArticleGenerateLog_DoubleClick(object sender, EventArgs e)
		{
			if (ArticleGenerateLog.Items.Count <= 0) return;
			MessageBox.Show(ArticleGenerateLog.SelectedItem.ToString(), "详细信息", MessageBoxButtons.OK);
		}

		private void PreviewImageCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetImage(ArticleOriginalImages[ArticlePicNum]);
		}

		private void TimeRandomizeButton_Click(object sender, EventArgs e)
		{
			RandomTimeSet = true; // 设置随机时间状态为已设置
			ArticleTimePicker.Text = RandomTimeGenerator();
			while (ArticleTimePicker.Value <= DateTime.Now)
			{
				ArticleTimePicker.Text = RandomTimeGenerator();
				if (ArticleTimePicker.Value.Date < DateTime.Today) ArticleTimePicker.Value = ArticleTimePicker.Value.AddDays(1);
			}
		}
		private string RandomTimeGenerator()
		{
			// 生成一个随机的时间字符串，格式为"yyyy-MM-dd HH:mm:ss"
			Random random = new Random();
			int year = ArticleTimePicker.Value.Year; // 年份
			int month = ArticleTimePicker.Value.Month; // 月份
			int day = ArticleTimePicker.Value.Day; // 日期
			int hour = random.Next(8, 20); // 随机小时
			int minute = random.Next(0, 60); // 随机分钟
			int second = random.Next(0, 60); // 随机秒数
											 // 返回格式化的时间字符串
			return string.Format("{0:0000}-{1:00}-{2:00} {3:00}:{4:00}:{5:00}", year, month, day, hour, minute, second);
			//return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}

		private void TransformedPreviewImageCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetImage(ArticlePicturePreview.Image);
		}

		private void 粘贴图像ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Clipboard.ContainsImage())
			{
				PosterPictureView.Image = Clipboard.GetImage();
				Clipboard.GetImage().Save(@"D:\Poster\temp_poster.jpg", ImageFormat.Jpeg); ;
			}
		}
	}
}