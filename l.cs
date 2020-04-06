using System.Threading;

internal class l
{
	public static Mutex a;

	public static bool a()
	{
		l.a = new Mutex(initiallyOwned: true, "{Echelon}", out bool createdNew);
		return createdNew;
	}
}
