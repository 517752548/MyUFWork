using BetaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpecificWordHint : BaseDragHint
{
    private BaseWord hintWord;
    /// <summary>
    /// 初始化道具状态
    /// </summary>
    public override void Init(BaseSkillManager skillManager, PropertyAB_Data config)
    {
        hintWord = null;
        base.Init(skillManager, config);
        AppEngine.SyncManager.Data.Hint4Unlock.Value |= unlocked;
        OnDataGot(AppEngine.SyncManager.Data.Hint4.Value, AppEngine.SyncManager.Data.Hint4Unlock.Value);
        AppEngine.SyncManager.Data.Hint4.DataUpdateEvent += OnHintChanged;
        AppEngine.SyncManager.Data.Hint4Unlock.DataUpdateEvent += OnHintChanged;
    }

    private void OnHintChanged()
    {
        OnDataChanged(true, AppEngine.SyncManager.Data.Hint4.Value, 
            AppEngine.SyncManager.Data.Hint4Unlock.Value);
    }

    private void OnDestroy()
    {
        AppEngine.SyncManager.Data.Hint4.DataUpdateEvent -= OnHintChanged;
        AppEngine.SyncManager.Data.Hint4Unlock.DataUpdateEvent -= OnHintChanged;
    }

    public override string GetHintTitle()
    {
        return "Solve";
    }

    public override string GetReportName()
    {
        return "Hint4";
    }
    
    protected override void OnHintWork()
    {
        base.OnHintWork();
        skillManager.CellManager.HintUse(false, false, false, true);
    }

    protected override void OnUseHint()
    {
        if (hintWord != null)
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.ogg_hint4);
            hintWord.HintComplete(()=> {
                hintWord = null;
                OnHintWorkEnd();
            });
            hintWord.HintSel(false);
        }
    }

    protected override void OnCancelHint()
    {
        if (hintWord != null)
        {
            hintWord.HintSel(false);
        }
        hintWord = null;
        OnHintEnd();
    }

    protected override void ReduceHintCount()
    {
        AppEngine.SyncManager.Data.Hint4.Value -= 1;
    }

    public override void OnClick()
    {
        base.OnClick();
    }

    public override void OnChooseTargetClick(PointerEventData eventData)
    {
        hintWord = null;
        if (IsPointerInCellsRect(eventData))
            hintWord = skillManager.CellManager.HintSelectWord(GetWorldPos2(eventData));
        base.OnChooseTargetClick(eventData);
        if (hintWord != null)
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
        hintWord = null;
        base.OnHintDragStart(eventData);
    }

    protected override void OnHintDrag(PointerEventData eventData)
    {
        skillManager.CellManager.HintSelectWord(GetWorldPos2(eventData));
        base.OnHintDrag(eventData);
    }

    protected override void OnHintDragEnd(PointerEventData eventData)
    {
        hintWord = null;
        if (IsPointerInCellsRect(eventData))
            hintWord = skillManager.CellManager.HintSelectWord(GetWorldPos2(eventData));
        else
            skillManager.CellManager.ClearHintSelectWord();
        base.OnHintDragEnd(eventData);
        if (hintWord != null)
        {
            UseHint();
        }
        else
        {
            OnCancelHint();
        }
    }
}