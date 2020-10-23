using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class StoryTemplateDB : StoryTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 根据剧情id，获得剧情列表
        /// </summary>
        /// <param name="storyid"></param>
        /// <returns></returns>
        public List<StoryTemplate> GetStoryListById(int storyid)
        {
            List<StoryTemplate> list = new List<StoryTemplate>();

            foreach (KeyValuePair<int, StoryTemplate> pair in idKeyDic)
            {
                if (pair.Value.storyId == storyid)
                {
                    list.Add(pair.Value);
                }
            }
            list.Sort(SortStoryList);
            return list;
        }

        /// <summary>
        /// 物品的排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int SortStoryList(StoryTemplate a, StoryTemplate b)
        {
            //排序id由小到大
            if (a.Id > b.Id)
            {
                return 1;
            }
            else if (a.Id < b.Id)
            {
                return -1;
            }
            return 0;
        }
    }
}
