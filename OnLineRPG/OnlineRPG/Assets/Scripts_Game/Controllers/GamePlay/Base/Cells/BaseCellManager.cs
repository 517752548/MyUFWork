using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine.UI;
using DG.Tweening;
using Newtonsoft.Json.Aot;


public class BaseCellManager : GameEntity
{
    protected struct DataForReport
    {
        //上次正确后使用道具次数
        public int Hint1;
        public int Hint2;
        public int Hint3;
        public int Hint4;
        //上次正确后答错次数
        public int WrongTimes;

        internal void OnCompleteWord()
        {
            Hint1 = 0;
            Hint2 = 0;
            Hint3 = 0;
            Hint4 = 0;
            WrongTimes = 0;
        }
    }
    //wordRegion区域
    public CellsScrollRect scrollRect;
    public RectTransform scrollViewport;
    public RectTransform scrollContent;
    public GridLayoutGroup gridLayout;

    public BaseWordFocusBox focusWordFlag;

    protected BaseWord curWord;
    protected List<BaseWord> wordList = new List<BaseWord>();
    public BaseCell CurCell { get; private set; }
    protected List<BaseCell> allCells = new List<BaseCell>();// 全部Cells
    protected int rowCellCount;
    private BaseWord curHintSelWord = null;
    private BaseCell curHintSelCell = null;
    public float cellSize { get; protected set; }
    public float effectScale { get; protected set; }
    protected float viewPortHeight, contentHeight, lineSpace, maxDeltaY, gridTop, targetPosY;
    private bool GameFinished = false;
    private Tweener cellMoveTweener;
    public BaseCell LastClickCell { get; set; }

    protected DataForReport ReportData;

    public virtual void Init()
    {
        ResetDatas();

        InitCells();
        GameManager.GetEntity<BaseQuestionDisplay>().Init();

        RecoveryLastProgress();
        AppEngine.SGameSettingManager.MarkFlyCell.ValueChanged.AddListener(()=>curWord?.Refresh());
    }

    public List<BaseWord> Words { get { return wordList; } }

    public int WrongTimes { get { return ReportData.WrongTimes; } }

    public int RowCellCount => rowCellCount;
    
    /// <summary>
    /// 重置数据
    /// </summary>
    private void ResetDatas()
    {
        for (int i = 0; i < allCells.Count; i++)
        {
            AppEngine.SObjectPoolManager.Despawn(GetCellResName(), allCells[i].gameObject);
        }

        allCells.Clear();
        wordList.Clear();
        CurCell = null;
        curWord = null;
    }

    /// <summary>
    /// 设置当前选中的格子
    /// </summary>
    /// <param name="cell"></param>
    public virtual void SetCurCell(BaseCell cell)
    {
        if (CurCell != null && CurCell != cell)
            CurCell.SetFocus(false);
        CurCell = cell;
        
        if (cell != null)
        {
            MoveCellCenter(cell);
        }
    }

    /// <summary>
    /// 将当前选中格子所在行移到到格子显示区域的中间位置
    /// </summary>
    /// <param name="cell">选中的格子</param>
    protected virtual void MoveCellCenter(BaseCell cell)
    {
        scrollRect.inertia = false;
        float wordY = Math.Abs(cell.transform.localPosition.y) + gridTop;
        float deltaY = wordY - targetPosY;
        if (deltaY < 0)
            deltaY = 0;
        else if (deltaY > maxDeltaY)
            deltaY = maxDeltaY;
        //scrollContent.SetLocalY(deltaY);
        ScrollContentLocalMoveY(deltaY, 0.3f);
    }

    protected Tweener ScrollContentLocalMoveY(float y, float duration)
    {
        if (cellMoveTweener != null)
        {
            cellMoveTweener.Kill();
        }
        cellMoveTweener = scrollContent.DOLocalMoveY(y, duration);
        cellMoveTweener.OnComplete(() => {
            cellMoveTweener = null;
        });
        return cellMoveTweener;
    }

    public void StopCellMove()
    {
        scrollRect.inertia = false;
        if (cellMoveTweener != null)
        {
            cellMoveTweener.Kill();
            cellMoveTweener = null;
        }
    }

    public void OnEnterPlayState()
    {
        if (curWord == null)
        {
            focusWordFlag.gameObject.SetActive(true);
            CheckGame();
            //GameManager.GetEntity<BaseQuestionDisplay>().OnWordChanged(curWord);
            //focusWordFlag.MoveTo(curWord);
        }
    }

    private void Start()
    {
        //延时调整word选中框位置，否则第一次进入位置不对
        //TimersManager.SetTimer(0.2f, 8, () => {
        //    if (curWord != null)
        //        focusWordFlag.MoveTo(curWord);
        //});
    }

    /// <summary>
    /// 设置当前选中word
    /// </summary>
    /// <param name="word">选中的word</param>
    public virtual void SetCurWord(BaseWord word)
    {
        if (curWord != null && curWord != word)
        {
            curWord.SetSelect(false);
        }
        curWord = word;
        if (word != null)
        {
            if (CurCell == null)
                MoveCellCenter(curWord.Cells[0]);
            focusWordFlag.MoveTo(curWord);
            GameManager.OnWordChangeFocus(word);
        }
        else
        {
            focusWordFlag.gameObject.SetActive(false);
        }
    }

    
    public void MoveToWord(BaseWord word)
    {
        if (word != null)
        {
            MoveCellCenter(word.Cells[0]);
        }
    }

    public bool IsCurWord(BaseWord word)
    {
        return curWord == word;
    }
    
    /// <summary>
    /// 初始化所有格子
    /// </summary>
    protected virtual void InitCells()
    {

    }

    /// <summary>
    /// 格子资源名称
    /// </summary>
    /// <returns></returns>
    protected virtual string GetCellResName()
    {
        return "";
    }

    /// <summary>
    /// 每行最大格子数
    /// </summary>
    /// <returns></returns>
    protected virtual int GetRowCellCount()
    {
        return 5;
    }

    /// <summary>
    /// 总行数
    /// </summary>
    /// <returns></returns>
    protected virtual int GetRowCount()
    {
        return 0;
    }

    /// <summary>
    /// 调整布局、大小、位置
    /// </summary>
    protected virtual void AdjustRect()
    {
        rowCellCount = GetRowCellCount();
        lineSpace = 20;
        scrollContent.SetLocalY(0);
        scrollViewport = (RectTransform)scrollContent.parent;
        scrollRect = scrollViewport.parent.gameObject.GetComponent<CellsScrollRect>();
        gridTop = Math.Abs(gridLayout.GetComponent<RectTransform>().offsetMax.y) + gridLayout.padding.top;
        var gridBottom = Math.Abs(gridLayout.GetComponent<RectTransform>().offsetMax.y) + gridLayout.padding.bottom;
        cellSize = scrollContent.rect.width / rowCellCount;
        gridLayout.cellSize = new Vector2(cellSize, cellSize + lineSpace);
        focusWordFlag.Init(cellSize);
        contentHeight = (cellSize + lineSpace) * GetRowCount() + gridTop + gridBottom + 20;
        viewPortHeight = scrollViewport.rect.height;
        maxDeltaY = contentHeight - viewPortHeight;
        if (maxDeltaY < 0) maxDeltaY = 0;
        targetPosY = viewPortHeight / 2;
        scrollContent.sizeDelta = new Vector2(scrollContent.sizeDelta.x, contentHeight);
        effectScale = cellSize / 114.4f;
    }

    /// <summary>
    /// 播放格子区域预览滚动动画
    /// </summary>
    /// <param name="aniOverCallback"></param>
    public void PlayPreviewAni(Action aniOverCallback = null)
    {
        if (maxDeltaY > 0)
        {
            scrollRect.inertia = false;
            Sequence seq = DOTween.Sequence();
            seq.Append(ScrollContentLocalMoveY(maxDeltaY, 1f));
            //MoveCellCenter(curWord.Cells[0]);
            //scrollRect.inertia = false;
            //float wordY = Math.Abs(curWord.Cells[0].transform.localPosition.y) + gridTop;
            //float deltaY = wordY - targetPosY;
            //if (deltaY < 0)
            //    deltaY = 0;
            //else if (deltaY > maxDeltaY)
            //    deltaY = maxDeltaY;
            //seq.Append(scrollContent.DOLocalMoveY(deltaY, 0.5f));
            seq.AppendCallback(() => { aniOverCallback?.Invoke(); }); 
        }
        else
        {
            aniOverCallback?.Invoke();
        }
    }

    /// <summary>
    /// 从键盘输入字母
    /// </summary>
    /// <param name="letter"></param>
    public virtual void InputLetter(string letter)
    {
        if (CurCell == null)
        {
            FocusOneNotFilledWord();
        }
        else
        {
            CurCell.InputLetter(letter);
        }
        CacheLevelProgress();
    }
    
    /// <summary>
    /// 寻找一个空白格获得焦点
    /// </summary>
    public void FocusOneNotFilledWord()
    {
        BaseWord toFocusWord = null;
        if (curWord == null)
        {
            toFocusWord = wordList.Find(x => !x.IsComplete);
        }
        else if (curWord.IsComplete)
        {
            int index = wordList.IndexOf(curWord);
            index = wordList.FindIndex(index + 1, x => !x.IsComplete);
            //curWord.SetSelect(false);
            if (index < 0)
                toFocusWord = wordList.Find(x => !x.IsComplete);
            else
            {
                toFocusWord = wordList[index];
            }
        }
        toFocusWord?.SetSelect(true);
    }

    public BaseWord GetCruBaseWord()
    {
        return curWord;
    }
    /// <summary>
    /// 检查是否所有格子已经填满
    /// </summary>
    /// <returns></returns>
    public bool CheckIsFull()
    {
        BaseWord word = wordList.Find(x => !x.IsComplete);
        if (ReferenceEquals(word, null))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// 响应上一个、下一个按钮点击
    /// </summary>
    /// <param name="next">true下一个，false上一个</param>
    public virtual void OnClickChangeWord(bool next)
    {
        BaseWord toFocusWord = null;
        int index = wordList.IndexOf(curWord);
        curWord.SetSelect(false);
        if (next)
        {
            index = wordList.FindIndex(index + 1, x => !x.IsComplete);
            if (index < 0)
                toFocusWord = wordList.Find(x => !x.IsComplete);
            else
            {
                toFocusWord = wordList[index];
            }
        }
        else
        {
            if (index > 0)
                index = wordList.FindLastIndex(index - 1, x => !x.IsComplete);
            else
                index = -1;
            if (index < 0)
                toFocusWord = wordList.FindLast(x => !x.IsComplete);
            else
            {
                toFocusWord = wordList[index];
            }
        }
        toFocusWord?.Select();
    }

    public virtual void OnWordWrong(BaseWord word,string wrongword)
    {
        ReportData.WrongTimes++;
        GameManager.GameTempData.WrongTimesForTip++;
    }

    /// <summary>
    /// 响应一个答案被完成
    /// </summary>
    /// <param name="word"></param>
    public virtual void OnCompleteOneWord(BaseWord word, bool playAni = true, Action overCallback = null)
    {
        OnWordCompleted(new List<BaseWord> { word });
        StartCoroutine(WordCompleteProcess(word, playAni, overCallback));
    }

    private IEnumerator WordCompleteProcess(BaseWord word, bool playAni, Action overCallback)
    {
        GameManager.GameAnimationStart();
        if (playAni)
        {
            //DisplayCorrectLightFrame(word);
            BaseCell cell;
            for (int i = 0; i < word.Cells.Count; i++)
            {
                cell = word.Cells[i];
                if (cell.State != CellState.none)
                {
                    cell.PlayCompletedAni();
                    yield return new WaitForSeconds(0.1f);
                }
            } 
            //DisappearAllCorrectLightFrame();
        }
        yield return OnAnswerCorrectAniOver(new List<BaseWord>(){word});
        if (NewFlyCell())
            yield return CellFlyOut(new List<BaseWord>(){word});
        else
            yield return HintByAnswer(word);
        yield return OnAnswerAniOver(new List<BaseWord>(){word});
        CheckGame();
        CacheLevelProgress();
        GameManager.GameAnimationEnd();
        overCallback?.Invoke();
        yield break;
    }

    protected virtual bool NewFlyCell()
    {
        return AppEngine.SSystemManager.GetSystem<CellTipABSystem>().CellTipEnable;
    }

    public virtual void CheckGame()
    {
        if (!CheckIsFull())
        {
            FocusOneNotFilledWord();
        }
    }
    
    /// <summary>
    /// hint3使用后检查格子和word
    /// </summary>
    public void CheckMultiWord(bool playAni = true, BaseWord skipAniWord = null)
    {
        List<BaseWord> newCompleteWords = new List<BaseWord>();
        GetNotCompleteWord().ForEach(word => {
            if (word.CheckComplete())
                newCompleteWords.Add(word);
        });
        CacheLevelProgress();
        if (newCompleteWords.Count > 0)
        {
            OnWordCompleted(newCompleteWords);
            StartCoroutine(MultiWordCompleteProcess(newCompleteWords, playAni, skipAniWord));
        }
        else
        {
            curWord?.FocusDefaultCell();
        }
    }

    private IEnumerator MultiWordCompleteProcess(List<BaseWord> words, bool playAni = true, BaseWord skipAniWord = null)
    {
        GameManager.GameAnimationStart();
        if (playAni)
        {
            BaseCell cell;
            bool playAniDid = false;
            for (int i = 0; i < rowCellCount; i++)
            {
                playAniDid = false;
                words.ForEach(word => {
                    // if (i == 0)
                    //     DisplayCorrectLightFrame(word);
                    // if (i >= word.Cells.Count)
                    //     return;
                    if (skipAniWord == word)
                        return;
                    if (word.Cells.Count > i)
                    {
                        cell = word.Cells[i];
                        if (cell.State != CellState.none)
                        {
                            cell.PlayCompletedAni();
                            playAniDid = true;
                        }
                    }
                
                });
            
                if (playAniDid)
                    yield return new WaitForSeconds(0.1f);
            }
        }
        //DisappearAllCorrectLightFrame();
        yield return OnAnswerCorrectAniOver(words);
        if (NewFlyCell())
            yield return CellFlyOut(words);
        else
            yield return HintByAnswer(words);
        yield return OnAnswerAniOver(words);
        CheckGame();
        CacheLevelProgress();
        GameManager.GameAnimationEnd();
        yield break;
    }

    // public void DisplayCorrectLightFrame(BaseWord word)
    // {
    //     var box = AppEngine.SObjectPoolManager.Spawn(ViewConst.prefab_Image_Correct, 
    //         prefabCorrectLightFrame.transform, Vector3.zero, default(Quaternion), scrollContent);
    //     box.localScale = Vector3.one;
    //     box.GetComponent<LightFrameBox>().Show(word);
    //     focusWordFlag.SetActive(false);
    // }

    // public void DisappearAllCorrectLightFrame()
    // {
    //     AppEngine.SObjectPoolManager.GetPrefabPool(ViewConst.prefab_Image_Correct)?.Spawned.ForEach(obj =>
    //     {
    //         AppEngine.SObjectPoolManager.Despawn(obj);
    //     });
    //     focusWordFlag.SetActive(true);
    // }
    //
    // public virtual void DisplayWrongLightFrame(BaseWord word)
    // {
    //     var box = AppEngine.SObjectPoolManager.Spawn(ViewConst.prefab_Image_Wrong, 
    //         prefabWrongLightFrame.transform, Vector3.zero, default(Quaternion), scrollContent);
    //     box.localScale = Vector3.one;
    //     box.GetComponent<LightFrameBox>().Show(word);
    //     focusWordFlag.SetActive(false);
    // }
    //
    // public void DisappearWrongLightFrame()
    // {
    //     AppEngine.SObjectPoolManager.GetPrefabPool(ViewConst.prefab_Image_Wrong)?.Spawned.ForEach(obj =>
    //     {
    //         AppEngine.SObjectPoolManager.Despawn(obj);
    //     });
    //     focusWordFlag.SetActive(true);
    // }
    protected virtual void OnWordCompleted(List<BaseWord> words)
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_WordRight);
        ReportData.OnCompleteWord();
        GameManager.GameTempData.WrongTimesForTip = 0;
        GameManager.GetEntity<BasePet>().CloseAnswerTip();
        GameManager.GetEntity<BasePet>().CloseCellTip();
    }

    public void HintUse(bool hint1, bool hint2, bool hint3, bool hint4)
    {
        ReportData.Hint1 += hint1 ? 1 : 0;
        ReportData.Hint2 += hint2 ? 1 : 0;
        ReportData.Hint3 += hint3 ? 1 : 0;
        ReportData.Hint4 += hint4 ? 1 : 0;
        GameManager.GameTempData.hint1num += hint1 ? 1 : 0;
        GameManager.GameTempData.hint2num += hint2 ? 1 : 0;
        GameManager.GameTempData.hint3num += hint3 ? 1 : 0;
        GameManager.GameTempData.hint4num += hint4 ? 1 : 0;
        GameManager.GameTempData.WrongTimesForTip = 0;
        GameManager.GameTempData.WordStayTimeForTip = 0;
    }

    public int CompletedWordsCount
    {
        get
        {
            return wordList.FindAll(word => word.IsComplete).Count;
        }
    }

    /// <summary>
    /// 恢复上次存档
    /// </summary>
    protected virtual void RecoveryLastProgress()
    {

    }

    /// <summary>
    /// 当前关卡完成
    /// </summary>
    public virtual void OnGameCompleted()
    {
        if (GameFinished)
        {
            return;
        }
        GameFinished = true;
        ClearLevelProgress();
        focusWordFlag.gameObject.SetActive(false);
    }
    
    protected virtual IEnumerator OnAnswerCorrectAniOver(List<BaseWord> words)
    {
        yield break;
    }
    
    
    // 存储存档
    public virtual void CacheLevelProgress()
    {
    }

    // 清除存档
    protected virtual void ClearLevelProgress()
    {
        GameManager.ClearLevelProgress();
    }

    #region 入场出厂动画

    public virtual void Appear()
    {
        
    }

    public virtual void DisAppear()
    {

    }
    
    #endregion

    /// <summary>
    /// 回收cell
    /// </summary>
    private void DiSpawnCell()
    {
        for (int i = 0; i < allCells.Count; i++)
        {
            AppEngine.SObjectPoolManager.Despawn(GetCellResName(), allCells[i].gameObject);
        }
    }

    protected virtual IEnumerator OnAnswerAniOver(List<BaseWord> words)
    {
        yield break;
    }
    
    public List<BaseWord> GetNotCompleteWord()
    {
        //return wordList.FindAll(word => !word.IsComplete);
        List<BaseWord> NotCompleteWords = new List<BaseWord>();
        wordList.ForEach(w => { if (!w.IsComplete) NotCompleteWords.Add(w); });
        return NotCompleteWords;
    }

    /// <summary>
    /// hint拖拽点发射射线，选中碰撞的word
    /// </summary>
    /// <param name="ray"></param>
    /// <returns></returns>
    public BaseWord HintSelectWord(Vector2 pos, bool skipHint2 = false)
    {
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit.transform != null)
        {
            if (hit.collider.gameObject.tag == "cell")
            {
                BaseCell cell = hit.collider.gameObject.GetComponent<BaseCell>();
                if (cell != null && cell.State != CellState.none && !cell.ParentWord.IsComplete)
                {
                    if (curHintSelWord == null || curHintSelWord != cell.ParentWord)
                    {
                        if (curHintSelWord != null)
                            curHintSelWord.HintSel(false);
                        if (skipHint2 && cell.ParentWord.IsKeyboardHintUsed)
                        {
                            curHintSelWord = null;
                        }
                        else
                        {
                            curHintSelWord = cell.ParentWord;
                            curHintSelWord.HintSel(true);
                        }
                        
                    }
                    return cell.ParentWord;
                }
            }
        }
        ClearHintSelectWord();
        return null;
    }

    public void ClearHintSelectWord()
    {
        if (curHintSelWord != null)
        {
            curHintSelWord.HintSel(false);
            curHintSelWord = null;
        }
    }

    /// <summary>
    /// hint拖拽点发射射线，选中碰撞的cell
    /// </summary>
    /// <param name="ray"></param>
    /// <returns></returns>
    public BaseCell HintSelectCell(Vector2 pos)
    {
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit.transform != null)
        {
            if (hit.collider.gameObject.tag == "cell")
            {
                BaseCell cell = hit.collider.gameObject.GetComponent<BaseCell>();
                if (cell != null && (cell.State == CellState.normal || cell.State == CellState.inputted))
                {
                    if (curHintSelCell == null || curHintSelCell != cell)
                    {
                        if (curHintSelCell != null)
                            curHintSelCell.HintSel(false);
                        curHintSelCell = cell;
                        curHintSelCell.HintSel(true);
                    }
                    return cell;
                }
            }
        }
        ClearHintSelectCell();
        return null;
    }

    public void ClearHintSelectCell()
    {
        if (curHintSelCell != null)
        {
            curHintSelCell.HintSel(false);
            curHintSelCell = null;
        }
    }

    /// <summary>
    /// 答出一个答案后提示其他答案中的字母
    /// </summary>
    /// <param name="answer"></param>
    protected IEnumerator HintByAnswer(BaseWord word)
    {
        wordList.ForEach(w => w.ResetAutoHintFillCacheCells());
        List<BaseCell> hintCells = new List<BaseCell>();
        List<BaseCell> validLetters = CheckWordFlyOutLetters(word, ref hintCells);
        
        if (hintCells.Count > 0)//有格子可填充则进行概率匹配，否则什么都不做
        {
            int limitHintCount = AppEngine.SSystemManager.GetSystem<ProbabilitySystem>().GetProbability(GetWordFlyProbabilityID(word.Index).ToString());
            int letterCount = validLetters.Count;
            int hintCount = letterCount > limitHintCount ? limitHintCount : letterCount;
            validLetters = XUtils.RandomFromList(validLetters, hintCount);
            Dictionary<BaseCell, BaseCell> flyFromCells = new Dictionary<BaseCell, BaseCell>();
            List<BaseCell> tempCells = new List<BaseCell>(hintCells);
            hintCells.Clear();
            tempCells.ForEach(c => {
                int index = validLetters.FindIndex(cell => cell.AnswerLetter == c.AnswerLetter);
                if (index >= 0)
                {
                    hintCells.Add(c);
                    flyFromCells.Add(validLetters[index], c);
                    validLetters.RemoveAt(index);
                }
            });

            float flyTime = 1f;
            List<BaseCell> flyCells = new List<BaseCell>();
            foreach (KeyValuePair<BaseCell, BaseCell> keyPair in flyFromCells)
            {
                BaseCell flyCell = keyPair.Key.Clone();
                flyCells.Add(flyCell);
                flyCell._CanvasGroup.blocksRaycasts = false;
                flyCell.ShowTrailEffect();
                flyCell.transform.DOMove(keyPair.Value.transform.position, flyTime).SetEase(Ease.OutCubic);
            }
            yield return new WaitForSeconds(flyTime);
            hintCells.ForEach(c => c.AutoHintFill());
            AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_AutoHintFill);
            yield return new WaitForSeconds(0.2f);
            flyCells.ForEach(flyCell => Destroy(flyCell.gameObject));
            hintCells.ForEach(c => c.AutoHintFillCheckAnswer());
        }
        yield break;
    }

    /// <summary>
    /// 答出多个答案后提示其他答案中的字母
    /// </summary>
    /// <param name="answer"></param>
    protected IEnumerator HintByAnswer(List<BaseWord> words)
    {
        wordList.ForEach(w => w.ResetAutoHintFillCacheCells());
        Dictionary<BaseWord, List<BaseCell>> answerLettersDic = new Dictionary<BaseWord, List<BaseCell>>();
        List<BaseCell> hintCells = new List<BaseCell>();
        foreach (BaseWord word in words)
        {
            answerLettersDic.Add(word, CheckWordFlyOutLetters(word, ref hintCells));
        }
        
        if (hintCells.Count > 0)//有格子可填充则进行概率匹配，否则什么都不做
        {
            //Dictionary<BaseWord, List<BaseCell>> answerCellsDic = new Dictionary<BaseWord, List<BaseCell>>();
            Dictionary<BaseCell, BaseCell> flyFromCells = new Dictionary<BaseCell, BaseCell>();
            List<BaseCell> tempCells = new List<BaseCell>(hintCells);
            hintCells.Clear();
            words.ForEach(word => {
                List<BaseCell> validLetters = answerLettersDic[word];
                int limitHintCount = AppEngine.SSystemManager.GetSystem<ProbabilitySystem>().GetProbability(GetWordFlyProbabilityID(word.Index).ToString());
                int letterCount = validLetters.Count;
                int hintCount = letterCount > limitHintCount ? limitHintCount : letterCount;
                validLetters = XUtils.RandomFromList(validLetters, hintCount);
                //answerCellsDic.Add(word, new List<BaseCell>());
                //if (validLetters.Count < letterCount)
                {
                    validLetters.ForEach(ch => {
                        BaseCell cell = tempCells.Find(c => c.AnswerLetter == ch.AnswerLetter);
                        if (cell != null)
                        {
                            hintCells.Add(cell);
                            //answerCellsDic[word].Add(cell);
                            flyFromCells.Add(ch, cell);
                            tempCells.Remove(cell);
                        }
                    });
                }
            });

            float flyTime = 1f;
            List<BaseCell> flyCells = new List<BaseCell>();
            foreach (KeyValuePair<BaseCell, BaseCell> keyPair in flyFromCells)
            {
                BaseCell flyCell = keyPair.Key.Clone();
                flyCells.Add(flyCell);
                flyCell._CanvasGroup.blocksRaycasts = false;
                flyCell.ShowTrailEffect();
                flyCell.transform.DOMove(keyPair.Value.transform.position, flyTime).SetEase(Ease.OutCubic);
            }
            yield return new WaitForSeconds(flyTime);
            hintCells.ForEach(c => c.AutoHintFill());
            AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_AutoHintFill);
            yield return new WaitForSeconds(0.2f);
            flyCells.ForEach(flyCell => Destroy(flyCell.gameObject));
            hintCells.ForEach(c => c.AutoHintFillCheckAnswer());
        }
        yield break;
    }

    private List<BaseCell> CheckWordFlyOutLetters(BaseWord word, ref List<BaseCell> hintCells)
    {
        //char[] arr = word.Answer.ToUpper().ToCharArray();
        List<BaseCell> allLetters = word.Cells.FindAll(c => c.State != CellState.none);
        List<BaseCell> validLetters = new List<BaseCell>();//该答案中所有能飞的字母（飞出去无处安置的则不能飞）
        List<BaseWord> NotCompleteWords = GetNotCompleteWord();//未完成的单词
        //未完成的单词按优先级排序
        NotCompleteWords = SortHintWords(NotCompleteWords);
        //NotCompleteWords.Sort((x, y) => { return x.GetHintOrder() - y.GetHintOrder(); });
        //遍历未完成的单词中所有未填充的格子，找到与答案字母匹配的格子
        foreach (BaseWord w in NotCompleteWords)
        {
            List<BaseCell> cells = w.GetAutoHintCanFillCells();
            int emptyCellCount = cells.FindAll(c => c.State == CellState.normal).Count;
            int validHintCount = w.ValidHintCount;
            foreach (BaseCell c in cells)
            {
                BaseCell matchCell = allLetters.Find(cell => cell.AnswerLetter.Equals(c.AnswerLetter));
                if (matchCell != null && validHintCount > 0)
                {
                    if (c.State == CellState.normal)
                    {
                        if (emptyCellCount > 1)
                            emptyCellCount--;
                        else//只剩这一个空格子，填充了它会导致它所在单词完成，则不能填充它
                            continue;
                    }
                    validHintCount--;
                    validLetters.Add(matchCell);
                    if (!hintCells.Contains(c))
                        hintCells.Add(c);
                    w.CacheAutoHintFillCell(c);
                    allLetters.Remove(matchCell);
                }
            }
        }
        return validLetters;
    }

    private List<BaseWord> SortHintWords(List<BaseWord> words)
    {
        List<int> priority = new List<int>();
        Dictionary<int, List<BaseWord>> map = new Dictionary<int, List<BaseWord>>();
        words.ForEach(word => {
            int order = word.GetHintOrder();
            if (priority.Contains(order))
            {
                int insertIndex = new System.Random().Next(map[order].Count);
                map[order].Insert(insertIndex, word);
            }
            else
            {
                priority.Add(order);
                List<BaseWord> subList = new List<BaseWord>() { word };
                map.Add(order, subList);
            }
        });
        if (priority.Count > 1)
            priority.Sort((x, y) => -x.CompareTo(y));
        List<BaseWord> sortList = new List<BaseWord>();
        priority.ForEach(order => {
            sortList.AddRange(map[order]);
        });
        return sortList;
    }

    /// <summary>
    /// 获取每个词飞出字母概率库ID
    /// </summary>
    /// <param name="wordIndex">词的索引</param>
    /// <returns>概率库ID</returns>
    protected virtual int GetWordFlyProbabilityID(int wordIndex)
    {
        return 1;
    }
    
    /// <summary>
    /// 获取每个词飞出字母概率库ID
    /// </summary>
    /// <param name="wordIndex">词的索引</param>
    /// <returns>概率库ID</returns>
    protected virtual int GetWordFlyOutProbabilityID(int wordIndex)
    {
        return 1;
    }

    public void ShowAnswer()
    {
        if (curWord != null)
        {
            curWord.PointAllAnswer();
        }
    }

    public Vector3 GetCenterPosition()
    {
        return scrollRect.transform.position;
    }
    // protected virtual void DoPositiveReaction(List<BaseWord> words) { }
    // protected virtual void PositiveReaction()
    // {
    //     
    // } 

    protected BaseCell GetCell(int wordIndex, int cellColIndex)
    {
        return wordList[wordIndex].Cells.Find(c => c.ColIndex == cellColIndex);
    }

    private int rowCountInView = 0;
    private int aroundRowOffset = 0;
    protected void InitCrossWordCell()
    {
        int wordCount = wordList.Count;
        if (wordCount <= 1)
            return;
        rowCountInView = (int) (viewPortHeight / (cellSize + lineSpace) + 0.3f);
        aroundRowOffset = (rowCountInView - 1) / 2;
        LoggerHelper.Error("row in view " + rowCountInView + "  offset=" + aroundRowOffset);
        var matchWordList = FindAllSameLetterCells();
        OptimizeMatch(matchWordList);
    }

    private List<FlyCrossWord> FindAllSameLetterCells()
    {
        //按字母划分所有格子
        Dictionary<char, List<BaseCell>> letterCellsDic = new Dictionary<char, List<BaseCell>>();
        foreach (var cell in allCells)
        {
            if (cell.State == CellState.none)
                continue;
            char letter = cell.AnswerLetter;
            if (letterCellsDic.ContainsKey(letter))
            {
                letterCellsDic[letter].Add(cell);
            }
            else
            {
                letterCellsDic.Add(letter, new List<BaseCell>(){cell});
            }
        }

        //找到所有不同词之间有交叉的所有格子
        Dictionary<char, List<BaseCell>> matchCells = new Dictionary<char, List<BaseCell>>();
        List<FlyCrossWord> matchWordList = new List<FlyCrossWord>();
        foreach (var pair in letterCellsDic)
        {
            int cellCount = pair.Value.Count;
            if (cellCount > 1)
            {
                var cell = pair.Value[0];
                if (pair.Value.Find(c => !c.IsInSameWord(cell)) != null)
                {
                    matchCells.Add(pair.Key, pair.Value);
                    foreach (var mCell in pair.Value)
                    {
                        var word = mCell.ParentWord;
                        
                        var mWord = matchWordList.Find(mw => mw.word == word);
                        if (mWord == null)
                        {
                            matchWordList.Add(new FlyCrossWord(){word = word, cells = new List<BaseCell>(){mCell}});
                        }
                        else
                        {
                            int curCount = mWord.cells.FindAll(c => c.AnswerLetter == mCell.AnswerLetter).Count;
                            int outSideCount = pair.Value.FindAll(c => c.ParentWord != word).Count;
                            if (curCount < outSideCount)
                                mWord.cells.Add(mCell);
                        }
                    }
                }
            }
        }
        
        //按交叉数量升序排列
        matchWordList.Sort((x, y) =>
        {
            return x.cells.Count.CompareTo(y.cells.Count);
        });

        foreach (var matchWord in matchWordList)
        {
            int cellsCount = matchWord.cells.Count;
            matchWord.flyOutCount = AppEngine.SSystemManager.GetSystem<ProbabilitySystem>().GetProbability(
                GetWordFlyOutProbabilityID(matchWord.word.Index).ToString());
            if (matchWord.flyOutCount > cellsCount)
                matchWord.flyOutCount = cellsCount;
            matchWord.flyInCount = matchWord.word.MaxBeFlyToCount;
            if (matchWord.flyInCount > cellsCount)
                matchWord.flyInCount = cellsCount;
            
            matchWord.matchCells = new Dictionary<BaseCell, List<FlyCrossCell>>();
            foreach (var flyOutCell in matchWord.cells)
            {
                matchWord.matchCells[flyOutCell] = new List<FlyCrossCell>();
                var allSameLetterCells = matchCells[flyOutCell.AnswerLetter];
                foreach (var otherCell in allSameLetterCells)
                {
                    if (otherCell.ParentWord == flyOutCell.ParentWord)
                        continue;
                    var word = matchWordList.Find(mw => mw.word == otherCell.ParentWord);
                    matchWord.matchCells[flyOutCell].Add(new FlyCrossCell(otherCell, word));
                }
            }
            
            LoggerHelper.Error($"Word {matchWord.word.Index} {matchWord.word.Answer} flyOut={matchWord.flyOutCount} maxHint={matchWord.flyInCount}");
        }

        return matchWordList;
    }

    class FlyCrossWord
    {
        public BaseWord word;
        public int flyOutCount = 0;
        public int flyInCount = 0;
        public List<BaseCell> cells;
        public Dictionary<BaseCell, List<FlyCrossCell>> matchCells;
        
        // public Dictionary<BaseCell, List<CrossLink>> flyInCellLinks;
        // public Dictionary<BaseCell, List<CrossLink>> flyOutCellLinks;
        public List<FlyCrossLink> flyInCellLinks = new List<FlyCrossLink>();
        public List<FlyCrossLink> flyOutCellLinks = new List<FlyCrossLink>();

        private List<BaseCell> flyOutCells = new List<BaseCell>();
        private List<BaseCell> flyInCells = new List<BaseCell>();

        public void OnCellFlyIn(FlyCrossCell cell)
        {
            if (!flyInCells.Contains(cell.cell))
            {
                flyInCells.Add(cell.cell);
                flyInCount--;
                flyInCellLinks.ForEach(link =>
                {
                    if (link.toCell.cell == cell.cell)
                        link.toCell.isUsed = true;
                    link.UpdateValid();
                });
                flyInCellLinks.ForEach(link =>
                {
                    link.RefreshWeight();
                });
            }
        }

        public void OnCellFlyOut(FlyCrossCell cell)
        {
            flyOutCells.Add(cell.cell);
            flyOutCount--;
            flyOutCellLinks.ForEach(link =>
            {
                if (link.fromCell.cell == cell.cell)
                    link.fromCell.isFlyOut = true;
                link.UpdateValid();
            });
            flyOutCellLinks.ForEach(link =>
            {
                link.RefreshWeight();
            });
        }

        public int FlyOutMatchCount()
        {
            int count = 0;
            List<BaseCell> _cells = new List<BaseCell>();
            flyOutCellLinks.ForEach(flyOutLink =>
            {
                if (_cells.Find(c => c != flyOutLink.fromCell.cell && c.AnswerLetter == flyOutLink.fromCell.cell.AnswerLetter) != null)
                    return;
                if (flyOutLink.weight != 0 && !flyOutLink.fromCell.isFlyOut && !flyOutLink.toCell.isUsed &&
                    flyOutLink.isNear)
                {
                    count++;
                    if (!_cells.Contains(flyOutLink.fromCell.cell))
                        _cells.Add(flyOutLink.fromCell.cell);
                }
            });
            return count;
        }
        
        public int FlyInMatchCount()
        {
            int count = 0;
            flyInCellLinks.ForEach(flyInLink =>
            {
                if (flyInLink.weight != 0 && !flyInLink.fromCell.isFlyOut && !flyInLink.toCell.isUsed && flyInLink.isNear)
                    count++;
            });
            return count;
        }

        public List<BaseCell> FindSameLetterFlyToCells(BaseCell cell)
        {
            List<BaseCell> list = new List<BaseCell>();
            flyOutCellLinks.ForEach(link =>
            {
                if (link.fromCell.cell != cell && link.fromCell.cell.AnswerLetter == cell.AnswerLetter && link.fromCell.cell.FlyToCell != null)
                {
                    list.Add(link.fromCell.cell.FlyToCell);
                }
            });
            return list;
        }
    }

    class FlyCrossCell
    {
        public BaseCell cell;
        public FlyCrossWord parentWord;
        public bool isUsed = false;
        public bool isFlyOut = false;

        public FlyCrossCell(BaseCell cell, FlyCrossWord parentWord)
        {
            this.cell = cell;
            this.parentWord = parentWord;
        }
    }

    private bool IsAroundWord(int curWordIndex, int otherWordIndex)
    {
        int wordCount = wordList.Count;
        int minIndex, maxIndex;
        minIndex = curWordIndex - aroundRowOffset;
        maxIndex = curWordIndex + aroundRowOffset;
        if (minIndex < 0)
        {
            minIndex = 0;
            maxIndex = minIndex + rowCountInView - 1;
        }

        if (maxIndex >= wordCount)
        {
            maxIndex = wordCount - 1;
            minIndex = maxIndex - rowCountInView + 1;
            if (minIndex < 0)
                minIndex = 0;
        }

        return otherWordIndex >= minIndex && otherWordIndex <= maxIndex;
    }

    
    protected virtual IEnumerator CellFlyOut(List<BaseWord> words)
    {
        wordList.ForEach(w => w.ResetAutoHintFillCacheCells());
        Dictionary<BaseCell, BaseCell> cellFromTo = new Dictionary<BaseCell, BaseCell>();
        foreach (BaseWord word in words)
        {
            foreach (var cell in word.Cells)
            {
                if (cell.FlyToCell != null && cell.FlyToCell.State != CellState.filled && !cellFromTo.ContainsKey(cell))
                    cellFromTo[cell] = cell.FlyToCell;
            }
        }

        if (cellFromTo.Count > 0)
        {
            bool completed = false;
            float upTime = 0.5f, flyTime = 1f, downTime = 0.15f, hintTime = 0.2f;

            List<BaseCell> flyCells = new List<BaseCell>();
            foreach (var pair in cellFromTo)
            {
                var flyCell = pair.Key.Clone();
                flyCell._CanvasGroup.blocksRaycasts = false;
                flyCell.FlyToCell = pair.Value;
                flyCells.Add(flyCell);
            }
            
            var seq = DOTween.Sequence();
            float timePos = 0.05f;
            seq.InsertCallback(timePos, () => flyCells.ForEach(flyCell =>
            {
                flyCell.cellAnimator.SetTrigger("flyup");
                flyCell.ShowTrailEffect();
            }));
            seq.InsertCallback(timePos += upTime, () =>
            {
                flyCells.ForEach(flyCell =>
                {
                    flyCell.transform.DOMove(flyCell.FlyToCell.transform.position, flyTime)
                        .SetEase(Ease.OutCubic);
                });
            });
            seq.InsertCallback(timePos += flyTime, () =>
            {
                flyCells.ForEach(flyCell => flyCell.cellAnimator.SetTrigger("flydown"));
            });
            seq.InsertCallback(timePos += downTime, () =>
            {
                flyCells.ForEach(flyCell =>
                {
                    flyCell.FlyToCell.AutoHintFill();
                    flyCell.FlyToCell.SetBeFlyToFlag(false);
                });
                AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_AutoHintFill);
            });
            seq.InsertCallback(timePos += hintTime, () =>
            {
                flyCells.ForEach(flyCell =>
                {
                    Destroy(flyCell.gameObject);
                    flyCell.FlyToCell.AutoHintFillCheckAnswer();
                });
                completed = true;
            });
            while (!completed)
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }

    class FlyCrossLink
    {
        public FlyCrossCell fromCell;
        public FlyCrossCell toCell;
        public int weight = -1;
        public bool isNear;
        public int toWordPriority;
        //public int fromWordChoiceCount;

        public void UseLink()
        {
            LoggerHelper.Error("use link " + weight + 
                               $"from {fromCell.cell.ParentWord.Index} {fromCell.cell.ColIndex} {fromCell.cell.AnswerLetter} " +
                               $"to {toCell.cell.ParentWord.Index} {toCell.cell.ColIndex} {toCell.cell.AnswerLetter} " +
                               $"isNear={isNear} flyOut={fromCell.isFlyOut} flyIn={toCell.isUsed}");
            fromCell.cell.FlyToCell = toCell.cell;
            fromCell.isFlyOut = true;
            toCell.isUsed = true;
            fromCell.parentWord.OnCellFlyOut(fromCell);
            toCell.parentWord.OnCellFlyIn(toCell);
        }

        public void UpdateValid()
        {
            if (weight == 0)
                return;
            if (fromCell.isFlyOut || fromCell.parentWord.flyOutCount <= 0)
            {
                weight = 0;
                return;
            }
            if (!toCell.isUsed && toCell.parentWord.flyInCount <= 0)
            {
                weight = 0;
                return;
            }

            if (fromCell.parentWord.FindSameLetterFlyToCells(fromCell.cell).Contains(toCell.cell))
            {
                weight = 0;
                return;
            }
        }

        public void RefreshWeight()
        {
            if (weight == 0)
                return;
            weight = 0;
            if (!toCell.isUsed)
                weight += 1000000;
            if (isNear)
                weight += 100000;
            weight += (toWordPriority * 1000);
            int w = 500 - (fromCell.parentWord.FlyOutMatchCount() - fromCell.parentWord.flyOutCount) 
                        - (toCell.parentWord.FlyInMatchCount() - toCell.parentWord.flyInCount);
            weight += w;
        }
    }
    private void OptimizeMatch(List<FlyCrossWord> matchWordList)
    {
        matchWordList.Sort((x, y) =>
        {
            int result = -x.word.GetHintOrder().CompareTo(y.word.GetHintOrder());
            if (result != 0)
                return result;
            return x.cells.Count.CompareTo(y.cells.Count);
        });

        int allFlyOut = 0, allFlyIn = 0;
        List<FlyCrossLink> allCellWeights = new List<FlyCrossLink>();
        foreach (var matchWord in matchWordList)
        {
            allFlyOut += matchWord.flyOutCount;
            allFlyIn += matchWord.flyInCount;
            foreach (var crossCell in matchWord.cells)
            {
                var matchCells = matchWord.matchCells[crossCell];
                foreach (var matchCell in matchCells)
                {
                    var data = new FlyCrossLink(){fromCell = matchCell, toCell = new FlyCrossCell(crossCell, matchWord)};
                    var word = matchCell.cell.ParentWord;
                    var otherMatchWord = matchCell.parentWord;
                    data.isNear = IsAroundWord(word.Index, matchWord.word.Index);
                    data.toWordPriority = matchWord.word.GetHintOrder();
                    //data.weight += (100 - (otherMatchWord.crossCellCount - otherMatchWord.flyOutCount)) * 10;
                    
                    matchWord.flyInCellLinks.Add(data);
                    allCellWeights.Add(data);
                    otherMatchWord.flyOutCellLinks.Add(data);
                }
            }
        }

        foreach (var cellWeight in allCellWeights)
        {
            cellWeight.RefreshWeight();
        }

        int flyCount = allFlyOut > allFlyIn ? allFlyIn : allFlyOut;
        for (int i = 0; i < flyCount; i++)
        {
            allCellWeights.Sort((x, y) => -x.weight.CompareTo(y.weight));
            if (allCellWeights[0].weight == 0)
                break;
            allCellWeights[0].UseLink();
        }
    }
}
