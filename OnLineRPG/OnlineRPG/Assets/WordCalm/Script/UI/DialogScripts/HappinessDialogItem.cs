using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Scripts_Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class HappinessDialogItem : MonoBehaviour
{
    public Image rewardImage;

    public TextMeshProUGUI rewardNum;

    public GameObject mask;

    private int index;

    private string[] rewards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(int index)
    {
        this.index = index;
        EliteWorld currentWorld = AppEngine.SSystemManager.GetSystem<EliteSystem>().GetCurrentWorld();
        if (index == 0)
        {
            rewards = currentWorld.reward1.Split(',');
            BagItems_Data data = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                .GetTarget(rewards[0]);
            LoadItemReward(data,int.Parse(rewards[1]));
        }else if (index == 1)
        {
            rewards = currentWorld.reward1.Split(',');
            BagItems_Data data = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                .GetTarget(rewards[0]);
            LoadItemReward(data,int.Parse(rewards[1]));
        }else if (index == 2)
        {
            rewards = currentWorld.reward2.Split(',');
            BagItems_Data data = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward)
                .GetTarget(rewards[0]);
            LoadItemReward(data,int.Parse(rewards[1]));
        }
    }

    public void Click()
    {
        AppEngine.SyncManager.Data.Elitedata.Value
            .GetElitePref(AppEngine.SSystemManager.GetSystem<EliteSystem>().currentWordID).SetRewardRewarded(index);
        CommonRewardData _commonRewardData = new CommonRewardData();
        _commonRewardData.rewardId = rewards[0];
        _commonRewardData.boxType = RewardBoxType.None;
        _commonRewardData.RewardSource = RewardSource.Happiness;
        _commonRewardData.callback = () =>
        {
            gameObject.SetActive(false);
        };
        UIManager.OpenUIAsync(ViewConst.prefab_CommonRewardDialog, OpenType.Over, null, null, null, _commonRewardData);
    }

    private async void LoadItemReward(BagItems_Data data,int number)
    {
        if (data == null)
        {
            return;
        }
        Sprite image = await Addressables.LoadAssetAsync<Sprite>(data.Sprite + ".png").Task;
        rewardImage.sprite = image;
        rewardNum.text = string.Format("x{0}", number);
    }
    public void SetStatus(bool can)
    {
        char status = AppEngine.SyncManager.Data.Elitedata.Value
            .GetElitePref(AppEngine.SSystemManager.GetSystem<EliteSystem>().currentWordID).rewardStatus[index];
       if (status == '1')
       {
           gameObject.SetActive(false);
       }
       else
       {
           
       }
    }
}
