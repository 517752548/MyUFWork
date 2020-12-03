using ProtoBuf.Meta;
using System;

namespace ProtoBuf.Serializers
{
	internal sealed class SingleSerializer : IProtoSerializer
	{
		private static readonly Type expectedType = typeof(float);

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

		public SingleSerializer(TypeModel model)
		{
		}

		public object Read(object value, ProtoReader source)
		{
			return source.ReadSingle();
		}

		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteSingle((float)value, dest);
		}
	}
}
