using ET.EventType;
using Hotfix;

namespace ET
{
    public class GetTipEvent: AEvent<EventType.JGetTips>
    {
        public override async ETTask Run(JGetTips i)
        {
          ShowPanel().Coroutine();
        }

        private async ETVoid ShowPanel()
        {
            await Game.Scene.GetComponent<UIManagerComponent>().OpenUIAsync<JLoginCompoent>(ViewConst.prefab_UIJLogin);
            //UI ui = await UIFactory.Create();
            //ui.AddComponent<Entity>();
            //ui.GetComponent<JLoginCompoent>().GetTip().Coroutine(); 
        }
    }
}