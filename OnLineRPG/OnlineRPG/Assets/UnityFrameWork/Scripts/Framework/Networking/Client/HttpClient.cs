using System;
using System.Collections.Generic;

namespace BetaFramework
{
    public class HttpClient : BaseClient
    {
        private string m_Url;
        private TaskPool<PeerHttp> m_HttpTasks;
        private readonly Dictionary<short, IPacketHandler> m_Handlers;

        public HttpClient(string url)
        {
            m_Url = url;
            m_HttpTasks = new TaskPool<PeerHttp>();
            m_Handlers = new Dictionary<short, IPacketHandler>();
        }

        public void SetUrl(string url)
        {
            m_Url = url;
        }

        public override void SetHandler(IPacketHandler handler)
        {
            m_Handlers[handler.OpCode] = handler;
        }

        public override void SetHandler(short opCode, IncommingMessageHandler handlerMethod)
        {
            var handler = new PacketHandler(opCode, handlerMethod);
            SetHandler(handler);
        }

        public override void RemoveHandler(IPacketHandler handler)
        {
            IPacketHandler previousHandler;
            m_Handlers.TryGetValue(handler.OpCode, out previousHandler);

            if (previousHandler != handler)
                return;

            m_Handlers.Remove(handler.OpCode);
        }

        public override void SendMessage(IMessage message)
        {
            PeerHttp peer = new PeerHttp(m_Url, message.OpCode);
            peer.SendMessage(message);
            peer.MessageReceived += HandleMessage;

            m_HttpTasks.AddTask(peer);
        }

        public override void SendMessage(IMessage message, ResponseCallback responseCallback)
        {
            PeerHttp peer = new PeerHttp(m_Url, message.OpCode);
            peer.SendMessage(message, responseCallback);
            peer.MessageReceived += HandleMessage;


            m_HttpTasks.AddTask(peer);
        }

        public override void SendMessage(IMessage message, ResponseCallback responseCallback, int timeoutSecs)
        {
            PeerHttp peer = new PeerHttp(m_Url, message.OpCode);
            peer.SendMessage(message, responseCallback, timeoutSecs);
            peer.MessageReceived += HandleMessage;

            m_HttpTasks.AddTask(peer);
        }

        private void HandleMessage(IIncommingMessage message)
        {
            try
            {
                IPacketHandler handler;
                m_Handlers.TryGetValue(message.OpCode, out handler);

                if (handler != null)
                {
                    handler.Handle(message);
                    LoggerHelper.LogFormat("Success to handle a message {0}. OpCode: {1}", message.AsString(), message.OpCode);
                }
                else
                {
                    LoggerHelper.ErrorFormat("Http is missing a handler. OpCode: {0}", message.OpCode);
                    message.Respond(ResponseStatus.Error);
                }
            }
            catch (Exception e)
            {
                LoggerHelper.ErrorFormat("Failed to handle a message. OpCode: {0}", message.OpCode);
                LoggerHelper.Exception(e);

                try
                {
                    message.Respond(ResponseStatus.Error);
                }
                catch (Exception exception)
                {
                    LoggerHelper.Exception(exception);
                }
            }

            PeerHttp peer = message.Peer as PeerHttp;
            if (peer != null)
            {
                peer.MessageReceived -= HandleMessage;
                m_HttpTasks.RemoveTask(peer);
            }
        }

        public override void Update(float deltaTime)
        {
            m_HttpTasks.Update(deltaTime);
        }

        public override void Shut()
        {
            m_HttpTasks.ClearAllTask();
        }
    }
}