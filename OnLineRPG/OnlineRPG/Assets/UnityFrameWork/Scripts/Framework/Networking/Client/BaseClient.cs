namespace BetaFramework
{
    public class BaseClient : IClient
    {
        public void SendMessage(short opCode)
        {
            var msg = MessageHelper.Create(opCode);
            SendMessage(msg);
        }

        public void SendMessage(short opCode, ISerializablePacket packet)
        {
            var msg = MessageHelper.Create(opCode, packet.ToBytes());
            SendMessage(msg);
        }

        public void SendMessage(short opCode, ISerializablePacket packet, ResponseCallback responseCallback)
        {
            var msg = MessageHelper.Create(opCode, packet.ToBytes());
            SendMessage(msg, responseCallback);
        }

        public void SendMessage(short opCode, ISerializablePacket packet, ResponseCallback responseCallback, int timeoutSecs)
        {
            var msg = MessageHelper.Create(opCode, packet.ToBytes());
            SendMessage(msg, responseCallback, timeoutSecs);
        }

        public void SendMessage(short opCode, ResponseCallback responseCallback)
        {
            var msg = MessageHelper.Create(opCode);
            SendMessage(msg, responseCallback);
        }

        public void SendMessage(short opCode, byte[] data)
        {
            var msg = MessageHelper.Create(opCode, data);
            SendMessage(msg);
        }

        public void SendMessage(short opCode, byte[] data, ResponseCallback responseCallback)
        {
            var msg = MessageHelper.Create(opCode, data);
            SendMessage(msg, responseCallback);
        }

        public void SendMessage(short opCode, byte[] data, ResponseCallback responseCallback, int timeoutSecs)
        {
            var msg = MessageHelper.Create(opCode, data);
            SendMessage(msg, responseCallback, timeoutSecs);
        }

        public void SendMessage(short opCode, string data)
        {
            var msg = MessageHelper.Create(opCode, data);
            SendMessage(msg);
        }

        public void SendMessage(short opCode, string data, ResponseCallback responseCallback)
        {
            var msg = MessageHelper.Create(opCode, data);
            SendMessage(msg, responseCallback);
        }

        public void SendMessage(short opCode, string data, ResponseCallback responseCallback, int timeoutSecs)
        {
            var msg = MessageHelper.Create(opCode, data);
            SendMessage(msg, responseCallback, timeoutSecs);
        }

        public void SendMessage(short opCode, int data)
        {
            var msg = MessageHelper.Create(opCode, data);
            SendMessage(msg);
        }

        public void SendMessage(short opCode, int data, ResponseCallback responseCallback)
        {
            var msg = MessageHelper.Create(opCode, data);
            SendMessage(msg, responseCallback);
        }

        public void SendMessage(short opCode, int data, ResponseCallback responseCallback, int timeoutSecs)
        {
            var msg = MessageHelper.Create(opCode, data);
            SendMessage(msg, responseCallback, timeoutSecs);
        }

        public virtual void SendMessage(IMessage message)
        {
        }

        public virtual void SendMessage(IMessage message, ResponseCallback responseCallback)
        {
        }

        public virtual void SendMessage(IMessage message, ResponseCallback responseCallback, int timeoutSecs)
        {
        }

        public virtual void SetHandler(IPacketHandler handler)
        {
        }

        public virtual void SetHandler(short opCode, IncommingMessageHandler handlerMethod)
        {
        }

        public virtual void RemoveHandler(IPacketHandler handler)
        {
        }

        public virtual void Update(float deltaTime)
        {
        }

        public virtual void Shut()
        {
        }
    }
}