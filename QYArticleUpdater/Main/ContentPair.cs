using System.Text.Json;

namespace QYArticleUpdater.Main
{
	internal class ContentPair
	{
		public string WebsitePattern { get; set; }
		public string WebsiteDivClass { get; set; }
		public enum ArticleType
		{
			Strategy,
			News
		}
	}
	public static class ContentMatch
	{
		public const string pairsString = @"[{
        ""WebsitePattern"": ""wandoujia"",
        ""WebsiteDivClass"": ""white-wrap"",
        ""ArticleType"": ""Strategy""
    },
    {
        ""WebsitePattern"": ""ali213"",
        ""WebsiteDivClass"": ""contentbox"",
        ""ArticleType"": ""Strategy""
    },
    {
        ""WebsitePattern"": ""weibo"",
        ""WebsiteDivClass"": ""wbpro-feed-content"",
        ""ArticleType"": ""News""
    },
{
	""WebsitePattern"": ""msn"",
	""WebsiteDivClass"": ""article-page"",
	""ArticleType"": ""Strategy""
}
]";
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
	}
}
