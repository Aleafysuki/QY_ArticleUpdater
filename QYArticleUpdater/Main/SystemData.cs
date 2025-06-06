using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading.Tasks;
using static QYArticleUpdater.Main.Caesar;
namespace QYArticleUpdater.Main
{
	internal class SystemData
	{


		DataRoot? QSystemData;
		string DataJsonURL = Decrypt(10, @"^jjfi0%%Wf_$g_[oek$Yec%WZc_d%7hj_Yb[%Whj_Yb[Iehj5k_Z3/*ioij[c3'hekj[3(");
		//"https://api.qieyou.com/admin/Article/articleSort?uid=94&system=1&route=%2Farticle%2FallList%2F";
		public async Task SystemDataGetAsync()
		{
			var client = new HttpClient();
			var messagerequest = new HttpRequestMessage(HttpMethod.Get, DataJsonURL);
			messagerequest.Headers.Add("Accept", "application/json");
			var response = await client.SendAsync(messagerequest);
			var jsonString = await response.Content.ReadAsStringAsync();
			if (jsonString == null) return;
			QSystemData = JsonSerializer.Deserialize<DataRoot>(jsonString);

		}
		/// <summary>
		/// 通过名称搜索来进行ID的近似匹配
		/// </summary>
		/// <param name="name"></param>
		public async Task<int> GetGameFromName(string name)
		{
			await SystemDataGetAsync();
			if (QSystemData == null)
			{
				return 0;
			}
			Regex regex = new Regex(@"^\d+\s*-\s*(.+)$");
			foreach (var item in QSystemData.data.game)
			{
				var match = regex.Match(item.label);
				if (!match.Success) continue;

				string namePart = match.Groups[1].Value;

				if (namePart.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return item.value;
				}
				else
				{
					//return 0;
				}
			}
			return 0;
		}
	}
	public class AttributeItem
	{
		/// <summary>
		/// 数值
		/// </summary>
		public int value { get; set; }
		/// <summary>
		/// 文章属性
		/// </summary>
		public string label { get; set; }
	}

	public class GameItem
	{
		/// <summary>
		/// 游戏id
		/// </summary>
		public int value { get; set; }
		/// <summary>
		/// 游戏id以及对应的名称组成的字符串，例："7932 - 代号：月相计划"
		/// </summary>
		public string label { get; set; }
	}

	public class ChildrenItem
	{
		/// <summary>
		/// 文章对应的分类-细分到最后一层的名称
		/// </summary>
		public string label { get; set; }
		/// <summary>
		/// 文章对应的分类最后一层的id，唯一值
		/// </summary>
		public int value { get; set; }
		/// <summary>
		/// 文章分类的上层分类的id
		/// </summary>
		public int pid { get; set; }
	}

	public class ColumnItem
	{
		/// <summary>
		/// 文章分类-大类的名称
		/// </summary>
		public string label { get; set; }
		/// <summary>
		/// 文章分类-大类的
		/// </summary>
		public int value { get; set; }
		/// <summary>
		/// 文章对应的id，与所有子分类的id相同
		/// </summary>
		public int pid { get; set; }
		/// <summary>
		/// 不知道是啥，反正底下有子列表的写true，没有子列表的这项是null
		/// </summary>
		public bool disabled { get; set; }
		/// <summary>
		/// 文章子分类集合
		/// </summary>
		public List<ChildrenItem> children { get; set; }
	}

	public class Data
	{
		/// <summary>
		/// 可用的文章属性列表
		/// </summary>
		public List<AttributeItem> attribute { get; set; }
		/// <summary>
		/// 游戏列表
		/// </summary>
		public List<GameItem> game { get; set; }
		/// <summary>
		/// 文章分类列表
		/// </summary>
		public List<ColumnItem> column { get; set; }
	}
	/// <summary>
	/// 返回体
	/// </summary>
	public class DataRoot
	{
		/// <summary>
		/// HTTP通信值
		/// </summary>
		public int code { get; set; }
		/// <summary>
		/// 具体的JSON数据
		/// </summary>
		public Data data { get; set; }
		/// <summary>
		/// “请求成功”
		/// </summary>
		public string info { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int status { get; set; }
	}

}
