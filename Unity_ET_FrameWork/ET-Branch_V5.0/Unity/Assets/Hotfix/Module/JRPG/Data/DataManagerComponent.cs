using System.Collections;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class DataManagerComponentAwakeSystem: AwakeSystem<DataManagerComponent>
    {
        public override void Awake(DataManagerComponent self)
        {
            if (PlayerPrefs.GetString("userid") != "")
            {
                self.userId = PlayerPrefs.GetString("userid");
            }
            else
            {

                self.userId = System.Guid.NewGuid().ToString();
                PlayerPrefs.SetString("userid",self.userId);
            }
        }
    }
    public class DataManagerComponent: Component
    {
        public string userId;
    }
}