using System.IO;

namespace DCET
{
	public interface IMessagePacker
	{
		void SerializeTo(object obj, MemoryStream stream);
		object DeserializeFrom(object instance, MemoryStream stream);
	}
}
