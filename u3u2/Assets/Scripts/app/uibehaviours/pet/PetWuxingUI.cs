using UnityEngine;
using UnityEngine.UI;

public class PetWuxingUI : UIMonoBehaviour
{
    public Text wuxingLevel;
    public ProgressBar wuxingEXPBar;

    public Text lvNow;
    public Text lvNext;
    public Text propAddNow;
    public Text propAddNext;

    public GameObject chuji;
    public GameObject zhongji;
    public GameObject gaoji;

    public TabButtonGroup wuxingTishengType;

    public GameUUButton tishengBtn;
    public GameUUButton tisheng50Btn;
    public GameUUButton wuxininfoBtn;

	public GameObject upgradeContainer;
	public GameObject maxLvText;

    public GameObject chujiCost;
	public GameObject zhongjiCost;
	public GameObject gaojiCost;

    public Image zhongjiCheckBox;
    public Image gaojiCheckBox;
    public Text zhongjiLabel;
    public Text gaojiLabel;

    public override void Init()
     {
        base.Init();
    wuxingLevel=transform.Find("wuxingLevel").GetComponent<UnityEngine.UI.Text>();
    wuxingEXPBar=transform.Find("wuxingExpBar").gameObject.AddComponent<ProgressBar>();
     wuxingEXPBar.Init(
         wuxingEXPBar.transform.Find("background").GetComponent<Image>(),
        wuxingEXPBar.transform.Find("background/foreground").GetComponent<Image>(), 
        wuxingEXPBar.transform.Find("Text").GetComponent<Text>(), 
        204
     );
    lvNow=transform.Find("lvBeforeUpgrade").GetComponent<UnityEngine.UI.Text>();
    lvNext=transform.Find("tisheng/lvAfterUpgrade").GetComponent<UnityEngine.UI.Text>();
    propAddNow=transform.Find("propsBeforeUpgrade").GetComponent<UnityEngine.UI.Text>();
    propAddNext=transform.Find("tisheng/propsAfterUpgrade").GetComponent<UnityEngine.UI.Text>();
    chuji=transform.Find("tisheng/wuxingTishengType/chuji").gameObject;
    zhongji=transform.Find("tisheng/wuxingTishengType/zhongji").gameObject;
    gaoji=transform.Find("tisheng/wuxingTishengType/gaoji").gameObject;
    wuxingTishengType=transform.Find("tisheng/wuxingTishengType").gameObject.AddComponent<TabButtonGroup>();
    wuxingTishengType.AddToggle(transform.Find("tisheng/wuxingTishengType/chuji").gameObject.GetComponent<GameUUToggle>());
    wuxingTishengType.AddToggle(transform.Find("tisheng/wuxingTishengType/zhongji").gameObject.GetComponent<GameUUToggle>());
    wuxingTishengType.AddToggle(transform.Find("tisheng/wuxingTishengType/gaoji").gameObject.GetComponent<GameUUToggle>());
    tishengBtn=transform.Find("tisheng/tishengBtn").GetComponent<GameUUButton>();
    tisheng50Btn=transform.Find("tisheng/tisheng50Btn").GetComponent<GameUUButton>();
    wuxininfoBtn = transform.Find("ZZInfoButton").GetComponent<GameUUButton>();
    upgradeContainer=transform.Find("tisheng").gameObject;
    maxLvText=transform.Find("maxLvText").gameObject;
    maxLvText.SetActive(false);
    chujiCost=transform.Find("tisheng/chujiCost").gameObject;
    zhongjiCost=transform.Find("tisheng/zhongjiCost").gameObject;
    gaojiCost=transform.Find("tisheng/gaojiCost").gameObject;

    zhongjiCheckBox = transform.Find("tisheng/wuxingTishengType/zhongji/Background").GetComponent<Image>();
    gaojiCheckBox = transform.Find("tisheng/wuxingTishengType/gaoji/Background").GetComponent<Image>();
    zhongjiLabel = transform.Find("tisheng/wuxingTishengType/zhongji/BiaoTiText_22").GetComponent<Text>();
    gaojiLabel = transform.Find("tisheng/wuxingTishengType/gaoji/BiaoTiText_22").GetComponent<Text>();
     }

}