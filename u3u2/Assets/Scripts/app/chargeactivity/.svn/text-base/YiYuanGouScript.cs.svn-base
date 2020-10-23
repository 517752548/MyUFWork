using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.human;
using app.jiangli;
using app.net;
using app.reward;
using app.utils;

public class YiYuanGouScript
{
    public YiYuanGouUI UI;
    public GoodActivityRewardInfos activityInfo;
    private List<RewardItem> rewarditem;

    public YiYuanGouScript(YiYuanGouUI ui)
    {
        UI = ui;
        //一元购
        //hasgivekey
        //curnum>=neednum,能买
        UI.chargeBtn.AddClickCallBack(clickCharge);
    }

    private void clickCharge()
    {
        if (activityInfo != null && !activityInfo.hasGiveKey)
        {
            if (activityInfo.currNum >= activityInfo.needNum)
            {
                MoneyCheck.Ins.Check(CurrencyTypeDef.BOND,activityInfo.needNumSecond, (RMetaEvent) =>
                {
                    GoodactivityCGHandler.sendCGGoodActivityGetBonus(activityInfo.activityId, activityInfo.targetId);
                });
            }
            else
            {
                LinkParse.Ins.linkToFunc(FunctionIdDef.CHONGZHI);
            }
        }
    }

    public void setData(GoodActivityInfo activityinfo)
    {
        //列表内容
        List<GoodActivityRewardInfos> list = GoodActivityRewardInfos.GetRewardItems(activityinfo);
        activityInfo = list[0];
        //规则
        UI.ruleContent.text = activityinfo.desc;

        RewardData rewardData = new RewardData();
        //rewardData.ParseReward(list[0].rewardData);

        if (rewarditem == null)
        {
            rewarditem = new List<RewardItem>();
            for (int j = 0; j < UI.commonItemList.Count; j++)
            {
                rewarditem.Add(new RewardItem(UI.commonItemList[j]));
            }
        }
        rewardData.Parse(activityInfo.rewardData, rewarditem);
        //按钮状态
        if (activityInfo.hasGiveKey)
        {
            ColorUtil.Gray(UI.chargeBtn);
            //UI.chargeBtn.interactable = false;
            UI.chargeBtnText.text = "已  购  买";
        }
        else
        {
            if (activityInfo.currNum >= activityInfo.needNum)
            {
                ColorUtil.DeGray(UI.chargeBtn);
                //UI.chargeBtn.interactable = true;
                UI.chargeBtnText.text = activityInfo.needNumSecond + "金子购买";
            }
            else
            {
                ColorUtil.DeGray(UI.chargeBtn);
                //UI.chargeBtn.interactable = true;
                UI.chargeBtnText.text = "前往充值";
            }
        }
    }

    public static bool hasReward(GoodActivityInfo activityinfo)
    {
        //列表内容
        List<GoodActivityRewardInfos> list = GoodActivityRewardInfos.GetRewardItems(activityinfo);
        GoodActivityRewardInfos tmpActivityInfo = list[0];
        //按钮状态
        if (tmpActivityInfo.hasGiveKey)
        {
            return false;
        }
        else
        {
            if (tmpActivityInfo.currNum >= tmpActivityInfo.needNum && Human.Instance.HasEnoughCurrency(CurrencyTypeDef.BOND, tmpActivityInfo.needNumSecond))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

public void Destroy()
    {
        UI.chargeBtn.ClearClickCallBack();
        for (int i = 0; rewarditem != null && i < rewarditem.Count; i++)
        {
            rewarditem[i].Destroy();
        }
        if (rewarditem != null) rewarditem.Clear();
        rewarditem = null;
    }
}
