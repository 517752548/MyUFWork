using ProtoBuf.Meta;
using System;

namespace ProtoBuf.Serializers
{
	internal sealed class ByteSerializer : IProtoSerializer
	{
		private static readonly Type expectedType = typeof(byte);

		public Type ExpectedType => expectedType;

		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		public ByteSerializer(TypeModel model)
		{
		}

		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteByte((byte)value, dest);
		}

		public object Read(object value, ProtoReader source)
		{
			return source.ReadByte();
		}
	}
}
