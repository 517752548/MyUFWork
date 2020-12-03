using System.IO;

namespace DCET
{
	public class ProtobufPacker : IMessagePacker
	{
		public void SerializeTo(object obj, MemoryStream stream)
		{
			ProtobufHelper.ToStream(obj, stream);
		}

		public object DeserializeFrom(object instance, MemoryStream stream)
		{
			return ProtobufHelper.FromStream(instance, stream);
		}
	}
}
