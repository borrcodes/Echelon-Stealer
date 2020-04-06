using System.Text;

namespace SimpleJSON
{
	public class JSONString : JSONNode
	{
		private string e;

		public override JSONNodeType Tag => JSONNodeType.String;

		public override bool IsString => true;

		public override string Value
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

		public JSONString(string aData)
		{
			e = aData;
		}

		internal override void c(StringBuilder lc, int ld, int le, JSONTextMode lf)
		{
			lc.Append('"').Append(JSONNode.a(e)).Append('"');
		}

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				return true;
			}
			string text = obj as string;
			if (text != null)
			{
				return e == text;
			}
			JSONString jSONString = obj as JSONString;
			if (jSONString != null)
			{
				return e == jSONString.e;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return e.GetHashCode();
		}
	}
}
