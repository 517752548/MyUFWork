using BetaFramework;
using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MultiCellsHint : BaseHint
{
    public GameObject flyEffect, boomEffect;
    private int maxHintCellCount = 6;
    /// <summary>
    /// 初始化道具状态
    /// </summary>
    public override void Init(BaseSkillManager skillManager, PropertyAB_Data config)
    {
        base.Init(skillManager, config);
        AppEngine.SyncManager.Data.Hint3Unlock.Value |= unlocked;
        OnDataGot(AppEngine.SyncManager.Data.Hint3.Value, AppEngine.SyncManager.Data.Hint3Unlock.Value);
        AppEngine.SyncManager.Data.Hint3.DataUpdateEvent += OnHintChanged;
        AppEngine.SyncManager.Data.Hint3Unlock.DataUpdateEvent += OnHintChanged;
    }

    private void OnHintChanged()
    {
        OnDataChanged(true, AppEngine.SyncManager.Data.Hint3.Value, 
            AppEngine.SyncManager.Data.Hint3Unlock.Value);
    }

    private void OnDestroy()
    {
        AppEngine.SyncManager.Data.Hint3.DataUpdateEvent -= OnHintChanged;
        AppEngine.SyncManager.Data.Hint3Unlock.DataUpdateEvent -= OnHintChanged;
    }

    public override string GetHintTitle()
    {
        return "Letter Storm";
    }

    public override string GetReportName()
    {
        return "Hint3";
    }
    
    protected override void OnHintWork()
    {
        base.OnHintWork();
        skillManager.CellManager.HintUse(false, false, true, false);
    }

    protected override void OnUseHint()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_hint3);
        //找到所有可以填充的格子，按词分组
        int hintCellCount = 0;
        List<List<BaseCell>> wordCells = new List<List<BaseCell>>();
        List<BaseWord> words = skillManager.CellManager.GetNotCompleteWord();
        words.ForEach(w => {
            List<BaseCell> cells = w.GetNotFillCells();
            if (cells.Count > 0)
            {
                wordCells.Add(cells);
                hintCellCount += cells.Count; 
            }
        });

        //从所有可以填充的格子中确定要被填充的格子
        List<BaseCell> hintCells = new List<BaseCell>();
        if (hintCellCount > maxHintCellCount)//如果格子总数多于hint的最大填充数，则随机选取
        {
            hintCellCount = maxHintCellCount;
            RandomSelWordCells(hintCells, wordCells, hintCellCount); //从wordCells随机选取hintCellCount个格子
        }
        else//所有格子都将被填充
        {
            wordCells.ForEach(cells => {
                hintCells.AddRange(cells);
            });
        }

        //完成填充
        StartCoroutine(CellsFlyProcess(hintCells));
    }

    private IEnumerator<object> CellsFlyProcess(List<BaseCell> hintCells)
    {
        Vector3 targetPos = skillManager.CellManager.GetCenterPosition();
        flyEffect.transform.position = transform.position;
        flyEffect.transform.localScale = Vector3.one;
        flyEffect.SetActive(true);
        flyEffect.transform.DOMove(targetPos, 0.5f).SetEase(Ease.InOutQuad);
        flyEffect.transform.DOScale(Vector3.one * 2, 0.5f);
        boomEffect.transform.position = targetPos;
        boomEffect.transform.localScale = Vector3.one * 2; 
        yield return new WaitForSeconds(1f);
        boomEffect.SetActive(true);
        flyEffect.SetActive(false);
        hintCells.ForEach(cell => { cell.PlayHint3Ani(targetPos, () => { }); });
        yield return new WaitForSeconds(0.5f);
        boomEffect.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        hintCells.ForEach(cell => { cell.SetFilled(); });
        skillManager.CellManager.CheckMultiWord();
        OnHintWorkEnd();
        yield break;
    }

    /// <summary>
    /// 随机选取格子，按词平均分布
    /// </summary>
    /// <param name="hintCells">被选中的格子，输出值</param>
    /// <param name="wordCells">所有待选取的格子</param>
    /// <param name="hintCellCount">选取的数量</param>
    private void RandomSelWordCells(List<BaseCell> hintCells, List<List<BaseCell>> wordCells, int hintCellCount)
    {
        if (hintCellCount < wordCells.Count)//提示数量少于未完成词数量，则在词中随机抽取，每个词提示一个
        {
            List<int> indexList = RandomIndexFromCount(wordCells.Count, hintCellCount);
            indexList.ForEach(index =>
            {
                List<BaseCell> cells = wordCells[index];
                BaseCell cell = XUtils.RandomOneFromList(ref cells);
                hintCells.Add(cell);
                hintCellCount--;
            });
        }
        else//提示数量多于未完成词数量，则先在每个词中随机抽取一个格子，在所有剩余中再进行下一次选取
        {
            //在每个词中随机抽取一个格子，并将选中的格子从wordCells中移除
            wordCells.ForEach(cells => {
                BaseCell cell = XUtils.RandomOneFromList(ref cells);
                hintCells.Add(cell);
                hintCellCount--;
            });
            //检查wordCells，删除已经没有可选格子的词
            for (int i = wordCells.Count-1; i>=0; i--)
            {
                if (wordCells[i].Count == 0)
                    wordCells.RemoveAt(i);
            }
            //如果还没够总的选取数量，则递归进行下一轮选取
            if (hintCellCount > 0)
                RandomSelWordCells(hintCells, wordCells, hintCellCount);
        }
    }

    /// <summary>
    /// 从总数中随机多个索引值
    /// </summary>
    /// <param name="count">总数</param>
    /// <param name="selCount">指定的随机数量</param>
    /// <returns>随机的多个索引值</returns>
    private List<int> RandomIndexFromCount(int count, int selCount)
    {
        List<int> list = new List<int>();
        for (int i = 0; i < count; i++)
            list.Add(i);
        return XUtils.RandomFromList(list, selCount);
    }

    protected override void OnCancelHint()
    {
        OnHintEnd();
    }

    protected override void ReduceHintCount()
    {
        AppEngine.SyncManager.Data.Hint3.Value -= 1;
    }

    public override void OnClick()
    {
        base.OnClick();
        UseHint();
    }
}