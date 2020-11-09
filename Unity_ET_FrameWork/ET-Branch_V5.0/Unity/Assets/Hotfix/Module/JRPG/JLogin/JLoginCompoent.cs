using System.Collections;
using System.Collections.Generic;
using ETHotfix;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    public class JLoginCompoent: UIBaseComponent
    {
        public string userid;
        
        public override void OnOpen()
        {
            GameObject.Get<GameObject>("LoginBtn").GetComponent<Button>().onClick.AddListener(ClickLogin);
            userid = SystemInfo.deviceUniqueIdentifier;
            base.OnOpen();
            GetTip().Coroutine();
        }
        

        public async  ETVoid GetTip()
        {
            // 创建一个ETModel层的Session
            ETModel.Session session = ETModel.Game.Scene.GetComponent<NetOuterComponent>().Create(GlobalConfigComponent.Instance.GlobalProto.Address);
            // 创建一个ETHotfix层的Session, ETHotfix的Session会通过ETModel层的Session发送消息
            Session realmSession = ComponentFactory.Create<Session, ETModel.Session>(session);
            R2C_JTips jtips = (R2C_JTips) await realmSession.Call(new C2R_JTips());
            Log.Info($"receive:{jtips.Message}");
        }

        public void ClickLogin()
        {
            Log.Info("click");
            ETHotfix.Game.Scene.GetComponent<MapManagerComponent>().LoadMapAsync(1).Coroutine();
            this.GetParent<UIBase>().CloseSelf();
        }
    }
}