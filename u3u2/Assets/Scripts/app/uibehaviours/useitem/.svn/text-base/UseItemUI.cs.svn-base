using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UseItemUI : UIMonoBehaviour
{
    public CommonItemUI m_defaultitem;
    public ScrollRect m_scrollrect;

    public override void Init()
    {
        base.Init();

        m_defaultitem = transform.Find("scrollRect/grid/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        m_defaultitem.Init();
        m_defaultitem.gameObject.SetActive(false);
        m_scrollrect = transform.Find("scrollRect").gameObject.GetComponent<ScrollRect>();
    }
}
