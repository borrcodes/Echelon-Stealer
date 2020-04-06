using System;
using System.IO;
using System.Reflection;

internal sealed class bg
{
	private delegate string a();

	private sealed class b
	{
		private static readonly a m_a;

		public static readonly b b;

		private byte[] c;

		static b()
		{
			b.m_a = bg.b;
			b = new b();
		}

		private b()
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(b.m_a());
			if (((manifestResourceStream == null) ? (-(~(-349463623) - 349463623)) : (~(~(-(~-1) >> 5)) << 2)) == 0)
			{
				c = new byte[(-369773799 ^ 0xA378642) - -431421042 + 42390595];
				manifestResourceStream.Read(c, ~(~(-563658827) + -322561289 - 371312866) - 130215328, c.Length);
			}
		}

		public string a(string ko, int kp)
		{
			int num = ko.Length;
			char[] array = ko.ToCharArray();
			while (--num >= (-(~(--693875382)) ^ 0x295BB2B7))
			{
				array[num] = (char)(array[num] ^ (c[kp & (~((-752350330 ^ -558801033) - -88273807) - 333869958 + 650296342)] | kp));
			}
			return new string(array);
		}
	}

	public static string a(string kk, int kl)
	{
		DateTime d = new DateTime(-706211239 - -285295385 + 420917874, ~(-(-21108956 ^ -21108987)) >> 3, -457866877 ^ -457866875);
		if ((d - DateTime.Now).TotalDays < 0.0)
		{
			throw new ArgumentException();
		}
		return bg.b.b.a(kk, kl);
	}

	public static string b()
	{
		char[] array = "óðÚÐ".ToCharArray();
		int num = array.Length;
		while (--num >= (--583136462 ^ 0x22C1F4CE) >> 7)
		{
			array[num] = (char)(array[num] ^ (~(-(--927240567 + 64325395 - 356083740)) ^ 0x25E0B0F1));
		}
		return new string(array);
	}
}
