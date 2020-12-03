using MongoDB.Bson.Serialization.Attributes;

namespace DCET
{
	[BsonIgnoreExtraElements]
	public class RunServerConfig: AConfigComponent
	{
		public string IP = "";
	}
}