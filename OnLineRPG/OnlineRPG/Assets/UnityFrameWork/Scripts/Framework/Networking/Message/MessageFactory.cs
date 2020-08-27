using System;

namespace BetaFramework
{
    public class MessageFactory : IMessageFactory
    {
        public IMessage Create(short opCode)
        {
            return new Message(opCode);
        }

        public IMessage Create(short opCode, byte[] data)
        {
            return new Message(opCode, data);
        }

        public IIncommingMessage FromBytes(byte[] buffer, int start, IPeer peer)
        {
            try
            {
                /************************************
                var converter = EndianBitConverter.Big;
                var flags = buffer[start];
                var opCode = converter.ToInt16(buffer, start + 1);
                var pointer = start + 3;

                var dataLength = converter.ToInt32(buffer, pointer);
                pointer += 4;
                var data = new byte[dataLength];
                Array.Copy(buffer, pointer, data, 0, dataLength);
                pointer += dataLength;

                var message = new IncommingMessage(opCode, data, peer);

                if ((flags & (byte) MessageFlag.AckRequest) > 0)
                {
                    message.AckResponseId = converter.ToInt32(buffer, pointer);
                    pointer += 4;
                }

                if ((flags & (byte) MessageFlag.AckResponse) > 0)
                {
                    var ackId = converter.ToInt32(buffer, pointer);
                    message.AckRequestId = ackId;
                    pointer += 4;

                    var statusCode = buffer[pointer];

                    message.Status = (ResponseStatus) statusCode;
                    pointer++;
                }
                *********************************************************/
                var message = new IncommingMessage(peer.OpCode, buffer, peer);
                return message;
            }
            catch (Exception e)
            {
                LoggerHelper.Error("WS Failed parsing an incoming message " + e);
            }
            return null;
        }
    }
}