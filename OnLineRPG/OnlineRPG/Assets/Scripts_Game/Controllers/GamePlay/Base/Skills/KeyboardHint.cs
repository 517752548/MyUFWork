using BetaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyboardHint : BaseDragHint
{
    public GameObject mask;
    private BaseWord hintWord;
    private bool reverseVoice = false;
    /// <summary>
    /// 初始化道具状态
    /// </summary>
    public override void Init(BaseSkillManager skillManager, PropertyAB_Data config)
    {
        hintWord = null;
        base.Init(skillManager, config);
        AppEngine.SyncManager.Data.Hint2Unlock.Value |= unlocked;
        OnDataGot(AppEngine.SyncManager.Data.Hint2.Value, AppEngine.SyncManager.Data.Hint2Unlock.Value);
        AppEngine.SyncManager.Data.Hint2.DataUpdateEvent += OnHintChanged;
        AppEngine.SyncManager.Data.Hint2Unlock.DataUpdateEvent += OnHintChanged;
    }

    private void OnHintChanged()
    {
        OnDataChanged(true, AppEngine.SyncManager.Data.Hint2.Value, 
            AppEngine.SyncManager.Data.Hint2Unlock.Value);
    }

    private void OnDestroy()
    {
        AppEngine.SyncManager.Data.Hint2.DataUpdateEvent -= OnHintChanged;
        AppEngine.SyncManager.Data.Hint2Unlock.DataUpdateEvent -= OnHintChanged;
    }

    public override string GetHintTitle()
    {
        return "Erase";
    }

    public override string GetReportName()
    {
        return "Hint2";
    }
    
    protected override void OnHintWork()
    {
        base.OnHintWork();
        skillManager.CellManager.HintUse(false, true, false, false);
    }

    protected override void OnUseHint()
    {
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_hint2);
        if (hintWord != null)
        {
            skillManager.GameManager.GetEntity<BaseKeyBoard>().ShowMask(false);
            skillManager.GameManager.GetEntity<BaseKeyBoard>().UseHint2(hintWord);
            hintWord.HintSel(false);
            hintWord.IsKeyboardHintUsed = true;
            
            hintWord.Select();
            hintWord.Refresh();
            hintWord.CellManager.CacheLevelProgress();
        }

        TimersManager.SetTimer(3.5f, () => {
            OnHintWorkEnd();
        });

    }
    

	protected override void OnCancelHint()
    {
        if (reverseVoice)
            skillManager.GameManager.GetEntity<ClassicVoiceKeyboard>().gameObject.SetActive(true);
        if (hintWord != null)
        {
            hintWord.HintSel(false);
        }
        hintWord = null;
        OnHintEnd();
    }

    protected override void ReduceHintCount()
    {
        AppEngine.SyncManager.Data.Hint2.Value -= 1;
    }

    public override void OnClick()
    {
        //Debug.LogError("oncllick");
		base.OnClick();
    }

    public override void OnChooseTargetClick(PointerEventData eventData)
    {
        //Debug.LogError("OnChooseTargetClick");
        hintWord = null;
        if (IsPointerInCellsRect(eventData))
            hintWord = skillManager.CellManager.HintSelectWord(GetWorldPos2(eventData), true);
        if (hintWord != null && hintWord.IsKeyboardHintUsed)
        {
            hintWord.HintSel(false);
            hintWord = null;
        }
        base.OnChooseTargetClick(eventData);
        if (hintWord != null)
        {
            UseHint();
            //Debug.LogError("usehint1");
        }
        else
        {
            OnCancelHint();
            //Debug.LogError("cancelhint1");
        }
    }

    protected override void OnHintDragStart(PointerEventData eventData)
    {
        hintWord = null;
        base.OnHintDragStart(eventData);
    }

    protected override void OnHintDrag(PointerEventData eventData)
    {
        skillManager.CellManager.HintSelectWord(GetWorldPos2(eventData), true);
        base.OnHintDrag(eventData);
    }

    protected override void OnHintDragEnd(PointerEventData eventData)
    {
        hintWord = null;
        if (IsPointerInCellsRect(eventData))
            hintWord = skillManager.CellManager.HintSelectWord(GetWorldPos2(eventData), true);
        else
            skillManager.CellManager.ClearHintSelectWord();
        if (hintWord != null && hintWord.IsKeyboardHintUsed)
        {
            hintWord.HintSel(false);
            hintWord = null;
        }
        base.OnHintDragEnd(eventData);
        if (hintWord != null)
        {
            UseHint();
            //Debug.LogError("usehint");
        }
        else
        {
            OnCancelHint();
            //Debug.LogError("cancelhint");
        }
    }
    
    protected override void OnHintStart()
    {
        base.OnHintStart();
        skillManager.CellManager.Words.ForEach(word => word.ChangeStateOnKeyboardHintReady(true));
        reverseVoice = skillManager.GameManager.GetEntity<ClassicVoiceKeyboard>().gameObject.activeSelf;
        skillManager.GameManager.GetEntity<ClassicVoiceKeyboard>().gameObject.SetActive(false);
    }

    protected override void OnHintEnd()
    {
        skillManager.CellManager.Words.ForEach(word => word.ChangeStateOnKeyboardHintReady(false));
        base.OnHintEnd();
    }
}