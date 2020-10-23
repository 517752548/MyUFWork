using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class GemSynthesisTemplateDB : GemSynthesisTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 根据宝石的等级、合成基数 获得合成模板数据
        /// </summary>
        /// <param name="gemlevel"></param>
        /// <param name="hechengjishu"></param>
        /// <returns></returns>
        public GemSynthesisTemplate getGetSynTpl(int gemlevel,int hechengjishu)
        {
            foreach (KeyValuePair<int, GemSynthesisTemplate> pair in idKeyDic)
            {
                if (pair.Value.gemLevel==gemlevel&&pair.Value.synthesisBase==hechengjishu)
                {
                    return pair.Value;
                }
            }
            return null;
        }

    }
}
