using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
	[Config]
	public partial class mondropCategory : ACategory<mondrop>
	{
		public static mondropCategory Instance;
		public mondropCategory()
		{
			Instance = this;
		}
	}

	public partial class mondrop: IConfig
	{
		[BsonId]
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
