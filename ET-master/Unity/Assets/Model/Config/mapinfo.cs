using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
	[Config]
	public partial class mapinfoCategory : ACategory<mapinfo>
	{
		public static mapinfoCategory Instance;
		public mapinfoCategory()
		{
			Instance = this;
		}
	}

	public partial class mapinfo: IConfig
	{
		[BsonId]
		public long Id { get; set; }
		public string mapname;
		public int mongroup;
		public string showname;
		public int width;
		public int height;
		public int mapid;
		public int type;
		public int minlv;
	}
}
