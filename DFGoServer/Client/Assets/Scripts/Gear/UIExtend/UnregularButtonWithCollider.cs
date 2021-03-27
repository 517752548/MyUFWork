using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

/// <summary>
/// 枚举 点击区域
/// </summary>
public enum ClickArea
{
    right,   //左侧透明区域
    left,
    top,
    bottom
};
public class UnregularButtonWithCollider : MonoBehaviour, IPointerClickHandler
{
    public class ButtonClickerEvent : UnityEvent { }
    private ButtonClickerEvent m_OnClick = new ButtonClickerEvent();

    PolygonCollider2D polygonCollider;
    Button button;
    void Start()
    {
        //获取多边形碰撞器
        polygonCollider = this.transform.GetComponent<PolygonCollider2D>();
        button = transform.GetComponent<Button>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (polygonCollider == null)
            return;
        if (polygonCollider.GetTotalPointCount() != 4)
            return;
        Vector2 outVec;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(this.transform.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out outVec);
        if (ContainsPointInQuadrangle(polygonCollider.points, outVec))
        {
            if(outVec.x == 0.0f || outVec.y == 0.0f)
            {
                return;
            }
            m_OnClick.Invoke();
        }
        else
        {
            ClickArea area = CheckClickArea(polygonCollider.points, outVec);
        }
    }

    public bool IsInQuadrangle(PointerEventData eventData)
    {
        Vector2 outVec;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out outVec);
        if (ContainsPointInQuadrangle(polygonCollider.points, outVec))
        {
            return true;
        }
        return false;
    }
    ClickArea CheckClickArea(Vector2[] polyPoints, Vector2 p)
    {
        Vector2 pos1 = polyPoints[0];
        Vector2 pos2 = polyPoints[1];
        Vector2 pos3 = polyPoints[2];
        if (p.x < pos1.x)
        {
            return ClickArea.left;
        }
        else if (p.x > pos3.x)
        {
            return ClickArea.right;
        }
        else if (p.y > pos1.y)
        {
            return ClickArea.top;
        }
        return ClickArea.bottom;
    }
    public ButtonClickerEvent OnClick
    {
        get { return m_OnClick; }
        set { m_OnClick = value; }
    }
    bool ContainsPointInQuadrangle(Vector2[] polyPoints, Vector2 p)
    {
        Vector2 pos1 = polyPoints[0];
        Vector2 pos2 = polyPoints[1];
        Vector2 pos3 = polyPoints[2];
        Vector2 pos4 = polyPoints[3];
        if (Multiply(p, pos1, pos2) * Multiply(p, pos4, pos3) <= 0 && Multiply(p, pos4, pos1) * Multiply(p, pos3, pos2) <= 0)
        {
            return true;
        }
        return false;
    }

    float Multiply(Vector2 p1, Vector2 p2, Vector2 p)
    {
        return ((p1.x - p.x) * (p2.y - p.y) - (p2.x - p.x) * (p1.y - p.y));
    }

    void Update()
    {

    }

}
