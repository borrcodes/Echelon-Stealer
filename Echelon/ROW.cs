using System.Runtime.CompilerServices;

namespace Echelon
{
	public struct ROW
	{
		[CompilerGenerated]
		private long a;

		[CompilerGenerated]
		private string[] b;

		public long ID
		{
			get;
			set;
		}

		public string[] RowData
		{
			get;
			set;
		}
	}
}
