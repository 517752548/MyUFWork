using UnityEngine;
using System.Collections;
using app.human;
using app.role;
using app.pet;
using app.net;
using app.db;
using System.Collections.Generic;
using app.reward;
using UnityEngine.EventSystems;
using app.tips;
using app.utils;
using app.zone;

public class FuzhujinengScript : BaseUI
{
    XinFaFuzhuJinengUI UI;
    MoneyItemScript moneyItem1;
    MoneyItemScript moneyItem2;
    MoneyItemScript moneyItemHuoli;

    private GCOpenCorpsAssistPanel mPanelInfo;

    Dictionary<int, CorpsAssistTemplate> templates;
    Dictionary<int, SimpleSkillItemUI> skillUIs = new Dictionary<int, SimpleSkillItemUI>();

    Dictionary<int, List<CorpsAssistGenTemplate>> skillGenerate = new Dictionary<int, List<CorpsAssistGenTemplate>>();

    private List<CorpsAssistGenTemplate> mCurrentGenTpls;

    private int mCurrentLevelFlag = 0;

    private bool mIsInit = false; 

    private SimpleSkillItemUI mCurrentSkillItem;

    private List<CorpsAssistGenTemplate> currentShowTpls;

    private int currentIndex = -1;

    public FuzhujinengScript(XinFaFuzhuJinengUI UI)
    {
        this.UI = UI;
        moneyItem1 = new MoneyItemScript(UI.moneyItemUI1);
        moneyItem2 = new MoneyItemScript(UI.moneyItemUI2);
        moneyItemHuoli = new MoneyItemScript(UI.moneyItemUI_huoli);
        UI.skillButtonGroup.TabChangeHandler = ChangeToggle;
        CorpModel.Ins.addChangeEvent(CorpModel.OPEN_ASSIST_PANEL,OpenPanelInfo);
        templates = CorpsAssistTemplateDB.Instance.GetSkillIdkeyDic();
        InitSkillGenerate();
        UI.btnDazaoLeftArrow.SetClickCallBack(OnClickLevelLeftLevel);
        UI.btnDazaoRightArrow.SetClickCallBack(OnClickLevelRightLevel);
        UI.btnZhizuo.SetClickCallBack(OnClickZhiZuo);
        UI.btnLearnSkill.SetClickCallBack(OnClickLearnSkill);
        for (int i = 0; i < UI.pengrenUIs.Length; i++)
        {
            UI.pengrenUIs[i].ClickCommonItemHanderObj = OnClickItem;
        }
        UI.objDefaultSkillItem.SetActive(false);
    }


    private void InitSkillGenerate()
    {
        Dictionary<int, CorpsAssistGenTemplate> generateTpls = CorpsAssistGenTemplateDB.Instance.getIdKeyDic();
        foreach (var item in generateTpls)
        {
            if (!skillGenerate.ContainsKey(item.Value.assistId))
            {
                skillGenerate.Add(item.Value.assistId, new List<CorpsAssistGenTemplate>());
            }
            skillGenerate[item.Value.assistId].Add(item.Value);
        }

    }

    private void OpenPanelInfo(RMetaEvent e = null)
    {
        mPanelInfo = CorpModel.Ins.GCOpenCorpsAssistPanel;
        SetData();
    }

    private void CreateSkillItem()
    {
        foreach (var item in templates)
        {
            GameObject obj = GameObject.Instantiate(UI.objDefaultSkillItem) as GameObject;
            SimpleSkillItemUI ui = obj.GetComponent<SimpleSkillItemUI>();
            obj.transform.SetParent(UI.tfSkillGrid);
            obj.SetActive(true);
            obj.transform.localScale = Vector3.one;
            skillUIs.Add(item.Key, ui);
            UI.skillButtonGroup.AddToggle(ui.toggle);
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
            if (skillUIs.TryGetValue(skillInfos[i].skillId, out ui))
            {
                CorpsAssistTemplate tpl = templates[skillInfos[i].skillId];
                 PathUtil.Ins.SetSkillIcon(ui.imageIcon,tpl.icon);
                ui.textLevel.text = string.Format("LV.{0}", skillInfos[i].level);
                ui.textSkillName.text = tpl.assistName;
                ui.skillId = skillInfos[i].skillId;
            }
        }
        UI.skillButtonGroup.SetIndexWithCallBack(UI.skillButtonGroup.index);
    }

    private CorpsSkillInfo GetSkillInfo(int skillId)
    {
        CorpsSkillInfo[] infos = mPanelInfo.getCorpsSkillInfoList();
        for (int i = 0; i < infos.Length; i++)
        {
            if (infos[i].skillId == skillId)
            {
                return infos[i];
            }
        }
        return null;
    }

    private CorpsAssistGenTemplate GetGenTpl(int skillId,int level)
    {
        List<CorpsAssistGenTemplate> tpls = skillGenerate[skillId];
        tpls.Sort(delegate(CorpsAssistGenTemplate x, CorpsAssistGenTemplate y) {
            return x.assistLevel.CompareTo(y.assistLevel);
        });

        for (int i = 0; i < tpls.Count; i++)
        {


            if (i < tpls.Count - 1 )
            {
                if(tpls[i].assistLevel <= level && tpls[i+1].assistLevel > level)
                {
                    return tpls[i];
                }             
            }
            else if (tpls[i].assistLevel <= level)
            {
                return tpls[i];
            }
        }
        return null;
    }

    private void ChangeToggle(int index)
    {
        mCurrentSkillItem = UI.skillButtonGroup.toggleList[index].gameObject.GetComponent<SimpleSkillItemUI>();
        CorpsAssistTemplate corpsTpl = templates[mCurrentSkillItem.skillId];

        if (corpsTpl.genType == 0)
        {
            UI.objDazao.SetActive(false);
            UI.objPengren.SetActive(true);
            SetPengren();
        }
        else
        {
            UI.objDazao.SetActive(true);
            UI.objPengren.SetActive(false);
            SetDazao();
        }       
    }

    private void SetDazao()
    {
        CorpsSkillInfo skillInfo = GetSkillInfo(mCurrentSkillItem.skillId);
        if (currentIndex != UI.skillButtonGroup.index)
        {
            mCurrentGenTpls = skillGenerate[mCurrentSkillItem.skillId];
            mCurrentGenTpls.Sort(delegate(CorpsAssistGenTemplate x, CorpsAssistGenTemplate y)
            {
                return x.assistLevel.CompareTo(y.assistLevel);
            });
            mCurrentLevelFlag = 0;
            UI.textDazaoLevel.text = mCurrentGenTpls[mCurrentLevelFlag].genDesc;
            CheckArrowState();
            currentIndex = UI.skillButtonGroup.index;
        }
    
        CorpsAssistTemplate tpl = templates[mCurrentSkillItem.skillId];
        UI.text_skillName.text = tpl.assistName + "LV" + skillInfo.level;
        OnCurrencyChanged();
    }

    private void OnClickLevelRightLevel()
    {
        ///等级不足时无法向下翻页///
        CorpsSkillInfo skillInfo = GetSkillInfo(mCurrentSkillItem.skillId);
        if (mCurrentGenTpls[mCurrentLevelFlag + 1].assistLevel > skillInfo.level)
        {
            List<Dictionary<string, string>> content = new List<Dictionary<string, string>>();
            string valueStr = LangConstant.FUZHU_RIGHT_ARROW;
            Dictionary<string, string> textDict = new Dictionary<string, string>();
            textDict.Add("type", "text");
            textDict.Add("text", valueStr);
            content.Add(textDict);
            ZoneBubbleManager.ins.BubbleRichText(content, "bubbleBackground", false, null, 0, ZoneBubbleContentType.DEFAULT);
            return;
        }
        mCurrentLevelFlag++;
        UI.textDazaoLevel.text = mCurrentGenTpls[mCurrentLevelFlag].genDesc;
        CheckArrowState();
    }

    private void OnClickLevelLeftLevel()
    {
        mCurrentLevelFlag--;
        UI.textDazaoLevel.text = mCurrentGenTpls[mCurrentLevelFlag].genDesc;
        CheckArrowState();
    }

    private void CheckArrowState()
    {
        if (mCurrentLevelFlag >= (mCurrentGenTpls.Count - 1))
        {
            UI.btnDazaoRightArrow.gameObject.SetActive(false);
        }
        else
        {
            UI.btnDazaoRightArrow.gameObject.SetActive(true);
        }
        if (mCurrentLevelFlag <= 0)
        {
            UI.btnDazaoLeftArrow.gameObject.SetActive(false);
        }
        else
        {
            UI.btnDazaoLeftArrow.gameObject.SetActive(true);
        }
    }

    private void SetPengren()
    {
        CorpsSkillInfo skillinfo = GetSkillInfo(mCurrentSkillItem.skillId);
        currentShowTpls = skillGenerate[mCurrentSkillItem.skillId];
        currentShowTpls.Sort(delegate(CorpsAssistGenTemplate x, CorpsAssistGenTemplate y)
        {
            return x.assistLevel.CompareTo(y.assistLevel);
        });

        for (int i = 0; i < currentShowTpls.Count; i++)
        {
            ItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(currentShowTpls[i].itemId);
            PathUtil.Ins.SetItemIcon( UI.pengrenUIs[i].icon,itemTpl.icon);
            if (skillinfo.level < currentShowTpls[i].assistLevel)
            {
                UI.pengrenUIs[i].num.gameObject.SetActive(true);
                UI.pengrenUIs[i].num.text = ColorUtil.getColorText(ColorUtil.RED_ID, string.Format("LV.{0}", currentShowTpls[i].assistLevel));
            }
            else
            {
                UI.pengrenUIs[i].num.gameObject.SetActive(false);
            }
        }
        CorpsAssistTemplate tpl = templates[mCurrentSkillItem.skillId];
        UI.text_skillName.text = tpl.assistName + "LV " + skillinfo.level;
        OnCurrencyChanged();
        
    }

    private void OnCurrencyChanged(RMetaEvent e = null)
    {
        CorpsAssistCostTemplate costTpl = CorpsAssistCostTemplateDB.Instance.GetTplByLevel(GetSkillInfo(mCurrentSkillItem.skillId).level);
        if (costTpl != null)
        {
            CorpsSkillInfo skillInfo = GetSkillInfo(mCurrentSkillItem.skillId);
            CorpsAssistGenTemplate genTpl = GetGenTpl(skillInfo.skillId,skillInfo.level);
            moneyItem1.SetMoney(CurrencyTypeDef.GOLD, costTpl.costCurrency);
            moneyItem2.SetMoney(CurrencyTypeDef.BANGGONG, costTpl.costContri);
            moneyItemHuoli.SetMoney(CurrencyTypeDef.HUOLI,genTpl == null? 0 : genTpl.costEnergy);
        }
    }

    private void OnClickZhiZuo()
    {
        CorpsCGHandler.sendCGMakeItem(mCurrentSkillItem.skillId, mCurrentGenTpls == null ? 0 : mCurrentGenTpls[mCurrentLevelFlag].assistLevel);
    }

    private void OnClickLearnSkill()
    {
        CorpsAssistCostTemplate costTpl = CorpsAssistCostTemplateDB.Instance.GetTplByLevel(GetSkillInfo(mCurrentSkillItem.skillId).level);
        if (costTpl != null)
        {
            MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD, costTpl.costCurrency, sureHandler);
        }
    }

    private void sureHandler(RMetaEvent e)
    {
        CorpsCGHandler.sendCGLearnAssistSkill(mCurrentSkillItem.skillId);
    }

    private void OnClickItem(PointerEventData eventData)
    {
        int index = -1;
        for (int i = 0; i < UI.pengrenUIs.Length; i++)
			{
                if (UI.pengrenUIs[i].gameObject == eventData.pointerPress)
                {
                    index = i;
                }
			}
        if (index != -1)
        {
            ItemTips.Ins.ShowTips(currentShowTpls[index].itemId);
        }
    }



    public override void Destroy()
    {
    //    PetModel.Ins.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, OnCurrencyChanged);
        CorpModel.Ins.removeChangeEvent(CorpModel.OPEN_ASSIST_PANEL, OpenPanelInfo);
        moneyItem1.Destroy();
        moneyItem2.Destroy();
        moneyItemHuoli.Destroy(); ;

        mPanelInfo = null;
        if (templates != null)
        {
            templates.Clear();
            templates = null;
        }
        if (skillUIs != null)
        {
            skillUIs.Clear();
            skillUIs = null;
        }

        if (skillGenerate != null)
        {
            skillGenerate.Clear();
            skillGenerate = null;
        }
        if (mCurrentGenTpls != null)
        {
            mCurrentGenTpls.Clear();
            mCurrentGenTpls = null;
        }
        if (currentShowTpls != null)
        {
            currentShowTpls.Clear();
            currentShowTpls = null;
        }
        base.Destroy();
        UI = null;
    }

}
