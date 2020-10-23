using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class PaiMaiHangPetUI : MonoBehaviour
{
    public GameUUButton closeBtn;
    public Image biankuang;
    public Image icon;
    public Text petName;
    public Text petLevel;
    public Text pingfen;

    public TabButtonGroup tabButtonGroup;
    public GameObject jinengGo;
    public GameObject zizhiGo;
    public GameObject propGo;

    public Text defaultPropItem;
    public CommonItemUI defaultSkillItem;
	public List<ProgressBar> zizhiPGList = new List<ProgressBar>();

    public GameObject shangjiafeiyong;
    public MoneyItemUI shangjiaCost;
	public Text chushouzhong;

    public GameObject feiyongobj;
    public GameObject chushoujiageobj;
    public InputTextUI chushoujiage;

    public GameUUButton quxiaoBtn;
    public GameUUButton xiajiaBtn;
    public GameUUButton shangjiaBtn;
    public GameUUButton zhanshiBtn;

    public void Init()
    {
    closeBtn=transform.Find("bg/UpContent/closeBtn").GetComponent<GameUUButton>();
    biankuang=transform.Find("bg/UpContent/CommonItemUI/biankuang").GetComponent<UnityEngine.UI.Image>();
    icon=transform.Find("bg/UpContent/CommonItemUI/Icon").GetComponent<Image>();
    petName=transform.Find("bg/UpContent/equipName").GetComponent<UnityEngine.UI.Text>();
    petLevel=transform.Find("bg/UpContent/equipLevel").GetComponent<UnityEngine.UI.Text>();
    pingfen=transform.Find("bg/UpContent/equipPingFen").GetComponent<UnityEngine.UI.Text>();
    tabButtonGroup=transform.Find("bg/MidContent/GameObject").gameObject.AddComponent<TabButtonGroup>();
    tabButtonGroup.Init();
    tabButtonGroup.AddToggle(tabButtonGroup.transform.Find("Toggle").GetComponent<GameUUToggle>());
    tabButtonGroup.AddToggle(tabButtonGroup.transform.Find("Toggle 1").GetComponent<GameUUToggle>());
    tabButtonGroup.AddToggle(tabButtonGroup.transform.Find("Toggle 2").GetComponent<GameUUToggle>());

    jinengGo=transform.Find("bg/MidContent/PropBList/jineng").gameObject;
    zizhiGo=transform.Find("bg/MidContent/PropBList/zizhiSkill").gameObject;
    propGo=transform.Find("bg/MidContent/PropBList/shuxing").gameObject;
    defaultPropItem=transform.Find("bg/MidContent/PropBList/shuxing/Text").GetComponent<UnityEngine.UI.Text>();
    defaultSkillItem=transform.Find("bg/MidContent/PropBList/jineng/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
    defaultSkillItem.Init();
    
    zizhiPGList = new List<ProgressBar>();
    ProgressBar pb1 = transform.Find("bg/MidContent/PropBList/zizhiSkill/pgGrid/Progress Bar").gameObject.AddComponent<ProgressBar>();
    pb1.Init(
        pb1.transform.Find("background").GetComponent<Image>(),
        pb1.transform.Find("background/foreground").GetComponent<Image>(), 
        pb1.transform.Find("Text").GetComponent<Text>(), 
       305
    );
    ProgressBar pb2 = transform.Find("bg/MidContent/PropBList/zizhiSkill/pgGrid/Progress Bar 1").gameObject.AddComponent<ProgressBar>();
    pb2.Init(
        pb2.transform.Find("background").GetComponent<Image>(),
        pb2.transform.Find("background/foreground").GetComponent<Image>(), 
        pb2.transform.Find("Text").GetComponent<Text>(),  
        305
    );
    ProgressBar pb3 = transform.Find("bg/MidContent/PropBList/zizhiSkill/pgGrid/Progress Bar 2").gameObject.AddComponent<ProgressBar>();
    pb3.Init(
        pb3.transform.Find("background").GetComponent<Image>(),
        pb3.transform.Find("background/foreground").GetComponent<Image>(), 
        pb3.transform.Find("Text").GetComponent<Text>(),  
        305
    );
    ProgressBar pb4 = transform.Find("bg/MidContent/PropBList/zizhiSkill/pgGrid/Progress Bar 3").gameObject.AddComponent<ProgressBar>();
    pb4.Init(
        pb4.transform.Find("background").GetComponent<Image>(),
        pb4.transform.Find("background/foreground").GetComponent<Image>(), 
        pb4.transform.Find("Text").GetComponent<Text>(),  
       305
    );
    ProgressBar pb5 = transform.Find("bg/MidContent/PropBList/zizhiSkill/pgGrid/Progress Bar 4").gameObject.AddComponent<ProgressBar>();
    pb5.Init(
        pb5.transform.Find("background").GetComponent<Image>(),
        pb5.transform.Find("background/foreground").GetComponent<Image>(), 
        pb5.transform.Find("Text").GetComponent<Text>(),  
       305
    );
    zizhiPGList.Add(pb1);
    zizhiPGList.Add(pb2);
    zizhiPGList.Add(pb3);
    zizhiPGList.Add(pb4);
    zizhiPGList.Add(pb5);
    feiyongobj = transform.Find("bg/MidContent/shangjiaFeiyong").gameObject;
    shangjiafeiyong=transform.Find("bg/MidContent/shangjiaFeiyong/GameObject").gameObject;
    shangjiaCost=transform.Find("bg/MidContent/shangjiaFeiyong/GameObject/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
    shangjiaCost.Init
    (
            shangjiaCost.transform.Find("Image").GetComponent<Image>(),
            shangjiaCost.transform.Find("Text").GetComponent<Text>(),
            null    
    );
    chushouzhong=transform.Find("bg/MidContent/shangjiaFeiyong/chushouzhong").GetComponent<UnityEngine.UI.Text>();

    chushoujiage=transform.Find("bg/MidContent/chushoujiage/InputTextUI").gameObject.AddComponent<InputTextUI>();
        MoneyItemUI m1 = chushoujiage.transform.Find("MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        m1.Init
        (
            m1.transform.Find("Image").GetComponent<Image>(),
            m1.transform.Find("Text").GetComponent<Text>(),
            m1.transform.Find("bg").GetComponent<Image>()  
        );
        chushoujiage.Init
        (
            chushoujiage.transform.Find("jianBtn").GetComponent<GameUUButton>(),
            chushoujiage.transform.Find("jiaBtn").GetComponent<GameUUButton>(),
            chushoujiage.transform.Find("MoneyItem/Text").GetComponent<Text>(),
            m1.moneyIcon, m1.inputBg
        );

    chushoujiageobj = transform.Find("bg/MidContent/chushoujiage").gameObject;
    quxiaoBtn=transform.Find("bg/DownContent/quxiao").GetComponent<GameUUButton>();
    xiajiaBtn=transform.Find("bg/DownContent/xiajia").GetComponent<GameUUButton>();
    shangjiaBtn=transform.Find("bg/DownContent/shangjia").GetComponent<GameUUButton>();
    zhanshiBtn = transform.Find("bg/DownContent/zhanshi").GetComponent<GameUUButton>();
    biankuang.gameObject.SetActive(false);
    chushouzhong.gameObject.SetActive(false);
    icon.gameObject.SetActive(false);
        }
}
