using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QieYouArticleUpdater
{
	public partial class PromptEditWindow : Form
	{
		public string? Content { get; set; }
		public PromptEditWindow()
		{
			InitializeComponent();
		}
		public void SetContent(string str)
		{
			PromptText.Text = str;
		}

		private void PromptText_TextChanged(object sender, EventArgs e)
		{
			Content = PromptText.Text;
		}

		private void PromptEditOK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}
