using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHomeUI : MonoBehaviour
{
    protected BaseThemeRoot root;
    [SerializeField] protected List<BaseHomeUI> childHomeUIs;

    public virtual void Init(BaseThemeRoot root)
    {
        this.root = root;
        childHomeUIs.ForEach(ui => ui.Init(root));
    }
    /// <summary>
    /// 导演类下的root显示
    /// </summary>
    public virtual void OnShow()
    {
        childHomeUIs.ForEach(ui => ui.OnShow());
    }
    /// <summary>
    /// 导演类下的root隐藏
    /// </summary>
    public virtual void OnHidden()
    {
        childHomeUIs.ForEach(ui => ui.OnHidden());
    }
    /// <summary>
    /// 进入标签
    /// </summary>
    public virtual void OnEnter()
    {
        childHomeUIs.ForEach(ui => ui.OnEnter());
    }
    /// <summary>
    /// 离开标签
    /// </summary>
    public virtual void OnLeave()
    {
        childHomeUIs.ForEach(ui => ui.OnLeave());
    }

    public T GetHomeUi<T>() where T : BaseHomeUI
    {
        for (int i = 0; i < childHomeUIs.Count; i++)
        {
            if (childHomeUIs[i] is T)
            {
                return childHomeUIs[i] as T;
            }
            else
            {
                var ui = childHomeUIs[i].GetHomeUi<T>();
                if (ui != null)
                    return ui;
            }
        }
        return null;
    }
}
