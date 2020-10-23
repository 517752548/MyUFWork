using UnityEngine;
using System.Collections;

public class BattlePetListUIBehav : MonoBehaviour
{

    public GameUUButton closeBtn;
	public GameObject itemList;
	public BattlePetListItemUI petListItemUI;

    public void Init()
    {
        closeBtn = transform.Find("GameObject/CloseButton").GetComponent<GameUUButton>();
        itemList = transform.Find("petItemScroll/scrollRect/petItemList").gameObject;
        petListItemUI = transform.Find("petItemScroll/scrollRect/petItemList/petListItem").gameObject.AddComponent<BattlePetListItemUI>();
        petListItemUI.Init();
        petListItemUI.gameObject.SetActive(false);
    }
}
