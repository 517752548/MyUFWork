using System.Collections.Generic;

namespace app.db
{
    public class ExchangeTemplateDB : ExchangeTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public int GetScale(int costid, int exchangeid)
        {
            foreach (KeyValuePair<int, ExchangeTemplate> pair in idKeyDic)
            {
                if (pair.Value.costId == costid && pair.Value.exchangeId == exchangeid)
                {
                    return pair.Value.scale;
                }
            }
            return 1;
        }
    }
}
