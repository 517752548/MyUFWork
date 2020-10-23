using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollViewer : ScrollRect
{
    private float MemberWidth;

    private float TotalWidth;

    private float startDragPosition;
    
    private int currentIndex = 0;

    protected override void Awake()
    {
        base.Awake();
        GridLayoutGroup grid = this.content.GetComponent<GridLayoutGroup>();
        MemberWidth =grid.cellSize.x;
    }

    public int CurrentIndex
    {
        get { return currentIndex; }
        set
        {
            //总数量
            int totalNum = (int)(TotalWidth / MemberWidth);
            if (value < totalNum&&value>=0)
            {
                currentIndex=value;
                this.SetContentAnchoredPosition(new Vector2(-currentIndex * MemberWidth, 0));
            }
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (this.horizontalNormalizedPosition<0)
        {
            CurrentIndex = 0;
            this.horizontalNormalizedPosition = 0;
            return;
        }
        if (this.horizontalNormalizedPosition>1)
        {
            CurrentIndex = (int) (TotalWidth/MemberWidth);
            this.horizontalNormalizedPosition = 1;
            return;
        }
        
        if(this.horizontalNormalizedPosition>startDragPosition)
        {
            CurrentIndex = CurrentIndex+1;
        }
        else if (this.horizontalNormalizedPosition < startDragPosition)
        {
            CurrentIndex = CurrentIndex - 1;
        }
        //Debug.Log("停止拖动 this.horizontalNormalizedPosition：" + this.horizontalNormalizedPosition);
        //Debug.Log("totalNum：" + totalNum);
        ////单个的范围
        //float memberRange = 1f / totalNum;
        //Debug.Log("memberRange：" + memberRange);
        ////当前中心的位置
        //float centerPos = this.horizontalNormalizedPosition + memberRange/2;
        //Debug.Log("centerPos：" + centerPos);
        ////中心位置落在哪个上，应该停在哪个上
        //int stopIndex = Mathf.FloorToInt(centerPos/memberRange);
        //Debug.Log("stopIndex：" + stopIndex);
        ////this.horizontalNormalizedPosition = stopIndex * memberRange;
        ////this.normalizedPosition = new Vector2(stopIndex * memberRange,0);
        //this.SetContentAnchoredPosition(new Vector2(-stopIndex * MemberWidth,0));
        //Debug.Log("停止拖动 内容Rect：" + this.content.rect + " normalizedPosition ：" + this.normalizedPosition + " 横向位置：" + this.horizontalNormalizedPosition);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        TotalWidth = this.content.rect.width;
        startDragPosition = this.horizontalNormalizedPosition;
        //Debug.Log("开始拖拽 内容Rect：" + this.content.rect + " normalizedPosition ：" + this.normalizedPosition + " 横向位置：" + this.horizontalNormalizedPosition);
    }

}
