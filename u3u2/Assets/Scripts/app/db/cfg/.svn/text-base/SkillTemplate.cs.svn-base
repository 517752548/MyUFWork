using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using app.utils;

namespace app.db
{
    public class SkillTemplate : SkillTemplateVO
    {
        // TODO 可能会自定义一些属性或方法

        //1	公式1  根据Skill表获取	X=min（（系数1+心法等级*心法系数）,系数2）		
        //2	公式2  根据Skill表获取	X=心法系数*心法等级
        //3	公式3  根据Skill表获取	X=技能系数*技能等级

        //4 公式4  被动技能，根据HumanSkill表获取  X=初始值+（技能等级-1）*增量

        /// <summary>
        /// 获得技能的详细效果描述
        /// </summary>
        /// <param name="xinfaLevel">该值已无用</param>
        /// <param name="skillLevel"></param>
        /// <returns></returns>
        public string GetDetailSkillDesc(int xinfaId,int xinfaLevel,int skillLevel,int skillceng)
        {
            //判断技能是 主动技能还是被动技能
            string str = descInfo;
            if (skillLevel<1)
            {//没开启的技能按照1级来算
                skillLevel = 1;
            }
            //被动技能模板
            HumanSubPassiveSkillTemplate subPassiveTpl = null;
            //心法技能模板
            HumanMainSkillToSubSkillTemplate mainSkillTpl = null;
            mainSkillTpl = HumanMainSkillToSubSkillTemplateDB.Instance.GetSkillByXinFaIdSkillId(xinfaId, Id);
            List<int> skillEffectIdList = SkillAddTemplateDB.Instance.GetSkillEffectIdList(Id, skillLevel, xinfaId, xinfaLevel);
            ///技能效果模板
            SkillEffectTemplate skillEffectTpl = null;
            if (null != skillEffectIdList && skillEffectIdList.Count > 0)
            {
                skillEffectTpl = SkillEffectTemplateDB.Instance.getTemplate(skillEffectIdList[0]);
            }

            switch (skillTypeId)
            {
                case 0:
                case 1:
                case 2:
                    return descInfo;
                case 3:
                    if (mainSkillTpl != null)
                    {
                        str = mainSkillTpl.descInfo;
                    }
                    else
                    {
                        str = descInfo;
                    }
                  
                    break;
                case 4:
                    subPassiveTpl = HumanSubPassiveSkillTemplateDB.Instance.getTemplate(Id);
                    if (mainSkillTpl!=null)
                    {
                        str = mainSkillTpl.descInfo;
                    }
                    break;
            }
            string[] leftpathArr = str.Split('{');
            if (leftpathArr.Length<=1)
            {
                return str;
            }
            //公式id数组
            List<int> gongshiIdArr = new List<int>();
            for (int i = 1; i < leftpathArr.Length; i++)
            {
                int rightIndex = leftpathArr[i].IndexOf('}');
                if (rightIndex<0)
                {
                    continue;
                }
                string gongshiIdstr = leftpathArr[i].Substring(0, rightIndex);
                leftpathArr[i] = "{" + (i - 1) + leftpathArr[i].Substring(rightIndex);
                int gongshiid = 0;
                int.TryParse(gongshiIdstr, out gongshiid);
                gongshiIdArr.Add(gongshiid);
            }
            str = "";
            for (int i = 0; i < leftpathArr.Length; i++)
            {
                str += leftpathArr[i];
            }
            string[] gongshiValueArr = new string[gongshiIdArr.Count];
            for (int i = 0; i < gongshiIdArr.Count; i++)
            {
                switch (gongshiIdArr[i])
                {
                    case 1:
                        if (mainSkillTpl == null || null == skillEffectTpl)
                        {
                            gongshiValueArr[i] = "0";
                        }
                        else
                        {
                            float x = skillEffectTpl.valueBase / 1000f;
                            gongshiValueArr[i] = x.ToString();
                                //Math.Min(Math.Floor(mainSkillTpl.coef1Desc + xinfaLevel * mainSkillTpl.mindCoefDesc),
                                //    mainSkillTpl.coef2Desc).ToString();
                        }
                        break;
                    case 2:
                        if (mainSkillTpl == null || null == skillEffectTpl)
                        {
                            gongshiValueArr[i] = "0";
                        }
                        else
                        {
                            int x = skillEffectTpl.skillLayerEffectList[skillceng-1]*(skillEffectTpl.valueAdd / 1000);
                            gongshiValueArr[i] = x.ToString();
                            //gongshiValueArr[i] = (xinfaLevel*mainSkillTpl.mindCoefDesc).ToString();
                        }
                        break;
                    case 3:
                        if (mainSkillTpl == null || null == skillEffectTpl)
                        {
                            gongshiValueArr[i] = "0";
                        }
                        else
                        {
                            gongshiValueArr[i] = skillEffectTpl.targetNum.ToString();
                            //gongshiValueArr[i] = (skillLevel*mainSkillTpl.skillCoefDesc).ToString();
                        }
                        break;
                    case 4:
                        if (subPassiveTpl == null)
                        {
                            gongshiValueArr[i] = "0";
                        }else{
                            gongshiValueArr[i] = (subPassiveTpl.baseProp + (skillLevel - 1) * subPassiveTpl.addProp).ToString();
                        }
                        break;
                    default:
                        gongshiValueArr[i] = "0";
                        break;
                }
            }
            str = StringUtil.Assemble(str, gongshiValueArr);
            return str;
        }
    }
}
