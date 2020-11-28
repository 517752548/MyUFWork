

using Hotfix;

namespace ET
{
	public class AppStartInitFinish_RemoveLoginUI: AEvent<EventType.AppStartInitFinish>
	{
		public override async ETTask Run(EventType.AppStartInitFinish args)
		{
			
			await Game.Scene.GetComponent<UIManagerComponent>().OpenUIAsync<JLoginCompoent>(ViewConst.prefab_UIJLogin);
			//await UIHelper.Create(args.ZoneScene, UIType.UILogin);
		}
	}
}
