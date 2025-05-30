using System.Net.Http.Headers;
namespace QieYouArticleUpdater.FileRW
{
    internal class PicUpload
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task Uploader(string filePath)
        {
            // URL of the API endpoint
            string url = "https://api.qieyou.com/admin/Game/getUploads";

            // Path to the image file you want to upload
            //string filePath = @"C:\path\to\your\image.jpg";

            try
            {
                // Create a multipart/form-data content
                using (var multiPartContent = new MultipartFormDataContent("----WebKitFormBoundaryE0n9dYvRuMRU5MAe"))
                {
                    // Add headers
                    multiPartContent.Headers.TryAddWithoutValidation("accept", "*/*");
                    multiPartContent.Headers.TryAddWithoutValidation("accept-language", "zh-CN,zh;q=0.9");
                    multiPartContent.Headers.TryAddWithoutValidation("cache-control", "no-cache");
                    multiPartContent.Headers.TryAddWithoutValidation("origin", "http://laoliu666.qieyou.com");
                    multiPartContent.Headers.TryAddWithoutValidation("pragma", "no-cache");
                    multiPartContent.Headers.TryAddWithoutValidation("priority", "u=1, i");
                    multiPartContent.Headers.TryAddWithoutValidation("referer", "http://laoliu666.qieyou.com/");
                    multiPartContent.Headers.TryAddWithoutValidation("sec-ch-ua", "\"Not/A)Brand\";v=\"8\", \"Chromium\";v=\"126\", \"Google Chrome\";v=\"126\"");
                    multiPartContent.Headers.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
                    multiPartContent.Headers.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");
                    multiPartContent.Headers.TryAddWithoutValidation("sec-fetch-dest", "empty");
                    multiPartContent.Headers.TryAddWithoutValidation("sec-fetch-mode", "cors");
                    multiPartContent.Headers.TryAddWithoutValidation("sec-fetch-site", "cross-site");
                    multiPartContent.Headers.TryAddWithoutValidation("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36");

                    // Add the file content
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    var byteArrayContent = new ByteArrayContent(fileBytes);
                    byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                    multiPartContent.Add(byteArrayContent, "file", Path.GetFileName(filePath));

                    // Send the request
                    using (var httpClient = new HttpClient())
                    {
                        HttpResponseMessage response = await httpClient.PostAsync(url, multiPartContent);
                        response.EnsureSuccessStatusCode(); // Throw if not a success code.

                        // Read and output the response content
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public async Task<string> PictureUpload(Image image)
        {
			using (Bitmap bitmap = new Bitmap(image)) // 这里假设你有一个 example.png 文件
			{
				byte[] imageBytes = ImageToByteArray(bitmap);

				using (var client = new HttpClient())
				{
					using (var content = new MultipartFormDataContent())
					{
						var byteArrayContent = new ByteArrayContent(imageBytes);
						byteArrayContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
						content.Add(byteArrayContent, "file", "uploaded_image.jpeg");

						try
						{
							HttpResponseMessage response = await client.PostAsync("https://api.qieyou.com/admin/Game/getUploads", content);

							if (response.IsSuccessStatusCode)
							{
								string responseBody = await response.Content.ReadAsStringAsync();
								return responseBody;
							}
							else
							{
								return response.StatusCode.ToString();
							}
						}
						catch (Exception ex)
						{
							return ex.Message;
						}
					}
				}
			}
		}

		static byte[] ImageToByteArray(Bitmap image)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // 根据需要选择合适的格式
				return ms.ToArray();
			}
		}
    }
}
