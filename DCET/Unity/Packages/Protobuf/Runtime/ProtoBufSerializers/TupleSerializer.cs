using ProtoBuf.Meta;
using System;
using System.Reflection;

namespace ProtoBuf.Serializers
{
	internal sealed class TupleSerializer : IProtoTypeSerializer, IProtoSerializer
	{
		private readonly MemberInfo[] members;

		private readonly ConstructorInfo ctor;

		private IProtoSerializer[] tails;

		public Type ExpectedType => ctor.DeclaringType;

		public bool RequiresOldValue => true;

		public bool ReturnsValue => false;

		public TupleSerializer(RuntimeTypeModel model, ConstructorInfo ctor, MemberInfo[] members)
		{
			if (ctor == (ConstructorInfo)null)
			{
				throw new ArgumentNullException("ctor");
			}
			if (members == null)
			{
				throw new ArgumentNullException("members");
			}
			this.ctor = ctor;
			this.members = members;
			tails = new IProtoSerializer[members.Length];
			ParameterInfo[] parameters = ctor.GetParameters();
			int num = 0;
			Type type2;
			while (true)
			{
				if (num < members.Length)
				{
					Type parameterType = parameters[num].ParameterType;
					Type type = null;
					Type concreteType = null;
					MetaType.ResolveListTypes(model, parameterType, ref type, ref concreteType);
					type2 = ((type == (Type)null) ? parameterType : type);
					bool asReference = false;
					if (model.FindOrAddAuto(type2, false, true, false) >= 0)
					{
						asReference = model[type2].AsReferenceDefault;
					}
					IProtoSerializer protoSerializer = ValueMember.TryGetCoreSerializer(model, DataFormat.Default, type2, out WireType wireType, asReference, false, false, true);
					if (protoSerializer != null)
					{
						protoSerializer = new TagDecorator(num + 1, wireType, false, protoSerializer);
						IProtoSerializer protoSerializer2 = (!(type == (Type)null)) ? ((!parameterType.IsArray) ? ((ProtoDecoratorBase)ListDecorator.Create(model, parameterType, concreteType, protoSerializer, num + 1, false, wireType, true, false, false)) : ((ProtoDecoratorBase)new ArrayDecorator(model, protoSerializer, num + 1, false, wireType, parameterType, false, false))) : protoSerializer;
						tails[num] = protoSerializer2;
						num++;
						continue;
					}
					break;
				}
				return;
			}
			throw new InvalidOperationException("No serializer defined for type: " + type2.FullName);
		}

		public bool HasCallbacks(TypeModel.CallbackType callbackType)
		{
			return false;
		}

		void IProtoTypeSerializer.Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context)
		{
		}

		object IProtoTypeSerializer.CreateInstance(ProtoReader source)
		{
			throw new NotSupportedException();
		}

		private object GetValue(object obj, int index)
		{
			PropertyInfo propertyInfo;
			if ((propertyInfo = (members[index] as PropertyInfo)) != (PropertyInfo)null)
			{
				if (obj == null)
				{
					if (!Helpers.IsValueType(propertyInfo.PropertyType))
					{
						return null;
					}
					return Activator.CreateInstance(propertyInfo.PropertyType);
				}
				return propertyInfo.GetValue(obj, null);
			}
			FieldInfo fieldInfo;
			if ((fieldInfo = (members[index] as FieldInfo)) != (FieldInfo)null)
			{
				if (obj == null)
				{
					if (!Helpers.IsValueType(fieldInfo.FieldType))
					{
						return null;
					}
					return Activator.CreateInstance(fieldInfo.FieldType);
				}
				return fieldInfo.GetValue(obj);
			}
			throw new InvalidOperationException();
		}

		public object Read(object value, ProtoReader source)
		{
			object[] array = new object[members.Length];
			bool flag = false;
			if (value == null)
			{
				flag = true;
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = GetValue(value, i);
			}
			int num;
			while ((num = source.ReadFieldHeader()) > 0)
			{
				flag = true;
				if (num <= tails.Length)
				{
					IProtoSerializer protoSerializer = tails[num - 1];
					array[num - 1] = tails[num - 1].Read(protoSerializer.RequiresOldValue ? array[num - 1] : null, source);
				}
				else
				{
					source.SkipField();
				}
			}
			if (!flag)
			{
				return value;
			}
			return ctor.Invoke(array);
		}

		public void Write(object value, ProtoWriter dest)
		{
			for (int i = 0; i < tails.Length; i++)
			{
				object value2 = GetValue(value, i);
				if (value2 != null)
				{
					tails[i].Write(value2, dest);
				}
			}
		}

		private Type GetMemberType(int index)
		{
			Type memberType = Helpers.GetMemberType(members[index]);
			if (memberType == (Type)null)
			{
				throw new InvalidOperationException();
			}
			return memberType;
		}

		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return false;
		}
	}
}
