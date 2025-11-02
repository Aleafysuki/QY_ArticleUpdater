using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace QYArticleUpdater.Main
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(new Form1());
		}

		//[MethodImpl(MethodImplOptions.AggressiveInlining)]

		/// <summary>
		/// 统计字符串的视觉长度
		/// </summary>
		/// <param name="input">  需要输入的字符串</param>
		/// <param name="minValue">最小长度（以汉字为单位）</param>
		/// <param name="maxValue">最大长度（以汉字为单位）</param>
		/// <returns>bool值，若字符串长度在限定范围内则输出true，反之为false</returns>
		public static bool IsLengthInRange(this string input,int minValue,int maxValue)
		{
			if (string.IsNullOrEmpty(input))
				return false;

			int visualLength = 0;
			TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(input);

			while (enumerator.MoveNext())
			{
				string textElement = enumerator.GetTextElement();
				// 文本元素的首字符决定其视觉宽度
				if (textElement[0] <= 127) // ASCII字符
					visualLength += 1;
				else // 非ASCII字符（汉字、全角字符等）
					visualLength += 2;
			}

			return visualLength >= minValue *2 && visualLength <= maxValue*2;
		}
		
		/// <summary>
		///	
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static int GetVisualLength(this string input)
		{
			if (string.IsNullOrEmpty(input))
				return 0;

			int visualLength = 0;
			TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(input);

			while (enumerator.MoveNext())
			{
				string textElement = enumerator.GetTextElement();
				// 文本元素的首字符决定其视觉宽度
				if (textElement[0] <= 127) // ASCII字符
					visualLength += 1;
				else // 非ASCII字符（汉字、全角字符等）
					visualLength += 2;
			}

			return visualLength;
		}
	}

}