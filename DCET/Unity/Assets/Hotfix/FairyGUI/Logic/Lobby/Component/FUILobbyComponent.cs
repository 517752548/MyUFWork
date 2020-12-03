namespace DCET
{
	[ObjectSystem]
	public class FUILobbyComponentAwakeSystem : AwakeSystem<FUILobbyComponent>
	{
		public override void Awake(FUILobbyComponent self)
		{
			self.Awake();
		}
	}

	public class FUILobbyComponent : Entity
	{
		private FUILobby fuiLobby;

		public void Awake()
		{
			fuiLobby = GetParent<FUILobby>();
			fuiLobby.enterButton.self.onClick.Set(OnClickEnter);
		}

		public void OnClickEnter()
		{
			MapHelper.EnterMapAsync("Map");
		}
	}
}
