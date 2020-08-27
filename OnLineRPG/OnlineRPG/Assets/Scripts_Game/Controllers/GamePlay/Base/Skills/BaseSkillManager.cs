using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using UnityEngine.UI;

public class BaseSkillManager : GameEntity
{
    public SpecificCellHint specificCellHint;
    public SpecificWordHint specificWordHint;
    public KeyboardHint keyboardHint;
    public MultiCellsHint multiCellsHint;

    protected BaseHint usingHint = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init()
    {
        PropertyAB propab = AppEngine.SSystemManager.GetSystem<RewardABSystem>().GetUserPropConfig();
        propab.dataList.ForEach(data => {
            switch (data.ID)
            {
                case "Hint1":
                    specificCellHint.Init(this, data);
                    break;
                case "Hint2":
                    keyboardHint.Init(this, data);
                    break;
                case "Hint3":
                    multiCellsHint.Init(this, data);
                    break;
                case "Hint4":
                    specificWordHint.Init(this, data);
                    break;
            }
        });
    }
    public BaseCellManager CellManager { get { return GameManager.GetEntity<BaseCellManager>(); } }

    public bool IsDuringUse { get { return usingHint != null; } }

    public bool IsUsingHint(BaseHint hint)
    {
        return usingHint == hint;
    }

    public virtual void OnHintStart(BaseHint hint)
    {
        usingHint = hint;
        ShowMask(true);
        //GameManager.GetEntity<BaseCellManager>().ShowMask(true);
        GameManager.GetEntity<BaseKeyBoard>().ShowMask(true);
    }

    public virtual void OnHintUse(BaseHint hint)
    {
        GameManager.HintUse();
    }

    public virtual void OnHintEnd(BaseHint hint)
    {
        usingHint = null;
        ShowMask(false);
        //GameManager.GetEntity<BaseCellManager>().ShowMask(false);
        GameManager.GetEntity<BaseKeyBoard>().ShowMask(false);
        GameManager.HintEnd();
        GameManager.CacheLevelProgress();
        GameManager.SaveLocal();
    }

    #region 入场和出场动画

    public void Appear()
    {
        
    }

    public void DisAppear()
    {
        
    }

    public virtual void OnGameCompleted()
    {
        if (usingHint != null)
            usingHint.CancelHint();
    }

    #endregion
}
