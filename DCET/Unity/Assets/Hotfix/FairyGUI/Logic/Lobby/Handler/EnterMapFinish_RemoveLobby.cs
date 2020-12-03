namespace DCET
{
	[Event(EventIdType.EnterMapFinish)]
	public class EnterMapFinish_RemoveLobby : AEvent
	{
        public override void Run()
        {
            Game.Scene.GetComponent<FUIComponent>().Remove(FUILobby.UIResName);
        }
    }
}