using System.Collections;
using System.Collections.Generic;
using ET;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class JFlyCompoent: UIBaseComponent
    {
        public Text tittleText;
        private int flyMapId;
        public override void OnOpen()
        {
            tittleText = this.GameObject.Get<GameObject>("Tittle").GetComponent<Text>();
            GameObject.Get<GameObject>("OKBtn").GetComponent<Button>().onClick.AddListener(ClickLogin);
            GameObject.Get<GameObject>("CloseBtn").GetComponent<Button>().onClick.AddListener(ClickClose);
            base.OnOpen();
            flyMapId = int.Parse(this.objs[0].ToString());
            this.tittleText.text = this.objs[0].ToString();
        }


        private void ClickClose()
        {
            this.GetParent<UIBase>().CloseSelf();
        }
        public void ClickLogin()
        {
            ET.Game.Scene.GetComponent<MapManagerComponent>().LoadMapAsync(flyMapId);
            this.GetParent<UIBase>().CloseSelf();
        }
    }
}