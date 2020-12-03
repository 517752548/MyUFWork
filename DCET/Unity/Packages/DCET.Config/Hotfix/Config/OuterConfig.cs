using MongoDB.Bson.Serialization.Attributes;

namespace DCET
{
	[BsonIgnoreExtraElements]
	public class OuterConfig: AConfigComponent
	{
		public string Address { get; set; }
		public string Address2 { get; set; }
	}
}