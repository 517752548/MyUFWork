using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class EquipDecomposeTemplateDB : EquipDecomposeTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        /// <summary>
        /// 获得一个装备的分解信息
        /// </summary>
        /// <param name="equipColorInt"></param>
        /// <param name="equipLevel"></param>
        /// <returns></returns>
        public EquipDecomposeTemplate GetEquipDecompose(int equipColorInt,int equipLevel)
        {
            foreach (KeyValuePair<int, EquipDecomposeTemplate> pair in idKeyDic)
            {
                if (pair.Value.color==equipColorInt)
                {
                    if (equipLevel >= pair.Value.lowLevel && equipLevel <= pair.Value.hightLevel)
                    {
                        if (pair.Value.isAvailable>0)
                        {
                            return pair.Value;
                        }
                    }
                }
            }
            return null;
        }
    }
}
