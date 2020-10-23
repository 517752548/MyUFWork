using System.Collections.Generic;

namespace app.db
{
    public class LifeSkillTemplateDB : LifeSkillTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法
        List<LifeSkillTemplate> result = null;
        public List<LifeSkillTemplate> GetAllSkill()
        {
            if (null == result)
            {
                result = new List<LifeSkillTemplate>();
                foreach (LifeSkillTemplate pair in idKeyDic.Values)
                {
                    result.Add(pair);
                }
                SortList();
            }
            return result;
        }

        private void SortList()
        {
            LifeSkillTemplate temp;
            for (int j = 0; j < result.Count - 1; j++)
            {
                for (int i = 0; i < result.Count - 1 - j; i++)
                {
                    if (result[i].resourceType > result[i + 1].resourceType)
                    {
                        temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                    }
                }
            }
        }
        
    }
}
