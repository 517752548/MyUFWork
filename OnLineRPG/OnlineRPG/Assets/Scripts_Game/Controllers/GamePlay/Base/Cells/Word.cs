using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BetaFramework;
using System;
using System.Collections;
using System.Reflection;
using Newtonsoft.Json;

/// <summary>
/// 答案词类
/// </summary>
public class BaseWord
{
    public int HintCount = 0; //被其他词完成时提示的数量
    public bool _IsKeyboardHintUsed = false; //是否在该词上使用了hint2
    public int Index = 0;
    public int[] wordspit = new int[] { };

    protected BaseCellManager cellManager;
    protected List<BaseCell> cellList;
    protected string answer = "";
    protected List<string> _similar = new List<string>();
    private int noEraseWrongTimes = 0;
    private const int MaxNearRightTime = 3;
    private int nearRightTime = 0;

    /// <summary>
    /// 专门为提示类型1计数，如果不出发2和3的情况下连续输入错误3次就出现提示1，切换单词和答对都置零
    /// </summary>
    private int wrongTimesForType1 = 0;

    /// <summary>
    /// 正序还是倒序提示玩家的cell提示，1是正序，-1是倒序，0是没有确定
    /// </summary>
    private int randomOrder = 0;

    private int randomIndex = 0;

    /// <summary>
    /// 有没有触发过相近词的正确答案逻辑
    /// </summary>
    private bool hasNearLogic = false;

    public BaseCellManager CellManager
    {
        get { return cellManager; }
    }

    public bool IsKeyboardHintUsed
    {
        get { return _IsKeyboardHintUsed; }
        set { _IsKeyboardHintUsed = value; }
    }

    public BaseWord(BaseCellManager cellManager, string answer, List<string> similarwords, int[] wordspit)
    {
        this.cellManager = cellManager;
        this.wordspit = wordspit;
        char[] arr = answer.ToUpper().Trim().ToCharArray();
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != ' ')
                this.answer += arr[i];
        }

        if (similarwords != null && similarwords.Count > 0)
        {
            _similar.Clear();
            for (int i = 0; i < similarwords.Count; i++)
            {
                _similar.Add(similarwords[i]);
            }
        }

        cellList = new List<BaseCell>();
    }

    public void Refresh()
    {
        cellList.ForEach(cell => cell.Refresh());
    }

    public virtual void AddCell(BaseCell cell)
    {
        cellList.Add(cell);
        cell.SetParentWord(this);
    }

    /// <summary>
    /// 语音回答正确的调用
    /// </summary>
    public virtual void OnVoiceRight()
    {
        //Select();
        cellManager.StopCellMove();

        IsComplete = true;
        cellList.ForEach(c => c.SetFilled());
        cellManager.CacheLevelProgress();
        cellManager.OnCompleteOneWord(this, true);
        int randomindex = UnityEngine.Random.Range(0, 100);
        if (randomindex >= 50)
        {
            //小人提示用的
            cellManager.GetGameManager<BaseGameManager>().GetEntity<BasePet>()
                .ShowPetTip(PetTip.Type4);
        }
    }

    public List<BaseCell> ValidCells
    {
        get { return cellList.GetRange(0, answer.Length); }
    }

    /// <summary>
    /// 是否已完成
    /// </summary>
    public bool IsComplete { get; protected set; }

    public string Answer
    {
        get { return answer; }
    }

    /// <summary>
    /// 语音的同义词
    /// </summary>
    public List<string> SimilarWords
    {
        get { return _similar; }
    }

    /// <summary>
    /// 可以被其他词完成时提示的最大数量
    /// </summary>
    public virtual int ValidHintCount
    {
        get { return 99; }
    }

    /// <summary>
    /// 可以被其他词完成时提示的最大数量
    /// </summary>
    public virtual int MaxBeFlyToCount
    {
        get { return 99; }
    }

    public virtual int MinBeFlyToCount
    {
        get { return 2; }
    }

    /// <summary>
    /// 存档信息
    /// </summary>
    public string StateInfo
    {
        get
        {
            string info = "";
            cellList.ForEach(c =>
            {
                switch (c.State)
                {
                    case CellState.normal:
                        info += "0";
                        break;
                    case CellState.filled:
                        info += "1";
                        break;
                    case CellState.inputted:
                        info += c.Letter;
                        break;
                }
            });
            return info;
        }
        set
        {
            char[] arr = value.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (i >= cellList.Count || cellList[i].State == CellState.none)
                {
                    break;
                }

                if (arr[i] == '0')
                {
                    cellList[i].ResetToNormalState();
                }
                else if (arr[i] == '1')
                {
                    cellList[i].SetFilled();
                }
                else
                {
                    cellList[i].SetInput(arr[i].ToString());
                }
            }

            CheckComplete();
            if (IsComplete)
                cellList.ForEach(c => c.SetWordCompleted(this));
        }
    }

    public BaseCell GetLastInputedCell()
    {
        for (int i = cellList.Count - 1; i > 0; i--)
        {
            if (cellList[i].State == CellState.inputted)
            {
                return cellList[i];
            }
        }

        return null;
    }

    public virtual string CellsState
    {
        get => "";
        set { }
    }

    /// <summary>
    /// 修改word被hint选中状态
    /// </summary>
    /// <param name="sel">是否被选中</param>
    public void HintSel(bool sel)
    {
        cellList.ForEach(cell => cell.HintSel(sel));
    }

    /// <summary>
    /// 使用hint4完成这个word
    /// </summary>
    public virtual void HintComplete(Action aniOver = null)
    {
        //Select();
        cellManager.StopCellMove();

        SequenceTask seqTask = new SequenceTask();
        Transform effect = AppEngine.SObjectPoolManager.Spawn(cellList[0].EffectPrefab_Hint4.name,
            cellList[0].EffectPrefab_Hint4.transform, Vector3.zero, default(Quaternion), cellManager.scrollContent);
        effect.localScale = Vector3.one * cellManager.effectScale;

        int len = answer.Length;
        float deltaX = cellList[1].transform.position.x - cellList[0].transform.position.x;
        Vector3 startPos = cellList[0].transform.position - new Vector3(deltaX, 0, 0);
        Vector3 EndPos = cellList[len - 1].transform.position + new Vector3(deltaX, 0, 0);
        effect.position = cellList[0].transform.position - new Vector3(deltaX, 0, 0);
        effect.gameObject.SetActive(true);
        float moveTime = 0.15f;
        float fillTime = moveTime / 3;
        for (int i = 0; i < len; i++)
        {
            seqTask.InsertCallback(i == 0 ? fillTime : moveTime,
                new SequenceTaskObjectCallback<BaseCell>(cellList[i],
                    cell =>
                    {
                        cell.SetFilled();
                        cell.PlayHint4CorrectAni();
                    }));
        }

        effect.DOMove(EndPos, moveTime * (len + 1)).SetEase(Ease.Linear).OnComplete(() =>
        {
            AppEngine.SObjectPoolManager.Despawn(effect);
            for (int i = 0; i < len; i++)
            {
                //if (i == 0)
                //    cellList[i].PlayHint4EndAni(() =>
                //    {
                //        IsComplete = true;
                //        cellManager.CacheLevelProgress();
                //        aniOver?.Invoke();
                //        cellManager.OnCompleteOneWord(this, false);
                //    });
                //else
                cellList[i].PlayHint4EndAni();
            }

            IsComplete = true;
            cellList.ForEach(c => c.SetFilled());
            cellManager.CacheLevelProgress();
            aniOver?.Invoke();
            cellManager.OnCompleteOneWord(this, false);
        });
    }

    public void ChangeStateOnKeyboardHintReady(bool isReady)
    {
        if (IsKeyboardHintUsed)
        {
            cellList.ForEach(c => c._CanvasGroup.alpha = isReady ? 0.5f : 1f);
        }
    }

    /// <summary>
    /// 点击格子时更改选中词
    /// </summary>
    /// <param name="sel"></param>
    public void SetSelect(bool sel)
    {
        if (sel)
        {
            Select();
        }
        else
        {
            wrongTimesForType1 = 0;
            cellList.ForEach(cell => cell.SetWordSelected(false, this));
        }
    }

    public virtual void UseHint2()
    {
        List<BaseCell> canUselist = cellList.FindAll(x => x.State != CellState.filled && x.State != CellState.none);
        var lists = canUselist.GetRandomList(2);
        for (int i = 0; i < lists.Count; i++)
        {
            lists[i].Hint2Filed();
        }
    }

    /// <summary>
    /// 初始化时选中默认词
    /// </summary>
    public void Select()
    {
        cellManager.SetCurWord(this);
        FocusDefaultCell();
        cellList.ForEach(cell => cell.SetWordSelected(true, this));
        if (IsComplete)
            cellManager.SetCurCell(null);
    }

    /// <summary>
    /// 当输入答案错误时，显示错误UI效果，重置已输入的格子
    /// </summary>
    protected void OnWordWrong(string wrongword)
    {
        noEraseWrongTimes = 0;
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_wordWrong);
        cellManager.GameManager.GameAnimationStart();
        cellList.ForEach(c => { c.SetWrongState(true); });
        cellManager.OnWordWrong(this, wrongword);
        TimersManager.SetTimer(0.5f, () =>
        {
            cellList.ForEach(c => { c.SetWrongState(false); });
            cellManager.CacheLevelProgress();
            cellManager.GameManager.GameAnimationEnd();
        });
        FocusOneCell(cellList.Find(cell => cell.State == CellState.normal || cell.State == CellState.inputted));
    }


    public bool GetSplitWordRight(string inputword)
    {
        if (wordspit.Length > 0)
        {
            List<int> wordsplit = new List<int>(wordspit);
            wordsplit.Add(answer.Length);
            int start = 0;
            for (int i = 0; i < wordsplit.Count; i++)
            {
                if (CheckCellSplitRight(inputword, start, wordsplit[i]))
                {
                    return true;
                }

                start = wordsplit[i];
            }
        }

        return false;
    }

    /// <summary>
    /// 检查区域字段对不对
    /// </summary>
    /// <param name="wordinput"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    private bool CheckCellSplitRight(string wordinput, int start, int end)
    {
        char[] ss = answer.Trim().ToCharArray();
        char[] st = wordinput.Trim().ToCharArray();
        bool same = true;
        bool filledPart = true;
        for (int i = 0; i < ss.Length; i++)
        {
            if (i >= start && i < end)
            {
                if (ss[i] != st[i])
                {
                    same = false;
                }

                if (cellList.Count > i && cellList[i].State != CellState.filled)
                {
                    filledPart = false;
                }
            }
        }

        return same && !filledPart;
    }

    /// <summary>
    /// 接近正确答案的情况下走接近答案的逻辑
    /// </summary>
    /// <param name="inputWord"></param>
    /// <returns></returns>
    private bool WordNearRight(string inputWord, int filledCount)
    {
        int rightNumber = XUtils.GetWordRightNumber(answer.Length);
        // if (filledCount >= rightNumber)
        // {
        //     return false;
        // }

        int compareNumber = XUtils.GetStringCompare(answer, inputWord);
        if (compareNumber >= rightNumber)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 玩家连续三次答错一个接近正确的单词就直接给一个
    /// </summary>
    private void PetTipNearRightCell(string inputWord)
    {
        if (randomOrder == 0)
        {
            int random = UnityEngine.Random.Range(1, 100);
            if (random > 50)
            {
                randomOrder = 1;
            }
            else
            {
                randomOrder = -1;
            }
        }

        cellManager.GetGameManager<BaseGameManager>().GetEntity<BasePet>()
            .ShowCellTip(XUtils.GetCellTip(answer, inputWord, randomOrder, randomIndex));
    }

    /// <summary>
    /// 使用hint3填充多个格子时检查单词是否完成
    /// </summary>
    /// <returns></returns>
    public bool CheckComplete()
    {
        int emptyCount = 0, inputCount = 0;
        cellList.ForEach(cell =>
        {
            if (cell.State == CellState.normal) emptyCount++;
            else if (cell.State == CellState.inputted) inputCount++;
        });
        if (emptyCount == 0) //没有空白格时，检查答案
        {
            if (inputCount == 0)
            {
                IsComplete = true;
                cellList.ForEach(c => c.SetFilled());
                return true;
            }

            string word = "";
            cellList.ForEach(c => word += c.Letter);
            if (word.ToLower().Equals(answer.ToLower()))
            {
                IsComplete = true;
                cellList.ForEach(c => c.SetFilled());
                return true;
            }
            else
            {
                if (AppEngine.SGameSettingManager.EraseWrongWord.Value)
                    cellList.ForEach(c =>
                    {
                        if (c.State != CellState.filled && c.State != CellState.none) c.ResetToNormalState();
                    });
            }
        }

        return false;
    }

    protected virtual void OnInputCompleteWord()
    {
    }

    /// <summary>
    /// 检查输入的答案是否正确
    /// </summary>
    /// <returns></returns>
    public virtual CheckAnswerResult CheckAnswer(bool lastInputedCell)
    {
        if (0 > cellList.FindIndex(x => x.State == CellState.normal)) //没有空白格时，检查答案
        {
            string word = "";
            int filledCell = GetCellFilled();
            int rightNumber = XUtils.GetWordRightNumber(answer.Length);
            cellList.ForEach(c => word += c.Letter);
            if (word.ToLower().Equals(answer.ToLower()))
            {
                IsComplete = true;
                OnInputCompleteWord();
                cellList.ForEach(c => c.SetFilled());
                if (cellManager.GetNotCompleteWord().Count == 0)
                {
                    //小人提示用的
                    cellManager.GetGameManager<BaseGameManager>().GetEntity<BasePet>()
                        .ShowPetTip(PetTip.Type4);
                }
                else if (filledCell < rightNumber)
                {
                    int randomindex = UnityEngine.Random.Range(0, 100);
                    if (randomindex >= 50)
                    {
                        //小人提示用的
                        cellManager.GetGameManager<BaseGameManager>().GetEntity<BasePet>()
                            .ShowPetTip(PetTip.Type4);
                    }
                }

                return CheckAnswerResult.right;
            }
            else
            {
                bool _WordNearRight = WordNearRight(word, filledCell);
                bool _HasNewCellFillRight = HasNewCellFillRight();

                int level = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
                int[] tipConfig = PreLoadManager.GetPreLoadConfig<AnswerTips>(ViewConst.asset_AnswerTips_AnswerTip)
                    .GetTargetLevelConfig(level);
                if (_WordNearRight && !_HasNewCellFillRight)
                {
                    AppEngine.SSoundManager.PlaySFX(ViewConst.wav_wordWrong);
                    nearRightTime++;
                    if (nearRightTime >= MaxNearRightTime)
                    {
                        nearRightTime = 0;
                        if (tipConfig[0] < 99)
                        {
                            cellManager.GetGameManager<BaseGameManager>().GetEntity<BasePet>()
                                .ShowAnswerTip(answer);
                        }
                        else
                        {
                            PetTipNearRightCell(word);
                        }
                    }
                }

                if (!AppEngine.SGameSettingManager.EraseWrongWord.Value)
                {
                    noEraseWrongTimes++;

                    if (_WordNearRight && _HasNewCellFillRight)
                    {
                        NearRight(word);
                        if (filledCell < rightNumber)
                        {
                            //小人提示用的
                            hasNearLogic = true;
                            cellManager.GetGameManager<BaseGameManager>().GetEntity<BasePet>()
                                .ShowPetTip(PetTip.Type2);
                        }
                    }
                    else if (GetSplitWordRight(word) && _HasNewCellFillRight)
                    {
                        //分词答对了也是对
                        SplitWordRight(word);
                    }
                    else
                    {
                        if (!(tipConfig[0] < 99))
                        {
                            if (lastInputedCell)
                                wrongTimesForType1++;
                            if (wrongTimesForType1 >= 3)
                            {
                                wrongTimesForType1 = 0;
                                cellManager.GetGameManager<BaseGameManager>().GetEntity<BasePet>()
                                    .ShowPetTip(PetTip.Type1);
                            }
                        }

                        //OnWordWrong(word);
                    }

                    if (noEraseWrongTimes == 1)
                    {
                        cellManager.OnWordWrong(this, word);
                    }

                    return CheckAnswerResult.miss;
                }


                if (_WordNearRight && _HasNewCellFillRight)
                {
                    NearRight(word);
                    if (filledCell < rightNumber)
                    {
                        //小人提示用的
                        hasNearLogic = true;
                        cellManager.GetGameManager<BaseGameManager>().GetEntity<BasePet>()
                            .ShowPetTip(PetTip.Type2);
                    }
                }
                else if (GetSplitWordRight(word) && _HasNewCellFillRight)
                {
                    Debug.LogError("分词答对了");
                    //分词答对了也是对
                    SplitWordRight(word);
                }
                else
                {
                    if (!(tipConfig[0] < 99))
                    {
                        wrongTimesForType1++;
                        if (wrongTimesForType1 >= 3)
                        {
                            wrongTimesForType1 = 0;
                            cellManager.GetGameManager<BaseGameManager>().GetEntity<BasePet>()
                                .ShowPetTip(PetTip.Type1);
                        }
                    }

                    OnWordWrong(word);
                }

                GetSplitWords();
                return CheckAnswerResult.wrong;
            }
        }

        return CheckAnswerResult.miss;
    }

    /// <summary>
    /// 获取分词的list
    /// </summary>
    /// <returns></returns>
    public List<string> GetSplitWords()
    {
        if (wordspit.Length > 0)
        {
            List<int> wordsplit = new List<int>(wordspit);
            List<string> words = new List<string>();
            wordsplit.Add(answer.Length);
            int start = 0;
            for (int i = 0; i < wordsplit.Count; i++)
            {
                words.Add(answer.Substring(start, wordsplit[i] - start));
                start = wordsplit[i];
            }

            return words;
        }

        return null;
    }

    public int GetCellFilled()
    {
        //下边的逻辑暂时不需要了
        int count = 0;
        for (int i = 0; i < cellList.Count; i++)
        {
            if (cellList[i].State == CellState.filled)
            {
                count++;
            }
        }


        return count;
    }

    public bool HasNewCellFillRight()
    {
        for (int i = 0; i < cellList.Count; i++)
        {
            if (cellList[i].CellInputRight())
            {
                return true;
            }
        }

        return false;
    }

    private void SplitWordRight(string wrongword)
    {
        noEraseWrongTimes = 0;
        //播放答对半个词的效果
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_PartRight);
        cellManager.GameManager.GameAnimationStart();

        int start = 0;
        List<int> rightCell = new List<int>();
        for (int i = 0; i < wordspit.Length; i++)
        {
            if (CheckCellSplitRight(wrongword, start, wordspit[i]))
            {
                for (int j = start; j < wordspit[i]; j++)
                {
                    rightCell.Add(j);
                }
            }

            start = wordspit[i];
        }

        if (CheckCellSplitRight(wrongword, wordspit[wordspit.Length - 1], GetCellCount()))
        {
            for (int j = wordspit[wordspit.Length - 1]; j < GetCellCount(); j++)
            {
                rightCell.Add(j);
            }
        }

        for (int i = 0; i < cellList.Count; i++)
        {
            if (rightCell.Contains(i))
            {
                cellList[i].SplitWordRight(true);
            }
            else
            {
                cellList[i].SplitWordRight(false);
            }
        }

        //cellList.ForEach(c => { c.WordNearRight(); });
        //cellManager.OnWordWrong(this, wrongword);
        TimersManager.SetTimer(1f, () =>
        {
            //cellList.ForEach(c => { c.SetWrongState(false); });
            cellManager.CacheLevelProgress();
            cellManager.GameManager.GameAnimationEnd();
        });
        FocusOneCell(cellList.Find(cell => cell.State == CellState.normal || cell.State == CellState.inputted));
    }

    private void NearRight(string wrongword)
    {
        Debug.LogError("差一点就答对了");
        noEraseWrongTimes = 0;
        //播放答对半个词的效果
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_PartRight);
        cellManager.GameManager.GameAnimationStart();
        cellList.ForEach(c => { c.WordNearRight(); });
        cellManager.OnWordWrong(this, wrongword);
        TimersManager.SetTimer(1f, () =>
        {
            //cellList.ForEach(c => { c.SetWrongState(false); });
            cellManager.CacheLevelProgress();
            cellManager.GameManager.GameAnimationEnd();
        });
        FocusOneCell(cellList.Find(cell => cell.State == CellState.normal || cell.State == CellState.inputted));
    }

    /// <summary>
    /// 使该行的当前格子的下一个格子获得焦点
    /// </summary>
    /// <param name="cell">当前格子</param>
    public void FocusNextCell(BaseCell cell, bool ignoreSwitch)
    {
        int index = cellList.IndexOf(cell);
        if (ignoreSwitch || AppEngine.SGameSettingManager.SkipFilledSquares.Value)
            index = cellList.FindIndex(index + 1, x => x.State == CellState.normal || x.State == CellState.inputted);
        else
            index = cellList.FindIndex(index + 1,
                x => x.State == CellState.normal || x.State == CellState.inputted || x.State == CellState.filled);
        if (index < 0)
        {
            BaseCell nextCell;
            if (ignoreSwitch || AppEngine.SGameSettingManager.SkipFilledSquares.Value)
                nextCell = cellList.Find(c => c.State == CellState.normal || c.State == CellState.inputted);
            else
                nextCell = cellList.Find(c =>
                    c.State == CellState.normal || c.State == CellState.inputted || c.State == CellState.filled);
            FocusOneCell(nextCell);
        }
        else
        {
            FocusOneCell(cellList[index]);
        }
    }

    /// <summary>
    /// 当删除操作执行后，如果当前格子已经空了，则移动焦点到上一个格子
    /// </summary>
    /// <param name="cell"></param>
    public void OnCellLetterDel(BaseCell cell)
    {
        int index = cellList.IndexOf(cell);
        if (index <= 0)
            return;
        if (AppEngine.SGameSettingManager.SkipFilledSquares.Value)
        {
            index = cellList.FindLastIndex(index - 1, x => x.State != CellState.filled && x.State != CellState.none);
        }
        else
        {
            index = cellList.FindLastIndex(index - 1, x => x.State != CellState.none);
        }

        if (index < 0)
        {
            //FocusOneCell(FindToFocusCell());
        }
        else
        {
            cellList[index].ResetToNormalState();
            FocusOneCell(cellList[index]);
        }
    }

    /// <summary>
    /// 指定格子获得焦点
    /// </summary>
    /// <param name="cell">要获得焦点的格子</param>
    private void FocusOneCell(BaseCell cell)
    {
        if (cell != null)
        {
            cell.SetFocus(true);
        }
    }

    /// <summary>
    /// 寻找第一个空白格
    /// </summary>
    /// <returns></returns>
    public BaseCell FindFirstCanInputCell()
    {
        return cellList.Find(cell => cell.State == CellState.normal || cell.State == CellState.inputted);
    }

    /// <summary>
    /// 使第一个空白格获得焦点
    /// </summary>
    public void FocusDefaultCell()
    {
        if (cellManager.CurCell == null || !cellList.Contains(cellManager.CurCell))
        {
            FocusOneCell(FindFirstCanInputCell());
        }
    }

    public void FocusFirstCanInputCell()
    {
        FocusOneCell(FindFirstCanInputCell());
    }

    public List<BaseCell> Cells
    {
        get { return cellList; }
    }

    /// <summary>
    /// 获取所有未填充正确字母的格子
    /// </summary>
    /// <returns></returns>
    public List<BaseCell> GetNotFillCells()
    {
        List<BaseCell> cells = new List<BaseCell>();
        cellList.ForEach(c =>
        {
            if (c.State == CellState.normal || c.State == CellState.inputted)
                cells.Add(c);
        });
        return cells;
    }

    public List<BaseCell> GetAutoHintCanFillCells()
    {
        List<BaseCell> cells = new List<BaseCell>();
        cellList.ForEach(c =>
        {
            if (AutoHintFillCacheCells.Contains(c))
                return;
            if (c.State == CellState.normal || c.State == CellState.inputted)
                cells.Add(c);
        });
        return cells;
    }

    public void CacheAutoHintFillCell(BaseCell cell)
    {
        AutoHintFillCacheCells.Add(cell);
    }

    private List<BaseCell> AutoHintFillCacheCells = new List<BaseCell>();

    public void ResetAutoHintFillCacheCells()
    {
        AutoHintFillCacheCells.Clear();
    }

    /// <summary>
    /// 获得第一个格子的坐标
    /// </summary>
    /// <returns></returns>
    public Vector3 GetFirstCellPos()
    {
        return cellList[0].transform.position;
    }

    /// <summary>
    /// 获取最后一个cell的坐标
    /// </summary>
    /// <returns></returns>
    public Vector3 GetLastCellPos()
    {
        BaseCell precell = null;
        for (int i = 0; i < cellList.Count; i++)
        {
            if (cellList[i].State == CellState.none)
            {
                if (precell != null)
                {
                    return precell.transform.position;
                }
            }

            precell = cellList[i];
        }

        return cellList[cellList.Count - 1].transform.position;
    }

    public int GetCellCount()
    {
        return answer.Length;
    }

    /// <summary>
    /// 获取单词的问题描述
    /// </summary>
    /// <returns></returns>
    public virtual string GetWordQuestion()
    {
        return "";
    }

    /// <summary>
    /// word的优先级，用于完成一个答案时自动提示字母位置顺序的确定
    /// </summary>
    /// <returns></returns>
    public virtual int GetHintOrder()
    {
        return 0;
    }

    public virtual void DisAppear()
    {
    }

    public void PlayFadeInOut()
    {
        List<BaseCell> cells = ValidCells;
        float interval = 0.2f;
        float totalTime = interval * (cells.Count - 1) + 0.9f;
        SequenceTask task = SequenceUtil.StartTask(totalTime, new SequenceTaskActionCallback(() => { }));
        task.InsertCallback(0.01f, new SequenceTaskObjectCallback<BaseCell>(cells[0], cell => cell.PlayFadeInOut()));
        for (int i = 1; i < cells.Count; i++)
        {
            task.InsertCallback(interval,
                new SequenceTaskObjectCallback<BaseCell>(cells[i], cell => cell.PlayFadeInOut()));
        }
    }

    public void PointAllAnswer()
    {
        return;
        MainSceneDirector.Instance.StartCoroutine(PointAnswers());
    }

    private IEnumerator PointAnswers()
    {
        KeyboardOneKey[] keys = CellManager.GetGameManager<BaseGameManager>().GetEntity<BaseKeyBoard>()
            ._KeyboardOneKeys;
        for (int i = 0; i < cellList.Count; i++)
        {
            yield return new WaitForSeconds(0.5f);
            if (!cellList[i].IsRight)
            {
                for (int j = 0; j < keys.Length; j++)
                {
                    BaseCell cell = cellList[i];
                    FieldInfo property = cell.GetType().GetField("answerLetter",
                        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    string cellanswer = (string) property.GetValue(cell);
                    Debug.LogError(cellanswer);
                    if (keys[j]._key.ToString().ToLower() == cellanswer.ToLower())
                    {
                        BootUtils.ClickKeyBoardKey(keys[j]);
                        break;
                    }
                }
            }
        }
    }
}

public enum CheckAnswerResult
{
    none,
    right, //答案正确
    wrong, //答案错误
    miss //有未输入的格子
}

public class BaseNormalWord : BaseWord
{
    protected BaseQuestionEntity question;
    protected bool checkAnswerToCompleteWord = true;

    public BaseNormalWord(BaseCellManager cellManager, BaseQuestionEntity question) : base(cellManager, question.Answer,
        question.SimiWords, CommUtil.GetWordSplit(question.wordSpit))
    {
        this.question = question;
    }

    public BaseQuestionEntity BaseQuestion
    {
        get { return question; }
    }

    public override CheckAnswerResult CheckAnswer(bool lastInputedCell)
    {
        CheckAnswerResult result = base.CheckAnswer(lastInputedCell);
        if (result == CheckAnswerResult.right && checkAnswerToCompleteWord)
        {
            cellManager.OnCompleteOneWord(this);
        }

        return result;
    }

    public override string GetWordQuestion()
    {
        return question.Question;
    }

    /// <summary>
    /// word的优先级，用于完成一个答案时自动提示字母位置顺序的确定
    /// </summary>
    /// <returns></returns>
    public override int GetHintOrder()
    {
        return question.Priority;
    }

    /// <summary>
    /// 可以被其他词完成时提示的最大数量
    /// </summary>
    public override int ValidHintCount
    {
        get
        {
            if (question.MaxAutoHint < 0)
                return 99;
            return question.MaxAutoHint - HintCount;
        }
    }

    /// <summary>
    /// 可以被其他词完成时提示的最大数量
    /// </summary>
    public override int MaxBeFlyToCount
    {
        get
        {
            if (question.MaxAutoHint < 0)
                return question.Answer.Length - 1;
            return question.MaxAutoHint;
        }
    }

    public override int MinBeFlyToCount
    {
        get
        {
            if (question.MaxAutoHint < 0)
                return 2;
            return 2;
        }
    }
}