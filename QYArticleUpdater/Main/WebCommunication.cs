using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using static QYArticleUpdater.Main.DeepSeekChatCompletion;

namespace QYArticleUpdater.Main
{
	internal class WebCommunication
	{

		public async Task DeepSeekCommunication()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Post, "https://api.deepseek.com/chat/completions");
			request.Headers.Add("Accept", "application/json");
			request.Headers.Add("Authorization", "Bearer <TOKEN>");
			var content = new StringContent("{\n  \"messages\": [\n    {\n      \"content\": \"You are a helpful assistant\",\n      \"role\": \"system\"\n    },\n    {\n      \"content\": \"Hi\",\n      \"role\": \"user\"\n    }\n  ],\n  \"model\": \"deepseek-chat\",\n  \"frequency_penalty\": 0,\n  \"max_tokens\": 2048,\n  \"presence_penalty\": 0,\n  \"response_format\": {\n    \"type\": \"text\"\n  },\n  \"stop\": null,\n  \"stream\": false,\n  \"stream_options\": null,\n  \"temperature\": 1,\n  \"top_p\": 1,\n  \"tools\": null,\n  \"tool_choice\": \"none\",\n  \"logprobs\": false,\n  \"top_logprobs\": null\n}", null, "application/json");
			request.Content = content;
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			Console.WriteLine(await response.Content.ReadAsStringAsync());
		}
		const string prompt_for_test = "【游戏攻略】将提供给你的内容撰写成一份游戏攻略文章。\r\n\r\n设想你是游戏资讯/攻略网站的编辑，需要对内容进行重新伪原创，并且不要出现AI特征（例如使用AI常用词等）。\r\n\r\n改写完成后，提供一份长度为20到24个汉字长度的标题，标题中不应该带除空格外的标点符号，每个空格算作0.5个汉字。\r\n标题撰写提示：可以考虑受众会怎样搜索文章，例如介绍角色技能的文章，读者一般会搜索“有什么技能”“技能怎么升级”一类的词汇；介绍游戏更新时间的文章，读者一般会搜索“什么时候更新”。\r\n只提供文章即可，文章的引用、说明等内容请不要输出。\r\n\r\n##注意事项:\r\n- 撰写时，剔除原网站的相关信息。\r\n- 需要注意标点符号的运用，不能丢失标点。\r\n- 需要写得尽可能详细，但不要自行点评以及升华，不要自己添油加醋，不要出现例如“这个技能可以xxx”“xxx对于xxx至关重要”“值得注意的是”等内容。\r\n- 正文尽量不要分条罗列。但例如介绍角色技能等内容，可以用小标题+一个完整段落的形式进行撰写。小标题只写成正文加粗，不要使用Head标签（撰写的时候不要使用两个井号来提升小标题权重）。\r\n- 若使用小标题，则小标题和对应段落之间不要使用一个分行或者两个分行，而是应该使用段落标记（不要用换行符<br>，而是和其他段落一样使用段落符号<p>）。\r\n- 不到万不得已尽量少用小标题。因为你的取标题能力很容易让读者看出来这篇文章非常水。\r\n- 剔除掉不需要的部分，例如要求撰写介绍角色技能的文章，如果提供的材料中包括了角色装备的介绍，也请不要在文中出现这些和主题无关的内容。\r\n- 若原文出现多个文章写作方向（例如提到某角色的攻略介绍了角色定位、技能、配队等多方面的内容），默认选择第一个。\r\n- 不要添加过多敬语，不要总是动不动就您您您的，应该拉近读者距离。\r\n- 攻略全文应该包含关于页面所述游戏名的关键词。关键词密度应大于2%。\r\n- 攻略开头和结尾段落应该针对所涉及到的游戏进行SEO。\r\n- 除部分有需要的内容需要写成表格之外，不应该出现任何其他格式（例如标题、有序/无序列表、分隔线）。但是允许加粗、斜体的格式。\r\n- 每句话的结尾必须是句号/问号/叹号等中文全角标点符号，不可以是点号(.)。每段的结尾都应该使用段落标记而不是换行符。小标题也使用段落标记而不是换行符。\r\n- 撰写时查找互联网相关资料，尽量将“玩家”一词替换为游戏官方给玩家安排的称呼（例如《原神》中的玩家被称呼为“旅行者”），如果查不到或者拿不准主意就称呼玩家即可。\r\n- 攻略需要有SEO友好的开头和结尾段落。如果原文没有则自行添加。开头段落应该自成一段，不能裹挟本来应该在正文的一部分内容。\r\n- 如果有明确的回答，在正文中用一段话的空间来明确回答文章所提到的问题（例如将某某游戏什么时候公测的文章，可以在正文中使用单独的一段写“某某游戏公测时间为x月x日”）。\r\n- 如果游戏为《地下城与勇士：起源》or《地下城与勇士手游》，则将其替换为《DNF手游》（即所有的“地下城与勇士”替换为“DNF”）。\r\n- 若文中出现洛克王国世界的字样，《洛克王国世界》是游戏名。\r\n- 全文中的游戏名都可以不加书名号。\r\n- 不要出现向其他任何平台导流的内容，例如“使用TapTap/豌豆荚/好游快爆预约”这样的字样一律不可以出现。\r\n\r\n##对初始语句的要求示例（可以进行适度的修改和美化）:\r\nxxx（游戏）的xxx（问题）？很多玩家都不清楚/想要了解/在询问小编xx（问题但是换一种问法），切游小编整理了一下关于xxx（文章主题）的一些资料，其实xxx（一句补充内容），下面我们一起来看一下xxx（问题）。\r\n（举例：原神甘雨用什么圣遗物最好？很多旅行者在培养甘雨的时候不清楚该给她配备什么圣遗物比较好，切游小编整理了一下原神甘雨的圣遗物配装相关资料，甘雨的圣遗物还是尽量靠扩大输出为目标，下面我们来看看详细的原神甘雨圣遗物配装相关攻略。）\r\n\r\n##开头段落长度要求：尽量不要多于150字。\r\n\r\n##中间段落长度要求：\r\n每段尽量不要超过200字或150token，正文部分的内容需要根据内容需求进行合理分段，但不是分条罗列。以2~5段为佳，不能写成一整段！\r\n\r\n##结尾语句要求示例（可以进行适度的润色、修改和美化）:\r\n{用一句话总结回应主题}，{\"以上就是\"+主题内容}了/啦。如果这篇攻略对你有帮助，还请点个收藏关注一下切游网，各位读者的支持就是我们持续更新的最大动力。\r\n（举例：原神甘雨的圣遗物配装以攻、冰、双爆为主要配装目标，这样可以最大化她的输出。以上就是原神甘雨的圣遗物配装攻略啦，如果这篇甘雨的圣遗物搭配攻略对你有帮助的话，还请点个收藏关注一下切游网，各位读者的支持就是我们持续更新的最大动力。）\r\n";
		public async Task<string> DS_Message(string message)
		{
			var apiKey = "your_api_key_here";
			var deepSeek = new DeepSeekChatCompletion("sk-cf17f707cdfb42b987ab7a8754859732");

			var request = new ChatRequest
			{
				Messages = new List<DeepSeekChatCompletion.Message>
				{
					new DeepSeekChatCompletion.Message { Role = "system", Content = prompt_for_test },
					new DeepSeekChatCompletion.Message { Role = "user", Content = message }
				},
				Model = "deepseek-chat",
				MaxTokens = 2048,
				Temperature = 0.7,
				ResponseFormat = new ResponseFormat { Type = "text" }
			};

			var response = await SendChatRequestAsync(request);
			return response;
		}
		public async Task<string> SendChatRequestAsync(ChatRequest request)
		{
			var client = new HttpClient();
			var messagerequest = new HttpRequestMessage(HttpMethod.Post, "https://api.deepseek.com/chat/completions");
			messagerequest.Headers.Add("Accept", "application/json");
			messagerequest.Headers.Add("Authorization", "Bearer sk-cf17f707cdfb42b987ab7a8754859732");

			var jsonRequest = JsonSerializer.Serialize(request, new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
				WriteIndented = true
			});
			var content = new StringContent(jsonRequest.ToLower(), Encoding.UTF8, "application/json");
			messagerequest.Content = content;
			var response = await client.SendAsync(messagerequest);
			response.EnsureSuccessStatusCode();
			if (!response.IsSuccessStatusCode)
			{
				throw new Exception($"API request failed with status code: {response.StatusCode}");
			}

			var jsonResponse = await response.Content.ReadAsStringAsync();
			var chatResponse = JsonSerializer.Deserialize<ChatResponse>(jsonResponse, new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true // Ignore case when deserializing
			});

			// Extract the "正文" from the response
			if (chatResponse?.choices != null && chatResponse.choices.Length > 0)
			{
				return chatResponse.choices[0].message.content;
			}

			throw new Exception("Unexpected response format");
		}
	}


	public class DeepSeekChatCompletion
	{
		private readonly string _apiKey = "sk-cf17f707cdfb42b987ab7a8754859732";
		private readonly HttpClient _httpClient;

		public DeepSeekChatCompletion(string apiKey)
		{
			_apiKey = apiKey;
			_httpClient = new HttpClient();
			_httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
			_httpClient.BaseAddress = new Uri("https://api.deepseek.com/");
		}

		public class Message
		{
			public string Role { get; set; }
			public string Content { get; set; }
			public string Name { get; set; }
		}

		public class ResponseFormat
		{
			public string Type { get; set; } = "text";
		}

		public class StreamOptions
		{
			public bool IncludeUsage { get; set; }
		}

		public class Function
		{
			public string Name { get; set; }
			public string Description { get; set; }
			public Dictionary<string, object> Parameters { get; set; }
		}

		public class Tool
		{
			public string Type { get; set; } = "function";
			public Function Function { get; set; }
		}

		public class ChatRequest
		{
			public List<Message> Messages { get; set; }
			public string Model { get; set; } = "deepseek-chat";
			public double? FrequencyPenalty { get; set; } = 0;
			public int? MaxTokens { get; set; } = 2048;
			public double? PresencePenalty { get; set; } = 0;
			public ResponseFormat ResponseFormat { get; set; } = new ResponseFormat();
			public object Stop { get; set; }
			public bool Stream { get; set; } = false;
			public StreamOptions StreamOptions { get; set; }
			public double? Temperature { get; set; } = 1;
			public double? TopP { get; set; } = 1;
			public List<Tool> Tools { get; set; }
			public string ToolChoice { get; set; } = "none";
			public bool Logprobs { get; set; } = false;
			public int? TopLogprobs { get; set; }
		}

		public class ChatResponse
		{
			public string Id { get; set; }
			public List<Choice> Choices { get; set; }
			public int Created { get; set; }
			public string Model { get; set; }
			public string SystemFingerprint { get; set; }
			public string Object { get; set; }
			public Usage Usage { get; set; }
		}

		public class Choice
		{
			public string Message { get; set; }
			public string FinishReason { get; set; }
		}

		public class Usage
		{
			public int PromptTokens { get; set; }
			public int CompletionTokens { get; set; }
			public int TotalTokens { get; set; }
		}


	}

	public class ChatResponse
	{
		public string id { get; set; } // Note: lowercase 'i'
		public string @object { get; set; } // Note: '@' symbol to escape reserved keyword
		public int created { get; set; } // Note: lowercase 'c'
		public string model { get; set; } // Note: lowercase 'm'
		public Choice[] choices { get; set; } // Note: lowercase 'c'
		public Usage usage { get; set; } // Note: lowercase 'u'
		public string system_fingerprint { get; set; } // Note: lowercase and underscore
	}

	public class Choice
	{
		public int index { get; set; } // Note: lowercase 'i'
		public Message message { get; set; } // Note: lowercase 'm'
		public object logprobs { get; set; } // Note: lowercase 'l'
		public string finish_reason { get; set; } // Note: lowercase and underscore
	}

	public class Message
	{
		public string role { get; set; } // Note: lowercase 'r'
		public string content { get; set; } // Note: lowercase 'c'
	}

	public class Usage
	{
		public int prompt_tokens { get; set; } // Note: lowercase and underscores
		public int completion_tokens { get; set; } // Note: lowercase and underscores
		public int total_tokens { get; set; } // Note: lowercase and underscores
		public PromptTokensDetails prompt_tokens_details { get; set; } // Note: lowercase and underscores
		public int prompt_cache_hit_tokens { get; set; } // Note: lowercase and underscores
		public int prompt_cache_miss_tokens { get; set; } // Note: lowercase and underscores
	}

	public class PromptTokensDetails
	{
		public int cached_tokens { get; set; } // Note: lowercase and underscores
	}

}
