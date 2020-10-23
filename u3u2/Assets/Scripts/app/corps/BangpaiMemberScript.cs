using UnityEngine;
using System.Collections;
using app.net;
using app.utils;
using app.tips;
using app.zone;

public class BangpaiMemberScript  
{
    public BangpaiItemUI UI;
    private BangpaiJingsaiJiangliView jiangliView;
    AllocateMemberInfo info;


    public BangpaiMemberScript(BangpaiItemUI UI,BangpaiJingsaiJiangliView jiangliView)
    {
        this.UI = UI;
        this.jiangliView = jiangliView;
        UI.btn_fenpeijiangli.SetClickCallBack(OnClickFenpeiJiangli);
        EventTriggerListener.Get(UI.tfJinXiangzi.gameObject).onClick = OnclickXiangzi;
        EventTriggerListener.Get(UI.tfYinXiangzi.gameObject).onClick = OnclickXiangzi;
        EventTriggerListener.Get(UI.tfTieXiangzi.gameObject).onClick = OnclickXiangzi;
    }

    public void SetData(AllocateMemberInfo info)
    {
        UI.text_name.text = info.playerName;
        UI.text_gongxianjifen.text = info.score.ToString();
        UI.text_dengji.text = info.playerLevel.ToString();
        UI.text_zhiwu.text =  CorpTitleDef.GetCorpTitleName(info.corpsJob);
        UI.text_zongheshili.text = info.playerPower.ToString();
        this.info = info;
        bool haveReward = false;
        AllocateItemInfo[] itemInfos = info.afterAllocateItemInfos;

        UI.btn_fenpeijiangli.gameObject.SetActive(false);
        for (int i = 0; i < info.afterAllocateItemInfos.Length; i++)
        {
            if (info.afterAllocateItemInfos[i].itemId == BangpaiJingsaiJiangliView.JINBAOXIANG_ITEM_ID)
            {
                UI.tfJinXiangzi.gameObject.SetActive(true);
                UI.tfYinXiangzi.gameObject.SetActive(false);
                UI.tfTieXiangzi.gameObject.SetActive(false);
                haveReward = true;
            }
            else if (info.afterAllocateItemInfos[i].itemId == BangpaiJingsaiJiangliView.YINBAOXIANG_ITEM_ID)
            {
                UI.tfJinXiangzi.gameObject.SetActive(false);
                UI.tfYinXiangzi.gameObject.SetActive(true);
                UI.tfTieXiangzi.gameObject.SetActive(false);
                haveReward = true;
            }
            else if (info.afterAllocateItemInfos[i].itemId == BangpaiJingsaiJiangliView.TIEBAOXIANG_ITEM_ID)
            {
                UI.tfJinXiangzi.gameObject.SetActive(false);
                UI.tfYinXiangzi.gameObject.SetActive(false);
                UI.tfTieXiangzi.gameObject.SetActive(true);
                haveReward = true;
            }

        }
        
        UI.btn_fenpeijiangli.gameObject.SetActive(!haveReward);
        if (!haveReward)
        {
            UI.tfJinXiangzi.gameObject.SetActive(false);
            UI.tfYinXiangzi.gameObject.SetActive(false);
            UI.tfTieXiangzi.gameObject.SetActive(false);
        }
        
    }

    private void OnClickFenpeiJiangli()
    {
        GCCorpsMemberInfo mymemberinfo = CorpModel.Ins.MyCorpMemberInfo;
        if (mymemberinfo.getCorpsMemInfo().memJob == (int)CorpTitleDef.CorpTitleType.BANGZHU)
        {
            jiangliView.fenpeiJiangliView.SetData(info);
        }
        else
        {
            ZoneBubbleManager.ins.BubbleSysMsg("只有帮主有分配权限");
        }
      
    }

    private void OnclickXiangzi(GameObject obj)
    {
        if (obj == UI.tfJinXiangzi.gameObject)
        {
            ItemTips.Ins.ShowTips(BangpaiJingsaiJiangliView.JINBAOXIANG_ITEM_ID);
        }
        else if (obj == UI.tfYinXiangzi.gameObject)
        {
            ItemTips.Ins.ShowTips(BangpaiJingsaiJiangliView.YINBAOXIANG_ITEM_ID);
        }
        else
        {
            ItemTips.Ins.ShowTips(BangpaiJingsaiJiangliView.TIEBAOXIANG_ITEM_ID);
        }
    }



}
