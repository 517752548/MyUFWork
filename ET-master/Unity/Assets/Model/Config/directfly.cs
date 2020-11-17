using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
	[Config]
	public partial class directflyCategory : ACategory<directfly>
	{
		public static directflyCategory Instance;
		public directflyCategory()
		{
			Instance = this;
		}
	}

	public partial class directfly: IConfig
	{
		[BsonId]
		public long Id { get; set; }
		public string tomap;
		public int tox;
		public int toy;
	}
}
