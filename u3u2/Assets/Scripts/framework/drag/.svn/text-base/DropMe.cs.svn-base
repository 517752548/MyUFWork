using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// ������ק�Ķ������Ӵ˽ű�
/// </summary>
public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Image containerImage;
    //����Ʒ����ʱ��ʾ
    public Image receiveImage;
    public Color highlightColor = Color.green;

	private Color normalColor=Color.white;

    private RMetaEventHandler onDropHandler;

    public RMetaEventHandler OnDropHandler
    {
        set { onDropHandler = value; }
    }

	public void OnDrop(PointerEventData data)
	{
	    if (DragManager.Ins.CurrentDragItem == null)
	    {
	        return;
	    }
        DragManager.Ins.CurrentDragItem.OnEndDrag(data);

		containerImage.color = normalColor;
        if (receiveImage != null)
        {
            receiveImage.gameObject.SetActive(false);
            receiveImage.color = normalColor;
        }
        if (onDropHandler!=null)
	    {
	        onDropHandler(new RMetaEvent("drop",null));
	    }
		ClientLog.LogWarning("DropPPPPPPPPPP"+data.pointerDrag.name);
    }

	public void OnPointerEnter(PointerEventData data)
	{
	    if (!DragManager.Ins.IsDragging)
	    {
	        return;
	    }
        ClientLog.LogWarning("OnPointerEnter!!!!!!!!!");

	    if (receiveImage != null)
	    {
            receiveImage.gameObject.SetActive(true);
	        receiveImage.color = highlightColor;
	    }
	}

	public void OnPointerExit(PointerEventData data)
	{
        if (!DragManager.Ins.IsDragging)
        {
            return;
        }
        ClientLog.LogWarning("OnPointerExit~~~~~~~~~~~!!!!!!!!!");
        if (receiveImage != null)
        {
            receiveImage.gameObject.SetActive(false);
            receiveImage.color = normalColor;
	    }
	}
	
	private Sprite GetDropSprite(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;

		var srcImage = originalObj.GetComponent<Image>();
		if (srcImage == null)
			return null;
		
		return srcImage.sprite;
	}
}
