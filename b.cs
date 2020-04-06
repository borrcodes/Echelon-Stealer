using System.Diagnostics;
using System.Management;
using System.Windows.Forms;

internal class b
{
	private static bool a
	{
		get
		{
			if (!SystemInformation.TerminalServerSession)
			{
				return false;
			}
			return true;
		}
	}

	private static bool a()
	{
		using (ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem").Get())
		{
			foreach (ManagementBaseObject item in managementObjectCollection)
			{
				try
				{
					string text = item["Manufacturer"].ToString().ToLower();
					bool flag = item["Model"].ToString().ToLower().Contains("virtual");
					if ((text.Equals("microsoft corporation") && flag) || text.Contains("vmware") || item["Model"].ToString().Equals("VirtualBox"))
					{
						return true;
					}
				}
				catch
				{
					return false;
				}
			}
		}
		return false;
	}

	private static bool b(Process q)
	{
		try
		{
			bool aj = false;
			m.b(q.Handle, ref aj);
			return aj;
		}
		catch
		{
			return false;
		}
	}

	private static bool c()
	{
		if (Process.GetProcessesByName("wsnm").Length != 0 || m.a("SbieDll.dll").ToInt32() != 0)
		{
			return true;
		}
		return false;
	}

	public static bool d()
	{
		if (!b(Process.GetCurrentProcess()) && !c() && !global::b.a && !a())
		{
			return false;
		}
		return true;
	}
}
