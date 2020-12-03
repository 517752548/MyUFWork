using ProtoBuf.Meta;
using System;
using System.Reflection;

namespace ProtoBuf.Serializers
{
	internal sealed class ParseableSerializer : IProtoSerializer
	{
		private readonly MethodInfo parse;

		public Type ExpectedType => parse.DeclaringType;

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

		public static ParseableSerializer TryCreate(Type type, TypeModel model)
		{
			if (type == (Type)null)
			{
				throw new ArgumentNullException("type");
			}
			MethodInfo method = type.GetMethod("Parse", BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public, null, new Type[1]
			{
				model.MapType(typeof(string))
			}, null);
			if (method != (MethodInfo)null && method.ReturnType == type)
			{
				if (Helpers.IsValueType(type))
				{
					MethodInfo customToString = GetCustomToString(type);
					if (!(customToString == (MethodInfo)null) && !(customToString.ReturnType != model.MapType(typeof(string))))
					{
						goto IL_008b;
					}
					return null;
				}
				goto IL_008b;
			}
			return null;
			IL_008b:
			return new ParseableSerializer(method);
		}

		private static MethodInfo GetCustomToString(Type type)
		{
			return type.GetMethod("ToString", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public, null, Helpers.EmptyTypes, null);
		}

		private ParseableSerializer(MethodInfo parse)
		{
			this.parse = parse;
		}

		public object Read(object value, ProtoReader source)
		{
			return parse.Invoke(null, new object[1]
			{
				source.ReadString()
			});
		}

		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteString(value.ToString(), dest);
		}
	}
}
