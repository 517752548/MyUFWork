
using System.Collections.Generic;

namespace app.db
{
    public class ChargeTemplateDB : ChargeTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public List<ChargeTemplate> GetSortedChargeList()
        {
            List<ChargeTemplate> list = new List<ChargeTemplate>();
            foreach (KeyValuePair<int, ChargeTemplate> pair in idKeyDic)
            {
                list.Add(pair.Value);
            }
            list.Sort((a, b) => a.rmb.CompareTo(b.rmb));
            return list;
        }
    }
}
