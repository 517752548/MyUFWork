

using Hotfix;

namespace ET
{
	public class AppStartInitFinish_RemoveLoginUI: AEvent<EventType.AppStartInitFinish>
	{
		public override async ETTask Run(EventType.AppStartInitFinish args)
		{
			Log.Info("run3");
			await Game.Scene.GetComponent<UIManagerComponent>().OpenUIAsync<JLoginCompoent>(ViewConst.prefab_UIJLogin);
			Log.Info("run4");
			//await UIHelper.Create(args.ZoneScene, UIType.UILogin);
		}
	}
}
