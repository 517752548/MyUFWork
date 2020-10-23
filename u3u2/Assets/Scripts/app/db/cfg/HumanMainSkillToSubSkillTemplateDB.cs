using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.db
{
    public class HumanMainSkillToSubSkillTemplateDB : HumanMainSkillToSubSkillTemplateDBBase
    {
        // TODO 可能会自定义一些属性或方法

        /// <summary>
        /// 根据心法Id获得技能列表
        /// </summary>
        /// <param name="xinfaId"></param>
        /// <returns></returns>
        public List<HumanMainSkillToSubSkillTemplate> GetSkillListByXinFaId(int xinfaId)
        {
            List<HumanMainSkillToSubSkillTemplate> list  = new List<HumanMainSkillToSubSkillTemplate>();
            foreach (KeyValuePair<int, HumanMainSkillToSubSkillTemplate> pair in idKeyDic)
            {
                if (pair.Value.mainSkillId == xinfaId)
                {
                    list.Add(pair.Value);
                }
            }
            list.Sort(Sortor);
            return list;
        }

        /// <summary>
        /// 根据心法Id,技能id 获得技能
        /// </summary>
        /// <param name="xinfaId"></param>
        /// <returns></returns>
        public HumanMainSkillToSubSkillTemplate GetSkillByXinFaIdSkillId(int xinfaId,int skillId)
        {
            foreach (KeyValuePair<int, HumanMainSkillToSubSkillTemplate> pair in idKeyDic)
            {
                if (pair.Value.mainSkillId == xinfaId && pair.Value.subSkillId == skillId)
                {
                    return pair.Value;
                }
            }
            return null;
        }

        public int GetXinFaIdBySkillId(int skillId)
        {
            foreach (KeyValuePair<int, HumanMainSkillToSubSkillTemplate> pair in idKeyDic)
            {
                if (pair.Value.subSkillId == skillId)
                {
                    return pair.Value.mainSkillId;
                }
            }
            return -1;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Sortor(HumanMainSkillToSubSkillTemplate a, HumanMainSkillToSubSkillTemplate b)
        {
            //排序按照index由小到大
            if (a.subSkillId > b.subSkillId)
            {
                return 1;
            }
            else if (a.subSkillId < b.subSkillId)
            {
                return -1;
            }
            return 0;
        }
    }
}
