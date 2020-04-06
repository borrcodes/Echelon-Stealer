using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Echelon
{
	public static class Internet
	{
		[Flags]
		private enum a
		{
			a = 0x1,
			b = 0x2,
			c = 0x4,
			d = 0x10,
			e = 0x20,
			f = 0x40
		}

		private static readonly object m_a = new object();

		[DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]
		private static extern bool a(ref a af, int ag);

		public static bool CheckConnection()
		{
			lock (Internet.m_a)
			{
				try
				{
					a af = Internet.a.f;
					bool flag = a(ref af, 0);
					if (flag)
					{
						return PingServer(new string[3]
						{
							"google.com",
							"wikipedia.org",
							"facebook.com"
						});
					}
					return flag;
				}
				catch
				{
					return false;
				}
			}
		}

		public static bool PingServer(string[] serverList)
		{
			bool flag = false;
			Ping ping = new Ping();
			for (int i = 0; i < serverList.Length; i++)
			{
				flag = (ping.Send(serverList[i]).Status == IPStatus.Success);
				if (flag)
				{
					break;
				}
			}
			return flag;
		}
	}
}
