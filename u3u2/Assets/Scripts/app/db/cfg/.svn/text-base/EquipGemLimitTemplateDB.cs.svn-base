
using System.Collections.Generic;

namespace app.db
{
    public class EquipGemLimitTemplateDB : EquipGemLimitTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 根据装备 部位，获得能镶嵌的宝石模板id
        /// </summary>
        /// <param name="equipPos"></param>
        /// <returns></returns>
        public List<int> GetGemIdListByEquipPos(int equipPos)
        {
            List<int> list = new List<int>();
            foreach (KeyValuePair<int, EquipGemLimitTemplate> pair in idKeyDic)
            {
                if (pair.Value.posId == equipPos && !list.Contains(pair.Value.gemItemId))
                {
                    list.Add(pair.Value.gemItemId);
                }
            }
            return list;
        }
    }
}
