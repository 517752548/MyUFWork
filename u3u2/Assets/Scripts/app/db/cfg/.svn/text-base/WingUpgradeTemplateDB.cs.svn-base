using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace app.db
{
    public class WingUpgradeTemplateDB : WingUpgradeTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 根据翅膀的 模板id和阶数
        /// </summary>
        /// <param name="wingTplId"></param>
        /// <param name="jie"></param>
        /// <returns></returns>
        public WingUpgradeTemplate GetTplByIdAndJie(int wingTplId, int jie)
        {
            foreach (KeyValuePair<int, WingUpgradeTemplate> pair in idKeyDic)
            {
                if (pair.Value.wingTplId == wingTplId && pair.Value.wingLevel == jie)
                {
                    return pair.Value;
                }
            }
            return null;
        }

    }
}
