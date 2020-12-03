using System;

namespace DCET
{
	public interface IMHandler
	{
		void Handle(Session session, object message);
		Type GetMessageType();
	}
}