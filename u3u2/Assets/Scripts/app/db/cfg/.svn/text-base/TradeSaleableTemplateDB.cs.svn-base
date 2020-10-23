using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class TradeSaleableTemplateDB : TradeSaleableTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public bool IsSaleable(int templateId)
        {
            foreach (KeyValuePair<int, TradeSaleableTemplate> pair in idKeyDic)
            {
                if (pair.Value.templateId==templateId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
