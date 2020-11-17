using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
	[Config]
	public partial class npcgenCategory : ACategory<npcgen>
	{
		public static npcgenCategory Instance;
		public npcgenCategory()
		{
			Instance = this;
		}
	}

	public partial class npcgen: IConfig
	{
		[BsonId]
		public long Id { get; set; }
		public string mNpcName;
		public string mMapid;
		public int mPosx;
		public int mPosy;
		public int mDirect;
		public string CustomPara;
		public string mDefalutTalk;
	}
}
