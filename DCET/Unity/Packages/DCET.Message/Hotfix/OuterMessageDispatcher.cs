namespace DCET
{
	public class OuterMessageDispatcher: IMessageDispatcher
	{
		public void Dispatch(Session session, ushort opcode, object message)
		{
			Game.Scene.GetComponent<MessageDispatcherComponent>().Handle(session, opcode, message);
		}
	}
}
