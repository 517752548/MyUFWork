
using System.Collections.Generic;

namespace app.db
{
    public class Day7TargetTemplateDB : Day7TargetTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public List<int> GetQuestIdListByDay(int day)
        {
            List<int> list = new List<int>();
            foreach (KeyValuePair<int, Day7TargetTemplate> pair in idKeyDic)
            {
                if (pair.Value.day == day)
                {
                    list.Add(pair.Value.questId);
                }
            }
            list.Sort(sortQuest);
            return list;
        }

        private int sortQuest(int a, int b)
        {
            //排序id由小到大，无排序id在有排序id的前面
            if (a > b)
            {
                return 1;
            }
            else if (a < b)
            {
                return -1;
            }
            return 0;
        }
    }
}
