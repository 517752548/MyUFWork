namespace DCET
{
	[ObjectSystem]
	public class FUILoginComponentAwakeSystem : AwakeSystem<FUILoginComponent>
	{
		public override void Awake(FUILoginComponent self)
		{
			self.Awake();
		}
	}

	public class FUILoginComponent : Entity
	{
		private FUILogin fuiLogin;

		public void Awake()
		{
			fuiLogin = GetParent<FUILogin>();
			fuiLogin.loginButton.self.onClick.Set(OnClickLogin);
		}

		public override void Dispose()
		{
			if (IsDisposed)
			{
				return;
			}

			base.Dispose();

			fuiLogin.loginButton.self.onClick.Clear();
		}

		public void OnClickLogin()
		{
			LoginHelper.OnLoginAsync(fuiLogin.accountInput.text);
		}
	}
}
