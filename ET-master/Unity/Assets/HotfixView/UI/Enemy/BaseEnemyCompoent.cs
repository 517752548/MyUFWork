using System.Collections;
using System.Collections.Generic;
using ET;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class JLoginCompoent: UIBaseComponent
    {
        public string userid;
        public string parentName;
        
        public override void OnOpen()
        {
            Log.Info("login open");
            GameObject.Get<GameObject>("LoginBtn").GetComponent<Button>().onClick.AddListener(ClickLogin);
            userid = SystemInfo.deviceUniqueIdentifier;
            base.OnOpen();
            GetTip().Coroutine();
            parentName = this.parent.Id.ToString();
        }
        

        public async  ETVoid GetTip()
        {
        }

        public void ClickLogin()
        {
            Log.Info("click");
            ET.Game.Scene.GetComponent<MapManagerComponent>().LoadMapAsync(1).Coroutine();
            this.GetParent<UIBase>().CloseSelf();
        }
    }
}