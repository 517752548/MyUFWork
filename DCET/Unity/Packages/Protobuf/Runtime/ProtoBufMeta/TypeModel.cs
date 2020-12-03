using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ProtoBuf.Meta
{
	public abstract class TypeModel
	{
		private sealed class DeserializeItemsIterator<T> : DeserializeItemsIterator, IEnumerator<T>, IDisposable, IEnumerator, IEnumerable<T>, IEnumerable
		{
			public new T Current => (T)base.Current;

			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				return this;
			}

			void IDisposable.Dispose()
			{
			}

			public DeserializeItemsIterator(TypeModel model, Stream source, PrefixStyle style, int expectedField, SerializationContext context)
				: base(model, source, model.MapType(typeof(T)), style, expectedField, null, context)
			{
			}
		}

		private class DeserializeItemsIterator : IEnumerator, IEnumerable
		{
			private bool haveObject;

			private object current;

			private readonly Stream source;

			private readonly Type type;

			private readonly PrefixStyle style;

			private readonly int expectedField;

			private readonly Serializer.TypeResolver resolver;

			private readonly TypeModel model;

			private readonly SerializationContext context;

			public object Current => current;

			IEnumerator IEnumerable.GetEnumerator()
			{
				return this;
			}

			public bool MoveNext()
			{
				if (haveObject)
				{
					current = model.DeserializeWithLengthPrefix(source, null, type, style, expectedField, resolver, out int _, out haveObject, context);
				}
				return haveObject;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			public DeserializeItemsIterator(TypeModel model, Stream source, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver, SerializationContext context)
			{
				haveObject = true;
				this.source = source;
				this.type = type;
				this.style = style;
				this.expectedField = expectedField;
				this.resolver = resolver;
				this.model = model;
				this.context = context;
			}
		}

		protected internal enum CallbackType
		{
			BeforeSerialize,
			AfterSerialize,
			BeforeDeserialize,
			AfterDeserialize
		}

		private static readonly Type ilist = typeof(IList);

		public event TypeFormatEventHandler DynamicTypeFormatting;

		protected internal Type MapType(Type type)
		{
			return MapType(type, true);
		}

		protected internal virtual Type MapType(Type type, bool demand)
		{
			return type;
		}

		private WireType GetWireType(ProtoTypeCode code, DataFormat format, ref Type type, out int modelKey)
		{
			modelKey = -1;
			if (Helpers.IsEnum(type))
			{
				modelKey = GetKey(ref type);
				return WireType.Variant;
			}
			switch (code)
			{
			default:
				if ((uint)(code - 100) <= 3u)
				{
					goto case ProtoTypeCode.Decimal;
				}
				break;
			case ProtoTypeCode.Int64:
			case ProtoTypeCode.UInt64:
				if (format != DataFormat.FixedSize)
				{
					return WireType.Variant;
				}
				return WireType.Fixed64;
			case ProtoTypeCode.Boolean:
			case ProtoTypeCode.Char:
			case ProtoTypeCode.SByte:
			case ProtoTypeCode.Byte:
			case ProtoTypeCode.Int16:
			case ProtoTypeCode.UInt16:
			case ProtoTypeCode.Int32:
			case ProtoTypeCode.UInt32:
				if (format != DataFormat.FixedSize)
				{
					return WireType.Variant;
				}
				return WireType.Fixed32;
			case ProtoTypeCode.Double:
				return WireType.Fixed64;
			case ProtoTypeCode.Single:
				return WireType.Fixed32;
			case ProtoTypeCode.Decimal:
			case ProtoTypeCode.DateTime:
			case ProtoTypeCode.String:
				return WireType.String;
			case (ProtoTypeCode)17:
				break;
			}
			if ((modelKey = GetKey(ref type)) >= 0)
			{
				return WireType.String;
			}
			return WireType.None;
		}

		internal bool TrySerializeAuxiliaryType(ProtoWriter writer, Type type, DataFormat format, int tag, object value, bool isInsideList)
		{
			if (type == (Type)null)
			{
				type = value.GetType();
			}
			ProtoTypeCode typeCode = Helpers.GetTypeCode(type);
			int num;
			WireType wireType = GetWireType(typeCode, format, ref type, out num);
			if (num >= 0)
			{
				if (Helpers.IsEnum(type))
				{
					Serialize(num, value, writer);
					return true;
				}
				ProtoWriter.WriteFieldHeader(tag, wireType, writer);
				if (wireType != WireType.None)
				{
					if ((uint)(wireType - 2) <= 1u)
					{
						SubItemToken token = ProtoWriter.StartSubItem(value, writer);
						Serialize(num, value, writer);
						ProtoWriter.EndSubItem(token, writer);
						return true;
					}
					Serialize(num, value, writer);
					return true;
				}
				throw ProtoWriter.CreateException(writer);
			}
			if (wireType != WireType.None)
			{
				ProtoWriter.WriteFieldHeader(tag, wireType, writer);
			}
			switch (typeCode)
			{
			case ProtoTypeCode.Int16:
				ProtoWriter.WriteInt16((short)value, writer);
				return true;
			case ProtoTypeCode.Int32:
				ProtoWriter.WriteInt32((int)value, writer);
				return true;
			case ProtoTypeCode.Int64:
				ProtoWriter.WriteInt64((long)value, writer);
				return true;
			case ProtoTypeCode.UInt16:
				ProtoWriter.WriteUInt16((ushort)value, writer);
				return true;
			case ProtoTypeCode.UInt32:
				ProtoWriter.WriteUInt32((uint)value, writer);
				return true;
			case ProtoTypeCode.UInt64:
				ProtoWriter.WriteUInt64((ulong)value, writer);
				return true;
			case ProtoTypeCode.Boolean:
				ProtoWriter.WriteBoolean((bool)value, writer);
				return true;
			case ProtoTypeCode.SByte:
				ProtoWriter.WriteSByte((sbyte)value, writer);
				return true;
			case ProtoTypeCode.Byte:
				ProtoWriter.WriteByte((byte)value, writer);
				return true;
			case ProtoTypeCode.Char:
				ProtoWriter.WriteUInt16((char)value, writer);
				return true;
			case ProtoTypeCode.Double:
				ProtoWriter.WriteDouble((double)value, writer);
				return true;
			case ProtoTypeCode.Single:
				ProtoWriter.WriteSingle((float)value, writer);
				return true;
			case ProtoTypeCode.DateTime:
				BclHelpers.WriteDateTime((DateTime)value, writer);
				return true;
			case ProtoTypeCode.Decimal:
				BclHelpers.WriteDecimal((decimal)value, writer);
				return true;
			case ProtoTypeCode.String:
				ProtoWriter.WriteString((string)value, writer);
				return true;
			case ProtoTypeCode.ByteArray:
				ProtoWriter.WriteBytes((byte[])value, writer);
				return true;
			case ProtoTypeCode.TimeSpan:
				BclHelpers.WriteTimeSpan((TimeSpan)value, writer);
				return true;
			case ProtoTypeCode.Guid:
				BclHelpers.WriteGuid((Guid)value, writer);
				return true;
			case ProtoTypeCode.Uri:
				ProtoWriter.WriteString(((Uri)value).AbsoluteUri, writer);
				return true;
			default:
			{
				IEnumerable enumerable = value as IEnumerable;
				if (enumerable != null)
				{
					if (isInsideList)
					{
						throw CreateNestedListsNotSupported();
					}
					foreach (object item in enumerable)
					{
						if (item == null)
						{
							throw new NullReferenceException();
						}
						if (!TrySerializeAuxiliaryType(writer, null, format, tag, item, true))
						{
							ThrowUnexpectedType(item.GetType());
						}
					}
					return true;
				}
				return false;
			}
			}
		}

		private void SerializeCore(ProtoWriter writer, object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			Type type = value.GetType();
			int key = GetKey(ref type);
			if (key >= 0)
			{
				Serialize(key, value, writer);
			}
			else if (!TrySerializeAuxiliaryType(writer, type, DataFormat.Default, 1, value, false))
			{
				ThrowUnexpectedType(type);
			}
		}

		public void Serialize(Stream dest, object value)
		{
			Serialize(dest, value, null);
		}

		public void Serialize(Stream dest, object value, SerializationContext context)
		{
			using (ProtoWriter protoWriter = new ProtoWriter(dest, this, context))
			{
				protoWriter.SetRootObject(value);
				SerializeCore(protoWriter, value);
				protoWriter.Close();
			}
		}

		public void Serialize(ProtoWriter dest, object value)
		{
			if (dest == null)
			{
				throw new ArgumentNullException("dest");
			}
			dest.CheckDepthFlushlock();
			dest.SetRootObject(value);
			SerializeCore(dest, value);
			dest.CheckDepthFlushlock();
			ProtoWriter.Flush(dest);
		}

		public object DeserializeWithLengthPrefix(Stream source, object value, Type type, PrefixStyle style, int fieldNumber)
		{
			int num;
			return DeserializeWithLengthPrefix(source, value, type, style, fieldNumber, null, out num);
		}

		public object DeserializeWithLengthPrefix(Stream source, object value, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver)
		{
			int num;
			return DeserializeWithLengthPrefix(source, value, type, style, expectedField, resolver, out num);
		}

		public object DeserializeWithLengthPrefix(Stream source, object value, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver, out int bytesRead)
		{
			bool flag;
			return DeserializeWithLengthPrefix(source, value, type, style, expectedField, resolver, out bytesRead, out flag, null);
		}

		private object DeserializeWithLengthPrefix(Stream source, object value, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver, out int bytesRead, out bool haveObject, SerializationContext context)
		{
			haveObject = false;
			bytesRead = 0;
			if (type == (Type)null && (style != PrefixStyle.Base128 || resolver == null))
			{
				throw new InvalidOperationException("A type must be provided unless base-128 prefixing is being used in combination with a resolver");
			}
			int num3;
			bool flag2;
			do
			{
				bool flag = expectedField > 0 || resolver != null;
				num3 = ProtoReader.ReadLengthPrefix(source, flag, style, out int num, out int num2);
				if (num2 == 0)
				{
					return value;
				}
				bytesRead += num2;
				if (num3 < 0)
				{
					return value;
				}
				if (style == PrefixStyle.Base128)
				{
					if (flag && expectedField == 0 && type == (Type)null && resolver != null)
					{
						type = resolver(num);
						flag2 = (type == (Type)null);
					}
					else
					{
						flag2 = (expectedField != num);
					}
				}
				else
				{
					flag2 = false;
				}
				if (flag2)
				{
					if (num3 == 2147483647)
					{
						throw new InvalidOperationException();
					}
					ProtoReader.Seek(source, num3, null);
					bytesRead += num3;
				}
			}
			while (flag2);
			ProtoReader protoReader = null;
			try
			{
				protoReader = ProtoReader.Create(source, this, context, num3);
				int key = GetKey(ref type);
				if (key >= 0 && !Helpers.IsEnum(type))
				{
					value = Deserialize(key, value, protoReader);
				}
				else if (!TryDeserializeAuxiliaryType(protoReader, DataFormat.Default, 1, type, ref value, true, false, true, false) && num3 != 0)
				{
					ThrowUnexpectedType(type);
				}
				bytesRead += protoReader.Position;
				haveObject = true;
				return value;
			}
			finally
			{
				ProtoReader.Recycle(protoReader);
			}
		}

		public IEnumerable DeserializeItems(Stream source, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver)
		{
			return DeserializeItems(source, type, style, expectedField, resolver, null);
		}

		public IEnumerable DeserializeItems(Stream source, Type type, PrefixStyle style, int expectedField, Serializer.TypeResolver resolver, SerializationContext context)
		{
			return new DeserializeItemsIterator(this, source, type, style, expectedField, resolver, context);
		}

		public IEnumerable<T> DeserializeItems<T>(Stream source, PrefixStyle style, int expectedField)
		{
			return DeserializeItems<T>(source, style, expectedField, null);
		}

		public IEnumerable<T> DeserializeItems<T>(Stream source, PrefixStyle style, int expectedField, SerializationContext context)
		{
			return new DeserializeItemsIterator<T>(this, source, style, expectedField, context);
		}

		public void SerializeWithLengthPrefix(Stream dest, object value, Type type, PrefixStyle style, int fieldNumber)
		{
			SerializeWithLengthPrefix(dest, value, type, style, fieldNumber, null);
		}

		public void SerializeWithLengthPrefix(Stream dest, object value, Type type, PrefixStyle style, int fieldNumber, SerializationContext context)
		{
			if (type == (Type)null)
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				type = MapType(value.GetType());
			}
			int key = GetKey(ref type);
			using (ProtoWriter protoWriter = new ProtoWriter(dest, this, context))
			{
				if (style != 0)
				{
					if ((uint)(style - 1) <= 2u)
					{
						ProtoWriter.WriteObject(value, key, protoWriter, style, fieldNumber);
						goto IL_0069;
					}
					throw new ArgumentOutOfRangeException("style");
				}
				Serialize(key, value, protoWriter);
				goto IL_0069;
				IL_0069:
				protoWriter.Close();
			}
		}

		public object Deserialize(Stream source, object value, Type type)
		{
			return Deserialize(source, value, type, null);
		}

		public object Deserialize(Stream source, object value, Type type, SerializationContext context)
		{
			bool noAutoCreate = PrepareDeserialize(value, ref type);
			ProtoReader protoReader = null;
			try
			{
				protoReader = ProtoReader.Create(source, this, context, -1);
				if (value != null)
				{
					protoReader.SetRootObject(value);
				}
				object result = DeserializeCore(protoReader, type, value, noAutoCreate);
				protoReader.CheckFullyConsumed();
				return result;
			}
			finally
			{
				ProtoReader.Recycle(protoReader);
			}
		}

		private bool PrepareDeserialize(object value, ref Type type)
		{
			if (type == (Type)null)
			{
				if (value == null)
				{
					throw new ArgumentNullException("type");
				}
				type = MapType(value.GetType());
			}
			bool result = true;
			Type underlyingType = Helpers.GetUnderlyingType(type);
			if (underlyingType != (Type)null)
			{
				type = underlyingType;
				result = false;
			}
			return result;
		}

		public object Deserialize(Stream source, object value, Type type, int length)
		{
			return Deserialize(source, value, type, length, null);
		}

		public object Deserialize(Stream source, object value, Type type, int length, SerializationContext context)
		{
			bool noAutoCreate = PrepareDeserialize(value, ref type);
			ProtoReader protoReader = null;
			try
			{
				protoReader = ProtoReader.Create(source, this, context, length);
				if (value != null)
				{
					protoReader.SetRootObject(value);
				}
				object result = DeserializeCore(protoReader, type, value, noAutoCreate);
				protoReader.CheckFullyConsumed();
				return result;
			}
			finally
			{
				ProtoReader.Recycle(protoReader);
			}
		}

		public object Deserialize(ProtoReader source, object value, Type type)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			bool noAutoCreate = PrepareDeserialize(value, ref type);
			if (value != null)
			{
				source.SetRootObject(value);
			}
			object result = DeserializeCore(source, type, value, noAutoCreate);
			source.CheckFullyConsumed();
			return result;
		}

		private object DeserializeCore(ProtoReader reader, Type type, object value, bool noAutoCreate)
		{
			int key = GetKey(ref type);
			if (key >= 0 && !Helpers.IsEnum(type))
			{
				return Deserialize(key, value, reader);
			}
			TryDeserializeAuxiliaryType(reader, DataFormat.Default, 1, type, ref value, true, false, noAutoCreate, false);
			return value;
		}

		internal static MethodInfo ResolveListAdd(TypeModel model, Type listType, Type itemType, out bool isList)
		{
			isList = model.MapType(ilist).IsAssignableFrom(listType);
			Type[] array = new Type[1]
			{
				itemType
			};
			MethodInfo instanceMethod = Helpers.GetInstanceMethod(listType, "Add", array);
			if (instanceMethod == (MethodInfo)null)
			{
				bool num = listType.IsInterface && listType == model.MapType(typeof(IEnumerable<>)).MakeGenericType(array);
				Type type = model.MapType(typeof(ICollection<>)).MakeGenericType(array);
				if (num || type.IsAssignableFrom(listType))
				{
					instanceMethod = Helpers.GetInstanceMethod(type, "Add", array);
				}
			}
			if (instanceMethod == (MethodInfo)null)
			{
				Type[] interfaces = listType.GetInterfaces();
				foreach (Type type2 in interfaces)
				{
					if (type2.Name == "IProducerConsumerCollection`1" && type2.IsGenericType && type2.GetGenericTypeDefinition().FullName == "System.Collections.Concurrent.IProducerConsumerCollection`1")
					{
						instanceMethod = Helpers.GetInstanceMethod(type2, "TryAdd", array);
						if (instanceMethod != (MethodInfo)null)
						{
							break;
						}
					}
				}
			}
			if (instanceMethod == (MethodInfo)null)
			{
				array[0] = model.MapType(typeof(object));
				instanceMethod = Helpers.GetInstanceMethod(listType, "Add", array);
			}
			if (instanceMethod == (MethodInfo)null & isList)
			{
				instanceMethod = Helpers.GetInstanceMethod(model.MapType(ilist), "Add", array);
			}
			return instanceMethod;
		}

		internal static Type GetListItemType(TypeModel model, Type listType)
		{
			if (!(listType == model.MapType(typeof(string))) && !listType.IsArray && model.MapType(typeof(IEnumerable)).IsAssignableFrom(listType))
			{
				BasicList basicList = new BasicList();
				MethodInfo[] methods = listType.GetMethods();
				foreach (MethodInfo methodInfo in methods)
				{
					if (!methodInfo.IsStatic && !(methodInfo.Name != "Add"))
					{
						ParameterInfo[] parameters = methodInfo.GetParameters();
						Type parameterType;
						if (parameters.Length == 1 && !basicList.Contains(parameterType = parameters[0].ParameterType))
						{
							basicList.Add(parameterType);
						}
					}
				}
				string name = listType.Name;
				if (name == null || (name.IndexOf("Queue") < 0 && name.IndexOf("Stack") < 0))
				{
					TestEnumerableListPatterns(model, basicList, listType);
					Type[] interfaces = listType.GetInterfaces();
					foreach (Type iType in interfaces)
					{
						TestEnumerableListPatterns(model, basicList, iType);
					}
				}
				PropertyInfo[] properties = listType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (!(propertyInfo.Name != "Item") && !basicList.Contains(propertyInfo.PropertyType))
					{
						ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
						if (indexParameters.Length == 1 && !(indexParameters[0].ParameterType != model.MapType(typeof(int))))
						{
							basicList.Add(propertyInfo.PropertyType);
						}
					}
				}
				switch (basicList.Count)
				{
				case 0:
					return null;
				case 1:
					return (Type)basicList[0];
				case 2:
					if (CheckDictionaryAccessors(model, (Type)basicList[0], (Type)basicList[1]))
					{
						return (Type)basicList[0];
					}
					if (!CheckDictionaryAccessors(model, (Type)basicList[1], (Type)basicList[0]))
					{
						break;
					}
					return (Type)basicList[1];
				}
				return null;
			}
			return null;
		}

		private static void TestEnumerableListPatterns(TypeModel model, BasicList candidates, Type iType)
		{
			if (iType.IsGenericType)
			{
				Type genericTypeDefinition = iType.GetGenericTypeDefinition();
				if (!(genericTypeDefinition == model.MapType(typeof(IEnumerable<>))) && !(genericTypeDefinition == model.MapType(typeof(ICollection<>))) && !(genericTypeDefinition.FullName == "System.Collections.Concurrent.IProducerConsumerCollection`1"))
				{
					return;
				}
				Type[] genericArguments = iType.GetGenericArguments();
				if (!candidates.Contains(genericArguments[0]))
				{
					candidates.Add(genericArguments[0]);
				}
			}
		}

		private static bool CheckDictionaryAccessors(TypeModel model, Type pair, Type value)
		{
			if (pair.IsGenericType && pair.GetGenericTypeDefinition() == model.MapType(typeof(KeyValuePair<, >)))
			{
				return pair.GetGenericArguments()[1] == value;
			}
			return false;
		}

		private bool TryDeserializeList(TypeModel model, ProtoReader reader, DataFormat format, int tag, Type listType, Type itemType, ref object value)
		{
			bool flag;
			MethodInfo methodInfo = ResolveListAdd(model, listType, itemType, out flag);
			if (methodInfo == (MethodInfo)null)
			{
				throw new NotSupportedException("Unknown list variant: " + listType.FullName);
			}
			bool result = false;
			object obj = null;
			IList list = value as IList;
			object[] array = flag ? null : new object[1];
			BasicList basicList = listType.IsArray ? new BasicList() : null;
			while (TryDeserializeAuxiliaryType(reader, format, tag, itemType, ref obj, true, true, true, true))
			{
				result = true;
				if (value == null && basicList == null)
				{
					value = CreateListInstance(listType, itemType);
					list = (value as IList);
				}
				if (list != null)
				{
					list.Add(obj);
				}
				else if (basicList != null)
				{
					basicList.Add(obj);
				}
				else
				{
					array[0] = obj;
					methodInfo.Invoke(value, array);
				}
				obj = null;
			}
			if (basicList != null)
			{
				if (value != null)
				{
					if (basicList.Count != 0)
					{
						Array array2 = (Array)value;
						Array array3 = Array.CreateInstance(itemType, array2.Length + basicList.Count);
						Array.Copy(array2, array3, array2.Length);
						basicList.CopyTo(array3, array2.Length);
						value = array3;
					}
				}
				else
				{
					Array array3 = Array.CreateInstance(itemType, basicList.Count);
					basicList.CopyTo(array3, 0);
					value = array3;
				}
			}
			return result;
		}

		private static object CreateListInstance(Type listType, Type itemType)
		{
			Type type = listType;
			if (listType.IsArray)
			{
				return Array.CreateInstance(itemType, 0);
			}
			if (!listType.IsClass || listType.IsAbstract || Helpers.GetConstructor(listType, Helpers.EmptyTypes, true) == (ConstructorInfo)null)
			{
				bool flag = false;
				string fullName;
				if (listType.IsInterface && (fullName = listType.FullName) != null && fullName.IndexOf("Dictionary") >= 0)
				{
					if (listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof(IDictionary<, >))
					{
						Type[] genericArguments = listType.GetGenericArguments();
						type = typeof(Dictionary<, >).MakeGenericType(genericArguments);
						flag = true;
					}
					if (!flag && listType == typeof(IDictionary))
					{
						type = typeof(Hashtable);
						flag = true;
					}
				}
				if (!flag)
				{
					type = typeof(List<>).MakeGenericType(itemType);
					flag = true;
				}
				if (!flag)
				{
					type = typeof(ArrayList);
					flag = true;
				}
			}
			return Activator.CreateInstance(type);
		}

		internal bool TryDeserializeAuxiliaryType(ProtoReader reader, DataFormat format, int tag, Type type, ref object value, bool skipOtherFields, bool asListItem, bool autoCreate, bool insideList)
		{
			if (type == (Type)null)
			{
				throw new ArgumentNullException("type");
			}
			Type type2 = null;
			ProtoTypeCode typeCode = Helpers.GetTypeCode(type);
			int num;
			WireType wireType = GetWireType(typeCode, format, ref type, out num);
			bool flag = false;
			if (wireType == WireType.None)
			{
				type2 = GetListItemType(this, type);
				if (type2 == (Type)null && type.IsArray && type.GetArrayRank() == 1 && type != typeof(byte[]))
				{
					type2 = type.GetElementType();
				}
				if (type2 != (Type)null)
				{
					if (insideList)
					{
						throw CreateNestedListsNotSupported();
					}
					flag = TryDeserializeList(this, reader, format, tag, type, type2, ref value);
					if (!flag & autoCreate)
					{
						value = CreateListInstance(type, type2);
					}
					return flag;
				}
				ThrowUnexpectedType(type);
			}
			while (true)
			{
				if (flag & asListItem)
				{
					break;
				}
				int num2 = reader.ReadFieldHeader();
				if (num2 <= 0)
				{
					break;
				}
				if (num2 != tag)
				{
					if (skipOtherFields)
					{
						reader.SkipField();
						continue;
					}
					throw ProtoReader.AddErrorData(new InvalidOperationException("Expected field " + tag.ToString() + ", but found " + num2.ToString()), reader);
				}
				flag = true;
				reader.Hint(wireType);
				if (num >= 0)
				{
					if ((uint)(wireType - 2) <= 1u)
					{
						SubItemToken token = ProtoReader.StartSubItem(reader);
						value = Deserialize(num, value, reader);
						ProtoReader.EndSubItem(token, reader);
					}
					else
					{
						value = Deserialize(num, value, reader);
					}
				}
				else
				{
					switch (typeCode)
					{
					case ProtoTypeCode.Int16:
						value = reader.ReadInt16();
						break;
					case ProtoTypeCode.Int32:
						value = reader.ReadInt32();
						break;
					case ProtoTypeCode.Int64:
						value = reader.ReadInt64();
						break;
					case ProtoTypeCode.UInt16:
						value = reader.ReadUInt16();
						break;
					case ProtoTypeCode.UInt32:
						value = reader.ReadUInt32();
						break;
					case ProtoTypeCode.UInt64:
						value = reader.ReadUInt64();
						break;
					case ProtoTypeCode.Boolean:
						value = reader.ReadBoolean();
						break;
					case ProtoTypeCode.SByte:
						value = reader.ReadSByte();
						break;
					case ProtoTypeCode.Byte:
						value = reader.ReadByte();
						break;
					case ProtoTypeCode.Char:
						value = (char)reader.ReadUInt16();
						break;
					case ProtoTypeCode.Double:
						value = reader.ReadDouble();
						break;
					case ProtoTypeCode.Single:
						value = reader.ReadSingle();
						break;
					case ProtoTypeCode.DateTime:
						value = BclHelpers.ReadDateTime(reader);
						break;
					case ProtoTypeCode.Decimal:
						value = BclHelpers.ReadDecimal(reader);
						break;
					case ProtoTypeCode.String:
						value = reader.ReadString();
						break;
					case ProtoTypeCode.ByteArray:
						value = ProtoReader.AppendBytes((byte[])value, reader);
						break;
					case ProtoTypeCode.TimeSpan:
						value = BclHelpers.ReadTimeSpan(reader);
						break;
					case ProtoTypeCode.Guid:
						value = BclHelpers.ReadGuid(reader);
						break;
					case ProtoTypeCode.Uri:
						value = new Uri(reader.ReadString());
						break;
					}
				}
			}
			if (((!flag && !asListItem) & autoCreate) && type != typeof(string))
			{
				value = Activator.CreateInstance(type);
			}
			return flag;
		}

		public static RuntimeTypeModel Create()
		{
			return new RuntimeTypeModel(false);
		}

		protected internal static Type ResolveProxies(Type type)
		{
			if (type == (Type)null)
			{
				return null;
			}
			if (type.IsGenericParameter)
			{
				return null;
			}
			Type underlyingType = Helpers.GetUnderlyingType(type);
			if (underlyingType != (Type)null)
			{
				return underlyingType;
			}
			string fullName = type.FullName;
			if (fullName != null && fullName.StartsWith("System.Data.Entity.DynamicProxies."))
			{
				return type.BaseType;
			}
			Type[] interfaces = type.GetInterfaces();
			for (int i = 0; i < interfaces.Length; i++)
			{
				switch (interfaces[i].FullName)
				{
				case "NHibernate.Proxy.INHibernateProxy":
				case "NHibernate.Proxy.DynamicProxy.IProxy":
				case "NHibernate.Intercept.IFieldInterceptorAccessor":
					return type.BaseType;
				}
			}
			return null;
		}

		public bool IsDefined(Type type)
		{
			return GetKey(ref type) >= 0;
		}

		protected internal int GetKey(ref Type type)
		{
			if (type == (Type)null)
			{
				return -1;
			}
			int keyImpl = GetKeyImpl(type);
			if (keyImpl < 0)
			{
				Type type2 = ResolveProxies(type);
				if (type2 != (Type)null)
				{
					type = type2;
					keyImpl = GetKeyImpl(type);
				}
			}
			return keyImpl;
		}

		protected abstract int GetKeyImpl(Type type);

		protected internal abstract void Serialize(int key, object value, ProtoWriter dest);

		protected internal abstract object Deserialize(int key, object value, ProtoReader source);

		public object DeepClone(object value)
		{
			if (value == null)
			{
				return null;
			}
			Type type = value.GetType();
			int key = GetKey(ref type);
			if (key >= 0 && !Helpers.IsEnum(type))
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (ProtoWriter protoWriter = new ProtoWriter(memoryStream, this, null))
					{
						protoWriter.SetRootObject(value);
						Serialize(key, value, protoWriter);
						protoWriter.Close();
					}
					memoryStream.Position = 0L;
					ProtoReader protoReader = null;
					try
					{
						protoReader = ProtoReader.Create(memoryStream, this, null, -1);
						return Deserialize(key, null, protoReader);
					}
					finally
					{
						ProtoReader.Recycle(protoReader);
					}
				}
			}
			if (type == typeof(byte[]))
			{
				byte[] array = (byte[])value;
				byte[] array2 = new byte[array.Length];
				Helpers.BlockCopy(array, 0, array2, 0, array.Length);
				return array2;
			}
			if (GetWireType(Helpers.GetTypeCode(type), DataFormat.Default, ref type, out int num) != WireType.None && num < 0)
			{
				return value;
			}
			using (MemoryStream memoryStream2 = new MemoryStream())
			{
				using (ProtoWriter protoWriter2 = new ProtoWriter(memoryStream2, this, null))
				{
					if (!TrySerializeAuxiliaryType(protoWriter2, type, DataFormat.Default, 1, value, false))
					{
						ThrowUnexpectedType(type);
					}
					protoWriter2.Close();
				}
				memoryStream2.Position = 0L;
				ProtoReader reader = null;
				try
				{
					reader = ProtoReader.Create(memoryStream2, this, null, -1);
					value = null;
					TryDeserializeAuxiliaryType(reader, DataFormat.Default, 1, type, ref value, true, false, true, false);
					return value;
				}
				finally
				{
					ProtoReader.Recycle(reader);
				}
			}
		}

		protected internal static void ThrowUnexpectedSubtype(Type expected, Type actual)
		{
			if (!(expected != ResolveProxies(actual)))
			{
				return;
			}
			throw new InvalidOperationException("Unexpected sub-type: " + actual.FullName);
		}

		protected internal static void ThrowUnexpectedType(Type type)
		{
			string str = (type == (Type)null) ? "(unknown)" : type.FullName;
			if (type != (Type)null)
			{
				Type baseType = type.BaseType;
				if (baseType != (Type)null && baseType.IsGenericType && baseType.GetGenericTypeDefinition().Name == "GeneratedMessage`2")
				{
					throw new InvalidOperationException("Are you mixing protobuf-net and protobuf-csharp-port? See http://stackoverflow.com/q/11564914; type: " + str);
				}
			}
			throw new InvalidOperationException("Type is not expected, and no contract can be inferred: " + str);
		}

		internal static Exception CreateNestedListsNotSupported()
		{
			return new NotSupportedException("Nested or jagged lists and arrays are not supported");
		}

		public static void ThrowCannotCreateInstance(Type type)
		{
			throw new ProtoException("No parameterless constructor found for " + ((type == (Type)null) ? "(null)" : type.Name));
		}

		internal static string SerializeType(TypeModel model, Type type)
		{
			if (model != null)
			{
				TypeFormatEventHandler dynamicTypeFormatting = model.DynamicTypeFormatting;
				if (dynamicTypeFormatting != null)
				{
					TypeFormatEventArgs typeFormatEventArgs = new TypeFormatEventArgs(type);
					dynamicTypeFormatting(model, typeFormatEventArgs);
					if (!Helpers.IsNullOrEmpty(typeFormatEventArgs.FormattedName))
					{
						return typeFormatEventArgs.FormattedName;
					}
				}
			}
			return type.AssemblyQualifiedName;
		}

		internal static Type DeserializeType(TypeModel model, string value)
		{
			if (model != null)
			{
				TypeFormatEventHandler dynamicTypeFormatting = model.DynamicTypeFormatting;
				if (dynamicTypeFormatting != null)
				{
					TypeFormatEventArgs typeFormatEventArgs = new TypeFormatEventArgs(value);
					dynamicTypeFormatting(model, typeFormatEventArgs);
					if (typeFormatEventArgs.Type != (Type)null)
					{
						return typeFormatEventArgs.Type;
					}
				}
			}
			return Type.GetType(value);
		}

		public bool CanSerializeContractType(Type type)
		{
			return CanSerialize(type, false, true, true);
		}

		public bool CanSerialize(Type type)
		{
			return CanSerialize(type, true, true, true);
		}

		public bool CanSerializeBasicType(Type type)
		{
			return CanSerialize(type, true, false, true);
		}

		private bool CanSerialize(Type type, bool allowBasic, bool allowContract, bool allowLists)
		{
			if (type == (Type)null)
			{
				throw new ArgumentNullException("type");
			}
			Type underlyingType = Helpers.GetUnderlyingType(type);
			if (underlyingType != (Type)null)
			{
				type = underlyingType;
			}
			ProtoTypeCode typeCode = Helpers.GetTypeCode(type);
			if ((uint)typeCode > 1u)
			{
				return allowBasic;
			}
			if (GetKey(ref type) >= 0)
			{
				return allowContract;
			}
			if (allowLists)
			{
				Type type2 = null;
				if (type.IsArray)
				{
					if (type.GetArrayRank() == 1)
					{
						type2 = type.GetElementType();
					}
				}
				else
				{
					type2 = GetListItemType(this, type);
				}
				if (type2 != (Type)null)
				{
					return CanSerialize(type2, allowBasic, allowContract, false);
				}
			}
			return false;
		}

		public virtual string GetSchema(Type type)
		{
			throw new NotSupportedException();
		}

		internal virtual Type GetType(string fullName, Assembly context)
		{
			return ResolveKnownType(fullName, this, context);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Type ResolveKnownType(string name, TypeModel model, Assembly assembly)
		{
			if (Helpers.IsNullOrEmpty(name))
			{
				return null;
			}
			try
			{
				Type type = Type.GetType(name);
				if (type != (Type)null)
				{
					return type;
				}
			}
			catch
			{
			}
			try
			{
				int num = name.IndexOf(',');
				string name2 = ((num > 0) ? name.Substring(0, num) : name).Trim();
				if (assembly == (Assembly)null)
				{
					assembly = Assembly.GetCallingAssembly();
				}
				Type type2 = (assembly == (Assembly)null) ? null : assembly.GetType(name2);
				if (type2 != (Type)null)
				{
					return type2;
				}
			}
			catch
			{
			}
			return null;
		}
	}
}
