using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static QYArticleUpdater.Main.Caesar;

namespace QYArticleUpdater.Main
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
		public Image[] GetImages(string html, string className) 
		{
			HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
			document.LoadHtml(html);

			var nodes = document.DocumentNode.SelectNodes($"//div[@class='{className}']");
			if (nodes == null)
			{
				return Array.Empty<Image>();
			}

			List<Image> images = new List<Image>();

			foreach (var node in nodes)
			{
				var imgNodes = node.SelectNodes(".//img");
				if (imgNodes != null)
				{
					foreach (var imgNode in imgNodes)
					{
						var srcAttr = imgNode.Attributes["src"];
						if (srcAttr != null && !string.IsNullOrEmpty(srcAttr.Value))
						{
							string cleanUrl = CleanImageUrl(srcAttr.Value);
							try
							{
								using (WebClient client = new WebClient())
								{
									byte[] imageData = client.DownloadData(cleanUrl);
									using (MemoryStream ms = new MemoryStream(imageData))
									{
										images.Add(Image.FromStream(ms));
									}
								}
							}
							catch (Exception ex)
							{
								// Handle exceptions (e.g., invalid URLs, network issues)
								Console.WriteLine($"Error loading image from {cleanUrl}: {ex.Message}");
							}
						}
					}
				}
			}

			return images.ToArray();
		}
		private string CleanImageUrl(string url)
		{
			Uri uri = new Uri(url);
			UriBuilder uriBuilder = new UriBuilder(uri)
			{
				Query = string.Empty // Remove query parameters
			};
			return uriBuilder.ToString();
		}
	}
}
