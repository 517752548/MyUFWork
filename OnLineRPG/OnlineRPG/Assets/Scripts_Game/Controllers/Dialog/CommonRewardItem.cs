using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using Scripts_Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class CommonRewardItem : MonoBehaviour
{
    public TextMeshProUGUI tittle;
    public TextMeshProUGUI numberText;
    public Image rewardImage;
    public Animator itemAnimator;
    public Transform item;
    public GameObject adimage;
    private bool isadreward;

    public async void SetData(RewardInventory reward, bool isAdreward = false)
    {
        var inventory = RewardMgr.GetInventoryConfig(reward.type);
        tittle.text = inventory?.Name;
        numberText.text = $"+{reward.count}";
        rewardImage.sprite = await Addressables.LoadAssetAsync<Sprite>(inventory?.Sprite + ".png").Task;
        adimage.SetActive(isAdreward);
        isadreward = isAdreward;
        gameObject.SetActive(!isadreward);
    }

    /// <summary>
    /// 飞行动画
    /// </summary>
    /// <param name="fromTransform"></param>
    public void DoFlyAnim(Vector3 position)
    {
        if(isadreward)
            gameObject.SetActive(isadreward);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_gift_itemappear);
        item.position = position;
        item.DOLocalMove(Vector3.zero, 0.5f);
        itemAnimator.SetTrigger("box");
    }

    /// <summary>
    /// 原地pia动画
    /// </summary>
    public void DoPiaAnim()
    {
        if(isadreward)
            gameObject.SetActive(isadreward);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_gift_item_pop);
        itemAnimator.SetTrigger("common");
    }

    private string GetTittle(int id)
    {
        BagItems_Data bagitem = PreLoadManager.GetPreLoadConfig<BagItems>(ViewConst.asset_BagItems_ItemReward).GetTarget(id.ToString());
        return bagitem.Name;
    }
    
    private string GetImage(int id)
    {
        if (id == 10)
        {
            return ViewConst.png_Gift_Coin;
        }else if (id == 11)
        {
            return ViewConst.png_Gift_Hint_1;
        }else if (id == 12)
        {
            return ViewConst.png_Gift_Hint_2;
        }else if (id == 13)
        {
            return ViewConst.png_Gift_Hint_3;
        }else if (id == 14)
        {
            return ViewConst.png_Gift_Hint_4;
        }

        return "";
    }
}
