using System;
using System.Collections.Generic;
using app.db;
using app.human;
using app.jiangli;
using app.model;
using app.net;
using app.reward;
using app.utils;
using app.zone;
using UnityEngine;

public class KaiFuJiJinScript
{
    public KaiFuJiJinUI UI;

    private List<GoodActivityRewardInfos> currentShowActivity;

    public KaiFuJiJinScript(KaiFuJiJinUI ui)
    {
        UI = ui;
        for (int i=0;i<UI.jijinList.Count;i++)
        {
            UI.jijinList[i].buyBtn.AddClickCallBack(clickBuyBtn);
        }
        //开服基金
        //按照分组id分组，一个组是一个档，一档分几步，买，20级领，30级领，按照当前状态显示
        //结束时间 读targetInfo里的
        //curnum,curnum2,neednum,neednum2:花费金子，等级需求，vip权限id，结束时间（需要+开始时间）
        //购买花费的金子：neednum1，购买后，显示下一次领取的货币和数量，读rewardstr，按钮：20级可领取，20读neednum2
        //全部领取完毕，显示已领完，下次打开页签消失

    }

    private void clickBuyBtn(GameObject go)
    {
        for (int i = 0; i < UI.jijinList.Count; i++)
        {
            if (UI.jijinList[i].buyBtn.gameObject == go)
            {
                if (i < currentShowActivity.Count)
                {
                    if (currentShowActivity[i].canGiveKey || currentShowActivity[i].currNum != 0)
                    {
                        MoneyCheck.Ins.Check(CurrencyTypeDef.BOND, currentShowActivity[i].currNum, (RMetaEvent) =>
                        {
                            GoodactivityCGHandler.sendCGGoodActivityGetBonus(currentShowActivity[i].activityId, currentShowActivity[i].targetId);
                        });
                    }
                    else
                    {
                         ZoneBubbleManager.ins.BubbleSysMsg(currentShowActivity[i].currNumSecond + "级可领取");
                    }
                }
                break;
            }
        }
    }

    public void setData(GoodActivityInfo activityinfo)
    {
        //列表内容
        List<GoodActivityRewardInfos> list = GoodActivityRewardInfos.GetRewardItems(activityinfo);

        //结束时间
        DateTime dt = new DateTime(1970, 1, 1);
        dt = dt.AddMilliseconds(activityinfo.startTime+list[0].needNumSecond);
        UI.endTime.text = "活动结束时间："+dt.ToString("yyyy-MM-dd HH:mm:ss");
        //规则
        UI.ruleText.text = activityinfo.desc;
        //每组只显示一档的信息，key:组id，value:活动信息
        Dictionary<int, GoodActivityRewardInfos> groupShowDic = new Dictionary<int, GoodActivityRewardInfos>();
        List<int> groupIdList = new List<int>();

        for (int i=0;i<list.Count;i++)
        {
            if (!groupIdList.Contains(list[i].targetGroup))
            {
                groupIdList.Add(list[i].targetGroup);
                groupShowDic.Add(list[i].targetGroup, list[i]);
            }
            //同一个档，找到已经领取的下一个 显示
            //都没有领取，说明 没有购买
            //都已经领取，说明 已经领完
            if (list[i].hasGiveKey && (i + 1) < list.Count && list[i].targetGroup == list[i+1].targetGroup)
            {
                if (groupShowDic.ContainsKey(list[i].targetGroup))
                {
                    groupShowDic[list[i].targetGroup]=list[i + 1];
                }
                else
                {
                    groupShowDic.Add(list[i].targetGroup, list[i + 1]);
                }
            }
        }
        if (currentShowActivity == null)
        {
            currentShowActivity = new List<GoodActivityRewardInfos>();
        }
        else
        {
            currentShowActivity.Clear();
        }
        //当前显示的数据列表
        for (int i = 0; i < groupIdList.Count; i++)
        {
            currentShowActivity.Add(groupShowDic[groupIdList[i]]);
        }
        for (int i=0;i<currentShowActivity.Count;i++)
        {
            if (i < UI.jijinList.Count)
            {
                UI.jijinList[i].shouyi.text = currentShowActivity[i].desc;
                RewardData rewardData = new RewardData();
                rewardData.ParseReward(currentShowActivity[i].rewardData);
                
                if (currentShowActivity[i].canGiveKey)
                {
                    ColorUtil.DeGray(UI.jijinList[i].buyBtn);
                    //UI.jijinList[i].buyBtn.interactable = true;
                    UI.jijinList[i].buyBtn.ClearClickCallBack();
                    UI.jijinList[i].buyBtn.AddClickCallBack(clickBuyBtn);
                    UI.jijinList[i].btnText.text = "领取";

                    UI.jijinList[i].jiage.text = "可领：" + rewardData.GetRewardToString();
                }
                else
                {
                    if (currentShowActivity[i].currNum!=0)
                    {
                        UI.jijinList[i].jiage.text = "价格：" + currentShowActivity[i].currNum + " 金子";

                        if (currentShowActivity[i].needNum>0)
                        {
                            //Test
                            //currentShowActivity[i].needNum = 20;
                            //有vip等级限制
                            int viplevel = PlayerModel.Ins.GetMyVipLevel();
                            int needVipLevel = VipConfigTemplateDB.Instance.GetVipTeQuanOpenLevel(currentShowActivity[i].needNum);
                            if (viplevel>=needVipLevel)
                            {
                                ColorUtil.DeGray(UI.jijinList[i].buyBtn);
                                //UI.jijinList[i].buyBtn.interactable = true;
                                UI.jijinList[i].buyBtn.ClearClickCallBack();
                                UI.jijinList[i].buyBtn.AddClickCallBack(clickBuyBtn);
                                UI.jijinList[i].btnText.text = "购买";
                            }
                            else
                            {
                                ColorUtil.Gray(UI.jijinList[i].buyBtn);
                                //UI.jijinList[i].buyBtn.interactable = false;
                                UI.jijinList[i].buyBtn.ClearClickCallBack();
                                UI.jijinList[i].btnText.text = "VIP" + needVipLevel + "可购买";
                            }
                        }
                        else
                        {
                            //没有vip等级限制
                            ColorUtil.DeGray(UI.jijinList[i].buyBtn);
                            //UI.jijinList[i].buyBtn.interactable = true;
                            UI.jijinList[i].buyBtn.ClearClickCallBack();
                            UI.jijinList[i].buyBtn.AddClickCallBack(clickBuyBtn);
                            UI.jijinList[i].btnText.text = "购买";
                        }
                    }
                    else
                    {
                        if (currentShowActivity[i].hasGiveKey)
                        {
                            ColorUtil.Gray(UI.jijinList[i].buyBtn);
                            //UI.jijinList[i].buyBtn.interactable = false;
                            UI.jijinList[i].buyBtn.ClearClickCallBack();
                            UI.jijinList[i].btnText.text = "已领完";

                            UI.jijinList[i].jiage.text = "可领：" + rewardData.GetRewardToString();
                        }
                        else
                        {
                            ColorUtil.Gray(UI.jijinList[i].buyBtn);
                            //UI.jijinList[i].buyBtn.interactable = false;
                            UI.jijinList[i].buyBtn.ClearClickCallBack();
                            UI.jijinList[i].btnText.text = currentShowActivity[i].currNumSecond + "级可领取";

                            UI.jijinList[i].jiage.text = "可领：" + rewardData.GetRewardToString();
                        }
                    }
                }
            }
        }
        for (int i=currentShowActivity.Count;i<UI.jijinList.Count;i++)
        {
            UI.jijinList[i].gameObject.SetActive(false);
        }
    }

    public static bool hasReward(GoodActivityInfo activityinfo)
    {
        //列表内容
        List<GoodActivityRewardInfos> list = GoodActivityRewardInfos.GetRewardItems(activityinfo);
        //每组只显示一档的信息，key:组id，value:活动信息
        Dictionary<int, GoodActivityRewardInfos> groupShowDic = new Dictionary<int, GoodActivityRewardInfos>();
        List<int> groupIdList = new List<int>();

        for (int i = 0; i < list.Count; i++)
        {
            if (!groupIdList.Contains(list[i].targetGroup))
            {
                groupIdList.Add(list[i].targetGroup);
                groupShowDic.Add(list[i].targetGroup, list[i]);
            }
            //同一个档，找到已经领取的下一个 显示
            //都没有领取，说明 没有购买
            //都已经领取，说明 已经领完
            if (list[i].hasGiveKey && (i + 1) < list.Count && list[i].targetGroup == list[i + 1].targetGroup)
            {
                if (groupShowDic.ContainsKey(list[i].targetGroup))
                {
                    groupShowDic[list[i].targetGroup] = list[i + 1];
                }
                else
                {
                    groupShowDic.Add(list[i].targetGroup, list[i + 1]);
                }
            }
        }
        
        //当前显示的数据列表
        for (int i = 0; i < groupIdList.Count; i++)
        {
            GoodActivityRewardInfos info=groupShowDic[groupIdList[i]];
            if (i < 3)
            {
                if (info.canGiveKey)
                {
                    return true;
                }
                else
                {
                    if (info.currNum != 0)
                    {
                        if (info.needNum > 0)
                        {
                            //有vip等级限制
                            int viplevel = PlayerModel.Ins.GetMyVipLevel();
                            int needVipLevel = VipConfigTemplateDB.Instance.GetVipTeQuanOpenLevel(info.needNum);
                            if (viplevel >= needVipLevel)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            //没有vip等级限制
                            return Human.Instance.HasEnoughCurrency(CurrencyTypeDef.BOND, info.currNum);
                        }
                    }
                    return false;
                }
            }
        }
        return false;
    }

    public void Destroy()
    {
        if(currentShowActivity!=null)currentShowActivity.Clear();
    }
}