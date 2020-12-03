using ProtoBuf.Meta;
using System;
using System.Reflection;

namespace ProtoBuf.Serializers
{
	internal sealed class TypeSerializer : IProtoTypeSerializer, IProtoSerializer
	{
		private readonly Type forType;

		private readonly Type constructType;

		private readonly IProtoSerializer[] serializers;

		private readonly int[] fieldNumbers;

		private readonly bool isRootType;

		private readonly bool useConstructor;

		private readonly bool isExtensible;

		private readonly bool hasConstructor;

		private readonly CallbackSet callbacks;

		private readonly MethodInfo[] baseCtorCallbacks;

		private readonly MethodInfo factory;

		private static readonly Type iextensible = typeof(IExtensible);

		public Type ExpectedType => forType;

		private bool CanHaveInheritance
		{
			get
			{
				if (!forType.IsClass && !forType.IsInterface)
				{
					return false;
				}
				return !forType.IsSealed;
			}
		}

		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return false;
			}
		}

		public bool HasCallbacks(TypeModel.CallbackType callbackType)
		{
			if (callbacks != null && callbacks[callbackType] != (MethodInfo)null)
			{
				return true;
			}
			for (int i = 0; i < serializers.Length; i++)
			{
				if (serializers[i].ExpectedType != forType && ((IProtoTypeSerializer)serializers[i]).HasCallbacks(callbackType))
				{
					return true;
				}
			}
			return false;
		}

		public TypeSerializer(TypeModel model, Type forType, int[] fieldNumbers, IProtoSerializer[] serializers, MethodInfo[] baseCtorCallbacks, bool isRootType, bool useConstructor, CallbackSet callbacks, Type constructType, MethodInfo factory)
		{
			Helpers.Sort(fieldNumbers, serializers);
			bool flag = false;
			for (int i = 1; i < fieldNumbers.Length; i++)
			{
				if (fieldNumbers[i] == fieldNumbers[i - 1])
				{
					throw new InvalidOperationException("Duplicate field-number detected; " + fieldNumbers[i].ToString() + " on: " + forType.FullName);
				}
				if (!flag && serializers[i].ExpectedType != forType)
				{
					flag = true;
				}
			}
			this.forType = forType;
			this.factory = factory;
			if (constructType == (Type)null)
			{
				constructType = forType;
			}
			else if (!forType.IsAssignableFrom(constructType))
			{
				throw new InvalidOperationException(forType.FullName + " cannot be assigned from " + constructType.FullName);
			}
			this.constructType = constructType;
			this.serializers = serializers;
			this.fieldNumbers = fieldNumbers;
			this.callbacks = callbacks;
			this.isRootType = isRootType;
			this.useConstructor = useConstructor;
			if (baseCtorCallbacks != null && baseCtorCallbacks.Length == 0)
			{
				baseCtorCallbacks = null;
			}
			this.baseCtorCallbacks = baseCtorCallbacks;
			if (Helpers.GetUnderlyingType(forType) != (Type)null)
			{
				throw new ArgumentException("Cannot create a TypeSerializer for nullable types", "forType");
			}
			if (model.MapType(iextensible).IsAssignableFrom(forType))
			{
				if ((forType.IsValueType || !isRootType) | flag)
				{
					throw new NotSupportedException("IExtensible is not supported in structs or classes with inheritance");
				}
				isExtensible = true;
			}
			hasConstructor = (!constructType.IsAbstract && Helpers.GetConstructor(constructType, Helpers.EmptyTypes, true) != (ConstructorInfo)null);
			if (!(constructType != forType & useConstructor))
			{
				return;
			}
			if (hasConstructor)
			{
				return;
			}
			throw new ArgumentException("The supplied default implementation cannot be created: " + constructType.FullName, "constructType");
		}

		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return true;
		}

		object IProtoTypeSerializer.CreateInstance(ProtoReader source)
		{
			return CreateInstance(source, false);
		}

		public void Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context)
		{
			if (callbacks != null)
			{
				InvokeCallback(callbacks[callbackType], value, context);
			}
			IProtoTypeSerializer protoTypeSerializer = (IProtoTypeSerializer)GetMoreSpecificSerializer(value);
			protoTypeSerializer?.Callback(value, callbackType, context);
		}

		private IProtoSerializer GetMoreSpecificSerializer(object value)
		{
			if (!CanHaveInheritance)
			{
				return null;
			}
			Type type = value.GetType();
			if (type == forType)
			{
				return null;
			}
			foreach (IProtoSerializer protoSerializer in serializers)
			{
				if (protoSerializer.ExpectedType != forType && Helpers.IsAssignableFrom(protoSerializer.ExpectedType, type))
				{
					return protoSerializer;
				}
			}
			if (type == constructType)
			{
				return null;
			}
			TypeModel.ThrowUnexpectedSubtype(forType, type);
			return null;
		}

		public void Write(object value, ProtoWriter dest)
		{
			if (isRootType)
			{
				Callback(value, TypeModel.CallbackType.BeforeSerialize, dest.Context);
			}
			IProtoSerializer moreSpecificSerializer = GetMoreSpecificSerializer(value);
			moreSpecificSerializer?.Write(value, dest);
			foreach (IProtoSerializer protoSerializer in serializers)
			{
				if (protoSerializer.ExpectedType == forType)
				{
					protoSerializer.Write(value, dest);
				}
			}
			if (isExtensible)
			{
				ProtoWriter.AppendExtensionData((IExtensible)value, dest);
			}
			if (isRootType)
			{
				Callback(value, TypeModel.CallbackType.AfterSerialize, dest.Context);
			}
		}

		public object Read(object value, ProtoReader source)
		{
			if (isRootType && value != null)
			{
				Callback(value, TypeModel.CallbackType.BeforeDeserialize, source.Context);
			}
			int num = 0;
			int num2 = 0;
			int num3;
			while ((num3 = source.ReadFieldHeader()) > 0)
			{
				bool flag = false;
				if (num3 < num)
				{
					num = (num2 = 0);
				}
				int num4 = num2;
				while (num4 < fieldNumbers.Length)
				{
					if (fieldNumbers[num4] != num3)
					{
						num4++;
						continue;
					}
					IProtoSerializer protoSerializer = serializers[num4];
					Type expectedType = protoSerializer.ExpectedType;
					if (value == null)
					{
						if (expectedType == forType)
						{
							value = CreateInstance(source, true);
						}
					}
					else if (expectedType != forType && ((IProtoTypeSerializer)protoSerializer).CanCreateInstance() && expectedType.IsSubclassOf(value.GetType()))
					{
						value = ProtoReader.Merge(source, value, ((IProtoTypeSerializer)protoSerializer).CreateInstance(source));
					}
					if (protoSerializer.ReturnsValue)
					{
						value = protoSerializer.Read(value, source);
					}
					else
					{
						protoSerializer.Read(value, source);
					}
					num2 = num4;
					num = num3;
					flag = true;
					break;
				}
				if (!flag)
				{
					if (value == null)
					{
						value = CreateInstance(source, true);
					}
					if (isExtensible)
					{
						source.AppendExtensionData((IExtensible)value);
					}
					else
					{
						source.SkipField();
					}
				}
			}
			if (value == null)
			{
				value = CreateInstance(source, true);
			}
			if (isRootType)
			{
				Callback(value, TypeModel.CallbackType.AfterDeserialize, source.Context);
			}
			return value;
		}

		private object InvokeCallback(MethodInfo method, object obj, SerializationContext context)
		{
			object result = null;
			if (method != (MethodInfo)null)
			{
				ParameterInfo[] parameters = method.GetParameters();
				object[] array;
				bool flag;
				if (parameters.Length == 0)
				{
					array = null;
					flag = true;
				}
				else
				{
					array = new object[parameters.Length];
					flag = true;
					for (int i = 0; i < array.Length; i++)
					{
						Type parameterType = parameters[i].ParameterType;
						object obj2;
						if (parameterType == typeof(SerializationContext))
						{
							obj2 = context;
						}
						else if (parameterType == typeof(Type))
						{
							obj2 = constructType;
						}
						else
						{
							obj2 = null;
							flag = false;
						}
						array[i] = obj2;
					}
				}
				if (flag)
				{
					result = method.Invoke(obj, array);
					goto IL_00a1;
				}
				throw CallbackSet.CreateInvalidCallbackSignature(method);
			}
			goto IL_00a1;
			IL_00a1:
			return result;
		}

		private object CreateInstance(ProtoReader source, bool includeLocalCallback)
		{
			object obj;
			if (factory != (MethodInfo)null)
			{
				obj = InvokeCallback(factory, null, source.Context);
			}
			else if (useConstructor)
			{
				if (!hasConstructor)
				{
					TypeModel.ThrowCannotCreateInstance(constructType);
				}
				obj = Activator.CreateInstance(constructType, true);
			}
			else
			{
				obj = BclHelpers.GetUninitializedObject(constructType);
			}
			ProtoReader.NoteObject(obj, source);
			if (baseCtorCallbacks != null)
			{
				for (int i = 0; i < baseCtorCallbacks.Length; i++)
				{
					InvokeCallback(baseCtorCallbacks[i], obj, source.Context);
				}
			}
			if (includeLocalCallback && callbacks != null)
			{
				InvokeCallback(callbacks.BeforeDeserialize, obj, source.Context);
			}
			return obj;
		}
	}
}
