using ProtoBuf.Meta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ProtoBuf
{
	internal static class ExtensibleUtil
	{
		internal static IEnumerable<TValue> GetExtendedValues<TValue>(IExtensible instance, int tag, DataFormat format, bool singleton, bool allowDefinedTag)
		{
			foreach (TValue extendedValue in GetExtendedValues(RuntimeTypeModel.Default, typeof(TValue), instance, tag, format, singleton, allowDefinedTag))
			{
				yield return extendedValue;
			}
		}

		internal static IEnumerable GetExtendedValues(TypeModel model, Type type, IExtensible instance, int tag, DataFormat format, bool singleton, bool allowDefinedTag)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (tag <= 0)
			{
				throw new ArgumentOutOfRangeException("tag");
			}
			IExtension extn = instance.GetExtensionObject(false);
			if (extn != null)
			{
				Stream stream = extn.BeginQuery();
				object obj = null;
				ProtoReader reader = null;
				try
				{
					SerializationContext context = new SerializationContext();
					reader = ProtoReader.Create(stream, model, context, -1);
					while (model.TryDeserializeAuxiliaryType(reader, format, tag, type, ref obj, true, false, false, false) && obj != null)
					{
						if (!singleton)
						{
							yield return obj;
							obj = null;
						}
					}
					if (singleton && obj != null)
					{
						yield return obj;
					}
				}
				finally
				{
					ProtoReader.Recycle(reader);
					extn.EndQuery(stream);
				}
			}
		}

		internal static void AppendExtendValue(TypeModel model, IExtensible instance, int tag, DataFormat format, object value)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			IExtension extensionObject = instance.GetExtensionObject(true);
			if (extensionObject == null)
			{
				throw new InvalidOperationException("No extension object available; appended data would be lost.");
			}
			bool commit = false;
			Stream stream = extensionObject.BeginAppend();
			try
			{
				using (ProtoWriter protoWriter = new ProtoWriter(stream, model, null))
				{
					model.TrySerializeAuxiliaryType(protoWriter, null, format, tag, value, false);
					protoWriter.Close();
				}
				commit = true;
			}
			finally
			{
				extensionObject.EndAppend(stream, commit);
			}
		}
	}
}
