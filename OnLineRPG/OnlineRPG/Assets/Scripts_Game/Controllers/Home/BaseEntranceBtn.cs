using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Scripts_Game.Controllers.Home;
using UnityEngine;

public class BaseEntranceBtn : BaseHomeUI
{
    [SerializeField] protected BaseEntranceCtrl parentCtrl;
    public int Weight;

    public float Height => GetComponent<RectTransform>().rect.height;
    
    /// <summary>
    /// 入口按钮对应的功能是否处于可用状态
    /// </summary>
    /// <returns></returns>
    public virtual bool IsValid()
    {
        return true;
    }
    
    /// <summary>
    /// 入口按钮是否可见
    /// </summary>
    /// <returns></returns>
    public virtual bool IsVisible()
    {
        return gameObject.activeSelf;
    }

    public void DOLocalMoveY(float posY)
    {
        transform.DOLocalMoveY(posY, 0.5f).SetEase(Ease.OutBack);
    }

    public void SetParentCtrl(BaseEntranceCtrl ctrl)
    {
        parentCtrl = ctrl;
    }

    protected void UpdateInParent()
    {
        parentCtrl.OnShow();
    }

    public override void OnShow()
    {
        base.OnShow();
    }
}
