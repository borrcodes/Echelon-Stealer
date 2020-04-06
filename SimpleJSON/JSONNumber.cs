using System;
using System.Text;

namespace SimpleJSON
{
	public class JSONNumber : JSONNode
	{
		private double e;

		public override JSONNodeType Tag => JSONNodeType.Number;

		public override bool IsNumber => true;

		public override string Value
		{
			get
			{
				return e.ToString();
			}
			set
			{
				if (double.TryParse(value, out double result))
				{
					e = result;
				}
			}
		}

		public override double AsDouble
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
			return default(Enumerator);
		}

		public JSONNumber(double aData)
		{
			e = aData;
		}

		public JSONNumber(string aData)
		{
			Value = aData;
		}

		internal override void c(StringBuilder lg, int lh, int li, JSONTextMode lj)
		{
			lg.Append(e);
		}

		private static bool a(object l)
		{
			if (!(l is int) && !(l is uint) && !(l is float) && !(l is double) && !(l is decimal) && !(l is long) && !(l is ulong) && !(l is short) && !(l is ushort) && !(l is sbyte))
			{
				return l is byte;
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (base.Equals(obj))
			{
				return true;
			}
			JSONNumber jSONNumber = obj as JSONNumber;
			if (jSONNumber != null)
			{
				return e == jSONNumber.e;
			}
			if (a(obj))
			{
				return Convert.ToDouble(obj) == e;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return e.GetHashCode();
		}
	}
}
