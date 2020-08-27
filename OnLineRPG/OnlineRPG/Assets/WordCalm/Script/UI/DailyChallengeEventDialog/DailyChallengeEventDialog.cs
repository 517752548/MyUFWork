using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyChallengeEventDialog : UIWindowBase
{
    public Text TodayDayText;

    public DailyRewardItem[] dailyrewardItems;

    public GameObject GuideGameObject;

    public GameObject PlayButton;
    public GameObject CompleteButton;
    public TextMeshProUGUI monthText;
    public Animator flyStarAnim;

    private bool canClosePanel = true;
    private int lastStar;
    public override void OnOpen()
    {
        lastStar = AppEngine.SyncManager.Data.Stars.LastValue;
        TodayDayText.text = string.Format("{0}", AppEngine.STimeHeart.RealTime.Day);
        DailyRewardData dailyabconfig = AppEngine.SSystemManager.GetSystem<DailySystem>().GetDailyRewardConfig().GetDailyRewardMonthReward();
        for (int i = 0; i < dailyrewardItems.Length; i++)
        {
            dailyrewardItems[i].Init(this,dailyabconfig.coins[i],dailyabconfig.pets[i],dailyabconfig.stars[i]);
        }
        CreateUI();
        //AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_Daily_star_appear);
        int currentStars = lastStar;
        int newStars = AppEngine.SyncManager.Data.Stars.Value;
        int distance = newStars - currentStars;
        if (distance == 0)
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_panel_show);
        }

        SetButton();
        monthText.text = string.Format(new System.Globalization.CultureInfo("en-US"),"{0:MMMM}",AppEngine.STimeHeart.RealTime);
    }

    private void SetButton()
    {
        if (AppEngine.SyncManager.Data.ToadyFinished.Value)
        {
            PlayButton.gameObject.SetActive(false);
            CompleteButton.gameObject.SetActive(true);
        }
        else
        {
            PlayButton.gameObject.SetActive(true);
            CompleteButton.gameObject.SetActive(false);
        }
    }
    private void CheckGuide()
    {
        if ( DataManager.ProcessData.showDailyGuide)
        {
            DataManager.ProcessData.showDailyGuide = false;
            GuideGameObject.SetActive(true);
        }
    }
    private void CreateUI()
    {
        int currentStars = lastStar;
        //是否需要开启下一个
        bool showCollecting = false;
        if (currentStars == 0)
        {
            showCollecting = true;
        }

        for (int i = 0; i < dailyrewardItems.Length; i++)
        {
            int needStars = dailyrewardItems[i].GetNeedStar();
            if (currentStars >= needStars)
            {
                dailyrewardItems[i].SetStars(needStars);
                currentStars -= needStars;
                if (currentStars == 0)
                {
                    showCollecting = true;
                }
            }
            else if (currentStars > 0)
            {
                dailyrewardItems[i].SetStars(currentStars);
                currentStars = 0;
            }
            else if (currentStars <= 0)
            {
                if (showCollecting)
                {
                    dailyrewardItems[i].SetStars(0);
                    showCollecting = false;
                }
            }
        }
    }

    public void DoFlyAnimator()
    {
        StartCoroutine(DoAnimator());
    }
    private IEnumerator DoAnimator()
    {
        yield return new WaitForSeconds(0.5f);
        int currentStars = lastStar;
        int newStars = AppEngine.SyncManager.Data.Stars.Value;
        int distance = newStars - currentStars;
        if (distance > 0)
        {
            canClosePanel = false;
            TimersManager.SetTimer(2, () => { canClosePanel = true; });
            while (distance > 0)
            {
                distance--;
                for (int i = 0; i < dailyrewardItems.Length; i++)
                {
                    if (dailyrewardItems[i].GetNeedStar() > 0)
                    {
                        if (dailyrewardItems[i].GetNeedStar() == 1)
                        {
                            flyStarAnim.SetTrigger(string.Format("D{0}",i + 1));
                            
                            // TimersManager.SetTimer(0.5f, () =>
                            // {
                            //     AppEngine.SSoundManager.PlaySFX(ViewConst.wav_daily_petget);
                            // });
                            yield return new WaitForSeconds(2f);
                            yield return dailyrewardItems[i].AddStars();
                            yield return new WaitForSeconds(0.4f);
                            
                            if (i + 1 < dailyrewardItems.Length)
                            {
                                //dailyrewardItems[i + 1].SetStars(0);
                                dailyrewardItems[i + 1].AnimUnLock();
                            }
                        }
                        else
                        {
                            flyStarAnim.SetTrigger(string.Format("D{0}",i + 1));
                            AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_Daily_star_appear);
                            yield return new WaitForSeconds(2f);
                            yield return dailyrewardItems[i].AddStars();
                            yield return new WaitForSeconds(0.4f);
                        }

                        break;
                    }
                }
            }

            AppEngine.SyncManager.Data.Stars.ResetLastValue();
        }
        CheckGuide();
    }

    private bool clickHome = false;
    public void ClickPlay()
    {
        
        TimersManager.SetTimer(0.5f, () =>
        {
            clickHome = false;
        });
        if (AppEngine.SyncManager.Data.ToadyFinished.Value)
        {
            UIManager.ShowMessage("Today Finished!");
            return;
        }
        UIManager.CloseUIWindow(this);
        AppEngine.SSystemManager.GetSystem<DailySystem>().PlayDailyGame();
    }

    public void ClickBack()
    {
        if(!canClosePanel)
            return;
        for (int i = 0; i < dailyrewardItems.Length; i++)
        {
            dailyrewardItems[i].ClosePanel();
        }
        UIManager.CloseUIWindow(this);
    }

    public override void OnClose()
    {
        base.OnClose();
        AppEngine.SyncManager.Data.Stars.ResetLastValue();
    }

    public void OneMoreTime()
    {
        UIManager.CloseUIWindow(this);
        AppEngine.SSystemManager.GetSystem<DailySystem>().PlayDailyGame();
    }
    
    public void FlyPet(GameObject pet)
    {
        
        HomeThemeRoot _HomeSceneController = FindObjectOfType<HomeThemeRoot>();
        if (_HomeSceneController)
        {
            GameObject newPet = Instantiate(pet);
            newPet.transform.SetParent(transform,false);
            newPet.transform.position = pet.transform.position;
            newPet.transform.localScale = Vector3.one * 0.5f;
            newPet.transform.DOMove(
                new Vector3(_HomeSceneController.SkinPoint.transform.parent.position.x,
                    _HomeSceneController.SkinPoint.transform.parent.position.y - 0.15f , pet.transform.position.z), 0.8f).OnComplete(
                () =>
                {
                    AppEngine.SSoundManager.PlaySFX(ViewConst.wav_petFlyFinish);
                    Destroy(newPet);
                });
            newPet.transform.DOScale(0.1f, 0.8f).OnComplete(() =>
            {
                newPet.SetActive(false);
                EventDispatcher.TriggerEvent(GlobalEvents.PetAdd);
            });
        }
    }

    public void StarDown()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_Daily_addpower);
    }
}