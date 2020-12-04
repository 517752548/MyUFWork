using System.Collections;
using System.Collections.Generic;
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
            
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private async ETTask InisAddressable()
        {
            await this.addressableLoader.Init();
        }

        private async ETTask GetDownLoadSize()
        {
            
        }
    }
}

