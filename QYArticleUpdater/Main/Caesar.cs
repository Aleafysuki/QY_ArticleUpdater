using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QYArticleUpdater.Main
{
	internal class Caesar
	{
		// 定义默认的偏移量常量
		private const int DefaultShift = 3;

		/// <summary>
		/// 解密通过凯撒密码加密的字符串。
		/// </summary>
		/// <param name="shift">解密时使用的偏移量。</param>
		/// <param name="encryptedText">需要解密的字符串。</param>
		/// <returns>解密后的字符串。</returns>
		public static string Decrypt(int shift, string encryptedText)
		{
			if (string.IsNullOrEmpty(encryptedText))
			{
				throw new ArgumentException("The input text cannot be null or empty.", nameof(encryptedText));
			}

			char[] decryptedChars = new char[encryptedText.Length];
			for (int i = 0; i < encryptedText.Length; i++)
			{
				decryptedChars[i] = ShiftCharacter(encryptedText[i], -shift);
			}
			return new string(decryptedChars);
		}

		/// <summary>
		/// 移动字符的位置。
		/// </summary>
		/// <param name="character">要移动的字符。</param>
		/// <param name="shift">移动的数量。</param>
		/// <returns>移动后的新字符。</returns>
		private static char ShiftCharacter(char character, int shift)
		{
			if (!char.IsLetter(character))
			{
				return character;
			}

			char offset = char.IsUpper(character) ? 'A' : 'a';
			int shiftedPosition = ((character + shift - offset) % 26 + 26) % 26 + offset;
			return (char)shiftedPosition;
		}
	}
}
