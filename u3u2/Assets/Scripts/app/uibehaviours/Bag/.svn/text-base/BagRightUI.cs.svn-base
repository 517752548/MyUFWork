using UnityEngine;
using UnityEngine.UI;

public class BagRightUI : MonoBehaviour
{
    public GameUUButton closeBtn;

    public TabButtonGroup tabButtonGroup;

    public TabButtonGroup itemTBG;
    
    public GridLayoutGroup itemGrid;
    public CommonItemUI defaultItemUI;
	public MoneyItemUI jinzi;
	public MoneyItemUI yinzi;
	public MoneyItemUI jinpiao;
	public MoneyItemUI yinpiao;
    public GameObject jinzidi;
    public GameObject yinzidi;
    public GameUUButton CangKuBtn;

    public GameUUButton ZhengLiBtn;
    
    public GameUUButton payBtn;

    public void Init(GameUUButton closeBtn,TabButtonGroup tabButtonGroup,TabButtonGroup itemTBG,GridLayoutGroup itemGrid,
        CommonItemUI defaultItemUi,MoneyItemUI jinzi,MoneyItemUI yinzi,MoneyItemUI jinpiao,MoneyItemUI yinpiao,GameUUButton cangkuBtn
        ,GameUUButton zhengliBtn)
    {
        this.closeBtn = closeBtn;
        this.tabButtonGroup = tabButtonGroup;
        this.itemTBG = itemTBG;
        this.itemGrid = itemGrid;
        this.defaultItemUI = defaultItemUi;
        this.jinzi = jinzi;
        this.yinzi = yinzi;
        this.jinpiao = jinpiao;
        this.yinpiao = yinpiao;
        this.CangKuBtn = cangkuBtn;
        this.ZhengLiBtn = zhengliBtn;

    }

    public void Init()
    {
        if (transform.parent.Find("closeBtn")!=null)
        {
            closeBtn = transform.parent.Find("closeBtn").GetComponent<GameUUButton>();
        }
        if (transform.parent.Find("tabGroup") != null)
        {
            tabButtonGroup = transform.parent.Find("tabGroup").gameObject.AddComponent<TabButtonGroup>();
            if (tabButtonGroup.transform.Find("toggles/quanbu")!=null)
            {
                GameUUToggle quanbu = tabButtonGroup.transform.Find("toggles/quanbu").GetComponent<GameUUToggle>();
                tabButtonGroup.AddToggle(quanbu);    
            }
            if (tabButtonGroup.transform.Find("toggles/zhuangbei") != null)
            {
                GameUUToggle zhuangbei = tabButtonGroup.transform.Find("toggles/zhuangbei").GetComponent<GameUUToggle>();
                tabButtonGroup.AddToggle(zhuangbei);
            }
            if (tabButtonGroup.transform.Find("toggles/cailiao") != null)
            {
                GameUUToggle cailiao = tabButtonGroup.transform.Find("toggles/cailiao").GetComponent<GameUUToggle>();
                tabButtonGroup.AddToggle(cailiao);
            }
            if (tabButtonGroup.transform.Find("toggles/daoju") != null)
            {
                GameUUToggle daoju = tabButtonGroup.transform.Find("toggles/daoju").GetComponent<GameUUToggle>();
                tabButtonGroup.AddToggle(daoju);
            }

            if (tabButtonGroup.transform.Find("toggles/xianfu") != null)
            {
                GameUUToggle xianfu = tabButtonGroup.transform.Find("toggles/xianfu").GetComponent<GameUUToggle>();
                tabButtonGroup.AddToggle(xianfu);
            }

            if (tabButtonGroup.transform.Find("toggles/chibang") != null)
            {
                GameUUToggle chibang = tabButtonGroup.transform.Find("toggles/chibang").GetComponent<GameUUToggle>();
                tabButtonGroup.AddToggle(chibang);
            }
        }
        if (transform.Find("Image/scrollRect/itemGrid") != null)
        {
            itemTBG = transform.Find("Image/scrollRect/itemGrid").GetComponent<TabButtonGroup>();
        }
        itemGrid = transform.Find("Image/scrollRect/itemGrid").GetComponent<GridLayoutGroup>();

        defaultItemUI = transform.Find("Image/scrollRect/itemGrid/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        GameUUToggle gameuutoggle=null;
        if (defaultItemUI.transform.Find("Toggle")!=null)
        {
            gameuutoggle = defaultItemUI.transform.Find("Toggle").GetComponent<GameUUToggle>();
        }
        if (transform.Find("jinzidi") != null)
        {
            jinzidi = transform.Find("jinzidi").gameObject;
        }
        if (transform.Find("yinzidi") != null)
        {
            yinzidi = transform.Find("yinzidi").gameObject;
        }
        Image yizhuangbei = null;
        if (defaultItemUI.transform.Find("Image (1)")!=null)
        {
            yizhuangbei = defaultItemUI.transform.Find("Image (1)").GetComponent<Image>();
        }
        
        defaultItemUI.Init
        (
            defaultItemUI.transform.Find("Image").GetComponent<Image>(),
            defaultItemUI.transform.Find("Icon").GetComponent<Image>(),
            defaultItemUI.transform.Find("BianKuang").GetComponent<Image>(),
            defaultItemUI.transform.Find("Num").GetComponent<Text>(),
            null,
            null, null, gameuutoggle, null, yizhuangbei
        );
        
        jinzi = transform.Find("jinzi").gameObject.AddComponent<MoneyItemUI>();
        jinzi.Init
        (
            jinzi.transform.Find("Image").GetComponent<Image>(),
            jinzi.transform.Find("Text").GetComponent<Text>(),
            null
        );
        yinzi = transform.Find("yinzi").gameObject.AddComponent<MoneyItemUI>();
        yinzi.Init
        (
            yinzi.transform.Find("Image").GetComponent<Image>(),
            yinzi.transform.Find("Text").GetComponent<Text>(),
            null
        );
        jinpiao = transform.Find("jinpiao").gameObject.AddComponent<MoneyItemUI>();
        jinpiao.Init
        (
            jinpiao.transform.Find("Image").GetComponent<Image>(),
            jinpiao.transform.Find("Text").GetComponent<Text>(),
            null
        );
        yinpiao = transform.Find("yinpiao").gameObject.AddComponent<MoneyItemUI>();
        yinpiao.Init
        (
            yinpiao.transform.Find("Image").GetComponent<Image>(),
            yinpiao.transform.Find("Text").GetComponent<Text>(),
            null
        );
        
        Transform payBtnGo = transform.Find("jia");
        if (payBtnGo != null)
        {
            payBtn = payBtnGo.gameObject.GetComponent<GameUUButton>();
        }
        
    }

}
