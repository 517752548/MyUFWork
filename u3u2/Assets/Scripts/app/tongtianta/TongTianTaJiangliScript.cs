using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using app.reward;
using app.net;
using app.tongtianta;

public class TongTianTaJiangliScript 
{
    public TongTianTaJiangLiUI UI;
    private GuajiRewardItemUI rewardUI;
    RewardData rewardData = new RewardData();

    List<GuajiRewardItemUI> rewardItems = new List<GuajiRewardItemUI>();

    public TongTianTaJiangliScript(TongTianTaJiangLiUI UI)
    {
        this.UI = UI;
        EventTriggerListener.Get(UI.objBigBg).onClick = Close;
        UI.closeBtn.SetClickCallBack(Close);
        if (rewardUI == null)
        {
            rewardUI = UI.objRewardItem.AddComponent<GuajiRewardItemUI>();
            rewardUI.Init();
        }
        rewardItems.Add(rewardUI);
       
    }

    private void Close(GameObject go)
    {
        UI.gameObject.SetActive(false);
    }

    public void Show()
    {
        UI.gameObject.SetActive(true);
       
        GCTowerReward towerReward = TongTianTaModel.ins.towerReward;
        if (towerReward == null)
        {
            return;
        }
        for (int i = 0; i < towerReward.getShowRewardList().Length; i++)
        {
            if (i == rewardItems.Count)
            {
                GameObject obj = GameObject.Instantiate(rewardUI.gameObject) as GameObject;
                GameObjectUtil.Bind(obj.transform,UI.tfRewardItemRoot,true,true);
                obj.transform.localScale = Vector3.one;
                rewardItems.Add(obj.GetComponent<GuajiRewardItemUI>());
              
            }
            rewardItems[i].gameObject.SetActive(true);
            SetRewardItemData(towerReward.getShowRewardNameList()[i], towerReward.getShowRewardList()[i], rewardItems[i]);
        }
        for (int i = towerReward.getShowRewardList().Length; i < rewardItems.Count; i++)
        {
             rewardItems[i].gameObject.SetActive(false);
        }

    }

    private void SetRewardItemData(string name,string reward,GuajiRewardItemUI itemUI)
    {
        itemUI.textTitle.text = name;
        List<RewardItem> rewardItems = new List<RewardItem>();
        for (int i = 0; i < itemUI.itemUIs.Count; i++)
        {
            rewardItems.Add(new RewardItem(itemUI.itemUIs[i]));
        }
        rewardData.Parse(reward,rewardItems);
    }

    public void Destroy()
    {
        GameObject.DestroyImmediate(UI);
        UI = null;
    }


}
