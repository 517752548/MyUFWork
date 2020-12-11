using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ETHotfix;
using ETModel;
using Hotfix;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    public class UILoginComponent: UIBaseComponent
    {
        public override void OnOpen()
        {
            base.OnOpen();
            this.rc.Get<GameObject>("LoginBtn").GetComponent<Button>().onClick.Add(SendHttp);
        }

        public async void SendHttp()
        {
            await this.rc.Get<GameObject>("LoginBtn").transform.DOLocalMove(Vector3.one, 1).ToAwaiter();
            Log.Info("11");
            ETModel.Game.Scene.GetComponent<SoundComponent>().PlayClip(ResConst.wav_btn_home);
            ETModel.Game.Scene.GetComponent<SoundComponent>().PlayMusic(ResConst.mp3_common_hm);
            UnityWebRequestAsync webRequestAsync = ComponentFactory.Create<UnityWebRequestAsync>();
            string url = "http://localhost:8080";
            await webRequestAsync.Get(url + "/t");
            if (webRequestAsync.Request != null)
            {
                Log.Info("-->" + webRequestAsync.Request.downloadHandler.text);
            }
            webRequestAsync.Dispose();
            
        }
    }
}