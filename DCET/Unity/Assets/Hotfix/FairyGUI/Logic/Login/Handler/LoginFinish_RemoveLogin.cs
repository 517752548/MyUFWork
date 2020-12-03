namespace DCET
{
	[Event(EventIdType.LoginFinish)]
	public class LoginFinish_RemoveLogin : AEvent
	{
        public override void Run()
        {
            Game.Scene.GetComponent<FUIComponent>().Remove(FUILogin.UIResName);
        }
    }
}