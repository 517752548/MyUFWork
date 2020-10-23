using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PaiMaiHangBuyUI : UIMonoBehaviour
{
    public VerticalLayoutGroup btnList;
    public ToggleGroup daleiToggleGroup;
    public ToggleGroup xiaoleiToggleGroup;

    public TabButtonGroup daleiTBG;
    public TabButtonGroup xiaoleiTBG;

    public ToggleWithArrow defaultDaLeiToggle;
    public GameUUToggle defaultXiaoLeiToggle;

    public MoneyItemUI haveMoney;
    public MoneyItemUI yinzihaveMoney;
    public GameUUButton addMoneyBtn;
    public GameUUButton yinziAddMoneyBtn;

    public GameObject rightUpGo;
    public Text shangpinLeiName;

    public GameObject fenleiScroll;
    public GameObject itemlist;

    public TabButtonGroup fenleiTBG;
    public GridLayoutGroup fenleiGrid;
    public PaiMaiHangItemUI defaultFenLeiUI;

    public TabButtonGroup itemsTBG;
    public GridLayoutGroup itemGrid;
    public PaiMaiHangItemUI defaultItemUI;

    public GameUUButton goumaiBtn;

    public GameObject petConditionGo;
    public GameObject equipConditionGo;
    public GameObject baoshiConditionGo;

    public DropDownMenu petBianyiMenu;
    public DropDownMenu petPingfenMenu;

    public DropDownMenu equipLevelMenu;
    public DropDownMenu equipColorMenu;

    public DropDownMenu baoshiLevelMenu;

    public DropDownMenu jiageMenu;
    public PageTurner pageTurner;

    public GameUUToggle petBianyiToggle;
    public GameUUToggle petPingFenToggle;
    public GameUUToggle equipLevelToggle;
    public GameUUToggle equipColorToggle;
    public GameUUToggle baoshiToggle;
    public GameUUToggle jiageToggle;

    public GameUUButton sousuoBtn;

    public CanvasRenderer leftPanelRenderer;
    public CanvasRenderer rightPanelRenderer;

    public override void Init()
    {
        base.Init();

        leftPanelRenderer = transform.Find("leftPanel").GetComponent<CanvasRenderer>();
        rightPanelRenderer = transform.Find("rightPanel").GetComponent<CanvasRenderer>();

        sousuoBtn = transform.Find("leftPanel/top/Button0").GetComponent<GameUUButton>();

        jiageToggle = transform.Find("JiageMenu/Toggle").GetComponent<GameUUToggle>();
        ToggleWithArrow arrow = jiageToggle.gameObject.AddComponent<ToggleWithArrow>();
        arrow.Init(
              jiageToggle,
              jiageToggle.transform.Find("shang").GetComponent<Image>(),
              jiageToggle.transform.Find("xia").GetComponent<Image>(),
              null,
              jiageToggle.transform.Find("Label").GetComponent<Text>(),
              ToggleWithArrowDirection.Vertical
          );
        arrow.InitListener();

        baoshiToggle = transform.Find("baoshiCondition/LevelMenu/Toggle").GetComponent<GameUUToggle>();
        arrow = baoshiToggle.gameObject.AddComponent<ToggleWithArrow>();
        arrow.Init(
               baoshiToggle,
               baoshiToggle.transform.Find("shang").GetComponent<Image>(),
               baoshiToggle.transform.Find("xia").GetComponent<Image>(),
               null,
               baoshiToggle.transform.Find("Label").GetComponent<Text>(),
               ToggleWithArrowDirection.Vertical
           );
        arrow.InitListener();

        equipColorToggle = transform.Find("equipCondition/ColorMenu/Toggle").GetComponent<GameUUToggle>();
        arrow = equipColorToggle.gameObject.AddComponent<ToggleWithArrow>();
        arrow.Init(
               equipColorToggle,
               equipColorToggle.transform.Find("shang").GetComponent<Image>(),
               equipColorToggle.transform.Find("xia").GetComponent<Image>(),
               null,
               equipColorToggle.transform.Find("Label").GetComponent<Text>(),
               ToggleWithArrowDirection.Vertical
           );
        arrow.InitListener();


        equipLevelToggle = transform.Find("equipCondition/LevelMenu/Toggle").GetComponent<GameUUToggle>();
        arrow = equipLevelToggle.gameObject.AddComponent<ToggleWithArrow>();
        arrow.Init(
               equipLevelToggle,
               equipLevelToggle.transform.Find("shang").GetComponent<Image>(),
               equipLevelToggle.transform.Find("xia").GetComponent<Image>(),
               null,
               equipLevelToggle.transform.Find("Label").GetComponent<Text>(),
               ToggleWithArrowDirection.Vertical
           );
        arrow.InitListener();

        petPingFenToggle = transform.Find("petCondition/PingfenMenu/Toggle").GetComponent<GameUUToggle>();
        arrow = petPingFenToggle.gameObject.AddComponent<ToggleWithArrow>();
        arrow.Init(
               petPingFenToggle,
               petPingFenToggle.transform.Find("shang").GetComponent<Image>(),
               petPingFenToggle.transform.Find("xia").GetComponent<Image>(),
               null,
               petPingFenToggle.transform.Find("Label").GetComponent<Text>(),
               ToggleWithArrowDirection.Vertical
           );
        arrow.InitListener();

        petBianyiToggle = transform.Find("petCondition/BianyiMenu/Toggle").GetComponent<GameUUToggle>();
        arrow = petBianyiToggle.gameObject.AddComponent<ToggleWithArrow>();
        arrow.Init(
               petBianyiToggle,
               petBianyiToggle.transform.Find("shang").GetComponent<Image>(),
               petBianyiToggle.transform.Find("xia").GetComponent<Image>(),
               null,
               petBianyiToggle.transform.Find("Label").GetComponent<Text>(),
               ToggleWithArrowDirection.Vertical
           );
        arrow.InitListener();

        btnList = transform.Find("leftPanel/scrollRect/petgrid").GetComponent<VerticalLayoutGroup>();
        daleiToggleGroup = transform.Find("leftPanel/scrollRect").GetComponent<ToggleGroup>();
        xiaoleiToggleGroup = transform.Find("leftPanel/scrollRect/petgrid").GetComponent<ToggleGroup>();
        daleiTBG = transform.Find("leftPanel/scrollRect").gameObject.AddComponent<TabButtonGroup>();
        daleiTBG.Init();
        xiaoleiTBG = transform.Find("leftPanel/scrollRect/petgrid").gameObject.AddComponent<TabButtonGroup>();
        xiaoleiTBG.Init();
        GameUUToggle defaultDaLeiToggleBase = transform.Find("leftPanel/scrollRect/petgrid/dalei").GetComponent<GameUUToggle>();
        defaultDaLeiToggleBase.isOn = false;
        defaultXiaoLeiToggle = transform.Find("leftPanel/scrollRect/petgrid/xiaolei").GetComponent<GameUUToggle>();
        defaultXiaoLeiToggle.isOn = false;
        //daleiTBG.AddToggle(defaultDaLeiToggle);
        //xiaoleiTBG.AddToggle(defaultXiaoLeiToggle);
        defaultDaLeiToggle = defaultDaLeiToggleBase.gameObject.AddComponent<ToggleWithArrow>();
        defaultDaLeiToggle.Init(
            defaultDaLeiToggleBase,
            defaultDaLeiToggleBase.transform.Find("up").GetComponent<Image>(),
            defaultDaLeiToggleBase.transform.Find("down").GetComponent<Image>(),
            defaultDaLeiToggleBase.transform.Find("right").GetComponent<Image>(),
            defaultDaLeiToggleBase.transform.Find("Text").GetComponent<Text>(),
            ToggleWithArrowDirection.Vertical
        );
        haveMoney = transform.Find("leftPanel/GameObject/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        haveMoney.Init(haveMoney.transform.Find("Image").GetComponent<Image>()
            , haveMoney.transform.Find("Text").GetComponent<Text>(),
            haveMoney.transform.Find("bg").GetComponent<Image>()); //TODO
        yinzihaveMoney = transform.Find("leftPanel/GameObject 1/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        yinzihaveMoney.Init(yinzihaveMoney.transform.Find("Image").GetComponent<Image>()
            , yinzihaveMoney.transform.Find("Text").GetComponent<Text>(),
            yinzihaveMoney.transform.Find("bg").GetComponent<Image>());//TODO
        addMoneyBtn = transform.Find("leftPanel/GameObject/Button").GetComponent<GameUUButton>();
        yinziAddMoneyBtn = transform.Find("leftPanel/GameObject 1/Button").GetComponent<GameUUButton>();
        rightUpGo = transform.Find("rightPanel/up").gameObject;
        shangpinLeiName = transform.Find("rightPanel/up/Text 1").GetComponent<UnityEngine.UI.Text>();
        fenleiScroll = transform.Find("rightPanel/fenleiScroll").gameObject;
        itemlist = transform.Find("rightPanel/itemList").gameObject;
        fenleiTBG = transform.Find("rightPanel/fenleiScroll/grid").gameObject.AddComponent<TabButtonGroup>();
        fenleiTBG.Init();
        fenleiGrid = transform.Find("rightPanel/fenleiScroll/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        defaultFenLeiUI = transform.Find("rightPanel/fenleiScroll/grid/fenleiItem").gameObject.AddComponent<PaiMaiHangItemUI>();
        /*
        MoneyItemUI moneyItemUi = defaultFenLeiUI.transform.Find("MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        moneyItemUi.Init(
            moneyItemUi.transform.Find("Image").GetComponent<Image>(),
            moneyItemUi.transform.Find("Text").GetComponent<Text>(),
            moneyItemUi.transform.Find("bg").GetComponent<Image>());
        */
        CommonItemUINoClick c1 = defaultFenLeiUI.transform.Find("CommonItemUINoClick").gameObject.AddComponent<CommonItemUINoClick>();
        c1.Init
            (
                c1.transform.Find("Image").GetComponent<Image>(),
                c1.transform.Find("Icon").GetComponent<Image>(),
                //c1.transform.Find("BianKuang").GetComponent<Image>(),
                //c1.transform.Find("Num").GetComponent<Text>(),
                //c1.transform.Find("Name").GetComponent<Text>(),
                null,
                null,
                null,
                null
            );

        defaultFenLeiUI.Init(
            null,
            null,
            defaultFenLeiUI.transform.Find("equipName").GetComponent<Text>(),
            null,
            null,
            c1
            );
        itemsTBG = transform.Find("rightPanel/itemList/grid").gameObject.AddComponent<TabButtonGroup>();
        itemsTBG.Init();
        itemGrid = transform.Find("rightPanel/itemList/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();




        defaultItemUI = transform.Find("rightPanel/itemList/grid/equipItem").gameObject.AddComponent<PaiMaiHangItemUI>();

        MoneyItemUI m2 = defaultItemUI.transform.Find("MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        m2.Init
        (
            m2.transform.Find("Image").GetComponent<Image>(),
            m2.transform.Find("Text").GetComponent<Text>(),
            m2.transform.Find("bg").GetComponent<Image>()
        );
        //Transform tfTest = defaultItemUI.transform.Find("CommonItemUINoClick");
        CommonItemUI c2 = defaultItemUI.transform.Find("CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        c2.Init();
        defaultItemUI.Init
        (
            c2,
            null,
            defaultItemUI.transform.Find("equipName").GetComponent<Text>(),
            null,
            m2,
            null
        );


        goumaiBtn = transform.Find("rightPanel/goumai").GetComponent<GameUUButton>();
        petConditionGo = transform.Find("petCondition").gameObject;
        equipConditionGo = transform.Find("equipCondition").gameObject;
        baoshiConditionGo = transform.Find("baoshiCondition").gameObject;
        petBianyiMenu = transform.Find("petCondition/BianyiMenu").gameObject.AddComponent<DropDownMenu>();
        petBianyiMenu.Init();


        petPingfenMenu = transform.Find("petCondition/PingfenMenu").gameObject.AddComponent<DropDownMenu>();
        List<ToggleWithText> petPingfenList = new List<ToggleWithText>();
        ToggleWithText petPingfenUp = transform.Find("petCondition/PingfenMenu/downListBg/downList/Toggle").gameObject.AddComponent<ToggleWithText>();
        petPingfenUp.Init(petPingfenUp.GetComponent<GameUUToggle>(), petPingfenUp.transform.Find("Label").GetComponent<Text>());
        ToggleWithText petPingfenDown = transform.Find("petCondition/PingfenMenu/downListBg/downList/Toggle 1").gameObject.AddComponent<ToggleWithText>();
        petPingfenDown.Init(petPingfenDown.GetComponent<GameUUToggle>(), petPingfenDown.transform.Find("Label").GetComponent<Text>());
        petPingfenList.Add(petPingfenUp);
        petPingfenList.Add(petPingfenDown);
        petPingfenMenu.Init(petPingfenList);


        equipLevelMenu = transform.Find("equipCondition/LevelMenu").gameObject.AddComponent<DropDownMenu>();
        equipLevelMenu.Init();


        equipColorMenu = transform.Find("equipCondition/ColorMenu").gameObject.AddComponent<DropDownMenu>();

        equipColorMenu.Init();


        baoshiLevelMenu = transform.Find("baoshiCondition/LevelMenu").gameObject.AddComponent<DropDownMenu>();
        baoshiLevelMenu.Init();


        jiageMenu = transform.Find("JiageMenu").gameObject.AddComponent<DropDownMenu>();
        List<ToggleWithText> jiageList = new List<ToggleWithText>();
        ToggleWithText jiageUp = transform.Find("JiageMenu/downListBg/downList/Toggle").gameObject.AddComponent<ToggleWithText>();
        jiageUp.Init(jiageUp.GetComponent<GameUUToggle>(), jiageUp.transform.Find("Label").GetComponent<Text>());
        ToggleWithText jiageDown = transform.Find("JiageMenu/downListBg/downList/Toggle 1").gameObject.AddComponent<ToggleWithText>();
        jiageDown.Init(jiageDown.GetComponent<GameUUToggle>(), jiageDown.transform.Find("Label").GetComponent<Text>());
        jiageList.Add(jiageUp);
        jiageList.Add(jiageDown);
        jiageMenu.Init(jiageList);

        pageTurner = transform.Find("PageTurner").gameObject.AddComponent<PageTurner>();
        pageTurner.Init
        (
            pageTurner.transform.Find("leftButton").GetComponent<GameUUButton>(),
            pageTurner.transform.Find("rightButton").GetComponent<GameUUButton>(),
            pageTurner.transform.Find("Text").GetComponent<Text>()

        );

        petConditionGo.gameObject.SetActive(false);
        equipConditionGo.gameObject.SetActive(false);
        baoshiConditionGo.gameObject.SetActive(false);
        jiageMenu.gameObject.SetActive(false);
    }

}
