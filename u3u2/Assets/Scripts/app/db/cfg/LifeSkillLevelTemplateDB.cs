
namespace app.db
{
    public class LifeSkillLevelTemplateDB : LifeSkillLevelTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        public LifeSkillLevelTemplate GetSkillLevel(int skillid,int lv)
        {

            foreach (LifeSkillLevelTemplate pair in idKeyDic.Values)
            {
                if (pair.lifeSkillId == skillid && pair.lifeSkillLevel == lv)
                {
                    return pair;
                }
            }
            return null;
        }
    }
}
