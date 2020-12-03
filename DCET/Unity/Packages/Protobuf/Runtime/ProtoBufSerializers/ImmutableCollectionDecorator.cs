using ProtoBuf.Meta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableCollectionDecorator : ListDecorator
	{
		private readonly MethodInfo builderFactory;

		private readonly MethodInfo add;

		private readonly MethodInfo addRange;

		private readonly MethodInfo finish;

		protected override bool RequireAdd => false;

		private static Type ResolveIReadOnlyCollection(Type declaredType, Type t)
		{
			Type[] interfaces = declaredType.GetInterfaces();
			foreach (Type type in interfaces)
			{
				if (type.IsGenericType && type.Name.StartsWith("IReadOnlyCollection`"))
				{
					if (t != (Type)null)
					{
						Type[] genericArguments = type.GetGenericArguments();
						if (genericArguments.Length != 1 && genericArguments[0] != t)
						{
							continue;
						}
					}
					return type;
				}
			}
			return null;
		}

		internal static bool IdentifyImmutable(TypeModel model, Type declaredType, out MethodInfo builderFactory, out MethodInfo add, out MethodInfo addRange, out MethodInfo finish)
		{
			builderFactory = (add = (addRange = (finish = null)));
			if (model != null && !(declaredType == (Type)null))
			{
				if (!declaredType.IsGenericType)
				{
					return false;
				}
				Type[] genericArguments = declaredType.GetGenericArguments();
				Type[] array;
				switch (genericArguments.LongLength)
				{
				case 1L:
					array = genericArguments;
					break;
				case 2L:
				{
					Type type = model.MapType(typeof(KeyValuePair<, >));
					if (type == (Type)null)
					{
						return false;
					}
					type = type.MakeGenericType(genericArguments);
					array = new Type[1]
					{
						type
					};
					break;
				}
				default:
					return false;
				}
				if (ResolveIReadOnlyCollection(declaredType, null) == (Type)null)
				{
					return false;
				}
				string name = declaredType.Name;
				int num = name.IndexOf('`');
				if (num <= 0)
				{
					return false;
				}
				name = (declaredType.IsInterface ? name.Substring(1, num - 1) : name.Substring(0, num));
				Type type2 = model.GetType(declaredType.Namespace + "." + name, declaredType.Assembly);
				if (type2 == (Type)null && name == "ImmutableSet")
				{
					type2 = model.GetType(declaredType.Namespace + ".ImmutableHashSet", declaredType.Assembly);
				}
				if (type2 == (Type)null)
				{
					return false;
				}
				MethodInfo[] methods = type2.GetMethods();
				foreach (MethodInfo methodInfo in methods)
				{
					if (methodInfo.IsStatic && !(methodInfo.Name != "CreateBuilder") && methodInfo.IsGenericMethodDefinition && methodInfo.GetParameters().Length == 0 && methodInfo.GetGenericArguments().Length == genericArguments.Length)
					{
						builderFactory = methodInfo.MakeGenericMethod(genericArguments);
						break;
					}
				}
				Type right = model.MapType(typeof(void));
				if (!(builderFactory == (MethodInfo)null) && !(builderFactory.ReturnType == (Type)null) && !(builderFactory.ReturnType == right))
				{
					add = Helpers.GetInstanceMethod(builderFactory.ReturnType, "Add", array);
					if (add == (MethodInfo)null)
					{
						return false;
					}
					finish = Helpers.GetInstanceMethod(builderFactory.ReturnType, "ToImmutable", Helpers.EmptyTypes);
					if (!(finish == (MethodInfo)null) && !(finish.ReturnType == (Type)null) && !(finish.ReturnType == right))
					{
						if (!(finish.ReturnType == declaredType) && !Helpers.IsAssignableFrom(declaredType, finish.ReturnType))
						{
							return false;
						}
						addRange = Helpers.GetInstanceMethod(builderFactory.ReturnType, "AddRange", new Type[1]
						{
							declaredType
						});
						if (addRange == (MethodInfo)null)
						{
							Type type3 = model.MapType(typeof(IEnumerable<>), false);
							if (type3 != (Type)null)
							{
								addRange = Helpers.GetInstanceMethod(builderFactory.ReturnType, "AddRange", new Type[1]
								{
									type3.MakeGenericType(array)
								});
							}
						}
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		internal ImmutableCollectionDecorator(TypeModel model, Type declaredType, Type concreteType, IProtoSerializer tail, int fieldNumber, bool writePacked, WireType packedWireType, bool returnList, bool overwriteList, bool supportNull, MethodInfo builderFactory, MethodInfo add, MethodInfo addRange, MethodInfo finish)
			: base(model, declaredType, concreteType, tail, fieldNumber, writePacked, packedWireType, returnList, overwriteList, supportNull)
		{
			this.builderFactory = builderFactory;
			this.add = add;
			this.addRange = addRange;
			this.finish = finish;
		}

		public override object Read(object value, ProtoReader source)
		{
			object obj = builderFactory.Invoke(null, null);
			int fieldNumber = source.FieldNumber;
			object[] array = new object[1];
			if (base.AppendToCollection && value != null && ((IList)value).Count != 0)
			{
				if (addRange != (MethodInfo)null)
				{
					array[0] = value;
					addRange.Invoke(obj, array);
				}
				else
				{
					foreach (object item in (IList)value)
					{
						object obj2 = array[0] = item;
						add.Invoke(obj, array);
					}
				}
			}
			if (base.packedWireType != WireType.None && source.WireType == WireType.String)
			{
				SubItemToken token = ProtoReader.StartSubItem(source);
				while (ProtoReader.HasSubValue(base.packedWireType, source))
				{
					array[0] = base.Tail.Read(null, source);
					add.Invoke(obj, array);
				}
				ProtoReader.EndSubItem(token, source);
			}
			else
			{
				do
				{
					array[0] = base.Tail.Read(null, source);
					add.Invoke(obj, array);
				}
				while (source.TryReadFieldHeader(fieldNumber));
			}
			return finish.Invoke(obj, null);
		}
	}
}
