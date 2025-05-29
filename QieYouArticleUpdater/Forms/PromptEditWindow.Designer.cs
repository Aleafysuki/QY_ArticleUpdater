namespace QieYouArticleUpdater
{
	partial class PromptEditWindow
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
			PromptText = new TextBox();
			PromptEditCancel = new Button();
			PromptEditOK = new Button();
			PromptDiscription = new TextBox();
			SuspendLayout();
			// 
			// PromptText
			// 
			PromptText.Location = new Point(12, 42);
			PromptText.Multiline = true;
			PromptText.Name = "PromptText";
			PromptText.Size = new Size(776, 355);
			PromptText.TabIndex = 0;
			PromptText.TextChanged += PromptText_TextChanged;
			// 
			// PromptEditCancel
			// 
			PromptEditCancel.Location = new Point(490, 406);
			PromptEditCancel.Name = "PromptEditCancel";
			PromptEditCancel.Size = new Size(146, 35);
			PromptEditCancel.TabIndex = 1;
			PromptEditCancel.Text = "取消";
			PromptEditCancel.UseVisualStyleBackColor = true;
			// 
			// PromptEditOK
			// 
			PromptEditOK.Location = new Point(642, 406);
			PromptEditOK.Name = "PromptEditOK";
			PromptEditOK.Size = new Size(146, 35);
			PromptEditOK.TabIndex = 2;
			PromptEditOK.Text = "确定";
			PromptEditOK.UseVisualStyleBackColor = true;
			PromptEditOK.Click += PromptEditOK_Click;
			// 
			// PromptDiscription
			// 
			PromptDiscription.Location = new Point(12, 12);
			PromptDiscription.Name = "PromptDiscription";
			PromptDiscription.Size = new Size(776, 24);
			PromptDiscription.TabIndex = 3;
			// 
			// PromptEditWindow
			// 
			AutoScaleDimensions = new SizeF(8F, 19F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(PromptDiscription);
			Controls.Add(PromptEditOK);
			Controls.Add(PromptEditCancel);
			Controls.Add(PromptText);
			Name = "PromptEditWindow";
			StartPosition = FormStartPosition.CenterParent;
			Text = "PromptEditWindow";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox PromptText;
		private Button PromptEditCancel;
		private Button PromptEditOK;
		private TextBox PromptDiscription;
	}
}