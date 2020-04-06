namespace Echelon
{
	public class AeadParameters : ICipherParameters
	{
		private readonly byte[] a;

		private readonly byte[] b;

		private readonly KeyParameter c;

		private readonly int d;

		public virtual KeyParameter Key => c;

		public virtual int MacSize => d;

		public AeadParameters(KeyParameter key, int macSize, byte[] nonce, byte[] associatedText)
		{
			c = key;
			b = nonce;
			d = macSize;
			a = associatedText;
		}

		public virtual byte[] GetAssociatedText()
		{
			return a;
		}

		public virtual byte[] GetNonce()
		{
			return b;
		}
	}
}
