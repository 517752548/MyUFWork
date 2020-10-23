using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeChengUI : UIMonoBehaviour
{
    public GameUUToggle fenleiToggle;
    public TabButtonGroup daleiTBG;
    public TabButtonGroup xiaoleiTBG;

    public VerticalLayoutGroup listParent;
    public ToggleWithArrow defaultDaleiToggle;
    public EquipDaZaoItem defaultXiaoleiToggle;

    public CommonItemUINoClick leftItem;
    public CommonItemUINoClick rightItem;
    public CommonItemUINoClick yulanItem;

    public Text chenggonglv;
    public MoneyItemUI hechengCost;
    public DropDownMenu jishuMenu;

    public GameUUButton hechengOne;
    public GameUUButton hechengAll;
    
    public GameObject hechengEffect;
    public GameObject emptyTip;

    public CanvasRenderer scrollRenderer;
    public CanvasRenderer rightInfoRenderer;

    public override void Init()
    {
        base.Init();
        fenleiToggle = transform.Find("Toggle").GetComponent<GameUUToggle>();
        scrollRenderer = transform.Find("scrollContainer").GetComponent<CanvasRenderer>();
        daleiTBG = transform.Find("scrollContainer/scroll").gameObject.AddComponent<TabButtonGroup>();
        daleiTBG.Init();
        xiaoleiTBG = transform.Find("scrollContainer/scroll/baoshiList").gameObject.AddComponent<TabButtonGroup>();
        xiaoleiTBG.Init();
        listParent = transform.Find("scrollContainer/scroll/baoshiList").GetComponent<VerticalLayoutGroup>();
        defaultDaleiToggle = transform.Find("scrollContainer/scroll/baoshiList/ToggleWithArrow").gameObject.AddComponent<ToggleWithArrow>();
        defaultDaleiToggle.Init(
            defaultDaleiToggle.GetComponent<GameUUToggle>(),
            defaultDaleiToggle.transform.Find("up").GetComponent<Image>(),
            defaultDaleiToggle.transform.Find("down").GetComponent<Image>(),
            defaultDaleiToggle.transform.Find("right").GetComponent<Image>(),
            defaultDaleiToggle.transform.Find("Text").GetComponent<Text>(),
            ToggleWithArrowDirection.Vertical
            );

        defaultXiaoleiToggle = transform.Find("scrollContainer/scroll/baoshiList/baoshiItem").gameObject.AddComponent<EquipDaZaoItem>();
        CommonItemUINoClick itemWithNoClick =
            defaultXiaoleiToggle.transform.Find("ZZCommonItemUINoClick").gameObject.AddComponent<CommonItemUINoClick>();
        itemWithNoClick.Init();
        defaultXiaoleiToggle.Init(
            defaultXiaoleiToggle.transform.Find("Background").GetComponent<Image>(),
              defaultXiaoleiToggle.transform.Find("Background/Checkmark").GetComponent<Image>(),
              defaultXiaoleiToggle.transform.GetComponent<GameUUToggle>(),
               itemWithNoClick,
               defaultXiaoleiToggle.transform.Find("baoshiName").GetComponent<Text>(),
defaultXiaoleiToggle.transform.Find("baoshiDesc").GetComponent<Text>(),
null

            );

        rightInfoRenderer = transform.Find("rightInfo").GetComponent<CanvasRenderer>();
        
        leftItem = transform.Find("rightInfo/content/leftItem").gameObject.AddComponent<CommonItemUINoClick>();
        leftItem.Init();
        rightItem = transform.Find("rightInfo/content/rightItem").gameObject.AddComponent<CommonItemUINoClick>();
        rightItem.Init();
        yulanItem = transform.Find("rightInfo/content/yulanItem").gameObject.AddComponent<CommonItemUINoClick>();
        yulanItem.Init();
        chenggonglv = transform.Find("rightInfo/chenggonglv/bg/Text").GetComponent<Text>();
        hechengCost = transform.Find("rightInfo/xiaohao/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        hechengCost.Init();
        jishuMenu = transform.Find("rightInfo/DropDownMenu").gameObject.AddComponent<DropDownMenu>();
        jishuMenu.Init();
        hechengOne = transform.Find("hechengOneBtn").GetComponent<GameUUButton>();
        hechengAll = transform.Find("hechengAllBtn").GetComponent<GameUUButton>();
        // hechengEffect = transform.Find("rightInfo/content/yulanItem/UI_01").gameObject;
        emptyTip = transform.Find("rightInfo/content/emptyTip").gameObject;
        // hechengEffect.gameObject.SetActive(false);
    }
}
