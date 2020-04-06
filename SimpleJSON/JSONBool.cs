using System;
using System.Text;

namespace SimpleJSON
{
	public class JSONBool : JSONNode
	{
		private bool e;

		public override JSONNodeType Tag => JSONNodeType.Boolean;

		public override bool IsBoolean
		{
			get
			{
				DateTime d = default(DateTime).AddYears(-((-45239256 >> 3) - -5652888)).AddMonths(-(((506596702 << 1) + -472171940) ^ -541021470) >> 1).AddDays(5.3471412037037);
				if ((d - DateTime.Now).TotalDays < 0.0)
				{
					int num = -(~(-602014302 - -602014301) << 1) >> 7;
					num = ((-549384224 >> 3) - -68673044 >> 4) / num;
				}
				return true;
			}
		}

		public override string Value
		{
			get
			{
				return e.ToString();
			}
			set
			{
				if (bool.TryParse(value, out bool result))
				{
					e = result;
				}
			}
		}

		public override bool AsBool
		{
			get
			{
				return e;
			}
			set
			{
				e = value;
			}
		}

		public override Enumerator GetEnumerator()
		{
			DateTime t = new DateTime((-1699594180 >> 2) - -424900565, --4, -(--178923835 ^ -178923839));
			if (t < DateTime.Now || 1 == 0)
			{
				int num = -(639325973 + -57134390 - 582191583 << 7);
				num = (-65904617 - -65904618) / num;
			}
			return default(Enumerator);
		}

		public JSONBool(bool aData)
		{
			e = aData;
		}

		public JSONBool(string aData)
		{
			Value = aData;
		}

		internal override void c(StringBuilder lk, int ll, int lm, JSONTextMode ln)
		{
			lk.Append(e ? "true" : "false");
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is bool)
			{
				return e == (bool)obj;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return e.GetHashCode();
		}
	}
}
