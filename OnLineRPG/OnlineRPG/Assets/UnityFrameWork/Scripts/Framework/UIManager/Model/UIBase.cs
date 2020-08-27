using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
    public void Init(int id)
    {
        m_UIID = id;
        //m_UIName = null;
        OnUiCreate();
    }

    public void DestroyUi()
    {
        OnUiDestroy();
    }

    //当UI第一次打开时调用OnInit方法，调用时机在OnOpen之前
    protected virtual void OnUiCreate()
    {
    }

    protected virtual void OnUiDestroy()
    {
    }

    private int m_UIID = -1;

    public int UIID
    {
        get { return m_UIID; }
    }

    public string UIEventKey
    {
        get { return UIName + m_UIID; }
    }

    private string m_UIName = null;

    public string UIName
    {
        get
        {
            if (m_UIName == null)
            {
                m_UIName = name;
            }

            return m_UIName;
        }
        set
        {
            m_UIName = value;
        }
    }
}