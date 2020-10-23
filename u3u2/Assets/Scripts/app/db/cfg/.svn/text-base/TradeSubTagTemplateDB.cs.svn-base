using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class TradeSubTagTemplateDB : TradeSubTagTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 获得一级分类下所有的二级分类，并按照显示排序
        /// </summary>
        /// <param name="maintag"></param>
        /// <returns></returns>
        public List<TradeSubTagTemplate> GetSubTagListByMainTag(int maintag)
        {
            List<TradeSubTagTemplate> subTagList=new List<TradeSubTagTemplate>();
            foreach (KeyValuePair<int, TradeSubTagTemplate> pair in idKeyDic)
            {
                if (pair.Value.mainTagId==maintag)
                {
                    subTagList.Add(pair.Value);
                }
            }
            subTagList.Sort((a,b)=>(a.displayIndex.CompareTo(b.displayIndex)));
            return subTagList;
        }

    }
}
