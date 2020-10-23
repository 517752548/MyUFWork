using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BangPaiShiJianListUI : MonoBehaviour
{

    public GridLayoutGroup listGrid;
    public BangPaiListItemUI defaultItemUI;

    public void Init()
    {
        listGrid = transform.Find("bangpaiList/scrollList/Image/grid").GetComponent<GridLayoutGroup>();
        defaultItemUI = transform.Find("bangpaiList/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<BangPaiListItemUI>();
        defaultItemUI.Init
        (
            defaultItemUI.transform,
            null,
            defaultItemUI.transform.Find("shijian"),
            defaultItemUI.transform.Find("mingcheng"),
            null, null, null, null, null, null, null, null, null, null, null, null,
            defaultItemUI.transform.Find("Background"),
            defaultItemUI.transform.Find("Background 1")
        );

        defaultItemUI.scrollRect = listGrid.transform.parent.GetComponent<ScrollRect>();
    }

}
