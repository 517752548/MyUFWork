using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using BetaFramework;
using Scripts_Game.Managers;

public class ClassicCell : BaseCell
{
    public Sprite bg_sprite_solution_word; //, bg_sprite_picture_word, bg_sprite_picture_solution;
    public GameObject EffectPrefab_CorrectTheme;
    public GameObject Prefab_PicWordFlag;
    public GameObject coinImg;
    public GameObject beeCoinImg;


    private ClassicThemeWord themeWord;
    private BaseWord curSelectedWord;
    private bool isInPictureWord;
    private GameObject picWordFlag = null;
    private bool hidePicWordFlag = false;
    private bool beeCoin = false;

    public bool BeeCoin
    {
        get => beeCoin;
        set => beeCoin = value;
    }

    public override void Init(BaseCellManager cellManager, string answerLetter, int index, float cellSize)
    {
        base.Init(cellManager, answerLetter, index, cellSize);
        themeWord = null;
        curSelectedWord = null;
        isInPictureWord = false;
        hidePicWordFlag = false;
        coinImg.SetActive(false);
        beeCoinImg.SetActive(false);
    }

    public override void SetParentWord(BaseWord word)
    {
        if (word is ClassicThemeWord)
            themeWord = word as ClassicThemeWord;
        else if (word is ClassicNormalWord)
        {
            isInPictureWord = ((ClassicNormalWord) word).Question.ImageSprite != null;
        }

        base.SetParentWord(word);
    }

    public bool IsInPictureWord
    {
        get { return isInPictureWord; }
    }

    protected override void UpdateContent()
    {
        base.UpdateContent();
        if ((bgFlag & Flag_Disable) > 0)
        {
        }
        else if ((bgFlag & Flag_Wrong) > 0)
        {
        }
        else if ((bgFlag & Flag_WordCompleted) > 0)
        {
            if (themeWord != null)
            {
                bgImage.sprite = bg_sprite_solution_word;
                if (State == CellState.filled)
                    letterText.color = FilledTextColor;
            }

            hidePicWordFlag = true;
        }
        else if ((bgFlag & Flag_HintSel) > 0)
        {
        }
        else if ((bgFlag & Flag_Focus) > 0)
        {
            bgImage.sprite = bg_sprite_focus;
            if (State == CellState.filled)
                letterText.color = FilledTextColor;
        }
        else if (bgFlag == Flag_Normal || bgFlag == (Flag_WordSel | Flag_Normal))
        {
            if (themeWord != null)
                bgImage.sprite = bg_sprite_solution_word;
        }

        ShowPicWordFlag(ColIndex == 0 && isInPictureWord && !hidePicWordFlag);
    }

    public void SetBeeCoin(bool has)
    {
        if (has)
        {
            beeCoin = true;
        }

        beeCoinImg.SetActive(has);
    }

    public override void SetFilled()
    {
        base.SetFilled();
        if (beeCoinImg.gameObject.activeSelf)
        {
            int delay = FlyRewardView.instance.AddSingleCoinToMultiFly(transform.position);

            //StartCoroutine(SingleCoinFly.FlySingleCommonTypeGolds(transform.position, 0.3f + ColIndex * 0.15f, false,
            //   ColIndex * 0.15f));
            if (beeCoin)
            {
                RewardMgr.RewardInventory(InventoryType.Coin, 1, RewardSource.BeeCoin);
            }

            TimersManager.SetTimer(0.1f * delay, () => { SetBeeCoin(false); });
        }
    }

    private void ShowPicWordFlag(bool show)
    {
        if (show)
        {
            if (picWordFlag == null)
            {
                picWordFlag = Instantiate(Prefab_PicWordFlag, transform);
                picWordFlag.transform.localScale = Vector3.one * effectScale;
                picWordFlag.transform.localPosition = Vector3.zero;
            }

            picWordFlag.SetActive(true);
        }
        else if (picWordFlag != null)
        {
            picWordFlag.SetActive(false);
        }
    }

    public void HidePicWordFlag()
    {
        hidePicWordFlag = true;
        ShowPicWordFlag(false);
    }

    public override void InputLetter(string letter)
    {
        if (string.IsNullOrEmpty(letter))
        {
            if (State == CellState.normal || State == CellState.filled)
            {
                curSelectedWord.OnCellLetterDel(this);
            }
            else
            {
                State = CellState.normal;
            }

            UpdateContent();
            return;
        }

        base.InputLetter(letter);
    }

    public override void OnClick()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_clickwordcell);
        if (State == CellState.none)
        {
            if (!IsWordSelected)
            {
                normalWord.SetSelect(true);
                //AppEngine.SSoundManager.PlaySFX(ViewConst.wav_clickwordcell);
            }

            return;
        }

        bool reclick = cellManager.LastClickCell == this;
        cellManager.LastClickCell = this;


        if (IsWordSelected)
        {
            if (reclick)
            {
                if (curSelectedWord != normalWord)
                {
                    normalWord.SetSelect(true);
                    //AppEngine.SSoundManager.PlaySFX(ViewConst.wav_clickwordcell);
                }
                else if (curSelectedWord != themeWord && themeWord != null)
                {
                    themeWord.SetSelect(true);
                    //AppEngine.SSoundManager.PlaySFX(ViewConst.wav_clickwordcell);
                }
            }

            if (AppEngine.SGameSettingManager.SelectFirstSolt.Value)
            {
                curSelectedWord.FocusFirstCanInputCell();
            }
            else if (State != CellState.filled && !IsFocused)
            {
                SetFocus(true);
                //小cell被选中，暂无音效，有的话加在这
            }
        }
        else
        {
            if (!AppEngine.SGameSettingManager.SelectFirstSolt.Value && State != CellState.filled)
                SetFocus(true);
            normalWord.SetSelect(true);
            //AppEngine.SSoundManager.PlaySFX(ViewConst.wav_clickwordcell);
        }

        cellManager.GameManager.StateMachine.TriggerEvent(BaseFSMManager.Event_GuideClose_RateReward);
    }

    public override void AutoHintFillCheckAnswer()
    {
        if (normalWord != curSelectedWord && !normalWord.IsComplete)
            normalWord.CheckAnswer(false);
        if (themeWord != null && themeWord != curSelectedWord && !themeWord.IsComplete)
            themeWord.CheckAnswer(false);
        if (curSelectedWord != null && !curSelectedWord.IsComplete)
        {
            curSelectedWord.CheckAnswer(false);
        }
    }

    public override void CheckAnswer()
    {
        _checkAnswerResult = CheckAnswerResult.none;
        if (normalWord != curSelectedWord && !normalWord.IsComplete)
            normalWord.CheckAnswer(normalWord.GetLastInputedCell()?.ColIndex == this.ColIndex);
        if (themeWord != null && themeWord != curSelectedWord && !themeWord.IsComplete)
            themeWord.CheckAnswer(false);
        if (curSelectedWord != null && !curSelectedWord.IsComplete)
        {
            _checkAnswerResult = curSelectedWord.CheckAnswer(curSelectedWord.GetLastInputedCell()?.ColIndex == this.ColIndex);
        }
    }

    public override void FocusToNextCell(bool ignoreSwitch = false)
    {
        if (curSelectedWord != null && !curSelectedWord.IsComplete)
        {
            if (_checkAnswerResult == CheckAnswerResult.miss)
                curSelectedWord.FocusNextCell(this, ignoreSwitch);
        }
    }

    public override void Disappear(float delay)
    {
        base.Disappear(delay);
        if (themeWord == null)
        {
            _CanvasGroup.DOFade(0.1f, 0.2f);
        }
        else
        {
            PlayCorrectThemeAni();
        }
    }
    //public override BaseWord ParentWord { get { return curWord; } }

    public override void SetWordSelected(bool sel, BaseWord word)
    {
        curSelectedWord = sel ? word : null;
        base.SetWordSelected(sel, word);
    }

    public float PlayCorrectThemeAni(Action callback = null)
    {
        float len = 0.667f;
        PlayAni(EffectPrefab_CorrectTheme, len, callback);
        return len;
    }

    public bool SetCoinActive(bool active)
    {
        if (themeWord != null || State == CellState.none)
        {
            return false;
        }

        coinImg.SetActive(active);
        return true;
    }
}

public class ClassicThemeWord : BaseWord
{
    public ClassicThemeWord(BaseCellManager cellManager, string answer, List<string> similarwords) : base(cellManager,
        answer, similarwords, CommUtil.GetWordSplit(""))
    {
    }

    public override CheckAnswerResult CheckAnswer(bool lastInputedCell)
    {
        CheckAnswerResult result = base.CheckAnswer(false);
        if (result == CheckAnswerResult.right)
        {
            ((ClassicCellManager) cellManager).OnCompleteThemeWord(this);
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_WordRight);
        }

        return result;
    }

    public override void OnVoiceRight()
    {
        //base.OnVoiceRight();
        cellManager.StopCellMove();
        IsComplete = true;
        cellList.ForEach(c => c.SetFilled());
        cellManager.CacheLevelProgress();
        ((ClassicCellManager) cellManager).OnCompleteThemeWord(this);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_WordRight);
    }

    public override string GetWordQuestion()
    {
        string des = "";
        int col = -1;
        cellList.ForEach(c =>
        {
            if (c.State == CellState.none)
                return;
            if (col < 0)
                col = c.ColIndex;
            else if (col != c.ColIndex)
            {
                col = c.ColIndex;
                des += " ";
            }

            if (c.State == CellState.filled)
                des += c.AnswerLetter;
            else
                des += "_";
        });
        return des;
    }

    public override void DisAppear()
    {
        base.DisAppear();
//        for (int i = 0; i < cellList.Count; i++)
//        {
//            (cellList[i] as ClassicCell).PlayCorrectThemeAni();
//        }
    }
}

public class ClassicNormalWord : BaseNormalWord
{
    public int RateRewardCoin { get; private set; }
    public int BeeRewardCoin { get; private set; }

    public ClassicNormalWord(BaseCellManager cellManager, BaseQuestionEntity answerInfo) : base(cellManager, answerInfo)
    {
        RateRewardCoin = 0;
    }

    public ClassicQuestionEntity Question
    {
        get { return question as ClassicQuestionEntity; }
    }

    public override void DisAppear()
    {
        base.DisAppear();
        for (int i = 0; i < cellList.Count; i++)
        {
            cellList[i].Disappear(0.01f * i);
        }
    }

    public override string CellsState
    {
        get
        {
            string info = "";
            cellList.ForEach(c => { info += (c as ClassicCell).BeeCoin ? "1" : "0"; });
            return info;
        }
        set
        {
            char[] arr = value.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i >= cellList.Count || cellList[i].State == CellState.none
                ) //|| cellList[i].State == CellState.filled
                {
                    break;
                }

                if (arr[i] == '1')
                {
                    if (cellList[i].State != CellState.filled)
                    {
                        (cellList[i] as ClassicCell).SetBeeCoin(true);
                    }
                }
            }
        }
    }

    private void CheckDelayRewardBeeCoin()
    {
        BeeRewardCoin = 0;
        foreach (var cell in cellList)
        {
            if ((cell as ClassicCell).BeeCoin)
            {
                BeeRewardCoin++;
                (cell as ClassicCell).BeeCoin = false;
            }
        }
    }

    public override void HintComplete(Action aniOver = null)
    {
        CheckDelayRewardBeeCoin();
        base.HintComplete(aniOver);
    }

    public override void OnVoiceRight()
    {
        CheckDelayRewardBeeCoin();
        base.OnVoiceRight();
    }

    protected override void OnInputCompleteWord()
    {
        CheckDelayRewardBeeCoin();
        base.OnInputCompleteWord();
    }

    public bool IsBeeWord()
    {
        foreach (var cell in cellList)
        {
            if ((cell as ClassicCell).BeeCoin)
            {
                return true;
            }
        }

        return false;
    }

    public void ShowRateRewardCoin()
    {
        RateRewardCoin = 0;
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_coinAppear);
        for (int i = 0; i < cellList.Count; i++)
        {
            if ((cellList[i] as ClassicCell).SetCoinActive(true))
            {
                RateRewardCoin++;
            }
        }
    }

    public IEnumerator HideRateRewardCoin(Action callback)
    {
        yield return new WaitForSeconds(0.1f);
        RateRewardCoin = 0;
        for (int i = 0; i < cellList.Count; i++)
        {
            (cellList[i] as ClassicCell).SetCoinActive(false);
            yield return new WaitForSeconds(0.1f);
        }

        callback?.Invoke();
    }

    public List<Vector3> GetAllCoinPos()
    {
        List<Vector3> coinPosList = new List<Vector3>();
        for (int i = 0; i < cellList.Count; i++)
        {
            if ((cellList[i] as ClassicCell).SetCoinActive(true))
            {
                coinPosList.Add(cellList[i].transform.position);
            }
        }

        return coinPosList;
    }
}