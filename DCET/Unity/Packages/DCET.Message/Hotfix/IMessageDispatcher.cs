namespace DCET
{
	public interface IMessageDispatcher
	{
		void Dispatch(Session session, ushort opcode, object message);
	}
}
