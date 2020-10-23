using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// ��Ҫ��ק�Ķ������Ӵ˽ű�
/// </summary>
public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler//IEndDragHandler
{
	public bool dragOnSurfaces = true;
    /// <summary>
    /// ��קʱ������ͼƬ
    /// </summary>
    public string dragImageTemplateId;
    /// <summary>
    /// ����ק�Ķ�������������һ��ScrollRect������Ҫ���ô���
    /// </summary>
    public ScrollRect parentScrollRect;

	private GameObject m_DraggingIcon;
	private RectTransform m_DraggingPlane;

    /// <summary>
    /// ���³������� ������ק,��λms
    /// </summary>
    private int minStartDragDown=200;
    /// <summary>
    /// ����ʱ��ʱ��
    /// </summary>
    private DateTime downTime=DateTime.MinValue;
    /// <summary>
    /// ��ǰ�Ƿ��Ѿ���ʼ��ק
    /// </summary>
    private bool isStartDrag=false;

    private RMetaEventHandler onStartDragHandler;

    public RMetaEventHandler OnStartDragHandler
    {
        set { onStartDragHandler = value; }
    }

    public void Update()
    {
        if (downTime != DateTime.MinValue)
        {
            TimeSpan ts = DateTime.Now - downTime;
            int passTime = (int)Math.Floor(ts.TotalMilliseconds);
            if (passTime>=minStartDragDown)
            {
                isStartDrag = true;
                downTime = DateTime.MinValue;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        downTime = DateTime.Now;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        downTime = DateTime.MinValue;
        isStartDrag = false;
    }

	public void OnBeginDrag(PointerEventData eventData)
	{
	    if (!isStartDrag)
	    {
	        downTime = DateTime.MinValue;
            if (parentScrollRect!=null) parentScrollRect.OnBeginDrag(eventData);
	        return;
	    }
	    else
	    {
	        onStartDrag(eventData);
	    }
	}

    public void onStartDrag(PointerEventData eventData)
    {
        // We have clicked something that can be dragged.
        // What we want to do is create an icon for this.
        m_DraggingIcon = new GameObject("icon");
        m_DraggingIcon.transform.SetParent(UGUIConfig.GetCanvasByWndType(WndType.BUBBLES).transform);
        m_DraggingIcon.transform.SetAsLastSibling();

        Image image = m_DraggingIcon.AddComponent<Image>();
        // The icon will be under the cursor.
        // We want it to be ignored by the event system.
        CanvasGroup group = m_DraggingIcon.AddComponent<CanvasGroup>();
        group.blocksRaycasts = false;
        PathUtil.Ins.SetItemIcon(image, this.dragImageTemplateId);
        //image.texture = PathUtil.Ins.GetItemIcon(this.dragImageTemplateId);
        image.SetNativeSize();
        image.transform.localScale = Vector3.one * 1.5f;
        if (dragOnSurfaces)
            m_DraggingPlane = this.GetComponent<RectTransform>();
        else
            m_DraggingPlane = UGUIConfig.GetCanvasByWndType(WndType.BUBBLES).GetComponent<RectTransform>();

        SetDraggedPosition(eventData);

        DragManager.Ins.CurrentDragItem = this;
        DragManager.Ins.IsDragging = true;
        if (onStartDragHandler!=null)
        {
            onStartDragHandler(new RMetaEvent("drag",null));
        }
    }

	public void OnDrag(PointerEventData data)
	{
	    if (!isStartDrag)
	    {
            if (parentScrollRect != null) parentScrollRect.OnDrag(data);
	    }
	    else
	    {
            ClientLog.Log("OnDrag!!!!!!!");
	        if (m_DraggingIcon != null)
	        {
	            SetDraggedPosition(data);
	        }    
	    }
	}

	private void SetDraggedPosition(PointerEventData data)
	{
		if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
			m_DraggingPlane = data.pointerEnter.transform as RectTransform;
        ClientLog.Log("SetDraggedPosition!!!!!!!");
        RectTransform rt = m_DraggingIcon.GetComponent<RectTransform>();
		Vector3 globalMousePos;
        Vector2 size = m_DraggingIcon.GetComponent<RectTransform>().sizeDelta;
        //Vector2 temp = Vector2.zero;
        //temp.x = data.position.x - size.x;
        //temp.y = data.position.y + size.y;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle
            (m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
		{
			rt.position = globalMousePos;
			rt.rotation = m_DraggingPlane.rotation;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
        ClientLog.Log("Onend Drag!!!!!!!");
	    if (m_DraggingIcon != null)
	    {
            GameObject.DestroyImmediate(m_DraggingIcon, true);
            m_DraggingIcon = null;
	    }
        DragManager.Ins.CurrentDragItem = null;
        DragManager.Ins.IsDragging = false;

        if (parentScrollRect != null) parentScrollRect.OnEndDrag(eventData);
	}

    /*
	static public T FindInParents<T>(GameObject go) where T : Component
	{
		if (go == null) return null;
		var comp = go.GetComponent<T>();

		if (comp != null)
			return comp;
		
		Transform t = go.transform.parent;
		while (t != null && comp == null)
		{
			comp = t.gameObject.GetComponent<T>();
			t = t.parent;
		}
		return comp;
	}
   * */
}
