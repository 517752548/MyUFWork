using UnityEngine;
using UnityEngine.UI;

public class EquipDaZaoUI : UIMonoBehaviour
{

    public GridLayoutGroup cailiaoGrid;
    public CaiLiaoItemUI defaultCaiLiaoItem;

    public CommonItemUI rightitem;
    public Text equiptype;
    public Text desc;

    public Dropdown kindDropDown;
    public Dropdown levelDropDown;
    public Dropdown nameDropDown;
    public Dropdown qualityDropDown;

    public GameUUButton monidazaoBtn;
    public GameUUButton dazaoBtn;

    public MoneyItemUI havemoney1;

    public GameObject detailProp;
    public Text equipname;
    public Text bindtxt;
    public Text prop1;
    public Text naijiu;
    public Text dengji;
    public Text zhiye;
    public Text prop2;
    public Text prop3;
    public Text bindprop;
    public Text maxkongnum;

    public GameObject dazaoEffectCommon;
    public GameObject dazaoEffectLv;
    public GameObject dazaoEffectLan;
    public GameObject dazaoEffectZi;
    public GameObject dazaoEffectCheng;

    public override void Init()
    {
        base.Init();
        cailiaoGrid = transform.Find("ScrollViewVertical/grid").gameObject.GetComponent<GridLayoutGroup>();
        defaultCaiLiaoItem = transform.Find("ScrollViewVertical/grid/item").gameObject.AddComponent<CaiLiaoItemUI>();
        defaultCaiLiaoItem.Init();

        rightitem = transform.Find("rightbg/CommonItemUINoClick80_80").gameObject.AddComponent<CommonItemUI>();
        rightitem.Init();
        desc = transform.Find("rightbg/ScrollViewVertical/grid/desc").gameObject.GetComponent<Text>();
        equiptype = transform.Find("rightbg/equiptype").gameObject.GetComponent<Text>();

        kindDropDown = transform.Find("KindDropDown").gameObject.GetComponent<Dropdown>();
        levelDropDown = transform.Find("LevelDropDown").gameObject.GetComponent<Dropdown>();
        nameDropDown = transform.Find("NameDropDown").gameObject.GetComponent<Dropdown>();
        qualityDropDown = transform.Find("QualityDropDown").gameObject.GetComponent<Dropdown>();

        monidazaoBtn = transform.Find("monidazaoBtn").gameObject.GetComponent<GameUUButton>();
        dazaoBtn = transform.Find("dazaoBtn").gameObject.GetComponent<GameUUButton>();

        havemoney1 = transform.Find("MoneyItem1").gameObject.AddComponent<MoneyItemUI>();
        havemoney1.Init();

        detailProp = transform.Find("rightbg/ScrollViewVertical/grid/props").gameObject;
        equipname = detailProp.transform.Find("name").GetComponent<Text>();
        bindtxt = detailProp.transform.Find("bind").GetComponent<Text>();
        prop1 = detailProp.transform.Find("prop1").GetComponent<Text>();
        naijiu = detailProp.transform.Find("naijiu").GetComponent<Text>();
        dengji = detailProp.transform.Find("dengji").GetComponent<Text>();
        zhiye = detailProp.transform.Find("zhiye").GetComponent<Text>();
        prop2 = detailProp.transform.Find("prop2").GetComponent<Text>();
        prop3 = detailProp.transform.Find("prop3").GetComponent<Text>();
        bindprop = detailProp.transform.Find("bindprop").GetComponent<Text>();
        maxkongnum = detailProp.transform.Find("maxkongnum").GetComponent<Text>();
    }

}

public class CaiLiaoItemUI:UIMonoBehaviour
{
    public CommonItemUI item;
    public InputTextUI inputTextui;

    public override void Init()
    {
        item = transform.Find("CommonItemUINoClick80_80").gameObject.AddComponent<CommonItemUI>();
        item.Init();

        GameUUButton jiabtn = transform.Find("PageTurner/rightButton").gameObject.GetComponent<GameUUButton>();
        GameUUButton jianbtn = transform.Find("PageTurner/leftButton").gameObject.GetComponent<GameUUButton>();
        Image bg = transform.Find("PageTurner/Image").gameObject.GetComponent<Image>();
        Text txt = transform.Find("PageTurner/Text").gameObject.GetComponent<Text>();

        inputTextui = transform.Find("PageTurner").gameObject.AddComponent<InputTextUI>();
        inputTextui.Init(jianbtn,jiabtn,txt,null,bg);


    }
}