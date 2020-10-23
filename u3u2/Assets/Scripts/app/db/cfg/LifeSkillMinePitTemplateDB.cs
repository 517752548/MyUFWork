using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class LifeSkillMinePitTemplateDB : LifeSkillMinePitTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public int GetOpenKuangDianNum(int kuangLevel)
        {
            int num = 0;
            foreach (KeyValuePair<int, LifeSkillMinePitTemplate> pair in idKeyDic)
            {
                if (kuangLevel >= pair.Value.openNeedMineLevel)
                {
                    if (pair.Key > num)
                    {
                        num = pair.Key;
                    }
                }
            }
            return num;
        }
    }
}
