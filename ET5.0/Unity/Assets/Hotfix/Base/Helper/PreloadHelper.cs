using System;
using System.Collections;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    public static class PreloadHelper
    {
        public static async ETTask PreloadRes()
        {
            List<Type> types = Game.EventSystem.GetTypes();
            foreach (Type type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof (ConfigAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }

                ConfigAttribute configAttribute = attrs[0] as ConfigAttribute;
                // 只加载指定的配置
                if (!configAttribute.Type.Is(AppType.ClientH))
                {
                    continue;
                }
                string configName = type.ToString().Replace("ETHotfix.", "").Replace("Category", "");
                await ETModel.Game.Scene.GetComponent<ResourcesComponent>().CacheBundleAsync($"{configName}.txt");
            }
        }
    }
}