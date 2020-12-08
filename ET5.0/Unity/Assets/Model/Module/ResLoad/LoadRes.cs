using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ETModel
{
    [Event(ETModel.EventIdType.UpdateOnlineRes)]
    public class LoadRes:AEvent
    {
        private Image progressImage;
        private AddressableLoaderAsync addressableLoader;
        public override void Run()
        {
            progressImage = GameObject.Find("Canvas/ImageProgress").GetComponent<Image>();
            addressableLoader = ComponentFactory.Create<AddressableLoaderAsync>();
            DoLoadRes().Coroutine();
        }

        private async ETVoid DoLoadRes()
        {
            await InitAddressable();
           long downloadSize = await GetDownLoadSize();
           Log.Info("下载大小为:" + downloadSize);
           if (downloadSize > 0)
           {
               var handle = addressableLoader.DownLoadRes();
               bool downloadFinish = false;
               while (!downloadFinish)
               {
                   if (handle.IsDone)
                   {
                       downloadFinish = true;
                   }
                   await Task.Delay(20);
                   progressImage.fillAmount = handle.PercentComplete;
               }
               Log.Info("下载完成");

           }
           else
           {
               int framecount = 0;
               while (framecount <= 100)
               {
                   framecount++;
                   await Task.Delay(20);
                   progressImage.fillAmount = (float) framecount / 100;
               }
           }
           //启动
           Game.Hotfix.GotoHotfix();
           GameObject.Find("Canvas").gameObject.SetActive(false);
        }


        
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private async ETTask InitAddressable()
        {
            await this.addressableLoader.Init();
        }

        private async ETTask<long> GetDownLoadSize()
        {
          long size = await addressableLoader.GetDownLoadSize();
          return size;
        }
        
    }
}

