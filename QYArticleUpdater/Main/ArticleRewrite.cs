using System.Net.Http.Headers;
using static QYArticleUpdater.Main.Caesar;

namespace QYArticleUpdater.Main
{
	/// <summary>
	/// 重写并上传文章
	/// </summary>
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

				HttpResponseMessage response = await client.PostAsync(Decrypt(14, @"Zffb,!!Sb[ c[Wkag Ua_!SV_[`!3df[U^W!Sdf[U^W7V[f"), content);
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

				HttpResponseMessage response = await client.PostAsync(Decrypt(14, @"Zffb,!!Sb[ c[Wkag Ua_!SV_[`!3df[U^W!Sdf[U^W7V[f"), content);
				response.EnsureSuccessStatusCode();
				return await response.Content.ReadAsStringAsync();
			}
		}
	}
}
