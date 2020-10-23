using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class ForageTaskRewardTemplateDB : ForageTaskRewardTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public ForageTaskRewardTemplate getTplByStar(int star)
        {
            foreach (KeyValuePair<int, ForageTaskRewardTemplate> pair in idKeyDic)
            {
                if (pair.Value.forageStar==star)
                {
                    return pair.Value;
                }
            }
            return null;
        }
    }
}
