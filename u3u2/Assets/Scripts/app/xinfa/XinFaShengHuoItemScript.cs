using UnityEngine;
using System.Collections;
using app.db;

namespace app.xinfa
{
    public class XinFaShengHuoItemScript
    {
        private XinFaShengHuoItemUI UI;

        public XinFaShengHuoItemScript(XinFaShengHuoItemUI ui)
        {
            UI = ui;
        }

        public void setData(LifeSkillTemplate skillTemplate, int skilllv)
        {
            if (null != skillTemplate)
            {
                UI.m_skill_name.text = skillTemplate.name;
                UI.m_skill_lv.text = skilllv + LangConstant.JI;
                UI.icon.icon.gameObject.SetActive(true);
                if (ResType.CAI_YAO == (ResType)skillTemplate.resourceType)
                {
                    UI.gameObject.SetActive(false);
                }
                //string iconame = "";
                //switch ((ResType)skillTemplate.resourceType)
                //{
                //    case ResType.FA_MU:
                //        iconame = "";
                //        break;
                //    case ResType.CAI_YAO:
                //        iconame = "";
                //        //UI.gameObject.SetActive(false);
                //        break;
                //    case ResType.CAI_KUANG:
                //        iconame = "";
                //        break;
                //    case ResType.SHOU_LIE:
                //        iconame = "";
                //        break;
                //}
                //PathUtil.Ins.SetSkillIcon(UI.icon.icon, iconame);
            }
        }
    }
}
