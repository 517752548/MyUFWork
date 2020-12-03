namespace DCET
{
	[Event(EventIdType.InitSceneStart)]
	public class InitSceneStart_CreateLogin : AEvent
	{
        public override void Run()
        {
            var fui = FUILogin.CreateInstance(Game.Scene);

            //默认将会以Id为Name，也可以自定义Name，方便查询和管理
            fui.Name = FUILogin.UIResName;
            fui.MakeFullScreen();
            fui.AddComponent<FUILoginComponent>();

            Game.Scene.GetComponent<FUIComponent>().Add(fui, true);
        }
    }
}