using app.human;
using app.net;
using app.team;
using app.zone;
using app.confirm;

public class ShiTuModel:AbsModel
{
    public const string UPDATE_SHITU_INFO = "UPDATE_SHITU_INFO";
    public const string UPDATE_REWARD_INFO = "UPDATE_REWARD_INFO";
    public const string UPDATE_HONGDIAN_INFO = "UPDATE_HONGDIAN_INFO";
    public ShiTuModel()
    {
        myShiTuInfo = new MyShiTuInfo();
    }
    private static ShiTuModel _ins;
    public static ShiTuModel Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new ShiTuModel();
            }
            return _ins;
        }
    }
    /// <summary>
    /// 我的师徒信息
    /// </summary>
    private MyShiTuInfo myShiTuInfo;

    public MyShiTuInfo MyShiTuInfo
    {
        get { return myShiTuInfo; }
    }

    public GCOvermanHongdian HongdianData
    {
        set
        {
            hongdianData = value;
            dispatchChangeEvent(UPDATE_HONGDIAN_INFO,null);
        }
    }

    private GCOvermanHongdian hongdianData;

    public void SetMyShiTuInfo(GCOvermanInfo msg)
    {
        myShiTuInfo = null;
        myShiTuInfo = new MyShiTuInfo();
        if (msg.getOverman() != 0&&msg.getOverman().Equals(Human.Instance.Id))
        {//我就是师傅
            myShiTuInfo.overman = 0;
            myShiTuInfo.overmanName = "";
            myShiTuInfo.overmanTemplateId = 0;

            myShiTuInfo.lowerList = msg.getLowerList();
        }
        if (msg.getLowerList().Length > 0)
        {
            for (int i=0;i<msg.getLowerList().Length;i++)
            {
                if (msg.getLowerList()[i].uuid.Equals(Human.Instance.Id))
                {
                    //我是徒弟
                    myShiTuInfo.overman = msg.getOverman();
                    myShiTuInfo.overmanName = msg.getOvermanName();
                    myShiTuInfo.overmanTemplateId = msg.getOvermanTemplateId();
                    myShiTuInfo.isOvermanOnline = msg.getIsOnline();
                    myShiTuInfo.lowerList = new LowermanInfo[0];
                    break;
                }
            }
        }
        dispatchChangeEvent(UPDATE_SHITU_INFO,myShiTuInfo);
    }

    public void ShouTu()
    {
        if (!TeamModel.ins.hasTeam())
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请组队前来收徒");
            return;
        }
        if (TeamModel.ins.getTeamMemberNum() != 2)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请2人组队前来收徒");
            return;
        }
        long leaderuuid = TeamModel.ins.GetLeaderUUID();
        TeamMemberInfo shifuInfo = TeamModel.ins.GetTeamMemberInfo(leaderuuid);
        TeamMemberInfo tudiInfo = TeamModel.ins.getTeamFirstOtherMemberInfo(leaderuuid);
        int shifudengji = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.OVERMAN_MIN_OVERMAN_LEVEL);
        int tudidengjidi = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.OVERMAN_MIN_LOWERMAN_LEVEL);
        int tudidengjigao = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.OVERMAN_MAX_LOWERMAN_LEVEL);
        string tudidengjistr = tudidengjidi + "-" + tudidengjigao;
        if (shifuInfo.level < shifudengji)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("徒弟" + tudidengjistr + "级，师傅>=" + shifudengji + "级才可组队拜师");
            return;
        }
        if (tudiInfo.level < tudidengjidi || tudiInfo.level > tudidengjigao)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("徒弟" + tudidengjistr + "级，师傅>=" + shifudengji + "级才可组队拜师");
            return;
        }
        if (myShiTuInfo.getOverman()!=0)
        {
            //我有师傅，我是徒弟
            ZoneBubbleManager.ins.BubbleSysMsg("你当前是" + myShiTuInfo.getOvermanName()+ "的徒弟，不能再收徒弟了");
            return;
        }
        if (myShiTuInfo.getLowerList().Length>0)
        {
            if (myShiTuInfo.getLowerList().Length==3)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("您的徒弟已经达到3位了，不能再收徒了");
                return;
            }
            //我有徒弟，我是师傅
            for (int i=0;i<myShiTuInfo.getLowerList().Length;i++)
            {
                if (myShiTuInfo.getLowerList()[i].uuid.Equals(tudiInfo.uuid))
                {
                    ZoneBubbleManager.ins.BubbleSysMsg(tudiInfo.name+"已经是您的徒弟了");
                    return;
                }
            }
        }
        OvermanCGHandler.sendCGFirstOverman();
        ZoneBubbleManager.ins.BubbleSysMsg("申请收徒成功，请等待" + tudiInfo.name+"确认");
    }

    public void ChuShi()
    {
        if (!TeamModel.ins.hasTeam())
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请组队前来出师");
            return;
        }
        if (TeamModel.ins.getTeamMemberNum() != 2)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请2人组队前来出师");
            return;
        }
        if (myShiTuInfo.getOverman()==0&&myShiTuInfo.getLowerList().Length==0)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请先收徒");
            return;
        }
        long leaderuuid = TeamModel.ins.GetLeaderUUID();
        if (!(leaderuuid.Equals(Human.Instance.Id)&&myShiTuInfo.getOverman()==0))
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请师傅作为队长来出师");
            return;
        }
        TeamMemberInfo tudiInfo = TeamModel.ins.getTeamFirstOtherMemberInfo(leaderuuid);
        bool ismytudi = false;
        for (int i = 0; i < myShiTuInfo.getLowerList().Length; i++)
        {
            if (myShiTuInfo.getLowerList()[i].uuid.Equals(tudiInfo.uuid))
            {
                ismytudi = true;
                break;
            }
        }
        if (!ismytudi)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("对方不是你的徒弟，无法出师");
            return;
        }
        int chushidengji = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.OVERMAN_OVER_OVERMAN);
        if (tudiInfo.level < chushidengji)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("徒弟等级>=" + chushidengji + "级才能出师");
            return;
        }
        OvermanCGHandler.sendCGFirstFireOverman();
        ZoneBubbleManager.ins.BubbleSysMsg("申请出师成功，请等待" + tudiInfo.name + "确认");
    }

    public void JieChuShiTu()
    {
        if (!TeamModel.ins.hasTeam())
        {
            //非组队状态，是否强制解除师徒关系
            if (MyShiTuInfo.getOverman()!=0)
            {
                //有师傅，我就是徒弟
                int cost = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.JIECHU_SHITU_COST);
                string tishi = "是否确定强制与" + MyShiTuInfo.getOvermanName()+ "解除师徒关系，解除需扣除" + cost + "银票";
                ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, tishi, sureForceJieChu, cancelForceJieChu);
            }
            else if(myShiTuInfo.getLowerList().Length>0)
            {
                //有徒弟，我就是师傅
                WndManager.open(GlobalConstDefine.JieChuTuDiView);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请先拜师或收徒");
            }
            return;
        }
        if (TeamModel.ins.getTeamMemberNum() != 2)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请2人组队前来解除师徒关系");
            return;
        }
        OvermanCGHandler.sendCGFirstTeamFireOverman();
    }

    private void sureForceJieChu(RMetaEvent e)
    {
        int cost = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.JIECHU_SHITU_COST);
        MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD, cost, sureHandler);
    }

    private void sureHandler(RMetaEvent e)
    {
        OvermanCGHandler.sendCGForceFireOverman(0);
    }

    private void cancelForceJieChu(RMetaEvent e)
    {

    }
    /// <summary>
    /// 判断 当前是否有红点
    /// </summary>
    /// <param name="uuidv"></param>
    /// <returns></returns>
    public bool HasHongDian(long uuidv)
    {
        if (hongdianData!=null)
        {
            for (int i=0;i<hongdianData.getRewardInfo().Length;i++)
            {
                if (hongdianData.getRewardInfo()[i].Equals(uuidv))
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// 获得一个徒弟的信息
    /// </summary>
    /// <param name="tudiuuid"></param>
    /// <returns></returns>
    public LowermanInfo GetTuDiInfoByUUID(long tudiuuid)
    {
        if (myShiTuInfo.getLowerList().Length==0)
        {
            return null;
        }
        for (int i=0;i<myShiTuInfo.getLowerList().Length;i++)
        {
            if (myShiTuInfo.getLowerList()[i].uuid.Equals(tudiuuid))
            {
                return myShiTuInfo.getLowerList()[i];
            }
        }
        return null;
    }

    public void GCGetOvermanRewardHandler(GCGetOvermanReward msg)
    {
        if (WndManager.Ins.IsWndShowing(GlobalConstDefine.ShiTuPanel))
        {
            dispatchChangeEvent(UPDATE_REWARD_INFO,msg);
        }
        else
        {
            WndManager.open(GlobalConstDefine.ShiTuPanel,msg);
        }
    }

    public void GCGetLowermanRewardHandler(GCGetLowermanReward msg)
    {
        if (WndManager.Ins.IsWndShowing(GlobalConstDefine.ShiTuPanel))
        {
            dispatchChangeEvent(UPDATE_REWARD_INFO, msg);
        }
        else
        {
            WndManager.open(GlobalConstDefine.ShiTuPanel, msg);
        }
    }
    
    public override void Destroy()
    {
        myShiTuInfo = new MyShiTuInfo();
        hongdianData = null;
        _ins = null;
    }
}

public class MyShiTuInfo
{
    /** 师傅charId */
    public long overman;
    /** 师傅charId */
    public string overmanName;
    /** 师傅的模版id */
    public int overmanTemplateId;
    /** 师傅是否在线*/
    public bool isOvermanOnline;
    /** 徒弟信息 */
    public LowermanInfo[] lowerList;
    
    public MyShiTuInfo()
    {
        overman = 0;
        overmanName = "";
        overmanTemplateId = 0;
        lowerList = new LowermanInfo[0];
    }

    public long getOverman()
    {
        return overman;
    }

    public string getOvermanName()
    {
        return overmanName;
    }

    public int getOvermanTemplateId()
    {
        return overmanTemplateId;
    }

    public LowermanInfo[] getLowerList()
    {
        return lowerList;
    }
}