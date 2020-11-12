using ETModel;

namespace ETHotfix
{
	[Config((int)(AppType.ClientH |  AppType.ClientM | AppType.Gate | AppType.Map))]
	public partial class defendMonsterCategory : ACategory<defendMonster>
	{
	}

	public class defendMonster: IConfig
	{
		public long Id { get; set; }
		public int[] unitID;
	}
}
