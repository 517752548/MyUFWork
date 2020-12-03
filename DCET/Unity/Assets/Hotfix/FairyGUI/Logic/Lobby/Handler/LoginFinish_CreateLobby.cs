namespace DCET
{
	[Event(EventIdType.LoginFinish)]
	public class LoginFinish_CreateLobby : AEvent
	{
        public override void Run()
        {
            var fui = FUILobby.CreateInstance(Game.Scene);

            //默认将会以Id为Name，也可以自定义Name，方便查询和管理
            fui.Name = FUILobby.UIResName;
            fui.MakeFullScreen();
            fui.AddComponent<FUILobbyComponent>();

            Game.Scene.GetComponent<FUIComponent>().Add(fui, true);
        }
    }
}