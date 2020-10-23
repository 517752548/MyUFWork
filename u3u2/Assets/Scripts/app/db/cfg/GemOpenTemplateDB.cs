using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class GemOpenTemplateDB : GemOpenTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 获取玩家开启的宝石孔数
        /// </summary>
        /// <param name="playerLevel"></param>
        public int GetOpenGridNum(int playerLevel)
        {
            int findLevel = 0;
            GemOpenTemplate gemtpl=null;
            foreach (KeyValuePair<int, GemOpenTemplate> pair in idKeyDic)
            {
                if (pair.Value.openLevel >= findLevel && playerLevel >= pair.Value.openLevel)
                {
                    findLevel = pair.Value.openLevel;
                    gemtpl = pair.Value;
                }
            }
            if (gemtpl!=null)
            {
                return gemtpl.Id;
            }
            return 0;
        }



    }
}
