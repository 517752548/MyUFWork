using System.Collections.Generic;

namespace app.db
{
    public class HumanSubSkillLevelTemplateDB : HumanSubSkillLevelTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public HumanSubSkillLevelTemplate GetHumanSubSkillLevelTemplate(int skillid, int skilllevel)
        {
            foreach (KeyValuePair<int, HumanSubSkillLevelTemplate> pair in idKeyDic)
            {
                if (pair.Value.subSkillId == skillid && pair.Value.subSkillLevel == skilllevel)
                {
                    return pair.Value;
                }
            }

            return null;
        }
    }
}
