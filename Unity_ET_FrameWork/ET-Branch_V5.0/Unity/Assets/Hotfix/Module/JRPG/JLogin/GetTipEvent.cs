using System.Collections;
using System.Collections.Generic;
using ETModel;
using Hotfix;
using UnityEngine;

namespace ETHotfix
{
    [Event(EventIdType.JGetTips)]
    public class GetTipEvent: AEvent
    {
        public override void Run()
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