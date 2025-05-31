namespace QYArticleUpdater
{
	partial class LabeledInput
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			Discrimination = new Label();
			ValueText = new TextBox();
			splitContainer1 = new SplitContainer();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			// 
			// Discrimination
			// 
			Discrimination.Dock = DockStyle.Fill;
			Discrimination.Location = new Point(0, 0);
			Discrimination.Name = "Discrimination";
			Discrimination.Size = new Size(121, 42);
			Discrimination.TabIndex = 0;
			Discrimination.Text = "Discrimination";
			Discrimination.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// ValueText
			// 
			ValueText.Dock = DockStyle.Fill;
			ValueText.Location = new Point(0, 0);
			ValueText.Multiline = true;
			ValueText.Name = "ValueText";
			ValueText.Size = new Size(246, 42);
			ValueText.TabIndex = 1;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(Discrimination);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(ValueText);
			splitContainer1.Size = new Size(371, 42);
			splitContainer1.SplitterDistance = 121;
			splitContainer1.TabIndex = 2;
			// 
			// LabeledInput
			// 
			AutoScaleDimensions = new SizeF(8F, 19F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(splitContainer1);
			Name = "LabeledInput";
			Size = new Size(371, 42);
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Label Discrimination;
		private TextBox ValueText;
		private SplitContainer splitContainer1;
	}
}
