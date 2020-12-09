using System.Collections;
using System.Collections.Generic;
using ETHotfix;
using ETModel;
using Hotfix;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    public class UILoginComponent : UIBaseComponent
    {
        public override void OnOpen()
        {
            base.OnOpen();
            this.rc.Get<GameObject>("LoginBtn").GetComponent<Button>().onClick.Add(SendHttp);
        }
        
        
        public async void SendHttp()
        {
            Log.Info("1");
            ETModel.Game.Scene.GetComponent<SoundComponent>().PlayClip(ResConst.wav_btn_home);
            ETModel.Game.Scene.GetComponent<SoundComponent>().PlayMusic(ResConst.mp3_common_hm);
            using (UnityWebRequestAsync webRequestAsync = ComponentFactory.Create<UnityWebRequestAsync>())
            {
                string url = "http://localhost:8080";
                await webRequestAsync.Get(url + "/t");
                Log.Info("->" + webRequestAsync.Request.downloadHandler.text);
            }
        }
    }
}

