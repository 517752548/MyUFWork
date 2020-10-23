using UnityEngine;
using UnityEngine.UI;

public class EquipBaoshiUI : UIMonoBehaviour
{
    public Text leftTitle;
    public Text leftDesc;

    public GameObject leftItemList;
    public GridLayoutGroup leftgrid;
    public TabButtonGroup leftItemTBG;
    public CommonItemUI leftDefaultItem;

    public MoneyItemUI costMoney1;

    public GameObject chenggonglvGo;
    public Text chenggonglvText;

    public TabButtonGroup rightTBG;
    public CommonItemUI fangruItem;
    public CommonItemUI fuwenItem;
    public CommonItemUI fuzhuItem;

    public GridLayoutGroup kongGrid;
    public TabButtonGroup rightItemTBG;
    public CommonItemUI defaultKongItem;

    public GameUUButton dobtn;
    public Text dobtnText;

    public void Init()
    {
        base.Init();
        leftTitle = transform.Find("lefttitle").GetComponent<Text>();
        leftDesc = transform.Find("desc").GetComponent<Text>();

        leftItemList = transform.Find("itemlistPanel").gameObject;

        leftgrid = transform.Find("itemlistPanel/scrollRect/itemGrid").GetComponent<GridLayoutGroup>();
        leftItemTBG = leftgrid.gameObject.AddComponent<TabButtonGroup>();
        leftItemTBG.Init();

        leftDefaultItem = leftgrid.transform.Find("CommonItemUI90_90").gameObject.AddComponent<CommonItemUI>();
        leftDefaultItem.Init();

        costMoney1 = transform.Find("MoneyItem1").gameObject.AddComponent<MoneyItemUI>();
        costMoney1.Init();

        chenggonglvGo = transform.Find("chenggonglv").gameObject;
        chenggonglvText = chenggonglvGo.transform.Find("Text").GetComponent<Text>();

        rightTBG = transform.Find("rightTabGroup").gameObject.AddComponent<TabButtonGroup>();

        GameUUToggle dakong = transform.Find("rightTabGroup/dakong").GetComponent<GameUUToggle>();
        rightTBG.AddToggle(dakong);

        GameUUToggle xikong = transform.Find("rightTabGroup/xikong").GetComponent<GameUUToggle>();
        rightTBG.AddToggle(xikong);

        GameUUToggle xiangqian = transform.Find("rightTabGroup/xiangqian").GetComponent<GameUUToggle>();
        rightTBG.AddToggle(xiangqian);

        GameUUToggle hecheng = transform.Find("rightTabGroup/zhaichu").GetComponent<GameUUToggle>();
        rightTBG.AddToggle(hecheng);

        fangruItem = transform.Find("fangruItem").gameObject.AddComponent<CommonItemUI>();
        fangruItem.Init();

        fuwenItem = transform.Find("xiangqianfuwen").gameObject.AddComponent<CommonItemUI>();
        fuwenItem.Init();

        fuzhuItem = transform.Find("fuzhuItem").gameObject.AddComponent<CommonItemUI>();
        fuzhuItem.Init();

        kongGrid = transform.Find("Image/scrollRect/itemGrid").gameObject.GetComponent<GridLayoutGroup>();
        rightItemTBG = kongGrid.gameObject.AddComponent<TabButtonGroup>();

        defaultKongItem = kongGrid.transform.Find("CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        defaultKongItem.Init();

        dobtn = transform.Find("doBtn").gameObject.GetComponent<GameUUButton>();
        dobtnText = dobtn.transform.Find("Text").GetComponent<Text>();


    }

}
