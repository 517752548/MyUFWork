

using System.Collections.Generic;

namespace app.db
{
    public class GemUpTemplateDB : GemUpTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 获得 镶嵌消耗的道具模板id列表
        /// </summary>
        /// <returns></returns>
        public List<int> xiangqianCostItemTplIdList()
        {
            List<int> list = new List<int>();
            foreach (KeyValuePair<int, GemUpTemplate> pair in idKeyDic)
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
