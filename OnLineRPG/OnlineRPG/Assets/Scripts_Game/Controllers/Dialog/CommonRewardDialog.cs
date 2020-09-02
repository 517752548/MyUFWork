using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using Scripts_Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class CommonRewardDialog : UIWindowBase
{
    public TextMeshProUGUI TittleText;
    public CanvasGroup ClamButton;
    public CanvasGroup adbuttonButton;
    public CommonRewardData _rewardData;

    public Transform Layout1;
    public Transform Layout2;
    public GameObject boxBG;
    public GameObject SignTittle;
    public Transform BoxContent;
    public GameObject commonBG;

    public Image adrewardImage;
    public TextMeshProUGUI adrewardNumber;
    public Image adrewardImage2;
    public TextMeshProUGUI adrewardNumber2;

    public GameObject videoBtneffect;

    private bool hasADReward;

    private List<CommonRewardItem> _rewardItemsList = new List<CommonRewardItem>();
    private List<CommonRewardItem> _adItemList = new List<CommonRewardItem>();
    private bool hasBoxAnim;
    private Animator boxAnimator;
    private List<RewardInventory> rewardList;
    private List<RewardInventory> rewardAdList;
    private int GetCoin;
    private Vector3 boxPosition;

    public override void OnOpen()
    {
        base.OnOpen();
        DataManager.PlayerData.playerGetSubWorldReward.Value = "";
        DataManager.PlayerData.claimPlayerGetSubWorldReward = false;
        _rewardData = objs[0] as CommonRewardData;
        ClamButton.alpha = 0;
        adbuttonButton.alpha = 0;
        ClamButton.interactable = false;
        adbuttonButton.interactable = false;
        TittleText.text = _rewardData.GetTittle();
        hasBoxAnim = _rewardData.HasBoxAnim();
        rewardList = _rewardData.GetReward();
        rewardAdList = RewardMgr.GetVideoRewards(_rewardData.rewardId);
        hasADReward = _rewardData.CanShowAD() && rewardAdList.Count > 0;
        adbuttonButton.gameObject.SetActive(hasADReward);
        if (hasADReward)
            ADAnalyze.ADBtnShow(_rewardData.boxType.ToString());
        RewardInventory coin = rewardList.Find(x => x.type == InventoryType.Coin);
        if (coin != null)
        {
            EventDispatcher.TriggerEvent(GlobalEvents.SkipBalanceAni);
            GetCoin = coin.count;
        }

        if (_rewardData.boxType == RewardBoxType.SignBox1 || _rewardData.boxType == RewardBoxType.SignBox2)
        {
            SignTittle.SetActive(true);
        }

        RewardItem();
        CreatUI();
        SetADImageButton(rewardAdList);
    }

    private void RewardItem()
    {
        //shop的在其他地方增加了，这里不加
        if (!_rewardData.boxType.ToString().Contains("Shop"))
        {
            RewardMgr.RewardInventory(rewardList, _rewardData.RewardSource,
                _rewardData.buyItem, _rewardData.moneyCoast, _rewardData.payType);
            // AppEngine.SSystemManager.GetSystem<BagSystem>().RewardItem(rewardsqueue, _rewardData.boxType.ToString(),
            //     _rewardData.buyItem, _rewardData.moneyCoast, _rewardData.payType);
        }
        else
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_ShopRewardMusic);
        }
    }

    private async void CreatUI()
    {
        GameObject Item = await Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_CommonRewardItem).Task;

        int rewardCount = rewardList.Count;
        GameObject rewardItem = null;
        int k = 0;
        if (rewardCount == 6)
        {
            k = 3;
        }
        else if (rewardCount == 5)
        {
            k = 2;
        }
        else if (rewardCount == 4)
        {
            k = 1;
        }


        for (int i = 0; i < rewardCount; i++)
        {
            if (k > 0)
            {
                rewardItem = Instantiate(Item, Layout1, false);
                CommonRewardItem _commonRewardItem = rewardItem.GetComponent<CommonRewardItem>();
                _commonRewardItem.SetData(rewardList[i]);
                _rewardItemsList.Add(_commonRewardItem);
                k--;
            }
            else
            {
                rewardItem = Instantiate(Item, Layout2, false);
                CommonRewardItem _commonRewardItem = rewardItem.GetComponent<CommonRewardItem>();
                _commonRewardItem.SetData(rewardList[i]);
                _rewardItemsList.Add(_commonRewardItem);
            }
        }

        if (hasADReward)
            for (int i = 0; i < rewardAdList.Count; i++)
            {
                if (rewardCount < 3)
                {
                    rewardItem = Instantiate(Item, Layout2, false);
                }
                else
                {
                    rewardItem = Instantiate(Item, Layout1, false);
                }

                CommonRewardItem _commonRewardItem = rewardItem.GetComponent<CommonRewardItem>();
                _commonRewardItem.SetData(rewardAdList[i], true);
                _adItemList.Add(_commonRewardItem);
            }

        CreatBox();
    }

    private void SetADImageButton(List<RewardInventory> rewardad)
    {
        if (rewardad.Count > 0 && hasADReward)
        {
            BagItems_Data item = RewardMgr.GetInventoryConfig(rewardad[0].type);
            Addressables.LoadAssetAsync<Sprite>(string.Format("{0}.png", item.Sprite)).Completed += op =>
            {
                adrewardImage.sprite = op.Result;
                adrewardNumber.text = string.Format("x{0}", rewardad[0].count);
                adrewardImage2.sprite = op.Result;
                adrewardNumber2.text = string.Format("x{0}", rewardad[0].count);
            };
        }
    }

    private async void CreatBox()
    {
        string boxres = _rewardData.GetBoxRes();
        if (!string.IsNullOrEmpty(boxres))
        {
            BoxContent.gameObject.SetActive(true);
            GameObject box = await Addressables.LoadAssetAsync<GameObject>(boxres).Task;
            box = Instantiate(box, BoxContent, false);
            boxAnimator = box.GetComponent<Animator>();
            boxPosition = boxAnimator.gameObject.transform.position;
        }
        else
        {
            BoxContent.gameObject.SetActive(false);
            AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_GiftDialog);
        }

        StartCoroutine(DoAnimator());
    }

    /// <summary>
    /// 开始动画
    /// </summary>
    /// <returns></returns>
    private IEnumerator DoAnimator()
    {
        if (boxAnimator != null)
        {
            boxBG.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            boxAnimator.SetTrigger("appear");
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_gift_boxdown);
            //宝箱从天而降的时间
            yield return new WaitForSeconds(0.5f);

            boxAnimator.SetTrigger("open");
            if (_rewardData.boxType == RewardBoxType.SignBox1 || _rewardData.boxType == RewardBoxType.SignBox2)
            {
                SignTittle.AddComponent<CanvasGroup>().DOFade(0, 1).OnComplete(() => { SignTittle.SetActive(false); })
                    .SetDelay(1f);
            }

            yield return new WaitForSeconds(_rewardData.GetBoxOpen());
        }
        else
        {
            commonBG.SetActive(true);
        }


        for (int i = 0; i < _rewardItemsList.Count; i++)
        {
            if (boxAnimator != null && hasBoxAnim)
            {
                //宝箱吐出一个奖励
                boxAnimator.SetTrigger("again");
                //宝箱吐出动画的时间
                yield return new WaitForSeconds(0.3f);
                _rewardItemsList[i].DoFlyAnim(boxAnimator.transform.position);
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                _rewardItemsList[i].DoPiaAnim();
                yield return new WaitForSeconds(0.5f);
            }
        }

        ShowClamButton();
    }

    public override void OnClose()
    {
        base.OnClose();
    }

    private void ShowClamButton()
    {
        ClamButton.DOFade(1, 0.5f).OnComplete(() => { ClamButton.interactable = true; });
        if (hasADReward)
        {
            videoBtneffect.SetActive(true);
            adbuttonButton.DOFade(1, 0.5f).OnComplete(() => { adbuttonButton.interactable = true; });
        }
    }

    private void ClickADDisableButton()
    {
        ClamButton.alpha = 0;
        ClamButton.interactable = false;
        adbuttonButton.gameObject.SetActive(false);
    }

    public void ADButtonClick()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            UIManager.ShowMessage("No internet connection");
            return;
        }

        ClickADDisableButton();
        StartCoroutine(WaitForAD());
        if (_rewardData.boxType == RewardBoxType.SignBox1 || _rewardData.boxType == RewardBoxType.SignBox2)
        {
            AppEngine.SAdManager.ShowRewardVideo(AdManager.RewardVideoCallPlace.SignGiftPanel, VideoFinish);
            ADAnalyze.AdBtnClick(_rewardData.boxType.ToString());
            return;
        }

        if (_rewardData.boxType == RewardBoxType.SubWorld)
        {
            AppEngine.SAdManager.ShowRewardVideo(AdManager.RewardVideoCallPlace.SubWorldGiftPanel, VideoFinish);
            ADAnalyze.AdBtnClick(_rewardData.boxType.ToString());
            return;
        }

        if (_rewardData.boxType == RewardBoxType.CupBox)
        {
            AppEngine.SAdManager.ShowRewardVideo(AdManager.RewardVideoCallPlace.BlogGiftPanel, VideoFinish);
            ADAnalyze.AdBtnClick(_rewardData.boxType.ToString());
            return;
        }

        VideoFinish(false);
    }

    /// <summary>
    /// 如果视频广告因为各种问题导致的播放完之后没有回调，那么等待35秒后自动出现收集按钮
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForAD()
    {
        yield return new WaitForSeconds(35);
        ClamButton.DOFade(1, 0.5f).OnComplete(() => { ClamButton.interactable = true; });
    }

    private void VideoFinish(bool ok)
    {
        if (ok)
        {
            StartCoroutine(ShowADReward());
            RewardInventory data = rewardAdList.Find(x => x.type == InventoryType.Coin);
            if (data != null)
            {
                EventDispatcher.TriggerEvent(GlobalEvents.SkipBalanceAni);
                GetCoin += data.count;
            }

            RewardMgr.RewardInventory(rewardAdList, _rewardData.RewardSource + 1, _rewardData.buyItem,
                _rewardData.moneyCoast, _rewardData.payType);
            // AppEngine.SSystemManager.GetSystem<BagSystem>().RewardItem(rewardAdList, string.Format("{0}Ad",_rewardData.boxType.ToString()),
            //     _rewardData.buyItem, _rewardData.moneyCoast, _rewardData.payType);
        }

        Debug.LogError("ad:" + ok);
        ClamButton.DOFade(1, 0.5f).OnComplete(() => { ClamButton.interactable = true; });
    }

    private IEnumerator ShowADReward()
    {
        Vector3 pos = BoxContent.transform.position;
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < _adItemList.Count; i++)
        {
            if (boxAnimator != null && hasBoxAnim)
            {
                //宝箱吐出一个奖励
                boxAnimator.SetTrigger("again");
                //宝箱吐出动画的时间
                yield return new WaitForSeconds(0.15f);
                _adItemList[i].SetActive(true);
                yield return new WaitForSeconds(0.15f);
                _adItemList[i].DoFlyAnim(pos);
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                _adItemList[i].DoPiaAnim();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    private bool buttoncd = false;

    public void ClamButtonClick()
    {
        if (buttoncd)
        {
            return;
        }

        buttoncd = true;
        TimersManager.SetTimer(1.5f, () => { buttoncd = false; });
        if (GetCoin > 0)
        {
            transform.GetChild(0).GetComponent<CanvasGroup>().DOFade(0, 0.3f);
            CommandBinder.DispatchBinding(GameEvent.RubyFly,
                new RubyFlyCommand.RubyFlyData(RubyType.stack, boxBG.transform.position, GetCoin));
            DOTween.Sequence().InsertCallback(0.8f, () =>
            {
                UIManager.CloseUIWindow(this, false);
                _rewardData.callback?.Invoke();
            });
        }
        else
        {
            UIManager.CloseUIWindow(this);
            _rewardData.callback?.Invoke();
        }
    }
}

public class CommonRewardData
{
    //奖励id，如果是商城购买就不填
    public string rewardId;
    public RewardBoxType boxType;
    public RewardSource RewardSource;
    public string Tittle;

    //点击calm后的回调，可填可不填
    public Action callback;

    //如果没有奖励id就赋值具体奖励，下面的如果没有都可以不填
    public int hint1;
    public int hint2;
    public int hint3;
    public int hint4;
    public int hint5;
    public int coin;
    public string buyItem;
    public string moneyCoast;
    public string payType;


    /// <summary>
    /// 是否可以展示广告
    /// </summary>
    /// <returns></returns>
    public bool CanShowAD()
    {
        if (boxType == RewardBoxType.SignBox1 || boxType == RewardBoxType.SignBox2)
        {
            return AppEngine.SAdManager.CanShowRewardVideo(AdManager.RewardVideoCallPlace.SignGiftPanel);
        }

        if (boxType == RewardBoxType.SubWorld)
        {
            return AppEngine.SAdManager.CanShowRewardVideo(AdManager.RewardVideoCallPlace.SubWorldGiftPanel);
        }

        if (boxType == RewardBoxType.CupBox)
        {
            return AppEngine.SAdManager.CanShowRewardVideo(AdManager.RewardVideoCallPlace.BlogGiftPanel);
        }

        return false;
    }

    /// <summary>
    /// 获取所有奖励
    /// </summary>
    /// <returns></returns>
    public List<RewardInventory> GetReward()
    {
        if (!string.IsNullOrEmpty(rewardId))
        {
            return RewardMgr.GetRewards(rewardId);
        }

        List<RewardInventory> rewards = new List<RewardInventory>();
        if (coin > 0)
        {
            rewards.Add(new RewardInventory() {type = InventoryType.Coin, count = coin});
        }

        if (hint1 > 0)
        {
            rewards.Add(new RewardInventory() {type = (InventoryType.Hint1), count = hint1});
        }

        if (hint2 > 0)
        {
            rewards.Add(new RewardInventory() {type = (InventoryType.Hint2), count = hint2});
        }

        if (hint3 > 0)
        {
            rewards.Add(new RewardInventory() {type = (InventoryType.Hint3), count = hint3});
        }
        if (hint4 > 0)
        {
            rewards.Add(new RewardInventory() {type = (InventoryType.Hint4), count = hint4});
        }
        if (hint5 > 0)
        {
            rewards.Add(new RewardInventory() {type = (InventoryType.Bee), count = hint5});
        }

        return rewards;
    }

    public string GetTittle()
    {
        if (!string.IsNullOrEmpty(Tittle))
        {
            return Tittle;
        }

        switch (boxType)
        {
            case RewardBoxType.None:
            case RewardBoxType.ShopNone:
                return "REWARDS";
            case RewardBoxType.OneWord:
                return "FLASH CRAZE REWARDS";
            case RewardBoxType.SubWorld:
                return "LEVEL REWARD";
            case RewardBoxType.Shop1:
            case RewardBoxType.Shop2:
            case RewardBoxType.Shop3:
            case RewardBoxType.Shop4:
                return "SUPER PACK";
            case RewardBoxType.SignBox1:
            case RewardBoxType.SignBox2:
                return "CARE PACKAGE";
            case RewardBoxType.CupBox:
                return "CUP REWARDS";
            case RewardBoxType.DailyWin:
                return "DAILY PUZZLE COMPLETED";
            case RewardBoxType.FastRace:
                return "TOURNAMENT REWARD";
        }

        return "REWARDS";
    }

    public string GetBoxRes()
    {
        switch (boxType)
        {
            case RewardBoxType.None:
            case RewardBoxType.ShopNone:
            case RewardBoxType.DailyWin:
            case RewardBoxType.OneWord:
                return "";
            case RewardBoxType.FastRace:
            case RewardBoxType.SubWorld:
                return ViewConst.prefab_Box_LevelRewards;
            case RewardBoxType.Shop1:
                return ViewConst.prefab_Box_Store_01;
            case RewardBoxType.Shop2:
                return ViewConst.prefab_Box_Store_02;
            case RewardBoxType.Shop3:
                return ViewConst.prefab_Box_Store_03;
            case RewardBoxType.Shop4:
                return ViewConst.prefab_Box_Store_04;
            case RewardBoxType.Shopmore:
                return ViewConst.prefab_Box_Store_500more;
            case RewardBoxType.SignBox1:
                return ViewConst.prefab_Box_7Days_Big;
            case RewardBoxType.SignBox2:
                return ViewConst.prefab_Box_7Days_Small;
            case RewardBoxType.CupBox:
                return ViewConst.prefab_Box_WebRewards;
        }

        return "";
    }

    /// <summary>
    /// 会否有宝箱动画
    /// </summary>
    /// <returns></returns>
    public bool HasBoxAnim()
    {
        switch (boxType)
        {
            case RewardBoxType.None:
            case RewardBoxType.ShopNone:
            case RewardBoxType.Shop1:
            case RewardBoxType.Shop2:
            case RewardBoxType.Shop3:
            case RewardBoxType.Shop4:
            case RewardBoxType.Shopmore:
            case RewardBoxType.DailyWin:
            case RewardBoxType.OneWord:
                return false;
            case RewardBoxType.FastRace:
            case RewardBoxType.SubWorld:
            case RewardBoxType.SignBox1:
            case RewardBoxType.SignBox2:
            case RewardBoxType.CupBox:
                return true;
        }

        return false;
    }

    public float GetBoxOpen()
    {
        switch (boxType)
        {
            case RewardBoxType.None:
            case RewardBoxType.ShopNone:
            case RewardBoxType.Shop1:
            case RewardBoxType.Shop2:
            case RewardBoxType.Shop3:
            case RewardBoxType.Shop4:
            case RewardBoxType.Shopmore:
            case RewardBoxType.DailyWin:
            case RewardBoxType.OneWord:
                return 0f;
            case RewardBoxType.FastRace:
            case RewardBoxType.SubWorld:
                return 1.4f;
            case RewardBoxType.SignBox1:
            case RewardBoxType.SignBox2:
                return 2.4f;
            case RewardBoxType.CupBox:
                return 1.4f;
        }

        return 1f;
    }
}

public enum RewardBoxType
{
    None = 1,
    SubWorld = 2,
    CupBox,
    SignBox1,
    SignBox2,
    Shop1 = 6,
    Shop2 = 7,
    Shop3 = 8,
    Shop4 = 9,
    Shopmore = 10,
    DailyWin,
    OneWord,
    ShopNone = 21,
    FastRace = 22,
}