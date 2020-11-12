using ETModel;

namespace ETHotfix
{
	[Config((int)(AppType.ClientH |  AppType.ClientM | AppType.Gate | AppType.Map))]
	public partial class directflyCategory : ACategory<directfly>
	{
	}

	public class directfly: IConfig
	{
		public long Id { get; set; }
		public string tomap;
		public int tox;
		public int toy;
	}
}
