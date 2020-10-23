using UnityEngine;
using UnityEngine.UI;

public class BattleItemListUIBehav : MonoBehaviour
{
	public LayoutElement itemListContainer;
	public GridLayoutGroup itemList;
	public CommonItemUINoClick itemUI;
	public Text leftTimeText;
	public BattleItemDetailInfoUIBehav itemDetailInfoUI;

    public void Init()
    {
        itemListContainer = transform.Find("totalList/itemListContainer").GetComponent<LayoutElement>();
        itemList = transform.Find("totalList/itemListContainer/itemList").GetComponent<GridLayoutGroup>();
        itemUI = transform.Find("item").gameObject.AddComponent<CommonItemUINoClick>();
        itemUI.Init(null, transform.Find("item/icon").GetComponent<Image>(), null, null, transform.Find("item/name").GetComponent<Text>(), null);
        leftTimeText = transform.Find("totalList/titleContainer/title").GetComponent<Text>();
        itemDetailInfoUI = transform.parent.Find("battleItemDetailInfoUI").gameObject.AddComponent<BattleItemDetailInfoUIBehav>();
        itemDetailInfoUI.Init();
        itemDetailInfoUI.gameObject.SetActive(false);
        itemUI.gameObject.SetActive(false);

    }
}
