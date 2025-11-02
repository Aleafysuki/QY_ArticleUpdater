namespace QYArticleUpdater.Forms
{
	partial class CoverImageModifier
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			panel1 = new Panel();
			pictureBox1 = new PictureBox();
			PicRestore = new Button();
			PrevPic = new Button();
			NextPic = new Button();
			picMenu = new ContextMenuStrip(components);
			粘贴图像ToolStripMenuItem = new ToolStripMenuItem();
			CoverComfirm = new Button();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			picMenu.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panel1.Controls.Add(pictureBox1);
			panel1.Location = new Point(180, 12);
			panel1.Name = "panel1";
			panel1.Size = new Size(1112, 725);
			panel1.TabIndex = 0;
			// 
			// pictureBox1
			// 
			pictureBox1.ContextMenuStrip = picMenu;
			pictureBox1.Dock = DockStyle.Fill;
			pictureBox1.Location = new Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(1112, 725);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			// 
			// PicRestore
			// 
			PicRestore.Location = new Point(5, 297);
			PicRestore.Name = "PicRestore";
			PicRestore.Size = new Size(167, 45);
			PicRestore.TabIndex = 1;
			PicRestore.Text = "撤销更改";
			PicRestore.UseVisualStyleBackColor = true;
			// 
			// PrevPic
			// 
			PrevPic.Location = new Point(5, 348);
			PrevPic.Name = "PrevPic";
			PrevPic.Size = new Size(82, 35);
			PrevPic.TabIndex = 2;
			PrevPic.Text = "上一张";
			PrevPic.UseVisualStyleBackColor = true;
			// 
			// NextPic
			// 
			NextPic.Location = new Point(88, 348);
			NextPic.Name = "NextPic";
			NextPic.Size = new Size(84, 35);
			NextPic.TabIndex = 2;
			NextPic.Text = "下一张";
			NextPic.UseVisualStyleBackColor = true;
			// 
			// picMenu
			// 
			picMenu.Items.AddRange(new ToolStripItem[] { 粘贴图像ToolStripMenuItem });
			picMenu.Name = "picMenu";
			picMenu.Size = new Size(125, 26);
			// 
			// 粘贴图像ToolStripMenuItem
			// 
			粘贴图像ToolStripMenuItem.Name = "粘贴图像ToolStripMenuItem";
			粘贴图像ToolStripMenuItem.Size = new Size(124, 22);
			粘贴图像ToolStripMenuItem.Text = "粘贴图像";
			// 
			// CoverComfirm
			// 
			CoverComfirm.Location = new Point(5, 389);
			CoverComfirm.Name = "CoverComfirm";
			CoverComfirm.Size = new Size(167, 45);
			CoverComfirm.TabIndex = 1;
			CoverComfirm.Text = "选定为封面";
			CoverComfirm.UseVisualStyleBackColor = true;
			// 
			// CoverImageModifier
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1296, 742);
			Controls.Add(NextPic);
			Controls.Add(PrevPic);
			Controls.Add(CoverComfirm);
			Controls.Add(PicRestore);
			Controls.Add(panel1);
			Name = "CoverImageModifier";
			Text = "CoverImageModifier";
			panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			picMenu.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private PictureBox pictureBox1;
		private Button PicRestore;
		private Button PrevPic;
		private Button NextPic;
		private ContextMenuStrip picMenu;
		private ToolStripMenuItem 粘贴图像ToolStripMenuItem;
		private Button CoverComfirm;
	}
}