using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class LifeSkillMineMinerTemplateDB : LifeSkillMineMinerTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public List<LifeSkillMineMinerTemplate> GetAllAI()
        {
            List<LifeSkillMineMinerTemplate> list = new List<LifeSkillMineMinerTemplate>();
            foreach (KeyValuePair<int, LifeSkillMineMinerTemplate> pair in idKeyDic)
            {
                list.Add(pair.Value);
            }
            return list;
        }
    }
}
