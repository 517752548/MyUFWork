using ProtoBuf.Meta;
using System;

namespace ProtoBuf.Serializers
{
	internal sealed class TagDecorator : ProtoDecoratorBase, IProtoTypeSerializer, IProtoSerializer
	{
		private readonly bool strict;

		private readonly int fieldNumber;

		private readonly WireType wireType;

		public override Type ExpectedType => base.Tail.ExpectedType;

		public override bool RequiresOldValue => base.Tail.RequiresOldValue;

		public override bool ReturnsValue => base.Tail.ReturnsValue;

		private bool NeedsHint => (wireType & (WireType)(-8)) != WireType.Variant;

		public bool HasCallbacks(TypeModel.CallbackType callbackType)
		{
			IProtoTypeSerializer protoTypeSerializer = base.Tail as IProtoTypeSerializer;
			return protoTypeSerializer?.HasCallbacks(callbackType) ?? false;
		}

		public bool CanCreateInstance()
		{
			IProtoTypeSerializer protoTypeSerializer = base.Tail as IProtoTypeSerializer;
			return protoTypeSerializer?.CanCreateInstance() ?? false;
		}

		public object CreateInstance(ProtoReader source)
		{
			return ((IProtoTypeSerializer)base.Tail).CreateInstance(source);
		}

		public void Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context)
		{
			IProtoTypeSerializer protoTypeSerializer = base.Tail as IProtoTypeSerializer;
			protoTypeSerializer?.Callback(value, callbackType, context);
		}

		public TagDecorator(int fieldNumber, WireType wireType, bool strict, IProtoSerializer tail)
			: base(tail)
		{
			this.fieldNumber = fieldNumber;
			this.wireType = wireType;
			this.strict = strict;
		}

		public override object Read(object value, ProtoReader source)
		{
			if (strict)
			{
				source.Assert(wireType);
			}
			else if (NeedsHint)
			{
				source.Hint(wireType);
			}
			return base.Tail.Read(value, source);
		}

		public override void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteFieldHeader(fieldNumber, wireType, dest);
			base.Tail.Write(value, dest);
		}
	}
}
