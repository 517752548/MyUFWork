namespace BetaFramework
{
    public class Message : IMessage
    {
        public Message(short opCode) : this(opCode, new byte[0])
        {
            OpCode = opCode;
            Status = 0;
        }

        public Message(short opCode, byte[] data)
        {
            OpCode = opCode;
            Status = 0;
            SetBinary(data);
        }

        public int? ReceiverId { get; set; }

        public short OpCode { get; private set; }

        public byte[] Data { get; private set; }

        public bool HasData
        {
            get { return Data.Length > 0; }
        }

        public int? AckRequestId { get; set; }

        public int? AckResponseId { get; set; }

        public byte Flags { get; set; }

        public ResponseStatus Status { get; set; }

        public IMessage SetBinary(byte[] data)
        {
            Data = data;
            return this;
        }

        public byte[] ToBytes()
        {
            return Data;
            //var converter = EndianBitConverter.Big;
            //var flags = GenerateFlags(this);

            //var dataLength = Data.Length;
            //var isAckRequest = (flags & (byte) MessageFlag.AckRequest) > 0;
            //var isAckResponse = (flags & (byte) MessageFlag.AckResponse) > 0;

            //var packetSize = 1 // Flags
            //                 + 2 // OpCode
            //                 + 4 // Data Length
            //                 + dataLength // Data
            //                 + (isAckRequest ? 4 : 0) // Ack Request id
            //                 + (isAckResponse ? 5 : 0); // Ack Response id (int + byte);

            //var messagePacket = new byte[packetSize];

            //var pointer = 0;
            //messagePacket[0] = flags;
            //pointer++; // Write Flags
            //converter.CopyBytes(OpCode, messagePacket, pointer);
            //pointer += 2; // Write OpCode
            //converter.CopyBytes(dataLength, messagePacket, pointer);
            //pointer += 4; // Data Length
            //Array.Copy(Data, 0, messagePacket, pointer, dataLength);
            //pointer += dataLength; // Data

            //if (isAckRequest)
            //{
            //    converter.CopyBytes(AckRequestId.Value, messagePacket, pointer);
            //    pointer += 4;
            //}

            //if (isAckResponse)
            //{
            //    converter.CopyBytes(AckResponseId.Value, messagePacket, pointer);
            //    pointer += 4;

            //    // Status code
            //    messagePacket[pointer] = (byte)Status;
            //    pointer++;
            //}

            //return messagePacket;
        }

        public static byte GenerateFlags(IMessage message)
        {
            var flags = message.Flags;

            if (message.AckRequestId.HasValue)
                flags |= (byte)MessageFlag.AckRequest;

            if (message.AckResponseId.HasValue)
                flags |= (byte)MessageFlag.AckResponse;

            return flags;
        }
    }
}