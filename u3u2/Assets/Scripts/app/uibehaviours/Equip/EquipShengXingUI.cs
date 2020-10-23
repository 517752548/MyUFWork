using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EquipShengXingUI : UIMonoBehaviour
{
    public CommonItemUI equipItem;
    public Text equipLevel;
    public Text equipName;

    public BagLeftUI bagleftUI;
    public GridLayoutGroup starGrid;

    public Text propNameNow;
    public Text propValueNow;

    public Text propNameAfter;
    public Text propValueAfter;

    public CommonItemUI shengxingshu;
    public CommonItemUI shengxingshi;

    public Text chenggonglv;

    public MoneyItemUI currentHave;

    public MoneyItemUI needMoney;

    public GameUUButton shuoming;
    public GameUUButton shengxing;
    
    public GameObject shengxingEffect;
    public GameUUToggle m_shengxingcheck;

    public override void Init()
    {
        base.Init();
        equipItem = transform.Find("rightPanel/equipGo/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        equipItem.Init();
        equipItem.Xing.gameObject.SetActive(false);
        equipLevel = transform.Find("rightPanel/equipGo/equiplevel").GetComponent<Text>();
        equipName = transform.Find("rightPanel/equipGo/equipname").GetComponent<Text>();
        
        bagleftUI = transform.Find("leftPanel").gameObject.AddComponent<BagLeftUI>();
        bagleftUI.Init(false);
        
        starGrid = transform.Find("rightPanel/equipGo/starList 1").GetComponent<GridLayoutGroup>();
        propNameNow = transform.Find("rightPanel/propName1").GetComponent<Text>();
        propValueNow = transform.Find("rightPanel/propValue1").GetComponent<Text>();
        propNameAfter = transform.Find("rightPanel/propName2").GetComponent<Text>();
        propValueAfter = transform.Find("rightPanel/propValue2").GetComponent<Text>();
        shengxingshu = transform.Find("rightPanel/shengxingshu").gameObject.AddComponent<CommonItemUI>();
        shengxingshu.Init();
        shengxingshu.Xing.gameObject.SetActive(false);
        m_shengxingcheck = transform.Find("rightPanel/shengxingshu/Toggle").gameObject.GetComponent<GameUUToggle>();
        shengxingshi = transform.Find("rightPanel/shengxingshi").gameObject.AddComponent<CommonItemUI>();
        shengxingshi.Init();
        shengxingshi.Xing.gameObject.SetActive(false);
        chenggonglv = transform.Find("rightPanel/chenggonglv").GetComponent<Text>();
        needMoney = transform.Find("rightPanel/ZZMoneyItem").gameObject.AddComponent<MoneyItemUI>();
        needMoney.Init(needMoney.transform.Find("Image").GetComponent<Image>(), needMoney.transform.Find("Text").GetComponent<Text>(), null);
        shuoming = transform.Find("rightPanel/shuoming").GetComponent<GameUUButton>();
        shengxing = transform.Find("rightPanel/shengxing").GetComponent<GameUUButton>();
        //shengxingEffect = transform.Find("rightPanel/equipGo/CommonItemUI/UI_01").gameObject;
    }

}
