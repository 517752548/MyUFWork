
using System.Collections.Generic;

namespace app.db
{
    public class GemDownTemplateDB : GemDownTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法


        /// <summary>
        /// 获得 摘除消耗的道具模板id列表
        /// </summary>
        /// <returns></returns>
        public List<int> zhaichuCostItemTplIdList()
        {
            List<int> list = new List<int>();
            foreach (KeyValuePair<int, GemDownTemplate> pair in idKeyDic)
            {
                if (!list.Contains(pair.Value.itemId1))
                {
                    list.Add(pair.Value.itemId1);
                }
                if (!list.Contains(pair.Value.itemId2))
                {
                    list.Add(pair.Value.itemId2);
                }
            }
            return list;
        }
    }
}
