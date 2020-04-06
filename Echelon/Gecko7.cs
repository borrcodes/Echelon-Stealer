using System.Globalization;
using System.Runtime.CompilerServices;

namespace Echelon
{
	public class Gecko7
	{
		[CompilerGenerated]
		private readonly string a;

		[CompilerGenerated]
		private readonly string b;

		[CompilerGenerated]
		private readonly string c;

		public string EntrySalt
		{
			get;
		}

		public string OID
		{
			get;
		}

		public string Passwordcheck
		{
			get;
		}

		public Gecko7(string DataToParse)
		{
			int num = int.Parse(DataToParse.Substring(2, 2), NumberStyles.HexNumber) * 2;
			a = DataToParse.Substring(6, num);
			int num2 = DataToParse.Length - (6 + num + 36);
			b = DataToParse.Substring(6 + num + 36, num2);
			c = DataToParse.Substring(6 + num + 4 + num2);
		}
	}
}
