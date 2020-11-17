using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
	[Config]
	public partial class itemStackCategory : ACategory<itemStack>
	{
		public static itemStackCategory Instance;
		public itemStackCategory()
		{
			Instance = this;
		}
	}

	public partial class itemStack: IConfig
	{
		[BsonId]
		public long Id { get; set; }
		public string name;
		public int stack;
	}
}
