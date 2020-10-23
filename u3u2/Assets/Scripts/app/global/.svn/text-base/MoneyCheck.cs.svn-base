using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.db;
using app.duihuan;
using app.human;
using app.confirm;

/// <summary>
/// 货币消耗校验，不足的情况下 会 弹出 充值/兑换 提示
/// </summary>
public class MoneyCheck
{
    private static MoneyCheck _ins;

    public static MoneyCheck Ins
    {
        get
        {
            if (_ins==null)
            {
                _ins = new MoneyCheck();
            }
            return _ins;
        }
    }
    /// <summary>
    /// 校验货币是否足够
    /// </summary>
    /// <param name="money">CurrencyTemplate类型的对象，消耗模板</param>
    /// <param name="sureHandler">足够 回调</param>
    /// <param name="shuliang">消耗的数量</param>
    public void Check(CurrencyTemplate money,RMetaEventHandler sureHandler,int shuliang=1)
    {
        Check(money.currencyType,money.num*shuliang,sureHandler);
    }
    /// <summary>
    /// 校验货币是否足够
    /// </summary>
    /// <param name="moneyType">消耗的货币类型</param>
    /// <param name="costValue">消耗的货币数量</param>
    /// <param name="sureHandler">足够 回调</param>
    public void Check(int moneyType,long costValue,RMetaEventHandler sureHandler)
    {
        switch (moneyType)
        {
            case CurrencyTypeDef.BOND:
                if (costValue>Human.Instance.GetCurrencyValue(CurrencyTypeDef.BOND))
                {
                    //金子不足，是否前往充值
                    ConfirmWnd.Ins.ShowConfirm("金子不足", "是否前往充值？", sureChargeHandler);
                    return ;
                }
                if (sureHandler!=null) sureHandler(null);
                //mJinzi.SetMoney(CurrencyTypeDef.BOND, , false, false);
                //mYinzi.SetMoney(CurrencyTypeDef.GOLD_2, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD_2), false, false);
                //mJinpiao.SetMoney(CurrencyTypeDef.GIFT_BOND, , false, false);
                //mYinpiao.SetMoney(CurrencyTypeDef.GOLD, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD), false, false);
                break;
            case CurrencyTypeDef.GIFT_BOND:
                long haveGiftBond = Human.Instance.GetCurrencyValue(CurrencyTypeDef.GIFT_BOND);
                if (costValue > haveGiftBond)
                {
                    //金票不足支付所有
                    //判断剩余的金子是否能够
                    long haveBond = Human.Instance.GetCurrencyValue(CurrencyTypeDef.BOND);
                    if ((costValue - haveGiftBond) <= haveBond)
                    {
                        //剩余的金子足以支付，提示
                        ConfirmWnd.Ins.ShowConfirm("金票不足", "是否消费" + (costValue - haveGiftBond) + "金子支付", sureHandler);
                    }
                    else
                    {
                        //剩余的金子不足以支付，提示
                        ConfirmWnd.Ins.ShowConfirm("金票不足", "是否消费" + (costValue - haveGiftBond) + "金子支付", jinziBuzu);
                    }
                    return;
                }
                if (sureHandler != null) sureHandler(null);
                break;
            case CurrencyTypeDef.GOLD_2:
                if (costValue > Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD_2))
                {
                    //银子不足，是否前往兑换
                    ConfirmWnd.Ins.ShowConfirm("银子不足", "是否前往兑换？", sureDuiHuanYinZi);
                    return ;
                }
                if (sureHandler != null) sureHandler(null);
                break;
            case CurrencyTypeDef.GOLD:
                long haveGOLD = Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD);
                if (costValue > haveGOLD)
                {
                    //银票不足支付所有
                    //判断剩余的银子是否能够
                    long haveGOLD_2 = Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD_2);
                    if ((costValue - haveGOLD) <= haveGOLD_2)
                    {
                        //剩余的银子足以支付，提示
                        ConfirmWnd.Ins.ShowConfirm("银票不足", "是否消费" + (costValue - haveGOLD) + "银子支付", sureHandler);
                    }
                    else
                    {
                        //剩余的银子不足以支付，提示
                        ConfirmWnd.Ins.ShowConfirm("银票不足", "是否消费" + (costValue - haveGOLD) + "银子支付",yinziBuzu);
                    }
                    return ;
                }
                if (sureHandler != null) sureHandler(null);
                break;
            default:
                if (sureHandler != null) sureHandler(null);
                break;
        }
    }

    private void jinziBuzu(RMetaEvent e)
    {
        //金票金子 不足，是否前往充值
        ConfirmWnd.Ins.ShowConfirm("金子不足", "是否前往充值？", sureChargeHandler); 
    }

    private void yinziBuzu(RMetaEvent e)
    {
        //银子 不足，是否前往兑换
        ConfirmWnd.Ins.ShowConfirm("银子不足", "是否前往兑换？", sureDuiHuanYinPiao);
    }

    private void sureDuiHuanYinZi(RMetaEvent e)
    {
        DuiHuanMoneyView.Ins.ShowDuiHuan(CurrencyTypeDef.GOLD_2);
    }

    private void sureDuiHuanYinPiao(RMetaEvent e)
    {
        DuiHuanMoneyView.Ins.ShowDuiHuan(CurrencyTypeDef.GOLD);
    }

    private void sureChargeHandler(RMetaEvent e)
    {
        LinkParse.Ins.linkToFunc(FunctionIdDef.CHONGZHI);
    }

}