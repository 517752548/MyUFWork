using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class LifeSkillMineTemplateDB : LifeSkillMineTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        public List<LifeSkillMineTemplate> GetMyKuangList(int mykuangLevel)
        {
            List<LifeSkillMineTemplate> list = new List<LifeSkillMineTemplate>();
            foreach (KeyValuePair<int, LifeSkillMineTemplate> pair in idKeyDic)
            {
                if (mykuangLevel >= pair.Value.openLevel)
                {
                    list.Add(pair.Value);
                }
            }
            return list;
        }
        
    }
}
