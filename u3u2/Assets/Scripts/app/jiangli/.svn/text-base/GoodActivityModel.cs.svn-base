using app.model;
using app.net;
using System.Collections.Generic;
using app.zone;

public class GoodActivityType
{
    /** 限时累计充值 首充*/
	public const int NORMAL_TOTAL_CHARGE=1;
	/** 每日累计充值 */
    public const int DAY_TOTAL_CHARGE = 2;
	/** 一元购类型充值（领奖需要购买） */
	public const int TOTAL_CHARGE_BUY=3;
	/** 等级排名 等级奖励*/
	public const int LEVEL_UP=5;
		
	/** 招财进宝 */
	public const int BUY_MONEY=8;
	/** 开服基金 */
	public const int LEVEL_MONEY=9;
		
	/** VIP等级 */
	public const int VIP_LEVEL=10;
	/** 累计消耗 */
	public const int TOTAL_COST=12;
	/** 每累计消耗 */
	public const int EVERY_COST=13;
	/**7日登陆**/
    public const int SEVEN_LOGIN = 15;
}

public class GoodActivityModel:AbsModel
{
    private static GoodActivityModel _ins;
    public static GoodActivityModel Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new GoodActivityModel();
            }
            return _ins;
        }
    }

    public List<GoodActivityInfo> ActivityList
    {
        get { return _activityList; }
        set { _activityList = value; }
    }

    public List<GoodActivityInfo> ChargeActivityList
    {
        get { return _chargeactivityList; }
        set { _chargeactivityList = value; }
    }

    public bool IsWaitingShowPanel
    {
        get { return isWaitingShowPanel; }
        set { isWaitingShowPanel = value; }
    }

    private List<GoodActivityInfo> _activityList;
    private List<GoodActivityInfo> _chargeactivityList;

    public const string UPDATE_GOODACTIVITY_LIST = "UPDATE_GOODACTIVITY_LIST";
    public const string UPDATE_GOODACTIVITY_INFO = "UPDATE_GOODACTIVITY_INFO";

    public const string UPDATE_GOODACTIVITY2_LIST = "UPDATE_GOODACTIVITY2_LIST";
    public const string UPDATE_GOODACTIVITY2_INFO = "UPDATE_GOODACTIVITY2_INFO";
    public const string UPDATE_GOODACTIVITY2_RedDot = "UPDATE_GOODACTIVITY2_RedDot";
    private bool isWaitingShowPanel=false;

    public void GCGoodActivityListHandler(GCGoodActivityList msg)
    {
        if (msg.getFuncId()==FunctionIdDef.JINGCAIHUODONG)
        {
            if (ActivityList == null)
            {
                ActivityList = new List<GoodActivityInfo>();
            }
            else
            {
                ActivityList.Clear();
            }
            GoodActivityInfo[] infos = msg.getGoodActivityList();
            if (infos == null)
            {
                return;
            }
            for (int i = 0; i < infos.Length; i++)
            {
                _activityList.Add(infos[i]);
            }
            dispatchChangeEvent(UPDATE_GOODACTIVITY_LIST, null);
        }
        else if (msg.getFuncId() == FunctionIdDef.JINGCAIHUODONG2)
        {
            if (ChargeActivityList == null)
            {
                ChargeActivityList = new List<GoodActivityInfo>();
            }
            else
            {
                ChargeActivityList.Clear();
            }
            GoodActivityInfo[] infos = msg.getGoodActivityList();
            if (infos == null)
            {
                return;
            }
            for (int i = 0; i < infos.Length; i++)
            {
                _chargeactivityList.Add(infos[i]);
            }
            if (IsWaitingShowPanel)
            {
                if (ChargeActivityList.Count>0)
                {
                    WndManager.open(GlobalConstDefine.ChargeActivityView);
                }
                else
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("暂无活动，敬请期待~");
                }
                IsWaitingShowPanel = false;
            }
            else
            {
                dispatchChangeEvent(UPDATE_GOODACTIVITY2_LIST, null);
            }
            dispatchChangeEvent(UPDATE_GOODACTIVITY2_RedDot, null);
        }
        
    }

    public void GCGoodActivityUpdateHandler(GCGoodActivityUpdate msg)
    {
        if (msg.getFuncId()==FunctionIdDef.JINGCAIHUODONG)
        {
            if (ActivityList == null)
            {
                return;
            }
            for (int i = 0; i < ActivityList.Count; i++)
            {
                if (ActivityList[i].activityId == msg.getGoodActivityInfo().activityId &&
                    ActivityList[i].typeId == msg.getGoodActivityInfo().typeId)
                {
                    if (msg.getGoodActivityInfo().needHide == 1)
                    {
                        ActivityList.RemoveAt(i);
                        dispatchChangeEvent(UPDATE_GOODACTIVITY_LIST, null);
                        break;
                    }
                    else
                    {
                        ActivityList[i] = msg.getGoodActivityInfo();
                        dispatchChangeEvent(UPDATE_GOODACTIVITY_INFO,
                            new int[3] {i, ActivityList[i].typeId, (int) ActivityList[i].activityId});
                        break;
                    }
                }
            }
        }
        else if (msg.getFuncId() == FunctionIdDef.JINGCAIHUODONG2)
        {
            if (ChargeActivityList == null)
            {
                return;
            }
            for (int i = 0; i < ChargeActivityList.Count; i++)
            {
                if (ChargeActivityList[i].activityId == msg.getGoodActivityInfo().activityId &&
                    ChargeActivityList[i].typeId == msg.getGoodActivityInfo().typeId)
                {
                    if (msg.getGoodActivityInfo().needHide == 1)
                    {
                        ChargeActivityList.RemoveAt(i);
                        dispatchChangeEvent(UPDATE_GOODACTIVITY2_INFO,
                            new int[1] { -1 });
                    }
                    else
                    {
                        ChargeActivityList[i] = msg.getGoodActivityInfo();
                        dispatchChangeEvent(UPDATE_GOODACTIVITY2_INFO,
                            new int[3] { i, ChargeActivityList[i].typeId, (int)ChargeActivityList[i].activityId });
                    }
                    
                    break;
                }
            }
            dispatchChangeEvent(UPDATE_GOODACTIVITY2_RedDot, null);
        }
    }
    /// <summary>
    /// 获得 活动信息
    /// </summary>
    /// <param name="typeId"></param>
    /// <param name="activityId"></param>
    /// <returns></returns>
    private GoodActivityInfo GetActivityInfo(int typeId, long activityId,int funcid)
    {
        if (funcid == FunctionIdDef.JINGCAIHUODONG)
        {
            if (ActivityList == null)
            {
                return null;
            }
            for (int i = 0; i < ActivityList.Count; i++)
            {
                if (ActivityList[i].activityId == activityId &&
                    ActivityList[i].typeId == typeId)
                {
                    return ActivityList[i];
                }
            }
            return null;
        }
        else if (funcid == FunctionIdDef.JINGCAIHUODONG2)
        {
            if (ChargeActivityList == null)
            {
                return null;
            }
            for (int i = 0; i < ChargeActivityList.Count; i++)
            {
                if (ChargeActivityList[i].activityId == activityId &&
                    ChargeActivityList[i].typeId == typeId)
                {
                    return ChargeActivityList[i];
                }
            }
            return null;
        }
        return null;
    }

    public bool HaveRedDot(int typeId, long activityId, int funcid)
    {
        GoodActivityInfo mGoodActivityInfo = GetActivityInfo(typeId, activityId, funcid);
        if (mGoodActivityInfo == null)
        {
            return false;
        }
        return mGoodActivityInfo.hasUnGotBonus == 1;
    }

    public bool ChargeActivityHasRedDot()
    {
        bool hasRedDot = FunctionModel.Ins.IsFuncNeedRedDot(FunctionIdDef.JINGCAIHUODONG2);
        if (hasRedDot)
        {
            return true;
        }
        for (int i = 0; ChargeActivityList!=null&&i < ChargeActivityList.Count; i++)
        {
            switch (ChargeActivityList[i].typeId)
            {
                case GoodActivityType.TOTAL_CHARGE_BUY:
                    //一元购
                     hasRedDot = YiYuanGouScript.hasReward(ChargeActivityList[i]);
                     if (hasRedDot) return true;
                    break;
                case GoodActivityType.BUY_MONEY:
                    //招财进宝
                     hasRedDot = ZhaoCaiJinBaoScript.hasReward(ChargeActivityList[i]);
                     if (hasRedDot) return true;
                    break;
                case GoodActivityType.LEVEL_MONEY:
                    //开服基金
                    hasRedDot = KaiFuJiJinScript.hasReward(ChargeActivityList[i]);
                    if (hasRedDot) return true;
                    break;
            }
        }
        return false;
    }

    public override void Destroy()
    {
        if(ActivityList!=null)ActivityList.Clear();
        ActivityList = null;
        if (ChargeActivityList!=null)ChargeActivityList.Clear();
        ChargeActivityList = null;
        isWaitingShowPanel = false;

        _ins = null;
    }
}
