using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class HotFixInit
    {
        // Start is called before the first frame update
        static void StartInit()
        {
            Log.Info("游戏启动");
            Game.EventSystem.Publish(new EventType.AppStart());
        }

    }
}

