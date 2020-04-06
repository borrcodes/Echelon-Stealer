using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SimpleJSON
{
	public class JSONObject : JSONNode
	{
		[CompilerGenerated]
		private new sealed class a
		{
			public JSONNode a;

			internal bool a(KeyValuePair<string, JSONNode> j)
			{
				return j.Value == this.a;
			}
		}

		private readonly Dictionary<string, JSONNode> d = new Dictionary<string, JSONNode>();

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

		public override JSONNodeType Tag => JSONNodeType.Object;

		public override bool IsObject => true;

		public override JSONNode this[string aKey]
		{
			get
			{
				if (d.ContainsKey(aKey))
				{
					return d[aKey];
				}
				return new global::a(this, aKey);
			}
			set
			{
				if (value == null)
				{
					value = JSONNull.CreateOrGet();
				}
				if (d.ContainsKey(aKey))
				{
					d[aKey] = value;
				}
				else
				{
					d.Add(aKey, value);
				}
			}
		}

		public override JSONNode this[int aIndex]
		{
			get
			{
				if (aIndex < 0 || aIndex >= d.Count)
				{
					return null;
				}
				return d.ElementAt(aIndex).Value;
			}
			set
			{
				if (value == null)
				{
					value = JSONNull.CreateOrGet();
				}
				if (aIndex >= 0 && aIndex < d.Count)
				{
					string key = d.ElementAt(aIndex).Key;
					d[key] = value;
				}
			}
		}

		public override int Count => d.Count;

		public override IEnumerable<JSONNode> Children
		{
			get
			{
				foreach (KeyValuePair<string, JSONNode> item in d)
				{
					yield return item.Value;
				}
			}
		}

		public override Enumerator GetEnumerator()
		{
			return new Enumerator(d.GetEnumerator());
		}

		public override void Add(string aKey, JSONNode aItem)
		{
			if (aItem == null)
			{
				aItem = JSONNull.CreateOrGet();
			}
			if (!string.IsNullOrEmpty(aKey))
			{
				if (d.ContainsKey(aKey))
				{
					d[aKey] = aItem;
				}
				else
				{
					d.Add(aKey, aItem);
				}
			}
			else
			{
				d.Add(Guid.NewGuid().ToString(), aItem);
			}
		}

		public override JSONNode Remove(string aKey)
		{
			if (!d.ContainsKey(aKey))
			{
				return null;
			}
			JSONNode result = d[aKey];
			d.Remove(aKey);
			return result;
		}

		public override JSONNode Remove(int aIndex)
		{
			if (aIndex < 0 || aIndex >= d.Count)
			{
				return null;
			}
			KeyValuePair<string, JSONNode> keyValuePair = d.ElementAt(aIndex);
			d.Remove(keyValuePair.Key);
			return keyValuePair.Value;
		}

		public override JSONNode Remove(JSONNode aNode)
		{
			try
			{
				KeyValuePair<string, JSONNode> keyValuePair = d.Where((KeyValuePair<string, JSONNode> j) => j.Value == aNode).First();
				d.Remove(keyValuePair.Key);
				return aNode;
			}
			catch (Exception)
			{
				return null;
			}
		}

		internal override void c(StringBuilder ky, int kz, int la, JSONTextMode lb)
		{
			ky.Append('{');
			bool flag = true;
			if (this.m_c)
			{
				lb = JSONTextMode.Compact;
			}
			foreach (KeyValuePair<string, JSONNode> item in d)
			{
				if (!flag)
				{
					ky.Append(',');
				}
				flag = false;
				if (lb == JSONTextMode.Indent)
				{
					ky.AppendLine();
				}
				if (lb == JSONTextMode.Indent)
				{
					ky.Append(' ', kz + la);
				}
				ky.Append('"').Append(JSONNode.a(item.Key)).Append('"');
				if (lb == JSONTextMode.Compact)
				{
					ky.Append(':');
				}
				else
				{
					ky.Append(" : ");
				}
				item.Value.c(ky, kz + la, la, lb);
			}
			if (lb == JSONTextMode.Indent)
			{
				ky.AppendLine().Append(' ', kz);
			}
			ky.Append('}');
		}
	}
}
