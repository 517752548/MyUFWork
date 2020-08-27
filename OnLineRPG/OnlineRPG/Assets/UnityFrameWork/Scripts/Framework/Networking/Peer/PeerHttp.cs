using System;
using System.Text;
using UnityEngine.Networking;

namespace BetaFramework
{
    public class PeerHttp : IDisposable, IPeer, ITask
    {
        private string m_Url;
        private UnityWebRequest m_UnityWebRequest = null;

        private bool m_Disposed = false;
        private ResponseCallback m_AckCallback;

        private int m_Id = -1;
        private static int m_PeerIdGenerator = -1;

        public event Action<IIncommingMessage> MessageReceived;

        public int Id
        {
            get
            {
                if (m_Id < 0)
                    m_Id = m_PeerIdGenerator++;
                return m_Id;
            }
        }

        public short OpCode { get; set; }

        private IIncommingMessage m_TimeoutMessage;
        private IIncommingMessage m_NetErrorMessage;

        public PeerHttp(string url, short opCode)
        {
            m_Url = url;
            OpCode = opCode;
            m_TimeoutMessage = new IncommingMessage(opCode, "{\"code\":501}".ToBytes(), this)
            {
                Status = ResponseStatus.Timeout
            };

            m_NetErrorMessage = new IncommingMessage(opCode, "{\"code\":500}".ToBytes(), this)
            {
                Status = ResponseStatus.Error
            };
        }

        public void SendMessage(short opCode)
        {
            SendMessage(MessageHelper.Create(opCode));
        }

        public void SendMessage(short opCode, ISerializablePacket packet)
        {
            SendMessage(MessageHelper.Create(opCode, packet));
        }

        public void SendMessage(short opCode, ISerializablePacket packet, ResponseCallback responseCallback)
        {
            var message = MessageHelper.Create(opCode, packet.ToBytes());
            SendMessage(MessageHelper.Create(opCode, packet), responseCallback);
        }

        public void SendMessage(short opCode, ISerializablePacket packet, ResponseCallback responseCallback, int timeoutSecs)
        {
            var message = MessageHelper.Create(opCode, packet.ToBytes());
            SendMessage(MessageHelper.Create(opCode, packet), responseCallback, timeoutSecs);
        }

        public void SendMessage(short opCode, ResponseCallback responseCallback)
        {
            SendMessage(MessageHelper.Create(opCode), responseCallback);
        }

        public void SendMessage(short opCode, byte[] data)
        {
            SendMessage(MessageHelper.Create(opCode, data));
        }

        public void SendMessage(short opCode, byte[] data, ResponseCallback responseCallback)
        {
            SendMessage(MessageHelper.Create(opCode, data), responseCallback);
        }

        public void SendMessage(short opCode, byte[] data, ResponseCallback responseCallback, int timeoutSecs)
        {
            SendMessage(MessageHelper.Create(opCode, data), responseCallback, timeoutSecs);
        }

        public void SendMessage(short opCode, string data)
        {
            SendMessage(MessageHelper.Create(opCode, data));
        }

        public void SendMessage(short opCode, string data, ResponseCallback responseCallback)
        {
            SendMessage(MessageHelper.Create(opCode, data), responseCallback);
        }

        public void SendMessage(short opCode, string data, ResponseCallback responseCallback, int timeoutSecs)
        {
            SendMessage(MessageHelper.Create(opCode, data), responseCallback, timeoutSecs);
        }

        public void SendMessage(short opCode, int data)
        {
            SendMessage(MessageHelper.Create(opCode, data));
        }

        public void SendMessage(short opCode, int data, ResponseCallback responseCallback)
        {
            SendMessage(MessageHelper.Create(opCode, data), responseCallback);
        }

        public void SendMessage(short opCode, int data, ResponseCallback responseCallback, int timeoutSecs)
        {
            SendMessage(MessageHelper.Create(opCode, data), responseCallback, timeoutSecs);
        }

        public void SendMessage(IMessage message)
        {
            RegisterAck(message, null);

            string str = Encoding.UTF8.GetString(message.ToBytes());
            m_UnityWebRequest = UnityWebRequest.Put(m_Url, str);
            m_UnityWebRequest.SetRequestHeader("Content-Type", "application/json");
            m_UnityWebRequest.SendWebRequest();

            LoggerHelper.LogFormat("Opcode: {0}, Send Message {1}", OpCode.ToString(), str);
        }

        public void SendMessage(IMessage message, ResponseCallback responseCallback)
        {
            RegisterAck(message, responseCallback);

            string str = Encoding.UTF8.GetString(message.ToBytes());
            m_UnityWebRequest = UnityWebRequest.Put(m_Url, str);
            m_UnityWebRequest.SetRequestHeader("Content-Type", "application/json");
            m_UnityWebRequest.SendWebRequest();

            LoggerHelper.LogFormat("Opcode: {0}, Send Message {1}", OpCode.ToString(), str);
        }

        public void SendMessage(IMessage message, ResponseCallback responseCallback, int timeoutSecs)
        {
            RegisterAck(message, responseCallback, timeoutSecs);

            string str = Encoding.UTF8.GetString(message.ToBytes());
            m_UnityWebRequest = UnityWebRequest.Put(m_Url, str);
            m_UnityWebRequest.SetRequestHeader("Content-Type", "application/json");
            m_UnityWebRequest.SendWebRequest();
            LoggerHelper.LogFormat("Opcode: {0}, Send Message {1}", OpCode.ToString(), str);
        }

        public void Update(float deltaTime)
        {
            if (m_UnityWebRequest == null)
                return;

            if (m_UnityWebRequest.isHttpError || m_UnityWebRequest.isNetworkError)
            {
                HandleMessage(m_NetErrorMessage);
                return;
            }

            if (m_UnityWebRequest.isDone)
            {
                HandleDataReceived(m_UnityWebRequest.downloadHandler.data, 0);
            }
        }

        protected int RegisterAck(IMessage message, ResponseCallback responseCallback, int timeoutSecs = 30)
        {
            m_AckCallback = responseCallback;
            message.AckRequestId = Id;
            StartAckTimeout(timeoutSecs);

            return Id;
        }

        protected void TriggerTimeOutAck()
        {
            Shut();

            if (MessageReceived != null)
                MessageReceived(m_TimeoutMessage);

            if (m_AckCallback != null)
                m_AckCallback(ResponseStatus.Timeout, m_TimeoutMessage);
        }

        private void StartAckTimeout(int timeoutSecs)
        {
            TimersManager.SetTimer(timeoutSecs, TriggerTimeOutAck);
        }

        private void CancelAck()
        {
            TimersManager.ClearTimer(TriggerTimeOutAck);
        }

        public virtual void HandleMessage(IIncommingMessage message)
        {
            Shut();

            if (MessageReceived != null)
                MessageReceived(message);
        }

        public void HandleDataReceived(byte[] buffer, int start)
        {
            IIncommingMessage message = null;

            try
            {
                message = MessageHelper.FromBytes(buffer, start, this);

                if (m_AckCallback != null)
                    m_AckCallback(ResponseStatus.Success, message);

                HandleMessage(message);
                CancelAck();

                LoggerHelper.LogFormat("Opcode :{0}, Success receive message: {1}", OpCode.ToString(), message.AsString());
            }
            catch (Exception e)
            {
                LoggerHelper.ErrorFormat("Opcode :{0}, Failed parsing an incomming message: ", OpCode.ToString());
                LoggerHelper.Exception(e);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!m_Disposed)
            {
                if (disposing)
                {
                    if (m_UnityWebRequest != null)
                    {
                        m_UnityWebRequest.Dispose();
                        m_UnityWebRequest = null;
                    }
                }

                m_Disposed = true;
            }
        }

        public void Shut()
        {
            if (m_UnityWebRequest != null)
            {
                m_UnityWebRequest.Abort();
                m_UnityWebRequest.Dispose();
                m_UnityWebRequest = null;
            }
        }

        public void Start()
        {
        }

        public void Stop()
        {
            Shut();
        }
    }
}