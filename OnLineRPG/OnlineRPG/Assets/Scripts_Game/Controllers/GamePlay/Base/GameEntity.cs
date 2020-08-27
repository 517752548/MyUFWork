using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 各种游戏实体对象
/// </summary>
public class GameEntity : MonoBehaviour
{
    public CanvasGroup mask = null;

    protected BaseGameManager m_baseGameManager;
    public BaseGameManager GameManager
    {
        get { return m_baseGameManager;}
        set { m_baseGameManager = value; }
    }

    public T GetGameManager<T>() where T : BaseGameManager
    {
        return m_baseGameManager as T;
    }

    public void ShowMask(bool show)
    {
        if (ReferenceEquals(mask, null))
            return;
        if (show)
        {
            
            mask.DOFade(1, 0.2f);
            mask.interactable = true;
            mask.blocksRaycasts = true;
        }
        else
        {
            mask.DOFade(0, 0.2f);
            mask.interactable = false;
            mask.blocksRaycasts = false;
        }
        //mask.DOFade(1, 0.2f).OnComplete(()=> { });
    }
}
