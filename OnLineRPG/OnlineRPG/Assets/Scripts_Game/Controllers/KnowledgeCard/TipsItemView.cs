using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class TipsItemView : MonoBehaviour
{
    public Transform layout;
    public GameObject TipItem;
    public GameObject comingSoon;
    private bool tipShowing;
    public async void SetData(string rewardId)
    {
        RewardAB_Data _subwordRewardData = null;
        Debug.LogError("奖励id:" + rewardId);
        var _subwordReward = AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetRewardInfoTable();
        for (int i = 0; i < _subwordReward.dataList.Count; i++)
        {
            if (_subwordReward.dataList[i].ID == rewardId)
            {
                _subwordRewardData = _subwordReward.dataList[i];
                break;
            }
        }

        GameObject rewardItem = null;
        if (_subwordRewardData != null)
        {
            if (_subwordRewardData.ITEMID1 > 5)
            {
                rewardItem = Instantiate(TipItem, layout, false);
                rewardItem.transform.Find("Img_Coin").GetComponent<Image>().sprite =
                    await Addressables.LoadAssetAsync<Sprite>(GetRewardImage(_subwordRewardData.ITEMID1)).Task;
                rewardItem.transform.Find("Img_Coin").GetComponent<Image>().DOFade(1, 0.2f);
                rewardItem.transform.Find("Text").GetComponent<Text>().text =
                    string.Format("x{0}", _subwordRewardData.Quantity1);
            }

            if (_subwordRewardData.ITEMID2 > 5)
            {
                rewardItem = Instantiate(TipItem, layout, false);
                rewardItem.transform.Find("Img_Coin").GetComponent<Image>().sprite =
                    await Addressables.LoadAssetAsync<Sprite>(GetRewardImage(_subwordRewardData.ITEMID2)).Task;
                rewardItem.transform.Find("Img_Coin").GetComponent<Image>().DOFade(1, 0.2f);
                rewardItem.transform.Find("Text").GetComponent<Text>().text =
                    string.Format("x{0}", _subwordRewardData.Quantity2);
            }

            if (_subwordRewardData.ITEMID3 > 5)
            {
                rewardItem = Instantiate(TipItem, layout, false);
                rewardItem.transform.Find("Img_Coin").GetComponent<Image>().sprite =
                    await Addressables.LoadAssetAsync<Sprite>(GetRewardImage(_subwordRewardData.ITEMID3)).Task;
                rewardItem.transform.Find("Img_Coin").GetComponent<Image>().DOFade(1, 0.2f);
                rewardItem.transform.Find("Text").GetComponent<Text>().text =
                    string.Format("x{0}", _subwordRewardData.Quantity3);
            }
        }
        else
        {
            comingSoon.SetActive(true);
        }
    }


    private string GetRewardImage(int rewardId)
    {
        switch (rewardId)
        {
            case 10:
                return ViewConst.png_Gift_Coin;
            case 11:
                return ViewConst.png_Gift_Hint_1;
            case 12:
                return ViewConst.png_Gift_Hint_2;
            case 13:
                return ViewConst.png_Gift_Hint_3;
            case 14:
                return ViewConst.png_Gift_Hint_4;
            case 22:
                return ViewConst.png_Gift_Bee;
        }

        return null;
    }

    private void Update()
    {
        if (!tipShowing && Input.anyKeyDown)
        {
            tipShowing = false;
            Destroy(gameObject);
        }
    }
}
