using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class EquipRecastLockAttrTemplateDB : EquipRecastLockAttrTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 根据装备的颜色id、锁定的条数，获得 重铸的消耗
        /// </summary>
        /// <param name="equipcolor"></param>
        /// <param name="lockNum"></param>
        /// <returns></returns>
        public EquipRecastLockAttrTemplate getTpl(int equipcolor,int lockNum)
        {
            foreach (KeyValuePair<int, EquipRecastLockAttrTemplate> pair in idKeyDic)
            {
                if (pair.Value.equipColorId==equipcolor&&pair.Value.lockNum==lockNum)
                {
                    return pair.Value;
                }
            }
            return null;
        }

    }
}
