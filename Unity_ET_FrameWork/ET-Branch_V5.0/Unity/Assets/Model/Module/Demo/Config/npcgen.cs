namespace ETModel
{
	[Config((int)(AppType.ClientH |  AppType.ClientM | AppType.Gate | AppType.Map))]
	public partial class npcgenCategory : ACategory<npcgen>
	{
	}

	public class npcgen: IConfig
	{
		public long Id { get; set; }
		public string mNpcName;
		public string mMapid;
		public int mPosx;
		public int mPosy;
		public string mResModel;
		public int mDirect;
		public int mFlyID;
		public string mDefalutTalk;
	}
}
