namespace DCET
{
	[ObjectSystem]
	public class SessionComponentAwakeSystem : AwakeSystem<SessionComponent>
	{
		public override void Awake(SessionComponent self)
		{
			self.Awake();
		}
	}

	public class SessionComponent: Entity
	{
		public static SessionComponent Instance;

		private Session session;

		public Session Session
		{
			get
			{
				return session;
			}
			set
			{
				if(session != null && !session.IsDisposed)
				{
					session.Dispose();
				}

				session = value;
			}
		}

		public void Awake()
		{
			Instance = this;
		}

		public override void Dispose()
		{
			if (IsDisposed)
			{
				return;
			}

			base.Dispose();

			Session?.Dispose();
			Session = null;
			Instance = null;
		}
	}
}
