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
				nodes = document.DocumentNode.SelectNodes($"//div[@id='{className}']");
			}
			if (nodes == null)
			{
				return string.Empty;
			}

			string textContent = string.Join(" ", nodes.Select(node => node.InnerText.Trim()));
			return textContent;
		}

		public async Task<Image[]> GetImages(string url, string html, string className) 
		{
			HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
			document.LoadHtml(html);

			var nodes = document.DocumentNode.SelectNodes($"//div[@class='{className}']");
			if (nodes == null)
			{
				nodes = document.DocumentNode.SelectNodes($"//div[@id='{className}']");
			}
			if (nodes == null)
			{
				return Array.Empty<Image>();
			}

			List<Image> images = new List<Image>();
			int pictureIndex = ContentMatch.GetPictureIndex(url);
			var imgSuffixPatterns = new char[] { '!','@','?' };
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
							if (cleanUrl.StartsWith("//"))
							{
								cleanUrl = "https:" + cleanUrl;
							}
							if (cleanUrl.StartsWith("file"))
							{
								cleanUrl = "https:" + cleanUrl.Substring(5);
							}
							if (cleanUrl.Contains("ali213"))
							{
								cleanUrl = cleanUrl.Replace("584_", string.Empty);
							}
							foreach (var suffix in imgSuffixPatterns)
							{
								if (cleanUrl.Contains(suffix))
								{
									cleanUrl = cleanUrl.Split(suffix)[0];
								}
							}
							try
							{
								using (HttpClient client = new HttpClient())
								{
									client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
									//client.DefaultRequestHeaders.Referrer = new Uri("https://www.example.com");
									client.DefaultRequestHeaders.Accept.ParseAdd("image/avif,image/jpeg,image/apng,image/*,*/*;q=0.8");
									client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/jpeg"));
									client.DefaultRequestHeaders.AcceptLanguage.ParseAdd("zh-CN,zh;q=0.9");
									HttpResponseMessage response = await client.GetAsync(cleanUrl);
									string contentType = response.Content.Headers.ContentType?.MediaType ?? "application/octet-stream";
									long? contentLength = response.Content.Headers.ContentLength;
									Console.WriteLine($"ContentType: {contentType}, ContentLength: {contentLength}");
									byte[] imageData = await client.GetByteArrayAsync(cleanUrl);
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
			if (pictureIndex > 0)
			{
				images.RemoveRange(0, Math.Min(pictureIndex, images.Count));
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
