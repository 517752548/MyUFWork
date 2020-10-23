using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class ActivityUITemplateDB : ActivityUITemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public ActivityUITemplate GetActivityTemplateByFuncId(int funcid)
        {
            foreach (KeyValuePair<int, ActivityUITemplate> pair in idKeyDic)
            {
                if (pair.Value.funcId == funcid)
                {
                    return pair.Value;
                }
            }
            return null;
        }

    }
}
