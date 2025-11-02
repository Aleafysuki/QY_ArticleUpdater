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
			label3 = new Label();
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
			CoverImageCropper = new Button();
			PosterPictureView = new PictureBox();
			PosterPicturePaste = new ContextMenuStrip(components);
			粘贴图像ToolStripMenuItem = new ToolStripMenuItem();
			AdjustPosterSize = new Button();
			SelectDefaultPosterButton = new Button();
			SelectPosterButton = new Button();
			ArticleSource = new LabeledInput();
			ArticleAuthor = new LabeledInput();
			ArticleTags = new LabeledInput();
			TextBoldButton = new Button();
			TextAlignButton = new Button();
			ArticleTitle = new LabeledInput();
			Article = new RichTextBox();
			AritcleMenu = new ContextMenuStrip(components);
			LinkReloadChecker = new CheckBox();
			ArticleClearButton = new Button();
			AIBox = new GroupBox();
			PromptPreviewList = new ListBox();
			PromptListMenu = new ContextMenuStrip(components);
			在上方新增ToolStripMenuItem = new ToolStripMenuItem();
			在下方新增ToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			删除ToolStripMenuItem = new ToolStripMenuItem();
			PromptSettingButton = new Button();
			AISettingButton = new Button();
			PageDivClassList = new ListBox();
			label1 = new Label();
			AIModelArea = new LabeledInput();
			AIAPIArea = new LabeledInput();
			SystemBox = new GroupBox();
			UserSignTextBox = new TextBox();
			label2 = new Label();
			PlatformVisibleButton = new Button();
			CaptureBox = new GroupBox();
			PageLinkListBoxManageButton = new Button();
			LinkDeleteButton = new Button();
			button1 = new Button();
			FileImportButton = new Button();
			PageLinkListBox = new ListBox();
			labeledInput1 = new LabeledInput();
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
			ArticleGenerateLog = new ListBox();
			PageLink = new LabeledInput();
			DetailChecker = new CheckBox();
			SkipAI = new CheckBox();
			LoginButton = new Button();
			FullAutoMode = new CheckBox();
			PageProcessButton = new Button();
			ProgressBarBackground = new System.ComponentModel.BackgroundWorker();
			ArticleUploadNow = new RadioButton();
			ArticleUploadLater = new RadioButton();
			ArticleAsDraft = new CheckBox();
			ArticleTimePicker = new DateTimePicker();
			TimeRandomizeButton = new Button();
			DelayMode = new CheckBox();
			MinDelay = new LabeledInput();
			MaxDelay = new LabeledInput();
			tabControl1 = new TabControl();
			tabPage1 = new TabPage();
			tabPage2 = new TabPage();
			SaveArticleButton = new Button();
			SaveAllArticleButton = new Button();
			ArticleBox.SuspendLayout();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ArticlePicturePreview).BeginInit();
			PicPreviewMenu.SuspendLayout();
			PosterGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PosterPictureView).BeginInit();
			PosterPicturePaste.SuspendLayout();
			AIBox.SuspendLayout();
			PromptListMenu.SuspendLayout();
			SystemBox.SuspendLayout();
			CaptureBox.SuspendLayout();
			menuStrip1.SuspendLayout();
			LinkListMenu.SuspendLayout();
			PageProcessBox.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			SuspendLayout();
			// 
			// ArticleBox
			// 
			ArticleBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ArticleBox.Controls.Add(label3);
			ArticleBox.Controls.Add(ArticleGameName);
			ArticleBox.Controls.Add(groupBox1);
			ArticleBox.Controls.Add(PosterGroupBox);
			ArticleBox.Controls.Add(ArticleSource);
			ArticleBox.Controls.Add(ArticleAuthor);
			ArticleBox.Controls.Add(ArticleTags);
			ArticleBox.Controls.Add(TextBoldButton);
			ArticleBox.Controls.Add(TextAlignButton);
			ArticleBox.Controls.Add(ArticleTitle);
			ArticleBox.Controls.Add(Article);
			ArticleBox.Controls.Add(LinkReloadChecker);
			ArticleBox.Controls.Add(ArticleClearButton);
			ArticleBox.Location = new Point(539, 5);
			ArticleBox.Margin = new Padding(3, 2, 3, 2);
			ArticleBox.Name = "ArticleBox";
			ArticleBox.Padding = new Padding(3, 2, 3, 2);
			ArticleBox.Size = new Size(698, 700);
			ArticleBox.TabIndex = 0;
			ArticleBox.TabStop = false;
			ArticleBox.Text = "文章预览";
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			label3.BackColor = Color.Transparent;
			label3.Font = new Font("宋体", 5F);
			label3.Location = new Point(84, 34);
			label3.Name = "label3";
			label3.Size = new Size(366, 15);
			label3.TabIndex = 0;
			label3.Text = "0              5              10              15              20              25\r\n····+····|····+····|····+····|····+····|····+····|";
			// 
			// ArticleGameName
			// 
			ArticleGameName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			ArticleGameName.Font = new Font("Microsoft YaHei UI", 10F);
			ArticleGameName.HideText = '\0';
			ArticleGameName.InputText = "";
			ArticleGameName.LabelText = "游戏名";
			ArticleGameName.Location = new Point(457, 49);
			ArticleGameName.Margin = new Padding(4);
			ArticleGameName.Name = "ArticleGameName";
			ArticleGameName.Size = new Size(235, 27);
			ArticleGameName.SplitVal = 65;
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
			groupBox1.Font = new Font("Microsoft YaHei UI", 10F);
			groupBox1.Location = new Point(302, 111);
			groupBox1.Margin = new Padding(3, 2, 3, 2);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(3, 2, 3, 2);
			groupBox1.Size = new Size(398, 149);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "正文图片预览";
			// 
			// PictureQuickSizeButton
			// 
			PictureQuickSizeButton.Location = new Point(121, 113);
			PictureQuickSizeButton.Margin = new Padding(3, 2, 3, 2);
			PictureQuickSizeButton.Name = "PictureQuickSizeButton";
			PictureQuickSizeButton.Size = new Size(107, 29);
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
			ArticlePicturePreview.Margin = new Padding(3, 2, 3, 2);
			ArticlePicturePreview.Name = "ArticlePicturePreview";
			ArticlePicturePreview.Size = new Size(148, 91);
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
			PicPreviewMenu.Size = new Size(243, 60);
			// 
			// PreviewImageCopy
			// 
			PreviewImageCopy.Name = "PreviewImageCopy";
			PreviewImageCopy.Size = new Size(242, 28);
			PreviewImageCopy.Text = "复制图像（原图）";
			PreviewImageCopy.Click += PreviewImageCopy_Click;
			// 
			// TransformedPreviewImageCopy
			// 
			TransformedPreviewImageCopy.Name = "TransformedPreviewImageCopy";
			TransformedPreviewImageCopy.Size = new Size(242, 28);
			TransformedPreviewImageCopy.Text = "复制图像（变换后）";
			TransformedPreviewImageCopy.Click += TransformedPreviewImageCopy_Click;
			// 
			// NextPicButton
			// 
			NextPicButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			NextPicButton.Location = new Point(280, 82);
			NextPicButton.Margin = new Padding(3, 2, 3, 2);
			NextPicButton.Name = "NextPicButton";
			NextPicButton.Size = new Size(113, 27);
			NextPicButton.TabIndex = 9;
			NextPicButton.Text = "下一张";
			NextPicButton.UseVisualStyleBackColor = true;
			NextPicButton.Click += NextPicButton_Click;
			// 
			// PrevPicButton
			// 
			PrevPicButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			PrevPicButton.Location = new Point(161, 82);
			PrevPicButton.Margin = new Padding(3, 2, 3, 2);
			PrevPicButton.Name = "PrevPicButton";
			PrevPicButton.Size = new Size(113, 27);
			PrevPicButton.TabIndex = 9;
			PrevPicButton.Text = "上一张";
			PrevPicButton.UseVisualStyleBackColor = true;
			PrevPicButton.Click += PrevPicButton_Click;
			// 
			// PictureFileNameLabel
			// 
			PictureFileNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			PictureFileNameLabel.Location = new Point(160, 18);
			PictureFileNameLabel.Name = "PictureFileNameLabel";
			PictureFileNameLabel.Size = new Size(232, 64);
			PictureFileNameLabel.TabIndex = 8;
			PictureFileNameLabel.Text = "label2";
			// 
			// PictureInsertButton
			// 
			PictureInsertButton.Location = new Point(235, 113);
			PictureInsertButton.Margin = new Padding(3, 2, 3, 2);
			PictureInsertButton.Name = "PictureInsertButton";
			PictureInsertButton.Size = new Size(158, 29);
			PictureInsertButton.TabIndex = 7;
			PictureInsertButton.Text = "插入本图片(无需换行)";
			PictureInsertButton.UseVisualStyleBackColor = true;
			PictureInsertButton.Click += PictureInsertButton_Click;
			// 
			// PictureEditButton
			// 
			PictureEditButton.Location = new Point(6, 113);
			PictureEditButton.Margin = new Padding(3, 2, 3, 2);
			PictureEditButton.Name = "PictureEditButton";
			PictureEditButton.Size = new Size(109, 29);
			PictureEditButton.TabIndex = 7;
			PictureEditButton.Text = "内页图片编辑";
			PictureEditButton.UseVisualStyleBackColor = true;
			PictureEditButton.Click += PictureEditButton_Click;
			// 
			// PosterGroupBox
			// 
			PosterGroupBox.Controls.Add(CoverImageCropper);
			PosterGroupBox.Controls.Add(PosterPictureView);
			PosterGroupBox.Controls.Add(AdjustPosterSize);
			PosterGroupBox.Controls.Add(SelectDefaultPosterButton);
			PosterGroupBox.Controls.Add(SelectPosterButton);
			PosterGroupBox.Font = new Font("Microsoft YaHei UI", 10F);
			PosterGroupBox.Location = new Point(6, 111);
			PosterGroupBox.Margin = new Padding(3, 2, 3, 2);
			PosterGroupBox.Name = "PosterGroupBox";
			PosterGroupBox.Padding = new Padding(3, 2, 3, 2);
			PosterGroupBox.Size = new Size(290, 149);
			PosterGroupBox.TabIndex = 8;
			PosterGroupBox.TabStop = false;
			PosterGroupBox.Text = "封面图片预览";
			// 
			// CoverImageCropper
			// 
			CoverImageCropper.Font = new Font("Microsoft YaHei UI", 10F);
			CoverImageCropper.Location = new Point(175, 114);
			CoverImageCropper.Margin = new Padding(3, 2, 3, 2);
			CoverImageCropper.Name = "CoverImageCropper";
			CoverImageCropper.Size = new Size(111, 27);
			CoverImageCropper.TabIndex = 9;
			CoverImageCropper.Text = "封面图片编辑";
			CoverImageCropper.UseVisualStyleBackColor = true;
			CoverImageCropper.Click += CoverImageCropper_Click;
			// 
			// PosterPictureView
			// 
			PosterPictureView.ContextMenuStrip = PosterPicturePaste;
			PosterPictureView.Location = new Point(6, 24);
			PosterPictureView.Margin = new Padding(3, 2, 3, 2);
			PosterPictureView.Name = "PosterPictureView";
			PosterPictureView.Size = new Size(167, 118);
			PosterPictureView.SizeMode = PictureBoxSizeMode.Zoom;
			PosterPictureView.TabIndex = 8;
			PosterPictureView.TabStop = false;
			// 
			// PosterPicturePaste
			// 
			PosterPicturePaste.Font = new Font("Microsoft YaHei UI", 13F);
			PosterPicturePaste.ImageScalingSize = new Size(17, 17);
			PosterPicturePaste.Items.AddRange(new ToolStripItem[] { 粘贴图像ToolStripMenuItem });
			PosterPicturePaste.Name = "PosterPicturePaste";
			PosterPicturePaste.Size = new Size(153, 32);
			// 
			// 粘贴图像ToolStripMenuItem
			// 
			粘贴图像ToolStripMenuItem.Name = "粘贴图像ToolStripMenuItem";
			粘贴图像ToolStripMenuItem.Size = new Size(152, 28);
			粘贴图像ToolStripMenuItem.Text = "粘贴图像";
			粘贴图像ToolStripMenuItem.Click += 粘贴图像ToolStripMenuItem_Click;
			// 
			// AdjustPosterSize
			// 
			AdjustPosterSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			AdjustPosterSize.Font = new Font("Microsoft Sans Serif", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			AdjustPosterSize.Location = new Point(175, 85);
			AdjustPosterSize.Margin = new Padding(3, 2, 3, 2);
			AdjustPosterSize.Name = "AdjustPosterSize";
			AdjustPosterSize.Size = new Size(111, 27);
			AdjustPosterSize.TabIndex = 7;
			AdjustPosterSize.Text = "裁切变换封面";
			AdjustPosterSize.UseVisualStyleBackColor = true;
			AdjustPosterSize.Click += AdjustPosterSize_Click;
			// 
			// SelectDefaultPosterButton
			// 
			SelectDefaultPosterButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			SelectDefaultPosterButton.Font = new Font("Microsoft Sans Serif", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			SelectDefaultPosterButton.Location = new Point(175, 54);
			SelectDefaultPosterButton.Margin = new Padding(3, 2, 3, 2);
			SelectDefaultPosterButton.Name = "SelectDefaultPosterButton";
			SelectDefaultPosterButton.Size = new Size(111, 27);
			SelectDefaultPosterButton.TabIndex = 7;
			SelectDefaultPosterButton.Text = "使用默认图片";
			SelectDefaultPosterButton.UseVisualStyleBackColor = true;
			SelectDefaultPosterButton.Click += SelectDefaultPosterButton_Click;
			// 
			// SelectPosterButton
			// 
			SelectPosterButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			SelectPosterButton.Font = new Font("Microsoft Sans Serif", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			SelectPosterButton.Location = new Point(175, 24);
			SelectPosterButton.Margin = new Padding(3, 2, 3, 2);
			SelectPosterButton.Name = "SelectPosterButton";
			SelectPosterButton.Size = new Size(111, 27);
			SelectPosterButton.TabIndex = 7;
			SelectPosterButton.Text = "从文件选择";
			SelectPosterButton.UseVisualStyleBackColor = true;
			SelectPosterButton.Click += SelectPosterButton_Click;
			// 
			// ArticleSource
			// 
			ArticleSource.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			ArticleSource.Font = new Font("Microsoft YaHei UI", 10F);
			ArticleSource.HideText = '\0';
			ArticleSource.InputText = "网络";
			ArticleSource.LabelText = "来源";
			ArticleSource.Location = new Point(457, 78);
			ArticleSource.Margin = new Padding(4);
			ArticleSource.Name = "ArticleSource";
			ArticleSource.Size = new Size(235, 27);
			ArticleSource.SplitVal = 65;
			ArticleSource.TabIndex = 6;
			// 
			// ArticleAuthor
			// 
			ArticleAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			ArticleAuthor.Font = new Font("Microsoft YaHei UI", 10F);
			ArticleAuthor.HideText = '\0';
			ArticleAuthor.InputText = "Kave";
			ArticleAuthor.LabelText = "作者";
			ArticleAuthor.Location = new Point(457, 20);
			ArticleAuthor.Margin = new Padding(4);
			ArticleAuthor.Name = "ArticleAuthor";
			ArticleAuthor.Size = new Size(235, 27);
			ArticleAuthor.SplitVal = 64;
			ArticleAuthor.TabIndex = 5;
			// 
			// ArticleTags
			// 
			ArticleTags.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ArticleTags.Font = new Font("Microsoft YaHei UI", 10F);
			ArticleTags.HideText = '\0';
			ArticleTags.InputText = "";
			ArticleTags.LabelText = "标签Tag";
			ArticleTags.Location = new Point(6, 78);
			ArticleTags.Margin = new Padding(4);
			ArticleTags.Name = "ArticleTags";
			ArticleTags.Size = new Size(442, 27);
			ArticleTags.SplitVal = 65;
			ArticleTags.TabIndex = 3;
			// 
			// TextBoldButton
			// 
			TextBoldButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			TextBoldButton.Font = new Font("Microsoft YaHei UI", 10F);
			TextBoldButton.Location = new Point(549, 667);
			TextBoldButton.Margin = new Padding(3, 2, 3, 2);
			TextBoldButton.Name = "TextBoldButton";
			TextBoldButton.Size = new Size(144, 27);
			TextBoldButton.TabIndex = 2;
			TextBoldButton.Text = "加粗(Ctrl+B)";
			TextBoldButton.TextAlign = ContentAlignment.TopCenter;
			TextBoldButton.UseVisualStyleBackColor = true;
			TextBoldButton.Click += TextBoldButton_Click;
			// 
			// TextAlignButton
			// 
			TextAlignButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			TextAlignButton.Font = new Font("Microsoft YaHei UI", 10F);
			TextAlignButton.Location = new Point(401, 667);
			TextAlignButton.Margin = new Padding(3, 2, 3, 2);
			TextAlignButton.Name = "TextAlignButton";
			TextAlignButton.Size = new Size(144, 27);
			TextAlignButton.TabIndex = 4;
			TextAlignButton.Text = "居中(Ctrl+H)";
			TextAlignButton.TextAlign = ContentAlignment.TopCenter;
			TextAlignButton.UseVisualStyleBackColor = true;
			TextAlignButton.Click += TextAlignButton_Click;
			// 
			// ArticleTitle
			// 
			ArticleTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ArticleTitle.Font = new Font("Microsoft YaHei UI", 10F);
			ArticleTitle.HideText = '\0';
			ArticleTitle.InputText = "";
			ArticleTitle.LabelText = "标题";
			ArticleTitle.Location = new Point(6, 49);
			ArticleTitle.Margin = new Padding(4);
			ArticleTitle.Name = "ArticleTitle";
			ArticleTitle.Size = new Size(443, 27);
			ArticleTitle.SplitVal = 65;
			ArticleTitle.TabIndex = 1;
			// 
			// Article
			// 
			Article.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			Article.ContextMenuStrip = AritcleMenu;
			Article.EnableAutoDragDrop = true;
			Article.Font = new Font("Microsoft YaHei UI", 9F);
			Article.Location = new Point(7, 264);
			Article.Margin = new Padding(3, 2, 3, 2);
			Article.Name = "Article";
			Article.Size = new Size(685, 398);
			Article.TabIndex = 0;
			Article.Text = "";
			Article.KeyDown += TextShortcutKey;
			// 
			// AritcleMenu
			// 
			AritcleMenu.Name = "AritcleMenu";
			AritcleMenu.Size = new Size(61, 4);
			// 
			// LinkReloadChecker
			// 
			LinkReloadChecker.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			LinkReloadChecker.AutoSize = true;
			LinkReloadChecker.Font = new Font("Microsoft YaHei UI", 10F);
			LinkReloadChecker.Location = new Point(106, 669);
			LinkReloadChecker.Margin = new Padding(3, 2, 3, 2);
			LinkReloadChecker.Name = "LinkReloadChecker";
			LinkReloadChecker.Size = new Size(196, 24);
			LinkReloadChecker.TabIndex = 4;
			LinkReloadChecker.Text = "清除时切换至列表下一条目";
			LinkReloadChecker.UseVisualStyleBackColor = true;
			// 
			// ArticleClearButton
			// 
			ArticleClearButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			ArticleClearButton.Font = new Font("Microsoft YaHei UI", 10F);
			ArticleClearButton.Location = new Point(-1, 666);
			ArticleClearButton.Margin = new Padding(3, 2, 3, 2);
			ArticleClearButton.Name = "ArticleClearButton";
			ArticleClearButton.Size = new Size(101, 28);
			ArticleClearButton.TabIndex = 4;
			ArticleClearButton.Text = "清除编辑器";
			ArticleClearButton.UseVisualStyleBackColor = true;
			ArticleClearButton.Click += ArticleClearButton_Click;
			// 
			// AIBox
			// 
			AIBox.Controls.Add(PromptPreviewList);
			AIBox.Controls.Add(PromptSettingButton);
			AIBox.Controls.Add(AISettingButton);
			AIBox.Controls.Add(PageDivClassList);
			AIBox.Controls.Add(label1);
			AIBox.Controls.Add(AIModelArea);
			AIBox.Controls.Add(AIAPIArea);
			AIBox.Controls.Add(SystemBox);
			AIBox.Location = new Point(274, 208);
			AIBox.Margin = new Padding(3, 2, 3, 2);
			AIBox.Name = "AIBox";
			AIBox.Padding = new Padding(3, 2, 3, 2);
			AIBox.Size = new Size(99, 22);
			AIBox.TabIndex = 1;
			AIBox.TabStop = false;
			AIBox.Text = "AI工具使用";
			AIBox.Visible = false;
			// 
			// PromptPreviewList
			// 
			PromptPreviewList.ContextMenuStrip = PromptListMenu;
			PromptPreviewList.FormattingEnabled = true;
			PromptPreviewList.ItemHeight = 20;
			PromptPreviewList.Location = new Point(464, 24);
			PromptPreviewList.Margin = new Padding(3, 2, 3, 2);
			PromptPreviewList.Name = "PromptPreviewList";
			PromptPreviewList.ScrollAlwaysVisible = true;
			PromptPreviewList.Size = new Size(435, 124);
			PromptPreviewList.TabIndex = 4;
			// 
			// PromptListMenu
			// 
			PromptListMenu.ImageScalingSize = new Size(17, 17);
			PromptListMenu.Items.AddRange(new ToolStripItem[] { 在上方新增ToolStripMenuItem, 在下方新增ToolStripMenuItem, toolStripSeparator1, 删除ToolStripMenuItem });
			PromptListMenu.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
			PromptListMenu.Name = "contextMenuStrip1";
			PromptListMenu.Size = new Size(137, 76);
			// 
			// 在上方新增ToolStripMenuItem
			// 
			在上方新增ToolStripMenuItem.Name = "在上方新增ToolStripMenuItem";
			在上方新增ToolStripMenuItem.Size = new Size(136, 22);
			在上方新增ToolStripMenuItem.Text = "在上方新增";
			// 
			// 在下方新增ToolStripMenuItem
			// 
			在下方新增ToolStripMenuItem.Name = "在下方新增ToolStripMenuItem";
			在下方新增ToolStripMenuItem.Size = new Size(136, 22);
			在下方新增ToolStripMenuItem.Text = "在下方新增";
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(133, 6);
			// 
			// 删除ToolStripMenuItem
			// 
			删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
			删除ToolStripMenuItem.Size = new Size(136, 22);
			删除ToolStripMenuItem.Text = "删除";
			// 
			// PromptSettingButton
			// 
			PromptSettingButton.Location = new Point(228, 93);
			PromptSettingButton.Margin = new Padding(3, 2, 3, 2);
			PromptSettingButton.Name = "PromptSettingButton";
			PromptSettingButton.Size = new Size(230, 32);
			PromptSettingButton.TabIndex = 3;
			PromptSettingButton.Text = "设置提示语";
			PromptSettingButton.UseVisualStyleBackColor = true;
			PromptSettingButton.Click += PromptSettingButton_Click;
			// 
			// AISettingButton
			// 
			AISettingButton.Location = new Point(8, 93);
			AISettingButton.Margin = new Padding(3, 2, 3, 2);
			AISettingButton.Name = "AISettingButton";
			AISettingButton.Size = new Size(215, 32);
			AISettingButton.TabIndex = 2;
			AISettingButton.Text = "API设定";
			AISettingButton.UseVisualStyleBackColor = true;
			// 
			// PageDivClassList
			// 
			PageDivClassList.FormattingEnabled = true;
			PageDivClassList.ItemHeight = 20;
			PageDivClassList.Items.AddRange(new object[] { "white-wrap", "contentbox", "consumption-page-gridarea_content" });
			PageDivClassList.Location = new Point(125, 129);
			PageDivClassList.Margin = new Padding(3, 2, 3, 2);
			PageDivClassList.Name = "PageDivClassList";
			PageDivClassList.ScrollAlwaysVisible = true;
			PageDivClassList.Size = new Size(124, 64);
			PageDivClassList.TabIndex = 5;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(9, 129);
			label1.Name = "label1";
			label1.Size = new Size(114, 40);
			label1.TabIndex = 7;
			label1.Text = "包含所需内容的\r\ndiv所属class名";
			// 
			// AIModelArea
			// 
			AIModelArea.HideText = '\0';
			AIModelArea.InputText = "deepseek-chat";
			AIModelArea.LabelText = "AI MODEL （名称）";
			AIModelArea.Location = new Point(6, 52);
			AIModelArea.Margin = new Padding(3, 2, 3, 2);
			AIModelArea.Name = "AIModelArea";
			AIModelArea.Size = new Size(350, 21);
			AIModelArea.SplitVal = 123;
			AIModelArea.TabIndex = 1;
			// 
			// AIAPIArea
			// 
			AIAPIArea.HideText = '\0';
			AIAPIArea.InputText = "https://api.deepseek.com";
			AIAPIArea.LabelText = "AI API （网址）";
			AIAPIArea.Location = new Point(6, 24);
			AIAPIArea.Margin = new Padding(3, 2, 3, 2);
			AIAPIArea.Name = "AIAPIArea";
			AIAPIArea.Size = new Size(350, 21);
			AIAPIArea.SplitVal = 123;
			AIAPIArea.TabIndex = 0;
			// 
			// SystemBox
			// 
			SystemBox.Controls.Add(UserSignTextBox);
			SystemBox.Controls.Add(label2);
			SystemBox.Controls.Add(PlatformVisibleButton);
			SystemBox.Location = new Point(275, 152);
			SystemBox.Margin = new Padding(3, 2, 3, 2);
			SystemBox.Name = "SystemBox";
			SystemBox.Padding = new Padding(3, 2, 3, 2);
			SystemBox.Size = new Size(269, 182);
			SystemBox.TabIndex = 2;
			SystemBox.TabStop = false;
			SystemBox.Text = "系统对接";
			// 
			// UserSignTextBox
			// 
			UserSignTextBox.Dock = DockStyle.Top;
			UserSignTextBox.Font = new Font("Microsoft Sans Serif", 7.841584F, FontStyle.Regular, GraphicsUnit.Point, 134);
			UserSignTextBox.Location = new Point(3, 21);
			UserSignTextBox.Margin = new Padding(3, 2, 3, 2);
			UserSignTextBox.Multiline = true;
			UserSignTextBox.Name = "UserSignTextBox";
			UserSignTextBox.Size = new Size(263, 111);
			UserSignTextBox.TabIndex = 3;
			// 
			// label2
			// 
			label2.Location = new Point(19, 52);
			label2.Name = "label2";
			label2.Size = new Size(215, 74);
			label2.TabIndex = 4;
			label2.Text = "若上传提示失败\r\n请检查本凭据是否有效";
			label2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// PlatformVisibleButton
			// 
			PlatformVisibleButton.Location = new Point(3, 145);
			PlatformVisibleButton.Margin = new Padding(3, 2, 3, 2);
			PlatformVisibleButton.Name = "PlatformVisibleButton";
			PlatformVisibleButton.Size = new Size(262, 33);
			PlatformVisibleButton.TabIndex = 2;
			PlatformVisibleButton.Text = "显示/隐藏凭据文本框";
			PlatformVisibleButton.UseVisualStyleBackColor = true;
			PlatformVisibleButton.Click += PlatformVisibleButton_Click;
			// 
			// CaptureBox
			// 
			CaptureBox.Controls.Add(PageLinkListBoxManageButton);
			CaptureBox.Controls.Add(LinkDeleteButton);
			CaptureBox.Controls.Add(button1);
			CaptureBox.Controls.Add(FileImportButton);
			CaptureBox.Controls.Add(PageLinkListBox);
			CaptureBox.Controls.Add(labeledInput1);
			CaptureBox.Location = new Point(6, 5);
			CaptureBox.Margin = new Padding(3, 2, 3, 2);
			CaptureBox.Name = "CaptureBox";
			CaptureBox.Padding = new Padding(3, 2, 3, 2);
			CaptureBox.Size = new Size(527, 215);
			CaptureBox.TabIndex = 2;
			CaptureBox.TabStop = false;
			CaptureBox.Text = "数据采集";
			// 
			// PageLinkListBoxManageButton
			// 
			PageLinkListBoxManageButton.Location = new Point(394, 174);
			PageLinkListBoxManageButton.Margin = new Padding(3, 2, 3, 2);
			PageLinkListBoxManageButton.Name = "PageLinkListBoxManageButton";
			PageLinkListBoxManageButton.Size = new Size(123, 32);
			PageLinkListBoxManageButton.TabIndex = 4;
			PageLinkListBoxManageButton.Text = "管理条目";
			PageLinkListBoxManageButton.UseVisualStyleBackColor = true;
			PageLinkListBoxManageButton.Click += PageLinkListBoxManageButton_Click;
			// 
			// LinkDeleteButton
			// 
			LinkDeleteButton.Location = new Point(266, 174);
			LinkDeleteButton.Margin = new Padding(3, 2, 3, 2);
			LinkDeleteButton.Name = "LinkDeleteButton";
			LinkDeleteButton.Size = new Size(123, 32);
			LinkDeleteButton.TabIndex = 4;
			LinkDeleteButton.Text = "删除选中条目";
			LinkDeleteButton.UseVisualStyleBackColor = true;
			LinkDeleteButton.Click += LinkDeleteButton_Click;
			// 
			// button1
			// 
			button1.Location = new Point(8, 174);
			button1.Margin = new Padding(3, 2, 3, 2);
			button1.Name = "button1";
			button1.Size = new Size(123, 32);
			button1.TabIndex = 2;
			button1.Text = "增加条目";
			button1.UseVisualStyleBackColor = true;
			// 
			// FileImportButton
			// 
			FileImportButton.Location = new Point(137, 174);
			FileImportButton.Margin = new Padding(3, 2, 3, 2);
			FileImportButton.Name = "FileImportButton";
			FileImportButton.Size = new Size(123, 32);
			FileImportButton.TabIndex = 2;
			FileImportButton.Text = "从文件导入";
			FileImportButton.UseVisualStyleBackColor = true;
			FileImportButton.Click += FileImportButton_Click;
			// 
			// PageLinkListBox
			// 
			PageLinkListBox.FormattingEnabled = true;
			PageLinkListBox.ItemHeight = 20;
			PageLinkListBox.Location = new Point(8, 61);
			PageLinkListBox.Margin = new Padding(3, 2, 3, 2);
			PageLinkListBox.Name = "PageLinkListBox";
			PageLinkListBox.ScrollAlwaysVisible = true;
			PageLinkListBox.Size = new Size(509, 104);
			PageLinkListBox.TabIndex = 1;
			PageLinkListBox.SelectedIndexChanged += PageLinkListBox_SelectedIndexChanged;
			// 
			// labeledInput1
			// 
			labeledInput1.HideText = '\0';
			labeledInput1.InputText = "";
			labeledInput1.LabelText = "Discrimination";
			labeledInput1.Location = new Point(8, 28);
			labeledInput1.Margin = new Padding(3, 2, 3, 2);
			labeledInput1.Name = "labeledInput1";
			labeledInput1.Size = new Size(509, 25);
			labeledInput1.SplitVal = 166;
			labeledInput1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			menuStrip1.BackColor = Color.Beige;
			menuStrip1.Font = new Font("Microsoft YaHei UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 134);
			menuStrip1.ImageScalingSize = new Size(17, 17);
			menuStrip1.Items.AddRange(new ToolStripItem[] { 文件ToolStripMenuItem, 设定ToolStripMenuItem, 关于ToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new Padding(8, 2, 0, 2);
			menuStrip1.Size = new Size(1269, 33);
			menuStrip1.TabIndex = 3;
			menuStrip1.Text = "menuStrip1";
			// 
			// 文件ToolStripMenuItem
			// 
			文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
			文件ToolStripMenuItem.Size = new Size(60, 29);
			文件ToolStripMenuItem.Text = "文件";
			// 
			// 设定ToolStripMenuItem
			// 
			设定ToolStripMenuItem.Name = "设定ToolStripMenuItem";
			设定ToolStripMenuItem.Size = new Size(60, 29);
			设定ToolStripMenuItem.Text = "设定";
			// 
			// 关于ToolStripMenuItem
			// 
			关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
			关于ToolStripMenuItem.Size = new Size(60, 29);
			关于ToolStripMenuItem.Text = "关于";
			// 
			// LinkListMenu
			// 
			LinkListMenu.ImageScalingSize = new Size(17, 17);
			LinkListMenu.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripSeparator2, toolStripMenuItem3 });
			LinkListMenu.Name = "contextMenuStrip1";
			LinkListMenu.Size = new Size(137, 76);
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new Size(136, 22);
			toolStripMenuItem1.Text = "在上方新增";
			// 
			// toolStripMenuItem2
			// 
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new Size(136, 22);
			toolStripMenuItem2.Text = "在下方新增";
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(133, 6);
			// 
			// toolStripMenuItem3
			// 
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new Size(136, 22);
			toolStripMenuItem3.Text = "删除";
			// 
			// UploadButton
			// 
			UploadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			UploadButton.Location = new Point(418, 423);
			UploadButton.Margin = new Padding(3, 2, 3, 2);
			UploadButton.Name = "UploadButton";
			UploadButton.Size = new Size(135, 27);
			UploadButton.TabIndex = 4;
			UploadButton.Text = "手动上传到系统";
			UploadButton.UseVisualStyleBackColor = true;
			UploadButton.Click += UploadButton_Click;
			// 
			// PageProcessBox
			// 
			PageProcessBox.Controls.Add(ArticleGenerateLog);
			PageProcessBox.Controls.Add(PageLink);
			PageProcessBox.Controls.Add(DetailChecker);
			PageProcessBox.Controls.Add(SkipAI);
			PageProcessBox.Controls.Add(LoginButton);
			PageProcessBox.Controls.Add(AIBox);
			PageProcessBox.Location = new Point(6, 224);
			PageProcessBox.Margin = new Padding(3, 2, 3, 2);
			PageProcessBox.Name = "PageProcessBox";
			PageProcessBox.Padding = new Padding(3, 2, 3, 2);
			PageProcessBox.Size = new Size(527, 241);
			PageProcessBox.TabIndex = 5;
			PageProcessBox.TabStop = false;
			PageProcessBox.Text = "链接处理";
			// 
			// ArticleGenerateLog
			// 
			ArticleGenerateLog.Font = new Font("Microsoft Sans Serif", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			ArticleGenerateLog.FormattingEnabled = true;
			ArticleGenerateLog.ItemHeight = 15;
			ArticleGenerateLog.Location = new Point(8, 61);
			ArticleGenerateLog.Margin = new Padding(3, 2, 3, 2);
			ArticleGenerateLog.Name = "ArticleGenerateLog";
			ArticleGenerateLog.Size = new Size(509, 109);
			ArticleGenerateLog.TabIndex = 8;
			ArticleGenerateLog.DoubleClick += ArticleGenerateLog_DoubleClick;
			// 
			// PageLink
			// 
			PageLink.Font = new Font("Microsoft Sans Serif", 7.841584F, FontStyle.Regular, GraphicsUnit.Point, 134);
			PageLink.HideText = '\0';
			PageLink.InputText = "111";
			PageLink.LabelText = "链接";
			PageLink.Location = new Point(9, 23);
			PageLink.Margin = new Padding(2);
			PageLink.Name = "PageLink";
			PageLink.Size = new Size(508, 34);
			PageLink.SplitVal = 40;
			PageLink.TabIndex = 6;
			// 
			// DetailChecker
			// 
			DetailChecker.AutoSize = true;
			DetailChecker.Location = new Point(8, 174);
			DetailChecker.Margin = new Padding(3, 2, 3, 2);
			DetailChecker.Name = "DetailChecker";
			DetailChecker.Size = new Size(193, 24);
			DetailChecker.TabIndex = 4;
			DetailChecker.Text = "（调试用）确认各项配置";
			DetailChecker.UseVisualStyleBackColor = true;
			// 
			// SkipAI
			// 
			SkipAI.AutoSize = true;
			SkipAI.Location = new Point(274, 174);
			SkipAI.Margin = new Padding(3, 2, 3, 2);
			SkipAI.Name = "SkipAI";
			SkipAI.Size = new Size(243, 24);
			SkipAI.TabIndex = 9;
			SkipAI.Text = "(调试用）不改写，直接使用原文";
			SkipAI.UseVisualStyleBackColor = true;
			// 
			// LoginButton
			// 
			LoginButton.Location = new Point(6, 202);
			LoginButton.Margin = new Padding(3, 2, 3, 2);
			LoginButton.Name = "LoginButton";
			LoginButton.Size = new Size(195, 28);
			LoginButton.TabIndex = 8;
			LoginButton.Text = "(上传不正常时用)登录";
			LoginButton.UseVisualStyleBackColor = true;
			LoginButton.Click += LoginButton_Click;
			// 
			// FullAutoMode
			// 
			FullAutoMode.AutoSize = true;
			FullAutoMode.Location = new Point(300, 168);
			FullAutoMode.Margin = new Padding(3, 2, 3, 2);
			FullAutoMode.Name = "FullAutoMode";
			FullAutoMode.Size = new Size(222, 24);
			FullAutoMode.TabIndex = 10;
			FullAutoMode.Text = "全自动模式(实验性,风险自担)";
			FullAutoMode.UseVisualStyleBackColor = true;
			// 
			// PageProcessButton
			// 
			PageProcessButton.Location = new Point(292, 196);
			PageProcessButton.Margin = new Padding(3, 2, 3, 2);
			PageProcessButton.Name = "PageProcessButton";
			PageProcessButton.Size = new Size(260, 61);
			PageProcessButton.TabIndex = 5;
			PageProcessButton.Text = "开始处理";
			PageProcessButton.UseVisualStyleBackColor = true;
			PageProcessButton.Click += PageProcessButton_Click;
			// 
			// ArticleUploadNow
			// 
			ArticleUploadNow.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			ArticleUploadNow.AutoSize = true;
			ArticleUploadNow.Location = new Point(26, 390);
			ArticleUploadNow.Margin = new Padding(3, 2, 3, 2);
			ArticleUploadNow.Name = "ArticleUploadNow";
			ArticleUploadNow.Size = new Size(57, 24);
			ArticleUploadNow.TabIndex = 6;
			ArticleUploadNow.TabStop = true;
			ArticleUploadNow.Text = "即时";
			ArticleUploadNow.UseVisualStyleBackColor = true;
			// 
			// ArticleUploadLater
			// 
			ArticleUploadLater.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			ArticleUploadLater.AutoSize = true;
			ArticleUploadLater.Location = new Point(26, 424);
			ArticleUploadLater.Margin = new Padding(3, 2, 3, 2);
			ArticleUploadLater.Name = "ArticleUploadLater";
			ArticleUploadLater.Size = new Size(57, 24);
			ArticleUploadLater.TabIndex = 6;
			ArticleUploadLater.TabStop = true;
			ArticleUploadLater.Text = "定时";
			ArticleUploadLater.UseVisualStyleBackColor = true;
			ArticleUploadLater.CheckedChanged += ArticleUploadLater_CheckedChanged;
			// 
			// ArticleAsDraft
			// 
			ArticleAsDraft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			ArticleAsDraft.AutoSize = true;
			ArticleAsDraft.Location = new Point(357, 425);
			ArticleAsDraft.Margin = new Padding(3, 2, 3, 2);
			ArticleAsDraft.Name = "ArticleAsDraft";
			ArticleAsDraft.Size = new Size(58, 24);
			ArticleAsDraft.TabIndex = 7;
			ArticleAsDraft.Text = "草稿";
			ArticleAsDraft.UseVisualStyleBackColor = true;
			// 
			// ArticleTimePicker
			// 
			ArticleTimePicker.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			ArticleTimePicker.Font = new Font("Microsoft Sans Serif", 10.6930695F, FontStyle.Regular, GraphicsUnit.Point, 134);
			ArticleTimePicker.Format = DateTimePickerFormat.Custom;
			ArticleTimePicker.Location = new Point(89, 424);
			ArticleTimePicker.Margin = new Padding(3, 2, 3, 2);
			ArticleTimePicker.Name = "ArticleTimePicker";
			ArticleTimePicker.Size = new Size(168, 24);
			ArticleTimePicker.TabIndex = 9;
			// 
			// TimeRandomizeButton
			// 
			TimeRandomizeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			TimeRandomizeButton.Font = new Font("Microsoft Sans Serif", 9.267326F, FontStyle.Regular, GraphicsUnit.Point, 134);
			TimeRandomizeButton.Location = new Point(263, 423);
			TimeRandomizeButton.Margin = new Padding(3, 2, 3, 2);
			TimeRandomizeButton.Name = "TimeRandomizeButton";
			TimeRandomizeButton.Size = new Size(84, 27);
			TimeRandomizeButton.TabIndex = 10;
			TimeRandomizeButton.Text = "随机时间";
			TimeRandomizeButton.UseVisualStyleBackColor = true;
			TimeRandomizeButton.Click += TimeRandomizeButton_Click;
			// 
			// DelayMode
			// 
			DelayMode.AutoSize = true;
			DelayMode.Location = new Point(33, 168);
			DelayMode.Margin = new Padding(3, 2, 3, 2);
			DelayMode.Name = "DelayMode";
			DelayMode.Size = new Size(238, 24);
			DelayMode.TabIndex = 11;
			DelayMode.Text = "延时模式（全自动模式下可用）";
			DelayMode.UseVisualStyleBackColor = true;
			// 
			// MinDelay
			// 
			MinDelay.HideText = '\0';
			MinDelay.InputText = "15";
			MinDelay.LabelText = "最小延时(秒)";
			MinDelay.Location = new Point(31, 196);
			MinDelay.Margin = new Padding(3, 2, 3, 2);
			MinDelay.Name = "MinDelay";
			MinDelay.Size = new Size(195, 25);
			MinDelay.SplitVal = 139;
			MinDelay.TabIndex = 12;
			// 
			// MaxDelay
			// 
			MaxDelay.HideText = '\0';
			MaxDelay.InputText = "75";
			MaxDelay.LabelText = "最大延时(秒)";
			MaxDelay.Location = new Point(31, 225);
			MaxDelay.Margin = new Padding(3, 2, 3, 2);
			MaxDelay.Name = "MaxDelay";
			MaxDelay.Size = new Size(195, 25);
			MaxDelay.SplitVal = 139;
			MaxDelay.TabIndex = 12;
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Location = new Point(12, 36);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(1251, 743);
			tabControl1.TabIndex = 13;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(SaveAllArticleButton);
			tabPage1.Controls.Add(SaveArticleButton);
			tabPage1.Controls.Add(ArticleBox);
			tabPage1.Controls.Add(CaptureBox);
			tabPage1.Controls.Add(PageProcessBox);
			tabPage1.Location = new Point(4, 29);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(1243, 710);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "tabPage1";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(DelayMode);
			tabPage2.Controls.Add(UploadButton);
			tabPage2.Controls.Add(ArticleUploadNow);
			tabPage2.Controls.Add(ArticleUploadLater);
			tabPage2.Controls.Add(ArticleAsDraft);
			tabPage2.Controls.Add(ArticleTimePicker);
			tabPage2.Controls.Add(FullAutoMode);
			tabPage2.Controls.Add(TimeRandomizeButton);
			tabPage2.Controls.Add(PageProcessButton);
			tabPage2.Controls.Add(MinDelay);
			tabPage2.Controls.Add(MaxDelay);
			tabPage2.Location = new Point(4, 29);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(1232, 600);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "tabPage2";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// SaveArticleButton
			// 
			SaveArticleButton.Location = new Point(355, 476);
			SaveArticleButton.Name = "SaveArticleButton";
			SaveArticleButton.Size = new Size(168, 29);
			SaveArticleButton.TabIndex = 6;
			SaveArticleButton.Text = "保存文章";
			SaveArticleButton.UseVisualStyleBackColor = true;
			// 
			// SaveAllArticleButton
			// 
			SaveAllArticleButton.Location = new Point(355, 511);
			SaveAllArticleButton.Name = "SaveAllArticleButton";
			SaveAllArticleButton.Size = new Size(168, 29);
			SaveAllArticleButton.TabIndex = 7;
			SaveAllArticleButton.Text = "批量保存全部文章";
			SaveAllArticleButton.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(9F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Linen;
			ClientSize = new Size(1269, 786);
			Controls.Add(tabControl1);
			Controls.Add(menuStrip1);
			Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 134);
			MainMenuStrip = menuStrip1;
			Margin = new Padding(3, 2, 3, 2);
			MinimumSize = new Size(1280, 700);
			Name = "Form1";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Laoliu666_QY文章快速填充工具";
			ArticleBox.ResumeLayout(false);
			ArticleBox.PerformLayout();
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)ArticlePicturePreview).EndInit();
			PicPreviewMenu.ResumeLayout(false);
			PosterGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)PosterPictureView).EndInit();
			PosterPicturePaste.ResumeLayout(false);
			AIBox.ResumeLayout(false);
			AIBox.PerformLayout();
			PromptListMenu.ResumeLayout(false);
			SystemBox.ResumeLayout(false);
			SystemBox.PerformLayout();
			CaptureBox.ResumeLayout(false);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			LinkListMenu.ResumeLayout(false);
			PageProcessBox.ResumeLayout(false);
			PageProcessBox.PerformLayout();
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
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
		private CheckBox FullAutoMode;
		private Label label3;
		private ContextMenuStrip PosterPicturePaste;
		private ToolStripMenuItem 粘贴图像ToolStripMenuItem;
		private ContextMenuStrip AritcleMenu;
		private CheckBox DelayMode;
		private LabeledInput MinDelay;
		private LabeledInput MaxDelay;
		private Button CoverImageCropper;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private Button SaveAllArticleButton;
		private Button SaveArticleButton;
	}
}
