using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class SkillAddTemplateDB : SkillAddTemplateDBBase
    {
        private Dictionary<int, List<SkillAddTemplate>> mDict = new Dictionary<int, List<SkillAddTemplate>>();
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 通过技能等级和心法取技能效果。
        /// </summary>
        /// <returns>The skill effect identifier list.</returns>
        /// <param name="skillId">Skill identifier.</param>
        /// <param name="skillLv">Skill lv.</param>
        /// <param name="mindId">Mind identifier.该值已无用</param>
        /// <param name="MindLv">Mind lv.该值已无用</param>
        public List<int> GetSkillEffectIdList(int skillId, int skillLv, int mindId, int MindLv)
        {
            List<SkillAddTemplate> skillAddTpls = null;
            mDict.TryGetValue(skillId, out skillAddTpls);
            if (skillAddTpls == null)
            {
                skillAddTpls = AddListToDict(skillId);
            }

            return GetSkillEffectIdList(skillAddTpls, skillLv, mindId, MindLv);
        }

        private List<SkillAddTemplate> AddListToDict(int skillId)
        {
            List<SkillAddTemplate> list = new List<SkillAddTemplate>();
            IDictionaryEnumerator enumerator = this.getIdKeyDic().GetEnumerator();
            while (enumerator.MoveNext())
            {
                SkillAddTemplate value = (SkillAddTemplate)(enumerator.Value);
                if (value.skillId == skillId)
                {
                    list.Add(value);
                }
            }

            mDict.Add(skillId, list);
            return list;
        }

        private List<int> GetSkillEffectIdList(List<SkillAddTemplate> skillAddTpls, int skillLv, int mindId, int mindLv)
        {
            if (skillAddTpls == null)
            {
                return null;
            }

            int len = skillAddTpls.Count;
            for (int i = 0; i < len; i++)
            {
                SkillAddTemplate tpl = skillAddTpls[i];
                if (IsSkillLvSatisfySkillAddTemplate(tpl, skillLv))// && IsMindSatisfySkillAddTemplate(tpl, mindId, mindLv))
                {
                    return tpl.effectIdList;
                }
            }

            return null;
        }

        /// <summary>
        /// 技能等级是否满足模版。
        /// </summary>
        /// <returns><c>true</c> if this instance is skill lv satisfy skill add template the specified tpl skillLv; otherwise, <c>false</c>.</returns>
        /// <param name="tpl">Tpl.</param>
        /// <param name="skillLv">Skill lv.</param>
        private bool IsSkillLvSatisfySkillAddTemplate(SkillAddTemplate tpl, int skillLv)
        {
            if (tpl.skillLevelMin > 0 && tpl.skillLevelMax >= tpl.skillLevelMin)
            {
                return skillLv >= tpl.skillLevelMin && skillLv <= tpl.skillLevelMax;
            }
            return true;
        }

        /// <summary>
        /// 心法是否满足模版。
        /// </summary>
        /// <returns><c>true</c> if this instance is mind satisfy skill add template the specified tpl mindId mindLv; otherwise, <c>false</c>.</returns>
        /// <param name="tpl">Tpl.</param>
        /// <param name="mindId">Mind identifier.</param>
        /// <param name="mindLv">Mind lv.</param>
        private bool IsMindSatisfySkillAddTemplate(SkillAddTemplate tpl, int mindId, int mindLv)
        {
            if (tpl.mindId > 0)
            {
                if (mindId != tpl.mindId)
                {
                    return false;
                }
                if (tpl.mindLevelMin > 0 && tpl.mindLevelMax >= tpl.mindLevelMin)
                {
                    return mindLv >= tpl.mindLevelMin && mindLv <= tpl.mindLevelMax;
                }
                return true;
            }
            return true;
        }
    }
}