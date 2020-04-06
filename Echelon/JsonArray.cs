using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Echelon
{
	public class JsonArray : JsonValue, IList<JsonValue>, ICollection<JsonValue>, IEnumerable<JsonValue>, IEnumerable
	{
		private List<JsonValue> a;

		public override int Count => a.Count;

		public bool IsReadOnly => false;

		public sealed override JsonValue this[int index]
		{
			get
			{
				return a[index];
			}
			set
			{
				a[index] = value;
			}
		}

		public override JsonType JsonType => JsonType.Array;

		public JsonArray(params JsonValue[] items)
		{
			a = new List<JsonValue>();
			AddRange(items);
		}

		public JsonArray(IEnumerable<JsonValue> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			a = new List<JsonValue>(items);
		}

		public void Add(JsonValue item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			a.Add(item);
		}

		public void AddRange(IEnumerable<JsonValue> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			a.AddRange(items);
		}

		public void AddRange(params JsonValue[] items)
		{
			if (items != null)
			{
				a.AddRange(items);
			}
		}

		public void Clear()
		{
			a.Clear();
		}

		public bool Contains(JsonValue item)
		{
			return a.Contains(item);
		}

		public void CopyTo(JsonValue[] array, int arrayIndex)
		{
			a.CopyTo(array, arrayIndex);
		}

		public int IndexOf(JsonValue item)
		{
			return a.IndexOf(item);
		}

		public void Insert(int index, JsonValue item)
		{
			a.Insert(index, item);
		}

		public bool Remove(JsonValue item)
		{
			return a.Remove(item);
		}

		public void RemoveAt(int index)
		{
			a.RemoveAt(index);
		}

		public override void Save(Stream stream, bool parsing)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			stream.WriteByte(91);
			for (int i = 0; i < a.Count; i++)
			{
				JsonValue jsonValue = a[i];
				if (jsonValue != null)
				{
					jsonValue.Save(stream, parsing);
				}
				else
				{
					stream.WriteByte(110);
					stream.WriteByte(117);
					stream.WriteByte(108);
					stream.WriteByte(108);
				}
				if (i < Count - 1)
				{
					stream.WriteByte(44);
					stream.WriteByte(32);
				}
			}
			stream.WriteByte(93);
		}

		IEnumerator<JsonValue> IEnumerable<JsonValue>.GetEnumerator()
		{
			return a.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return a.GetEnumerator();
		}
	}
}
