using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class MallNormalItemTemplateDB : MallNormalItemTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        private Dictionary<int, List<MallNormalItemTemplate>> fenleiDic;

        /// <summary>
        /// 根据物品的分类 获得 物品列表
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        public List<MallNormalItemTemplate> GetItemListByCatalog(int catalog)
        {
            if (fenleiDic==null)
            {
                fenleiDic = new Dictionary<int, List<MallNormalItemTemplate>>();
                foreach (KeyValuePair<int, MallNormalItemTemplate> pair in idKeyDic)
                {
                    if (pair.Value.notSale == 0)
                    {
                        if (!fenleiDic.ContainsKey(pair.Value.catalogId))
                        {
                            fenleiDic.Add(pair.Value.catalogId, new List<MallNormalItemTemplate>());
                        }
                        fenleiDic[pair.Value.catalogId].Add(pair.Value);
                    }
                }
            }
            if (fenleiDic.ContainsKey(catalog))
            {
                return fenleiDic[catalog];
            }
            else
            {
                return null;
            }
        }
    }
}
