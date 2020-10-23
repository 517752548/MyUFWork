using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EquipChongZhuUI : UIMonoBehaviour
{
    public GameObject gaizaoui;
    public GameObject tishiGo;
    public BagRightUI bagrightui;

    public CommonItemUI selectItem;
    public Text equipName;
    public Text dengji;
    //public Text naijiudu;
    //public Text basePropName;
    //public Text basePropValue;
    public Text zhiyeyaoqiu;
    public Text zhuangbeiPingfen;

    public GridLayoutGroup propBGrid;
    //public List<Text> propNameTextList;
    public List<Text> propNameValueList;
    public List<GameUUToggle> propToggleList;
    public List<Image> propToggleImageList;
    public CommonItemUI cailiaoItem;
    public MoneyItemUI needMoney;
    public GameUUButton chongzhu;
    public GameObject chongzhuEffect;

    public CanvasRenderer gaizaoRenderer;
    public CanvasRenderer tishiRenderer;
    public CanvasRenderer rightInfoRenderer;

    public override void Init()
    {
        base.Init();
        gaizaoui = transform.Find("gaizao").gameObject;
        gaizaoRenderer = gaizaoui.GetComponent<CanvasRenderer>();
        tishiGo = transform.Find("tishi").gameObject;
        tishiRenderer = tishiGo.GetComponent<CanvasRenderer>();

        bagrightui=transform.Find("rightPanel").gameObject.AddComponent<BagRightUI>();
        rightInfoRenderer = bagrightui.GetComponent<CanvasRenderer>();
        //bagrightui.Init();

        TabButtonGroup itemTBG = transform.Find("rightPanel/Image/scrollRect/itemGrid").gameObject.AddComponent<TabButtonGroup>();
        GridLayoutGroup itemGrid = transform.Find("rightPanel/Image/scrollRect/itemGrid").GetComponent<GridLayoutGroup>();
        CommonItemUI defauleItemUI = transform.Find("rightPanel/Image/scrollRect/itemGrid/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        defauleItemUI.Init();
        MoneyItemUI jinzi = transform.Find("rightPanel/jinzi").gameObject.AddComponent<MoneyItemUI>();
        jinzi.Init();
        MoneyItemUI yinzi = transform.Find("rightPanel/yinzi").gameObject.AddComponent<MoneyItemUI>();
        yinzi.Init();
        MoneyItemUI jinpiao = transform.Find("rightPanel/jinpiao").gameObject.AddComponent<MoneyItemUI>();
        jinpiao.Init();
        MoneyItemUI yinpiao = transform.Find("rightPanel/yinpiao").gameObject.AddComponent<MoneyItemUI>();
        yinpiao.Init();

        bagrightui.Init(null,null,itemTBG,itemGrid,defauleItemUI,jinzi,yinzi,jinpiao,yinpiao,null,null);

        selectItem=transform.Find("gaizao/CommonItemUI90_90").gameObject.AddComponent<CommonItemUI>();
        selectItem.Init();
        equipName=transform.Find("gaizao/equipName").GetComponent<Text>();
        dengji=transform.Find("gaizao/dengji").GetComponent<Text>();
        zhiyeyaoqiu=transform.Find("gaizao/zhiyeyaoqiu").GetComponent<Text>();
        zhuangbeiPingfen=transform.Find("gaizao/pingfen").GetComponent<Text>();
        propBGrid=transform.Find("gaizao/PropBList").GetComponent<GridLayoutGroup>();
        
        propNameValueList = new List<Text>();

        Text text1 = transform.Find("gaizao/PropBList/PropBText/PropBText 1").GetComponent<Text>();
        propNameValueList.Add(text1);
        Text text2 = transform.Find("gaizao/PropBList/PropBText (1)/PropBText 1").GetComponent<Text>();
        propNameValueList.Add(text2);
        Text text3 = transform.Find("gaizao/PropBList/PropBText (2)/PropBText 1").GetComponent<Text>();
        propNameValueList.Add(text3);
        Text text4 = transform.Find("gaizao/PropBList/PropBText (3)/PropBText 1").GetComponent<Text>();
        propNameValueList.Add(text4);
        Text text5 = transform.Find("gaizao/PropBList/PropBText (4)/PropBText 1").GetComponent<Text>();
        propNameValueList.Add(text5);
        Text text6 = transform.Find("gaizao/PropBList/PropBText (5)/PropBText 1").GetComponent<Text>();
        propNameValueList.Add(text6);

        propToggleList = new List<GameUUToggle>();

        GameUUToggle toggle1 = transform.Find("gaizao/PropBList/PropBText/Toggle").GetComponent<GameUUToggle>();
        propToggleList.Add(toggle1);
        GameUUToggle toggle2 = transform.Find("gaizao/PropBList/PropBText (1)/Toggle").GetComponent<GameUUToggle>();
        propToggleList.Add(toggle2);
        GameUUToggle toggle3 = transform.Find("gaizao/PropBList/PropBText (2)/Toggle").GetComponent<GameUUToggle>();
        propToggleList.Add(toggle3);
        GameUUToggle toggle4 = transform.Find("gaizao/PropBList/PropBText (3)/Toggle").GetComponent<GameUUToggle>();
        propToggleList.Add(toggle4);
        GameUUToggle toggle5 = transform.Find("gaizao/PropBList/PropBText (4)/Toggle").GetComponent<GameUUToggle>();
        propToggleList.Add(toggle5);
        GameUUToggle toggle6 = transform.Find("gaizao/PropBList/PropBText (5)/Toggle").GetComponent<GameUUToggle>();
        propToggleList.Add(toggle6);


        propToggleImageList = new List<Image>();

        Image imagetoggle1 = transform.Find("gaizao/PropBList/PropBText/Toggle/Background").GetComponent<Image>();
        propToggleImageList.Add(imagetoggle1);
        Image imagetoggle2 = transform.Find("gaizao/PropBList/PropBText (1)/Toggle/Background").GetComponent<Image>();
        propToggleImageList.Add(imagetoggle2);
        Image imagetoggle3 = transform.Find("gaizao/PropBList/PropBText (2)/Toggle/Background").GetComponent<Image>();
        propToggleImageList.Add(imagetoggle3);
        Image imagetoggle4 = transform.Find("gaizao/PropBList/PropBText (3)/Toggle/Background").GetComponent<Image>();
        propToggleImageList.Add(imagetoggle4);
        Image imagetoggle5 = transform.Find("gaizao/PropBList/PropBText (4)/Toggle/Background").GetComponent<Image>();
        propToggleImageList.Add(imagetoggle5);
        Image imagetoggle6 = transform.Find("gaizao/PropBList/PropBText (5)/Toggle/Background").GetComponent<Image>();
        propToggleImageList.Add(imagetoggle6);


        cailiaoItem = transform.Find("gaizao/CommonItemUI90_90_1").gameObject.AddComponent<CommonItemUI>();
        cailiaoItem.Init();
        needMoney=transform.Find("gaizao/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        needMoney.Init();
        chongzhu=transform.Find("gaizao/chongzhu").GetComponent<GameUUButton>();
        chongzhuEffect = transform.Find("gaizao/CommonItemUI90_90/UI_01").gameObject;
        chongzhuEffect.gameObject.SetActive(false);
        gaizaoui.gameObject.SetActive(false);
        tishiGo.gameObject.SetActive(false);

      }

}
