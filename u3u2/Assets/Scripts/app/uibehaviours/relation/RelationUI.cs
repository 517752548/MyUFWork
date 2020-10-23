using app.utils;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class RelationUI : MonoBehaviour
{
    public GameUUButton closeBtn;
    public TabButtonGroup lefttopBtn;
    public Text panelTitle;
    public Text shuomingText;
    //最近联系人
    public UIMonoBehaviour zuijinGo;
    public VerticalLayoutGroup zuijinGrid;
    public TabButtonGroup zuijinTBG;
    public RelationItemUI defaultZuijinItem;
    //联系人（好友 ，黑名单）
    public UIMonoBehaviour lianxirenGo;
    public VerticalLayoutGroup LianxirenGrid;
    public VerticalLayoutGroup whiteListGrid;
    public VerticalLayoutGroup blackListGrid;
    public TabButtonGroup haoyouTBG;
    public TabButtonGroup heimingdanTBG;
    public TabButtonGroup mainToggleTBG;
    public GameUUToggle haoyouToggle;
    public GameUUToggle heimingdanToggle;
    public RelationItemUI defaultLianxirenItem;
    //邮件
    public UIMonoBehaviour mailGo;
    public GridLayoutGroup mailGrid;
    public TabButtonGroup mailTBG;
    public RelationItemUI defaultmailItem;
    public ScrollRect mailItemScroller;
    //添加好友按钮
    public GameUUButton addFriendBtn;
    //定位按钮
    public GameUUButton dingweiBtn;
    //主页按钮
    public GameUUButton zhuyeBtn;
    //右上角
    public UIMonoBehaviour youshangjiaoGo;
    public Image inputBg;
    public GameUUButton sendMsgBtn;
    public GameObject youshangBlackGo;
    public GameUUButton chazhaoBlackBtn;
    public GameUUButton smileBtn;
    //消息内容
    public UIMonoBehaviour MsgContent;
    public VerticalLayoutGroup msgLayout;
    public ChatMsgItemUI duifangMsg;
    //邮件内容
    public UIMonoBehaviour mailContentGo;
    public Text mailTitleText;
    public Text mailContentText;
    public GameObject jiangliGo;
    public GridLayoutGroup jiangliItemGrid;
    public CommonItemUI defaultJiangliItem;
    public GameUUButton lingquBtn;
    public Text lingquBtnText;
    //操作列表
    public GameObject operationListGo;
    public GridLayoutGroup operationGrid;
    public Image operationBg;
    public List<GameUUButton> operateBtnList;
    //public GameUUButton operationListGoBgBtn;
    public void Init()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        lefttopBtn = transform.Find("btngrid").gameObject.AddComponent<TabButtonGroup>();
        lefttopBtn.AddToggle(lefttopBtn.transform.Find("Toggle").GetComponent<GameUUToggle>());
        lefttopBtn.AddToggle(lefttopBtn.transform.Find("Toggle 1").GetComponent<GameUUToggle>());
        lefttopBtn.AddToggle(lefttopBtn.transform.Find("Toggle 2").GetComponent<GameUUToggle>());
        
        panelTitle = transform.Find("title").GetComponent<UnityEngine.UI.Text>();
        shuomingText = transform.Find("shuoming").GetComponent<UnityEngine.UI.Text>();
        addFriendBtn = transform.Find("addFriendBtn").GetComponent<GameUUButton>();
        
        dingweiBtn = transform.Find("ZZButton1").GetComponent<GameUUButton>();
        zhuyeBtn = transform.Find("ZZButton2").GetComponent<GameUUButton>();
        
        dingweiBtn.interactable = false;
        ColorUtil.Gray(dingweiBtn);
        zhuyeBtn.interactable = false;
        ColorUtil.Gray(zhuyeBtn);
        dingweiBtn.enabled = false;
        zhuyeBtn.enabled = false;
    }
    
    public bool lianxirenInited { get; private set; }
    public void InitLianXiRen()
    {
        lianxirenGo = transform.Find("LianXiRen").gameObject.AddComponent<UIMonoBehaviour>();
        LianxirenGrid = transform.Find("LianXiRen/grid").GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
        haoyouTBG = transform.Find("LianXiRen/grid").gameObject.AddComponent<TabButtonGroup>();
        whiteListGrid = transform.Find("LianXiRen/grid/whiteList").GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
        blackListGrid = transform.Find("LianXiRen/grid/blackList").GetComponent<UnityEngine.UI.VerticalLayoutGroup>();

        heimingdanTBG = transform.Find("LianXiRen/grid/MainToggle 1").gameObject.AddComponent<TabButtonGroup>();
        mainToggleTBG = transform.Find("LianXiRen").gameObject.AddComponent<TabButtonGroup>();
        mainToggleTBG.AddToggle(mainToggleTBG.transform.Find("grid/MainToggle/Toggle").GetComponent<GameUUToggle>());
        mainToggleTBG.AddToggle(mainToggleTBG.transform.Find("grid/MainToggle 1/Toggle").GetComponent<GameUUToggle>());

        haoyouToggle = transform.Find("LianXiRen/grid/MainToggle/Toggle").GetComponent<GameUUToggle>();
        heimingdanToggle = transform.Find("LianXiRen/grid/MainToggle 1/Toggle").GetComponent<GameUUToggle>();
        defaultLianxirenItem = transform.Find("LianXiRen/grid/equipItem").gameObject.AddComponent<RelationItemUI>();
        defaultLianxirenItem.Init();
        lianxirenGo.Init();
        lianxirenGo.Hide();
        defaultLianxirenItem.gameObject.SetActive(false);
        lianxirenInited = true;
    }
    
    public bool mailInited { get; private set; }
    public void InitMail()
    {
        mailGo = transform.Find("Mail").gameObject.AddComponent<UIMonoBehaviour>();
        mailGrid = transform.Find("Mail/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        mailTBG = transform.Find("Mail/grid").gameObject.AddComponent<TabButtonGroup>();
        defaultmailItem = transform.Find("Mail/grid/equipItem").gameObject.AddComponent<RelationItemUI>();
        defaultmailItem.Init();
        mailGo.Init();
        mailGo.Hide();
        mailInited = true;
    }
    
    public bool mailContentInited { get; private set; }
    public void InitMailContent()
    {
        mailContentGo = transform.Find("MailContent").gameObject.AddComponent<UIMonoBehaviour>();
        mailTitleText = transform.Find("MailContent/title").GetComponent<UnityEngine.UI.Text>();
        mailContentText = transform.Find("MailContent/Scroller/youjianNeirong").GetComponent<UnityEngine.UI.Text>();
        jiangliGo = transform.Find("MailContent/jiangli").gameObject;
        jiangliItemGrid = transform.Find("MailContent/jiangli/scroller/ItemList").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        defaultJiangliItem = transform.Find("MailContent/jiangli/scroller/ItemList/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        defaultJiangliItem.Init
        (
            defaultJiangliItem.transform.Find("Image").GetComponent<Image>(),
            defaultJiangliItem.transform.Find("Icon").GetComponent<Image>(),
            defaultJiangliItem.transform.Find("BianKuang").GetComponent<Image>(),
            defaultJiangliItem.transform.Find("Num").GetComponent<Text>(),
            //defaultJiangliItem.transform.Find("Name").GetComponent<Text>(),
            null,null,null, null, null, null
            //defaultJiangliItem.transform.Find("xing").gameObject,
            //defaultJiangliItem.transform.Find("xing/Text").GetComponent<Text>(),
            //defaultJiangliItem.transform.Find("Toggle").GetComponent<GameUUToggle>(), null, null
        );
        //defaultJiangliItem.Xing.SetActive(false);
        //defaultJiangliItem.SelectedToggle.gameObject.SetActive(false);
        lingquBtn = transform.Find("MailContent/jiangli/lingquBtn").GetComponent<GameUUButton>();
        lingquBtnText = transform.Find("MailContent/jiangli/lingquBtn/Text").GetComponent<UnityEngine.UI.Text>();
        mailItemScroller = transform.Find("MailContent/jiangli/scroller").GetComponent<UnityEngine.UI.ScrollRect>();
        mailItemScroller.gameObject.SetActive(false);
        mailContentGo.Init();
        mailContentGo.Hide();
        mailContentInited = true;
    }
    
    public bool msgContentInited { get; private set; }
    public void InitMsgContent()
    {
        MsgContent = transform.Find("msgContent").gameObject.AddComponent<UIMonoBehaviour>();
        msgLayout = transform.Find("msgContent/scrollRect/scrollContent").GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
        duifangMsg = transform.Find("msgContent/scrollRect/scrollContent/chatItem").gameObject.AddComponent<ChatMsgItemUI>();
        duifangMsg.Init(
            duifangMsg.transform.GetComponent<VerticalLayoutGroup>(),
            duifangMsg.transform.Find("chatVertical").GetComponent<VerticalLayoutGroup>(),
            duifangMsg.transform.Find("CommonItemUI82_82/Icon").GetComponent<Image>(),
            duifangMsg.transform.Find("CommonItemUI82_82/vipsign").GetComponent<Image>(),
            null,
            duifangMsg.transform.Find("chatVertical/title/playerNameText").GetComponent<Text>(),
            duifangMsg.transform.Find("chatVertical/chatMsg").GetComponent<VerticalLayoutGroup>(),
            duifangMsg.transform.Find("chatVertical/chatMsg 1").GetComponent<VerticalLayoutGroup>(),
            duifangMsg.transform.Find("chatVertical/chatMsg/content").gameObject,
            duifangMsg.transform.Find("chatVertical/chatMsg 1/content").gameObject,
            duifangMsg.transform.Find("chatVertical/chatMsg/yuyin").gameObject,
            duifangMsg.transform.Find("chatVertical/chatMsg/yuyin/duifangyuyinBtn").GetComponent<GameUUButton>(),
            duifangMsg.transform.Find("chatVertical/chatMsg/yuyin/duifangyuyinBtn/Text").GetComponent<Text>(),
            duifangMsg.transform.Find("chatVertical/chatMsg 1/yuyin 1").gameObject,
            duifangMsg.transform.Find("chatVertical/chatMsg 1/yuyin 1/selfYuyinBtn").GetComponent<GameUUButton>(),
            duifangMsg.transform.Find("chatVertical/chatMsg 1/yuyin 1/selfYuyinBtn/Text").GetComponent<Text>()

            );
        //duifangMsg.transform.Find("CommonItemUI82_82/BianKuang").gameObject.SetActive(false);
        MsgContent.Init();
        msgContentInited = true;
    }
    
    public bool operationListInited { get; private set; }
    public void InitOperationList()
    {
        operationListGo = transform.Find("operationList").gameObject;
        operationGrid = transform.Find("operationList/downListBg/downList").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        operationBg = transform.Find("operationList/downListBg").GetComponent<UnityEngine.UI.Image>();
        operateBtnList = new List<GameUUButton>();
        operateBtnList.Add(transform.Find("operationList/downListBg/downList/Button").GetComponent<GameUUButton>());
        operateBtnList.Add(transform.Find("operationList/downListBg/downList/Button 1").GetComponent<GameUUButton>());
        operateBtnList.Add(transform.Find("operationList/downListBg/downList/Button 2").GetComponent<GameUUButton>());
        operateBtnList.Add(transform.Find("operationList/downListBg/downList/Button 3").GetComponent<GameUUButton>());
        operateBtnList.Add(transform.Find("operationList/downListBg/downList/Button 4").GetComponent<GameUUButton>());
        operateBtnList.Add(transform.Find("operationList/downListBg/downList/Button 5").GetComponent<GameUUButton>());
        operateBtnList.Add(transform.Find("operationList/downListBg/downList/Button 6").GetComponent<GameUUButton>());
        //operationListGoBgBtn = operationListGo.transform.Find("bg_btn").GetComponent<GameUUButton>();
        operationListInited = true;
    }
    
    public bool sendMsgGoInited { get; private set; }
    public void InitSendMsgGo()
    {
        youshangjiaoGo = transform.Find("sengMsgGo").gameObject.AddComponent<UIMonoBehaviour>();
        inputBg = transform.Find("sengMsgGo/inputTextBg").GetComponent<UnityEngine.UI.Image>();
        sendMsgBtn = transform.Find("sengMsgGo/sendBtn").GetComponent<GameUUButton>();
        youshangBlackGo = transform.Find("sengMsgGo/blackGo").gameObject;
        chazhaoBlackBtn = transform.Find("sengMsgGo/blackGo/findBlackBtn").GetComponent<GameUUButton>();
        smileBtn = transform.Find("sengMsgGo/smileBtn").GetComponent<GameUUButton>();
        //smileBtn.interactable = false;
        //smileBtn.enabled = false;
        //ColorUtil.Gray(smileBtn);
        youshangjiaoGo.Init();
        sendMsgGoInited = true;
    }
    
    public bool zuiJinLianXiInited { get; private set; }
    public void InitZuiJinLianXi()
    {
        zuijinGo = transform.Find("ZuiJinLianXi").gameObject.AddComponent<UIMonoBehaviour>();
        zuijinGrid = transform.Find("ZuiJinLianXi/grid").GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
        zuijinTBG = transform.Find("ZuiJinLianXi/grid").gameObject.AddComponent<TabButtonGroup>();
        defaultZuijinItem = transform.Find("ZuiJinLianXi/grid/equipItem").gameObject.AddComponent<RelationItemUI>();
        defaultZuijinItem.Init();
        zuijinGo.Init();
        zuijinGo.Hide();
        zuiJinLianXiInited = true;
    }
}