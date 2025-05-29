namespace QieYouArticleUpdater
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			ArticleBox = new GroupBox();
			SelectPosterButton = new Button();
			PictureEditButton = new Button();
			ArticleSource = new LabeledInput();
			ArticleAuthor = new LabeledInput();
			TextAlignButton = new Button();
			ArticleTags = new LabeledInput();
			TextBoldButton = new Button();
			ArticleTitle = new LabeledInput();
			Article = new RichTextBox();
			AIBox = new GroupBox();
			PromptPreviewList = new ListBox();
			PromptListMenu = new ContextMenuStrip(components);
			在上方新增ToolStripMenuItem = new ToolStripMenuItem();
			在下方新增ToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			删除ToolStripMenuItem = new ToolStripMenuItem();
			PromptSettingButton = new Button();
			AISettingButton = new Button();
			AIModelArea = new LabeledInput();
			AIAPIArea = new LabeledInput();
			CaptureBox = new GroupBox();
			PageLinkListBoxManageButton = new Button();
			LinkDeleteButton = new Button();
			button1 = new Button();
			FileImportButton = new Button();
			PageLinkListBox = new ListBox();
			labeledInput1 = new LabeledInput();
			SystemBox = new GroupBox();
			UserSignTextBox = new TextBox();
			PlatformVisibleButton = new Button();
			menuStrip1 = new MenuStrip();
			文件ToolStripMenuItem = new ToolStripMenuItem();
			设定ToolStripMenuItem = new ToolStripMenuItem();
			关于ToolStripMenuItem = new ToolStripMenuItem();
			LinkListMenu = new ContextMenuStrip(components);
			toolStripMenuItem1 = new ToolStripMenuItem();
			toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripSeparator2 = new ToolStripSeparator();
			toolStripMenuItem3 = new ToolStripMenuItem();
			UploadButton = new Button();
			ArticleGeneratorProgressBar = new ProgressBar();
			PageProcessBox = new GroupBox();
			label1 = new Label();
			PageDivClassList = new ListBox();
			PageLink = new LabeledInput();
			PageProcessButton = new Button();
			DetailChecker = new CheckBox();
			ArticleClearButton = new Button();
			LinkReloadChecker = new CheckBox();
			ProgressBarBackground = new System.ComponentModel.BackgroundWorker();
			ArticleBox.SuspendLayout();
			AIBox.SuspendLayout();
			PromptListMenu.SuspendLayout();
			CaptureBox.SuspendLayout();
			SystemBox.SuspendLayout();
			menuStrip1.SuspendLayout();
			LinkListMenu.SuspendLayout();
			PageProcessBox.SuspendLayout();
			SuspendLayout();
			// 
			// ArticleBox
			// 
			ArticleBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ArticleBox.Controls.Add(SelectPosterButton);
			ArticleBox.Controls.Add(PictureEditButton);
			ArticleBox.Controls.Add(ArticleSource);
			ArticleBox.Controls.Add(ArticleAuthor);
			ArticleBox.Controls.Add(TextAlignButton);
			ArticleBox.Controls.Add(ArticleTags);
			ArticleBox.Controls.Add(TextBoldButton);
			ArticleBox.Controls.Add(ArticleTitle);
			ArticleBox.Controls.Add(Article);
			ArticleBox.Location = new Point(824, 37);
			ArticleBox.Name = "ArticleBox";
			ArticleBox.Size = new Size(656, 601);
			ArticleBox.TabIndex = 0;
			ArticleBox.TabStop = false;
			ArticleBox.Text = "文章预览";
			// 
			// SelectPosterButton
			// 
			SelectPosterButton.Location = new Point(420, 91);
			SelectPosterButton.Name = "SelectPosterButton";
			SelectPosterButton.Size = new Size(230, 35);
			SelectPosterButton.TabIndex = 7;
			SelectPosterButton.Text = "内页图片编辑";
			SelectPosterButton.UseVisualStyleBackColor = true;
			SelectPosterButton.Click += SelectPosterButton_Click;
			// 
			// PictureEditButton
			// 
			PictureEditButton.Location = new Point(419, 130);
			PictureEditButton.Name = "PictureEditButton";
			PictureEditButton.Size = new Size(230, 35);
			PictureEditButton.TabIndex = 7;
			PictureEditButton.Text = "内页图片编辑";
			PictureEditButton.UseVisualStyleBackColor = true;
			// 
			// ArticleSource
			// 
			ArticleSource.Font = new Font("微软雅黑 Consolas", 10.6930695F);
			ArticleSource.HideText = '\0';
			ArticleSource.InputText = "网络";
			ArticleSource.LabelText = "来源";
			ArticleSource.Location = new Point(361, 53);
			ArticleSource.Name = "ArticleSource";
			ArticleSource.Size = new Size(141, 24);
			ArticleSource.SplitVal = 50;
			ArticleSource.TabIndex = 6;
			// 
			// ArticleAuthor
			// 
			ArticleAuthor.Font = new Font("微软雅黑 Consolas", 10.6930695F);
			ArticleAuthor.HideText = '\0';
			ArticleAuthor.InputText = "Kave";
			ArticleAuthor.LabelText = "作者";
			ArticleAuthor.Location = new Point(508, 53);
			ArticleAuthor.Name = "ArticleAuthor";
			ArticleAuthor.Size = new Size(141, 24);
			ArticleAuthor.SplitVal = 50;
			ArticleAuthor.TabIndex = 5;
			// 
			// TextAlignButton
			// 
			TextAlignButton.Font = new Font("微软雅黑 Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
			TextAlignButton.Location = new Point(3, 142);
			TextAlignButton.Name = "TextAlignButton";
			TextAlignButton.Size = new Size(52, 27);
			TextAlignButton.TabIndex = 4;
			TextAlignButton.Text = "Center";
			TextAlignButton.TextAlign = ContentAlignment.TopCenter;
			TextAlignButton.UseVisualStyleBackColor = true;
			TextAlignButton.Click += TextAlignButton_Click;
			// 
			// ArticleTags
			// 
			ArticleTags.Font = new Font("微软雅黑 Consolas", 10.6930695F);
			ArticleTags.HideText = '\0';
			ArticleTags.InputText = "";
			ArticleTags.LabelText = "标签Tag";
			ArticleTags.Location = new Point(5, 53);
			ArticleTags.Name = "ArticleTags";
			ArticleTags.Size = new Size(350, 21);
			ArticleTags.SplitVal = 98;
			ArticleTags.TabIndex = 3;
			// 
			// TextBoldButton
			// 
			TextBoldButton.Font = new Font("微软雅黑 Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
			TextBoldButton.Location = new Point(3, 109);
			TextBoldButton.Name = "TextBoldButton";
			TextBoldButton.Size = new Size(52, 27);
			TextBoldButton.TabIndex = 2;
			TextBoldButton.Text = "Bold";
			TextBoldButton.TextAlign = ContentAlignment.TopCenter;
			TextBoldButton.UseVisualStyleBackColor = true;
			TextBoldButton.Click += TextBoldButton_Click;
			// 
			// ArticleTitle
			// 
			ArticleTitle.Font = new Font("微软雅黑 Consolas", 10.6930695F);
			ArticleTitle.HideText = '\0';
			ArticleTitle.InputText = "";
			ArticleTitle.LabelText = "标题";
			ArticleTitle.Location = new Point(5, 26);
			ArticleTitle.Name = "ArticleTitle";
			ArticleTitle.Size = new Size(645, 21);
			ArticleTitle.SplitVal = 96;
			ArticleTitle.TabIndex = 1;
			// 
			// Article
			// 
			Article.Dock = DockStyle.Bottom;
			Article.EnableAutoDragDrop = true;
			Article.Location = new Point(3, 171);
			Article.Name = "Article";
			Article.Size = new Size(650, 427);
			Article.TabIndex = 0;
			Article.Text = "";
			Article.KeyDown += TextShortcutKey;
			// 
			// AIBox
			// 
			AIBox.Controls.Add(PromptPreviewList);
			AIBox.Controls.Add(PromptSettingButton);
			AIBox.Controls.Add(AISettingButton);
			AIBox.Controls.Add(AIModelArea);
			AIBox.Controls.Add(AIAPIArea);
			AIBox.Location = new Point(4, 37);
			AIBox.Name = "AIBox";
			AIBox.Size = new Size(813, 169);
			AIBox.TabIndex = 1;
			AIBox.TabStop = false;
			AIBox.Text = "AI工具使用";
			// 
			// PromptPreviewList
			// 
			PromptPreviewList.ContextMenuStrip = PromptListMenu;
			PromptPreviewList.FormattingEnabled = true;
			PromptPreviewList.ItemHeight = 22;
			PromptPreviewList.Location = new Point(464, 29);
			PromptPreviewList.Name = "PromptPreviewList";
			PromptPreviewList.ScrollAlwaysVisible = true;
			PromptPreviewList.Size = new Size(343, 136);
			PromptPreviewList.TabIndex = 4;
			// 
			// PromptListMenu
			// 
			PromptListMenu.ImageScalingSize = new Size(17, 17);
			PromptListMenu.Items.AddRange(new ToolStripItem[] { 在上方新增ToolStripMenuItem, 在下方新增ToolStripMenuItem, toolStripSeparator1, 删除ToolStripMenuItem });
			PromptListMenu.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
			PromptListMenu.Name = "contextMenuStrip1";
			PromptListMenu.Size = new Size(144, 82);
			// 
			// 在上方新增ToolStripMenuItem
			// 
			在上方新增ToolStripMenuItem.Name = "在上方新增ToolStripMenuItem";
			在上方新增ToolStripMenuItem.Size = new Size(143, 24);
			在上方新增ToolStripMenuItem.Text = "在上方新增";
			// 
			// 在下方新增ToolStripMenuItem
			// 
			在下方新增ToolStripMenuItem.Name = "在下方新增ToolStripMenuItem";
			在下方新增ToolStripMenuItem.Size = new Size(143, 24);
			在下方新增ToolStripMenuItem.Text = "在下方新增";
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(140, 6);
			// 
			// 删除ToolStripMenuItem
			// 
			删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
			删除ToolStripMenuItem.Size = new Size(143, 24);
			删除ToolStripMenuItem.Text = "删除";
			// 
			// PromptSettingButton
			// 
			PromptSettingButton.Location = new Point(228, 93);
			PromptSettingButton.Name = "PromptSettingButton";
			PromptSettingButton.Size = new Size(230, 31);
			PromptSettingButton.TabIndex = 3;
			PromptSettingButton.Text = "设置提示语";
			PromptSettingButton.UseVisualStyleBackColor = true;
			PromptSettingButton.Click += PromptSettingButton_Click;
			// 
			// AISettingButton
			// 
			AISettingButton.Location = new Point(8, 93);
			AISettingButton.Name = "AISettingButton";
			AISettingButton.Size = new Size(214, 31);
			AISettingButton.TabIndex = 2;
			AISettingButton.Text = "API设定";
			AISettingButton.UseVisualStyleBackColor = true;
			// 
			// AIModelArea
			// 
			AIModelArea.HideText = '\0';
			AIModelArea.InputText = "deepseek-chat";
			AIModelArea.LabelText = "AI MODEL （名称）";
			AIModelArea.Location = new Point(8, 61);
			AIModelArea.Name = "AIModelArea";
			AIModelArea.Size = new Size(450, 25);
			AIModelArea.SplitVal = 159;
			AIModelArea.TabIndex = 1;
			// 
			// AIAPIArea
			// 
			AIAPIArea.HideText = '\0';
			AIAPIArea.InputText = "https://api.deepseek.com";
			AIAPIArea.LabelText = "AI API （网址）";
			AIAPIArea.Location = new Point(8, 29);
			AIAPIArea.Name = "AIAPIArea";
			AIAPIArea.Size = new Size(450, 25);
			AIAPIArea.SplitVal = 159;
			AIAPIArea.TabIndex = 0;
			// 
			// CaptureBox
			// 
			CaptureBox.Controls.Add(PageLinkListBoxManageButton);
			CaptureBox.Controls.Add(LinkDeleteButton);
			CaptureBox.Controls.Add(button1);
			CaptureBox.Controls.Add(FileImportButton);
			CaptureBox.Controls.Add(PageLinkListBox);
			CaptureBox.Controls.Add(labeledInput1);
			CaptureBox.Location = new Point(4, 212);
			CaptureBox.Name = "CaptureBox";
			CaptureBox.Size = new Size(813, 211);
			CaptureBox.TabIndex = 2;
			CaptureBox.TabStop = false;
			CaptureBox.Text = "数据采集";
			// 
			// PageLinkListBoxManageButton
			// 
			PageLinkListBoxManageButton.Location = new Point(491, 135);
			PageLinkListBoxManageButton.Name = "PageLinkListBoxManageButton";
			PageLinkListBoxManageButton.Size = new Size(165, 31);
			PageLinkListBoxManageButton.TabIndex = 4;
			PageLinkListBoxManageButton.Text = "管理条目";
			PageLinkListBoxManageButton.UseVisualStyleBackColor = true;
			PageLinkListBoxManageButton.Click += PageLinkListBoxManageButton_Click;
			// 
			// LinkDeleteButton
			// 
			LinkDeleteButton.Location = new Point(491, 98);
			LinkDeleteButton.Name = "LinkDeleteButton";
			LinkDeleteButton.Size = new Size(165, 31);
			LinkDeleteButton.TabIndex = 4;
			LinkDeleteButton.Text = "删除选中条目";
			LinkDeleteButton.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.Location = new Point(491, 26);
			button1.Name = "button1";
			button1.Size = new Size(165, 31);
			button1.TabIndex = 2;
			button1.Text = "增加条目";
			button1.UseVisualStyleBackColor = true;
			// 
			// FileImportButton
			// 
			FileImportButton.Location = new Point(491, 61);
			FileImportButton.Name = "FileImportButton";
			FileImportButton.Size = new Size(165, 31);
			FileImportButton.TabIndex = 2;
			FileImportButton.Text = "从文件导入";
			FileImportButton.UseVisualStyleBackColor = true;
			// 
			// PageLinkListBox
			// 
			PageLinkListBox.FormattingEnabled = true;
			PageLinkListBox.ItemHeight = 22;
			PageLinkListBox.Location = new Point(8, 61);
			PageLinkListBox.Name = "PageLinkListBox";
			PageLinkListBox.ScrollAlwaysVisible = true;
			PageLinkListBox.Size = new Size(477, 136);
			PageLinkListBox.TabIndex = 1;
			PageLinkListBox.SelectedIndexChanged += PageLinkListBox_SelectedIndexChanged;
			// 
			// labeledInput1
			// 
			labeledInput1.HideText = '\0';
			labeledInput1.InputText = "";
			labeledInput1.LabelText = "Discrimination";
			labeledInput1.Location = new Point(8, 29);
			labeledInput1.Name = "labeledInput1";
			labeledInput1.Size = new Size(477, 25);
			labeledInput1.SplitVal = 155;
			labeledInput1.TabIndex = 0;
			// 
			// SystemBox
			// 
			SystemBox.Controls.Add(UserSignTextBox);
			SystemBox.Controls.Add(PlatformVisibleButton);
			SystemBox.Location = new Point(565, 429);
			SystemBox.Name = "SystemBox";
			SystemBox.Size = new Size(252, 168);
			SystemBox.TabIndex = 2;
			SystemBox.TabStop = false;
			SystemBox.Text = "系统对接";
			// 
			// UserSignTextBox
			// 
			UserSignTextBox.Dock = DockStyle.Top;
			UserSignTextBox.Font = new Font("微软雅黑 Consolas", 7.841584F, FontStyle.Regular, GraphicsUnit.Point, 134);
			UserSignTextBox.Location = new Point(3, 26);
			UserSignTextBox.Multiline = true;
			UserSignTextBox.Name = "UserSignTextBox";
			UserSignTextBox.Size = new Size(246, 98);
			UserSignTextBox.TabIndex = 3;
			// 
			// PlatformVisibleButton
			// 
			PlatformVisibleButton.Location = new Point(3, 130);
			PlatformVisibleButton.Name = "PlatformVisibleButton";
			PlatformVisibleButton.Size = new Size(246, 32);
			PlatformVisibleButton.TabIndex = 2;
			PlatformVisibleButton.Text = "显示/隐藏凭据文本框";
			PlatformVisibleButton.UseVisualStyleBackColor = true;
			PlatformVisibleButton.Click += PlatformVisibleButton_Click;
			// 
			// menuStrip1
			// 
			menuStrip1.BackColor = Color.Beige;
			menuStrip1.Font = new Font("Microsoft YaHei UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 134);
			menuStrip1.ImageScalingSize = new Size(17, 17);
			menuStrip1.Items.AddRange(new ToolStripItem[] { 文件ToolStripMenuItem, 设定ToolStripMenuItem, 关于ToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new Padding(7, 2, 0, 2);
			menuStrip1.Size = new Size(1493, 34);
			menuStrip1.TabIndex = 3;
			menuStrip1.Text = "menuStrip1";
			// 
			// 文件ToolStripMenuItem
			// 
			文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
			文件ToolStripMenuItem.Size = new Size(62, 30);
			文件ToolStripMenuItem.Text = "文件";
			// 
			// 设定ToolStripMenuItem
			// 
			设定ToolStripMenuItem.Name = "设定ToolStripMenuItem";
			设定ToolStripMenuItem.Size = new Size(62, 30);
			设定ToolStripMenuItem.Text = "设定";
			// 
			// 关于ToolStripMenuItem
			// 
			关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
			关于ToolStripMenuItem.Size = new Size(62, 30);
			关于ToolStripMenuItem.Text = "关于";
			// 
			// LinkListMenu
			// 
			LinkListMenu.ImageScalingSize = new Size(17, 17);
			LinkListMenu.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripSeparator2, toolStripMenuItem3 });
			LinkListMenu.Name = "contextMenuStrip1";
			LinkListMenu.Size = new Size(144, 82);
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new Size(143, 24);
			toolStripMenuItem1.Text = "在上方新增";
			// 
			// toolStripMenuItem2
			// 
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new Size(143, 24);
			toolStripMenuItem2.Text = "在下方新增";
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(140, 6);
			// 
			// toolStripMenuItem3
			// 
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new Size(143, 24);
			toolStripMenuItem3.Text = "删除";
			// 
			// UploadButton
			// 
			UploadButton.Location = new Point(240, 603);
			UploadButton.Name = "UploadButton";
			UploadButton.Size = new Size(577, 35);
			UploadButton.TabIndex = 4;
			UploadButton.Text = "上传到系统";
			UploadButton.UseVisualStyleBackColor = true;
			UploadButton.Click += UploadButton_Click;
			// 
			// ArticleGeneratorProgressBar
			// 
			ArticleGeneratorProgressBar.Location = new Point(6, 138);
			ArticleGeneratorProgressBar.Name = "ArticleGeneratorProgressBar";
			ArticleGeneratorProgressBar.Size = new Size(535, 24);
			ArticleGeneratorProgressBar.TabIndex = 3;
			// 
			// PageProcessBox
			// 
			PageProcessBox.Controls.Add(label1);
			PageProcessBox.Controls.Add(PageDivClassList);
			PageProcessBox.Controls.Add(PageLink);
			PageProcessBox.Controls.Add(PageProcessButton);
			PageProcessBox.Controls.Add(DetailChecker);
			PageProcessBox.Controls.Add(ArticleGeneratorProgressBar);
			PageProcessBox.Location = new Point(4, 429);
			PageProcessBox.Name = "PageProcessBox";
			PageProcessBox.Size = new Size(555, 168);
			PageProcessBox.TabIndex = 5;
			PageProcessBox.TabStop = false;
			PageProcessBox.Text = "链接处理";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(8, 67);
			label1.Name = "label1";
			label1.Size = new Size(133, 44);
			label1.TabIndex = 7;
			label1.Text = "包含所需内容的\r\ndiv所属class名";
			// 
			// PageDivClassList
			// 
			PageDivClassList.FormattingEnabled = true;
			PageDivClassList.ItemHeight = 22;
			PageDivClassList.Items.AddRange(new object[] { "white-wrap", "contentbox" });
			PageDivClassList.Location = new Point(147, 65);
			PageDivClassList.Name = "PageDivClassList";
			PageDivClassList.ScrollAlwaysVisible = true;
			PageDivClassList.Size = new Size(124, 48);
			PageDivClassList.TabIndex = 5;
			// 
			// PageLink
			// 
			PageLink.HideText = '\0';
			PageLink.InputText = "";
			PageLink.LabelText = "链接";
			PageLink.Location = new Point(8, 29);
			PageLink.Name = "PageLink";
			PageLink.Size = new Size(533, 25);
			PageLink.SplitVal = 44;
			PageLink.TabIndex = 6;
			// 
			// PageProcessButton
			// 
			PageProcessButton.Location = new Point(406, 73);
			PageProcessButton.Name = "PageProcessButton";
			PageProcessButton.Size = new Size(135, 31);
			PageProcessButton.TabIndex = 5;
			PageProcessButton.Text = "开始处理";
			PageProcessButton.UseVisualStyleBackColor = true;
			PageProcessButton.Click += PageProcessButton_Click;
			// 
			// DetailChecker
			// 
			DetailChecker.AutoSize = true;
			DetailChecker.Location = new Point(277, 76);
			DetailChecker.Name = "DetailChecker";
			DetailChecker.Size = new Size(131, 26);
			DetailChecker.TabIndex = 4;
			DetailChecker.Text = "确认各项配置";
			DetailChecker.UseVisualStyleBackColor = true;
			// 
			// ArticleClearButton
			// 
			ArticleClearButton.Location = new Point(4, 603);
			ArticleClearButton.Name = "ArticleClearButton";
			ArticleClearButton.Size = new Size(230, 35);
			ArticleClearButton.TabIndex = 4;
			ArticleClearButton.Text = "清除编辑器";
			ArticleClearButton.UseVisualStyleBackColor = true;
			// 
			// LinkReloadChecker
			// 
			LinkReloadChecker.AutoSize = true;
			LinkReloadChecker.Location = new Point(7, 644);
			LinkReloadChecker.Name = "LinkReloadChecker";
			LinkReloadChecker.Size = new Size(182, 26);
			LinkReloadChecker.TabIndex = 4;
			LinkReloadChecker.Text = "切换至列表下一条目";
			LinkReloadChecker.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(9F, 22F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Linen;
			ClientSize = new Size(1493, 773);
			Controls.Add(PageProcessBox);
			Controls.Add(ArticleClearButton);
			Controls.Add(LinkReloadChecker);
			Controls.Add(UploadButton);
			Controls.Add(SystemBox);
			Controls.Add(CaptureBox);
			Controls.Add(AIBox);
			Controls.Add(ArticleBox);
			Controls.Add(menuStrip1);
			Font = new Font("微软雅黑 Consolas", 12.1188116F, FontStyle.Regular, GraphicsUnit.Point, 134);
			MainMenuStrip = menuStrip1;
			Name = "Form1";
			Text = "Laoliu666_Qieyou文章快速填充工具";
			ArticleBox.ResumeLayout(false);
			AIBox.ResumeLayout(false);
			PromptListMenu.ResumeLayout(false);
			CaptureBox.ResumeLayout(false);
			SystemBox.ResumeLayout(false);
			SystemBox.PerformLayout();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			LinkListMenu.ResumeLayout(false);
			PageProcessBox.ResumeLayout(false);
			PageProcessBox.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox ArticleBox;
		private RichTextBox Article;
		private GroupBox AIBox;
		private GroupBox CaptureBox;
		private GroupBox SystemBox;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem 文件ToolStripMenuItem;
		private ToolStripMenuItem 设定ToolStripMenuItem;
		private ToolStripMenuItem 关于ToolStripMenuItem;
		private LabeledInput labeledInput1;
		private LabeledInput AIAPIArea;
		private Button AISettingButton;
		private LabeledInput AIModelArea;
		private ListBox PromptPreviewList;
		private Button PromptSettingButton;
		private LabeledInput ArticleTitle;
		private Button TextBoldButton;
		private LabeledInput ArticleTags;
		private Button TextAlignButton;
		private Button PlatformVisibleButton;
		private ListBox PageLinkListBox;
		private ContextMenuStrip PromptListMenu;
		private ToolStripMenuItem 在上方新增ToolStripMenuItem;
		private ToolStripMenuItem 在下方新增ToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem 删除ToolStripMenuItem;
		private ContextMenuStrip LinkListMenu;
		private ToolStripMenuItem toolStripMenuItem1;
		private ToolStripMenuItem toolStripMenuItem2;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem toolStripMenuItem3;
		private LabeledInput ArticleSource;
		private LabeledInput ArticleAuthor;
		private Button UploadButton;
		private Button LinkDeleteButton;
		private ProgressBar ArticleGeneratorProgressBar;
		private Button FileImportButton;
		private GroupBox PageProcessBox;
		private LabeledInput PageLink;
		private Button PageProcessButton;
		private CheckBox DetailChecker;
		private Label label1;
		private ListBox PageDivClassList;
		private Button button1;
		private Button ArticleClearButton;
		private CheckBox LinkReloadChecker;
		private TextBox UserSignTextBox;
		private Button PageLinkListBoxManageButton;
		private System.ComponentModel.BackgroundWorker ProgressBarBackground;
		private Button PictureEditButton;
		private Button SelectPosterButton;
	}
}
