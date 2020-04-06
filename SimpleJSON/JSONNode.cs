using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SimpleJSON
{
	public abstract class JSONNode
	{
		public struct Enumerator
		{
			private enum a
			{
				a,
				b,
				c
			}

			private readonly a m_a;

			private Dictionary<string, JSONNode>.Enumerator b;

			private List<JSONNode>.Enumerator c;

			public bool IsValid => this.m_a != Enumerator.a.a;

			public KeyValuePair<string, JSONNode> Current
			{
				get
				{
					if (this.m_a == Enumerator.a.b)
					{
						return new KeyValuePair<string, JSONNode>(string.Empty, c.Current);
					}
					if (this.m_a == Enumerator.a.c)
					{
						return b.Current;
					}
					return new KeyValuePair<string, JSONNode>(string.Empty, null);
				}
			}

			public Enumerator(List<JSONNode>.Enumerator aArrayEnum)
			{
				this.m_a = Enumerator.a.b;
				b = default(Dictionary<string, JSONNode>.Enumerator);
				c = aArrayEnum;
			}

			public Enumerator(Dictionary<string, JSONNode>.Enumerator aDictEnum)
			{
				this.m_a = Enumerator.a.c;
				b = aDictEnum;
				c = default(List<JSONNode>.Enumerator);
			}

			public bool MoveNext()
			{
				if (this.m_a == Enumerator.a.b)
				{
					return c.MoveNext();
				}
				if (this.m_a == Enumerator.a.c)
				{
					return b.MoveNext();
				}
				return false;
			}
		}

		public struct ValueEnumerator
		{
			private Enumerator a;

			public JSONNode Current => a.Current.Value;

			public ValueEnumerator(List<JSONNode>.Enumerator aArrayEnum)
				: this(new Enumerator(aArrayEnum))
			{
			}

			public ValueEnumerator(Dictionary<string, JSONNode>.Enumerator aDictEnum)
				: this(new Enumerator(aDictEnum))
			{
			}

			public ValueEnumerator(Enumerator aEnumerator)
			{
				a = aEnumerator;
			}

			public bool MoveNext()
			{
				return a.MoveNext();
			}

			public ValueEnumerator GetEnumerator()
			{
				return this;
			}
		}

		public struct KeyEnumerator
		{
			private Enumerator a;

			public JSONNode Current => a.Current.Key;

			public KeyEnumerator(List<JSONNode>.Enumerator aArrayEnum)
				: this(new Enumerator(aArrayEnum))
			{
			}

			public KeyEnumerator(Dictionary<string, JSONNode>.Enumerator aDictEnum)
				: this(new Enumerator(aDictEnum))
			{
			}

			public KeyEnumerator(Enumerator aEnumerator)
			{
				a = aEnumerator;
			}

			public bool MoveNext()
			{
				return a.MoveNext();
			}

			public KeyEnumerator GetEnumerator()
			{
				return this;
			}
		}

		public class LinqEnumerator : IEnumerator<KeyValuePair<string, JSONNode>>, IEnumerable<KeyValuePair<string, JSONNode>>, IDisposable, IEnumerator, IEnumerable
		{
			private JSONNode a;

			private Enumerator b;

			public KeyValuePair<string, JSONNode> Current => b.Current;

			object IEnumerator.Current => b.Current;

			internal LinqEnumerator(JSONNode f)
			{
				a = f;
				if (a != null)
				{
					b = a.GetEnumerator();
				}
			}

			public bool MoveNext()
			{
				return b.MoveNext();
			}

			public void Dispose()
			{
				a = null;
				b = default(Enumerator);
			}

			public IEnumerator<KeyValuePair<string, JSONNode>> GetEnumerator()
			{
				return new LinqEnumerator(a);
			}

			public void Reset()
			{
				if (a != null)
				{
					b = a.GetEnumerator();
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return new LinqEnumerator(a);
			}
		}

		public static bool forceASCII;

		[ThreadStatic]
		private static StringBuilder m_a;

		public abstract JSONNodeType Tag
		{
			get;
		}

		public virtual JSONNode this[int aIndex]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual JSONNode this[string aKey]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual string Value
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		public virtual int Count => 0;

		public virtual bool IsNumber => false;

		public virtual bool IsString => false;

		public virtual bool IsBoolean => false;

		public virtual bool IsNull => false;

		public virtual bool IsArray => false;

		public virtual bool IsObject => false;

		public virtual bool Inline
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual IEnumerable<JSONNode> Children
		{
			get
			{
				yield break;
			}
		}

		public IEnumerable<JSONNode> DeepChildren
		{
			get
			{
				foreach (JSONNode child in Children)
				{
					foreach (JSONNode deepChild in child.DeepChildren)
					{
						yield return deepChild;
					}
				}
			}
		}

		public IEnumerable<KeyValuePair<string, JSONNode>> Linq => new LinqEnumerator(this);

		public KeyEnumerator Keys => new KeyEnumerator(GetEnumerator());

		public ValueEnumerator Values => new ValueEnumerator(GetEnumerator());

		public virtual double AsDouble
		{
			get
			{
				if (double.TryParse(Value, out double result))
				{
					return result;
				}
				return 0.0;
			}
			set
			{
				Value = value.ToString();
			}
		}

		public virtual int AsInt
		{
			get
			{
				return (int)AsDouble;
			}
			set
			{
				AsDouble = value;
			}
		}

		public virtual float AsFloat
		{
			get
			{
				return (float)AsDouble;
			}
			set
			{
				AsDouble = value;
			}
		}

		public virtual bool AsBool
		{
			get
			{
				if (bool.TryParse(Value, out bool result))
				{
					return result;
				}
				return !string.IsNullOrEmpty(Value);
			}
			set
			{
				Value = (value ? "true" : "false");
			}
		}

		public virtual JSONArray AsArray => this as JSONArray;

		public virtual JSONObject AsObject => this as JSONObject;

		internal static StringBuilder b
		{
			get
			{
				if (JSONNode.m_a == null)
				{
					JSONNode.m_a = new StringBuilder();
				}
				return JSONNode.m_a;
			}
		}

		public virtual void Add(string aKey, JSONNode aItem)
		{
		}

		public virtual void Add(JSONNode aItem)
		{
			Add("", aItem);
		}

		public virtual JSONNode Remove(string aKey)
		{
			return null;
		}

		public virtual JSONNode Remove(int aIndex)
		{
			return null;
		}

		public virtual JSONNode Remove(JSONNode aNode)
		{
			return aNode;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			c(stringBuilder, 0, 0, JSONTextMode.Compact);
			return stringBuilder.ToString();
		}

		public virtual string ToString(int aIndent)
		{
			StringBuilder stringBuilder = new StringBuilder();
			c(stringBuilder, 0, aIndent, JSONTextMode.Indent);
			return stringBuilder.ToString();
		}

		internal abstract void c(StringBuilder kq, int kr, int ks, JSONTextMode kt);

		public abstract Enumerator GetEnumerator();

		public static implicit operator JSONNode(string s)
		{
			return new JSONString(s);
		}

		public static implicit operator string(JSONNode d)
		{
			return d?.Value;
		}

		public static implicit operator JSONNode(double n)
		{
			return new JSONNumber(n);
		}

		public static implicit operator double(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsDouble;
			}
			return 0.0;
		}

		public static implicit operator JSONNode(float n)
		{
			return new JSONNumber(n);
		}

		public static implicit operator float(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsFloat;
			}
			return 0f;
		}

		public static implicit operator JSONNode(int n)
		{
			return new JSONNumber(n);
		}

		public static implicit operator int(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsInt;
			}
			return 0;
		}

		public static implicit operator JSONNode(bool b)
		{
			return new JSONBool(b);
		}

		public static implicit operator bool(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsBool;
			}
			return false;
		}

		public static implicit operator JSONNode(KeyValuePair<string, JSONNode> aKeyValue)
		{
			return aKeyValue.Value;
		}

		public static bool operator ==(JSONNode a, object b)
		{
			if ((object)a == b)
			{
				return true;
			}
			bool flag = a is JSONNull || (object)a == null || a is global::a;
			bool flag2 = b is JSONNull || b == null || b is global::a;
			if (flag && flag2)
			{
				return true;
			}
			if (!flag)
			{
				return a.Equals(b);
			}
			return false;
		}

		public static bool operator !=(JSONNode a, object b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			return (object)this == obj;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		internal static string a(string a)
		{
			StringBuilder b = JSONNode.b;
			b.Length = 0;
			if (b.Capacity < a.Length + a.Length / 10)
			{
				b.Capacity = a.Length + a.Length / 10;
			}
			foreach (char c in a)
			{
				switch (c)
				{
				case '\\':
					b.Append("\\\\");
					continue;
				case '"':
					b.Append("\\\"");
					continue;
				case '\n':
					b.Append("\\n");
					continue;
				case '\r':
					b.Append("\\r");
					continue;
				case '\t':
					b.Append("\\t");
					continue;
				case '\b':
					b.Append("\\b");
					continue;
				case '\f':
					b.Append("\\f");
					continue;
				}
				if (c < ' ' || (forceASCII && c > '\u007f'))
				{
					ushort num = c;
					b.Append("\\u").Append(num.ToString("X4"));
				}
				else
				{
					b.Append(c);
				}
			}
			string result = b.ToString();
			b.Length = 0;
			return result;
		}

		private static void b(JSONNode b, string c, string d, bool e)
		{
			if (e)
			{
				b.Add(d, c);
				return;
			}
			string text = c.ToLower();
			switch (text)
			{
			case "false":
			case "true":
				b.Add(d, text == "true");
				return;
			case "null":
				b.Add(d, null);
				return;
			}
			if (double.TryParse(c, out double result))
			{
				b.Add(d, result);
			}
			else
			{
				b.Add(d, c);
			}
		}

		public static JSONNode Parse(string aJSON)
		{
			Stack<JSONNode> stack = new Stack<JSONNode>();
			JSONNode jSONNode = null;
			int i = 0;
			StringBuilder stringBuilder = new StringBuilder();
			string text = "";
			bool flag = false;
			bool flag2 = false;
			for (; i < aJSON.Length; i++)
			{
				switch (aJSON[i])
				{
				case '{':
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
						break;
					}
					stack.Push(new JSONObject());
					if (jSONNode != null)
					{
						jSONNode.Add(text, stack.Peek());
					}
					text = "";
					stringBuilder.Length = 0;
					jSONNode = stack.Peek();
					break;
				case '[':
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
						break;
					}
					stack.Push(new JSONArray());
					if (jSONNode != null)
					{
						jSONNode.Add(text, stack.Peek());
					}
					text = "";
					stringBuilder.Length = 0;
					jSONNode = stack.Peek();
					break;
				case ']':
				case '}':
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
						break;
					}
					if (stack.Count == 0)
					{
						throw new Exception("JSON Parse: Too many closing brackets");
					}
					stack.Pop();
					if (stringBuilder.Length > 0 || flag2)
					{
						b(jSONNode, stringBuilder.ToString(), text, flag2);
						flag2 = false;
					}
					text = "";
					stringBuilder.Length = 0;
					if (stack.Count > 0)
					{
						jSONNode = stack.Peek();
					}
					break;
				case ':':
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
						break;
					}
					text = stringBuilder.ToString();
					stringBuilder.Length = 0;
					flag2 = false;
					break;
				case '"':
					flag = !flag;
					flag2 = (flag2 || flag);
					break;
				case ',':
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
						break;
					}
					if (stringBuilder.Length > 0 || flag2)
					{
						b(jSONNode, stringBuilder.ToString(), text, flag2);
					}
					text = "";
					stringBuilder.Length = 0;
					flag2 = false;
					break;
				case '\t':
				case ' ':
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
					}
					break;
				case '\\':
					i++;
					if (flag)
					{
						char c = aJSON[i];
						switch (c)
						{
						case 't':
							stringBuilder.Append('\t');
							break;
						case 'r':
							stringBuilder.Append('\r');
							break;
						case 'n':
							stringBuilder.Append('\n');
							break;
						case 'b':
							stringBuilder.Append('\b');
							break;
						case 'f':
							stringBuilder.Append('\f');
							break;
						case 'u':
						{
							string s = aJSON.Substring(i + 1, 4);
							stringBuilder.Append((char)int.Parse(s, NumberStyles.AllowHexSpecifier));
							i += 4;
							break;
						}
						default:
							stringBuilder.Append(c);
							break;
						}
					}
					break;
				default:
					stringBuilder.Append(aJSON[i]);
					break;
				case '\n':
				case '\r':
					break;
				}
			}
			if (flag)
			{
				throw new Exception("JSON Parse: Quotation marks seems to be messed up.");
			}
			return jSONNode;
		}
	}
}
