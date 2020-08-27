using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PageScrollView : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public ScrollRect scrollView;
    public Button prevPageButton;
    public Button nextPageButton;
    public GameObject dotImageContent;

    public Action<int> OnPageChanged;
    public Action<bool> OnReachedEdge;

    public float dragSensitivity = 0.1f;

    private RectTransform content;
    private Rect viewRect;
    private List<float> posList = new List<float>();            //求出每页的临界角，页索引从0开始
    private int currentPageIndex = 0;

    private bool isDrag = false;
    private bool stopMove = true;
    public float smooting = 4;      //滑动速度
    public float sensitivity = 0;
    private float startTime;
    private float targethorizontal = 0;             //滑动的起始坐标
    private float startDragHorizontal;
    private float startDragContentPosX;

    private bool enable = true;

    // Use this for initialization
    private void Start()
    {
        Init();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isDrag && !stopMove)
        {
            startTime += Time.deltaTime;
            float t = startTime * smooting;
            if (scrollView)
                scrollView.horizontalNormalizedPosition = Mathf.Lerp(scrollView.horizontalNormalizedPosition, targethorizontal, t);
            if (t >= 1)
                stopMove = true;
        }
    }

    public int CurPageIndex { get { return currentPageIndex; } }
    public int PageCount { get { return content.childCount; } }

    public void Init()
    {
        if (content != null)
            return;
        content = scrollView.content;
        viewRect = scrollView.GetComponent<RectTransform>().rect;
        updateState();

        if (prevPageButton != null)
        {
            prevPageButton.onClick.AddListener(PrevPage);
        }
        if (nextPageButton != null)
        {
            nextPageButton.onClick.AddListener(NextPage);
        }
    }

    private void updateState()
    {
        posList.Clear();
        posList.Add(0);
        float count = content.transform.childCount - 1;
        for (int i = 1; i < count; i++)
        {
            posList.Add(i / count);
        }
        if (count > 0)
            posList.Add(1);
    }

    public void SetEnable(bool bEnable)
    {
        enable = bEnable;
        scrollView.enabled = enable;
    }

    public void PrevPage()
    {
        if (!enable)
            return;
        if (currentPageIndex <= 0)
            return;
        PageToAnimation(currentPageIndex - 1, 0.5f);
    }

    public void NextPage()
    {
        if (!enable)
            return;
        if (currentPageIndex + 1 >= content.transform.childCount)
            return;
        PageToAnimation(currentPageIndex + 1, 0.5f);
    }

    public void AddPage(GameObject page)
    {
        page.GetComponent<RectTransform>().sizeDelta = new Vector2(viewRect.width, viewRect.height);
        page.transform.parent = content;
        updateState();
    }

    public void pageTo(int index)
    {
        if (index >= 0 && index < posList.Count)
        {
            scrollView.horizontalNormalizedPosition = posList[index];
            SetPageIndex(index);
        }
        else
        {
            BetaFramework.LoggerHelper.Error("页码不存在");
        }
    }

    public void PageToAnimation(int index, float duration)
    {
        if (index >= 0 && index < posList.Count)
        {
            DOTween.To(() => scrollView.horizontalNormalizedPosition, x => scrollView.horizontalNormalizedPosition = x, posList[index], duration);
            SetPageIndex(index);
        }
        else
        {
            BetaFramework.LoggerHelper.Error("页码不存在");
        }
    }

    private void SetPageIndex(int index)
    {
        if (currentPageIndex != index)
        {
            currentPageIndex = index;
            if (prevPageButton != null)
                prevPageButton.interactable = currentPageIndex > 0;
            if (nextPageButton != null)
                nextPageButton.interactable = currentPageIndex < content.transform.childCount - 1;
            if (OnPageChanged != null)
                OnPageChanged(index);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
        startDragHorizontal = scrollView.horizontalNormalizedPosition;
        startDragContentPosX = content.localPosition.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float posX = scrollView.horizontalNormalizedPosition;
        posX += ((posX - startDragHorizontal) * sensitivity);
        posX = posX < 1 ? posX : 1;
        posX = posX > 0 ? posX : 0;
        int index = 0;
        float width = scrollView.GetComponent<RectTransform>().rect.width;
        float deltaX = content.localPosition.x - startDragContentPosX;
        if (Math.Abs(deltaX) > width * dragSensitivity)
        {
            if (deltaX < 0)
            {
                index = currentPageIndex + 1;
                if (index >= posList.Count)
                {
                    index = posList.Count - 1;
                    if (OnReachedEdge != null)
                    {
                        OnReachedEdge(true);
                    }
                }
            }
            if (deltaX > 0)
            {
                index = currentPageIndex - 1;
                if (index < 0)
                {
                    index = 0;
                    if (OnReachedEdge != null)
                    {
                        OnReachedEdge(false);
                    }
                }
            }
        }
        else
        {
            float offset = Mathf.Abs(posList[index] - posX);
            for (int i = 1; i < posList.Count; i++)
            {
                float temp = Mathf.Abs(posList[i] - posX);
                if (temp < offset)
                {
                    index = i;
                    offset = temp;
                }
            }
        }

        SetPageIndex(index);

        targethorizontal = posList[index]; //设置当前坐标，更新函数进行插值
        isDrag = false;
        startTime = 0;
        stopMove = false;
    }
}