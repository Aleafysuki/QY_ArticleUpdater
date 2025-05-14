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
			PageLinkListBox = new ListBox();
			labeledInput1 = new LabeledInput();
			SystemBox = new GroupBox();
			PlatformLogin = new Button();
			PlatformPasswordInput = new LabeledInput();
			PlatformAccountInput = new LabeledInput();
			menuStrip1 = new MenuStrip();
			文件ToolStripMenuItem = new ToolStripMenuItem();
			设定ToolStripMenuItem = new ToolStripMenuItem();
			关于ToolStripMenuItem = new ToolStripMenuItem();
			LinkListMenu = new ContextMenuStrip(components);
			toolStripMenuItem1 = new ToolStripMenuItem();
			toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripSeparator2 = new ToolStripSeparator();
			toolStripMenuItem3 = new ToolStripMenuItem();
			ArticleBox.SuspendLayout();
			AIBox.SuspendLayout();
			PromptListMenu.SuspendLayout();
			CaptureBox.SuspendLayout();
			SystemBox.SuspendLayout();
			menuStrip1.SuspendLayout();
			LinkListMenu.SuspendLayout();
			SuspendLayout();
			// 
			// ArticleBox
			// 
			ArticleBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			ArticleBox.Controls.Add(TextAlignButton);
			ArticleBox.Controls.Add(ArticleTags);
			ArticleBox.Controls.Add(TextBoldButton);
			ArticleBox.Controls.Add(ArticleTitle);
			ArticleBox.Controls.Add(Article);
			ArticleBox.Location = new Point(824, 72);
			ArticleBox.Name = "ArticleBox";
			ArticleBox.Size = new Size(656, 608);
			ArticleBox.TabIndex = 0;
			ArticleBox.TabStop = false;
			ArticleBox.Text = "文章预览";
			// 
			// TextAlignButton
			// 
			TextAlignButton.Font = new Font("微软雅黑 Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
			TextAlignButton.Location = new Point(64, 107);
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
			ArticleTags.HideText = '\0';
			ArticleTags.InputText = "";
			ArticleTags.LabelText = "标签Tag";
			ArticleTags.Location = new Point(6, 58);
			ArticleTags.Name = "ArticleTags";
			ArticleTags.Size = new Size(341, 23);
			ArticleTags.SplitVal = 96;
			ArticleTags.TabIndex = 3;
			// 
			// TextBoldButton
			// 
			TextBoldButton.Font = new Font("微软雅黑 Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
			TextBoldButton.Location = new Point(6, 107);
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
			ArticleTitle.HideText = '\0';
			ArticleTitle.InputText = "";
			ArticleTitle.LabelText = "标题";
			ArticleTitle.Location = new Point(6, 29);
			ArticleTitle.Name = "ArticleTitle";
			ArticleTitle.Size = new Size(644, 23);
			ArticleTitle.SplitVal = 96;
			ArticleTitle.TabIndex = 1;
			// 
			// Article
			// 
			Article.Dock = DockStyle.Bottom;
			Article.EnableAutoDragDrop = true;
			Article.Location = new Point(3, 140);
			Article.Name = "Article";
			Article.Size = new Size(650, 465);
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
			CaptureBox.Controls.Add(PageLinkListBox);
			CaptureBox.Controls.Add(labeledInput1);
			CaptureBox.Location = new Point(4, 212);
			CaptureBox.Name = "CaptureBox";
			CaptureBox.Size = new Size(813, 407);
			CaptureBox.TabIndex = 2;
			CaptureBox.TabStop = false;
			CaptureBox.Text = "数据采集";
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
			SystemBox.Controls.Add(PlatformLogin);
			SystemBox.Controls.Add(PlatformPasswordInput);
			SystemBox.Controls.Add(PlatformAccountInput);
			SystemBox.Location = new Point(4, 625);
			SystemBox.Name = "SystemBox";
			SystemBox.Size = new Size(813, 135);
			SystemBox.TabIndex = 2;
			SystemBox.TabStop = false;
			SystemBox.Text = "系统对接";
			// 
			// PlatformLogin
			// 
			PlatformLogin.Location = new Point(6, 93);
			PlatformLogin.Name = "PlatformLogin";
			PlatformLogin.Size = new Size(253, 32);
			PlatformLogin.TabIndex = 2;
			PlatformLogin.Text = "登录 / 刷新登录";
			PlatformLogin.UseVisualStyleBackColor = true;
			// 
			// PlatformPasswordInput
			// 
			PlatformPasswordInput.HideText = '\0';
			PlatformPasswordInput.InputText = "";
			PlatformPasswordInput.LabelText = "平台密码";
			PlatformPasswordInput.Location = new Point(8, 61);
			PlatformPasswordInput.Name = "PlatformPasswordInput";
			PlatformPasswordInput.Size = new Size(251, 25);
			PlatformPasswordInput.SplitVal = 81;
			PlatformPasswordInput.TabIndex = 1;
			// 
			// PlatformAccountInput
			// 
			PlatformAccountInput.HideText = '\0';
			PlatformAccountInput.InputText = "";
			PlatformAccountInput.LabelText = "平台账号";
			PlatformAccountInput.Location = new Point(8, 29);
			PlatformAccountInput.Name = "PlatformAccountInput";
			PlatformAccountInput.Size = new Size(251, 25);
			PlatformAccountInput.SplitVal = 81;
			PlatformAccountInput.TabIndex = 0;
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
			// Form1
			// 
			AutoScaleDimensions = new SizeF(9F, 22F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Linen;
			ClientSize = new Size(1493, 773);
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
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			LinkListMenu.ResumeLayout(false);
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
		private LabeledInput PlatformPasswordInput;
		private LabeledInput PlatformAccountInput;
		private Button PlatformLogin;
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
	}
}
