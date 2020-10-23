using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PaiMaiHangDaoJuUI : MonoBehaviour
{
    public GameUUButton closeButton;
    public CommonItemUI commonItemUI;
    public Text itemName;
    public Text itemType;
    public Text desc;
    public Text descDetail;

    public GameObject shangjiaFeiyong;
    public MoneyItemUI shangjiaFeiYongObj;

    public GameObject chushouShuliang;
    public InputTextUI shuliang;
    
    public GameObject chushouDanjia;
    public InputTextUI danjia;
    public Text tuijiaJiaGe;
    public GameObject chushouZongjia;
    public MoneyItemUI zongjia;
    
    public GameUUButton quxiaoBtn;
    public GameUUButton shangjiaBtn;
    public GameUUButton xiajiaBtn;

    public Text chushouZhong;
	
    public void Init()
     {
    closeButton=transform.Find("bg/UpContent/closeBtn").GetComponent<GameUUButton>();
    commonItemUI=transform.Find("bg/UpContent/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
    commonItemUI.Init
    (
        commonItemUI.transform.Find("Image").GetComponent<Image>(), 
        commonItemUI.transform.Find("Icon").GetComponent<Image>(),
        commonItemUI.transform.Find("BianKuang").GetComponent<Image>(),
        //commonItemUI.transform.Find("Num").GetComponent<Text>(),
        //commonItemUI.transform.Find("Name").GetComponent<Text>(),
        null,
        null,
        null,
        null, 
        null, 
        null, 
        null
    );

    itemName=transform.Find("bg/UpContent/equipName").GetComponent<UnityEngine.UI.Text>();
    itemType=transform.Find("bg/UpContent/daojuType").GetComponent<UnityEngine.UI.Text>();
    desc=transform.Find("bg/UpContent/Text 1").GetComponent<UnityEngine.UI.Text>();
    descDetail=transform.Find("bg/content/PropBList/PropBText").GetComponent<UnityEngine.UI.Text>();
    shangjiaFeiyong=transform.Find("bg/content/shangjiafeiyong").gameObject;
    shangjiaFeiYongObj=transform.Find("bg/content/shangjiafeiyong/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
    shangjiaFeiYongObj.Init
    (
         shangjiaFeiYongObj.transform.Find("Image").GetComponent<Image>(),
         shangjiaFeiYongObj.transform.Find("Text").GetComponent<Text>(),
         null
    );
    chushouShuliang=transform.Find("bg/content/chushoushuliang").gameObject;
    shuliang=transform.Find("bg/content/chushoushuliang/InputTextUI").gameObject.AddComponent<InputTextUI>();
    MoneyItemUI m1 = shuliang.transform.Find("MoneyItem").gameObject.AddComponent<MoneyItemUI>();
    m1.Init
    (
        m1.transform.Find("Image").GetComponent<Image>(),
        m1.transform.Find("Text").GetComponent<Text>(),
        m1.transform.Find("bg").GetComponent<Image>()
    );
    shuliang.Init
    (
        shuliang.transform.Find("jianBtn").GetComponent<GameUUButton>(),
        shuliang.transform.Find("jiaBtn").GetComponent<GameUUButton>(),
        shuliang.transform.Find("MoneyItem/Text").GetComponent<Text>(),
        m1.moneyIcon, m1.inputBg
    );
    chushouDanjia=transform.Find("bg/content/chushoudanjia").gameObject;
    danjia=transform.Find("bg/content/chushoudanjia/InputTextUI").gameObject.AddComponent<InputTextUI>();
    MoneyItemUI m2 = danjia.transform.Find("MoneyItem").gameObject.AddComponent<MoneyItemUI>();
    m2.Init
    (
        m2.transform.Find("Image").GetComponent<Image>(),
        m2.transform.Find("Text").GetComponent<Text>(),
        null
    );
    danjia.Init
    (
        danjia.transform.Find("jianBtn").GetComponent<GameUUButton>(),
        danjia.transform.Find("jiaBtn").GetComponent<GameUUButton>(),
        danjia.transform.Find("MoneyItem/Text").GetComponent<Text>(),
        m2.moneyIcon, m2.inputBg
    );
    tuijiaJiaGe=transform.Find("bg/content/jiagefudong").GetComponent<UnityEngine.UI.Text>();
    chushouZongjia=transform.Find("bg/content/chushouzongjia").gameObject;
    zongjia=transform.Find("bg/content/chushouzongjia/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
    zongjia.Init
    (
        zongjia.transform.Find("Image").GetComponent<Image>(),
        zongjia.transform.Find("Text").GetComponent<Text>(),
        null
    );
    quxiaoBtn=transform.Find("bg/content/DownContent/quxiao").GetComponent<GameUUButton>();
    shangjiaBtn=transform.Find("bg/content/DownContent/shangjia").GetComponent<GameUUButton>();
    xiajiaBtn=transform.Find("bg/content/DownContent/xiajia").GetComponent<GameUUButton>();
    chushouZhong=transform.Find("bg/content/chushouzhong").GetComponent<UnityEngine.UI.Text>();

        }
}
