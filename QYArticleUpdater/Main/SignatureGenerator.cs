using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QYArticleUpdater.Main
{
	public class SignatureGenerator
	{
		public static string GenerateSign()
		{
			// 构造原始对象
			var obj = new
			{
				timeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
				nonceStr = Guid.NewGuid().ToString(),
				package = "request_id=" + GenerateRandomString(16),
				signType = "MD5",
				time_expire = 300,
				appId = "dingaq0sfq1yqchdt2z2"
			};

			// 使用 System.Text.Json 序列化为紧凑 JSON
			var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = false
			});

			// 加密参数
			string key = "0123456789ASDFGH";
			string iv = "ASDFGH0123456789";

			return EncryptToBase64(json, key, iv);
		}

		public static string EncryptToBase64(string plaintext, string key, string iv)
		{
			byte[] keyBytes = Encoding.UTF8.GetBytes(key);
			byte[] ivBytes = Encoding.UTF8.GetBytes(iv);
			byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);

			using Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			aes.Key = keyBytes;
			aes.IV = ivBytes;

			using ICryptoTransform encryptor = aes.CreateEncryptor();
			byte[] cipherBytes = encryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);

			return Convert.ToBase64String(cipherBytes);
		}

		public static string GenerateRandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var sb = new StringBuilder();
			using var rng = RandomNumberGenerator.Create();
			byte[] buffer = new byte[1];

			for (int i = 0; i < length; i++)
			{
				rng.GetBytes(buffer);
				int idx = buffer[0] % chars.Length;
				sb.Append(chars[idx]);
			}

			return sb.ToString();
		}
	}
}
