using System;
using System.Collections.Generic;
using System.IO;
using FuzzySharp;

public class GameNameMatcher
{
	private Dictionary<string, string> nameMapping;

	public GameNameMatcher(string mappingFilePath)
	{
		// 从JSON文件加载名称映射表
		var json = File.ReadAllText(mappingFilePath);
		nameMapping = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
	}

	public string MatchGameName(string scrapedName)
	{
		// 优先检查映射表
		if (nameMapping.ContainsKey(scrapedName))
		{
			return nameMapping[scrapedName];
		}

		// 使用模糊匹配（Levenshtein距离）
		string bestMatch = null;
		int bestScore = 0;

		foreach (var dbName in nameMapping.Values.Distinct())
		{
			int score = Fuzz.Ratio(scrapedName, dbName);
			if (score > bestScore && score >= 85) // 相似度阈值
			{
				bestScore = score;
				bestMatch = dbName;
			}
		}

		return bestMatch ?? scrapedName; // 未匹配则返回原名
	}
}