using System.Collections;
using System.Collections.Generic;
using ETHotfix;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    public class UILoginComponent : UIBaseComponent
    {
        public override void OnOpen()
        {
            base.OnOpen();
            Log.Info("uilogin awake");
            this.rc.Get<GameObject>("LoginBtn").GetComponent<Button>().onClick.AddListener(SendHttp);
        }
        
        
        public async void SendHttp()
        {
            Log.Info("1");
            using (UnityWebRequestAsync webRequestAsync = ETModel.ComponentFactory.Create<UnityWebRequestAsync>())
            {
                string url = "http://localhost:8080";
                Log.Info("2");
                Log.Info(url);
                await webRequestAsync.DownloadAsync(url + "/t");
                Log.Info(webRequestAsync.Request.downloadHandler.text);
            }
        }
    }
}

