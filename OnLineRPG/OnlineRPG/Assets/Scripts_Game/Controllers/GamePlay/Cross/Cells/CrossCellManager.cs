using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using Scripts_Game.Managers;
using UnityEngine;

namespace Scripts_Game.Controllers.GamePlay.Cross
{
    public class CrossCellManager : BaseCellManager
    {
        [SerializeField] private BeeCountBar _beeCountBar;
        [SerializeField] private GameObject beePrefab;

        public bool CurSelHorizontalWord { get; private set; }

        private CrossGameManager _GameManager => m_baseGameManager as CrossGameManager;

        private CrossLevelEntity level;
        private CrossCell[,] cellArray;
        private bool display = false;

        public override void Init()
        {
            base.Init();
            ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_BeeFly,
                (go) => { beePrefab = go; });
            if (_GameManager.ProgressData.Value.flyMap.Count == 0)
            {
                InitFlyCellMatch();
                for (int row = 0; row < level.SizeRow; row++)
                {
                    _GameManager.ProgressData.Value.flyMap[row] = new Dictionary<int, KeyValuePair<int, int>>();
                    for (int col = 0; col < rowCellCount; col++)
                    {
                        CrossCell cell = cellArray[row, col];
                        if (cell.FlyToCell != null)
                        {
                            var toCell = cell.FlyToCell as CrossCell;
                            _GameManager.ProgressData.Value.flyMap[row][col] = 
                                new KeyValuePair<int, int>(toCell.PosRow, toCell.PosCol);
                        }
                    }
                }
            }
        }

        protected override int GetRowCellCount()
        {
            return level.SizeCol;
        }

        protected override int GetRowCount()
        {
            return level.SizeRow;
        }

        protected override void AdjustRect()
        {
            //base.AdjustRect();
            rowCellCount = GetRowCellCount();
            lineSpace = 0;
            scrollViewport = (RectTransform) scrollContent.parent;
            scrollRect = scrollViewport.parent.gameObject.GetComponent<CellsScrollRect>();
            cellSize = scrollContent.rect.width / rowCellCount;
            gridLayout.cellSize = new Vector2(cellSize, cellSize);
            focusWordFlag.Init(cellSize);
            contentHeight = scrollContent.rect.height;
            viewPortHeight = scrollViewport.rect.height;
            maxDeltaY = contentHeight - viewPortHeight;
            if (maxDeltaY < 0) maxDeltaY = 0;
            targetPosY = viewPortHeight / 2;
            effectScale = cellSize / 114.4f;
            float space = 0;
            switch (level.SizeRow)
            {
                case 4:
                    space = 8;
                    break;
                case 5:
                    space = 5;
                    break;
                case 6:
                    space = 5;
                    break;
                case 7:
                    space = 4;
                    break;
                case 8:
                    space = 4;
                    break;
                case 9:
                    space = 3;
                    break;
            }

            //gridLayout.spacing = new Vector2(space, space);
        }

        protected override void InitCells()
        {
            level = _GameManager.GetLevel();
            if (level == null)
                return;

            AdjustRect();

            int rowCount = GetRowCount();
            cellArray = new CrossCell[rowCount, rowCellCount];
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < rowCellCount; col++)
                {
                    CrossCell cell = AppEngine.SObjectPoolManager.Spawn(GetCellResName()).GetComponent<CrossCell>();
                    cell.Init(this, null, col, cellSize);
                    cell.PosRow = row;
                    cell.PosCol = col;
                    cell.transform.SetParent(gridLayout.transform, false);
                    cell.gameObject.SetActive(true);

                    cellArray[row, col] = cell;
                }
            }

            int questionsCount = level.Questions.Count;
            for (int quesIndex = 0; quesIndex < questionsCount; quesIndex++)
            {
                CrossQuestionEntity answer = level.Questions[quesIndex];
                answer.Answer = answer.Answer.ToUpper();
                CrossNormalWord word = new CrossNormalWord(this, answer);
                word.Index = quesIndex;
                int cellCount = word.Answer.Length;
                int startRow = answer.Row, startCol = answer.Col;
                for (int i = 0; i < cellCount; i++)
                {
                    CrossCell cell = answer.Horizontal
                        ? cellArray[startRow, startCol + i]
                        : cellArray[startRow + i, startCol];

                    if (cell.State == CellState.none)
                    {
                        cell.InitLetter(word.Answer.Substring(i, 1));
                        allCells.Add(cell);
                    }

                    word.AddCell(cell);
                }

                wordList.Add(word);
            }
        }

        public int CellCount => allCells.Count;

        private CrossCell GetCellByPos(int row, int col)
        {
            return cellArray[row, col];
        }

        public override void SetCurWord(BaseWord word)
        {
            base.SetCurWord(word);
            if (word != null && word is CrossNormalWord _word)
                CurSelHorizontalWord = _word.IsHorizontal;
        }

        protected override string GetCellResName()
        {
            return ViewConst.prefab_CrossCell;
        }

        protected override void RecoveryLastProgress()
        {
            base.RecoveryLastProgress();
            for (int i = 0; i < wordList.Count; i++)
            {
                if (_GameManager.ProgressData.Value.levelData.ContainsKey(wordList[i].Answer))
                {
                    wordList[i].StateInfo = _GameManager.ProgressData.Value.levelData[wordList[i].Answer];
                }

                if (_GameManager.ProgressData.Value.levelData.ContainsKey(wordList[i].Answer))
                {
                    wordList[i].HintCount = _GameManager.ProgressData.Value.wordHints[wordList[i].Answer];
                }

                if (_GameManager.ProgressData.Value.wordUseHint2.ContainsKey(wordList[i].Answer))
                {
                    wordList[i].IsKeyboardHintUsed = _GameManager.ProgressData.Value.wordUseHint2[wordList[i].Answer];
                }

                wordList[i].Refresh();
            }

            if (NewFlyCell() && _GameManager.ProgressData.Value.flyMap.Count > 0)
            {
                for (int row = 0; row < level.SizeRow; row++)
                {
                    var wordCellFlyDic = _GameManager.ProgressData.Value.flyMap[row];
                    for (int col = 0; col < rowCellCount; col++)
                    {
                        CrossCell cell = cellArray[row, col];
                        if (wordCellFlyDic.ContainsKey(col))
                        {
                            var pair = wordCellFlyDic[col];
                            cell.FlyToCell = GetCellByPos(pair.Key, pair.Value);
                        }
                    }
                }
            }

            //CheckGame();
        }

        public override void CacheLevelProgress()
        {
            if (_GameManager != null && _GameManager.ProgressData.Value != null && wordList != null && !display)
            {
                _GameManager.ProgressData.Value.CacheMemary(wordList);
            }
        }

        protected override int GetWordFlyProbabilityID(int wordIndex)
        {
            var progress = CompletedWordsCount / (float) Words.Count;
            if (progress < 0.34f)
                return 0;
            if (progress < 0.67f)
                return 1;
            return 2;
        }

        protected override int GetWordFlyOutProbabilityID(int wordIndex)
        {
            return level.ProbabilityID;
        }

        protected override void OnWordCompleted(List<BaseWord> words)
        {
            _GameManager.GameTempData.CrossAnswerRight(words, CompletedWordsCount.ToString(), ReportData.Hint1,
                ReportData.Hint2, ReportData.Hint3, ReportData.Hint4);
            words.ForEach(word =>
            {
                GameManager.GetEntity<CrossQuestionDisplay>().OnCompleteOneWord(word);
                if (word is CrossNormalWord normalWord)
                {
                    if (normalWord.BeeRewardCoin > 0)
                    {
                        RewardMgr.RewardInventory(InventoryType.Coin, normalWord.BeeRewardCoin, RewardSource.BeeCoin);
                    }
                }
            });
            base.OnWordCompleted(words);
        }

        public override void OnWordWrong(BaseWord word, string wrongword)
        {
            if (word is CrossNormalWord)
            {
                base.OnWordWrong(word, wrongword);
                GameManager.GameTempData.CrossAnswerWrong(word, wrongword, ReportData.Hint1, ReportData.Hint2,
                    ReportData.Hint3, ReportData.Hint4);
            }
        }

        public override void OnCompleteOneWord(BaseWord word, bool playAni = true, Action overCallback = null)
        {
            //base.OnCompleteOneWord(word, playAni, overCallback);
        }

        public void OnlyDisplay()
        {
            display = true;
            _GameManager.ProgressData.Value = new CrossLevelProgressData();
            allCells.ForEach(cell =>
            {
                cell.SetFilled();
                //cell.SetWordCompleted(null);
            });
            wordList.ForEach(word => (word as CrossNormalWord)?.SetComplete());
            focusWordFlag.gameObject.SetActive(true);
            wordList[0].SetSelect(true);
        }

        public override void OnClickChangeWord(bool next)
        {
            base.OnClickChangeWord(next);
            if (display)
            {
                int index = wordList.IndexOf(curWord);
                if (next)
                {
                    index++;
                    if (index >= wordList.Count)
                        index = 0;
                }
                else
                {
                    index--;
                    if (index < 0)
                        index = wordList.Count - 1;
                }
                wordList[index].Select();
            }
        }

        public void UseBee(Action callback)
        {
            //return;
            var words = GetNotCompleteWord();
            words = words.FindAll(w => !w.CellsState.Contains("1"));
            int count = words.Count;
            int maxCount = _GameManager.GetBeeMaxCount() - _GameManager.ProgressData.Value.BeeUsedCount;
            if (count > maxCount)
                count = maxCount;
            if (count > AppEngine.SyncManager.Data.Bee.Value)
                count = AppEngine.SyncManager.Data.Bee.Value;
            AppEngine.SyncManager.Data.Bee.Value -= count;
            _GameManager.ProgressData.Value.BeeUsedCount += count;
            int coin = AppEngine.SyncManager.Data.Coin.Value;
            int hint1 = AppEngine.SyncManager.Data.Hint1.Value;
            int hint2 = AppEngine.SyncManager.Data.Hint2.Value;
            int Hint3 = AppEngine.SyncManager.Data.Hint3.Value;
            int Hint4 = AppEngine.SyncManager.Data.Hint4.Value;
            int hint5 = AppEngine.SyncManager.Data.Bee.Value;
            GameAnalyze.LogitemConsume(GameManager.GetLevelSeq(), DataManager.ProcessData._GameMode.ToString(), "NULL",
                coin.ToString(), hint1.ToString(), hint2.ToString(), Hint3.ToString(), Hint4.ToString(),
                "0", "0",
                "hint", "hint5", "0", count.ToString(), hint5.ToString(),
                AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserRewardLib(),
                AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetABReportStr());
            //确定要飞蜜蜂的词
            List<BaseWord> beeFlyWords = new List<BaseWord>();
            if (count == words.Count)
            {
                beeFlyWords.AddRange(words);
            }
            else
            {
                beeFlyWords = CommUtil.RandomFromList(words, count);
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

            GameManager.GameTempData.hint5num = count;
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
                            bee.DOLocalMoveX(-200, 0.3f).OnComplete(() =>
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
                    }).SetDelay(delay).SetEase(Ease.OutCubic)
                    .OnStart(() => AppEngine.SSoundManager.PlaySFX(ViewConst.wav_beeAppear));
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
                    .OnComplete(() => { BeeUpDown(!down); });
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
                        (cell as CrossCell).SetBeeCoin(true);
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

        protected override bool NewFlyCell()
        {
            return true;
        }

        private void InitFlyCellMatch()
        {
            Dictionary<char, List<CrossCell>> letterCellsDic = new Dictionary<char, List<CrossCell>>();
            foreach (var cell in allCells)
            {
                if (cell.State == CellState.none)
                    continue;
                char letter = cell.AnswerLetter;
                if (letterCellsDic.ContainsKey(letter))
                {
                    letterCellsDic[letter].Add(cell as CrossCell);
                }
                else
                {
                    letterCellsDic.Add(letter, new List<CrossCell>() {cell as CrossCell});
                }
            }

            List<TheFlyCrossWord> matchWordList = new List<TheFlyCrossWord>();
            Dictionary<char, List<TheFlyCrossCell>> letterFlyCellsDic = new Dictionary<char, List<TheFlyCrossCell>>();
            foreach (var pair in letterCellsDic)
            {
                int cellCount = pair.Value.Count;
                if (cellCount > 1)
                {
                    var cell = pair.Value[0];
                    if (pair.Value.Find(c => !c.IsInSameWord(cell)) != null)
                    {
                        letterFlyCellsDic[pair.Key] = new List<TheFlyCrossCell>();
                        foreach (var mCell in pair.Value)
                        {
                            var toCells = pair.Value.FindAll(c => c != mCell && !c.IsInSameWord(mCell));
                            AddFlyMatchWordCell(ref matchWordList, mCell, mCell.HWord, toCells);
                            AddFlyMatchWordCell(ref matchWordList, mCell, mCell.VWord, toCells);
                        }
                    }
                }
            }

            Dictionary<BaseCell, TheFlyCrossCell> cellDic = new Dictionary<BaseCell, TheFlyCrossCell>();
            foreach (var pair in letterFlyCellsDic)
            {
                var list = letterCellsDic[pair.Key];
                foreach (var cell in list)
                {
                    var h_word = cell.HWord == null
                        ? null
                        : matchWordList.Find(mw => mw.word == cell.HWord);
                    var v_word = cell.VWord == null
                        ? null
                        : matchWordList.Find(mw => mw.word == cell.VWord);
                    var flyCell = new TheFlyCrossCell(cell, h_word, v_word);
                    pair.Value.Add(flyCell);
                    cellDic[cell] = flyCell;
                }
            }

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

                matchWord.matchCells = new Dictionary<BaseCell, List<TheFlyCrossCell>>();
                foreach (var flyOutCell in matchWord.cells)
                {
                    matchWord.matchCells[flyOutCell] = new List<TheFlyCrossCell>();
                    var allSameLetterCells = letterFlyCellsDic[flyOutCell.AnswerLetter];
                    foreach (var otherCell in allSameLetterCells)
                    {
                        if (otherCell.cell.IsInSameWord(flyOutCell))
                            continue;
                        matchWord.matchCells[flyOutCell].Add(otherCell);
                    }
                }

                LoggerHelper.Error(
                    $"Word {matchWord.word.Index} {matchWord.word.Answer} " +
                    $"flyOut={matchWord.flyOutCount} maxHint={matchWord.flyInCount}");
            }


            int allFlyOut = 0, allFlyIn = 0;
            List<TheFlyCrossLink> allCellWeights = new List<TheFlyCrossLink>();
            foreach (var flyToWord in matchWordList)
            {
                allFlyOut += flyToWord.flyOutCount;
                allFlyIn += flyToWord.flyInCount;
                foreach (var flyToCell in flyToWord.cells)
                {
                    var matchCells = flyToWord.matchCells[flyToCell];
                    foreach (var flyFromCell in matchCells)
                    {
                        var data = new TheFlyCrossLink()
                        {
                            fromCell = flyFromCell, toCell = cellDic[flyToCell],
                            toWordPriority = flyToWord.word.GetHintOrder()
                        };

                        flyToWord.flyInCellLinks.Add(data);
                        flyFromCell.HWord?.flyOutCellLinks.Add(data);
                        flyFromCell.VWord?.flyOutCellLinks.Add(data);
                        allCellWeights.Add(data);
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

        private void AddFlyMatchWordCell(ref List<TheFlyCrossWord> matchWordList, CrossCell cell, CrossNormalWord word,
            List<CrossCell> toCells)
        {
            if (word == null)
                return;
            var mWord = matchWordList.Find(mw => mw.word == word);
            if (mWord == null)
            {
                matchWordList.Add(new TheFlyCrossWord() {word = word, cells = new List<BaseCell>() {cell}});
            }
            else
            {
                int curCount = mWord.cells.FindAll(c => c.AnswerLetter == cell.AnswerLetter).Count;
                int outSideCount = toCells.Count;
                if (curCount < outSideCount)
                    mWord.cells.Add(cell);
            }
        }

        class TheFlyCrossWord
        {
            public BaseWord word;
            public int flyOutCount = 0;
            public int flyInCount = 0;
            public List<BaseCell> cells;
            public List<TheFlyCrossCell> flyCells;
            public Dictionary<BaseCell, List<TheFlyCrossCell>> matchCells;

            public List<TheFlyCrossLink> flyInCellLinks = new List<TheFlyCrossLink>();
            public List<TheFlyCrossLink> flyOutCellLinks = new List<TheFlyCrossLink>();

            private List<BaseCell> flyOutCells = new List<BaseCell>();
            private List<BaseCell> flyInCells = new List<BaseCell>();

            public void OnCellFlyIn(TheFlyCrossCell cell)
            {
                if (!flyInCells.Contains(cell.cell))
                {
                    flyInCells.Add(cell.cell);
                    flyInCount--;
                    flyInCellLinks.ForEach(link =>
                    {
                        link.UpdateValid();
                        link.RefreshWeight();
                    });
                }
            }

            public void OnCellFlyOut(TheFlyCrossCell cell)
            {
                flyOutCells.Add(cell.cell);
                flyOutCount--;
                flyOutCellLinks.ForEach(link =>
                {
                    link.UpdateValid();
                    link.RefreshWeight();
                });
            }

            public int FlyOutMatchCount()
            {
                int count = 0;
                List<BaseCell> _cells = new List<BaseCell>();
                flyOutCellLinks.ForEach(flyOutLink =>
                {
                    if (_cells.Find(c =>
                            c != flyOutLink.fromCell.cell && c.AnswerLetter == flyOutLink.fromCell.cell.AnswerLetter) !=
                        null)
                        return;
                    if (flyOutLink.weight != 0 && !flyOutLink.fromCell.isFlyOut && !flyOutLink.toCell.isUsed)
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
                    if (flyInLink.weight != 0 && !flyInLink.fromCell.isFlyOut && !flyInLink.toCell.isUsed)
                        count++;
                });
                return count;
            }

            public List<BaseCell> FindSameLetterFlyToCells(BaseCell cell)
            {
                List<BaseCell> list = new List<BaseCell>();
                flyOutCellLinks.ForEach(link =>
                {
                    if (link.fromCell.cell != cell && link.fromCell.cell.AnswerLetter == cell.AnswerLetter &&
                        link.fromCell.cell.FlyToCell != null)
                    {
                        list.Add(link.fromCell.cell.FlyToCell);
                    }
                });
                return list;
            }
        }

        class TheFlyCrossCell
        {
            public TheFlyCrossWord HWord;
            public TheFlyCrossWord VWord;
            public CrossCell cell;
            public bool isUsed = false;
            public bool isFlyOut = false;

            public TheFlyCrossCell(CrossCell cell, TheFlyCrossWord hWord, TheFlyCrossWord vWord)
            {
                this.cell = cell;
                HWord = hWord;
                VWord = vWord;
            }
        }

        class TheFlyCrossLink
        {
            public TheFlyCrossCell fromCell;
            public TheFlyCrossCell toCell;
            public int weight = -1;

            public int toWordPriority;

            public void UseLink()
            {
                LoggerHelper.Error("use link " + weight +
                                   $"from {fromCell.cell.PosRow} {fromCell.cell.PosCol} {fromCell.cell.AnswerLetter} " +
                                   $"to {toCell.cell.PosRow} {toCell.cell.PosCol} {toCell.cell.AnswerLetter} " +
                                   $"flyOut={fromCell.isFlyOut} flyIn={toCell.isUsed}");
                fromCell.cell.FlyToCell = toCell.cell;
                fromCell.isFlyOut = true;
                toCell.isUsed = true;
                fromCell.HWord?.OnCellFlyOut(fromCell);
                fromCell.VWord?.OnCellFlyOut(fromCell);
                toCell.HWord?.OnCellFlyIn(toCell);
                toCell.VWord?.OnCellFlyIn(toCell);
            }

            public void UpdateValid()
            {
                if (weight == 0)
                    return;
                if (fromCell.isFlyOut || (fromCell.HWord != null && fromCell.HWord.flyOutCount <= 0) || (fromCell.VWord != null && fromCell.VWord.flyOutCount <= 0))
                {
                    weight = 0;
                    return;
                }

                if (!toCell.isUsed && ((toCell.HWord != null && toCell.HWord.flyInCount <= 0) || (toCell.VWord != null && toCell.VWord.flyInCount <= 0)))
                {
                    weight = 0;
                    return;
                }

                if (fromCell.HWord != null && fromCell.HWord.FindSameLetterFlyToCells(fromCell.cell).Contains(toCell.cell))
                {
                    weight = 0;
                    return;
                }
                
                if (fromCell.VWord != null && fromCell.VWord.FindSameLetterFlyToCells(fromCell.cell).Contains(toCell.cell))
                {
                    weight = 0;
                    return;
                }

                if (toCell.cell.FlyToCell == fromCell.cell)
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
                weight += (toWordPriority * 10000);
                int hFlyOutMore = fromCell.HWord == null
                    ? 100
                    : (fromCell.HWord.FlyOutMatchCount() - fromCell.HWord.flyOutCount);
                int vFlyOutMore = fromCell.VWord == null
                    ? 100
                    : (fromCell.VWord.FlyOutMatchCount() - fromCell.VWord.flyOutCount);
                int hFlyInMore = toCell.HWord == null
                    ? 100
                    : (toCell.HWord.FlyInMatchCount() - toCell.HWord.flyInCount);
                int vFlyInMore = toCell.VWord == null
                    ? 100
                    : (toCell.VWord.FlyInMatchCount() - toCell.VWord.flyInCount);
                int flyOutMore = hFlyOutMore <= vFlyOutMore ? hFlyOutMore : vFlyOutMore;
                int flyInMore = hFlyInMore <= vFlyInMore ? hFlyInMore : vFlyInMore;
                weight += (500 - flyInMore - flyOutMore);
            }
        }

        protected override IEnumerator CellFlyOut(List<BaseWord> words)
        {
            wordList.ForEach(w => w.ResetAutoHintFillCacheCells());
            Dictionary<BaseCell, BaseCell> cellFromTo = new Dictionary<BaseCell, BaseCell>();
            foreach (BaseWord word in words)
            {
                foreach (var cell in word.Cells)
                {
                    if (cell.FlyToCell != null && cell.FlyToCell.State != CellState.filled &&
                        !cellFromTo.ContainsKey(cell))
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
                seq.InsertCallback(timePos += flyTime,
                    () => { flyCells.ForEach(flyCell => flyCell.cellAnimator.SetTrigger("flydown")); });
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
                    flyCells.ForEach(flyCell => { Destroy(flyCell.gameObject); });
                    completed = true;
                });
                while (!completed)
                {
                    yield return new WaitForEndOfFrame();
                }

                CheckMultiWord();
            }
        }
    }
}