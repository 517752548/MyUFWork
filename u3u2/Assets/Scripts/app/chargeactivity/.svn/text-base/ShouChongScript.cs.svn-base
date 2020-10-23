using System.Collections.Generic;
using app.jiangli;
using app.net;
using app.reward;
using app.utils;

public class ShouChongScript
{
    public ShouChongUI UI;
    public GoodActivityRewardInfos activityInfo;
    private List<RewardItem> rewarditem;

    public ShouChongScript(ShouChongUI ui)
    {
        UI = ui;
        UI.chargeBtn.AddClickCallBack(clickCharge);
    }

    public void setData(GoodActivityInfo  activityinfo)
    {
        //列表内容
        List<GoodActivityRewardInfos> list = GoodActivityRewardInfos.GetRewardItems(activityinfo);
        activityInfo = list[0];

        RewardData rewardData = new RewardData();

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
            UI.chargeBtn.ClearClickCallBack();
            //UI.chargeBtn.interactable = false;
            UI.chargeBtnText.text = "已  领  取";
        }
        else
        {
            if (activityInfo.currNum >= activityInfo.needNum)
            {
                ColorUtil.DeGray(UI.chargeBtn);
                UI.chargeBtn.ClearClickCallBack();
                UI.chargeBtn.AddClickCallBack(clickCharge);
                //UI.chargeBtn.interactable = true;
                UI.chargeBtnText.text = "领   取";
            }
            else
            {
                ColorUtil.DeGray(UI.chargeBtn);
                UI.chargeBtn.ClearClickCallBack();
                UI.chargeBtn.AddClickCallBack(clickCharge);
                //UI.chargeBtn.interactable = true;
                UI.chargeBtnText.text = "前往充值";
            }
        }
    }

    private void clickCharge()
    {
        if (activityInfo!=null&&!activityInfo.hasGiveKey)
        {
            if (activityInfo.currNum >= activityInfo.needNum)
            {
                GoodactivityCGHandler.sendCGGoodActivityGetBonus(activityInfo.activityId,activityInfo.targetId);
            }
            else
            {
                LinkParse.Ins.linkToFunc(FunctionIdDef.CHONGZHI);
            }
        }
    }

    public void Destroy()
    {
        UI.chargeBtn.ClearClickCallBack();
        for (int i = 0; rewarditem!=null&&i < rewarditem.Count; i++)
        {
            rewarditem[i].Destroy();
        }
        if(rewarditem!=null)rewarditem.Clear();
        rewarditem = null;
    }
}
