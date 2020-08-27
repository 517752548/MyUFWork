using System;
using System.Collections.Generic;
using BetaFramework;
using Scripts_Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClassicQuestionRate : GameEntity
{
    public ToggleButton funBtn, boringBtn;
    public TextMeshProUGUI noRewardTitle;
    public TextMeshProUGUI rewardCountText;
    public RectTransform answerContent;
    public GameObject AnswerCellPrefab;

    private const string key = "RateQuestionRecord";
    private BaseNormalWord curWord;
    private Dictionary<int, int> rateResult;
    private int levelIndex;

    class CacheData
    {
        public int Level;
        public Dictionary<int, int> Result;

        public CacheData()
        {
        }

        public CacheData(int level, Dictionary<int, int> result)
        {
            Level = level;
            Result = result;
        }
    }

    public void Init(int levelIndex)
    {
        this.levelIndex = levelIndex;
        if (rateResult == null)
            rateResult = new Dictionary<int, int>();
        else
        {
            rateResult.Clear();
        }

        CacheData data = Record.GetObject<CacheData>(key, null);
        if (data != null)
        {
            if (data.Level == levelIndex)
            {
                rateResult = data.Result;
            }
            else
            {
                Record.DeleteKey(key);
            }
        }

        curWord = null;
        gameObject.SetActive(false);
    }

    public void OnClickFun()
    {
        ChangeRateState(!funBtn.IsOn ? 1 : -1);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
    }

    public void OnClickBoring()
    {
        ChangeRateState(!boringBtn.IsOn ? 0 : -1);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_btn_normal);
    }

    private void ChangeRateState(int rate)
    {
        GameManager.StateMachine.TriggerEvent(BaseFSMManager.Event_GuideClose_RateReward);
        if (rate >= 0 && HasRateReward())
        {
            RewardUser();
        }

        UpdateRateState(rate);
        rateResult[curWord.BaseQuestion.ID] = rate;
        Record.SetObject(key, new CacheData(levelIndex, rateResult));
    }

    private void UpdateRateState(int rate)
    {
        if (rate == 0)
        {
            boringBtn.IsOn = true;
            funBtn.IsOn = false;
        }
        else if (rate == 1)
        {
            funBtn.IsOn = true;
            boringBtn.IsOn = false;
        }
        else
        {
            funBtn.IsOn = false;
            boringBtn.IsOn = false;
        }
    }

    public void OnWordChanged(BaseWord word)
    {
        curWord = word as BaseNormalWord;
        if (curWord == null)
        {
            gameObject.SetActive(false);
            return;
        }

        if (curWord.IsComplete)
        {
            int rate = -1;
            if (rateResult.ContainsKey(curWord.BaseQuestion.ID))
                rate = rateResult[curWord.BaseQuestion.ID];
            UpdateRateState(rate);
            RefreshReward();
            FillAnswerCells();
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void OnLevelCompleted()
    {
        try
        {
            var words = GameManager.GetEntity<BaseCellManager>().Words;
            foreach (var keyValuePair in rateResult)
            {
                if (keyValuePair.Value >= 0)
                {
                    BaseNormalWord w =
                        words.Find(word => (word as BaseNormalWord).BaseQuestion.ID == keyValuePair.Key) as
                            BaseNormalWord;
                }
            }

            rateResult.Clear();
            Record.DeleteKey(key);
        }
        catch (Exception e)
        {
        }
    }

    private bool HasRateReward()
    {
        return (curWord as ClassicNormalWord).RateRewardCoin > 0;
        if (AppEngine.SyncManager.Data.lastRateRewardTime.Value != AppEngine.STimeHeart.RealTime.ToString("yyyy-MM-dd"))
        {
            return true;
        }

        return false;
    }

    private void RewardUser()
    {
        //CommandBinder.DispatchBinding(GameEvent.RubyFly, new RubyFlyCommand.RubyFlyData(RubyType.single, curWord.Cells[0].transform,0));
        //AppEngine.SyncManager.Data.lastRateRewardTime.Value = AppEngine.STimeHeart.RealTime.ToString("yyyy-MM-dd");
        GameManager.GameAnimationStart();
        RewardMgr.RewardInventory(InventoryType.Coin, (curWord as ClassicNormalWord).RateRewardCoin,
            RewardSource.queFeedback);
        StartCoroutine(
            (curWord as ClassicNormalWord).HideRateRewardCoin(GameManager.GameAnimationEnd)); //金币依次消失，与飞金币动画对应
        (m_baseGameManager as ClassicGameManager).ProgressData.RateRewardWordIndex = 999; //索引值大于0而且超过总词数，表示金币已经领取不再展示
    }

    private void RefreshReward()
    {
        int coin = (curWord as ClassicNormalWord).RateRewardCoin;
        if (coin > 0)
        {
            noRewardTitle.SetActive(false);
            rewardCountText.text = coin + " coins";
            rewardCountText.SetParentActive(true);
        }
        else
        {
            noRewardTitle.SetActive(true);
            rewardCountText.SetParentActive(false);
        }
    }

    private void FillAnswerCells()
    {
        answerContent.DestroyAll();
        int count = curWord.Answer.Length;
        int minCount = CommUtil.IsPad() ? 9 : 7;
        if (count < minCount)
            count = minCount;
        float cellSize = answerContent.rect.width / count;
        answerContent.GetComponent<GridLayoutGroup>().cellSize = Vector2.one * cellSize;
        for (int i = 0; i < curWord.Answer.Length; i++)
        {
            GameObject obj = Instantiate(AnswerCellPrefab, answerContent, false);
            ClassicQuestionRateCell rateCell = obj.GetComponent<ClassicQuestionRateCell>();
            rateCell.Init(cellSize, curWord.Answer[i]);
        }
    }

    public void PlayGuideAni(bool play)
    {
        funBtn.transform.Find("AniPack/Img_Bg").GetComponent<Animator>().SetTrigger(play ? "guide" : "idle");
        boringBtn.transform.Find("AniPack/Img_Bg").GetComponent<Animator>().SetTrigger(play ? "guide" : "idle");
    }
}