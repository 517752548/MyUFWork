using app.bag;
using app.fuben;
using app.tongtianta;
using app.xinfa;

public class AutoMaticManager : AbsMonoBehaviour
{
    private static AutoMaticManager _ins;
    public static AutoMaticManager Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new AutoMaticManager();
            }
            return _ins;
        }
        set { _ins = value; }
    }

    /// <summary>
    /// 当前 自动化 类型
    /// </summary>
    public AutoMaticType CurAutoMaticType
    {
        get { return curAutoMaticType; }
        set
        {
            curAutoMaticType = value;
            if (curAutoMaticType!=AutoMaticType.AutoQuest)
            {
                QuestModel.Ins.AutoQuestId = 0;
            }
        }
    }

    /// <summary>
    /// 自动化类型
    /// </summary>
    public enum AutoMaticType
    {
        None,
        AutoQuest,
        AutoUseCangBaoTu,
        AutoGuaJi,
        AutoLvYe,
        AutoFindResPoint
    }

    /// <summary>
    /// 当前 自动化 类型
    /// </summary>
    private AutoMaticType curAutoMaticType;

    public override void DoUpdate(float deltaTime)
    {
        switch (CurAutoMaticType)
        {
            case AutoMaticType.None:
                break;
            case AutoMaticType.AutoQuest:
                QuestModel.Ins.DoUpdate();
            break;
            case AutoMaticType.AutoUseCangBaoTu:
                BagModel.Ins.checkAutoUseBaoTu();
            break;
            case AutoMaticType.AutoGuaJi:
                TongTianTaModel.ins.DoUpdate();
                break;
            case AutoMaticType.AutoLvYe:
                FubenlyxzModel.ins.DoUpdate();
                break;
            case AutoMaticType.AutoFindResPoint:
                XinFaModel.instance.checkAutoFindResPoint();
                break;
            default:
                break;
        }
        //超链接
        LinkParse.Ins.updateLink();
    }

    public void StopAutoMatic()
    {
        QuestModel.Ins.StopAutoQuest();
        BagModel.Ins.stopAutoUsingBaotu();
        TongTianTaModel.ins.StopAuto();
        FubenlyxzModel.ins.stopAutoBattle();

        EffectUtil.Ins.RemoveEffect(ClientConstantDef.ZIDONG_XUNLU_EFFECT_NAME);
        EffectUtil.Ins.RemoveEffect(ClientConstantDef.GUAJI_EFFECT_NAME);
    }

}
