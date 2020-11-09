namespace ETModel
{
	[Config((int)(AppType.ClientH |  AppType.ClientM | AppType.Gate | AppType.Map))]
	public partial class LevelinfoCategory : ACategory<Levelinfo>
	{
	}

	public class Levelinfo: IConfig
	{
		public long Id { get; set; }
		public int zhiye;
		public int lv;
		public long jingyan;
		public int zhuansheng;
		public int shengwang;
		public int hp;
		public int mp;
		public int minat;
		public int maxat;
		public int minmt;
		public int maxmt;
		public int mindt;
		public int maxdt;
		public int mindef;
		public int maxdef;
		public int minmef;
		public int maxmef;
		public int jingzhun;
		public int miss;
	}
}
