using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BangPaiJianSheUI : MonoBehaviour 
{
    public ToggleGroup toggleGroup;
    public TabButtonGroup tabButtonGroup;
    public Text textTarget;
    public GameObject objNeedExp;
    public ProgressBar needExpProgressbar;
    public GameObject objNeedMoney;
    public ProgressBar needMoneyProgressbar;
    public GameObject objShengjiZhong;
    public Text textRemainTime;
    public GameUUButton buttonUpgrade;
    public Text textBuildingDesc;
    public GameObject objTopLevel;


    public void Init()
    {

        toggleGroup = transform.Find("toggleGroup").GetComponent<ToggleGroup>();
        tabButtonGroup = toggleGroup.gameObject.AddComponent<TabButtonGroup>();
        {
            tabButtonGroup.AddToggle(toggleGroup.transform.Find("toggle_bangpai").GetComponent<GameUUToggle>());
            tabButtonGroup.AddToggle(toggleGroup.transform.Find("toggle_qinglongtang").GetComponent<GameUUToggle>());
            tabButtonGroup.AddToggle(toggleGroup.transform.Find("toggle_baihutang").GetComponent<GameUUToggle>());
            tabButtonGroup.AddToggle(toggleGroup.transform.Find("toggle_zhuquetang").GetComponent<GameUUToggle>());
            tabButtonGroup.AddToggle(toggleGroup.transform.Find("toggle_xuanwutang").GetComponent<GameUUToggle>());
            tabButtonGroup.AddToggle(toggleGroup.transform.Find("toggle_yangshengtang").GetComponent<GameUUToggle>());
            tabButtonGroup.AddToggle(toggleGroup.transform.Find("toggle_shijiantang").GetComponent<GameUUToggle>());
        }
        textTarget = transform.Find("RawImageBg/Text_dengji").GetComponent<Text>();
        objNeedExp = transform.Find("RawImageBg/needExp").gameObject;
        needExpProgressbar = objNeedExp.gameObject.AddComponent<ProgressBar>();
        needExpProgressbar.Init(
            needExpProgressbar.transform.Find("background").GetComponent<Image>(),
            needExpProgressbar.transform.Find("foreground").GetComponent<Image>(),
            needExpProgressbar.transform.Find("Text").GetComponent<Text>(),
            338
            );
        objNeedMoney = transform.Find("RawImageBg/needMoney").gameObject;
        needMoneyProgressbar = objNeedMoney.gameObject.AddComponent<ProgressBar>();
        needMoneyProgressbar.Init(
            needMoneyProgressbar.transform.Find("background").GetComponent<Image>(),
            needMoneyProgressbar.transform.Find("foreground").GetComponent<Image>(),
            needMoneyProgressbar.transform.Find("Text").GetComponent<Text>(),
            338f
            );
        objShengjiZhong = transform.Find("RawImageBg/shijizhongGo").gameObject;
        textRemainTime = objShengjiZhong.transform.Find("Text_remainTime").GetComponent<Text>();
        buttonUpgrade = transform.Find("RawImageBg/Button0").GetComponent<GameUUButton>();
        textBuildingDesc = transform.Find("RawImageBg/Text_desc").GetComponent<Text>();

        objTopLevel = transform.Find("RawImageBg/Image_topLevel").gameObject;
    }
}
