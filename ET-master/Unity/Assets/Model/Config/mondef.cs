using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
	[Config]
	public partial class mondefCategory : ACategory<mondef>
	{
		public static mondefCategory Instance;
		public mondefCategory()
		{
			Instance = this;
		}
	}

	public partial class mondef: IConfig
	{
		[BsonId]
		public long Id { get; set; }
		public string name;
		public int MHP;
		public int mp;
		public int MinDEF;
		public int MaxDEF;
		public int MinMDEF;
		public int MaxMDEF;
		public int MinATK;
		public int MaxATK;
		public int MinMATK;
		public int MaxMATK;
		public int DODGE;
		public int HIT;
		public int minStayTime;
		public int maxStayTime;
		public int moveTime;
		public int CRIRate;
		public int DUCrate;
		public int ADTR;
		public int MR;
		public int HPup;
		public int showTomb;
	}
}
