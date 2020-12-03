using System.Net;
using MongoDB.Bson.Serialization.Attributes;

namespace DCET
{
	[NoObjectPool]
	[BsonIgnoreExtraElements]
	public class InnerConfig: AConfigComponent
	{
		public string Address { get; set; }
	}
}