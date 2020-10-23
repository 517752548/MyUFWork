using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class GemCostTemplateDB : GemCostTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 根据当前人物等级 获得 最高可镶嵌的宝石等级
        /// </summary>
        /// <param name="roleLevel"></param>
        /// <returns></returns>
        public int GetMaxGemLevel(int roleLevel)
        {
            int maxRoleLevel = 1;
            int maxGemLevel = 1;
            foreach (KeyValuePair<int, GemCostTemplate> pair in idKeyDic)
            {
                if (roleLevel>=pair.Value.humanLevel)
                {
                    if (pair.Value.humanLevel >= maxRoleLevel)
                    {
                        maxRoleLevel = pair.Value.humanLevel;
                        maxGemLevel = pair.Key;
                    }
                }
            }
            return maxGemLevel;
        }
    }
}
