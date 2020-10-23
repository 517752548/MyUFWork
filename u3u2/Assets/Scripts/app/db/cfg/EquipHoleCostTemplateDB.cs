
using System.Collections.Generic;

namespace app.db
{
    public class EquipHoleCostTemplateDB : EquipHoleCostTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 获得 装备 打孔 所需的材料模板
        /// </summary>
        /// <param name="kongIndex"></param>
        /// <param name="equipLevel"></param>
        /// <returns></returns>
        public EquipHoleCostTemplate getEquipHoleCostTPL(int kongIndex,int equipLevel)
        {
            foreach (KeyValuePair<int, EquipHoleCostTemplate> pair in idKeyDic)
            {
                if (pair.Value.hole == kongIndex &&
                    equipLevel>=pair.Value.levelMin &&
                    equipLevel <= pair.Value.levelMax)
                {
                    return pair.Value;
                }
            }
            return null;
        }

    }
}
