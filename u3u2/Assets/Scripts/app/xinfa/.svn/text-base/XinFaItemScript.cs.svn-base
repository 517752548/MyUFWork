using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.db;
using app.human;
using app.role;
using UnityEngine;

namespace app.xinfa
{
    public class XinFaItemScript
    {
        public XinFaItemUI UI;
        private HumanMainSkillTemplate tpl;

        public XinFaItemScript(XinFaItemUI ui)
        {
            UI = ui;
            UI.icon.gameObject.SetActive(false);
        }

        public XinFaItemUI Ui
        {
            get { return UI; }
        }

        public void setData(HumanMainSkillTemplate template)
        {
            tpl = template;
            Ui.xinfaName.text = template.name + " " + XinFaModel.instance.GetXinFaLevel(tpl.Id) + LangConstant.JI;
            Ui.xinfaDesc.text = template.mainSkillTypeDetail;
            UI.icon.gameObject.SetActive(true);
            ////PathUtil.Ins.SetRawImageSource(UI.icon, tpl.Id.ToString(), PathUtil.XINFA_ICON);
            string idstr = template.Id.ToString();
            PathUtil.Ins.SetXinFaIcon(UI.icon, idstr);
        }

        public void updateLevel()
        {
            if (null != tpl)
            {
                Ui.xinfaName.text = tpl.name + " " + XinFaModel.instance.GetXinFaLevel(tpl.Id) + LangConstant.JI;
            }
        }

        public void Destroy()
        {
            tpl = null;
            GameObject.DestroyImmediate(UI.gameObject);
            UI = null;
        }
    }
}