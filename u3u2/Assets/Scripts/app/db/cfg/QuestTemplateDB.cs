using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class QuestTemplateDB : QuestTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public List<QuestTemplate> GetQuestTplList(QuestDefine.QuestType questtype)
        {
            List<QuestTemplate> questinfodata = new List<QuestTemplate>();
            foreach (KeyValuePair<int, QuestTemplate> pair in idKeyDic)
            {
                if (pair.Value.questType == (int)questtype)
                {
                    questinfodata.Add(pair.Value);
                }
            }
            questinfodata.Sort(sortQuest);
            return questinfodata;
        }

        private int sortQuest(QuestTemplate a, QuestTemplate b)
        {
            //排序id由小到大，无排序id在有排序id的前面
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
