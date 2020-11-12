using System.Collections;
using System.Collections.Generic;
using ETHotfix;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    public class JFlyCompoent: UIBaseComponent
    {
        public Text tittleText;
        public override void OnOpen()
        {
            tittleText = this.GameObject.Get<GameObject>("Tittle").GetComponent<Text>();
            GameObject.Get<GameObject>("OKBtn").GetComponent<Button>().onClick.AddListener(ClickLogin);
            base.OnOpen();
            this.tittleText.text = this.objs[0].ToString();
        }
        


        public void ClickLogin()
        {
            ETHotfix.Game.Scene.GetComponent<MapManagerComponent>().LoadMapAsync(2);
        }
    }
}