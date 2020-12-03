using System;
using System.Collections.Generic;

namespace DCET
{
	[ObjectSystem]
	public class MessageDispatcherComponentAwakeSystem : AwakeSystem<MessageDispatcherComponent>
	{
		public override void Awake(MessageDispatcherComponent t)
		{
			t.Awake();
		}
	}

	[ObjectSystem]
	public class MessageDispatcherComponentLoadSystem : LoadSystem<MessageDispatcherComponent>
	{
		public override void Load(MessageDispatcherComponent self)
		{
			self.Load();
		}
	}

	/// <summary>
	/// 消息分发组件
	/// </summary>
	public class MessageDispatcherComponent : Entity
	{
		public static MessageDispatcherComponent Instance;

		private readonly Dictionary<ushort, List<IMHandler>> handlers = new Dictionary<ushort, List<IMHandler>>();

		public void Awake()
		{
			this.Load();
			Instance = this;
		}

		public void Load()
		{
			this.handlers.Clear();

			HashSet<Type> types = Game.EventSystem.GetTypes(typeof(MessageHandlerAttribute));

			foreach (Type type in types)
			{
				object[] attrs = type.GetCustomAttributes(typeof(MessageHandlerAttribute), false);
				if (attrs.Length == 0)
				{
					continue;
				}

				IMHandler iMHandler = Activator.CreateInstance(type) as IMHandler;
				if (iMHandler == null)
				{
					Log.Error($"message handle {type.Name} 需要继承 IMHandler");
					continue;
				}

				Type messageType = iMHandler.GetMessageType();
				ushort opcode = this.Parent.GetComponent<OpcodeTypeComponent>().GetOpcode(messageType);
				if (opcode == 0)
				{
					Log.Error($"消息opcode为0: {messageType.Name}");
					continue;
				}
				this.RegisterHandler(opcode, iMHandler);
			}
		}

		public void RegisterHandler(ushort opcode, IMHandler handler)
		{
			if (!this.handlers.ContainsKey(opcode))
			{
				this.handlers.Add(opcode, new List<IMHandler>());
			}
			this.handlers[opcode].Add(handler);
		}

		public void Handle(Session session, ushort opcode, object message)
		{
			List<IMHandler> actions;
			if (!this.handlers.TryGetValue(opcode, out actions))
			{
				Log.Error($"消息没有处理: opcode={opcode}");
				Log.Error($"消息没有处理: message={DCETRuntime.MongoHelper.ToJson(message)}");
				return;
			}
			
			foreach (IMHandler ev in actions)
			{
				try
				{
					ev.Handle(session, message);
				}
				catch (Exception e)
				{
					Log.Exception(e);
				}
			}
		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			base.Dispose();

			Instance = null;
		}
	}
}