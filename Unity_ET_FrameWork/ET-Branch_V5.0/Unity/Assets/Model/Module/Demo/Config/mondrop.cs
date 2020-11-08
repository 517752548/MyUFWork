namespace ETModel
{
	[Config((int)(AppType.ClientH |  AppType.ClientM | AppType.Gate | AppType.Map))]
	public partial class mondropCategory : ACategory<mondrop>
	{
	}

	public class mondrop: IConfig
	{
		public long Id { get; set; }
		public int dropsID;
		public int bangding;
		public int feibangding;
		public int dropid;
		public int dropsID2;
		public int DropRate;
		public int isbangding;
		public int droptime;
	}
}
