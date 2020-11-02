using System.Collections;
using System.Collections.Generic;
using ETHotfix;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    [ObjectSystem]
    public class JLoginCompoentAwakeSystem : AwakeSystem<JLoginCompoent>
    {
        public override void Awake(JLoginCompoent self)
        {
            self.userid = SystemInfo.deviceUniqueIdentifier;
        }
    }
    public class JLoginCompoent: Component
    {
        public string userid;

        public async  ETVoid GetTip()
        {
            // 创建一个ETModel层的Session
            ETModel.Session session = ETModel.Game.Scene.GetComponent<NetOuterComponent>().Create(GlobalConfigComponent.Instance.GlobalProto.Address);
            // 创建一个ETHotfix层的Session, ETHotfix的Session会通过ETModel层的Session发送消息
            Session realmSession = ComponentFactory.Create<Session, ETModel.Session>(session);
            R2C_JTips jtips = (R2C_JTips) await realmSession.Call(new C2R_JTips());
            Log.Info($"receive:{jtips.Message}");
        }
    }
}