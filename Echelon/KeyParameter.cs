using System;

namespace Echelon
{
	public class KeyParameter : ICipherParameters
	{
		private readonly byte[] a;

		public KeyParameter(byte[] key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			a = (byte[])key.Clone();
		}

		public KeyParameter(byte[] key, int keyOff, int keyLen)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (keyOff < 0 || keyOff > key.Length)
			{
				throw new ArgumentOutOfRangeException("keyOff");
			}
			if (keyLen < 0 || keyOff + keyLen > key.Length)
			{
				throw new ArgumentOutOfRangeException("keyLen");
			}
			a = new byte[keyLen];
			Array.Copy(key, keyOff, a, 0, keyLen);
		}

		public byte[] GetKey()
		{
			return (byte[])a.Clone();
		}
	}
}
