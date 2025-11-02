using System;
using System.Collections.Generic;
using System.Linq;

public class TagGenerator
{
	// 使用TF-IDF或TextRank提取关键词（此处简化为模拟实现）
	public List<string> GenerateTags(string articleText, int maxTags = 5)
	{
		// 模拟关键词提取（实际可替换为BERT、TF-IDF等算法）
		var keywords = ExtractKeywords(articleText);
		var tags = new List<string>();

		foreach (var keyword in keywords.Take(maxTags))
		{
			tags.Add($"#{keyword}");
		}

		return tags;
	}

	private List<string> ExtractKeywords(string text)
	{
		// 示例：按空格分词并过滤停用词
		var stopWords = new HashSet<string> { "的", "是", "在", "了", "和", "等" };
		var words = text.Split(' ').Where(w => !stopWords.Contains(w) && w.Length > 1).ToList();
		return words;
	}
}