using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QieYouArticleUpdater.Main
{
	internal class WebpageAccess
	{
		/// <summary>
		/// 获取指定URL的对应网页HTML源码
		/// </summary>
		/// <param name="url">所需访问的网址链接</param>
		/// <returns></returns>
		public string GetWebpageContent(string url)
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = client.GetAsync(url).Result;
				response.EnsureSuccessStatusCode();
				string responseBody = response.Content.ReadAsStringAsync().Result;
				return responseBody;
			}
		}
		public string ExtractTextByClass(string html, string className)
		{
			HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
			document.LoadHtml(html);

			var nodes = document.DocumentNode.SelectNodes($"//div[@class='{className}']");
			if (nodes == null)
			{
				return string.Empty;
			}

			string textContent = string.Join(" ", nodes.Select(node => node.InnerText.Trim()));
			return textContent;
		}
	}
}
