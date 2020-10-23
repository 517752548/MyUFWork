
using System.Collections.Generic;

namespace app.db
{
    public class EquipCraftItemTemplateDB : EquipCraftItemTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 根据 打造消耗模板和打造的品质，获得打造需要的材料列表
        /// </summary>
        /// <param name="craftcost"></param>
        /// <param name="qualityid"></param>
        /// <returns></returns>
        public List<EquipCraftItemTemplate> getTplListByCraftCost(CraftEquipCostTemplate craftcost,int qualityid)
        {
            List<EquipCraftItemTemplate> list = new List<EquipCraftItemTemplate>();

            int len = craftcost.costItemList.Count;
            for (int i=0;i<len;i++)
            {
                bool hasitem = false;
                if (craftcost.costItemList[i].groupId!=0)
                {
                    foreach (KeyValuePair<int, EquipCraftItemTemplate> pair in idKeyDic)
                    {
                        if (pair.Value.groupId == craftcost.costItemList[i].groupId
                            && qualityid == pair.Value.rarityId)
                        {
                            list.Add(pair.Value);
                            hasitem = true;
                            break;
                        }
                    }
                }
                if (!hasitem)
                {
                    //不足用null填充，保持和craftcost.costItemList列表的对应
                    list.Add(null);
                }
            }
            return list;
        }

    }
}
