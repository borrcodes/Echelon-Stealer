using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Echelon.Properties
{
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	internal class Resources
	{
		private static ResourceManager a;

		private static CultureInfo b;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager c
		{
			get
			{
				if (a == null)
				{
					a = new ResourceManager("Echelon.Properties.Resources", typeof(Resources).Assembly);
				}
				return a;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo d
		{
			get
			{
				return b;
			}
			set
			{
				b = value;
			}
		}

		internal static string e => c.GetString("Adress", b);

		internal Resources()
		{
		}
	}
}
