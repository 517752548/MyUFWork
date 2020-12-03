using System;
using System.Reflection;

namespace ProtoBuf.Serializers
{
	internal sealed class MemberSpecifiedDecorator : ProtoDecoratorBase
	{
		private readonly MethodInfo getSpecified;

		private readonly MethodInfo setSpecified;

		public override Type ExpectedType => base.Tail.ExpectedType;

		public override bool RequiresOldValue => base.Tail.RequiresOldValue;

		public override bool ReturnsValue => base.Tail.ReturnsValue;

		public MemberSpecifiedDecorator(MethodInfo getSpecified, MethodInfo setSpecified, IProtoSerializer tail)
			: base(tail)
		{
			if (getSpecified == (MethodInfo)null && setSpecified == (MethodInfo)null)
			{
				throw new InvalidOperationException();
			}
			this.getSpecified = getSpecified;
			this.setSpecified = setSpecified;
		}

		public override void Write(object value, ProtoWriter dest)
		{
			if (!(getSpecified == (MethodInfo)null) && !(bool)getSpecified.Invoke(value, null))
			{
				return;
			}
			base.Tail.Write(value, dest);
		}

		public override object Read(object value, ProtoReader source)
		{
			object result = base.Tail.Read(value, source);
			if (setSpecified != (MethodInfo)null)
			{
				setSpecified.Invoke(value, new object[1]
				{
					true
				});
			}
			return result;
		}
	}
}
