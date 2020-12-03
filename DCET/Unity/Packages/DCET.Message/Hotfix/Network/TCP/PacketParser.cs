using DCETRuntime;
using System;
using System.IO;

namespace DCET
{
	public enum ParserState
	{
		PacketSize,
		PacketBody
	}
	
	public static class Packet
	{
		public const int PacketSizeLength2 = 2;
		public const int PacketSizeLength4 = 4;
		public const int MinPacketSize = 2;
		public const int OpcodeIndex = 0;
		public const int MessageIndex = 2;
	}

	public class PacketParser
	{
		private readonly CircularBuffer buffer;
		private int packetSize;
		private ParserState state;
		public MemoryStream memoryStream;
		private bool isOK;
		private readonly int packetSizeLength;

		public PacketParser(int packetSizeLength, CircularBuffer buffer, MemoryStream memoryStream)
		{
			this.packetSizeLength = packetSizeLength;
			this.buffer = buffer;
			this.memoryStream = memoryStream;
		}

		public bool Parse()
		{
			if (this.isOK)
			{
				return true;
			}

			bool finish = false;
			while (!finish)
			{
				switch (this.state)
				{
					case ParserState.PacketSize:
						if (this.buffer.Length < this.packetSizeLength)
						{
							finish = true;
						}
						else
						{
							this.buffer.ReadMemoryStream(this.memoryStream, 0, this.packetSizeLength);
							
							switch (this.packetSizeLength)
							{
								case Packet.PacketSizeLength4:
									this.packetSize = this.memoryStream.ToInt32(0);
									if (this.packetSize > ushort.MaxValue * 16 || this.packetSize < Packet.MinPacketSize)
									{
										throw new Exception($"recv packet size error, 可能是外网探测端口: {this.packetSize}");
									}
									break;
								case Packet.PacketSizeLength2:
									this.packetSize = this.memoryStream.ToUInt16(0);
									if (this.packetSize > ushort.MaxValue || this.packetSize < Packet.MinPacketSize)
									{
										throw new Exception($"recv packet size error:, 可能是外网探测端口: {this.packetSize}");
									}
									break;
								default:
									throw new Exception("packet size byte count must be 2 or 4!");
							}
							this.state = ParserState.PacketBody;
						}
						break;
					case ParserState.PacketBody:
						if (this.buffer.Length < this.packetSize)
						{
							finish = true;
						}
						else
						{
							this.buffer.ReadMemoryStream(memoryStream, 0, this.packetSize);
							this.isOK = true;
							this.state = ParserState.PacketSize;
							finish = true;
						}
						break;
				}
			}
			return this.isOK;
		}

		public MemoryStream GetPacket()
		{
			this.isOK = false;
			return this.memoryStream;
		}
	}
}