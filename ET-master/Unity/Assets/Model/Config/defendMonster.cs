using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
	[Config]
	public partial class defendMonsterCategory : ACategory<defendMonster>
	{
		public static defendMonsterCategory Instance;
		public defendMonsterCategory()
		{
			Instance = this;
		}
	}

	public partial class defendMonster: IConfig
	{
		[BsonId]
		public long Id { get; set; }
		public int[] unitID;
	}
}
