
using System.Collections.Generic;

namespace app.db
{
    public class VipUpgradeTemplateDB : VipUpgradeTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 获得 当前vip等级，升级所需的充值总数，作为进度的分母
        /// </summary>
        /// <param name="curvip"></param>
        /// <returns></returns>
        public int GetCurVIPUpgradeNeedChargeTotal(int curvip)
        {
            int chargetotal = 0;
            foreach (KeyValuePair<int, VipUpgradeTemplate> pair in idKeyDic)
            {
                if (pair.Value.Id <= curvip)
                {
                    chargetotal += (int)pair.Value.requireExp;
                }
            }
            return chargetotal;
        }
    }
}
