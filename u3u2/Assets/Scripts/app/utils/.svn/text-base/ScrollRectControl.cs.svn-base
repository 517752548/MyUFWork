using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 上拉刷新的 滚动条，每次增加一页的条数
/// </summary>
/// 
public class ScrollRectControl : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Scrollbar bar;
    private ScrollRect scrollRect;
    private GameObject defaultItem;
    private GameObject itemParent;
    private int perpageNum = 5;
    private int totalNum = 100;
    public List<GameObject> goList { get; private set; }
    private AddOnePageCallBack addOnePageCB;

    private bool needNew;
    private int currentNum;
    private bool lastActiveValue;
    private bool mScrollItemNumChanged;
    private float mScrollItemsHeight;
    private PointerEventData mEndDragEventData;

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="scrollRectv"></param>
    /// <param name="defaultItemv"></param>
    /// <param name="itemParentv"></param>
    /// <param name="barv"></param>
    /// <param name="addOnePageCBv"></param>
    public void init(ScrollRect scrollRectv, GameObject defaultItemv,
        GameObject itemParentv, Scrollbar barv, AddOnePageCallBack addOnePageCBv)
    {
        scrollRect = scrollRectv;
        scrollRect.movementType = ScrollRect.MovementType.Elastic;
        scrollRect.elasticity = 0.1f;
        defaultItem = defaultItemv;
        itemParent = itemParentv;
        bar = barv;
        addOnePageCB = addOnePageCBv;
    }
    /// <summary>
    /// 设置每页的条数 和 总条数
    /// </summary>
    /// <param name="perpageNumv"></param>
    /// <param name="totalNumv"></param>
    public void setItemNum(int perpageNumv, int totalNumv)
    {
        perpageNum = perpageNumv;
        totalNum = totalNumv;
        currentNum = 0;
        addOnePage();
    }

    private void clickBtn()
    {
        bar.value = 1;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        mEndDragEventData = eventData;
        if (needNew && currentNum < totalNum)
        {
            mScrollItemsHeight = itemParent.GetComponent<RectTransform>().sizeDelta.y;
            addOnePage();
            needNew = false;
        }
        else
        {
            scrollRect.movementType = ScrollRect.MovementType.Elastic;
            scrollRect.elasticity = 0.1f;
            scrollRect.OnEndDrag(eventData);
        }
        //scrollRect.movementType = ScrollRect.MovementType.Elastic;
        //scrollRect.elasticity = 0.1f;
        //scrollRect.OnEndDrag(eventData);
    }

    /// <summary>
    /// 添加一页
    /// </summary>
    private void addOnePage()
    {
        if (defaultItem == null || itemParent == null)
        {
            return;
        }

        if (currentNum >= totalNum)
        {
            //已经到最后了
            if (totalNum == 0)
            {
                //多余的隐藏
                if (goList == null) return;
                for (int i = 0; i < goList.Count; i++)
                {
                    if (goList[i] != null)
                        goList[i].SetActive(false);
                }
            }
            return;
        }

        int addNum = 0;
        if (currentNum + perpageNum > totalNum)
        {
            addNum = totalNum - currentNum;
        }
        else
        {
            addNum = perpageNum;
        }
        for (int i = currentNum; i < currentNum + addNum; i++)
        {
            if (goList == null)
            {
                goList = new List<GameObject>();
            }
            if (i >= goList.Count)
            {
                GameObject newItem = GameObject.Instantiate(defaultItem) as GameObject;
                newItem.transform.SetParent(itemParent.transform);
                newItem.transform.localScale = Vector3.one;
                goList.Add(newItem);
            }
            goList[i].SetActive(true);
        }
        //多余的隐藏
        for (int i = currentNum + addNum; i < goList.Count; i++)
        {
            goList[i].SetActive(false);
        }
        if (addOnePageCB != null)
        {
            //回调增加一页
            //addOnePageCB(currentNum, addNum);
            StartCoroutine(addOnePageCB(currentNum, addNum));
        }
        currentNum = currentNum + addNum;

        mScrollItemNumChanged = (addNum > 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //if (needNew == false)
        //{
        /*
        if (bar.value<=0)
        {
            needNew = true;
        }
        else
        {
            needNew = false;
        }
        */
        //}
        needNew = (bar.value <= 0);
    }

    public void DoUpdate()
    {
        if (mScrollItemNumChanged && mEndDragEventData != null)
        {
            float f = itemParent.GetComponent<RectTransform>().sizeDelta.y;
            if (f != mScrollItemsHeight)
            {
                scrollRect.movementType = ScrollRect.MovementType.Elastic;
                scrollRect.elasticity = 0.1f;
                scrollRect.OnEndDrag(mEndDragEventData);

                mScrollItemNumChanged = false;
            }
        }

        if (lastActiveValue && scrollRect.gameObject.activeInHierarchy)
        {
            return;
        }
        //if (lastActiveValue && !scrollRect.gameObject.activeInHierarchy)
        //{
        //    DisPose();
        //}
        lastActiveValue = scrollRect.gameObject.activeInHierarchy;
    }
    /// <summary>
    /// 回收释放
    /// </summary>
    public void DisPose()
    {
        if (goList != null)
        {
            for (int i = 0; i < goList.Count; i++)
            {
                GameObject.DestroyImmediate(goList[i], true);
                goList[i] = null;
            }
            goList.Clear();
        }

        currentNum = 0;
    }
}
