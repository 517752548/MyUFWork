using ProtoBuf.Meta;
using System;
using System.Reflection;

namespace ProtoBuf.Serializers
{
	internal sealed class PropertyDecorator : ProtoDecoratorBase
	{
		private readonly PropertyInfo property;

		private readonly Type forType;

		private readonly bool readOptionsWriteValue;

		private readonly MethodInfo shadowSetter;

		public override Type ExpectedType => forType;

		public override bool RequiresOldValue => true;

		public override bool ReturnsValue => false;

		public PropertyDecorator(TypeModel model, Type forType, PropertyInfo property, IProtoSerializer tail)
			: base(tail)
		{
			this.forType = forType;
			this.property = property;
			SanityCheck(model, property, tail, out readOptionsWriteValue, true, true);
			shadowSetter = GetShadowSetter(model, property);
		}

		private static void SanityCheck(TypeModel model, PropertyInfo property, IProtoSerializer tail, out bool writeValue, bool nonPublic, bool allowInternal)
		{
			if (property == (PropertyInfo)null)
			{
				throw new ArgumentNullException("property");
			}
			writeValue = (tail.ReturnsValue && (GetShadowSetter(model, property) != (MethodInfo)null || (property.CanWrite && Helpers.GetSetMethod(property, nonPublic, allowInternal) != (MethodInfo)null)));
			if (property.CanRead && !(Helpers.GetGetMethod(property, nonPublic, allowInternal) == (MethodInfo)null))
			{
				if (writeValue)
				{
					return;
				}
				if (tail.RequiresOldValue && !Helpers.IsValueType(tail.ExpectedType))
				{
					return;
				}
				throw new InvalidOperationException("Cannot apply changes to property " + property.DeclaringType.FullName + "." + property.Name);
			}
			throw new InvalidOperationException("Cannot serialize property without a get accessor");
		}

		private static MethodInfo GetShadowSetter(TypeModel model, PropertyInfo property)
		{
			MethodInfo instanceMethod = Helpers.GetInstanceMethod(property.ReflectedType, "Set" + property.Name, new Type[1]
			{
				property.PropertyType
			});
			if (!(instanceMethod == (MethodInfo)null) && instanceMethod.IsPublic && !(instanceMethod.ReturnType != model.MapType(typeof(void))))
			{
				return instanceMethod;
			}
			return null;
		}

		public override void Write(object value, ProtoWriter dest)
		{
			value = property.GetValue(value, null);
			if (value != null)
			{
				base.Tail.Write(value, dest);
			}
		}

		public override object Read(object value, ProtoReader source)
		{
			object value2 = base.Tail.RequiresOldValue ? property.GetValue(value, null) : null;
			object obj = base.Tail.Read(value2, source);
			if (readOptionsWriteValue && obj != null)
			{
				if (shadowSetter == (MethodInfo)null)
				{
					property.SetValue(value, obj, null);
				}
				else
				{
					shadowSetter.Invoke(value, new object[1]
					{
						obj
					});
				}
			}
			return null;
		}

		internal static bool CanWrite(TypeModel model, MemberInfo member)
		{
			if (member == (MemberInfo)null)
			{
				throw new ArgumentNullException("member");
			}
			PropertyInfo propertyInfo = member as PropertyInfo;
			if (propertyInfo != (PropertyInfo)null)
			{
				if (!propertyInfo.CanWrite)
				{
					return GetShadowSetter(model, propertyInfo) != (MethodInfo)null;
				}
				return true;
			}
			return member is FieldInfo;
		}
	}
}
