using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QYArticleUpdater.Main
{
	internal static class DSCommunication
	{
		// API配置常量
		private const string ApiUrl = "https://api.deepseek.com/chat/completions";
		private const string ApiKey = "Bearer sk-cf17f707cdfb42b987ab7a8754859732";

		// HTTP客户端工厂
		private static HttpClient _client;
		private static readonly object _lock = new object();

		// 消息历史记录
		private static List<ChatMessage> _messageHistory;

		/// <summary>
		/// 连接到DeepSeek API（初始化HTTP客户端）
		/// </summary>
		public static void Connect()
		{
			lock (_lock)
			{
				// 创建新的HttpClient实例
				_client = new HttpClient();
				_client.DefaultRequestHeaders.Add("Authorization", ApiKey);
				_client.DefaultRequestHeaders.Add("Accept", "application/json");
				_client.Timeout = TimeSpan.FromSeconds(120);

				// 初始化新的消息历史
				_messageHistory = new List<ChatMessage>();
			}
		}

		/// <summary>
		/// 发送系统指令
		/// </summary>
		/// <param name="systemPrompt">系统提示内容</param>
		public static void SendSystemPrompt(string systemPrompt)
		{
			if (string.IsNullOrWhiteSpace(systemPrompt))
				throw new ArgumentException("System prompt cannot be empty");

			lock (_lock)
			{
				_messageHistory.Add(new ChatMessage
				{
					role = "system",
					content = systemPrompt
				});
			}
		}

		/// <summary>
		/// 发送用户指令并获取AI响应
		/// </summary>
		/// <param name="userMessage">用户消息内容</param>
		/// <returns>AI生成的回复</returns>
		public static async Task<string> SendUserMessageAsync(string userMessage)
		{
			if (string.IsNullOrWhiteSpace(userMessage))
				throw new ArgumentException("User message cannot be empty");

			// 验证连接状态
			if (_client == null)
				throw new InvalidOperationException("Not connected to API. Call Connect() first.");

			ChatMessage[] currentMessages;
			lock (_lock)
			{
				// 添加用户消息到历史
				_messageHistory.Add(new ChatMessage
				{
					role = "user",
					content = userMessage
				});

				// 复制当前消息列表以用于请求
				currentMessages = _messageHistory.ToArray();
			}

			// 构建请求体
			var request = new ChatRequest
			{
				model = "deepseek-chat",
				messages = currentMessages,
				stream = false
			};

			// 发送请求
			var jsonContent = JsonSerializer.Serialize(request);
			var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
			//_client.Timeout = TimeSpan.FromSeconds(300);
			var response = await _client.PostAsync(ApiUrl, httpContent);
			response.EnsureSuccessStatusCode();

			// 解析响应
			var responseBody = await response.Content.ReadAsStringAsync();
			var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseBody);

			if (apiResponse?.choices == null || apiResponse.choices.Count == 0)
				throw new InvalidOperationException("Invalid API response");

			// 添加AI回复到历史
			var aiResponse = apiResponse.choices[0].message.content;
			lock (_lock)
			{
				_messageHistory.Add(new ChatMessage
				{
					role = "assistant",
					content = aiResponse
				});
			}

			return aiResponse;
		}

		/// <summary>
		/// 断开连接并清除上下文
		/// </summary>
		public static void Disconnect()
		{
			lock (_lock)
			{
				// 释放现有HttpClient
				if (_client != null)
				{
					_client.Dispose();
					_client = null;
				}

				// 清除历史记录
				_messageHistory = null;
			}
		}

		// 辅助类：聊天消息
		private class ChatMessage
		{
			public string role { get; set; }
			public string content { get; set; }
		}

		// 辅助类：API请求结构
		private class ChatRequest
		{
			public string model { get; set; }
			public ChatMessage[] messages { get; set; }
			public bool stream { get; set; }
		}

		// 辅助类：API响应结构
		private class ApiResponse
		{
			public string id { get; set; }
			public List<Choice> choices { get; set; }
		}

		private class Choice
		{
			public ChatMessage message { get; set; }
		}
	}
}