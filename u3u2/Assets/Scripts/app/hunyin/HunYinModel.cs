using app.human;
using app.net;
using app.team;
using app.utils;
using app.zone;
using app.confirm;

public class HunYinModel:AbsModel
{
    public const string UPDATE_HUNYIN_INFO = "UPDATE_HUNYIN_INFO";
    private static HunYinModel _ins;
    public static HunYinModel Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new HunYinModel();
            }
            return _ins;
        }
    }
    private GCMarryInfo myMarryInfo ;
    /// <summary>
    /// 我的婚姻信息
    /// </summary>
    public GCMarryInfo MyMarryInfo
    {
        get { return myMarryInfo; }
        set
        {
            myMarryInfo=value;
            dispatchChangeEvent(UPDATE_HUNYIN_INFO,myMarryInfo);
        }
    }

    public void JieHun()
    {
        if (HasMeMarryed())
        {
            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CANNOT_JIEHUN);
            return;
        }
        if (!TeamModel.ins.hasTeam())
        {
            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.ZUDUI_JIEHUN);
            return;
        }
        if (TeamModel.ins.getTeamMemberNum() != 2)
        {
            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.LIAREN_ZUDUI_JIEHUN);
            return;
        }
        long leaderuuid = TeamModel.ins.GetLeaderUUID();
        TeamMemberInfo shifuInfo = TeamModel.ins.GetTeamMemberInfo(leaderuuid);
        TeamMemberInfo tudiInfo = TeamModel.ins.getTeamFirstOtherMemberInfo(leaderuuid);

        int jihundengji = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.JIEHUN_LEVEL);
        if (shifuInfo.level < jihundengji || tudiInfo.level < jihundengji)
        {
            ZoneBubbleManager.ins.BubbleSysMsg(
                StringUtil.Assemble(LangConstant.JIEHUN_TIAOJIAN,new string[1]{jihundengji.ToString()})
                );
            return;
        }
        MarryCGHandler.sendCGFirstMarry();
    }

    public void LiHun()
    {
        if (!HasMeMarryed())
        {
            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CANNOT_LIHUN);
            return;
        }
        if (!TeamModel.ins.hasTeam())
        {
            //是否强制离婚
            int cost = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.MARRY_FORCE_FIRE);
            string tishi =
                StringUtil.Assemble(LangConstant.FORCE_LIHUN_COST, new string[2] {cost.ToString(), GetMyCoupleName()});
            ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, tishi, sureForceLiHun,cancelForceLiHun);
            return;
        }
        if (TeamModel.ins.getTeamMemberNum() != 2)
        {
            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.LIAREN_ZUDUI_LIHUN);
            return;
        }
        if (!IsMyCouple(TeamModel.ins.getTeamFirstOtherMemberInfo(Human.Instance.Id).uuid))
        {
            ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CANNOT_LIHUN_NOTCOUPLE);
            return;
        }
        MarryCGHandler.sendCGFirstFireMarry();
    }

    private void sureForceLiHun(RMetaEvent e)
    {
        int cost = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.MARRY_FORCE_FIRE);
        MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD,cost,sureHandler);
    }

    private void sureHandler(RMetaEvent e)
    {
        MarryCGHandler.sendCGForceFireMarry();
    }

    private void cancelForceLiHun(RMetaEvent e)
    {

    }
    /// <summary>
    /// 我是否已经结婚
    /// </summary>
    /// <returns></returns>
    public bool HasMeMarryed()
    {
        if (MyMarryInfo != null && (MyMarryInfo.getHusband().Equals(Human.Instance.Id) || (MyMarryInfo.getWife().Equals(Human.Instance.Id))))
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// 判断此人是否我的夫妻
    /// </summary>
    /// <param name="uuid"></param>
    /// <returns></returns>
    public bool IsMyCouple(long uuid)
    {
        if (MyMarryInfo != null && (MyMarryInfo.getHusband().Equals(uuid) || (MyMarryInfo.getWife().Equals(uuid))))
        {
            return true;
        }
        return false;
    }

    public long GetMyCoupleUUID()
    {
        if (MyMarryInfo != null)
        {
            if (MyMarryInfo.getHusband().Equals(Human.Instance.Id))
            {
                return MyMarryInfo.getWife();
            }
            if (MyMarryInfo.getWife().Equals(Human.Instance.Id))
            {
                return MyMarryInfo.getHusband();
            }
        }
        return 0;
    }

    public string GetMyCoupleName()
    {
        if (MyMarryInfo != null)
        {
            if (MyMarryInfo.getHusband().Equals(Human.Instance.Id))
            {
                return MyMarryInfo.getWifeName();
            }
            if (MyMarryInfo.getWife().Equals(Human.Instance.Id))
            {
                return MyMarryInfo.getHusbandName();
            }
        }
        return "";
    }
    
    public override void Destroy()
    {
        myMarryInfo = null;
        _ins = null;
    }
}
