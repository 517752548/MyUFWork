using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class CraftEquipCostTemplateDB : CraftEquipCostTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 根据类别 获得 等级段 列表（字符串形式，英文-隔开，如：1-19）
        /// </summary>
        /// <param name="kindid"></param>
        /// <returns></returns>
        public List<string> GetLevelRangeListByKind(int kindid)
        {
            List<string> levelRangeList = new List<string>();
            foreach (KeyValuePair<int, CraftEquipCostTemplate> pair in idKeyDic)
            {
                if (pair.Value.equipTypeId==kindid&&pair.Value.canCraftFlag==1)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(pair.Value.levelMin+"-" + pair.Value.levelMax);

                    if (!levelRangeList.Contains(sb.ToString()))
                    {
                        levelRangeList.Add(sb.ToString());
                    }
                }
            }
            return levelRangeList;
        }

        /// <summary>
        /// 根据类别和等级段 获得 装备模板id列表
        /// </summary>
        /// <param name="kindid"></param>
        /// <returns></returns>
        public List<CraftEquipCostTemplate> GetEquipListByKindAndLevel(int kindid, string levelRange)
        {
            string[] arr = levelRange.Split('-');
            int levelMin = int.Parse(arr[0]);
            int levelMax = int.Parse(arr[1]);

            List<CraftEquipCostTemplate> itemTplIdList = new List<CraftEquipCostTemplate>();
            foreach (KeyValuePair<int, CraftEquipCostTemplate> pair in idKeyDic)
            {
                if (pair.Value.equipTypeId == kindid && pair.Value.canCraftFlag == 1
                    && pair.Value.levelMin == levelMin && pair.Value.levelMax == levelMax)
                {
                    //if (!itemTplIdList.Contains(pair.Value.equipId))
                    //{
                        itemTplIdList.Add(pair.Value);
                    //}
                }
            }
            return itemTplIdList;
        }

    }
}
