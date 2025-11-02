using System.Text.Json;

namespace QYArticleUpdater.Main
{
	internal class ContentPair
	{
		public string WebsitePattern { get; set; }
		public string WebsiteDivClass { get; set; }
		public int PictureIndex { get; set; }
		public string ArticleType { get; set; }

	}
	public static class ContentMatch
	{
		public static string pairsString = File.ReadAllText(@"D:\Poster\ContentMatch.json");
		public static string GetDivClass(string websiteurl)
		{
			var pairs = JsonSerializer.Deserialize<List<ContentPair>>(pairsString, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			if (pairs == null)
			{
				throw new InvalidOperationException("Failed to deserialize content pairs.");
			}
			foreach (var pair in pairs)
			{
				if (websiteurl.Contains(pair.WebsitePattern, StringComparison.OrdinalIgnoreCase))
				{
					return pair.WebsiteDivClass;
				}
			}
			return string.Empty; // 如果没有匹配的模式，返回空字符串
		}
		public static string GetArticleType(string websiteurl)
		{
			var pairs = JsonSerializer.Deserialize<List<ContentPair>>(pairsString, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			if (pairs == null)
			{
				throw new InvalidOperationException("Failed to deserialize content pairs.");
			}
			foreach (var pair in pairs)
			{
				if (websiteurl.Contains(pair.WebsitePattern, StringComparison.OrdinalIgnoreCase))
				{
					return pair.ArticleType;
				}
			}
			return string.Empty;
		}
		public static int GetPictureIndex(string websiteurl)
		{
			var pairs = JsonSerializer.Deserialize<List<ContentPair>>(pairsString, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			});
			if (pairs == null)
			{
				throw new InvalidOperationException("Failed to deserialize content pairs.");
			}
			foreach (var pair in pairs)
			{
				if (websiteurl.Contains(pair.WebsitePattern, StringComparison.OrdinalIgnoreCase))
				{
					return pair.PictureIndex;
				}
			}
			return 0; // 如果没有匹配的模式，返回默认值0
		}
	}
}

