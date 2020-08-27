using System;
using BetaFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyCellManager : BaseCellManager
{
    private DailyGameManager _GameManager
    {
        get { return m_baseGameManager as DailyGameManager; }
    }

    private List<DailyQuestionEntity> level;

    public override void Init()
    {
        base.Init();
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

    /// <summary>
    /// 初始化所有格子
    /// </summary>
    protected override void InitCells()
    {
        level = _GameManager.GetLevel();
        if (level == null || level.Count == 0)
            return;

        AdjustRect();

        int rowCount = level.Count;
        for (int row = 0; row < rowCount; row++)
        {
            DailyQuestionEntity answer = level[row];
            answer.Answer = answer.Answer.ToUpper();
            int beginColIndex = 0;
            int endColIndex = beginColIndex + answer.Answer.Length - 1;
            BaseWord word = new BaseNormalWord(this, answer);
            word.Index = row;
            for (int col = 0; col < rowCellCount; col++)
            {
                DailyCell cell = AppEngine.SObjectPoolManager.Spawn(GetCellResName()).GetComponent<DailyCell>();

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
                allCells.Add(cell);
            }

            wordList.Add(word);
        }
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

    protected override string GetCellResName()
    {
        return ViewConst.prefab_DailyCell;
    }
    
    protected override void OnWordCompleted(List<BaseWord> words)
    {
        base.OnWordCompleted(words);
        _GameManager.GameTempData.DailyAnswerRight(words,CompletedWordsCount.ToString(),ReportData.Hint1,ReportData.Hint2,ReportData.Hint3,ReportData.Hint4);
    }
    
    public override void OnWordWrong(BaseWord word,string wrongword)
    {
        if (word is BaseNormalWord)
        {
            base.OnWordWrong(word,wrongword);
            GameManager.GameTempData.DailyAnswerWrong(word,wrongword, ReportData.Hint1, ReportData.Hint2, ReportData.Hint3, ReportData.Hint4);
        }
    }

    protected override int GetRowCount()
    {
        return level.Count;
    }

    protected override int GetRowCellCount()
    {
        int count = base.GetRowCellCount();
        foreach (BaseQuestionEntity answer in level)
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
        return level[wordIndex].ProbabilityID;
    }
    
    protected override int GetWordFlyOutProbabilityID(int wordIndex)
    {
        return level[wordIndex].ProbabilityID;
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

            if (_GameManager.ProgressData.levelData.ContainsKey(wordList[i].Answer))
            {
                wordList[i].HintCount = _GameManager.ProgressData.wordHints[wordList[i].Answer];
            }

            if (_GameManager.ProgressData.wordUseHint2.ContainsKey(wordList[i].Answer))
            {
                wordList[i].IsKeyboardHintUsed = _GameManager.ProgressData.wordUseHint2[wordList[i].Answer];
            }

            wordList[i].Refresh();
            
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

        //CheckGame();
    }

    public override void CacheLevelProgress()
    {
        if (_GameManager != null && _GameManager.ProgressData != null && wordList != null)
        {
            _GameManager.ProgressData.CacheMemary(wordList);
        }
    }
}