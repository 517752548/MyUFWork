using UnityEngine;
using System.Collections;
using BetaFramework;
using System.Text;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Scripts_Game.Managers;
using Random = UnityEngine.Random;


public class ClassicCellManager : BaseCellManager
{
    [SerializeField] private BeeCountBar _beeCountBar;
    [SerializeField] private GameObject beePrefab;
    private ClassicGameManager _GameManager => m_baseGameManager as ClassicGameManager;

    private ClassicLevelEntity level;
    private float originalContentHight;
    private ClassicThemeWord themeWord;

    private RateReward_Data rateRewardConfig;

    public ClassicThemeWord ThemeWord => themeWord;

    public override void Init()
    {
        base.Init();
        scrollRect.OnEndDrag(OnScrollEndDrag);
        AppEngine.SResourceManager.LoadAssetAsync<GameObject>(ViewConst.prefab_BeeFly, 
            (go) => { beePrefab = go; });
        rateRewardConfig = PreLoadManager.GetPreLoadConfig<RateReward>(ViewConst.asset_RateReward_rate).dataList[0];
        
        if (NewFlyCell() && _GameManager.ProgressData.flyMap.Count == 0)
        {
            InitCrossWordCell();
            foreach (var word in wordList)
            {
                _GameManager.ProgressData.flyMap[word.Index] = new Dictionary<int, KeyValuePair<int, int>>();
                foreach (var cell in word.Cells)
                {
                    if (cell.FlyToCell != null)
                    {
                        _GameManager.ProgressData.flyMap[word.Index][cell.ColIndex] = 
                            new KeyValuePair<int, int>(cell.FlyToCell.ParentWord.Index, cell.FlyToCell.ColIndex);
                    }
                }
            }
        }
    }


    private void OnScrollEndDrag()
    {
        GameManager.GetEntity<ClassicQuestionDisplay>().ClosePicBox();
    }

    /// <summary>
    /// 初始化所有格子
    /// </summary>
    protected override void InitCells()
    {
        level = _GameManager.GetLevel();
        if (level == null)
            return;

        AdjustRect();
        originalContentHight = contentHeight;

        int rowCount = level.Questions.Count;
        themeWord = level._SolutionCard == null ? null : new ClassicThemeWord(this, level.SolutionWord, null);
        for (int row = 0; row < rowCount; row++)
        {
            ClassicQuestionEntity answer = level.Questions[row];
            answer.Answer = answer.Answer.ToUpper();
            int beginColIndex = 0;
            int endColIndex = beginColIndex + answer.Answer.Length - 1;
            int solutionWordIndex = beginColIndex + answer.SolutionWordIndex;
            BaseWord word = new ClassicNormalWord(this, answer);
            word.Index = row;
            for (int col = 0; col < rowCellCount; col++)
            {
                ClassicCell cell = AppEngine.SObjectPoolManager.Spawn(GetCellResName()).GetComponent<ClassicCell>();

                if (col >= beginColIndex && col <= endColIndex)
                {
                    cell.Init(this, answer.Answer.Substring(col - beginColIndex, 1), col, cellSize);
                }
                else
                {
                    cell.Init(this, null, col, cellSize);
                }

                cell.transform.SetParent(gridLayout.transform, false);
                cell.gameObject.SetActive(true);

                word.AddCell(cell);
                if (col == solutionWordIndex)
                    themeWord?.AddCell(cell);
                allCells.Add(cell);
            }

            wordList.Add(word);
        }


        // 找到最长词，和图片词的位置
        // List<int> LWordPos = new List<int>();
        // int LWordLength = 0;
        // List<int> PWordPos = new List<int>();
        // for (int row = 0; row < rowCount; row++)
        // {
        //     ClassicQuestionEntity answer = level.Questions[row];
        //     if (string.IsNullOrEmpty(answer.CardID))
        //     {
        //         if (answer.Answer.Length > LWordLength)
        //         {
        //             LWordPos.Clear();
        //             LWordLength = answer.Answer.Length;
        //             LWordPos.Add(row);
        //         }
        //         else if (answer.Answer.Length == LWordLength)
        //         {
        //             LWordPos.Add(row);
        //         }
        //     }
        //     else
        //     {
        //         PWordPos.Add(row);
        //     }
        // }
        //
        // // 给最终位置赋值
        // GameManager.GameTempData.PRWords.Add(level.Questions[XUtils.RandomOneFromList(ref LWordPos)].Answer);
        // int PWordPRNum = UnityEngine.Random.Range(1, 100) > 75 ? 1 : 2;
        // for (int i = 0; i < PWordPRNum; i++)
        // {
        //     if (PWordPos.Count == 0) break;
        //     int pos = XUtils.RandomOneFromList(ref PWordPos);
        //     GameManager.GameTempData.PRWords.Add(level.Questions[pos].Answer);
        //     PWordPos.Remove(pos);
    }


    public override void SetCurCell(BaseCell cell)
    {
        if (CurCell != null && cell != null && CurCell.ParentWord != cell.ParentWord
            && ((ClassicCell) CurCell).IsInPictureWord && !((ClassicCell) cell).IsInPictureWord)
            ChangeScrollRect(0);
        base.SetCurCell(cell);
    }

    protected override string GetCellResName()
    {
        return ViewConst.prefab_ClassicCell;
    }

    protected override int GetRowCount()
    {
        int count = 0;
        level.Questions.ForEach(ques =>
        {
            if (!string.IsNullOrEmpty(ques.Answer))
                count++;
        });
        return count;
    }

    protected override int GetRowCellCount()
    {
        int count = base.GetRowCellCount();
        foreach (BaseQuestionEntity answer in level.Questions)
        {
            int len = answer.Answer.Length;
            if (len > count)
                count = len;
        }

        return count;
    }

    protected override int GetWordFlyProbabilityID(int wordIndex)
    {
        var progress = CompletedWordsCount / (float) Words.Count;
        if (progress < 0.34f)
            return 0;
        if (progress < 0.67f)
            return 1;
        return 2;
        return level.ProbabilityID;
    }

    protected override int GetWordFlyOutProbabilityID(int wordIndex)
    {
        return level.ProbabilityID;
    }

    protected override void RecoveryLastProgress()
    {
        base.RecoveryLastProgress();
        for (int i = 0; i < wordList.Count; i++)
        {
            if (_GameManager.ProgressData.levelData.ContainsKey(wordList[i].Answer))
            {
                wordList[i].StateInfo = _GameManager.ProgressData.levelData[wordList[i].Answer];
            }

            if (_GameManager.ProgressData.wordHints.ContainsKey(wordList[i].Answer))
            {
                wordList[i].HintCount = _GameManager.ProgressData.wordHints[wordList[i].Answer];
            }

            if (_GameManager.ProgressData.wordUseHint2.ContainsKey(wordList[i].Answer))
            {
                wordList[i].IsKeyboardHintUsed = _GameManager.ProgressData.wordUseHint2[wordList[i].Answer];
            }

            if (_GameManager.ProgressData.cellsState.ContainsKey(wordList[i].Answer))
            {
                wordList[i].CellsState = _GameManager.ProgressData.cellsState[wordList[i].Answer];
            }

            wordList[i].Refresh();
            if (wordList[i].Index == _GameManager.ProgressData.RateRewardWordIndex)
            {
                (wordList[i] as ClassicNormalWord)?.ShowRateRewardCoin();
            }

            if (NewFlyCell() &&
                _GameManager.ProgressData.flyMap.ContainsKey(wordList[i].Index))
            {
                var wordCellFlyDic = _GameManager.ProgressData.flyMap[wordList[i].Index];
                wordList[i].ValidCells.ForEach(cell =>
                {
                    if (wordCellFlyDic.ContainsKey(cell.ColIndex))
                    {
                        var pair = wordCellFlyDic[cell.ColIndex];
                        cell.FlyToCell = GetCell(pair.Key, pair.Value);
                    } 
                });
            }
        }

        themeWord?.CheckComplete();
        if (_GameManager.ProgressData.RateRewardWordSeq < 0)
        {
            _GameManager.ProgressData.RateRewardWordSeq = Random.Range(0, wordList.Count - 2);
        }

        LoggerHelper.Log("反馈奖励词次序 " + (_GameManager.ProgressData.RateRewardWordSeq + 1));
        //CheckGame();
    }

    public override void CacheLevelProgress()
    {
        if (_GameManager.ProgressData != null)
            _GameManager.ProgressData.CacheMemary(wordList);
    }

    public void ChangeScrollRect(float delta)
    {
        ChangeScrollRectData(delta);
        MoveCellCenter(curWord.Cells[0]);
    }

    private void ChangeScrollRectData(float delta)
    {
        if (delta > 0)
            //targetPosY = (cellSize + lineSpace) / 2 + lineSpace;
            targetPosY = (viewPortHeight - delta) / 2;
        else
            targetPosY = viewPortHeight / 2;
        contentHeight = originalContentHight + delta;
        maxDeltaY = contentHeight - viewPortHeight;
        if (maxDeltaY < 0) maxDeltaY = 0;
        scrollContent.sizeDelta = new Vector2(scrollContent.sizeDelta.x, contentHeight);
    }

    protected override void AdjustRect()
    {
        base.AdjustRect();
        float paddingTop = (viewPortHeight - contentHeight) / 2;
        if (paddingTop > 0)
        {
            gridLayout.padding.top = (int) paddingTop;
            gridTop = Math.Abs(gridLayout.GetComponent<RectTransform>().offsetMax.y) + gridLayout.padding.top;
            var gridBottom = Math.Abs(gridLayout.GetComponent<RectTransform>().offsetMax.y) + gridLayout.padding.bottom;
            contentHeight = (cellSize + lineSpace) * GetRowCount() + gridTop + gridBottom + 20;
            maxDeltaY = contentHeight - viewPortHeight;
            if (maxDeltaY < 0) maxDeltaY = 0;
            scrollContent.sizeDelta = new Vector2(scrollContent.sizeDelta.x, contentHeight);
        }
    }

    protected override void OnWordCompleted(List<BaseWord> words)
    {
        words.ForEach(word => (word.Cells[0] as ClassicCell).HidePicWordFlag());
        _GameManager.GameTempData.ClassicAnswerRight(words, CompletedWordsCount.ToString(), ReportData.Hint1,
            ReportData.Hint2, ReportData.Hint3, ReportData.Hint4);
        base.OnWordCompleted(words);
    }


    protected override IEnumerator OnAnswerAniOver(List<BaseWord> words)
    {
        yield return base.OnAnswerAniOver(words);
        int levelIndex = AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value;
// #if UNITY_EDITOR
//         if (true)
//         {
//             int seq1 = CompletedWordsCount - 1;
//             for (int i = words.Count - 1; i >= 0; i--)
//             {
//                     try
//                     {
//                         _GameManager.ProgressData.RateRewardWordIndex = words[i].Index;
//                         (words[i] as ClassicNormalWord)?.ShowRateRewardCoin();
//                     }
//                     catch (Exception e)
//                     {
//                     }
//                     //DataManager.ProcessData.CanShowRateRewardWord = words[i];
//                     yield return new WaitForSeconds(0.5f);
//                     try
//                     {
//                         if (!AppEngine.SyncManager.Data.GuideRateReward.Value)
//                         {
//                             GameManager.GameAnimationStart();
//                             var sequence = DOTween.Sequence();
//                             sequence.InsertCallback(0.5f, () => { MoveCellCenter(words[i].Cells[0]); });
//                             sequence.InsertCallback(0.85f, () => ShowRateRewardGuide(words[i]));
//                         }
//                     }
//                     catch (Exception e)
//                     {
//                     }
//                     break;
//             }
//         }
//         yield break;
// #endif
        if (rateRewardConfig == null)
            yield break;
        if (levelIndex < rateRewardConfig.StartLevel || levelIndex >= rateRewardConfig.EndLevel)
            yield break;
        int seq = CompletedWordsCount - 1;
        if (_GameManager == null)
        {
            yield break;
        }
        if (_GameManager.ProgressData == null)
        {
            yield break;
        }
        if (_GameManager.ProgressData.RateRewardWordIndex < 0 && seq >= _GameManager.ProgressData.RateRewardWordSeq)
        {
            for (int i = words.Count - 1; i >= 0; i--)
            {
                if ((seq - i) == _GameManager.ProgressData.RateRewardWordSeq)
                {
                    try
                    {
                        _GameManager.ProgressData.RateRewardWordIndex = words[i].Index;
                        (words[i] as ClassicNormalWord)?.ShowRateRewardCoin();
                    }
                    catch (Exception e)
                    {
                    }
                    //DataManager.ProcessData.CanShowRateRewardWord = words[i];
                    yield return new WaitForSeconds(0.5f);
                    try
                    {
                        if (!AppEngine.SyncManager.Data.GuideRateReward.Value)
                        {
                            GameManager.GameAnimationStart();
                            var sequence = DOTween.Sequence();
                            sequence.InsertCallback(0.5f, () => { MoveCellCenter(words[i].Cells[0]); });
                            sequence.InsertCallback(0.85f, () => ShowRateRewardGuide(words[i]));
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    break;
                }
            }
        }
    }

    private void ShowRateRewardGuide(BaseWord word)
    {
        DataManager.ProcessData.CanShowRateRewardWord = word;
        GameManager.GameAnimationEnd();
        //_GameManager.StateMachine.Next();
    }

    public override void OnWordWrong(BaseWord word, string wrongword)
    {
        if (word is ClassicNormalWord)
        {
            base.OnWordWrong(word, wrongword);
            GameManager.GameTempData.ClassicAnswerWrong(word, wrongword, ReportData.Hint1, ReportData.Hint2,
                ReportData.Hint3, ReportData.Hint4);
        }
    }

    public void OnCompleteThemeWord(ClassicThemeWord word)
    {
        //if (curWord == word)
        //    FocusOneNotFilledWord();
        StartCoroutine(ThemeWordCompleteProcess(word));
    }

    public override void OnCompleteOneWord(BaseWord word, bool playAni = true, Action overCallback = null)
    {
        GameManager.StateMachine.TriggerEvent(BaseFSMManager.Event_GuideClose_First);
        //ChangeScrollRect(0);
        //GameManager.GetEntity<ClassicQuestionDisplay>().ClosePicBox();
        GameManager.GetEntity<ClassicQuestionDisplay>().OnCompleteOneWord(word);
        if (word is ClassicNormalWord normalWord)
        {
            if (normalWord.BeeRewardCoin > 0)
            {
                RewardMgr.RewardInventory(InventoryType.Coin, normalWord.BeeRewardCoin, RewardSource.BeeCoin);
            }
        }
        base.OnCompleteOneWord(word, playAni, overCallback);
    }

    public override void DisAppear()
    {
        base.DisAppear();
        ChangeScrollRectData(0);
        StartCoroutine(DisappearAnim(Words.Count * 0.3f));
    }

    IEnumerator DisappearAnim(float totalTime)
    {
        scrollRect.inertia = false;
        float toTopTime = 0.15f;
        ScrollContentLocalMoveY(0, toTopTime);
        yield return new WaitForSeconds(toTopTime + 0.05f);
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_win_fall);

        float moveTime = totalTime - toTopTime - 0.05f;
        float perWordTime = moveTime / wordList.Count;
        ScrollContentLocalMoveY(maxDeltaY, moveTime);
        for (int i = 0; i < wordList.Count; i++)
        {
            wordList[i].DisAppear();
            yield return new WaitForSeconds(perWordTime);
        }
    }

    private IEnumerator ThemeWordCompleteProcess(ClassicThemeWord word)
    {
        ClassicCell cell;
        for (int i = 0; i < word.Cells.Count; i++)
        {
            cell = word.Cells[i] as ClassicCell;
            if (cell.State != CellState.none)
            {
                cell.PlayCorrectThemeAni();
                yield return new WaitForSeconds(0.1f);
            }
        }

        if (curWord == word)
        {
            FocusOneNotFilledWord();
        }

        yield break;
    }
    // 多于1个必定播放，
    // protected override void DoPositiveReaction(List<BaseWord> words)
    // {
    //     if (words.Count < 1)
    //         return;
    //     if (words.Count > 1)
    //     {
    //         PositiveReaction();
    //         return;
    //     }
    //     if (GameManager.GameTempData.PRWords.Contains(words[0].Answer))
    //     {
    //         PositiveReaction();
    //     }
    // }
    // protected override void PositiveReaction()
    // {
    //     GameManager.GetEntity<BasePet>().PRPlay();
    // }
    //
    // public override void DisplayWrongLightFrame(BaseWord word)
    // {
    //     if (word is ClassicThemeWord)
    //     {
    //         (word as ClassicThemeWord).PartCells.ForEach(part =>
    //         {
    //             var box = AppEngine.SObjectPoolManager.Spawn(ViewConst.prefab_Image_Wrong, 
    //                 prefabWrongLightFrame.transform, Vector3.zero, default(Quaternion), scrollContent);
    //             box.localScale = Vector3.one;
    //             box.GetComponent<LightFrameBox>().Show(cellSize, lineSpace, part[0].transform.position, part.Count);
    //         });
    //         focusWordFlag.SetActive(false);
    //         return;
    //     }
    //     base.DisplayWrongLightFrame(word);
    // }

    public void UseBee(Action callback)
    {
        //return;
        CommConfig_Data config = PreLoadManager.GetPreLoadConfig<CommConfig>(ViewConst.asset_CommConfig_config)
            ?.dataList[0];
        LoggerHelper.Log("小蜜蜂的数量-:" + config.BeeUseMax);
        var words = GetNotCompleteWord();
        words = words.FindAll(w => !w.CellsState.Contains("1"));
        int count = words.Count;
        int maxCount = config.BeeUseMax - _GameManager.ProgressData.BeeUsedCount;
        if (count > maxCount)
            count = maxCount;
        if (count > AppEngine.SyncManager.Data.Bee.Value)
            count = AppEngine.SyncManager.Data.Bee.Value;
        AppEngine.SyncManager.Data.Bee.Value -= count;
        _GameManager.ProgressData.BeeUsedCount += count;
        int coin = AppEngine.SyncManager.Data.Coin.Value;
        int hint1 = AppEngine.SyncManager.Data.Hint1.Value;
        int hint2 = AppEngine.SyncManager.Data.Hint2.Value;
        int Hint3 = AppEngine.SyncManager.Data.Hint3.Value;
        int Hint4 = AppEngine.SyncManager.Data.Hint4.Value;
        int hint5 = AppEngine.SyncManager.Data.Bee.Value;
        //确定要飞蜜蜂的词
        List<BaseWord> beeFlyWords = new List<BaseWord>();
        if (count == words.Count)
        {
            beeFlyWords.AddRange(words);
        }
        else
        {
            int topWordIndex = -1;
            List<BaseWord> toChooseWords = new List<BaseWord>();
            words.ForEach(word =>
            {
                if (topWordIndex < 0)
                {
                    topWordIndex = word.Index;
                    toChooseWords.Add(word);
                }
                else if (word.Index - topWordIndex < 6 || toChooseWords.Count < count)
                {
                    toChooseWords.Add(word);
                }
            });
            beeFlyWords = CommUtil.RandomFromList(toChooseWords, count);
        }

        //开始飞蜜蜂流程
        _beeCountBar.SlideInOut(count, () =>
        {
            Vector3 beeStartPos = _beeCountBar.beeImg.transform.position;
            int completeTaskCount = 0;
            float delay = 0f;
            beeFlyWords.ForEach(word =>
            {
                Transform bee =
                    AppEngine.SObjectPoolManager.Spawn(ViewConst.prefab_BeeFly, beePrefab.transform, beeStartPos);
                bee.SetParent(scrollContent);
                bee.localScale = Vector3.one * effectScale * (RowCellCount > 9 ? 0.58f : 0.50f);
                bee.position = beeStartPos;
                new BeeFlyTask(word, bee, () =>
                {
                    completeTaskCount++;
                    if (completeTaskCount == count)
                    {
                        //蜜蜂飞结束后保存当前状态存档
                        CacheLevelProgress();
                        GameManager.SaveLocal();
                        callback?.Invoke();
                    }
                }).Run(delay);
                delay += 0.2f;
            });
        });
        //todo fly bee

        GameManager.GameTempData.hint5num = count;
        ReportBee(count);
    }

    private void ReportBee(int hintcount)
    {
        float progress = (float) CompletedWordsCount / Words.Count;
        int coin = AppEngine.SyncManager.Data.Coin.Value;
        int hint1 = AppEngine.SyncManager.Data.Hint1.Value;
        int hint2 = AppEngine.SyncManager.Data.Hint2.Value;
        int Hint3 = AppEngine.SyncManager.Data.Hint3.Value;
        int Hint4 = AppEngine.SyncManager.Data.Hint4.Value;
        int hint5 = AppEngine.SyncManager.Data.Bee.Value;
        string SpendType = "hint";
        // GameAnalyze.LogitemConsume(GameManager.GameTempData.levelID,DataManager.ProcessData._GameMode.ToString(),"NULL",
        //     coin.ToString(),hint1.ToString(),hint2.ToString(),Hint3.ToString(),Hint4.ToString(),hint5.ToString(), 
        //     progress.ToString(),WrongTimes.ToString(),
        //     SpendType, "hint5","0",hintcount.ToString(),
        //     AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib(),
        //     AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetABReportStr());
    }

    class BeeFlyTask
    {
        private readonly BaseWord word;
        private readonly Transform bee;
        private SequenceTask taskMgr;
        private readonly Action completeCallback;

        public BeeFlyTask(BaseWord word, Transform bee, Action completeCallback)
        {
            this.word = word;
            this.bee = bee;
            this.completeCallback = completeCallback;
        }

        public void Run(float delay)
        {
            var firstCell = word.FindFirstCanInputCell();
            var cells = word.ValidCells;

            Vector3 lastCellPos = cells[cells.Count - 1].transform.position;
            Vector3[] path = new[] {bee.position, lastCellPos};
            //bee.DOPath(path, 1f, PathType.CatmullRom).OnComplete(() =>
            bee.DOMove(lastCellPos, 1f).OnComplete(() =>
            {
                int flyCellCount = 0;
                taskMgr = new SequenceTask();
                float interval = -1f;
                for (int i = cells.Count - 1; i >= 0; i--)
                {
                    flyCellCount++;
                    if (cells[i] == firstCell)
                    {
                        taskMgr.InsertCallback(interval, new BeeFlyCellTask(cells[i], null, bee));
                        break;
                    }

                    taskMgr.InsertCallback(interval, new BeeFlyCellTask(cells[i], cells[i - 1], bee));
                    if (interval < 0)
                    {
                        interval = 0.15f;
                    }
                }

                bee.DOMove(firstCell.transform.position, interval * flyCellCount).OnComplete(() =>
                {
                    bee.GetComponentInChildren<Animator>().SetTrigger("hint");
                    AppEngine.SSoundManager.PlaySFX(ViewConst.wav_beeHint);
                    float hintAniLen = 0.9f;
                    bee.DOLocalMoveX(- 200, 0.3f).OnComplete(() =>
                        {
                            Destroy(bee.gameObject);
                            completeCallback?.Invoke();
                        }).SetDelay(hintAniLen)
                        .SetEase(Ease.Linear);
                    // //bee.Rotate(0, 180, 0);
                    // bee.DORotate(new Vector3(0, 180, 0), 0.1f).SetDelay(hintAniLen);
                    // //Vector3[] backPath = new[] {bee.localPosition, new Vector3(Screen.width + 200, bee.localPosition.y, bee.localPosition.z)};
                    // //bee.DOLocalPath(backPath, 1.5f, PathType.CatmullRom).OnComplete(() =>
                    // bee.DOLocalMoveX(Screen.width + 200, 1.5f).OnComplete(() =>
                    //     {
                    //         Destroy(bee.gameObject);
                    //         completeCallback?.Invoke();
                    //     }).SetDelay(0.1f + hintAniLen).OnStart(() => BeeUpDown(true))
                    //     .SetEase(Ease.InQuad);
                }).SetEase(Ease.Linear);
                taskMgr.InsertCallback(interval, new SequenceTaskActionCallback(OnFlyOver));
            }).SetDelay(delay).SetEase(Ease.OutCubic).OnStart(()=>AppEngine.SSoundManager.PlaySFX(ViewConst.wav_beeAppear));
        }

        private void OnFlyOver()
        {
            word.CheckAnswer(false);
            //completeCallback?.Invoke();
        }

        private int beeUpDownTimes = 0;
        private void BeeUpDown(bool down)
        {
            beeUpDownTimes++;
            if (beeUpDownTimes > 3)
                return;
            bee.DOLocalMoveY(bee.localPosition.y + (down ? -80 : 110), 0.5f).SetEase(Ease.Linear)
                .OnComplete(() => { BeeUpDown(!down);});
        }
    }

    class BeeFlyCellTask : ISequenceTaskCallback
    {
        private readonly BaseCell cell;
        private readonly BaseCell nextCell;
        private readonly Transform bee;

        public BeeFlyCellTask(BaseCell cell, BaseCell nextCell, Transform bee)
        {
            this.cell = cell;
            this.nextCell = nextCell;
            this.bee = bee;
        }

        public void Run()
        {
            if (nextCell != null)
            {
                if (cell.State != CellState.filled)
                    (cell as ClassicCell).SetBeeCoin(true);
                //bee.DOMove(nextCell.transform.position, 0.15f);
            }
            else
            {
                //TODO hint this
                DOTween.Sequence().InsertCallback(0.7f, () =>
                {
                    cell.SetFilled();
                    cell.PlayCorrectAni();
                });
                //cell.PlayCorrectAni();
                //Destroy(bee.gameObject);
            }
        }
    }
}