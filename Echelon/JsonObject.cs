using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Echelon
{
	public class JsonObject : JsonValue, IDictionary<string, JsonValue>, ICollection<KeyValuePair<string, JsonValue>>, IEnumerable<KeyValuePair<string, JsonValue>>, IEnumerable
	{
		private SortedDictionary<string, JsonValue> b;

		public override int Count => b.Count;

		public sealed override JsonValue this[string key]
		{
			get
			{
				return b[key];
			}
			set
			{
				b[key] = value;
			}
		}

		public override JsonType JsonType => JsonType.Object;

		public ICollection<string> Keys => b.Keys;

		public ICollection<JsonValue> Values => b.Values;

		bool ICollection<KeyValuePair<string, JsonValue>>.IsReadOnly => false;

		public JsonObject(params KeyValuePair<string, JsonValue>[] items)
		{
			b = new SortedDictionary<string, JsonValue>(StringComparer.Ordinal);
			if (items != null)
			{
				AddRange(items);
			}
		}

		public JsonObject(IEnumerable<KeyValuePair<string, JsonValue>> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			b = new SortedDictionary<string, JsonValue>(StringComparer.Ordinal);
			AddRange(items);
		}

		public IEnumerator<KeyValuePair<string, JsonValue>> GetEnumerator()
		{
			return b.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return b.GetEnumerator();
		}

		public void Add(string key, JsonValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			b.Add(key, value);
		}

		public void Add(KeyValuePair<string, JsonValue> pair)
		{
			Add(pair.Key, pair.Value);
		}

		public void AddRange(IEnumerable<KeyValuePair<string, JsonValue>> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			foreach (KeyValuePair<string, JsonValue> item in items)
			{
				b.Add(item.Key, item.Value);
			}
		}

		public void AddRange(params KeyValuePair<string, JsonValue>[] items)
		{
			AddRange((IEnumerable<KeyValuePair<string, JsonValue>>)items);
		}

		public void Clear()
		{
			b.Clear();
		}

		bool ICollection<KeyValuePair<string, JsonValue>>.Contains(KeyValuePair<string, JsonValue> item)
		{
			return ((ICollection<KeyValuePair<string, JsonValue>>)b).Contains(item);
		}

		bool ICollection<KeyValuePair<string, JsonValue>>.Remove(KeyValuePair<string, JsonValue> item)
		{
			return ((ICollection<KeyValuePair<string, JsonValue>>)b).Remove(item);
		}

		public override bool ContainsKey(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return b.ContainsKey(key);
		}

		public void CopyTo(KeyValuePair<string, JsonValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<string, JsonValue>>)b).CopyTo(array, arrayIndex);
		}

		public bool Remove(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return b.Remove(key);
		}

		public override void Save(Stream stream, bool parsing)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			stream.WriteByte(123);
			foreach (KeyValuePair<string, JsonValue> item in b)
			{
				stream.WriteByte(34);
				byte[] bytes = Encoding.UTF8.GetBytes(EscapeString(item.Key));
				stream.Write(bytes, 0, bytes.Length);
				stream.WriteByte(34);
				stream.WriteByte(44);
				stream.WriteByte(32);
				if (item.Value == null)
				{
					stream.WriteByte(110);
					stream.WriteByte(117);
					stream.WriteByte(108);
					stream.WriteByte(108);
				}
				else
				{
					item.Value.Save(stream, parsing);
				}
			}
			stream.WriteByte(125);
		}

		public bool TryGetValue(string key, out JsonValue value)
		{
			return b.TryGetValue(key, out value);
		}
	}
}
