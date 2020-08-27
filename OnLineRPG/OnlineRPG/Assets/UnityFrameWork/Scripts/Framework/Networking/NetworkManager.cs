namespace BetaFramework
{
    public class NetworkManager : IModule
    {
        private IClient m_Client;

        public NetworkManager()
        {
            m_Client = new HttpClient(URLSetting.SERVER_SYNC_URL);
        }

        public override void Init()
        {
        }

        public override void Execute(float deltaTime)
        {
            if (m_Client != null)
                m_Client.Update(deltaTime);
        }

        public override void Pause(bool pause)
        {
        }

        public override void Shut()
        {
            if (m_Client != null)
                m_Client.Shut();
        }

        public void SetUrl(string url)
        {
            if (m_Client != null)
                ((HttpClient)m_Client).SetUrl(url);
        }

        #region Send Message

        public void SendMessage(short opCode)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode);
        }

        public void SendMessage(short opCode, ISerializablePacket packet)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, packet);
        }

        public void SendMessage(short opCode, ISerializablePacket packet, ResponseCallback responseCallback)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, packet, responseCallback);
        }

        public void SendMessage(short opCode, ISerializablePacket packet, ResponseCallback responseCallback, int timeoutSecs)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, packet, responseCallback, timeoutSecs);
        }

        public void SendMessage(short opCode, ResponseCallback responseCallback)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, responseCallback);
        }

        public void SendMessage(short opCode, byte[] data)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, data);
        }

        public void SendMessage(short opCode, byte[] data, ResponseCallback responseCallback)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, data, responseCallback);
        }

        public void SendMessage(short opCode, byte[] data, ResponseCallback responseCallback, int timeoutSecs)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, data, responseCallback, timeoutSecs);
        }

        public void SendMessage(short opCode, string data)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, data);
        }

        public void SendMessage(short opCode, string data, ResponseCallback responseCallback)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, data, responseCallback);
        }

        public void SendMessage(short opCode, string data, ResponseCallback responseCallback, int timeoutSecs)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, data, responseCallback, timeoutSecs);
        }

        public void SendMessage(short opCode, int data)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, data);
        }

        public void SendMessage(short opCode, int data, ResponseCallback responseCallback)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, data, responseCallback);
        }

        public void SendMessage(short opCode, int data, ResponseCallback responseCallback, int timeoutSecs)
        {
            if (m_Client != null)
                m_Client.SendMessage(opCode, data, responseCallback, timeoutSecs);
        }

        public void SendMessage(IMessage message)
        {
            if (m_Client != null)
                m_Client.SendMessage(message);
        }

        public void SendMessage(IMessage message, ResponseCallback responseCallback)
        {
            if (m_Client != null)
                m_Client.SendMessage(message, responseCallback);
        }

        public void SendMessage(IMessage message, ResponseCallback responseCallback, int timeoutSecs)
        {
            if (m_Client != null)
                m_Client.SendMessage(message, responseCallback, timeoutSecs);
        }

        #endregion Send Message

        #region Set Handlers

        public void SetHandler(IPacketHandler handler)
        {
            if (m_Client != null)
                m_Client.SetHandler(handler);
        }

        public void SetHandler(short opCode, IncommingMessageHandler handlerMethod)
        {
            if (m_Client != null)
                m_Client.SetHandler(opCode, handlerMethod);
        }

        public void RemoveHandler(IPacketHandler handler)
        {
            if (m_Client != null)
                m_Client.RemoveHandler(handler);
        }

        #endregion Set Handlers
    }
}