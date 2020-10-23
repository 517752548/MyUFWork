using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class WizardRaidTemplateDB : WizardRaidTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minlevel">队里最小等级</param>
        /// <param name="maxlevel">队里最大等级</param>
        /// <param name="type">2是组队 1是单人</param>
        /// <returns></returns>
        public int GetFubenID(int minlevel ,int maxlevel,int type) {
            foreach (KeyValuePair<int, WizardRaidTemplate> item in idKeyDic)
            {
                if (item.Value.raidTypeId == type)
                {
                    //组队
                    if (item.Value.levelMin <= minlevel && item.Value.levelMax >= maxlevel)
                    {
                        return item.Value.Id;
                    }
                }

            }
            return -1;
        }
        
    }
}
