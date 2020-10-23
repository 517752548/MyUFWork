using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class EquipTipsUI : MonoBehaviour
{
    public Image bg;
    public RectTransform upContent;
    public RectTransform midContent;
    public RectTransform downContent;
    public RectTransform content;
    public Image IsWearing;
    public CommonItemUI Icon;
    public Text ItemName;
    public Text ItemLevel;
    public Text ItemType;
    public Text ItemPingFen;
    public Image pingfenUPbtn;
    public Image pingfenDOWNbtn;
    public List<Image> xingjieImageList;
    public GridLayoutGroup xingjie;
    public Text ZhiYe;
    public Text NaiJiuDu;
    public Text DaZaoZhe;
    public Text youxiaoqi;
    public Text bindprop;
    public Text bindstatus;

    public Text basePropName;
    public Text basePropValue;
    public GridLayoutGroup FuJiaShuXing;
	public List<Text> FuJiaShuXingList;
    public Text baoshiPropText;
    public GridLayoutGroup BaoShiShuxing;
	public List<Text> BaoShiShuxingList;

    public Text ShuoMing;
    
    public GameUUButton LeftButton;
    public GameUUButton RightButton;
    public Text leftBtnText;
    public Text rightBtnText;
    public void Init()
    {
        bg = transform.Find("bg").gameObject.GetComponent<Image>();
        upContent = transform.Find("bg/UpContent").gameObject.GetComponent<RectTransform>();
        midContent = transform.Find("bg/content/MidContent").gameObject.GetComponent<RectTransform>();
        downContent = transform.Find("bg/content/DownContent").gameObject.GetComponent<RectTransform>();
        content = transform.Find("bg/content").gameObject.GetComponent<RectTransform>();
        IsWearing = transform.Find("bg/UpContent/zhuangbeizhong").GetComponent<Image>();
        Icon = transform.Find("bg/UpContent/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        Icon.Init
        (
            Icon.transform.Find("Image").GetComponent<Image>(),
            Icon.transform.Find("Icon").GetComponent<Image>(),
            Icon.transform.Find("BianKuang").GetComponent<Image>(),
            null, null,
            Icon.transform.Find("xing").gameObject,
            Icon.transform.Find("xing/Text").GetComponent<Text>(),
            null, null, null
        );
        ItemName = transform.Find("bg/UpContent/equipName").GetComponent<Text>();
        ItemLevel = transform.Find("bg/UpContent/equipLevel").GetComponent<Text>();
        ItemType = transform.Find("bg/UpContent/equipTypeName").GetComponent<Text>();
        ItemPingFen = transform.Find("bg/UpContent/equipPingFen").GetComponent<Text>();
        pingfenUPbtn = transform.Find("bg/UpContent/SwitchButton/BackButton").GetComponent<Image>();
        pingfenDOWNbtn = transform.Find("bg/UpContent/SwitchButton/ForeButton").GetComponent<Image>();

        xingjieImageList = new List<Image>();
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image").GetComponent<Image>());
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image 1").GetComponent<Image>());
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image 2").GetComponent<Image>());
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image 3").GetComponent<Image>());
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image 4").GetComponent<Image>());
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image 5").GetComponent<Image>());
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image 6").GetComponent<Image>());
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image 7").GetComponent<Image>());
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image 8").GetComponent<Image>());
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image 9").GetComponent<Image>());
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image 10").GetComponent<Image>());
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image 11").GetComponent<Image>());
        xingjieImageList.Add(transform.Find("bg/content/MidContent/XingJi/Image 12").GetComponent<Image>());

        xingjie = transform.Find("bg/content/MidContent/XingJi").GetComponent<GridLayoutGroup>();
        ZhiYe = transform.Find("bg/content/MidContent/GameObject/zhiyeyaoqiu").GetComponent<Text>();
        NaiJiuDu = transform.Find("bg/content/MidContent/GameObject/naijiu").GetComponent<Text>();
        DaZaoZhe = transform.Find("bg/content/MidContent/GameObject/dazaozhe").GetComponent<Text>();
       
        youxiaoqi = transform.Find("bg/content/MidContent/GameObject/youxiaoqi").GetComponent<Text>();
        bindstatus = transform.Find("bg/content/MidContent/GameObject/bindstatus").GetComponent<Text>();
        bindprop = transform.Find("bg/content/MidContent/GameObject/bindprop").GetComponent<Text>();
        basePropName = transform.Find("bg/content/MidContent/GameObject/Text").GetComponent<Text>();
        basePropValue = transform.Find("bg/content/MidContent/GameObject/fashuqiangdu").GetComponent<Text>();

        FuJiaShuXing = transform.Find("bg/content/MidContent/PropBList").GetComponent<GridLayoutGroup>();

        FuJiaShuXingList = new List<Text>();
        FuJiaShuXingList.Add(transform.Find("bg/content/MidContent/PropBList/PropAText").GetComponent<Text>());
        FuJiaShuXingList.Add(transform.Find("bg/content/MidContent/PropBList/PropAText 1").GetComponent<Text>());
        FuJiaShuXingList.Add(transform.Find("bg/content/MidContent/PropBList/PropAText 2").GetComponent<Text>());
        FuJiaShuXingList.Add(transform.Find("bg/content/MidContent/PropBList/PropAText 3").GetComponent<Text>());
        FuJiaShuXingList.Add(transform.Find("bg/content/MidContent/PropBList/PropAText 4").GetComponent<Text>());
        FuJiaShuXingList.Add(transform.Find("bg/content/MidContent/PropBList/PropAText 5").GetComponent<Text>());

        baoshiPropText = transform.Find("bg/content/MidContent/PropAText 1").GetComponent<Text>();
        BaoShiShuxing = transform.Find("bg/content/MidContent/BaoShiAddPropList").GetComponent<GridLayoutGroup>();

        BaoShiShuxingList = new List<Text>();
        BaoShiShuxingList.Add(transform.Find("bg/content/MidContent/BaoShiAddPropList/PropBText").GetComponent<Text>());
        BaoShiShuxingList.Add(transform.Find("bg/content/MidContent/BaoShiAddPropList/PropBText 1").GetComponent<Text>());
        BaoShiShuxingList.Add(transform.Find("bg/content/MidContent/BaoShiAddPropList/PropBText 2").GetComponent<Text>());
        BaoShiShuxingList.Add(transform.Find("bg/content/MidContent/BaoShiAddPropList/PropBText 3").GetComponent<Text>());
        BaoShiShuxingList.Add(transform.Find("bg/content/MidContent/BaoShiAddPropList/PropBText 4").GetComponent<Text>());
        BaoShiShuxingList.Add(transform.Find("bg/content/MidContent/BaoShiAddPropList/PropBText 5").GetComponent<Text>());
        BaoShiShuxingList.Add(transform.Find("bg/content/MidContent/BaoShiAddPropList/PropBText 6").GetComponent<Text>());
        BaoShiShuxingList.Add(transform.Find("bg/content/MidContent/BaoShiAddPropList/PropBText 7").GetComponent<Text>());
        BaoShiShuxingList.Add(transform.Find("bg/content/MidContent/BaoShiAddPropList/PropBText 8").GetComponent<Text>());
        BaoShiShuxingList.Add(transform.Find("bg/content/MidContent/BaoShiAddPropList/PropBText 9").GetComponent<Text>());

        ShuoMing = transform.Find("bg/content/MidContent/desc").GetComponent<Text>();

        LeftButton = transform.Find("bg/content/DownContent/leftButton").GetComponent<GameUUButton>();
        RightButton = transform.Find("bg/content/DownContent/rightButton").GetComponent<GameUUButton>();

        leftBtnText = LeftButton.transform.Find("name").GetComponent<Text>();
        rightBtnText = RightButton.transform.Find("name").GetComponent<Text>();


    }


}
