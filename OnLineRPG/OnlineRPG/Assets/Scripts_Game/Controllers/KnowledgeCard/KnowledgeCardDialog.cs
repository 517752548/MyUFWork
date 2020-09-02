using UnityEngine.UI;
using BetaFramework;
using System;
using UnityEngine;
using System.Collections.Generic;
using Bag;
using TMPro;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

[RequireComponent(typeof(UnityEngine.UI.LoopScrollRect))]
[DisallowMultipleComponent]
public class KnowledgeCardDialog : UIWindowBase
{
    public TextMeshProUGUI _fansText;
    public TextMeshProUGUI _FansCountText;
    public GameObject nothingDes;
    public Slider _fansSlider;
    public Transform TipsContent;
    public Transform FansContent;
    public GameObject loading;
    
    private LoopVerticalScrollRect loopScrollRect;
    private string rewardId;

    void Awake()
    {
        //      userHeadIcon = transform.Find("Content/UserNews/UderHead/PhotoHead/Mask/Img_Icon").GetComponent<Image>();
//        userNameText = transform.Find("Content/UserNews/UderHead/PhotoHead/Text_Name").GetComponent<Text>();
//        userPostText = transform.Find("Content/UserNews/UderHead/PhotoHead/Text_Post").GetComponent<Text>();
//        userFansNum = transform.Find("Content/UserNews/Fans/Text_Fans_Num").GetComponent<Text>();
        loopScrollRect = transform.Find("Content/Slider/Scroll View").GetComponent<LoopVerticalScrollRect>();
        GameAnalyze.LogblogClick("NULL","4");
    }

    public override void OnOpen()
    {
        base.OnOpen();
        List<LocalKnowledgeCard> _knowledgeCards = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().GetOwnCards();
        if (_knowledgeCards.Count == 0)
        {
            nothingDes.SetActive(true);
        }

        _knowledgeCards.Reverse();
        //  initUserData();     
        loopScrollRect.totalCount = _knowledgeCards.Count;
        loopScrollRect.objectsToFill = new List<object>(_knowledgeCards);
        loopScrollRect.RefillCells();
            
        CheckGuide();

        if (DataManager.ProcessData.firstOpenKnowledge)
        {
            DataManager.ProcessData.firstOpenKnowledge = false;
            loading.SetActive(true);
            TimersManager.SetTimer(1, () =>
            {
                loading.SetActive(false);
            });
        }
    }

    private void SetWebText(int current, int max)
    {
        if (max == -1 || max == 0)
        {
            _fansText.text = string.Format("MAX", current, current);
        }
        else
        {
            _fansText.text = string.Format("{0}/{1}", current, max);
        }
    }

    private void CheckGuide()
    {
        if (AppEngine.SSystemManager.GetSystem<GuideSystem>().GuideShown_BlogEnter.Value && !AppEngine.SSystemManager.GetSystem<GuideSystem>().GuideShown_BlogCard.Value)
        {
            ClickFans();
            AppEngine.SSystemManager.GetSystem<GuideSystem>().GuideShown_BlogCard.Value = true;
        }
    }

//    private void initUserData()
//    {
//        initFansNum();
//        userNameText.text = AppEngine.SSystemManager.GetSystem<PlayerInfoSystem>().PlsyerFBName.Value;
//        userPostText.text = _knowledgeCards.Count.ToString() + "posts";
//    }

    public void CloseKnowledgeCard()
    {
        KnowCardIdManager.getInstance().destory();
        saveKnowledgeCard();
        Close();
    }

    




    public void ClickBox()
    {
        ShowTips();
    }

    private void saveKnowledgeCard()
    {
        DataManager.PlayerData.KnowledgeCards.Value.ClearAllNewFlag();
    }

    private async void ShowTips()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_tip_appear);
        GameObject tips = await Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_tips).Task;
        tips = Instantiate(tips, TipsContent, false);
        TipsItemView view = tips.GetComponent<TipsItemView>();
        view.SetData(rewardId);
    }

    public void ClickFans()
    {
        ShowFansTips();
    }
    private async void ShowFansTips()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_tip_appear);
        GameObject tips = await Addressables.LoadAssetAsync<GameObject>(ViewConst.prefab_CardFansTips).Task;
        tips = Instantiate(tips, FansContent, false);
        tips.SetActive(true);
    }
    
}