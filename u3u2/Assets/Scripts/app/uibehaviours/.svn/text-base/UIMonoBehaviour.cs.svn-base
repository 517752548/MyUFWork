using UnityEngine;

public class UIMonoBehaviour : MonoBehaviour
{
	public Transform visibleParent;
	public Vector2 showPos;
	public Vector2 hidePos;
	private RectTransform mRTrans = null;

	public virtual void Init()
	{
		visibleParent = gameObject.transform.parent;
		mRTrans = GetComponent<RectTransform>();
		showPos = mRTrans.anchoredPosition;
		hidePos = new Vector2(showPos.x, showPos.y + UGUIConfig.UISpaceHeight);
	}
	
	public virtual void Show()
	{
		if (!gameObject.activeSelf)
		{
			gameObject.SetActive(true);
		}
		
		if (transform.parent != visibleParent)
		{
			transform.SetParent(visibleParent);
		}
		if (mRTrans.anchoredPosition != showPos)
		{
			mRTrans.anchoredPosition = showPos;
		}
	}
	
	public virtual void Hide()
	{
		/*
		if (transform.parent != UGUIConfig.InvisibleTransform)
		{
			transform.SetParent(UGUIConfig.InvisibleTransform);
		}
		*/
		if (mRTrans.anchoredPosition != hidePos)
		{
			mRTrans.anchoredPosition = hidePos;
		}
	}
	
	public bool isShown
	{
		get
		{
			return gameObject.activeSelf && (transform.parent == visibleParent) && (mRTrans.anchoredPosition == showPos);
		}
	}
}