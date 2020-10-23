using System.Collections.Generic;
using System.Linq;
using app.corp;
using app.net;
using app.db;

public class CorpModel : AbsModel
{
    public const string UPDATE_CORPSLIST = "UPDATE_CORPSLIST";

    public const string UPDATE_CURRENT_CORP = "UPDATE_CURRENT_CORP";

    public const string UPDATE_MY_CORP_INFO = "UPDATE_MY_CORP_INFO";

    public const string UPDATE_CORP_MEMBER_LIST = "UPDATE_CORP_MEMBER_LIST";

    public const string UPDATE_MY_CORP_MEMBER_INFO = "UPDATE_MY_CORP_MEMBER_INFO";

    public const string UPDATE_SEARCH_RESULT = "UPDATE_SEARCH_RESULT";

    public const string OPEN_CORP_BUILDING_PANEL = "OPEN_CORP_BUILDING_PANEL";

    public const string CORPS_UPGRADE_RESULT = "CORPS_UPGRADE_RESULT";

    public const string CORPS_DEGRADE_INFO = "CORPS_DEGRADE_INFO";

    public const string GET_CORPS_BENIFITINFO = "GET_CORPS_BENIFITINFO";

    public const string ON_BUILDING_TIMER = "ON_BUILDING_TIMER";

    public const string ON_BUILDING_TIMER_END = "ON_BUILDING_TIMER_END";

    public const string ON_FUCTION_CHANGE = "ON_FUCTION_CHANGE";

    public const string OPEN_CULTIVATE_PANEL = "OPEN_CULTIVATE_PANEL";

    public const string OPEN_ASSIST_PANEL = "OPEN_ASSIST_PANEL";

    public const string OPEN_CORPSREDENVEL_Panel = "OPEN_CORPSREDENVEL_Panel";

    public const string OPEN_ONE_REDENVEL = "OPEN_ONE_REDENVEL";

    public const string SENG_REDENVEL_RESULT = "SENG_REDENVEL_RESULT";

    public const string OPEN_ALLOCATE_PANEL = "OPEN_ALLOCATE_PANEL";
    
    /// <summary>
    /// 帮派列表
    /// </summary>
    private GCCorpsListPanel corpListPanel;
    private List<SimpleCorpsInfo> corpList;
    /// <summary>
    /// 我的帮派信息
    /// </summary>
    private GCOpenCorpsPanel myCorpInfo;
    /// <summary>
    /// 帮派成员列表
    /// </summary>
    private List<CorpsMemberInfo> memberList;
    /// <summary>
    /// 我的帮派成员信息
    /// </summary>
    private GCCorpsMemberInfo myCorpMemberInfo;
    /// <summary>
    /// 是否点击了搜索
    /// </summary>
    public bool isSearch = false;
    /// <summary>
    /// 帮派建筑信息
    /// </summary>
    private GCOpenCorpsBuildingPanel mBuildingPanel;
    /// <summary>
    /// 帮派建筑升级结果
    /// </summary>
    private GCUpgradeCorps mGCUpgradeCorps;
    /// <summary>
    /// 帮派降级信息
    /// </summary>
    private GCDegradeCorps mGCDegradeCorps;
    /// <summary>
    /// 帮派福利信息
    /// </summary>
    private CorpsBenifitInfo mCorpsBenifit;
    /// <summary>
    /// 帮派福利的领取
    /// </summary>
    private GCGetBenifit mGCGeetBenifit;
    /// <summary>
    /// 帮派修炼技能
    /// </summary>
    private GCOpenCorpsCultivatePanel mGCOpenCultivatePanel;
    /// <summary>
    /// 帮派辅助技能
    /// </summary>
    private GCOpenCorpsAssistPanel mGCOpenCorpsAssistPanel;
    /// <summary>
    /// 帮派红包
    /// </summary>
    private GCOpenCorpsRedEnvelopePanel mGCOpenCorpsRedEnvelopePanel;
    /// <summary>
    /// 帮派红包领取
    /// </summary>
    private GCGotCorpsRedEnvelope mGCGotCorpsRedEnvelope;
    /// <summary>
    /// 帮派竞赛奖励
    /// </summary>
    private GCOpenAllocatePanel mGCOpenAllocatePanel;
    public Dictionary<int, CorpsBuildingInfo> corpsBuildingInfos = new Dictionary<int, CorpsBuildingInfo>();
    public DetailCorpsInfo detailCorpsInfo;
    /// <summary>
    /// 帮派升级倒计时
    /// </summary>
    private RTimer mRtimer;

    /// <summary>
    /// 发放红包结果
    /// </summary>
    public GCCreateCorpsRedEnvelope GCCreateCorpsRedEnvelope
    {
        set
        {
            dispatchChangeEvent(SENG_REDENVEL_RESULT, value);
        }
    }

    /// <summary>
    /// 技能修炼结果
    /// </summary>
    public bool upgradeResult
    {
        set
        {
            if (value)
            {
                EffectUtil.Ins.PlayEffect("common_shengji02", LayerConfig.SecondWnd, false, null);
            }
        }
    }
    
    private static CorpModel _ins;
    public static CorpModel Ins
    {
        get
        {
            if (_ins == null)
            {
                //_ins = Singleton.getObj(typeof(CorpModel)) as CorpModel;
                _ins = new CorpModel();
            }
            return _ins;
        }
    }

    public GCCorpsListPanel CorpListPanel
    {
        get { return corpListPanel; }
        set
        {
            corpListPanel = value;
            corpList = corpListPanel.getSimpleCorpsInfos().ToList();
            if (isSearch)
            {
                isSearch = false;
                if (corpList.Count == 0)
                {
                    dispatchChangeEvent(UPDATE_SEARCH_RESULT, null);
                }
            }
            if (!WndManager.Ins.IsWndShowing(typeof(CorpsEntryView)))
            {
                WndManager.open(GlobalConstDefine.CorpsEntryView_Name);
            }
            else
            {
                dispatchChangeEvent(UPDATE_CORPSLIST, null);
            }
        }
    }

    public List<SimpleCorpsInfo> CorpList
    {
        get { return corpList; }
    }

    /// <summary>
    /// 我的帮派信息
    /// </summary>
    public GCOpenCorpsPanel MyCorpInfo
    {
        get { return myCorpInfo; }
        set
        {
            myCorpInfo = value;
            detailCorpsInfo = MyCorpInfo.getDetailCorpsInfo();
            if (!WndManager.Ins.IsWndShowing(typeof(CorpsOfMineView)))
            {
                WndManager.open(GlobalConstDefine.CorpsOfMineView_Name);
            }
            else
            {
                dispatchChangeEvent(UPDATE_MY_CORP_INFO, null);
                dispatchChangeEvent(ON_FUCTION_CHANGE, null);
            }
        }
    }

    /// <summary>
    /// 帮派成员列表
    /// </summary>
    public List<CorpsMemberInfo> MemberList
    {
        get { return memberList; }
        set
        {
            memberList = value;
            dispatchChangeEvent(UPDATE_CORP_MEMBER_LIST, null);
        }
    }

    public void updateMemberList(GCCorpsChangedMemberInfo msg)
    {
        CorpsMemberInfo[] listtmp = msg.getCorpsMemInfoList();
        /** 更新类别 1修改,2添加,3删除 */
        switch (msg.getChangeType())
        {
            case 1:
                for (int i = 0; i < listtmp.Length; i++)
                {
                    for (int j = 0; j < memberList.Count; j++)
                    {
                        if (listtmp[i].memId.Equals(memberList[j].memId))
                        {
                            memberList[j] = listtmp[i];
                            break;
                        }
                    }
                }
                break;
            case 2:
                for (int i = 0; i < listtmp.Length; i++)
                {
                    memberList.Add(listtmp[i]);
                }
                break;
            case 3:
                for (int i = 0; i < listtmp.Length; i++)
                {
                    for (int j = 0; j < memberList.Count; j++)
                    {
                        if (listtmp[i].memId.Equals(memberList[j].memId))
                        {
                            memberList.RemoveAt(j);
                            break;
                        }
                    }
                }
                break;
        }
        dispatchChangeEvent(UPDATE_CORP_MEMBER_LIST, null);
    }

    /// <summary>
    /// 我的帮派成员信息
    /// </summary>
    public GCCorpsMemberInfo MyCorpMemberInfo
    {
        get { return myCorpMemberInfo; }
        set
        {
            myCorpMemberInfo = value;
            dispatchChangeEvent(UPDATE_MY_CORP_MEMBER_INFO, null);
        }
    }

    public void UpdateOneCorpInfo(SimpleCorpsInfo simpleCorpsInfo)
    {
        for (int i = 0; i < CorpList.Count; i++)
        {
            if (CorpList[i].corpsId == simpleCorpsInfo.corpsId)
            {
                CorpList[i] = simpleCorpsInfo;
                dispatchChangeEvent(UPDATE_CURRENT_CORP, simpleCorpsInfo);
                break;
            }
        }
    }
    /// <summary>
    /// 帮派建筑信息
    /// </summary>
    public GCOpenCorpsBuildingPanel buildingPanel
    {
        get
        {
            return mBuildingPanel;
        }
        set
        {
            if (value == null)
            {
                return;
            }
            mBuildingPanel = value;
            CorpsBuildingInfo buildingInfo = mBuildingPanel.getCorpsBuildingInfo();
            corpsBuildingInfos[buildingInfo.buildType] = buildingInfo;
            dispatchChangeEvent(OPEN_CORP_BUILDING_PANEL, value);
            dispatchChangeEvent(ON_FUCTION_CHANGE, null);
            if (buildingInfo.upgradeCountDownTime > 0)
            {
                if (mRtimer != null)
                {
                    mRtimer.stop();
                    mRtimer = null;
                }
    
                mRtimer = TimerManager.Ins.createTimer(500, (int)(buildingInfo.upgradeCountDownTime), OnBuildTimer, OnBuildTimerEnd);
                mRtimer.start();
                OnBuildTimer(mRtimer);
            }
        }
    }

    private void OnBuildTimer(RTimer timer)
    {
        dispatchChangeEvent(ON_BUILDING_TIMER, timer);
    }

    private void OnBuildTimerEnd(RTimer timer)
    {
        dispatchChangeEvent(ON_BUILDING_TIMER_END, timer);
    }

    /// <summary>
    /// 帮派建筑升级结果
    /// </summary>
    public GCUpgradeCorps GCUpgradeCorps
    {
        get
        {
            return mGCUpgradeCorps;
        }
        set
        {
            mGCUpgradeCorps = value;
            dispatchChangeEvent(CORPS_UPGRADE_RESULT, value);
            dispatchChangeEvent(ON_FUCTION_CHANGE, null);

        }
    }

    /// <summary>
    /// 帮派降级
    /// </summary>
    public GCDegradeCorps GCDegradeCorps
    {
        get
        {
            return mGCDegradeCorps;
        }
        set
        {
            mGCDegradeCorps = value;
            detailCorpsInfo = value.getDetailCorpsInfo();
            CorpsBuildingInfo buildingInfo = value.getCorpsBuildingInfo();
            corpsBuildingInfos[buildingInfo.buildType] = buildingInfo;
            dispatchChangeEvent(CORPS_DEGRADE_INFO, value);
            dispatchChangeEvent(ON_FUCTION_CHANGE, null);
        }
    }

    /// <summary>
    /// 帮派福利
    /// </summary>
    public CorpsBenifitInfo corpsBenifitInfo
    {
        get
        {
            return mCorpsBenifit;
        }
        set
        {
            mCorpsBenifit = value;
            dispatchChangeEvent(GET_CORPS_BENIFITINFO, value);
            dispatchChangeEvent(ON_FUCTION_CHANGE, null);

        }
    }

    /// <summary>
    /// 帮派福利的领取
    /// </summary>
    public GCGetBenifit GCGetBenifit
    {
        get
        {
            return mGCGeetBenifit;
        }
        set
        {
            mGCGeetBenifit = value;
            CorpsCGHandler.sendCGOpenCorpsBenifitPanel();
        }
    }

   /// <summary>
   /// 帮派修炼技能
   /// </summary>
    public GCOpenCorpsCultivatePanel GCOpenCultivatePanel
    {
        set
        {
            mGCOpenCultivatePanel = value;
            dispatchChangeEvent(OPEN_CULTIVATE_PANEL, value);
        }
        get
        {
            return mGCOpenCultivatePanel;
        }
    }

    /// <summary>
    /// 帮派辅助技能 
    /// </summary>
    public GCOpenCorpsAssistPanel GCOpenCorpsAssistPanel
    {
        set
        {
            mGCOpenCorpsAssistPanel = value;
            dispatchChangeEvent(OPEN_ASSIST_PANEL,null);
        }
        get
        {
            return mGCOpenCorpsAssistPanel;
        }
    }
    /// <summary>
    /// 帮派红包界面
    /// </summary>
    public GCOpenCorpsRedEnvelopePanel GCOpenCorpsRedEnvelopePanel
    {
        set
        {
            mGCOpenCorpsRedEnvelopePanel = value;
            dispatchChangeEvent(OPEN_CORPSREDENVEL_Panel,null);       
        }
        get
        {
            return mGCOpenCorpsRedEnvelopePanel;
        }
    }

    /// <summary>
    /// 红包领取
    /// </summary>
    public GCGotCorpsRedEnvelope GCGotCorpsRedEnvelope
    {
        set
        {
            mGCGotCorpsRedEnvelope = value;
            dispatchChangeEvent(OPEN_ONE_REDENVEL,null);
        }
        get
        {
            return mGCGotCorpsRedEnvelope;
        }
    }

    public GCOpenAllocatePanel GCOpenAllocatePanel
    {
        set
        {
            mGCOpenAllocatePanel = value;
            dispatchChangeEvent(OPEN_ALLOCATE_PANEL,null);
        }
        get
        {
            return mGCOpenAllocatePanel;
        }
    }

    public bool buildHaveRedDot()
    {
        if (corpsBuildingInfos == null || detailCorpsInfo == null)
        {
            return false;
        }
        foreach (var item in corpsBuildingInfos)
        {
            int level = item.Value.buildingLevel;

            CorpsUpgradeTemplate template = CorpsUpgradeTemplateDB.Instance.getTemplate(level);
            if (template != null && detailCorpsInfo.currExp >= template.upgradeExp
                && detailCorpsInfo.currFund >= template.upgradeFund
                && detailCorpsInfo.hasNextLevel == 1 && item.Value.upgradeCountDownTime == 0)
            {
                return true;
            }
        }
        return false;
    }

    public bool benifitHaveRedDot()
    {
        if (corpsBenifitInfo == null)
        {
            return false;
        }
        return corpsBenifitInfo.canReceive == 1;
    }

    public CorpsBuildingInfo GetBuildingInfoByType(int type)
    {
        CorpsBuildingInfo buildingInfo;
        corpsBuildingInfos.TryGetValue(type,out buildingInfo);
        return buildingInfo;
    }

    public override void Destroy()
    {
        corpListPanel = null;
        if (corpList != null)
        {
            for (int i = 0; i < corpList.Count; i++)
            {
                corpList[i] = null;
            }
            corpList.Clear();
            corpList = null;
        }

        myCorpInfo = null;

        if (memberList != null)
        {
            for (int i = 0; i < memberList.Count; i++)
            {
                memberList[i] = null;
            }
            memberList.Clear();
            memberList = null;
        }
        myCorpMemberInfo = null;
        isSearch = false;

        mBuildingPanel = null;
        mGCUpgradeCorps = null;
        mGCDegradeCorps = null;
        mCorpsBenifit = null;
        mGCGeetBenifit = null;
        mGCOpenCultivatePanel = null;
        mGCOpenCorpsAssistPanel = null;
        mGCOpenCorpsRedEnvelopePanel = null;
        mGCGotCorpsRedEnvelope = null;
        
        mGCOpenAllocatePanel=null;
        if(corpsBuildingInfos!=null)corpsBuildingInfos.Clear();
        corpsBuildingInfos = null;
        detailCorpsInfo=null;
        if (mRtimer != null)
        {
            mRtimer.stop();
        }
        mRtimer = null;
        _ins = null;
    }
}

