namespace QieYouArticleUpdater
{
	partial class PictureIO
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
			PictureInput = new PictureBox();
			resolutionX = new TextBox();
			resolutionY = new TextBox();
			OutputPath = new TextBox();
			Suffix1 = new TextBox();
			Generator = new Button();
			groupBox1 = new GroupBox();
			PicFileSize = new Label();
			label1 = new Label();
			QualitySelector = new ComboBox();
			CopyGenerator = new Button();
			panel1 = new Panel();
			groupBox3 = new GroupBox();
			tableLayoutPanel1 = new TableLayoutPanel();
			LeftUp = new Button();
			Down = new Button();
			RightDown = new Button();
			Right = new Button();
			Up = new Button();
			LeftDown = new Button();
			RightUp = new Button();
			Left = new Button();
			ClickedPoint = new Label();
			Menus = new ContextMenuStrip(components);
			粘贴图像ToolStripMenuItem = new ToolStripMenuItem();
			窗口置顶ToolStripMenuItem = new ToolStripMenuItem();
			窗口透明度ToolStripMenuItem = new ToolStripMenuItem();
			Transparency0 = new ToolStripMenuItem();
			Transparency1 = new ToolStripMenuItem();
			Transparency2 = new ToolStripMenuItem();
			Transparency3 = new ToolStripMenuItem();
			Transparency4 = new ToolStripMenuItem();
			恢复PictureBox尺寸ToolStripMenuItem = new ToolStripMenuItem();
			tabControl1 = new TabControl();
			tabPage1 = new TabPage();
			groupBox4 = new GroupBox();
			ImageSherpen = new Button();
			tabPage2 = new TabPage();
			copycomplete = new Label();
			convertIframeButton = new Button();
			inputiframetext = new Label();
			outputsharediframebox = new TextBox();
			inputsharediframebox = new TextBox();
			PicList = new ImageList(components);
			PictureUploader = new Button();
			((System.ComponentModel.ISupportInitialize)PictureInput).BeginInit();
			groupBox1.SuspendLayout();
			panel1.SuspendLayout();
			groupBox3.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			Menus.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			groupBox4.SuspendLayout();
			tabPage2.SuspendLayout();
			SuspendLayout();
			// 
			// PictureInput
			// 
			PictureInput.Location = new Point(0, 0);
			PictureInput.Name = "PictureInput";
			PictureInput.Size = new Size(333, 333);
			PictureInput.SizeMode = PictureBoxSizeMode.AutoSize;
			PictureInput.TabIndex = 0;
			PictureInput.TabStop = false;
			PictureInput.DragDrop += PictureInput_DragDrop;
			PictureInput.DragEnter += PictureInput_DragEnter;
			PictureInput.DoubleClick += PasteImage;
			PictureInput.MouseClick += PictureInput_MouseClick;
			PictureInput.MouseMove += PictureInput_MouseClick;
			PictureInput.MouseUp += PictureInput_MouseUp;
			// 
			// resolutionX
			// 
			resolutionX.Location = new Point(6, 23);
			resolutionX.Name = "resolutionX";
			resolutionX.Size = new Size(100, 24);
			resolutionX.TabIndex = 1;
			resolutionX.Text = "550";
			resolutionX.TextChanged += resolution_TextChanged;
			// 
			// resolutionY
			// 
			resolutionY.Location = new Point(112, 23);
			resolutionY.Name = "resolutionY";
			resolutionY.Size = new Size(99, 24);
			resolutionY.TabIndex = 1;
			resolutionY.Text = "999";
			resolutionY.TextChanged += resolution_TextChanged;
			// 
			// OutputPath
			// 
			OutputPath.Location = new Point(6, 53);
			OutputPath.Name = "OutputPath";
			OutputPath.Size = new Size(205, 24);
			OutputPath.TabIndex = 1;
			// 
			// Suffix1
			// 
			Suffix1.Location = new Point(6, 83);
			Suffix1.Multiline = true;
			Suffix1.Name = "Suffix1";
			Suffix1.Size = new Size(100, 27);
			Suffix1.TabIndex = 1;
			Suffix1.Text = "内容";
			// 
			// Generator
			// 
			Generator.Location = new Point(557, 496);
			Generator.Name = "Generator";
			Generator.Size = new Size(100, 27);
			Generator.TabIndex = 2;
			Generator.Text = "保存图像";
			Generator.UseVisualStyleBackColor = true;
			Generator.Click += Generator_Click;
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			groupBox1.Controls.Add(PicFileSize);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(QualitySelector);
			groupBox1.Controls.Add(resolutionX);
			groupBox1.Controls.Add(resolutionY);
			groupBox1.Controls.Add(PictureUploader);
			groupBox1.Controls.Add(Suffix1);
			groupBox1.Controls.Add(OutputPath);
			groupBox1.Location = new Point(551, 6);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(220, 248);
			groupBox1.TabIndex = 3;
			groupBox1.TabStop = false;
			groupBox1.Text = "按比例缩放图像";
			// 
			// PicFileSize
			// 
			PicFileSize.Location = new Point(128, 118);
			PicFileSize.Name = "PicFileSize";
			PicFileSize.Size = new Size(83, 20);
			PicFileSize.TabIndex = 6;
			PicFileSize.Text = "--";
			PicFileSize.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(6, 118);
			label1.Name = "label1";
			label1.Size = new Size(126, 19);
			label1.TabIndex = 5;
			label1.Text = "图像预计文件大小：";
			label1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// QualitySelector
			// 
			QualitySelector.DropDownStyle = ComboBoxStyle.DropDownList;
			QualitySelector.Font = new Font("Microsoft YaHei UI", 9.267326F);
			QualitySelector.FormattingEnabled = true;
			QualitySelector.Items.AddRange(new object[] { "100%", "99%", "95%", "90%", "85%", "80%", "70%", "60%", "50%", "40%", "20%" });
			QualitySelector.Location = new Point(112, 83);
			QualitySelector.Name = "QualitySelector";
			QualitySelector.Size = new Size(99, 27);
			QualitySelector.TabIndex = 4;
			QualitySelector.SelectedIndexChanged += QualitySelector_SelectedIndexChanged;
			// 
			// CopyGenerator
			// 
			CopyGenerator.Location = new Point(663, 496);
			CopyGenerator.Name = "CopyGenerator";
			CopyGenerator.Size = new Size(100, 27);
			CopyGenerator.TabIndex = 3;
			CopyGenerator.Text = "复制图像";
			CopyGenerator.UseVisualStyleBackColor = true;
			CopyGenerator.Click += CopyGenerator_Click;
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panel1.AutoScroll = true;
			panel1.AutoScrollMargin = new Size(2, 2);
			panel1.AutoScrollMinSize = new Size(2, 2);
			panel1.BorderStyle = BorderStyle.Fixed3D;
			panel1.Controls.Add(PictureInput);
			panel1.Location = new Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new Size(542, 523);
			panel1.TabIndex = 4;
			panel1.DoubleClick += PasteImage;
			// 
			// groupBox3
			// 
			groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			groupBox3.Controls.Add(tableLayoutPanel1);
			groupBox3.Controls.Add(ClickedPoint);
			groupBox3.Location = new Point(551, 260);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(221, 163);
			groupBox3.TabIndex = 5;
			groupBox3.TabStop = false;
			groupBox3.Text = "保留图片的一部分";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel1.Controls.Add(LeftUp, 0, 0);
			tableLayoutPanel1.Controls.Add(Down, 1, 2);
			tableLayoutPanel1.Controls.Add(RightDown, 2, 2);
			tableLayoutPanel1.Controls.Add(Right, 2, 1);
			tableLayoutPanel1.Controls.Add(Up, 1, 0);
			tableLayoutPanel1.Controls.Add(LeftDown, 0, 2);
			tableLayoutPanel1.Controls.Add(RightUp, 2, 0);
			tableLayoutPanel1.Controls.Add(Left, 0, 1);
			tableLayoutPanel1.Location = new Point(6, 23);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
			tableLayoutPanel1.Size = new Size(207, 107);
			tableLayoutPanel1.TabIndex = 7;
			// 
			// LeftUp
			// 
			LeftUp.Dock = DockStyle.Fill;
			LeftUp.Location = new Point(1, 1);
			LeftUp.Margin = new Padding(1);
			LeftUp.Name = "LeftUp";
			LeftUp.Size = new Size(66, 33);
			LeftUp.TabIndex = 0;
			LeftUp.Tag = "11";
			LeftUp.Text = "左上";
			LeftUp.UseVisualStyleBackColor = true;
			LeftUp.Click += Cropper_Click;
			// 
			// Down
			// 
			Down.Dock = DockStyle.Fill;
			Down.Location = new Point(69, 71);
			Down.Margin = new Padding(1);
			Down.Name = "Down";
			Down.Size = new Size(66, 35);
			Down.TabIndex = 5;
			Down.Tag = "13";
			Down.Text = "下";
			Down.UseVisualStyleBackColor = true;
			Down.Click += Cropper_Click;
			// 
			// RightDown
			// 
			RightDown.Dock = DockStyle.Fill;
			RightDown.Location = new Point(137, 71);
			RightDown.Margin = new Padding(1);
			RightDown.Name = "RightDown";
			RightDown.Size = new Size(69, 35);
			RightDown.TabIndex = 0;
			RightDown.Tag = "14";
			RightDown.Text = "右下";
			RightDown.UseVisualStyleBackColor = true;
			RightDown.Click += Cropper_Click;
			// 
			// Right
			// 
			Right.Dock = DockStyle.Fill;
			Right.Location = new Point(137, 36);
			Right.Margin = new Padding(1);
			Right.Name = "Right";
			Right.Size = new Size(69, 33);
			Right.TabIndex = 4;
			Right.Tag = "13";
			Right.Text = "右";
			Right.UseVisualStyleBackColor = true;
			Right.Click += Cropper_Click;
			// 
			// Up
			// 
			Up.Dock = DockStyle.Fill;
			Up.Location = new Point(69, 1);
			Up.Margin = new Padding(1);
			Up.Name = "Up";
			Up.Size = new Size(66, 33);
			Up.TabIndex = 2;
			Up.Tag = "11";
			Up.Text = "上";
			Up.UseVisualStyleBackColor = true;
			Up.Click += Cropper_Click;
			// 
			// LeftDown
			// 
			LeftDown.Dock = DockStyle.Fill;
			LeftDown.Location = new Point(1, 71);
			LeftDown.Margin = new Padding(1);
			LeftDown.Name = "LeftDown";
			LeftDown.Size = new Size(66, 35);
			LeftDown.TabIndex = 0;
			LeftDown.Tag = "13";
			LeftDown.Text = "左下";
			LeftDown.UseVisualStyleBackColor = true;
			LeftDown.Click += Cropper_Click;
			// 
			// RightUp
			// 
			RightUp.Dock = DockStyle.Fill;
			RightUp.Location = new Point(137, 1);
			RightUp.Margin = new Padding(1);
			RightUp.Name = "RightUp";
			RightUp.Size = new Size(69, 33);
			RightUp.TabIndex = 0;
			RightUp.Tag = "12";
			RightUp.Text = "右上";
			RightUp.UseVisualStyleBackColor = true;
			RightUp.Click += Cropper_Click;
			// 
			// Left
			// 
			Left.Dock = DockStyle.Fill;
			Left.Location = new Point(1, 36);
			Left.Margin = new Padding(1);
			Left.Name = "Left";
			Left.Size = new Size(66, 33);
			Left.TabIndex = 3;
			Left.Tag = "13";
			Left.Text = "左";
			Left.UseVisualStyleBackColor = true;
			Left.Click += Cropper_Click;
			// 
			// ClickedPoint
			// 
			ClickedPoint.AutoSize = true;
			ClickedPoint.Location = new Point(6, 133);
			ClickedPoint.Name = "ClickedPoint";
			ClickedPoint.Size = new Size(87, 19);
			ClickedPoint.TabIndex = 1;
			ClickedPoint.Text = "已选中坐标：";
			// 
			// Menus
			// 
			Menus.ImageScalingSize = new Size(17, 17);
			Menus.Items.AddRange(new ToolStripItem[] { 粘贴图像ToolStripMenuItem, 窗口置顶ToolStripMenuItem, 窗口透明度ToolStripMenuItem, 恢复PictureBox尺寸ToolStripMenuItem });
			Menus.Name = "contextMenuStrip1";
			Menus.Size = new Size(197, 100);
			// 
			// 粘贴图像ToolStripMenuItem
			// 
			粘贴图像ToolStripMenuItem.Name = "粘贴图像ToolStripMenuItem";
			粘贴图像ToolStripMenuItem.Size = new Size(196, 24);
			粘贴图像ToolStripMenuItem.Text = "粘贴图像";
			粘贴图像ToolStripMenuItem.Click += PasteImage;
			// 
			// 窗口置顶ToolStripMenuItem
			// 
			窗口置顶ToolStripMenuItem.CheckOnClick = true;
			窗口置顶ToolStripMenuItem.Name = "窗口置顶ToolStripMenuItem";
			窗口置顶ToolStripMenuItem.Size = new Size(196, 24);
			窗口置顶ToolStripMenuItem.Text = "窗口置顶";
			窗口置顶ToolStripMenuItem.Click += WindowTop;
			// 
			// 窗口透明度ToolStripMenuItem
			// 
			窗口透明度ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Transparency0, Transparency1, Transparency2, Transparency3, Transparency4 });
			窗口透明度ToolStripMenuItem.Name = "窗口透明度ToolStripMenuItem";
			窗口透明度ToolStripMenuItem.Size = new Size(196, 24);
			窗口透明度ToolStripMenuItem.Text = "窗口透明度";
			// 
			// Transparency0
			// 
			Transparency0.Name = "Transparency0";
			Transparency0.Size = new Size(108, 24);
			Transparency0.Text = "0%";
			Transparency0.Click += TransparencySet;
			// 
			// Transparency1
			// 
			Transparency1.Name = "Transparency1";
			Transparency1.Size = new Size(108, 24);
			Transparency1.Text = "25%";
			Transparency1.Click += TransparencySet;
			// 
			// Transparency2
			// 
			Transparency2.Name = "Transparency2";
			Transparency2.Size = new Size(108, 24);
			Transparency2.Text = "50%";
			Transparency2.Click += TransparencySet;
			// 
			// Transparency3
			// 
			Transparency3.Name = "Transparency3";
			Transparency3.Size = new Size(108, 24);
			Transparency3.Text = "75%";
			Transparency3.Click += TransparencySet;
			// 
			// Transparency4
			// 
			Transparency4.Name = "Transparency4";
			Transparency4.Size = new Size(108, 24);
			Transparency4.Text = "90%";
			Transparency4.Click += TransparencySet;
			// 
			// 恢复PictureBox尺寸ToolStripMenuItem
			// 
			恢复PictureBox尺寸ToolStripMenuItem.Name = "恢复PictureBox尺寸ToolStripMenuItem";
			恢复PictureBox尺寸ToolStripMenuItem.Size = new Size(196, 24);
			恢复PictureBox尺寸ToolStripMenuItem.Text = "恢复PictureBox尺寸";
			恢复PictureBox尺寸ToolStripMenuItem.Click += PictureBoxReset;
			// 
			// tabControl1
			// 
			tabControl1.Alignment = TabAlignment.Bottom;
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.ItemSize = new Size(180, 24);
			tabControl1.Location = new Point(0, 0);
			tabControl1.Multiline = true;
			tabControl1.Name = "tabControl1";
			tabControl1.Padding = new Point(2, 2);
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(787, 561);
			tabControl1.SizeMode = TabSizeMode.Fixed;
			tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(groupBox4);
			tabPage1.Controls.Add(panel1);
			tabPage1.Controls.Add(groupBox1);
			tabPage1.Controls.Add(CopyGenerator);
			tabPage1.Controls.Add(groupBox3);
			tabPage1.Controls.Add(Generator);
			tabPage1.Location = new Point(4, 4);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(779, 529);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "图像处理";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(ImageSherpen);
			groupBox4.Location = new Point(551, 429);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(221, 61);
			groupBox4.TabIndex = 6;
			groupBox4.TabStop = false;
			groupBox4.Text = "简单图像处理";
			// 
			// ImageSherpen
			// 
			ImageSherpen.Location = new Point(7, 23);
			ImageSherpen.Name = "ImageSherpen";
			ImageSherpen.Size = new Size(206, 28);
			ImageSherpen.TabIndex = 0;
			ImageSherpen.Text = "图像锐化（无法撤销）";
			ImageSherpen.UseVisualStyleBackColor = true;
			ImageSherpen.Click += ImageSherpen_Click;
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(copycomplete);
			tabPage2.Controls.Add(convertIframeButton);
			tabPage2.Controls.Add(inputiframetext);
			tabPage2.Controls.Add(outputsharediframebox);
			tabPage2.Controls.Add(inputsharediframebox);
			tabPage2.Location = new Point(4, 4);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(779, 529);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "文字链接处理";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// copycomplete
			// 
			copycomplete.AutoSize = true;
			copycomplete.ForeColor = Color.Red;
			copycomplete.Location = new Point(228, 140);
			copycomplete.Name = "copycomplete";
			copycomplete.Size = new Size(113, 19);
			copycomplete.TabIndex = 4;
			copycomplete.Text = "已复制目标代码！";
			copycomplete.Visible = false;
			// 
			// convertIframeButton
			// 
			convertIframeButton.Location = new Point(8, 133);
			convertIframeButton.Name = "convertIframeButton";
			convertIframeButton.Size = new Size(214, 32);
			convertIframeButton.TabIndex = 3;
			convertIframeButton.Text = "↓转换成网站需要的iframe代码↓";
			convertIframeButton.UseVisualStyleBackColor = true;
			convertIframeButton.Click += convertIframeButton_Click;
			// 
			// inputiframetext
			// 
			inputiframetext.AutoSize = true;
			inputiframetext.Location = new Point(8, 28);
			inputiframetext.Name = "inputiframetext";
			inputiframetext.Size = new Size(204, 19);
			inputiframetext.TabIndex = 2;
			inputiframetext.Text = "输入需要转换的链接或iframe代码";
			// 
			// outputsharediframebox
			// 
			outputsharediframebox.BackColor = Color.White;
			outputsharediframebox.Location = new Point(8, 171);
			outputsharediframebox.Multiline = true;
			outputsharediframebox.Name = "outputsharediframebox";
			outputsharediframebox.Size = new Size(406, 77);
			outputsharediframebox.TabIndex = 1;
			// 
			// inputsharediframebox
			// 
			inputsharediframebox.Location = new Point(8, 50);
			inputsharediframebox.Multiline = true;
			inputsharediframebox.Name = "inputsharediframebox";
			inputsharediframebox.Size = new Size(406, 77);
			inputsharediframebox.TabIndex = 0;
			inputsharediframebox.TextChanged += inputsharediframebox_TextChanged;
			// 
			// PicList
			// 
			PicList.ColorDepth = ColorDepth.Depth32Bit;
			PicList.ImageSize = new Size(16, 16);
			PicList.TransparentColor = Color.Transparent;
			// 
			// PictureUploader
			// 
			PictureUploader.Location = new Point(7, 141);
			PictureUploader.Name = "PictureUploader";
			PictureUploader.Size = new Size(205, 37);
			PictureUploader.TabIndex = 2;
			PictureUploader.Text = "上传图像";
			PictureUploader.UseVisualStyleBackColor = true;
			PictureUploader.Click += Generator_Click;
			// 
			// PictureIO
			// 
			AutoScaleDimensions = new SizeF(8F, 19F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(787, 561);
			ContextMenuStrip = Menus;
			Controls.Add(tabControl1);
			Name = "PictureIO";
			Text = "图片处理（等比缩放）";
			KeyDown += PasteImage;
			((System.ComponentModel.ISupportInitialize)PictureInput).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			Menus.ResumeLayout(false);
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private PictureBox PictureInput;
		private TextBox resolutionX;
		private TextBox resolutionY;
		private TextBox OutputPath;
		private TextBox Suffix1;
		private Button Generator;
		private GroupBox groupBox1;
		private Panel panel1;
		private GroupBox groupBox3;
		private Button RightDown;
		private Button LeftDown;
		private Button RightUp;
		private Button LeftUp;
		private Label ClickedPoint;
		private ContextMenuStrip Menus;
		private ToolStripMenuItem 窗口置顶ToolStripMenuItem;
		private ToolStripMenuItem 窗口透明度ToolStripMenuItem;
		private ToolStripMenuItem Transparency0;
		private ToolStripMenuItem Transparency1;
		private ToolStripMenuItem Transparency2;
		private ToolStripMenuItem Transparency3;
		private ToolStripMenuItem Transparency4;
		private ToolStripMenuItem 恢复PictureBox尺寸ToolStripMenuItem;
		private ToolStripMenuItem 粘贴图像ToolStripMenuItem;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private TextBox inputsharediframebox;
		private Button convertIframeButton;
		private Label inputiframetext;
		private TextBox outputsharediframebox;
		private Label copycomplete;
		private Button Left;
		private Button Up;
		private Button Down;
		private Button Right;
		private TableLayoutPanel tableLayoutPanel1;
		private Button CopyGenerator;
		private Label label1;
		private ComboBox QualitySelector;
		private Label PicFileSize;
		private GroupBox groupBox4;
		private Button ImageSherpen;
		private ImageList PicList;
		private Button PictureUploader;
	}
}
