using System.Collections.Generic;
using System.Text;

namespace SimpleJSON
{
	public class JSONArray : JSONNode
	{
		private new readonly List<JSONNode> b = new List<JSONNode>();

		private new bool m_c;

		public override bool Inline
		{
			get
			{
				return this.m_c;
			}
			set
			{
				this.m_c = value;
			}
		}

		public override JSONNodeType Tag => JSONNodeType.Array;

		public override bool IsArray => true;

		public override JSONNode this[int aIndex]
		{
			get
			{
				if (aIndex < 0 || aIndex >= b.Count)
				{
					return new global::a(this);
				}
				return b[aIndex];
			}
			set
			{
				if (value == null)
				{
					value = JSONNull.CreateOrGet();
				}
				if (aIndex < 0 || aIndex >= b.Count)
				{
					b.Add(value);
				}
				else
				{
					b[aIndex] = value;
				}
			}
		}

		public override JSONNode this[string aKey]
		{
			get
			{
				return new global::a(this);
			}
			set
			{
				if (value == null)
				{
					value = JSONNull.CreateOrGet();
				}
				b.Add(value);
			}
		}

		public override int Count => b.Count;

		public override IEnumerable<JSONNode> Children
		{
			get
			{
				foreach (JSONNode item in b)
				{
					yield return item;
				}
			}
		}

		public override Enumerator GetEnumerator()
		{
			return new Enumerator(b.GetEnumerator());
		}

		public override void Add(string aKey, JSONNode aItem)
		{
			if (aItem == null)
			{
				aItem = JSONNull.CreateOrGet();
			}
			b.Add(aItem);
		}

		public override JSONNode Remove(int aIndex)
		{
			if (aIndex < 0 || aIndex >= b.Count)
			{
				return null;
			}
			JSONNode result = b[aIndex];
			b.RemoveAt(aIndex);
			return result;
		}

		public override JSONNode Remove(JSONNode aNode)
		{
			b.Remove(aNode);
			return aNode;
		}

		internal override void c(StringBuilder ku, int kv, int kw, JSONTextMode kx)
		{
			ku.Append('[');
			int count = b.Count;
			if (this.m_c)
			{
				kx = JSONTextMode.Compact;
			}
			for (int i = 0; i < count; i++)
			{
				if (i > 0)
				{
					ku.Append(',');
				}
				if (kx == JSONTextMode.Indent)
				{
					ku.AppendLine();
				}
				if (kx == JSONTextMode.Indent)
				{
					ku.Append(' ', kv + kw);
				}
				b[i].c(ku, kv + kw, kw, kx);
			}
			if (kx == JSONTextMode.Indent)
			{
				ku.AppendLine().Append(' ', kv);
			}
			ku.Append(']');
		}
	}
}
