using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 增加一页内容的回调
/// </summary>
/// <param name="startIndex"></param>
/// <param name="count"></param>
public delegate IEnumerator AddOnePageCallBack(int startIndex,int count);

public class ScrollerManager:AbsMonoBehaviour
{
    //所有的滚动条列表
    private List<ScrollRectControl> scrollerList;

    private static ScrollerManager _ins;
    public static ScrollerManager Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new ScrollerManager();
            }
            return _ins;
        }
    }

    private ScrollerManager()
    {
        scrollerList = new List<ScrollRectControl>();
    }

    public override void DoUpdate(float deltaTime)
    {
        for (int i = 0; i < scrollerList.Count; i++)
        {
            ScrollRectControl timer = scrollerList[i];
            if (timer != null)
            {
                timer.DoUpdate();
            }
        }
    }
    GameObject bargo;
    public ScrollRectControl createScroll(ScrollRect scrollRect,GameObject defaultItem,
        GameObject itemParent, AddOnePageCallBack addOnePageCB)
    {
        ScrollRectControl scroll = scrollRect.gameObject.GetComponent<ScrollRectControl>();
        if (scroll==null)
        {
            scroll = scrollRect.gameObject.AddComponent<ScrollRectControl>();
        }
        if(bargo==null)
            bargo = SourceManager.Ins.createObjectFromAssetBundle(PathUtil.Ins.GetUIPath("Scrollbar")) as GameObject;
        Scrollbar bar = bargo.GetComponent<Scrollbar>();
        bargo.transform.SetParent(scrollRect.transform);
        RectTransform rtf = bar.GetComponent<RectTransform>();
        rtf.anchoredPosition = new Vector2(-5, 0);
        rtf.sizeDelta = new Vector2(20, 0);
        bargo.transform.localScale = Vector3.one;
        scrollRect.verticalScrollbar = bar;
        bar.direction = Scrollbar.Direction.TopToBottom;
        bar.gameObject.SetActive(false);
        scroll.init(scrollRect,defaultItem,itemParent,bar,addOnePageCB);
        if (!scrollerList.Contains(scroll))
        {
            scrollerList.Add(scroll);
        }
        return scroll;
    }

    public void DisposeScroll(ScrollRectControl scroll)
    {
        if (scrollerList!=null&&scroll!=null&&scrollerList.Contains(scroll))
        {
            scroll.DisPose();
            scrollerList.Remove(scroll);
        }
    }
}
