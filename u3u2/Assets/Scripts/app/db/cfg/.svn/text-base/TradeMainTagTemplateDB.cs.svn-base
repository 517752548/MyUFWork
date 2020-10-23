using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class TradeMainTagTemplateDB : TradeMainTagTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        /// <summary>
        /// 获得所有分类
        /// </summary>
        /// <returns></returns>
        public List<TradeMainTagTemplate> GetMainTagList()
        {
            List<TradeMainTagTemplate> list = new List<TradeMainTagTemplate>();
            foreach (KeyValuePair<int, TradeMainTagTemplate> pair in idKeyDic)
            {
                list.Add(pair.Value);
            }
            return list;
        }

    }
}
