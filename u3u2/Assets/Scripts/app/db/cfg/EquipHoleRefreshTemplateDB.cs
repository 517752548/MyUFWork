
using System.Collections.Generic;

namespace app.db
{
    public class EquipHoleRefreshTemplateDB : EquipHoleRefreshTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 根据装备的等级，获得洗孔消耗的模板数据
        /// </summary>
        /// <param name="equipLevel"></param>
        /// <returns></returns>
        public EquipHoleRefreshTemplate getCostTpl(int equipLevel)
        {
            foreach (KeyValuePair<int, EquipHoleRefreshTemplate> pair in idKeyDic)
            {
                if (equipLevel>=pair.Value.levelMin&&
                    equipLevel<=pair.Value.levelMax)
                {
                    return pair.Value;
                }
            }
            return null;
        }
        
    }
}
