using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    public int UIID;
    private UiLayerController m_controller;
    public UiState type = UiState.Waiting;
    public bool CanReuse = true;

    public void SetController(UiLayerController m_controller)
    {
        this.m_controller = m_controller;
    }
    /// <summary>
    /// 被打开的时候调用
    /// </summary>
    public virtual void OnOpen()
    {
        type = UiState.Waiting;
    }

    /// <summary>
    /// 打开动画
    /// </summary>
    public virtual void OpenAnim()
    {
        type = UiState.Opening;
        OpenCompleted();
    }

    /// <summary>
    /// 完成了open动画
    /// </summary>
    public virtual void OpenCompleted()
    {
        type = UiState.Idle;
    }
    
    //在栈中再次弹出的时候调用
    public virtual void OnReOpen()
    {
        
    }
    
    //被隐藏入栈的时候调用
    public virtual void OnHidden()
    {
        
    }

    /// <summary>
    /// 关闭动画
    /// </summary>
    public virtual void ClosingAnim()
    {
        type = UiState.Closing;
        CloseCompleted();
    }

    /// <summary>
    /// 关闭成功
    /// </summary>
    public virtual void CloseCompleted()
    {
        type = UiState.Closed;
    }
    
    //被关闭
    public virtual void OnClose()
    {
        
    }
    
    //进入对象池被回收的时候调用
    public virtual void OnBeRecy()
    {
        
    }
}
