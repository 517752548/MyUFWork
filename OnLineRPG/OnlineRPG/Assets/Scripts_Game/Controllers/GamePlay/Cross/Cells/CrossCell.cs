using System;
using BetaFramework;
using Scripts_Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossCell : BaseCell
    {
        public GameObject beeCoinImg;
        public TextMeshProUGUI numText;
        public int PosRow, PosCol;

        private BaseWord curSelectedWord;
        private CrossNormalWord verticalWord, horizontalWord;
        private bool beeCoin = false;
        private string wordNumber = "";

        private bool isShadow = false;
        private CrossCell entityCell;
        private Action updateCallback = null;

        public bool BeeCoin
        {
            get => beeCoin;
            set => beeCoin = value;
        }
        
        private CrossCellManager CellMgr => cellManager as CrossCellManager;

        public override void Init(BaseCellManager cellManager, string answerLetter, int index, float cellSize)
        {
            base.Init(cellManager, answerLetter, index, cellSize);
            content.offsetMax = new Vector2(0, 0); //left top
            content.offsetMin = new Vector2(0, 0);
            content.SetActive(false);
            beeCoinImg.SetActive(false);
            numText.SetActive(false);
            curSelectedWord = null;
        }

        public void InitLetter(string answerLetter)
        {
            this.answerLetter = answerLetter;
            State = CellState.normal;
            bgFlag = Flag_Normal;
            numText.text = "";
        }

        public override void SetParentWord(BaseWord word)
        {
            if (word is CrossNormalWord _word)
            {
                if (word.Cells[0] == this)
                {
                    numText.text = _word.Question.Number.ToString();
                }
                if (normalWord == null)
                    normalWord = _word;
                if (_word.IsHorizontal)
                {
                    horizontalWord = _word;
                }
                else
                {
                    verticalWord = _word;
                }

                UpdateContent();
            }
        }

        private void OnUpdate(Action updateCallback)
        {
            this.updateCallback = updateCallback;
        }

        protected override void UpdateContent()
        {
            base.UpdateContent();
            if ((bgFlag & Flag_Disable) > 0)
            {
                content.SetActive(false);
            }
            else
            {
                content.SetActive(true);
            }
            updateCallback?.Invoke();
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
                return;
            }

            if (entityCell != null)
            {
                if (cellManager.LastClickCell != entityCell)
                    entityCell.OnClick();
                return;
            }

            bool reclick = cellManager.LastClickCell == this;
            cellManager.LastClickCell = this;
            
            if (IsWordSelected)
            {
                if (reclick)
                {
                    if (curSelectedWord != horizontalWord && horizontalWord != null)
                    {
                        horizontalWord.SetSelect(true);
                    }
                    else if (curSelectedWord != verticalWord && verticalWord != null)
                    {
                        verticalWord.SetSelect(true);
                    }
                }

                if (AppEngine.SGameSettingManager.SelectFirstSolt.Value)
                {
                    curSelectedWord.FocusFirstCanInputCell();
                }
                else if (State != CellState.filled && !IsFocused)
                {
                    SetFocus(true);
                }
            }
            else
            {
                if (!AppEngine.SGameSettingManager.SelectFirstSolt.Value && State != CellState.filled)
                    SetFocus(true);
                if (CellMgr.CurSelHorizontalWord)
                {
                    if (horizontalWord != null)
                        horizontalWord.SetSelect(true);
                    else
                        verticalWord.SetSelect(true);
                }
                else
                {
                    if (verticalWord != null)
                        verticalWord.SetSelect(true);
                    else
                        horizontalWord.SetSelect(true);
                }
            }
        }

        public override void AutoHintFill()
        {
            //base.AutoHintFill();
            SetFilled();
            PlayCorrectAni();
        }

        public override void AutoHintFillCheckAnswer()
        {
            if (horizontalWord != null && horizontalWord != curSelectedWord && !horizontalWord.IsComplete)
                horizontalWord.CheckAnswer(false);
            if (verticalWord != null && verticalWord != curSelectedWord && !verticalWord.IsComplete)
                verticalWord.CheckAnswer(false);
            if (curSelectedWord != null && !curSelectedWord.IsComplete)
            {
                curSelectedWord.CheckAnswer(false);
            }
            cellManager.CheckMultiWord();
        }

        public override void CheckAnswer()
        {
            _checkAnswerResult = CheckAnswerResult.none;
            if (horizontalWord != null && horizontalWord != curSelectedWord && !horizontalWord.IsComplete)
                horizontalWord.CheckAnswer(horizontalWord.GetLastInputedCell() == this);
            if (verticalWord != null && verticalWord != curSelectedWord && !verticalWord.IsComplete)
                verticalWord.CheckAnswer(verticalWord.GetLastInputedCell() == this);
            if (curSelectedWord != null && !curSelectedWord.IsComplete)
            {
                _checkAnswerResult =
                    curSelectedWord.CheckAnswer(curSelectedWord.GetLastInputedCell() == this);
            }
            cellManager.CheckMultiWord();
        }

        public override void FocusToNextCell(bool ignoreSwitch = false)
        {
            if (curSelectedWord != null && !curSelectedWord.IsComplete)
            {
                if (_checkAnswerResult == CheckAnswerResult.miss)
                    curSelectedWord.FocusNextCell(this, ignoreSwitch);
            }
        }

        public override void Refresh()
        {
            //base.Refresh();
            UpdateContent();
            if (curSelectedWord != null)
                SetWordSelected(cellManager.IsCurWord(curSelectedWord), curSelectedWord);
        }

        public override void SetWordSelected(bool sel, BaseWord word)
        {
            curSelectedWord = sel ? word : null;
            if (sel) normalWord = word as BaseNormalWord;
            numText.SetActive(sel);
            base.SetWordSelected(sel, word);
        }

        public void SetBeeCoin(bool has)
        {
            if (has)
            {
                beeCoin = true;
            }

            beeCoinImg.SetActive(has);
        }

        public override BaseWord ParentWord
        {
            get
            {
                if (CellMgr.CurSelHorizontalWord)
                {
                    if (horizontalWord != null)
                        return horizontalWord;
                    else
                        return verticalWord;
                }
                else
                {
                    if (verticalWord != null)
                        return verticalWord;
                    else
                        return horizontalWord;
                }
            }
        }

        public override bool IsInSameWord(BaseCell cell)
        {
            //return base.IsInSameWord(cell);
            if (cell is CrossCell _cell)
                return (horizontalWord != null && horizontalWord == _cell.horizontalWord) ||
                       (verticalWord != null && verticalWord == _cell.verticalWord);
            return false;
        }

        public CrossNormalWord HWord => horizontalWord;
        public CrossNormalWord VWord => verticalWord;

        public void ReleaseShadow()
        {
            entityCell.OnUpdate(null);
            Destroy(gameObject);
        }

        public CrossCell MakeShadow(float cellSize)
        {
            GameObject obj = Instantiate(gameObject, transform.parent.parent, true);
            for (int i = obj.transform.childCount - 1; i > 0; i--)
            {
                Destroy(obj.transform.GetChild(i).gameObject);
            }
            obj.transform.localScale = Vector3.one;
            CrossCell cell = obj.GetComponent<CrossCell>();
            cell.InitShadow(this, cellSize);
            return cell;
        }

        private void InitShadow(CrossCell cell, float cellSize)
        {
            isShadow = true;
            entityCell = cell;
            this.cellSize = cellSize;
            //ColIndex = cell.ColIndex;
            this.cellManager = cell.cellManager;
            this.answerLetter = cell.answerLetter;
            inputLetter = cell.inputLetter;
            State = cell.State;
            bgFlag = cell.bgFlag;
            normalWord = cell.normalWord;
            letterText.SetSize(Vector3.one * cellSize * 0.68f);
            effectScale = cellSize / 114.4f;
            beFlyToFlag.SetActive(false);
            cell.OnUpdate(() =>
            {
                inputLetter = entityCell.inputLetter;
                State = entityCell.State;
                bgFlag = entityCell.bgFlag;
                UpdateContent();
            });
        }
    }

    public class CrossNormalWord : BaseNormalWord
    {
        public int BeeRewardCoin { get; private set; }
        public bool Display { get; private set; }

        public CrossNormalWord(BaseCellManager cellManager, BaseQuestionEntity answerInfo) : base(cellManager,
            answerInfo)
        {
            checkAnswerToCompleteWord = false;
            Display = false;
            NumTag = Question.Number + (Question.Horizontal ? "a" : "d");
            question.Question = $"<color=#3C0B10>{NumTag}.</color>" + question.Question;
        }

        public CrossQuestionEntity Question => question as CrossQuestionEntity;
        public bool IsHorizontal => Question.Horizontal;
        public string NumTag { get; private set; }

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
                cellList.ForEach(c => { info += (c as CrossCell).BeeCoin ? "1" : "0"; });
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
                            (cellList[i] as CrossCell).SetBeeCoin(true);
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
                if ((cell as CrossCell).BeeCoin)
                {
                    BeeRewardCoin++;
                    (cell as CrossCell).BeeCoin = false;
                }
            }
        }

        public override void HintComplete(Action aniOver = null)
        {
            CheckDelayRewardBeeCoin();
            base.HintComplete(() =>
            {
                aniOver?.Invoke();
                CellManager.CheckMultiWord();
            });
            
        }

        public override void OnVoiceRight()
        {
            CheckDelayRewardBeeCoin();
            base.OnVoiceRight();
            IsComplete = false;
            CellManager.CheckMultiWord();
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
                if ((cell as CrossCell).BeeCoin)
                {
                    return true;
                }
            }

            return false;
        }

        public void SetComplete()
        {
            IsComplete = true;
            Display = true;
        }

        public override CheckAnswerResult CheckAnswer(bool lastInputedCell)
        {
            CheckAnswerResult result = base.CheckAnswer(lastInputedCell);
            if (result == CheckAnswerResult.right)
            {
                IsComplete = false;
            }

            return result;
        }
    }
}