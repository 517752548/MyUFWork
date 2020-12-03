using DCETRuntime;

namespace DCET
{
	[Config((int)(AppType.ClientH |  AppType.ClientM | AppType.Gate | AppType.Map))]
	public partial class UnitConfig2Category : ACategory<UnitConfig2>
	{
	}

	public class UnitConfig2: IConfig
	{
		public long _id {get; set;}
		public string Name {get; set;}
		public string Desc {get; set;}
		public int Position {get; set;}
		public int Height {get; set;}
		public int Weight {get; set;}
	}
}
