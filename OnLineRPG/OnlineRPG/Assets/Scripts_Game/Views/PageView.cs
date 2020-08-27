using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PageView : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private ScrollRect rect;                        //滑动组件
    private float targethorizontal = 0;             //滑动的起始坐标
    private bool isDrag = false;                    //是否拖拽结束
    public List<float> posList = new List<float>();            //求出每页的临界角，页索引从0开始
    private int currentPageIndex = 0;
    public Action<int> OnPageChanged;

    private bool stopMove = true;
    public float smooting = 0.8f;      //滑动速度
    public float sensitivity = 0;
    private float startTime;
    public int FixedWith = 0;
    private float startDragHorizontal;
    public RectTransform content;

    private void Awake()
    {
        rect = transform.GetComponent<ScrollRect>();
        if (content == null) {
            content = transform.Find("Viewport/Content") as RectTransform;
        }
        ContentChildCountChanged();
        smooting = 0.8f;
    }

    public void ContentChildCountChanged()
    {
        posList.Clear();
        float horizontalLength = content.transform.childCount * GetComponent<RectTransform>().rect.width - GetComponent<RectTransform>().rect.width;
        posList.Add(0);
        for (int i = 1; i < content.transform.childCount - 1; i++)
        {
            posList.Add((GetComponent<RectTransform>().rect.width * i+FixedWith*i) / horizontalLength);
        }
        posList.Add(1);
        if (content.transform.childCount < 2)
        {
            this.enabled = false;
            rect.enabled = false;
        }
        else
        {
            this.enabled = true;
            rect.enabled = true;
        }
    }

    private void Update()
    {
        if (!isDrag && !stopMove)
        {
            startTime += Time.deltaTime;
            float t = startTime * smooting;
            if (rect) {
                rect.horizontalNormalizedPosition = Mathf.Lerp(rect.horizontalNormalizedPosition, targethorizontal, t);
            }
            if (t >= 1)
                stopMove = true;
        }
    }

    public void pageTo(int index)
    {
        // Debug.LogError($"page to {index}");
        if (index >= 0 && index < posList.Count)
        {
            rect.horizontalNormalizedPosition = posList[index];
            SetPageIndex(index);
        }
        else
        {
            Debug.LogWarning("页码不存在");
        }
    }

    public void PageToAnimation(int index, float duration)
    {
        // Debug.LogError($"page to {index}");
        if (duration < 0.0001) {
            pageTo(index);
            return;
        }
        stopMove = true;//停止弹性update
        if (index >= 0 && index < posList.Count)
        {
            DOTween.To(() => rect.horizontalNormalizedPosition, x => rect.horizontalNormalizedPosition = x, posList[index], duration);
            SetPageIndex(index);
        }
        else
        {
            Debug.LogWarning("页码不存在");
        }
    }

    private void SetPageIndex(int index)
    {
        if (currentPageIndex != index)
        {
            currentPageIndex = index;
            if (OnPageChanged != null)
                OnPageChanged(index);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
        startDragHorizontal = rect.horizontalNormalizedPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        BetaFramework.LoggerHelper.Log("velocity " + rect.velocity);
        //if (Math.Abs(rect.velocity.x) > 300) {
        //	if (rect.velocity.x > 0) {
        //		rect.velocity = new Vector2(200, 0);
        //	} else {
        //		rect.velocity = new Vector2(-200, 0);
        //	}
        //}
        float posX = rect.horizontalNormalizedPosition;
        posX += ((posX - startDragHorizontal) * sensitivity);
        posX = posX < 1 ? posX : 1;
        posX = posX > 0 ? posX : 0;
        int index = 0;
        if (Math.Abs(rect.velocity.x) > 300)
        {
            if (rect.velocity.x < 0)
            {
                index = currentPageIndex + 1;
                if (index >= posList.Count)
                {
                    index = posList.Count - 1;
                }
            }
            if (rect.velocity.x > 0)
            {
                index = currentPageIndex - 1;
                if (index < 0)
                {
                    index = 0;
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

        BetaFramework.LoggerHelper.Log(">>>> index" + index);
        SetPageIndex(index);

        targethorizontal = posList[index]; //设置当前坐标，更新函数进行插值
        isDrag = false;
        startTime = 0;
        stopMove = false;
    }
}