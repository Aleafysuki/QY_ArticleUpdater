using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

public class ImagePlacementHandler
{
	private InferenceSession sentenceBertSession; // 假设已加载Sentence-BERT模型

	public ImagePlacementHandler(string modelPath)
	{
		// 加载Sentence-BERT模型（需预先转换为ONNX格式）
		sentenceBertSession = new InferenceSession(modelPath);
	}

	public List<string> InsertImages(List<string> rewrittenParagraphs, Dictionary<string, string> originalImageMap)
	{
		var result = new List<string>();

		foreach (var paragraph in rewrittenParagraphs)
		{
			result.Add(paragraph);
			var bestMatchImage = FindBestMatchImage(paragraph, originalImageMap);
			if (bestMatchImage != null)
			{
				result.Add($"![{bestMatchImage}]({bestMatchImage})");
			}
		}

		return result;
	}

	private string FindBestMatchImage(string paragraph, Dictionary<string, string> originalImageMap)
	{
		// 使用Sentence-BERT计算文本相似度（伪代码）
		string bestImage = null;
		float bestScore = 0;

		foreach (var kvp in originalImageMap)
		{
			float similarity = ComputeSimilarity(paragraph, kvp.Key);
			if (similarity > bestScore)
			{
				bestScore = similarity;
				bestImage = kvp.Value;
			}
		}

		return bestScore > 0.7 ? bestImage : null; // 相似度阈值
	}

	private float ComputeSimilarity(string textA, string textB)
	{
		// 调用Sentence-BERT模型计算余弦相似度（需实现具体推理逻辑）
		return 0.85f; // 示例值
	}
}