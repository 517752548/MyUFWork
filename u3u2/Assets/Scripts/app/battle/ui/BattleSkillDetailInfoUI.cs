using app.human;
using app.role;
using UnityEngine;
using app.db;
using app.net;

namespace app.battle
{
    public class BattleSkillDetailInfoUI
    {
        public BattleSkillDetailInfoUIBehav UI { get; private set; }

        public bool isShown { get; private set; }
        
        public BattleSkillDetailInfoUI(BattleSkillDetailInfoUIBehav UI)
        {
            this.UI = UI;
            InitUI();
        }

        private void InitUI()
        {
            isShown = false;
        }

        public void Show(PetSkillInfo skillInfo, SkillTemplate skillTpl)
        {
            SetData(skillInfo, skillTpl);
            UI.gameObject.SetActive(true);
            isShown = true;
        }

        private void SetData(PetSkillInfo skillInfo, SkillTemplate skillTpl)
        {
            UI.icon.gameObject.SetActive(false);

            if (skillInfo != null && skillTpl != null)
            {
                //string path = PathUtil.Ins.GetUITexturePath(skillTpl.icon, PathUtil.TEXTUER_SKILL);
                //SourceLoader.Ins.load(path, OnIconLoaded);
                PathUtil.Ins.SetSkillIcon(UI.icon, skillTpl.icon + "-1");
                UI.nameTxt.text = skillTpl.name;
                UI.levelTxt.text = LangConstant.LEVEL_NAME + ": " + skillInfo.level;
                UI.costTxt.text = LangConstant.CONSUME + ": " + skillInfo.skillCost + ClientConstantDef.GetSkillCostTypeName(skillTpl.costTypeId);
                //int mindId = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.MAINSKILL_TYPE);
                //int mindLv = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.MAINSKILL_LEVEL);
                int xinfaid = HumanMainSkillToSubSkillTemplateDB.Instance.GetXinFaIdBySkillId(skillInfo.skillId);
                UI.descTxt.text = skillTpl.GetDetailSkillDesc(xinfaid, 0, skillInfo.level, skillInfo.layer);
            }
            else
            {
                UI.nameTxt.text = "";
                UI.levelTxt.text = "";
                UI.costTxt.text = "";
                UI.descTxt.text = "";

                if (skillInfo == null)
                {
                    ClientLog.LogError("目标身上没有所选技能");
                }

                if (skillTpl == null)
                {
                    ClientLog.LogError("没有找到所选技能的模版");
                }
            }
        }
        /*
        private void OnIconLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                LoadInfo info = (LoadInfo)(e.data);
                string path = info.urlPath;
                Texture t = SourceManager.Ins.GetAsset<Texture>(path);
                if (t != null)
                {
                    UI.icon.texture = t;
                    UI.icon.SetNativeSize();
                    UI.icon.gameObject.SetActive(true);
                }
            }
        }
        */

        public void Hide()
        {
            UI.gameObject.SetActive(false);
            isShown = false;
        }
    }
}