using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace QieYouArticleUpdater.Main
{
	internal class ArticleRewrite
	{
		private HttpClient client = new HttpClient();

		public async Task<string> UploadArticle(Dictionary<string, string> formData)
		{
			using (var content = new MultipartFormDataContent("--WebKitFormBoundaryyyuuNMIVe2FV9LDX"))
			{
				foreach (var item in formData)
				{
					content.Add(new StringContent(item.Value), item.Key);
				}

				HttpResponseMessage response = await client.PostAsync("http://api.qieyou.com/admin/Article/articleEdit", content);
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsStringAsync();
			}
		}
	}
	public class ArticleUploader
	{
		private HttpClient client = new HttpClient();

		public async Task<string> UploadArticle(Dictionary<string, string> formData, string posterFilePath)
		{
			using (var content = new MultipartFormDataContent("--WebKitFormBoundaryyyuuNMIVe2FV9LDX"))
			{
				foreach (var item in formData)
				{
					content.Add(new StringContent(item.Value), item.Key);
				}

				if (!string.IsNullOrEmpty(posterFilePath))
				{
					byte[] fileBytes = File.ReadAllBytes(posterFilePath);
					var streamContent = new ByteArrayContent(fileBytes);
					streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
					content.Add(streamContent, "zh_poster", Path.GetFileName(posterFilePath));
				}

				HttpResponseMessage response = await client.PostAsync("http://api.qieyou.com/admin/Article/articleEdit", content);
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsStringAsync();
			}
		}
	}
}
