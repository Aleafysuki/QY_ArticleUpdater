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
	public partial class LabeledInput : UserControl
	{
		public LabeledInput()
		{
			InitializeComponent();
		}
		[Category("UserSetting")]
		[Description("控制控件的左右分隔，默认为120")]
		[DefaultValue(typeof(int), "SplitVal")]
		public int SplitVal
		{
			get { return splitContainer1.SplitterDistance; }
			set
			{
				splitContainer1.SplitterDistance = value;
				Invalidate();
			}
		}
		[Category("Content")]
		[Description("控件中左侧说明性文字的文字内容")]
		[DefaultValue(typeof(string), "LabelText")]
		public string LabelText
		{
			get { return Discrimination.Text; }
			set
			{
				Discrimination.Text = value;
				Invalidate();
			}
		}
		[Category("Content")]
		[Description("控件中输入框的文字内容")]
		[DefaultValue(typeof(string), "InputText")]
		public string InputText
		{
			get { return ValueText.Text; }
			set
			{
				ValueText.Text = value;
				Invalidate();
			}
		}
		[Category("Content")]
		[Description("控件中输入框的文字内容")]
		[DefaultValue(typeof(string), "InputText")]
		public char HideText
		{
			get { return ValueText.PasswordChar; }
			set
			{
				ValueText.PasswordChar = value;
				Invalidate();
			}
		}
	}
}
