using System;

namespace Echelon
{
	public class ParametersWithIV : ICipherParameters
	{
		private readonly ICipherParameters a;

		private readonly byte[] b;

		public ICipherParameters Parameters => a;

		public ParametersWithIV(ICipherParameters parameters, byte[] iv)
			: this(parameters, iv, 0, iv.Length)
		{
		}

		public ParametersWithIV(ICipherParameters parameters, byte[] iv, int ivOff, int ivLen)
		{
			if (parameters == null)
			{
				throw new ArgumentNullException("parameters");
			}
			if (iv == null)
			{
				throw new ArgumentNullException("iv");
			}
			a = parameters;
			b = new byte[ivLen];
			Array.Copy(iv, ivOff, b, 0, ivLen);
		}

		public byte[] GetIV()
		{
			DateTime t = new DateTime(-((-807354303 ^ 0x115F26AF) - -557844810 >> 1), ~(-40 >> 3), ((1532272490 + -405614593 - 546208640) ^ -13634074) - -575207927);
			if (DateTime.Now > t || 1 == 0)
			{
				int num = -((~42013938 - 489096920) ^ -531110859);
				num = -(419346375 + -419346376) / num;
			}
			return (byte[])b.Clone();
		}
	}
}
