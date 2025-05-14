using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QieYouArticleUpdater.FileRW
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
    public class AppConfig
    {
        public string TextContent { get; set; }
    }
}
