using System.Collections;
using System.Collections.Generic;
using ETModel;
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
            GameObject player  = new GameObject("Player");
            UI ui = await UIFactory.Create();
            //ui.AddComponent<Entity>();
            ui.GetComponent<JLoginCompoent>().GetTip().Coroutine(); 
        }
    }  
}

