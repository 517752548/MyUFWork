using System;
using System.Collections.Generic;
using System.Linq;
using app.human;
using app.jiangli;
using app.net;
using UnityEngine;
using UnityEngine.UI;

public class ZhaoCaiJinBaoScript
{
    public ZhaoCaiJinBaoUI UI;

    public UGUIImageText touruNum;
    public UGUIImageText chanchuNum;

    public MoneyItemScript touruMoney;
    public MoneyItemScript haveMoney;

    public List<Text> logList;
    private GoodActivityRewardInfos showReward = null;

    public ZhaoCaiJinBaoScript(ZhaoCaiJinBaoUI ui)
    {
        //招财进宝，为列表，但只显示一个
        //hasgivekey为false的第一个,按照列表顺序，若都已投，显示最后一个 且不能投入
        //投入curnum，最多产出curnum2

        UI = ui;
        touruMoney = new MoneyItemScript(UI.touruMoney);
        haveMoney = new MoneyItemScript(UI.haveMoney);
        logList = new List<Text>();
        UI.chargeBtn.AddClickCallBack(clickCharge);
        
    }

    private void clickCharge()
    {
        if (showReward!=null)
        {
            MoneyCheck.Ins.Check(showReward.currNumSecond, showReward.currNum,sureHandler);
        }
    }

    private void sureHandler(RMetaEvent e)
    {
        if (showReward != null)
        {
            GoodactivityCGHandler.sendCGGoodActivityGetBonus(showReward.activityId, showReward.targetId);
        }
    }

    public void setData(GoodActivityInfo activityinfo)
    {
        //结束时间
        DateTime dt = new DateTime(1970, 1, 1);
        dt = dt.AddMilliseconds(activityinfo.endTime);
        UI.endTime.text = dt.ToString("yyyy-MM-dd HH:mm:ss");

        //列表内容
        List<GoodActivityRewardInfos> list = GoodActivityRewardInfos.GetRewardItems(activityinfo);

        showReward = null;
        UI.defaultText.gameObject.SetActive(false);

        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].hasGiveKey)
            {
                showReward = list[i];
                break;
            }
        }
        if (showReward==null)
        {
            return;
        }
        if (touruNum == null)
        {
            touruNum = new UGUIImageText();
            touruNum.SetParent(UI.touruGo.transform);
            touruNum.gameObject.transform.localPosition = Vector3.zero;
            touruNum.gameObject.transform.localScale = Vector3.one;
        }
        if (chanchuNum == null)
        {
            chanchuNum = new UGUIImageText();
            chanchuNum.SetParent(UI.fanhuanGo.transform);
            chanchuNum.gameObject.transform.localPosition = Vector3.zero;
            chanchuNum.gameObject.transform.localScale = Vector3.one;
        }
        string touru = showReward.currNum+"";
        string[] content = new string[touru.Length];
        for (int i = 0; i < touru.Length; i++)
        {
            content[i] = touru.ToCharArray()[i].ToString() + "_6";
        }
        touruNum.Clear();
        touruNum.SetContent(PathUtil.Ins.uiDependenciesPath, content);

        string fanhuan = showReward.needNum + "";
        string[] content1 = new string[fanhuan.Length];
        for (int i = 0; i < fanhuan.Length; i++)
        {
            content1[i] = fanhuan.ToCharArray()[i].ToString() + "_6";
        }
        chanchuNum.Clear();
        chanchuNum.SetContent(PathUtil.Ins.uiDependenciesPath, content1);

        touruMoney.SetMoney(showReward.currNumSecond, showReward.currNum, true, false);
        haveMoney.SetMoney(showReward.currNumSecond, Human.Instance.GetCurrencyValue(showReward.currNumSecond), false, false);
        UI.maxget.text = "最多可获得" +showReward.needNum+CurrencyTypeDef.GetCurrencyName(showReward.needNumSecond);
        
        List<string> logs = activityinfo.logList.ToList();

        UI.defaultText.gameObject.SetActive(false);
        for (int i=0;i<logs.Count;i++)
        {
            if (i>=logList.Count)
            {
                Text log = GameObject.Instantiate(UI.defaultText);
                log.gameObject.SetActive(true);
                log.transform.SetParent(UI.grid.transform);
                log.transform.localScale = Vector3.one;
                logList.Add(log);
            }
            logList[i].gameObject.SetActive(true);
            logList[i].gameObject.transform.SetAsLastSibling();
            logList[i].text = logs[i];
        }
        for (int i=logs.Count;i<logList.Count;i++)
        {
            logList[i].gameObject.SetActive(false);
        }
    }

    public static bool hasReward(GoodActivityInfo activityinfo)
    {
        //列表内容
        List<GoodActivityRewardInfos> list = GoodActivityRewardInfos.GetRewardItems(activityinfo);
        GoodActivityRewardInfos showreward = null;

        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].hasGiveKey)
            {
                showreward = list[i];
                break;
            }
        }
        if (showreward == null)
        {
            return false;
        }
        return (Human.Instance.GetCurrencyValue(showreward.currNumSecond) >= showreward.currNum);
    }

    public void Destroy()
    {
        if(UI!=null)UI.chargeBtn.ClearClickCallBack();
        if (touruMoney!=null)
        {
            touruMoney.Destroy();
            touruMoney = null;
        }
        if (haveMoney != null)
        {
            haveMoney.Destroy();
            haveMoney = null;
        }
        for (int i = 0; logList!=null&&i < logList.Count; i++)
        {
            GameObject.DestroyImmediate(logList[i], true);
        }
        if (logList!=null) logList.Clear();
        if (touruNum != null)
        {
            touruNum.Destroy();
            touruNum = null;
        }
        if (chanchuNum != null)
        {
            chanchuNum.Destroy();
            chanchuNum = null;
        }
        showReward = null;
        GameObject.DestroyImmediate(UI,true);
        UI = null;
    }
}