using System.Runtime.InteropServices;
using System.Text;

namespace QYArticleUpdater.FileRW
{
	internal class FileReader
	{

	}
	/*		INI	文件示例
	[Prompt]
	Index=0
	Discription=This is a discription.
	TextContent=This is line one.
	This is line two.
	And this is line three.
	[Prompt]
	Index=1
	Discription=This is a discription.
	TextContent=This is line one.
	This is line two.
	And this is line three.
	 */
	public class PromptConfigurations
	{
		/// <summary>
		/// 读取INI文件
		/// </summary>
		/// <param name="section">方括号括起来的区域</param>
		/// <param name="key">键</param>
		/// <returns>该键对应的值</returns>
		public string INIRead(string section, string key)
		{
			StringBuilder temp = new StringBuilder(4096); // 每次从ini中读取多少字节
			IniFileHelper.GetPrivateProfileString(section, key, "", temp, 4096, IniFileHelper._iniFilePath);
			return temp.ToString();
		}
		/// <summary>
		/// 写入INI文件
		/// </summary>
		/// <param name="section">方括号括起来的区域</param>
		/// <param name="key">键</param>
		/// <param name="value">该键对应的值</param>
		public void INIWrite(string section, string key, string value)
		{
			IniFileHelper.WritePrivateProfileString(section, key, value, IniFileHelper._iniFilePath);
		}
	}
	public class IniFileHelper
	{
		public static readonly string _iniFilePath;

		static IniFileHelper()
		{
			_iniFilePath = "prompt.ini";
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		public static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		public static extern bool WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

		public static void WriteValue(string section, string key, string value)
		{
			WritePrivateProfileString(section, key, value, _iniFilePath);
		}

		public static string ReadValue(string section, string key, string defaultValue = "")
		{
			StringBuilder result = new StringBuilder(500);
			GetPrivateProfileString(section, key, defaultValue, result, 500, _iniFilePath);
			return result.ToString();
		}
	}


	public static class IniFileConverter
	{
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(
			string section, string key, string defaultValue,
			StringBuilder result, int size, string filePath);

		[DllImport("kernel32")]
		private static extern bool WritePrivateProfileString(
			string section, string key, string value, string filePath);

		/// <summary>
		/// 读取INI文件中的值
		/// </summary>
		/// <param name="filePath">INI文件路径</param>
		/// <param name="section">节名称（如 [General]）</param>
		/// <param name="key">键名</param>
		/// <param name="defaultValue">默认值（当键不存在时返回）</param>
		public static string ReadValue(string filePath, string section, string key, string defaultValue = "")
		{
			const int bufferSize = 255;
			var result = new StringBuilder(bufferSize);
			GetPrivateProfileString(section, key, defaultValue, result, bufferSize, filePath);
			return result.ToString();
		}

		/// <summary>
		/// 写入值到INI文件
		/// </summary>
		public static void WriteValue(string filePath, string section, string key, string value)
		{
			WritePrivateProfileString(section, key, value, filePath);
		}
		public static Dictionary<string, string> InportDict(string filePath, string section)
		{
			var result = new Dictionary<string, string>();
			const int bufferSize = 255;
			var dict  = new StringBuilder(bufferSize);
			//Get

			return result;
		}
	}
	public class AppConfig
	{
		public string TextContent { get; set; }
	}
}
