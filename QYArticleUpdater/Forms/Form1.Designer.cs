namespace QYArticleUpdater
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
			ArticleGameName = new LabeledInput();
			groupBox1 = new GroupBox();
			PictureQuickSizeButton = new Button();
			ArticlePicturePreview = new PictureBox();
			PicPreviewMenu = new ContextMenuStrip(components);
			PreviewImageCopy = new ToolStripMenuItem();
			TransformedPreviewImageCopy = new ToolStripMenuItem();
			NextPicButton = new Button();
			PrevPicButton = new Button();
			PictureFileNameLabel = new Label();
			PictureInsertButton = new Button();
			PictureEditButton = new Button();
			PosterGroupBox = new GroupBox();
			PosterPictureView = new PictureBox();
			AdjustPosterSize = new Button();
			SelectDefaultPosterButton = new Button();
			SelectPosterButton = new Button();
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
			label2 = new Label();
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
			PageProcessBox = new GroupBox();
			SkipAI = new CheckBox();
			ArticleGenerateLog = new ListBox();
			label1 = new Label();
			PageDivClassList = new ListBox();
			PageLink = new LabeledInput();
			PageProcessButton = new Button();
			DetailChecker = new CheckBox();
			ArticleClearButton = new Button();
			LinkReloadChecker = new CheckBox();
			ProgressBarBackground = new System.ComponentModel.BackgroundWorker();
			ArticleUploadNow = new RadioButton();
			ArticleUploadLater = new RadioButton();
			ArticleAsDraft = new CheckBox();
			LoginButton = new Button();
			ArticleTimePicker = new DateTimePicker();
			TimeRandomizeButton = new Button();
			ArticleBox.SuspendLayout();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ArticlePicturePreview).BeginInit();
			PicPreviewMenu.SuspendLayout();
			PosterGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PosterPictureView).BeginInit();
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
			ArticleBox.Controls.Add(ArticleGameName);
			ArticleBox.Controls.Add(groupBox1);
			ArticleBox.Controls.Add(PosterGroupBox);
			ArticleBox.Controls.Add(ArticleSource);
			ArticleBox.Controls.Add(ArticleAuthor);
			ArticleBox.Controls.Add(TextAlignButton);
			ArticleBox.Controls.Add(ArticleTags);
			ArticleBox.Controls.Add(TextBoldButton);
			ArticleBox.Controls.Add(ArticleTitle);
			ArticleBox.Controls.Add(Article);
			ArticleBox.Location = new Point(914, 37);
			ArticleBox.Name = "ArticleBox";
			ArticleBox.Size = new Size(657, 711);
			ArticleBox.TabIndex = 0;
			ArticleBox.TabStop = false;
			ArticleBox.Text = "文章预览";
			// 
			// ArticleGameName
			// 
			ArticleGameName.Font = new Font("微软雅黑 Consolas", 10.6930695F);
			ArticleGameName.HideText = '\0';
			ArticleGameName.InputText = "";
			ArticleGameName.LabelText = "游戏名";
			ArticleGameName.Location = new Point(455, 24);
			ArticleGameName.Name = "ArticleGameName";
			ArticleGameName.Size = new Size(194, 24);
			ArticleGameName.SplitVal = 68;
			ArticleGameName.TabIndex = 9;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(PictureQuickSizeButton);
			groupBox1.Controls.Add(ArticlePicturePreview);
			groupBox1.Controls.Add(NextPicButton);
			groupBox1.Controls.Add(PrevPicButton);
			groupBox1.Controls.Add(PictureFileNameLabel);
			groupBox1.Controls.Add(PictureInsertButton);
			groupBox1.Controls.Add(PictureEditButton);
			groupBox1.Font = new Font("微软雅黑 Consolas", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			groupBox1.Location = new Point(277, 80);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(372, 149);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "正文图片预览";
			// 
			// PictureQuickSizeButton
			// 
			PictureQuickSizeButton.Location = new Point(103, 113);
			PictureQuickSizeButton.Name = "PictureQuickSizeButton";
			PictureQuickSizeButton.Size = new Size(94, 30);
			PictureQuickSizeButton.TabIndex = 11;
			PictureQuickSizeButton.Text = "一键批量处理";
			PictureQuickSizeButton.UseVisualStyleBackColor = true;
			PictureQuickSizeButton.Click += PictureQuickSizeButton_Click;
			// 
			// ArticlePicturePreview
			// 
			ArticlePicturePreview.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ArticlePicturePreview.ContextMenuStrip = PicPreviewMenu;
			ArticlePicturePreview.Location = new Point(6, 18);
			ArticlePicturePreview.Name = "ArticlePicturePreview";
			ArticlePicturePreview.Size = new Size(191, 89);
			ArticlePicturePreview.SizeMode = PictureBoxSizeMode.Zoom;
			ArticlePicturePreview.TabIndex = 10;
			ArticlePicturePreview.TabStop = false;
			ArticlePicturePreview.Paint += ArticlePicturePreview_Paint;
			// 
			// PicPreviewMenu
			// 
			PicPreviewMenu.Font = new Font("Microsoft YaHei UI", 13F);
			PicPreviewMenu.ImageScalingSize = new Size(17, 17);
			PicPreviewMenu.Items.AddRange(new ToolStripItem[] { PreviewImageCopy, TransformedPreviewImageCopy });
			PicPreviewMenu.Name = "PicPreviewMenu";
			PicPreviewMenu.Size = new Size(256, 64);
			// 
			// PreviewImageCopy
			// 
			PreviewImageCopy.Name = "PreviewImageCopy";
			PreviewImageCopy.Size = new Size(255, 30);
			PreviewImageCopy.Text = "复制图像（原图）";
			PreviewImageCopy.Click += PreviewImageCopy_Click;
			// 
			// TransformedPreviewImageCopy
			// 
			TransformedPreviewImageCopy.Name = "TransformedPreviewImageCopy";
			TransformedPreviewImageCopy.Size = new Size(255, 30);
			TransformedPreviewImageCopy.Text = "复制图像（变换后）";
			// 
			// NextPicButton
			// 
			NextPicButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			NextPicButton.Location = new Point(288, 83);
			NextPicButton.Name = "NextPicButton";
			NextPicButton.Size = new Size(78, 24);
			NextPicButton.TabIndex = 9;
			NextPicButton.Text = "下一张";
			NextPicButton.UseVisualStyleBackColor = true;
			NextPicButton.Click += NextPicButton_Click;
			// 
			// PrevPicButton
			// 
			PrevPicButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			PrevPicButton.Location = new Point(203, 83);
			PrevPicButton.Name = "PrevPicButton";
			PrevPicButton.Size = new Size(78, 24);
			PrevPicButton.TabIndex = 9;
			PrevPicButton.Text = "上一张";
			PrevPicButton.UseVisualStyleBackColor = true;
			PrevPicButton.Click += PrevPicButton_Click;
			// 
			// PictureFileNameLabel
			// 
			PictureFileNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			PictureFileNameLabel.AutoSize = true;
			PictureFileNameLabel.Location = new Point(203, 18);
			PictureFileNameLabel.Name = "PictureFileNameLabel";
			PictureFileNameLabel.Size = new Size(50, 17);
			PictureFileNameLabel.TabIndex = 8;
			PictureFileNameLabel.Text = "label2";
			// 
			// PictureInsertButton
			// 
			PictureInsertButton.Location = new Point(203, 113);
			PictureInsertButton.Name = "PictureInsertButton";
			PictureInsertButton.Size = new Size(163, 30);
			PictureInsertButton.TabIndex = 7;
			PictureInsertButton.Text = "插入本图片（无需换行）";
			PictureInsertButton.UseVisualStyleBackColor = true;
			PictureInsertButton.Click += PictureInsertButton_Click;
			// 
			// PictureEditButton
			// 
			PictureEditButton.Location = new Point(6, 113);
			PictureEditButton.Name = "PictureEditButton";
			PictureEditButton.Size = new Size(94, 30);
			PictureEditButton.TabIndex = 7;
			PictureEditButton.Text = "内页图片编辑";
			PictureEditButton.UseVisualStyleBackColor = true;
			PictureEditButton.Click += PictureEditButton_Click;
			// 
			// PosterGroupBox
			// 
			PosterGroupBox.Controls.Add(PosterPictureView);
			PosterGroupBox.Controls.Add(AdjustPosterSize);
			PosterGroupBox.Controls.Add(SelectDefaultPosterButton);
			PosterGroupBox.Controls.Add(SelectPosterButton);
			PosterGroupBox.Font = new Font("微软雅黑 Consolas", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			PosterGroupBox.Location = new Point(6, 80);
			PosterGroupBox.Name = "PosterGroupBox";
			PosterGroupBox.Size = new Size(265, 119);
			PosterGroupBox.TabIndex = 8;
			PosterGroupBox.TabStop = false;
			PosterGroupBox.Text = "封面图片预览";
			// 
			// PosterPictureView
			// 
			PosterPictureView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			PosterPictureView.Location = new Point(6, 24);
			PosterPictureView.Name = "PosterPictureView";
			PosterPictureView.Size = new Size(150, 90);
			PosterPictureView.SizeMode = PictureBoxSizeMode.Zoom;
			PosterPictureView.TabIndex = 8;
			PosterPictureView.TabStop = false;
			// 
			// AdjustPosterSize
			// 
			AdjustPosterSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			AdjustPosterSize.Font = new Font("微软雅黑 Consolas", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			AdjustPosterSize.Location = new Point(163, 85);
			AdjustPosterSize.Name = "AdjustPosterSize";
			AdjustPosterSize.Size = new Size(96, 28);
			AdjustPosterSize.TabIndex = 7;
			AdjustPosterSize.Text = "裁切变换封面";
			AdjustPosterSize.UseVisualStyleBackColor = true;
			AdjustPosterSize.Click += AdjustPosterSize_Click;
			// 
			// SelectDefaultPosterButton
			// 
			SelectDefaultPosterButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			SelectDefaultPosterButton.Font = new Font("微软雅黑 Consolas", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			SelectDefaultPosterButton.Location = new Point(163, 54);
			SelectDefaultPosterButton.Name = "SelectDefaultPosterButton";
			SelectDefaultPosterButton.Size = new Size(96, 28);
			SelectDefaultPosterButton.TabIndex = 7;
			SelectDefaultPosterButton.Text = "使用默认图片";
			SelectDefaultPosterButton.UseVisualStyleBackColor = true;
			SelectDefaultPosterButton.Click += SelectDefaultPosterButton_Click;
			// 
			// SelectPosterButton
			// 
			SelectPosterButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			SelectPosterButton.Font = new Font("微软雅黑 Consolas", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			SelectPosterButton.Location = new Point(163, 24);
			SelectPosterButton.Name = "SelectPosterButton";
			SelectPosterButton.Size = new Size(96, 28);
			SelectPosterButton.TabIndex = 7;
			SelectPosterButton.Text = "从文件选择";
			SelectPosterButton.UseVisualStyleBackColor = true;
			SelectPosterButton.Click += SelectPosterButton_Click;
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
			TextAlignButton.Location = new Point(61, 205);
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
			ArticleTags.Size = new Size(234, 21);
			ArticleTags.SplitVal = 65;
			ArticleTags.TabIndex = 3;
			// 
			// TextBoldButton
			// 
			TextBoldButton.Font = new Font("微软雅黑 Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
			TextBoldButton.Location = new Point(5, 205);
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
			ArticleTitle.Size = new Size(444, 21);
			ArticleTitle.SplitVal = 66;
			ArticleTitle.TabIndex = 1;
			// 
			// Article
			// 
			Article.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			Article.EnableAutoDragDrop = true;
			Article.Location = new Point(3, 236);
			Article.Name = "Article";
			Article.Size = new Size(647, 472);
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
			AIBox.Size = new Size(904, 169);
			AIBox.TabIndex = 1;
			AIBox.TabStop = false;
			AIBox.Text = "AI工具使用";
			// 
			// PromptPreviewList
			// 
			PromptPreviewList.ContextMenuStrip = PromptListMenu;
			PromptPreviewList.FormattingEnabled = true;
			PromptPreviewList.ItemHeight = 22;
			PromptPreviewList.Location = new Point(464, 24);
			PromptPreviewList.Name = "PromptPreviewList";
			PromptPreviewList.ScrollAlwaysVisible = true;
			PromptPreviewList.Size = new Size(434, 136);
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
			CaptureBox.Location = new Point(4, 411);
			CaptureBox.Name = "CaptureBox";
			CaptureBox.Size = new Size(630, 183);
			CaptureBox.TabIndex = 2;
			CaptureBox.TabStop = false;
			CaptureBox.Text = "数据采集";
			// 
			// PageLinkListBoxManageButton
			// 
			PageLinkListBoxManageButton.Location = new Point(462, 140);
			PageLinkListBoxManageButton.Name = "PageLinkListBoxManageButton";
			PageLinkListBoxManageButton.Size = new Size(165, 31);
			PageLinkListBoxManageButton.TabIndex = 4;
			PageLinkListBoxManageButton.Text = "管理条目";
			PageLinkListBoxManageButton.UseVisualStyleBackColor = true;
			PageLinkListBoxManageButton.Click += PageLinkListBoxManageButton_Click;
			// 
			// LinkDeleteButton
			// 
			LinkDeleteButton.Location = new Point(462, 102);
			LinkDeleteButton.Name = "LinkDeleteButton";
			LinkDeleteButton.Size = new Size(165, 31);
			LinkDeleteButton.TabIndex = 4;
			LinkDeleteButton.Text = "删除选中条目";
			LinkDeleteButton.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.Location = new Point(462, 28);
			button1.Name = "button1";
			button1.Size = new Size(165, 31);
			button1.TabIndex = 2;
			button1.Text = "增加条目";
			button1.UseVisualStyleBackColor = true;
			// 
			// FileImportButton
			// 
			FileImportButton.Location = new Point(462, 64);
			FileImportButton.Name = "FileImportButton";
			FileImportButton.Size = new Size(165, 31);
			FileImportButton.TabIndex = 2;
			FileImportButton.Text = "从文件导入";
			FileImportButton.UseVisualStyleBackColor = true;
			FileImportButton.Click += FileImportButton_Click;
			// 
			// PageLinkListBox
			// 
			PageLinkListBox.FormattingEnabled = true;
			PageLinkListBox.ItemHeight = 22;
			PageLinkListBox.Location = new Point(8, 61);
			PageLinkListBox.Name = "PageLinkListBox";
			PageLinkListBox.ScrollAlwaysVisible = true;
			PageLinkListBox.Size = new Size(450, 114);
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
			labeledInput1.Size = new Size(450, 25);
			labeledInput1.SplitVal = 146;
			labeledInput1.TabIndex = 0;
			// 
			// SystemBox
			// 
			SystemBox.Controls.Add(UserSignTextBox);
			SystemBox.Controls.Add(label2);
			SystemBox.Controls.Add(PlatformVisibleButton);
			SystemBox.Location = new Point(640, 411);
			SystemBox.Name = "SystemBox";
			SystemBox.Size = new Size(268, 183);
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
			UserSignTextBox.Size = new Size(262, 112);
			UserSignTextBox.TabIndex = 3;
			// 
			// label2
			// 
			label2.Location = new Point(20, 51);
			label2.Name = "label2";
			label2.Size = new Size(214, 74);
			label2.TabIndex = 4;
			label2.Text = "若上传提示失败\r\n请检查本凭据是否有效";
			label2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// PlatformVisibleButton
			// 
			PlatformVisibleButton.Location = new Point(3, 145);
			PlatformVisibleButton.Name = "PlatformVisibleButton";
			PlatformVisibleButton.Size = new Size(262, 32);
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
			menuStrip1.Size = new Size(1584, 34);
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
			UploadButton.Location = new Point(643, 603);
			UploadButton.Name = "UploadButton";
			UploadButton.Size = new Size(262, 67);
			UploadButton.TabIndex = 4;
			UploadButton.Text = "上传到系统";
			UploadButton.UseVisualStyleBackColor = true;
			UploadButton.Click += UploadButton_Click;
			// 
			// PageProcessBox
			// 
			PageProcessBox.Controls.Add(SkipAI);
			PageProcessBox.Controls.Add(ArticleGenerateLog);
			PageProcessBox.Controls.Add(label1);
			PageProcessBox.Controls.Add(PageDivClassList);
			PageProcessBox.Controls.Add(PageLink);
			PageProcessBox.Controls.Add(PageProcessButton);
			PageProcessBox.Controls.Add(DetailChecker);
			PageProcessBox.Location = new Point(4, 212);
			PageProcessBox.Name = "PageProcessBox";
			PageProcessBox.Size = new Size(904, 193);
			PageProcessBox.TabIndex = 5;
			PageProcessBox.TabStop = false;
			PageProcessBox.Text = "链接处理";
			// 
			// SkipAI
			// 
			SkipAI.AutoSize = true;
			SkipAI.Font = new Font("微软雅黑 Consolas", 10.6930695F, FontStyle.Regular, GraphicsUnit.Point, 134);
			SkipAI.Location = new Point(639, 104);
			SkipAI.Name = "SkipAI";
			SkipAI.Size = new Size(246, 24);
			SkipAI.TabIndex = 9;
			SkipAI.Text = "(调试用）不改写，直接使用原文";
			SkipAI.UseVisualStyleBackColor = true;
			// 
			// ArticleGenerateLog
			// 
			ArticleGenerateLog.Font = new Font("微软雅黑 Consolas", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			ArticleGenerateLog.FormattingEnabled = true;
			ArticleGenerateLog.Location = new Point(8, 61);
			ArticleGenerateLog.Name = "ArticleGenerateLog";
			ArticleGenerateLog.Size = new Size(619, 123);
			ArticleGenerateLog.TabIndex = 8;
			ArticleGenerateLog.DoubleClick += ArticleGenerateLog_DoubleClick;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(634, 30);
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
			PageDivClassList.Location = new Point(773, 28);
			PageDivClassList.Name = "PageDivClassList";
			PageDivClassList.ScrollAlwaysVisible = true;
			PageDivClassList.Size = new Size(124, 70);
			PageDivClassList.TabIndex = 5;
			// 
			// PageLink
			// 
			PageLink.Font = new Font("微软雅黑 Consolas", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			PageLink.HideText = '\0';
			PageLink.InputText = "111";
			PageLink.LabelText = "链接";
			PageLink.Location = new Point(6, 22);
			PageLink.Margin = new Padding(2);
			PageLink.Name = "PageLink";
			PageLink.Size = new Size(621, 32);
			PageLink.SplitVal = 50;
			PageLink.TabIndex = 6;
			// 
			// PageProcessButton
			// 
			PageProcessButton.Location = new Point(765, 154);
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
			DetailChecker.Location = new Point(636, 157);
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
			ArticleClearButton.Size = new Size(185, 35);
			ArticleClearButton.TabIndex = 4;
			ArticleClearButton.Text = "清除编辑器";
			ArticleClearButton.UseVisualStyleBackColor = true;
			ArticleClearButton.Click += ArticleClearButton_Click;
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
			// ArticleUploadNow
			// 
			ArticleUploadNow.AutoSize = true;
			ArticleUploadNow.Location = new Point(572, 607);
			ArticleUploadNow.Name = "ArticleUploadNow";
			ArticleUploadNow.Size = new Size(62, 26);
			ArticleUploadNow.TabIndex = 6;
			ArticleUploadNow.TabStop = true;
			ArticleUploadNow.Text = "即时";
			ArticleUploadNow.UseVisualStyleBackColor = true;
			// 
			// ArticleUploadLater
			// 
			ArticleUploadLater.AutoSize = true;
			ArticleUploadLater.Location = new Point(572, 638);
			ArticleUploadLater.Name = "ArticleUploadLater";
			ArticleUploadLater.Size = new Size(62, 26);
			ArticleUploadLater.TabIndex = 6;
			ArticleUploadLater.TabStop = true;
			ArticleUploadLater.Text = "定时";
			ArticleUploadLater.UseVisualStyleBackColor = true;
			ArticleUploadLater.CheckedChanged += ArticleUploadLater_CheckedChanged;
			// 
			// ArticleAsDraft
			// 
			ArticleAsDraft.AutoSize = true;
			ArticleAsDraft.Location = new Point(503, 607);
			ArticleAsDraft.Name = "ArticleAsDraft";
			ArticleAsDraft.Size = new Size(63, 26);
			ArticleAsDraft.TabIndex = 7;
			ArticleAsDraft.Text = "草稿";
			ArticleAsDraft.UseVisualStyleBackColor = true;
			// 
			// LoginButton
			// 
			LoginButton.Location = new Point(259, 609);
			LoginButton.Name = "LoginButton";
			LoginButton.Size = new Size(203, 29);
			LoginButton.TabIndex = 8;
			LoginButton.Text = "(上传不正常时用)登录";
			LoginButton.UseVisualStyleBackColor = true;
			LoginButton.Click += LoginButton_Click;
			// 
			// ArticleTimePicker
			// 
			ArticleTimePicker.Font = new Font("微软雅黑 Consolas", 10.6930695F, FontStyle.Regular, GraphicsUnit.Point, 134);
			ArticleTimePicker.Format = DateTimePickerFormat.Custom;
			ArticleTimePicker.Location = new Point(343, 640);
			ArticleTimePicker.Name = "ArticleTimePicker";
			ArticleTimePicker.Size = new Size(223, 27);
			ArticleTimePicker.TabIndex = 9;
			// 
			// TimeRandomizeButton
			// 
			TimeRandomizeButton.Font = new Font("微软雅黑 Consolas", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			TimeRandomizeButton.Location = new Point(259, 640);
			TimeRandomizeButton.Name = "TimeRandomizeButton";
			TimeRandomizeButton.Size = new Size(79, 27);
			TimeRandomizeButton.TabIndex = 10;
			TimeRandomizeButton.Text = "随机时间";
			TimeRandomizeButton.UseVisualStyleBackColor = true;
			TimeRandomizeButton.Click += TimeRandomizeButton_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(9F, 22F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Linen;
			ClientSize = new Size(1584, 760);
			Controls.Add(TimeRandomizeButton);
			Controls.Add(ArticleTimePicker);
			Controls.Add(LoginButton);
			Controls.Add(ArticleAsDraft);
			Controls.Add(ArticleUploadLater);
			Controls.Add(ArticleUploadNow);
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
			Text = "Laoliu666_QY文章快速填充工具";
			ArticleBox.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)ArticlePicturePreview).EndInit();
			PicPreviewMenu.ResumeLayout(false);
			PosterGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)PosterPictureView).EndInit();
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
		private GroupBox PosterGroupBox;
		private PictureBox PosterPictureView;
		private GroupBox groupBox1;
		private PictureBox ArticlePicturePreview;
		private Button NextPicButton;
		private Button PrevPicButton;
		private Label PictureFileNameLabel;
		private Label label2;
		private RadioButton ArticleUploadNow;
		private RadioButton ArticleUploadLater;
		private CheckBox ArticleAsDraft;
		private Button PictureInsertButton;
		private ListBox ArticleGenerateLog;
		private Button PictureQuickSizeButton;
		private CheckBox SkipAI;
		private LabeledInput ArticleGameName;
		private Button LoginButton;
		private Button AdjustPosterSize;
		private Button SelectDefaultPosterButton;
		private DateTimePicker ArticleTimePicker;
		private ContextMenuStrip PicPreviewMenu;
		private ToolStripMenuItem PreviewImageCopy;
		private ToolStripMenuItem TransformedPreviewImageCopy;
		private Button TimeRandomizeButton;
	}
}
