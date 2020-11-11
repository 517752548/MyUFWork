namespace ETModel
{
	[Config((int)(AppType.ClientH |  AppType.ClientM | AppType.Gate | AppType.Map))]
	public partial class mapinfoCategory : ACategory<mapinfo>
	{
	}

	public class mapinfo: IConfig
	{
		public long Id { get; set; }
		public string mapname;
		public string showname;
		public int width;
		public int height;
		public int mapid;
		public int type;
		public int minlv;
	}
}
