using System;

namespace BetaFramework
{
    public delegate void IncommingMessageHandler(IIncommingMessage message);

    public delegate void ResponseCallback(ResponseStatus status, IIncommingMessage response);

    public interface IPeer : IDisposable, IMsgDispatcher, ITask
    {
        short OpCode { get; set; }

        int Id { get; }

        /// <summary>
        ///     消息接收事件
        /// </summary>
        event Action<IIncommingMessage> MessageReceived;
    }
}