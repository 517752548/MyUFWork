namespace BetaFramework
{
    internal interface IClient : IMsgDispatcher
    {
        /// <summary>
        /// 增加包处理接口，需要指定opcode
        /// </summary>
        void SetHandler(IPacketHandler handler);

        /// <summary>
        /// 增加包处理接口，需要指定opcode
        /// </summary>
        void SetHandler(short opCode, IncommingMessageHandler handlerMethod);

        /// <summary>
        /// 移除接口
        /// </summary>
        /// <param name="handler"></param>
        void RemoveHandler(IPacketHandler handler);

        void Update(float deltaTime);

        void Shut();
    }
}