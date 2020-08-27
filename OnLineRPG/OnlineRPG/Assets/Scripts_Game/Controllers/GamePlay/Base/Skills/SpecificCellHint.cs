using BetaFramework;
using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpecificCellHint : BaseDragHint
{
    private BaseCell hintCell;
    /// <summary>
    /// 初始化道具状态
    /// </summary>
    public override void Init(BaseSkillManager skillManager, PropertyAB_Data config)
    {
        hintCell = null;
        base.Init(skillManager, config);
        AppEngine.SyncManager.Data.Hint1Unlock.Value |= unlocked;
        OnDataGot(AppEngine.SyncManager.Data.Hint1.Value, AppEngine.SyncManager.Data.Hint1Unlock.Value);
        AppEngine.SyncManager.Data.Hint1.DataUpdateEvent += OnHintChanged;
        AppEngine.SyncManager.Data.Hint1Unlock.DataUpdateEvent += OnHintChanged;
    }

    private void OnHintChanged()
    {
        OnDataChanged(true, AppEngine.SyncManager.Data.Hint1.Value, 
            AppEngine.SyncManager.Data.Hint1Unlock.Value);
    }

    private void OnDestroy()
    {
        AppEngine.SyncManager.Data.Hint1.DataUpdateEvent -= OnHintChanged;
        AppEngine.SyncManager.Data.Hint1Unlock.DataUpdateEvent -= OnHintChanged;
    }

    public override string GetHintTitle()
    {
        return "Reveal";
    }

    public override string GetReportName()
    {
        return "Hint1";
    }
    
    protected override void OnHintWork()
    {
        base.OnHintWork();
        skillManager.CellManager.HintUse(true, false, false, false);
    }

    protected override void OnUseHint()
    {
        if (hintCell != null)
        {
            hintCell.ParentWord.Select();
            hintCell.HintSel(false);
            hintCell.PlayHint1Ani();
            Sequence seq = DOTween.Sequence();
            seq.AppendInterval(0.4f);
            seq.AppendCallback(() => {
                AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_hint1);
                hintCell.SetFilled();
                hintCell.CheckAnswer();
                hintCell.FocusToNextCell(true);
                hintCell.CellManager.CacheLevelProgress();
                hintCell = null;
                OnHintWorkEnd();
            });
        }
        else
            OnHintWorkEnd();
    }

    protected override void OnCancelHint()
    {
        if (hintCell != null)
        {
            hintCell.HintSel(false);
        }
        hintCell = null;
        OnHintEnd();
    }

    protected override void ReduceHintCount()
    {
        AppEngine.SyncManager.Data.Hint1.Value -= 1;
    }

    public override void OnClick()
    {
        base.OnClick();
    }

    public override void OnChooseTargetClick(PointerEventData eventData)
    {
        hintCell = null;
        if (IsPointerInCellsRect(eventData))
            hintCell = skillManager.CellManager.HintSelectCell(GetWorldPos2(eventData));
        base.OnChooseTargetClick(eventData);
        if (hintCell != null)
        {
            UseHint();
        }
        else
        {
            OnCancelHint();
        }
    }

    protected override void OnHintDragStart(PointerEventData eventData)
    {
        hintCell = null;
        base.OnHintDragStart(eventData);
    }

    protected override void OnHintDrag(PointerEventData eventData)
    {
        skillManager.CellManager.HintSelectCell(GetWorldPos2(eventData));
        base.OnHintDrag(eventData);
    }

    protected override void OnHintDragEnd(PointerEventData eventData)
    {
        hintCell = null;
        if (IsPointerInCellsRect(eventData))
            hintCell = skillManager.CellManager.HintSelectCell(GetWorldPos2(eventData));
        else
            skillManager.CellManager.ClearHintSelectCell();
        base.OnHintDragEnd(eventData);
        if (hintCell != null)
        {
            UseHint();
        }
        else
        {
            OnCancelHint();
        }
    }
}