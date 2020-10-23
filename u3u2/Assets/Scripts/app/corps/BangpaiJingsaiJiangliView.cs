using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.net;
using app.tips;
using app.jiangli;
using app.zone;
using app.corp;

public class BangpaiJingsaiJiangliView : BaseUI 
{
    public const int JINBAOXIANG_ITEM_ID = 20166;
    public const int YINBAOXIANG_ITEM_ID = 20167;
    public const int TIEBAOXIANG_ITEM_ID = 20168;
    public BangpaijingsaijiangliUI UI;
    private GCOpenAllocatePanel data;
    private List<BangpaiMemberScript> memberScript = new List<BangpaiMemberScript>();
    public FenpeijiangliView fenpeiJiangliView;
    private CorpsActivityView activityView;

    public BangpaiJingsaiJiangliView(BangpaijingsaijiangliUI UI,CorpsActivityView activityView)
    {
        this.UI = UI;
        this.activityView = activityView;
        CorpModel.Ins.addChangeEvent(CorpModel.OPEN_ALLOCATE_PANEL, UpdateData);
        UI.defaultItemScript.gameObject.SetActive(false);
        fenpeiJiangliView = new FenpeijiangliView(UI.fenpeiJiangliUI);
        EventTriggerListener.Get(UI.objJin).onClick = OnclickXiangzi;
        EventTriggerListener.Get(UI.objYin).onClick = OnclickXiangzi;
        EventTriggerListener.Get(UI.objTie).onClick = OnclickXiangzi;

    }

    public void CallData()
    {
        UI.fenpeiJiangliUI.gameObject.SetActive(false);
        CorpsCGHandler.sendCGOpenAllocatePanel(3);
    }

    private void UpdateData(RMetaEvent e = null)
    {
        data = CorpModel.Ins.GCOpenAllocatePanel;
        if (data.getAllocateMemberInfoList().Length > 0)
        {
            ShowMembers();
            SetUIInfo();
            activityView.UI.tfScrollView.gameObject.SetActive(false);
            UI.gameObject.SetActive(true);
        }
        else
        {
            
            ZoneBubbleManager.ins.BubbleSysMsg("无帮派竞赛奖励数据");
        }
    }

    private void ShowMembers()
    {
        AllocateMemberInfo[] memberinfos = data.getAllocateMemberInfoList();
        //List<AllocateMemberInfo> infos = new List<AllocateMemberInfo>();
        //for (int i = 0; i < memberinfos.Length; i++)
        //{
        //    infos.Add(memberinfos[i]);
        //}

        //infos.Sort(delegate(AllocateMemberInfo x, AllocateMemberInfo y)
        //{
        //    if (x.score != y.score)
        //    {
        //        return y.score.CompareTo(x.score);
        //    }
        //    else
        //    {
        //        if (x.playerPower != y.playerPower)
        //        {
        //            return y.playerPower.CompareTo(x.playerPower);
        //        }
        //        else
        //        {
        //            return x.roleId.CompareTo(y.roleId);
        //        }
        //    }
        //});

        for (int i = 0; i < memberinfos.Length; i++)
        {
            if (i == memberScript.Count)
            {
                GameObject obj = GameObject.Instantiate(UI.defaultItemScript.gameObject);
                obj.transform.SetParent(UI.tfGrid);
                obj.transform.localScale = Vector3.one;
                obj.SetActive(true);
                BangpaiMemberScript script = new BangpaiMemberScript(obj.GetComponent<BangpaiItemUI>(),this);
                memberScript.Add(script);
            }
            memberScript[i].UI.gameObject.SetActive(true);
            memberScript[i].SetData(memberinfos[i]);
        }
        for (int i = memberinfos.Length; i < memberScript.Count; i++)
        {
            memberScript[i].UI.gameObject.SetActive(false);
        }

    }

    private void SetUIInfo()
    {
        AllocateItemInfo[] infos = data.getBeforeAllocateItemInfos();
        int jinNum = 0;
        int yinNum = 0;
        int tieNum = 0;

        int haveNum = 0;
        for (int i = 0; i < infos.Length; i++)
        {
            if (infos[i].itemId == JINBAOXIANG_ITEM_ID)
            {
                jinNum = infos[i].num;
                haveNum++;
            }
            else if (infos[i].itemId == YINBAOXIANG_ITEM_ID)
            {
                yinNum = infos[i].num;
                haveNum++;
            }
            else if (infos[i].itemId == TIEBAOXIANG_ITEM_ID)
            {
                tieNum = infos[i].num;
                haveNum++;
            }
        }
        if (haveNum > 0)
        {
            UI.tfYoujiangli.gameObject.SetActive(true);
            UI.tfFenpeiwan.gameObject.SetActive(false);
            UI.text_jinNum.text = jinNum.ToString();
            UI.text_yinNum.text = yinNum.ToString();
            UI.text_tieNum.text = tieNum.ToString();
        }
        else
        {
            UI.tfYoujiangli.gameObject.SetActive(false);
            UI.tfFenpeiwan.gameObject.SetActive(true);
        }


    }

    private void OnclickXiangzi(GameObject obj)
    {
        if (obj == UI.objJin)
        {
            ItemTips.Ins.ShowTips(BangpaiJingsaiJiangliView.JINBAOXIANG_ITEM_ID);
        }
        else if (obj == UI.objYin)
        {
            ItemTips.Ins.ShowTips(BangpaiJingsaiJiangliView.YINBAOXIANG_ITEM_ID);
        }
        else
        {
            ItemTips.Ins.ShowTips(BangpaiJingsaiJiangliView.TIEBAOXIANG_ITEM_ID);
        }
    }

    public override void Destroy()
    {

        CorpModel.Ins.removeChangeEvent(CorpModel.OPEN_ALLOCATE_PANEL, UpdateData);
        data = null;
        if (memberScript != null)
        {

            memberScript.Clear();
            memberScript = null;
        }

        if(fenpeiJiangliView!=null)
        {

            fenpeiJiangliView.Destroy();
            fenpeiJiangliView = null;
        }
        base.Destroy();
        UI = null; 
    //public FenpeijiangliView fenpeiJiangliView;
    }


}
