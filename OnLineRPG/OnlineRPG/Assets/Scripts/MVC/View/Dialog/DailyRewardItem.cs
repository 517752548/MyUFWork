using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using Spine.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class DailyRewardItem : MonoBehaviour
{
    public string DailyRewardIndex;
    public Transform fromCoin;
    public TextMeshProUGUI progressText;
    public Slider progressImage;
    public Transform content2;
    public Transform content1;
    public Text[] coinText;
    public Animator selfAnimator;

    private int currentLength = 0;

    private int MaxStars;
    private int coinReward;
    private string RewardPetID;
    private DailyRewardStatus currentStatus = DailyRewardStatus.Locked;
    private GameObject petCache;
    private DailyChallengeEventDialog _dailyChallengeEventDialog;
    
    public void Init(DailyChallengeEventDialog _dailyChallengeEventDialog,int coin,string petid,int star)
    {
        this._dailyChallengeEventDialog = _dailyChallengeEventDialog;
        coinReward = coin;
        RewardPetID = petid;
        MaxStars = star;
        for (int i = 0; i < coinText.Length; i++)
        {
            coinText[i].text = coinReward.ToString();
        }

        SetStatus(currentStatus);
        LoadPet();
    }
    private async void LoadPet()
    {
        Pets pet = PreLoadManager.GetPreLoadConfig<Pets>(ViewConst.asset_Pets_Pet);
        for (int i = 0; i < pet.dataList.Count; i++)
        {
            if (pet.dataList[i].ID == RewardPetID)
            {
                GameObject temp = await Addressables.LoadAssetAsync<GameObject>(pet.dataList[i].prefab + ".prefab").Task;
                StartCoroutine(CreatPet(temp));
            }
        }
    }

    IEnumerator CreatPet(GameObject temp)
    {
        GameObject petObj = null;
        yield return petObj = Instantiate(temp);
        SkeletonGraphic skeleton = petObj.GetComponent<SkeletonGraphic>();
        if (skeleton)
        {
            skeleton.freeze = true;
            skeleton.color = Color.black;
        }

        
        petObj.transform.SetParent(content2, false);
        GameObject petObj2 = null;
        yield return petObj2 = Instantiate(temp);
        petCache = petObj2;
        petObj2.transform.SetParent(content1, false);
    }

    public int GetNeedStar()
    {
        return MaxStars - (currentLength == -1 ? 0 : currentLength);
    }

    public void SetStars(int star)
    {
        if (star > 0)
        {
            currentLength = star;
        }

        if (currentLength >= MaxStars)
        {
            currentStatus = DailyRewardStatus.Rewarded;
            SetStatus(currentStatus);
        }
        else if (currentLength >= 0)
        {
            currentStatus = DailyRewardStatus.Collecting;
            SetStatus(currentStatus);
        }

        progressText.text = string.Format("{0}/{1}", star < 0 ? 0 : star, MaxStars);
        progressImage.value = (float) star / MaxStars;
    }

    public void AnimUnLock()
    {
        currentStatus = DailyRewardStatus.Collecting;
        progressText.text = string.Format("{0}/{1}", 0, MaxStars);
        progressImage.value = 0;
        selfAnimator.SetTrigger("tounlock");
        TimersManager.SetTimer(0.4f, () =>
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_NewPetAppear);
        });
    }

    public void AnimFinish()
    {
        selfAnimator.SetTrigger("tofinish");
        TimersManager.SetTimer(0.4f, () =>
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_window_pet_unlock);
        });
    }


    public IEnumerator AddStars()
    {
        if (currentLength < 0)
        {
            currentLength = 0;
        }

        if (currentLength <= MaxStars)
        {
            currentLength++;
        }
        
        if (currentStatus == DailyRewardStatus.Locked)
        {
            currentStatus = DailyRewardStatus.Collecting;
            SetStatus(DailyRewardStatus.Collecting);
            progressText.text = string.Format("{0}/{1}", currentLength, MaxStars);
            progressImage.DOValue((float) currentLength / MaxStars, 0.4f).SetEase(Ease.Linear);
            //AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_Daily_addpower);
        }
        else if (currentStatus == DailyRewardStatus.Collecting)
        {
            if (currentLength == MaxStars)
            {
                currentStatus = DailyRewardStatus.Rewarded;
                progressText.text = string.Format("{0}/{1}", currentLength, MaxStars);
                progressImage.DOValue((float) currentLength / MaxStars, 0.4f).OnComplete(() =>
                {
                    FlyRewardView.instance.FlyCoin(fromCoin.position, null);
                    //SetStatus(DailyRewardStatus.Rewarded);
                    AnimFinish();
                    //AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_Daily_addpower);
                }).SetEase(Ease.Linear);
                
                yield return new WaitForSeconds(1.4f);
                //AppEngine.SSystemManager.GetSystem<BagSystem>().RewardItem(21,0,"DailyStepReward" + MaxStars,RewardPetID);
                FlyPet();
                //AppEngine.SSystemManager.GetSystem<BagSystem>().RewardItem(10, coinReward, "DailyStepReward" + MaxStars);
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                progressText.text = string.Format("{0}/{1}", currentLength, MaxStars);
                progressImage.DOValue((float) currentLength / MaxStars, 0.4f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    //AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_Daily_addpower);
                });
            }
        }
        else if (currentStatus == DailyRewardStatus.Rewarded)
        {
        }
    }

    public void ClosePanel()
    {
        content1.gameObject.SetActive(false);
        content2.gameObject.SetActive(false);
    }

    private void SetStatus(DailyRewardStatus status)
    {
        switch (status)
        {
            case DailyRewardStatus.Locked:
                // LockedGameObject.SetActive(true);
                // CollectingGameObject.SetActive(false);
                // RewardedGameObject.SetActive(false);
                //lockBG.SetActive(true);
                selfAnimator.SetTrigger("lock");
                break;
            case DailyRewardStatus.Rewarded:
                // LockedGameObject.SetActive(false);
                // CollectingGameObject.SetActive(false);
                // RewardedGameObject.SetActive(true);
                //lockBG.SetActive(false);
                selfAnimator.SetTrigger("finish");

                break;
            case DailyRewardStatus.Collecting:
                // LockedGameObject.SetActive(false);
                // CollectingGameObject.SetActive(true);
                // RewardedGameObject.SetActive(false);
                //lockBG.SetActive(false);
                selfAnimator.SetTrigger("unlock");

                break;
        }
        
        
    }

    private void FlyPet()
    {
        _dailyChallengeEventDialog.FlyPet(petCache);
    }

    private enum DailyRewardStatus
    {
        Rewarded,
        Collecting,
        Locked
    }
}