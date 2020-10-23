using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class ShangChengTabUI : UIMonoBehaviour
{
    public TabButtonGroup tabTBG;
    public GridLayoutGroup tabGrid;
    public GameUUToggle defaultToggle;

    //public TabButtonGroup itemsTBG;
    //public GameObject itemGrid;
    public ScrollRect scrollrect;
    public PaiMaiHangItemUI defaultItemUI;

    public GameObject tishiObj;
    public Text tishiText;
    public GameObject itemInfoObj;

    public Text itemnameText;
    public Text itemdesc;
    public MoneyItemUI yuanjia;
    public Text yuanjiaText;
    public MoneyItemUI xianjia;
    public Image yuanjiaRedLine;

    public InputTextUI shuliang;
    public MoneyItemUI huafei;
    public MoneyItemUI yongyou;

    public GameUUButton goumaiBtn;

    public GameUUButton shuaxinBtn;

    public CanvasRenderer tabsRenderer;
    public CanvasRenderer itemListRenderer;
    public CanvasRenderer itemDataRenderer;


    public override void Init()
    {
        base.Init();

        tabTBG = transform.Find("shoptabscanvas/shopTabs/grid").gameObject.AddComponent<TabButtonGroup>();
        tabsRenderer = transform.Find("shoptabscanvas").GetComponent<CanvasRenderer>();

        tabGrid = transform.Find("shoptabscanvas/shopTabs/grid").gameObject.GetComponent<GridLayoutGroup>();
        defaultToggle = transform.Find("shoptabscanvas/shopTabs/grid/toggle").gameObject.GetComponent<GameUUToggle>();

        itemListRenderer = transform.Find("itemListCanvas").GetComponent<CanvasRenderer>();
        scrollrect = transform.Find("itemListCanvas/itemList").gameObject.GetComponent<ScrollRect>();

        //itemsTBG = transform.Find("itemList/grid").gameObject.AddComponent<TabButtonGroup>();
        //itemGrid = transform.Find("itemList/grid").gameObject;

        CommonItemUI c1 = transform.Find("equipItem/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        c1.Init();
        MoneyItemUI m1 = transform.Find("equipItem/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        m1.Init();

        defaultItemUI = transform.Find("equipItem").gameObject.AddComponent<PaiMaiHangItemUI>();
        defaultItemUI.Init(c1, null,//transform.Find("itemList/grid/equipItem/CommonItemUI/Icon").GetComponent<Image>(),
            transform.Find("equipItem/equipName").GetComponent<Text>(), null,
            m1, null
            );
        itemDataRenderer = transform.Find("itemdata").GetComponent<CanvasRenderer>();
        tishiObj = transform.Find("itemdata/tishi").gameObject;
        tishiText = tishiObj.transform.Find("Text_timer").GetComponent<Text>();
        itemInfoObj = transform.Find("itemdata/itemdesc").gameObject;

        itemnameText = transform.Find("itemdata/itemdesc/itemname").gameObject.GetComponent<Text>();
        itemdesc = transform.Find("itemdata/itemdesc/itemdesc").gameObject.GetComponent<Text>();
        yuanjia = transform.Find("itemdata/itemdesc/yuanjia/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        yuanjia.Init();
        yuanjiaText = transform.Find("itemdata/itemdesc/yuanjia/Text").gameObject.GetComponent<Text>();

        xianjia = transform.Find("itemdata/itemdesc/xianjia/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        xianjia.Init();

        yuanjiaRedLine = transform.Find("itemdata/itemdesc/yuanjia/hongxian").gameObject.GetComponent<Image>();
        MoneyItemUI shuliangmoney = transform.Find("goumaishuliang/InputTextUI/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        shuliangmoney.Init();

        shuliang = transform.Find("goumaishuliang").gameObject.AddComponent<InputTextUI>();
        shuliang.Init(
            shuliang.transform.Find("InputTextUI/jianBtn").GetComponent<GameUUButton>(),
            shuliang.transform.Find("InputTextUI/jiaBtn").GetComponent<GameUUButton>(),
            shuliang.transform.Find("InputTextUI/MoneyItem/Text").GetComponent<Text>(),
            shuliangmoney.moneyIcon,shuliangmoney.inputBg
            );

        huafei = transform.Find("huafei/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        huafei.Init();

        yongyou = transform.Find("yongyou/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        yongyou.Init();

        goumaiBtn = transform.Find("goumai").gameObject.GetComponent<GameUUButton>();

        shuaxinBtn = transform.Find("shuaxin").GetComponent<GameUUButton>();

        itemInfoObj.gameObject.SetActive(false);
        defaultItemUI.gameObject.SetActive(false);
        scrollrect.gameObject.SetActive(false);
        //itemGrid.gameObject.SetActive(false);
    }

}
