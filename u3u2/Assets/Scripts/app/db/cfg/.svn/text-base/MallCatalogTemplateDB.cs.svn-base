using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class MallCatalogTemplateDB : MallCatalogTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        //宠物商店
        private int PetStoreId = 1;
        //生活技能
        private int ShengHuoId = 7;
        /// <summary>
        /// 获得商城所有的页签，排除宠物商店
        /// </summary>
        /// <returns></returns>
        public List<int> GetShopTabIdList()
        {
            List<int> tabs = new List<int>();
            foreach (KeyValuePair<int, MallCatalogTemplate> pair in idKeyDic)
            {
                if (pair.Key != PetStoreId && pair.Key != ShengHuoId)
                {
                    tabs.Add(pair.Key);
                }
            }
            return tabs;
        }
        
    }
}
