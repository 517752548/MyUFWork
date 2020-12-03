using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProtoBuf
{
	public sealed class ProtoReader : IDisposable
	{
		private Stream source;

		private byte[] ioBuffer;

		private TypeModel model;

		private int fieldNumber;

		private int depth;

		private int dataRemaining;

		private int ioIndex;

		private int position;

		private int available;

		private int blockEnd;

		private WireType wireType;

		private bool isFixedLength;

		private bool internStrings;

		private NetObjectCache netCache;

		private uint trapCount;

		internal const int TO_EOF = -1;

		private SerializationContext context;

		private const long Int64Msb = long.MinValue;

		private const int Int32Msb = int.MinValue;

		private Dictionary<string, string> stringInterner;

		private static readonly UTF8Encoding encoding = new UTF8Encoding();

		private static readonly byte[] EmptyBlob = new byte[0];

		[ThreadStatic]
		private static ProtoReader lastReader;

		public int FieldNumber => fieldNumber;

		public WireType WireType => wireType;

		public bool InternStrings
		{
			get
			{
				return internStrings;
			}
			set
			{
				internStrings = value;
			}
		}

		public SerializationContext Context => context;

		public int Position => position;

		public TypeModel Model => model;

		internal NetObjectCache NetCache => netCache;

		public ProtoReader(Stream source, TypeModel model, SerializationContext context)
		{
			Init(this, source, model, context, -1);
		}

		public ProtoReader(Stream source, TypeModel model, SerializationContext context, int length)
		{
			Init(this, source, model, context, length);
		}

		private static void Init(ProtoReader reader, Stream source, TypeModel model, SerializationContext context, int length)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (!source.CanRead)
			{
				throw new ArgumentException("Cannot read from stream", "source");
			}
			reader.source = source;
			reader.ioBuffer = BufferPool.GetBuffer();
			reader.model = model;
			reader.dataRemaining = ((reader.isFixedLength = (length >= 0)) ? length : 0);
			if (context == null)
			{
				context = SerializationContext.Default;
			}
			else
			{
				context.Freeze();
			}
			reader.context = context;
			reader.position = (reader.available = (reader.depth = (reader.fieldNumber = (reader.ioIndex = 0))));
			reader.blockEnd = 2147483647;
			reader.internStrings = true;
			reader.wireType = WireType.None;
			reader.trapCount = 1u;
			if (reader.netCache == null)
			{
				reader.netCache = new NetObjectCache();
			}
		}

		public void Dispose()
		{
			source = null;
			model = null;
			BufferPool.ReleaseBufferToPool(ref ioBuffer);
			if (stringInterner != null)
			{
				stringInterner.Clear();
			}
			if (netCache != null)
			{
				netCache.Clear();
			}
		}

		internal int TryReadUInt32VariantWithoutMoving(bool trimNegative, out uint value)
		{
			if (available < 10)
			{
				Ensure(10, false);
			}
			if (available == 0)
			{
				value = 0u;
				return 0;
			}
			int num = ioIndex;
			value = ioBuffer[num++];
			if ((value & 0x80) == 0)
			{
				return 1;
			}
			value &= 127u;
			if (available == 1)
			{
				throw EoF(this);
			}
			uint num4 = ioBuffer[num++];
			value |= (num4 & 0x7F) << 7;
			if ((num4 & 0x80) == 0)
			{
				return 2;
			}
			if (available == 2)
			{
				throw EoF(this);
			}
			num4 = ioBuffer[num++];
			value |= (num4 & 0x7F) << 14;
			if ((num4 & 0x80) == 0)
			{
				return 3;
			}
			if (available == 3)
			{
				throw EoF(this);
			}
			num4 = ioBuffer[num++];
			value |= (num4 & 0x7F) << 21;
			if ((num4 & 0x80) == 0)
			{
				return 4;
			}
			if (available == 4)
			{
				throw EoF(this);
			}
			num4 = ioBuffer[num];
			value |= num4 << 28;
			if ((num4 & 0xF0) == 0)
			{
				return 5;
			}
			if (trimNegative && (num4 & 0xF0) == 240 && available >= 10 && ioBuffer[++num] == 255 && ioBuffer[++num] == 255 && ioBuffer[++num] == 255 && ioBuffer[++num] == 255 && ioBuffer[++num] == 1)
			{
				return 10;
			}
			throw AddErrorData(new OverflowException(), this);
		}

		private uint ReadUInt32Variant(bool trimNegative)
		{
			uint result;
			int num = TryReadUInt32VariantWithoutMoving(trimNegative, out result);
			if (num > 0)
			{
				ioIndex += num;
				available -= num;
				position += num;
				return result;
			}
			throw EoF(this);
		}

		private bool TryReadUInt32Variant(out uint value)
		{
			int num = TryReadUInt32VariantWithoutMoving(false, out value);
			if (num > 0)
			{
				ioIndex += num;
				available -= num;
				position += num;
				return true;
			}
			return false;
		}

		public uint ReadUInt32()
		{
			switch (wireType)
			{
			case WireType.Variant:
				return ReadUInt32Variant(false);
			case WireType.Fixed32:
			{
				if (available < 4)
				{
					Ensure(4, true);
				}
				position += 4;
				available -= 4;
				uint num = ioBuffer[ioIndex];
				uint num2 = ioBuffer[ioIndex + 1];
				uint num3 = ioBuffer[ioIndex + 2];
				byte num4 = ioBuffer[ioIndex + 3];
				uint num5 = num;
				uint num6 = num2 << 8;
				uint num7 = num3 << 16;
				uint num8 = (uint)(num4 << 24);
				ioIndex += 4;
				return num5 | num6 | num7 | num8;
			}
			case WireType.Fixed64:
				return checked((uint)ReadUInt64());
			default:
				throw CreateWireTypeException();
			}
		}

		internal void Ensure(int count, bool strict)
		{
			if (count > ioBuffer.Length)
			{
				BufferPool.ResizeAndFlushLeft(ref ioBuffer, count, ioIndex, available);
				ioIndex = 0;
			}
			else if (ioIndex + count >= ioBuffer.Length)
			{
				Helpers.BlockCopy(ioBuffer, ioIndex, ioBuffer, 0, available);
				ioIndex = 0;
			}
			count -= available;
			int num = ioIndex + available;
			int num2 = ioBuffer.Length - num;
			if (isFixedLength && dataRemaining < num2)
			{
				num2 = dataRemaining;
			}
			int num3;
			while (count > 0 && num2 > 0 && (num3 = source.Read(ioBuffer, num, num2)) > 0)
			{
				available += num3;
				count -= num3;
				num2 -= num3;
				num += num3;
				if (isFixedLength)
				{
					dataRemaining -= num3;
				}
			}
			if (!strict)
			{
				return;
			}
			if (count <= 0)
			{
				return;
			}
			throw EoF(this);
		}

		public short ReadInt16()
		{
			return checked((short)ReadInt32());
		}

		public ushort ReadUInt16()
		{
			return checked((ushort)ReadUInt32());
		}

		public byte ReadByte()
		{
			return checked((byte)ReadUInt32());
		}

		public sbyte ReadSByte()
		{
			return checked((sbyte)ReadInt32());
		}

		public int ReadInt32()
		{
			switch (wireType)
			{
			case WireType.Variant:
				return (int)ReadUInt32Variant(true);
			case WireType.Fixed32:
			{
				if (available < 4)
				{
					Ensure(4, true);
				}
				position += 4;
				available -= 4;
				int num = ioBuffer[ioIndex];
				int num2 = ioBuffer[ioIndex + 1];
				int num3 = ioBuffer[ioIndex + 2];
				byte num4 = ioBuffer[ioIndex + 3];
				int num5 = num;
				int num6 = num2 << 8;
				int num7 = num3 << 16;
				int num8 = num4 << 24;
				ioIndex += 4;
				return num5 | num6 | num7 | num8;
			}
			case WireType.Fixed64:
				return checked((int)ReadInt64());
			case WireType.SignedVariant:
				return Zag(ReadUInt32Variant(true));
			default:
				throw CreateWireTypeException();
			}
		}

		private static int Zag(uint ziggedValue)
		{
			return (int)(0 - (ziggedValue & 1)) ^ ((int)ziggedValue >> 1 & 0x7FFFFFFF);
		}

		private static long Zag(ulong ziggedValue)
		{
			return (long)(0L - (ziggedValue & 1)) ^ ((long)ziggedValue >> 1 & 0x7FFFFFFFFFFFFFFF);
		}

		public long ReadInt64()
		{
			switch (wireType)
			{
			case WireType.Variant:
				return (long)ReadUInt64Variant();
			case WireType.Fixed32:
				return ReadInt32();
			case WireType.Fixed64:
			{
				if (available < 8)
				{
					Ensure(8, true);
				}
				position += 8;
				available -= 8;
				long num = ioBuffer[ioIndex];
				long num2 = ioBuffer[ioIndex + 1];
				long num3 = ioBuffer[ioIndex + 2];
				long num4 = ioBuffer[ioIndex + 3];
				long num5 = ioBuffer[ioIndex + 4];
				long num6 = ioBuffer[ioIndex + 5];
				long num7 = ioBuffer[ioIndex + 6];
				long num8 = ioBuffer[ioIndex + 7];
				long num9 = num;
				long num10 = num2 << 8;
				long num11 = num3 << 16;
				long num12 = num4 << 24;
				long num13 = num5 << 32;
				long num14 = num6 << 40;
				long num15 = num7 << 48;
				long num16 = num8 << 56;
				ioIndex += 8;
				return num9 | num10 | num11 | num12 | num13 | num14 | num15 | num16;
			}
			case WireType.SignedVariant:
				return Zag(ReadUInt64Variant());
			default:
				throw CreateWireTypeException();
			}
		}

		private int TryReadUInt64VariantWithoutMoving(out ulong value)
		{
			if (available < 10)
			{
				Ensure(10, false);
			}
			if (available == 0)
			{
				value = 0uL;
				return 0;
			}
			int num = ioIndex;
			value = ioBuffer[num++];
			if ((value & 0x80) == 0L)
			{
				return 1;
			}
			value &= 127uL;
			if (available == 1)
			{
				throw EoF(this);
			}
			ulong num4 = ioBuffer[num++];
			value |= (num4 & 0x7F) << 7;
			if ((num4 & 0x80) == 0L)
			{
				return 2;
			}
			if (available == 2)
			{
				throw EoF(this);
			}
			num4 = ioBuffer[num++];
			value |= (num4 & 0x7F) << 14;
			if ((num4 & 0x80) == 0L)
			{
				return 3;
			}
			if (available == 3)
			{
				throw EoF(this);
			}
			num4 = ioBuffer[num++];
			value |= (num4 & 0x7F) << 21;
			if ((num4 & 0x80) == 0L)
			{
				return 4;
			}
			if (available == 4)
			{
				throw EoF(this);
			}
			num4 = ioBuffer[num++];
			value |= (num4 & 0x7F) << 28;
			if ((num4 & 0x80) == 0L)
			{
				return 5;
			}
			if (available == 5)
			{
				throw EoF(this);
			}
			num4 = ioBuffer[num++];
			value |= (num4 & 0x7F) << 35;
			if ((num4 & 0x80) == 0L)
			{
				return 6;
			}
			if (available == 6)
			{
				throw EoF(this);
			}
			num4 = ioBuffer[num++];
			value |= (num4 & 0x7F) << 42;
			if ((num4 & 0x80) == 0L)
			{
				return 7;
			}
			if (available == 7)
			{
				throw EoF(this);
			}
			num4 = ioBuffer[num++];
			value |= (num4 & 0x7F) << 49;
			if ((num4 & 0x80) == 0L)
			{
				return 8;
			}
			if (available == 8)
			{
				throw EoF(this);
			}
			num4 = ioBuffer[num++];
			value |= (num4 & 0x7F) << 56;
			if ((num4 & 0x80) == 0L)
			{
				return 9;
			}
			if (available == 9)
			{
				throw EoF(this);
			}
			num4 = ioBuffer[num];
			value |= num4 << 63;
			if (((long)num4 & -2L) != 0L)
			{
				throw AddErrorData(new OverflowException(), this);
			}
			return 10;
		}

		private ulong ReadUInt64Variant()
		{
			ulong result;
			int num = TryReadUInt64VariantWithoutMoving(out result);
			if (num > 0)
			{
				ioIndex += num;
				available -= num;
				position += num;
				return result;
			}
			throw EoF(this);
		}

		private string Intern(string value)
		{
			if (value == null)
			{
				return null;
			}
			if (value.Length == 0)
			{
				return "";
			}
			string text;
			if (stringInterner == null)
			{
				stringInterner = new Dictionary<string, string>();
				stringInterner.Add(value, value);
			}
			else if (stringInterner.TryGetValue(value, out text))
			{
				value = text;
			}
			else
			{
				stringInterner.Add(value, value);
			}
			return value;
		}

		public string ReadString()
		{
			if (wireType == WireType.String)
			{
				int num = (int)ReadUInt32Variant(false);
				if (num == 0)
				{
					return "";
				}
				if (available < num)
				{
					Ensure(num, true);
				}
				string text = encoding.GetString(ioBuffer, ioIndex, num);
				if (internStrings)
				{
					text = Intern(text);
				}
				available -= num;
				position += num;
				ioIndex += num;
				return text;
			}
			throw CreateWireTypeException();
		}

		public void ThrowEnumException(Type type, int value)
		{
			string str = (type == (Type)null) ? "<null>" : type.FullName;
			throw AddErrorData(new ProtoException("No " + str + " enum is mapped to the wire-value " + value.ToString()), this);
		}

		private Exception CreateWireTypeException()
		{
			return CreateException("Invalid wire-type; this usually means you have over-written a file without truncating or setting the length; see http://stackoverflow.com/q/2152978/23354");
		}

		private Exception CreateException(string message)
		{
			return AddErrorData(new ProtoException(message), this);
		}

		public unsafe double ReadDouble()
		{
			switch (wireType)
			{
			case WireType.Fixed32:
				return (double)ReadSingle();
			case WireType.Fixed64:
			{
				long num = ReadInt64();
				return *(double*)(&num);
			}
			default:
				throw CreateWireTypeException();
			}
		}

		public static object ReadObject(object value, int key, ProtoReader reader)
		{
			return ReadTypedObject(value, key, reader, null);
		}

		internal static object ReadTypedObject(object value, int key, ProtoReader reader, Type type)
		{
			if (reader.model == null)
			{
				throw AddErrorData(new InvalidOperationException("Cannot deserialize sub-objects unless a model is provided"), reader);
			}
			SubItemToken token = StartSubItem(reader);
			if (key >= 0)
			{
				value = reader.model.Deserialize(key, value, reader);
			}
			else if (!(type != (Type)null) || !reader.model.TryDeserializeAuxiliaryType(reader, DataFormat.Default, 1, type, ref value, true, false, true, false))
			{
				TypeModel.ThrowUnexpectedType(type);
			}
			EndSubItem(token, reader);
			return value;
		}

		public static void EndSubItem(SubItemToken token, ProtoReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			int value = token.value;
			WireType wireType = reader.wireType;
			if (wireType == WireType.EndGroup)
			{
				if (value >= 0)
				{
					throw AddErrorData(new ArgumentException("token"), reader);
				}
				if (-value != reader.fieldNumber)
				{
					throw reader.CreateException("Wrong group was ended");
				}
				reader.wireType = WireType.None;
				reader.depth--;
			}
			else
			{
				if (value < reader.position)
				{
					throw reader.CreateException("Sub-message not read entirely");
				}
				if (reader.blockEnd != reader.position && reader.blockEnd != 2147483647)
				{
					throw reader.CreateException("Sub-message not read correctly");
				}
				reader.blockEnd = value;
				reader.depth--;
			}
		}

		public static SubItemToken StartSubItem(ProtoReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			switch (reader.wireType)
			{
			case WireType.StartGroup:
				reader.wireType = WireType.None;
				reader.depth++;
				return new SubItemToken(-reader.fieldNumber);
			case WireType.String:
			{
				int num = (int)reader.ReadUInt32Variant(false);
				if (num < 0)
				{
					throw AddErrorData(new InvalidOperationException(), reader);
				}
				int value = reader.blockEnd;
				reader.blockEnd = reader.position + num;
				reader.depth++;
				return new SubItemToken(value);
			}
			default:
				throw reader.CreateWireTypeException();
			}
		}

		public int ReadFieldHeader()
		{
			if (blockEnd > position && wireType != WireType.EndGroup)
			{
				if (TryReadUInt32Variant(out uint num))
				{
					wireType = (WireType)(num & 7);
					fieldNumber = (int)(num >> 3);
					if (fieldNumber < 1)
					{
						throw new ProtoException("Invalid field in source data: " + fieldNumber.ToString() + "  " + num.ToString());
					}
				}
				else
				{
					wireType = WireType.None;
					fieldNumber = 0;
				}
				if (wireType == WireType.EndGroup)
				{
					if (depth > 0)
					{
						return 0;
					}
					throw new ProtoException("Unexpected end-group in source data; this usually means the source data is corrupt");
				}
				return fieldNumber;
			}
			return 0;
		}

		public bool TryReadFieldHeader(int field)
		{
			if (blockEnd > position && this.wireType != WireType.EndGroup)
			{
				uint num;
				int num2 = TryReadUInt32VariantWithoutMoving(false, out num);
				WireType wireType;
				if (num2 > 0 && (int)num >> 3 == field && (wireType = (WireType)(num & 7)) != WireType.EndGroup)
				{
					this.wireType = wireType;
					fieldNumber = field;
					position += num2;
					ioIndex += num2;
					available -= num2;
					return true;
				}
				return false;
			}
			return false;
		}

		public void Hint(WireType wireType)
		{
			if (this.wireType != wireType && (wireType & (WireType)7) == this.wireType)
			{
				this.wireType = wireType;
			}
		}

		public void Assert(WireType wireType)
		{
			if (this.wireType == wireType)
			{
				return;
			}
			if ((wireType & (WireType)7) == this.wireType)
			{
				this.wireType = wireType;
				return;
			}
			throw CreateWireTypeException();
		}

		public void SkipField()
		{
			switch (wireType)
			{
			case WireType.Fixed32:
				if (available < 4)
				{
					Ensure(4, true);
				}
				available -= 4;
				ioIndex += 4;
				position += 4;
				break;
			case WireType.Fixed64:
				if (available < 8)
				{
					Ensure(8, true);
				}
				available -= 8;
				ioIndex += 8;
				position += 8;
				break;
			case WireType.String:
			{
				int num2 = (int)ReadUInt32Variant(false);
				if (num2 <= available)
				{
					available -= num2;
					ioIndex += num2;
					position += num2;
				}
				else
				{
					position += num2;
					num2 -= available;
					ioIndex = (available = 0);
					if (isFixedLength)
					{
						if (num2 > dataRemaining)
						{
							throw EoF(this);
						}
						dataRemaining -= num2;
					}
					Seek(source, num2, ioBuffer);
				}
				break;
			}
			case WireType.Variant:
			case WireType.SignedVariant:
				ReadUInt64Variant();
				break;
			case WireType.StartGroup:
			{
				int num = fieldNumber;
				depth++;
				while (ReadFieldHeader() > 0)
				{
					SkipField();
				}
				depth--;
				if (wireType == WireType.EndGroup && fieldNumber == num)
				{
					wireType = WireType.None;
					break;
				}
				throw CreateWireTypeException();
			}
			default:
				throw CreateWireTypeException();
			}
		}

		public ulong ReadUInt64()
		{
			switch (wireType)
			{
			case WireType.Variant:
				return ReadUInt64Variant();
			case WireType.Fixed32:
				return ReadUInt32();
			case WireType.Fixed64:
			{
				if (available < 8)
				{
					Ensure(8, true);
				}
				position += 8;
				available -= 8;
				ulong num = ioBuffer[ioIndex];
				ulong num2 = ioBuffer[ioIndex + 1];
				ulong num3 = ioBuffer[ioIndex + 2];
				ulong num4 = ioBuffer[ioIndex + 3];
				ulong num5 = ioBuffer[ioIndex + 4];
				ulong num6 = ioBuffer[ioIndex + 5];
				ulong num7 = ioBuffer[ioIndex + 6];
				long num8 = ioBuffer[ioIndex + 7];
				ulong num9 = num;
				ulong num10 = num2 << 8;
				ulong num11 = num3 << 16;
				ulong num12 = num4 << 24;
				ulong num13 = num5 << 32;
				ulong num14 = num6 << 40;
				ulong num15 = num7 << 48;
				ulong num16 = (ulong)(num8 << 56);
				ioIndex += 8;
				return num9 | num10 | num11 | num12 | num13 | num14 | num15 | num16;
			}
			default:
				throw CreateWireTypeException();
			}
		}

		public unsafe float ReadSingle()
		{
			switch (wireType)
			{
			case WireType.Fixed32:
			{
				int num3 = ReadInt32();
				return *(float*)(&num3);
			}
			case WireType.Fixed64:
			{
				double num = ReadDouble();
				float num2 = (float)num;
				if (Helpers.IsInfinity(num2) && !Helpers.IsInfinity(num))
				{
					throw AddErrorData(new OverflowException(), this);
				}
				return num2;
			}
			default:
				throw CreateWireTypeException();
			}
		}

		public bool ReadBoolean()
		{
			switch (ReadUInt32())
			{
			case 0u:
				return false;
			case 1u:
				return true;
			default:
				throw CreateException("Unexpected boolean value");
			}
		}

		public static byte[] AppendBytes(byte[] value, ProtoReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			WireType wireType = reader.wireType;
			if (wireType == WireType.String)
			{
				int num = (int)reader.ReadUInt32Variant(false);
				reader.wireType = WireType.None;
				if (num == 0)
				{
					if (value != null)
					{
						return value;
					}
					return EmptyBlob;
				}
				int num2;
				if (value == null || value.Length == 0)
				{
					num2 = 0;
					value = new byte[num];
				}
				else
				{
					num2 = value.Length;
					byte[] array = new byte[value.Length + num];
					Helpers.BlockCopy(value, 0, array, 0, value.Length);
					value = array;
				}
				reader.position += num;
				while (num > reader.available)
				{
					if (reader.available > 0)
					{
						Helpers.BlockCopy(reader.ioBuffer, reader.ioIndex, value, num2, reader.available);
						num -= reader.available;
						num2 += reader.available;
						reader.ioIndex = (reader.available = 0);
					}
					int num3 = (num > reader.ioBuffer.Length) ? reader.ioBuffer.Length : num;
					if (num3 > 0)
					{
						reader.Ensure(num3, true);
					}
				}
				if (num > 0)
				{
					Helpers.BlockCopy(reader.ioBuffer, reader.ioIndex, value, num2, num);
					reader.ioIndex += num;
					reader.available -= num;
				}
				return value;
			}
			throw reader.CreateWireTypeException();
		}

		private static int ReadByteOrThrow(Stream source)
		{
			int num = source.ReadByte();
			if (num < 0)
			{
				throw EoF(null);
			}
			return num;
		}

		public static int ReadLengthPrefix(Stream source, bool expectHeader, PrefixStyle style, out int fieldNumber)
		{
			int num;
			return ReadLengthPrefix(source, expectHeader, style, out fieldNumber, out num);
		}

		public static int DirectReadLittleEndianInt32(Stream source)
		{
			return ReadByteOrThrow(source) | ReadByteOrThrow(source) << 8 | ReadByteOrThrow(source) << 16 | ReadByteOrThrow(source) << 24;
		}

		public static int DirectReadBigEndianInt32(Stream source)
		{
			return ReadByteOrThrow(source) << 24 | ReadByteOrThrow(source) << 16 | ReadByteOrThrow(source) << 8 | ReadByteOrThrow(source);
		}

		public static int DirectReadVarintInt32(Stream source)
		{
			if (TryReadUInt32Variant(source, out uint result) <= 0)
			{
				throw EoF(null);
			}
			return (int)result;
		}

		public static void DirectReadBytes(Stream source, byte[] buffer, int offset, int count)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			int num;
			while (count > 0 && (num = source.Read(buffer, offset, count)) > 0)
			{
				count -= num;
				offset += num;
			}
			if (count <= 0)
			{
				return;
			}
			throw EoF(null);
		}

		public static byte[] DirectReadBytes(Stream source, int count)
		{
			byte[] array = new byte[count];
			DirectReadBytes(source, array, 0, count);
			return array;
		}

		public static string DirectReadString(Stream source, int length)
		{
			byte[] array = new byte[length];
			DirectReadBytes(source, array, 0, length);
			return Encoding.UTF8.GetString(array, 0, length);
		}

		public static int ReadLengthPrefix(Stream source, bool expectHeader, PrefixStyle style, out int fieldNumber, out int bytesRead)
		{
			fieldNumber = 0;
			switch (style)
			{
			case PrefixStyle.None:
				bytesRead = 0;
				return 2147483647;
			case PrefixStyle.Base128:
			{
				bytesRead = 0;
				uint num2;
				int num3;
				if (expectHeader)
				{
					num3 = TryReadUInt32Variant(source, out num2);
					bytesRead += num3;
					if (num3 > 0)
					{
						if ((num2 & 7) != 2)
						{
							throw new InvalidOperationException();
						}
						fieldNumber = (int)(num2 >> 3);
						num3 = TryReadUInt32Variant(source, out num2);
						bytesRead += num3;
						if (bytesRead == 0)
						{
							throw EoF(null);
						}
						return (int)num2;
					}
					bytesRead = 0;
					return -1;
				}
				num3 = TryReadUInt32Variant(source, out num2);
				bytesRead += num3;
				if (bytesRead >= 0)
				{
					return (int)num2;
				}
				return -1;
			}
			case PrefixStyle.Fixed32:
			{
				int num4 = source.ReadByte();
				if (num4 < 0)
				{
					bytesRead = 0;
					return -1;
				}
				bytesRead = 4;
				return num4 | ReadByteOrThrow(source) << 8 | ReadByteOrThrow(source) << 16 | ReadByteOrThrow(source) << 24;
			}
			case PrefixStyle.Fixed32BigEndian:
			{
				int num = source.ReadByte();
				if (num < 0)
				{
					bytesRead = 0;
					return -1;
				}
				bytesRead = 4;
				return num << 24 | ReadByteOrThrow(source) << 16 | ReadByteOrThrow(source) << 8 | ReadByteOrThrow(source);
			}
			default:
				throw new ArgumentOutOfRangeException("style");
			}
		}

		private static int TryReadUInt32Variant(Stream source, out uint value)
		{
			value = 0u;
			int num = source.ReadByte();
			if (num < 0)
			{
				return 0;
			}
			value = (uint)num;
			if ((value & 0x80) == 0)
			{
				return 1;
			}
			value &= 127u;
			num = source.ReadByte();
			if (num < 0)
			{
				throw EoF(null);
			}
			value |= (uint)((num & 0x7F) << 7);
			if ((num & 0x80) == 0)
			{
				return 2;
			}
			num = source.ReadByte();
			if (num < 0)
			{
				throw EoF(null);
			}
			value |= (uint)((num & 0x7F) << 14);
			if ((num & 0x80) == 0)
			{
				return 3;
			}
			num = source.ReadByte();
			if (num < 0)
			{
				throw EoF(null);
			}
			value |= (uint)((num & 0x7F) << 21);
			if ((num & 0x80) == 0)
			{
				return 4;
			}
			num = source.ReadByte();
			if (num < 0)
			{
				throw EoF(null);
			}
			value |= (uint)(num << 28);
			if ((num & 0xF0) == 0)
			{
				return 5;
			}
			throw new OverflowException();
		}

		internal static void Seek(Stream source, int count, byte[] buffer)
		{
			if (source.CanSeek)
			{
				source.Seek(count, SeekOrigin.Current);
				count = 0;
			}
			else if (buffer != null)
			{
				int num;
				while (count > buffer.Length && (num = source.Read(buffer, 0, buffer.Length)) > 0)
				{
					count -= num;
				}
				while (count > 0 && (num = source.Read(buffer, 0, count)) > 0)
				{
					count -= num;
				}
			}
			else
			{
				buffer = BufferPool.GetBuffer();
				try
				{
					int num2;
					while (count > buffer.Length && (num2 = source.Read(buffer, 0, buffer.Length)) > 0)
					{
						count -= num2;
					}
					while (count > 0 && (num2 = source.Read(buffer, 0, count)) > 0)
					{
						count -= num2;
					}
				}
				finally
				{
					BufferPool.ReleaseBufferToPool(ref buffer);
				}
			}
			if (count <= 0)
			{
				return;
			}
			throw EoF(null);
		}

		internal static Exception AddErrorData(Exception exception, ProtoReader source)
		{
			if (exception != null && source != null && !exception.Data.Contains("protoSource"))
			{
				exception.Data.Add("protoSource", $"tag={source.fieldNumber}; wire-type={source.wireType}; offset={source.position}; depth={source.depth}");
			}
			return exception;
		}

		private static Exception EoF(ProtoReader source)
		{
			return AddErrorData(new EndOfStreamException(), source);
		}

		public void AppendExtensionData(IExtensible instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			IExtension extensionObject = instance.GetExtensionObject(true);
			bool commit = false;
			Stream stream = extensionObject.BeginAppend();
			try
			{
				using (ProtoWriter protoWriter = new ProtoWriter(stream, model, null))
				{
					AppendExtensionField(protoWriter);
					protoWriter.Close();
				}
				commit = true;
			}
			finally
			{
				extensionObject.EndAppend(stream, commit);
			}
		}

		private void AppendExtensionField(ProtoWriter writer)
		{
			ProtoWriter.WriteFieldHeader(fieldNumber, wireType, writer);
			switch (wireType)
			{
			case WireType.Fixed32:
				ProtoWriter.WriteInt32(ReadInt32(), writer);
				break;
			case WireType.Variant:
			case WireType.Fixed64:
			case WireType.SignedVariant:
				ProtoWriter.WriteInt64(ReadInt64(), writer);
				break;
			case WireType.String:
				ProtoWriter.WriteBytes(AppendBytes(null, this), writer);
				break;
			case WireType.StartGroup:
			{
				SubItemToken token = StartSubItem(this);
				SubItemToken token2 = ProtoWriter.StartSubItem(null, writer);
				while (ReadFieldHeader() > 0)
				{
					AppendExtensionField(writer);
				}
				EndSubItem(token, this);
				ProtoWriter.EndSubItem(token2, writer);
				break;
			}
			default:
				throw CreateWireTypeException();
			}
		}

		public static bool HasSubValue(WireType wireType, ProtoReader source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (source.blockEnd > source.position && wireType != WireType.EndGroup)
			{
				source.wireType = wireType;
				return true;
			}
			return false;
		}

		internal int GetTypeKey(ref Type type)
		{
			return model.GetKey(ref type);
		}

		internal Type DeserializeType(string value)
		{
			return TypeModel.DeserializeType(model, value);
		}

		internal void SetRootObject(object value)
		{
			netCache.SetKeyedObject(0, value);
			trapCount -= 1u;
		}

		public static void NoteObject(object value, ProtoReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (reader.trapCount != 0)
			{
				reader.netCache.RegisterTrappedObject(value);
				reader.trapCount -= 1u;
			}
		}

		public Type ReadType()
		{
			return TypeModel.DeserializeType(model, ReadString());
		}

		internal void TrapNextObject(int newObjectKey)
		{
			trapCount += 1u;
			netCache.SetKeyedObject(newObjectKey, null);
		}

		internal void CheckFullyConsumed()
		{
			if (isFixedLength)
			{
				if (dataRemaining == 0)
				{
					return;
				}
				throw new ProtoException("Incorrect number of bytes consumed");
			}
			if (available == 0)
			{
				return;
			}
			throw new ProtoException("Unconsumed data left in the buffer; this suggests corrupt input");
		}

		public static object Merge(ProtoReader parent, object from, object to)
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}
			TypeModel typeModel = parent.Model;
			SerializationContext serializationContext = parent.Context;
			if (typeModel == null)
			{
				throw new InvalidOperationException("Types cannot be merged unless a type-model has been specified");
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				typeModel.Serialize(memoryStream, from, serializationContext);
				memoryStream.Position = 0L;
				return typeModel.Deserialize(memoryStream, to, null);
			}
		}

		internal static ProtoReader Create(Stream source, TypeModel model, SerializationContext context, int len)
		{
			ProtoReader recycled = GetRecycled();
			if (recycled == null)
			{
				return new ProtoReader(source, model, context, len);
			}
			Init(recycled, source, model, context, len);
			return recycled;
		}

		private static ProtoReader GetRecycled()
		{
			ProtoReader result = lastReader;
			lastReader = null;
			return result;
		}

		internal static void Recycle(ProtoReader reader)
		{
			if (reader != null)
			{
				reader.Dispose();
				lastReader = reader;
			}
		}
	}
}
