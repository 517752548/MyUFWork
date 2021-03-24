using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class GDragEventDispatcher : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	public GameObject targetGo;

	private ScrollRect anotherScrollRect;

	private Image thisRaycast;

	private CanvasGroup thisCV;

	void Awake()
	{

	}

	void Start()
	{
		if(targetGo == null)
		{
			anotherScrollRect = gameObject.transform.parent.GetComponentInParent<ScrollRect>();
		}else
		{
			anotherScrollRect = targetGo.GetComponent<ScrollRect>();
		}

		if (anotherScrollRect)
		{
			thisRaycast = gameObject.GetComponentInChildren<Image>();

			thisCV = gameObject.GetComponentInChildren<CanvasGroup>();

		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (anotherScrollRect)
		{
			anotherScrollRect.OnBeginDrag(eventData);
		}

		if (thisRaycast)
		{
			thisRaycast.raycastTarget = false;
		}

		if (thisCV)
		{
			thisCV.interactable = false;
			thisCV.blocksRaycasts = false;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (anotherScrollRect)
		{
			anotherScrollRect.OnDrag(eventData);
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (anotherScrollRect)
		{
			anotherScrollRect.OnEndDrag(eventData);
		}

		if (thisRaycast)
		{
			thisRaycast.raycastTarget = true;
		}

		if (thisCV)
		{
			thisCV.interactable = true;
			thisCV.blocksRaycasts = true;
		}
	}
}