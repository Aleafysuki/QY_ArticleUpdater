using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYArticleUpdater.Main
{
	internal class Caesar
	{
		public static string CaesarDecode(int num, string str)
		{
			if (str.Length <= 0)
			{
				return string.Empty;
			}
			char[] chars = str.ToCharArray();
			for (int i = 0; i < chars.Length; i++)
			{
				chars[i] += Convert.ToChar(num);
			}
			return new string(chars);
		}
	}
}
