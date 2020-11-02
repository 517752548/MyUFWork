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
            GameObject player  = new GameObject("Player");
            UI ui = UILobbyFactory.Create();
            ui.AddComponent<Entity>();
            ui.AddComponent<JLoginCompoent>().GetTip().Coroutine();
        }
    }  
}

