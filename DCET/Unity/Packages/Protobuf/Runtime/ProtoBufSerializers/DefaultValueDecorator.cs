using ProtoBuf.Meta;
using System;

namespace ProtoBuf.Serializers
{
	internal sealed class DefaultValueDecorator : ProtoDecoratorBase
	{
		private readonly object defaultValue;

		public override Type ExpectedType => base.Tail.ExpectedType;

		public override bool RequiresOldValue => base.Tail.RequiresOldValue;

		public override bool ReturnsValue => base.Tail.ReturnsValue;

		public DefaultValueDecorator(TypeModel model, object defaultValue, IProtoSerializer tail)
			: base(tail)
		{
			if (defaultValue == null)
			{
				throw new ArgumentNullException("defaultValue");
			}
			if (model.MapType(defaultValue.GetType()) != tail.ExpectedType)
			{
				throw new ArgumentException("Default value is of incorrect type", "defaultValue");
			}
			this.defaultValue = defaultValue;
		}

		public override void Write(object value, ProtoWriter dest)
		{
			if (!object.Equals(value, defaultValue))
			{
				base.Tail.Write(value, dest);
			}
		}

		public override object Read(object value, ProtoReader source)
		{
			return base.Tail.Read(value, source);
		}
	}
}
