using UnityEngine;
using System.Collections;
using app.pet;
using System.Collections.Generic;
using app.db;
using app.net;

public class XiulianJinengScript :BaseUI 
{
    XinFaXiulianJinengUI UI;
    MoneyItemScript moneyItemScript1;
    MoneyItemScript moneyItemScript2;


    Dictionary<int, CorpsCultivateTemplate> templates = new Dictionary<int,CorpsCultivateTemplate>();
    Dictionary<int, SimpleSkillItemUI> skillUIs = new Dictionary<int, SimpleSkillItemUI>();

    private SimpleSkillItemUI mCurrentSkillUI;

    private bool mIsInit = false;

    private GCOpenCorpsCultivatePanel mPanelInfo;

    public GCOpenCorpsCultivatePanel panelInfo
    {
        set
        {
            mPanelInfo = value;
            SetData();
        }
    }

    public XiulianJinengScript(XinFaXiulianJinengUI UI)
    {
        this.UI = UI;
        moneyItemScript1 = new MoneyItemScript(UI.moneyItem_1);
        moneyItemScript2 = new MoneyItemScript(UI.moneyItem_2);
        UI.skillButtonGroup.TabChangeHandler = TabChangehandler;
     //   PetModel.Ins.addChangeEvent(PetModel.UPDATE_HUMAN_PROP,OnCurrencyChanged);
        GetTemplates();
        skillUIs.Clear();
        UI.objDefaultItem.SetActive(false);
        UI.btnXiulian.SetClickCallBack(OnClickXiuLian);
        UI.btnXiulianshici.SetClickCallBack(OnClickXiulianShici);
        CorpModel.Ins.addChangeEvent(CorpModel.OPEN_CULTIVATE_PANEL,GetPanelInfo);
    }

    private void GetTemplates()
    {
        Dictionary<int, CorpsCultivateTemplate> tpls = CorpsCultivateTemplateDB.Instance.getIdKeyDic();
        templates.Clear();
        foreach (var item in tpls)
        {
            templates.Add(item.Value.cultivateId,item.Value);
        }
    }

    private void GetPanelInfo(RMetaEvent e = null)
    {
        panelInfo = CorpModel.Ins.GCOpenCultivatePanel;
    }

    private void CreateSkillItem()
    {
        foreach (var item in templates)
        {
            GameObject obj = GameObject.Instantiate(UI.objDefaultItem) as GameObject;
            SimpleSkillItemUI ui = obj.GetComponent<SimpleSkillItemUI>();
            obj.transform.SetParent(UI.tfItemGrid);
            obj.SetActive(true);
            obj.transform.localScale = Vector3.one;
            skillUIs.Add(item.Key, ui);
            UI.skillButtonGroup.AddToggle(ui.toggle);
            ui.skillId = item.Value.cultivateId;
        }
    }

    private void SetData()
    {
        if (!mIsInit)
        {
            CreateSkillItem();
            mIsInit = true;
        }

        if (mPanelInfo == null)
        {
            return;
        }

        CorpsSkillInfo[] skillInfos = mPanelInfo.getCorpsSkillInfoList();
        for (int i = 0; i < skillInfos.Length; i++)
        {
            SimpleSkillItemUI ui = null;
            if(skillUIs.TryGetValue(skillInfos[i].skillId,out ui))
            {
                CorpsCultivateTemplate tpl = templates[skillInfos[i].skillId];
                PathUtil.Ins.SetSkillIcon(ui.imageIcon,tpl.icon);
                ui.textLevel.text = string.Format("LV.{0}",skillInfos[i].level);
                ui.textSkillName.text = tpl.cultivateName;
                ui.skillId = skillInfos[i].skillId;
            }
        }
        UI.skillButtonGroup.SetIndexWithCallBack(UI.skillButtonGroup.index);

    }

    private void SetUIInfoData(int index)
    {
        SimpleSkillItemUI ui = UI.skillButtonGroup.toggleList[index].gameObject.GetComponent<SimpleSkillItemUI>();
        CorpsSkillInfo info = GetSkillInfo(ui.skillId);
        if (info != null)
        {
            CorpsCultivateTemplate tpl = templates[ui.skillId];
            CorpsCultivateCostTemplate costTpl = CorpsCultivateCostTemplateDB.Instance.GetTemplateByLevel(info.level);
            UI.textSkillName.text = tpl.cultivateName + " LV "+info.level;
            UI.textSkillDescription.text = tpl.cultivateDesc;
            UI.textLevel.text = string.Format("LV.{0}",info.level);
            UI.barExp.LabelType = ProgressBarLabelType.CurrentAndMax;
            UI.barExp.MaxValue = CorpsCultivateCostTemplateDB.Instance.GetUpgradeExp(info.level) ;
            UI.barExp.Value = info.exp;
            OnCurrencyChanged();         
        }

    }

    private CorpsSkillInfo GetSkillInfo(int skillId)
    {
        if (skillId == 0)
        {
            return null;
        }
        CorpsSkillInfo[] skillInfos = mPanelInfo.getCorpsSkillInfoList();
        for (int i = 0; i < skillInfos.Length; i++)
        {
            if (skillInfos[i].skillId == skillId)
            {
                return skillInfos[i];
            }
        }
        return null;
    }

    public void TabChangehandler(int index)
    {
       mCurrentSkillUI = UI.skillButtonGroup.toggleList[index].gameObject.GetComponent<SimpleSkillItemUI>();
       ClientLog.Log(index.ToString());
       SetUIInfoData(index);
    }

    private void OnCurrencyChanged(RMetaEvent e = null)
    {
        if (UI.skillButtonGroup.toggleList.Count > 0)
        {
            SimpleSkillItemUI ui = UI.skillButtonGroup.toggleList[UI.skillButtonGroup.index].gameObject.GetComponent<SimpleSkillItemUI>();
            CorpsSkillInfo info = GetSkillInfo(ui.skillId);
            CorpsCultivateCostTemplate costTpl = CorpsCultivateCostTemplateDB.Instance.GetTemplateByLevel(info.level);
            moneyItemScript1.SetMoney(CurrencyTypeDef.GOLD, ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.XIULIANJINENG_COST_MONEY));
            moneyItemScript2.SetMoney(CurrencyTypeDef.BANGGONG, costTpl.costContri);
        }
    }

    private void OnClickXiuLian()
    {
        if (null != mCurrentSkillUI)
        {
            int costmoney = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.XIULIANJINENG_COST_MONEY);
            MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD,costmoney, (RMetaEvent) =>
            {
                CorpsCGHandler.sendCGCultivateSkill(mCurrentSkillUI.skillId, 0);
            });
        }
    }
    private void OnClickXiulianShici()
    {
        if (null != mCurrentSkillUI)
        {
            int costmoney = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.XIULIANJINENG_COST_MONEY)*10;
            MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD, costmoney, (RMetaEvent) =>
            {
                CorpsCGHandler.sendCGCultivateSkill(mCurrentSkillUI.skillId, 1);
            });
        }
    }

    public override void Destroy()
    {
   //     PetModel.Ins.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, OnCurrencyChanged);
        CorpModel.Ins.removeChangeEvent(CorpModel.OPEN_CULTIVATE_PANEL, GetPanelInfo);
        //Dictionary<int, CorpsCultivateTemplate> templates = new Dictionary<int, CorpsCultivateTemplate>();
        //Dictionary<int, SimpleSkillItemUI> skillUIs = new Dictionary<int, SimpleSkillItemUI>();
        moneyItemScript1.Destroy();
        moneyItemScript2.Destroy();
        templates.Clear();
        templates = null;
        skillUIs.Clear();
        skillUIs = null;
        base.Destroy();
        UI = null;
    }
}
