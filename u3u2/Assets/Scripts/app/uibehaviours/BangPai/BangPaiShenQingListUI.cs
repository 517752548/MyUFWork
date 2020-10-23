using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BangPaiShenQingListUI : MonoBehaviour
{

    public GameUUButton bianhaoBtn;
    public GameUUButton mingchengBtn;
    public GameUUButton xingbieBtn;
    public GameUUButton dengjiBtn;
    public GameUUButton zhiyeBtn;
    public GameUUButton caozuoBtn;

    public GridLayoutGroup listGrid;
    public BangPaiListItemUI defaultListItemUI;

    public GameUUButton shuaxinBtn;
    public GameUUButton qingkongBtn;
    
    public void Init()
    {
        bianhaoBtn = transform.Find("bangpaiList/topBtnList/bianhao").GetComponent<GameUUButton>();
        mingchengBtn = transform.Find("bangpaiList/topBtnList/mingcheng").GetComponent<GameUUButton>();
        xingbieBtn = transform.Find("bangpaiList/topBtnList/xingbie").GetComponent<GameUUButton>();
        dengjiBtn = transform.Find("bangpaiList/topBtnList/dengji").GetComponent<GameUUButton>();
        zhiyeBtn = transform.Find("bangpaiList/topBtnList/zhiye").GetComponent<GameUUButton>();
        caozuoBtn = transform.Find("bangpaiList/topBtnList/caozuo").GetComponent<GameUUButton>();
        
        listGrid = transform.Find("bangpaiList/scrollList/Image/grid").GetComponent<GridLayoutGroup>();
        
        defaultListItemUI = transform.Find("bangpaiList/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<BangPaiListItemUI>();
        defaultListItemUI.Init
        (
            defaultListItemUI.transform,
            null,
            defaultListItemUI.transform.Find("bianhao"),
            defaultListItemUI.transform.Find("mingcheng"),
            defaultListItemUI.transform.Find("dengji"),
            null, null,
            defaultListItemUI.transform.Find("Toggle"),
            defaultListItemUI.transform.Find("zhiye"),
            null, null, null, null,
            defaultListItemUI.transform.Find("xingbie"),
            defaultListItemUI.transform.Find("tongyi"),
            defaultListItemUI.transform.Find("jujue"),
            defaultListItemUI.transform.Find("Background"),
            defaultListItemUI.transform.Find("Background 1")
        );
        defaultListItemUI.scrollRect = listGrid.transform.parent.GetComponent<ScrollRect>();
        shuaxinBtn = transform.Find("funcBtns/bangzhong/shuaxin").GetComponent<GameUUButton>();
        qingkongBtn = transform.Find("funcBtns/bangzhong/qingkong").GetComponent<GameUUButton>();
    }

}
