using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainUI : UIMonoBehaviour
{
    public MainUIUserInfoUI userInfo;
    public MainUIButtonUI mainuiButton;
    public MainUIMapUI mapUI;
    public MainUIQuestUI questUI;
    public MainUIChatUI chatUI;

    public GameUUButton bagua;
    public GameUUButton bagBtn;
    public GameUUButton friendBtn;
    public GameObject isRecording;

    public ProgressBar expProgressBar;
    public GridLayoutGroup expGrid;
    public ChatPanelUI chatPanelUI;

    public GameUUButton mapBtn;
    public ShiTuUI shituUI;
    public GameObject guideUseBtns;
    public GameUUButton payBtn;

    public Transform tfHulu;
    //public Text textDoublePoint;
    public MainButtonUI jingcaihuodongBtn;
    public MainButtonUI xianhuBtn;
    public MainButtonUI yuekaBtn;

    public override void Init()
    {
        base.Init();
        userInfo = transform.Find("userInfo").gameObject.AddComponent<MainUIUserInfoUI>();
        userInfo.Init();

        mainuiButton = transform.Find("mainButtons").gameObject.AddComponent<MainUIButtonUI>();
        mainuiButton.Init();

        mapUI = transform.Find("mapInfo").gameObject.AddComponent<MainUIMapUI>();
        mapUI.Init();

        questUI = transform.Find("questInfo").gameObject.AddComponent<MainUIQuestUI>();
        questUI.Init();

        chatUI = transform.Find("chatInfo").gameObject.AddComponent<MainUIChatUI>();
        chatUI.Init();

        bagua = transform.Find("mainButtons/bagua/Button").GetComponent<GameUUButton>();
        bagBtn = transform.Find("mainButtons/rightImage/rightBtns/beibaoBtnContainer/beibao").GetComponent<GameUUButton>();
        friendBtn = transform.Find("chatInfo/relationBtnContainer/relationBtn/friend").GetComponent<GameUUButton>();
        isRecording = transform.Find("luyinkuang").gameObject;

        expProgressBar = transform.Find("EXPProgressBar").gameObject.AddComponent<ProgressBar>();
        expProgressBar.Init
        (
            expProgressBar.transform.Find("background").GetComponent<Image>(),
            expProgressBar.transform.Find("foreground").GetComponent<Image>(),
            expProgressBar.transform.Find("Text").GetComponent<Text>(), (UGUIConfig.UISpaceWidth - 40));

        expGrid = transform.Find("EXPProgressBar/fengexian/grid").GetComponent<GridLayoutGroup>();
        chatPanelUI = transform.Find("chatPanel").gameObject.AddComponent<ChatPanelUI>();
        chatPanelUI.Init();

        mapBtn = transform.Find("mapInfo/mapBtn").GetComponent<GameUUButton>();
        shituUI = transform.Find("chatInfo/relationBtnContainer/shituUI").gameObject.AddComponent<ShiTuUI>();
        shituUI.Init();
        chatPanelUI.gameObject.SetActive(false);

        guideUseBtns = transform.Find("guideUseBtns").gameObject;
        guideUseBtns.SetActive(false);

        tfHulu = transform.Find("userInfo/roleInfo/Image_hulu");
        tfHulu.gameObject.SetActive(false);
        //textDoublePoint = transform.Find("topBtns/guajiBtnContainer/doublePoint").GetComponent<Text>();

        jingcaihuodongBtn = transform.Find("leftBtns/jingcaihuodongBtn/jiangli").gameObject.AddComponent<MainButtonUI>();
        jingcaihuodongBtn.Init();

        xianhuBtn = transform.Find("leftBtns/xianhuBtn/xianhu").gameObject.AddComponent<MainButtonUI>();
        xianhuBtn.Init();
        yuekaBtn = transform.Find("leftBtns/yuekaBtn/yueka").gameObject.AddComponent<MainButtonUI>();
        yuekaBtn.Init();
    }

}
