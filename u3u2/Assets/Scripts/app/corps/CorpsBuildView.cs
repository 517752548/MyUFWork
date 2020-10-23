using UnityEngine;
using System.Collections.Generic;
using app.net;
using app.zone;
using app.db;
using app.utils;
using UnityEngine.UI;

public enum BUILDING_TYPE
{
    /** 建筑类型,1朱雀,2青龙,3白虎,4朱雀,5玄武,6养生,7侍剑 */
    JUXIANTANG = 1,
    QINGLONGTANG = 2,
    BAIHUTANG = 3,
    ZHUQUETANG = 4,
    XUANWUTANG = 5,
    YANGSHENGTANG = 6,
    SHIJIANTANG = 7
}
public class CorpsBuildView : BaseUI
{

    private BangPaiJianSheUI jiansheUI;
    private CorpModel mCorpModel;
    Dictionary<int, CorpsUpgradeTemplate> corpsUpgradeTemplates;
    private List<string> mBuildingNames = new List<string>(); 


    public CorpsBuildView(BangPaiJianSheUI jiansheUI)
    {
        this.jiansheUI = jiansheUI;
        mBuildingNames.Add("聚义堂");
        mBuildingNames.Add("朱雀堂");
        mBuildingNames.Add("侍剑堂");
        Init();
    }

    private void Init()
    {
        jiansheUI.tabButtonGroup.TabChangeHandler = TabChangeHandler;
        jiansheUI.tabButtonGroup.SetIndexWithCallBack(0);
        jiansheUI.buttonUpgrade.SetClickCallBack(OnClickUpgrade);
        jiansheUI.needExpProgressbar.LabelType = ProgressBarLabelType.CurrentAndMax;
        jiansheUI.needMoneyProgressbar.LabelType = ProgressBarLabelType.CurrentAndMax;
        mCorpModel = CorpModel.Ins;
        mCorpModel.addChangeEvent(CorpModel.OPEN_CORP_BUILDING_PANEL, OpenBuildingPanel);
        mCorpModel.addChangeEvent(CorpModel.CORPS_UPGRADE_RESULT, CorpsUpgradeResult);
        mCorpModel.addChangeEvent(CorpModel.CORPS_DEGRADE_INFO, CorpsDegrade);

        mCorpModel.addChangeEvent(CorpModel.ON_BUILDING_TIMER, OnUpgradeTimer);
        mCorpModel.addChangeEvent(CorpModel.ON_BUILDING_TIMER_END, OnUpgradeTimerEnd);
        corpsUpgradeTemplates = CorpsUpgradeTemplateDB.Instance.getIdKeyDic();
        InitToggleLists();
    }
    public override void show(RMetaEvent e = null)
    {
        base.show(e);
        jiansheUI.tabButtonGroup.SetIndexWithCallBack(0);
    }

    private void InitToggleLists()
    {
        for (int i = 0; i < mBuildingNames.Count; i++)
        {
            jiansheUI.tabButtonGroup.toggleList[i].gameObject.SetActive(true);
            Text text = jiansheUI.tabButtonGroup.toggleList[i].transform.Find("Label").GetComponent<Text>();
            text.text = mBuildingNames[i];
        }
        for (int i = mBuildingNames.Count; i < jiansheUI.tabButtonGroup.toggleList.Count; i++)
        {
            jiansheUI.tabButtonGroup.toggleList[i].gameObject.SetActive(false);
        }
    }

    private void TabChangeHandler(int index)
    {
        CallBuildingPanelInfo(GetBuildingTypeByIndex(index));
    }

    private int GetBuildingTypeByIndex(int index)
    {
        switch (index)
        {
            case 0:
                return (int)BUILDING_TYPE.JUXIANTANG;
            case 1:
                return (int)BUILDING_TYPE.ZHUQUETANG;
            case 2:
                return (int)BUILDING_TYPE.SHIJIANTANG;
        }
        return -1;
    }

    private void OpenBuildingPanel(RMetaEvent e = null)
    {
        GCOpenCorpsBuildingPanel buildingPanel = e.data as GCOpenCorpsBuildingPanel;
        if (buildingPanel.getCorpsBuildingInfo().buildType == GetBuildingTypeByIndex(jiansheUI.tabButtonGroup.index))
        {
            SetData();
        }
       
    }

    private void CorpsUpgradeResult(RMetaEvent e = null)
    {

        CorpsCGHandler.sendCGOpenCorpsPanel();
        GCUpgradeCorps upgradeCorps = e.data as GCUpgradeCorps;
        /** 升级结果,1成功,2失败 */
        int result = upgradeCorps.getResult();
        if (result != 1)
        {
            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CORPS_UPGRADE_FAIL_TISHI);
        }
        else if(upgradeCorps.getBuildType() == GetBuildingTypeByIndex(jiansheUI.tabButtonGroup.index))
        {
            SetData();
        }

    }

    private void CorpsDegrade(RMetaEvent e = null)
    {
        if (GetBuildingTypeByIndex(jiansheUI.tabButtonGroup.index) == (int)BUILDING_TYPE.JUXIANTANG)
        {
            SetData();
        }
    }

    private void SetData()
    {
        if (mCorpModel.corpsBuildingInfos == null || mCorpModel.detailCorpsInfo == null)
        {
            return;
        }
        int currentType = GetBuildingTypeByIndex(jiansheUI.tabButtonGroup.index);
        CorpsBuildingInfo currentBuildingInfo = mCorpModel.GetBuildingInfoByType(currentType);
        CorpsBuildingUpgradeTemplate corpTemplate = CorpsBuildingUpgradeTemplateDB.Instance.GetTemplateByTL(currentType,currentBuildingInfo.buildingLevel);


        if (corpTemplate == null)
        {
            return;
        }

        jiansheUI.objNeedExp.SetActive(currentType == (int)BUILDING_TYPE.JUXIANTANG);

        //get topLevet Build
        bool isTopLevel = false;

        CorpsBuildingUpgradeTemplate topTemplate = CorpsBuildingUpgradeTemplateDB.Instance.GetTopLevelTpl(currentType);

        isTopLevel = topTemplate.corpsBldgLevel == currentBuildingInfo.buildingLevel;


        jiansheUI.textTarget.text = currentBuildingInfo.buildingLevel + LangConstant.JI + " " + GetBuildingName(jiansheUI.tabButtonGroup.index);
        jiansheUI.textBuildingDesc.text = GetDesc(currentType);

        bool isUpgrading = currentBuildingInfo.upgradeCountDownTime > 0;

        bool needShowExp = currentType == (int)BUILDING_TYPE.JUXIANTANG;

        jiansheUI.objNeedExp.SetActive(!isUpgrading && !isTopLevel&&needShowExp);
        jiansheUI.objNeedMoney.SetActive(!isUpgrading && !isTopLevel);
        jiansheUI.objShengjiZhong.SetActive(isUpgrading && !isTopLevel);
        jiansheUI.textRemainTime.gameObject.SetActive(isUpgrading && !isTopLevel);

        if (isTopLevel) 
        {
            jiansheUI.objTopLevel.SetActive(true);
            return;
        }
        else
        {
            jiansheUI.objTopLevel.SetActive(false);
        }


        if (isUpgrading)
        {
            jiansheUI.textRemainTime.text = LangConstant.IS_BUILDING_COST_TIME + "：  " + TimeString.getTimeString((int)currentBuildingInfo.upgradeCountDownTime);
            if (jiansheUI.buttonUpgrade.IsInteractable())
            {
                jiansheUI.buttonUpgrade.interactable = false;
                ColorUtil.Gray(jiansheUI.buttonUpgrade);
            }
        }

        else
        {
            if (needShowExp)
            {
                jiansheUI.needExpProgressbar.setLongPercent(corpTemplate.upgradeExp, mCorpModel.detailCorpsInfo.currExp);
            }
            jiansheUI.needMoneyProgressbar.setLongPercent(corpTemplate.upgradeFund, mCorpModel.detailCorpsInfo.currFund);
            if (mCorpModel.MyCorpMemberInfo.getCorpsMemInfo().memJob == (int)CorpTitleDef.CorpTitleType.BANGZHU)
            {
                if (!jiansheUI.buttonUpgrade.IsInteractable())
                {
                    ColorUtil.DeGray(jiansheUI.buttonUpgrade);
                    jiansheUI.buttonUpgrade.interactable = true;
                }
            }
            else
            {
                if (jiansheUI.buttonUpgrade.IsInteractable())
                {
                    jiansheUI.buttonUpgrade.interactable = false;
                    ColorUtil.Gray(jiansheUI.buttonUpgrade);
                }
            }
        }
    }

    private string GetBuildingName(int index)
    {
        if (index >= 0 && index < mBuildingNames.Count)
        {
            return mBuildingNames[index];
        }
        return "";
    }

    private string GetDesc(int type)
    {
        switch (type)
        {
            case (int)BUILDING_TYPE.JUXIANTANG:
                return "聚义堂等级决定帮派等级、帮派修炼上限\n\n其他建筑等级不能超过聚义堂等级";
            case (int)BUILDING_TYPE.ZHUQUETANG:
                return "提升朱雀堂等级可增加修炼技能上限。";
            case (int)BUILDING_TYPE.SHIJIANTANG:
                return "提升侍剑堂等级可增加辅助技能生产效率。";
        }
        return "";
    }

    private void OnUpgradeTimer(RMetaEvent e = null)
    {
        RTimer timer = e.data as RTimer;
        if (jiansheUI)
        {
            jiansheUI.textRemainTime.text = LangConstant.IS_BUILDING_COST_TIME + "：  " + TimeString.getTimeString((int)(timer.getLeftTime() / 1000.0f));
        }
    }

    private void OnUpgradeTimerEnd(RMetaEvent e = null)
    {
        int currentType = GetBuildingTypeByIndex(jiansheUI.tabButtonGroup.index);
        CallBuildingPanelInfo(currentType);
    }

    public void CallBuildingPanelInfo(int index)
    {
        CorpsCGHandler.sendCGOpenCorpsBuildingPanel(index);
    }

    private void OnClickUpgrade()
    {
        CorpsBuildingInfo buildingInfo = CorpModel.Ins.GetBuildingInfoByType(GetBuildingTypeByIndex(jiansheUI.tabButtonGroup.index));
        if (buildingInfo != null && buildingInfo.upgradeCountDownTime == 0
            && mCorpModel.MyCorpMemberInfo.getCorpsMemInfo().memJob == (int)CorpTitleDef.CorpTitleType.BANGZHU)
        {
            CorpsCGHandler.sendCGUpgradeCorps(buildingInfo.buildType);
            CallBuildingPanelInfo(buildingInfo.buildType);
        }

    }


    public override void Destroy()
    {
        mCorpModel.removeChangeEvent(CorpModel.OPEN_CORP_BUILDING_PANEL, OpenBuildingPanel);
        mCorpModel.removeChangeEvent(CorpModel.CORPS_UPGRADE_RESULT, CorpsUpgradeResult);
        mCorpModel.removeChangeEvent(CorpModel.CORPS_DEGRADE_INFO, CorpsDegrade);
        mCorpModel.removeChangeEvent(CorpModel.ON_BUILDING_TIMER, OnUpgradeTimer);
        mCorpModel.removeChangeEvent(CorpModel.ON_BUILDING_TIMER_END, OnUpgradeTimerEnd);
        base.Destroy();
        this.jiansheUI = null;
    }

}
