using UnityEngine;
using UnityEngine.UI;

public class ChatMsgItemUI : MonoBehaviour
{
    public VerticalLayoutGroup UIVerticalLayout;
    public VerticalLayoutGroup contentVerticalLayout;

    public CommonItemUI headItem;

    public Image headIcon;
    public Image vipsign;
    public Text channelName;
    public Text roleName;

    public VerticalLayoutGroup duifangMsgGo;
    public VerticalLayoutGroup selfMsgGo;

    public GameObject duifangContent;
    public GameObject selfContent;
    public UGUIRichTextOptimized duifangText;
    public UGUIRichTextOptimized selfText;

    public GameObject duifangYuyinGo;
    public GameUUButton duifangYuyinBtn;
    public Text duifangYuyinTimeText;

    public GameObject selfYuyinGo;
    public GameUUButton selfYuyinBtn;
    public Text selfYuyinTimeText;

    public void Init(VerticalLayoutGroup UIVerticalLayout,
        VerticalLayoutGroup contentVerticalLayout,
        Image headIcon,
        Image vipsignv,
        Text channelName,
        Text roleName,
        VerticalLayoutGroup duifangMsgGo,
        VerticalLayoutGroup selfMsgGo,
        GameObject duifangContent,
        GameObject selfContent,
        GameObject duifangYuyinGo,
        GameUUButton duifangYuyinBtn,
        Text duifangYuyinTimeText,
        GameObject selfYuyinGo,
        GameUUButton selfYuyinBtn,
        Text selfYuyinTimeText)
    {
        this.UIVerticalLayout = UIVerticalLayout;
        this.contentVerticalLayout = contentVerticalLayout;
        this.headIcon = headIcon;
        this.vipsign = vipsignv;
        if(vipsign!=null)vipsign.gameObject.SetActive(false);
        this.channelName = channelName;
        this.roleName = roleName;
        this.duifangMsgGo = duifangMsgGo;
        this.selfMsgGo = selfMsgGo;
        this.duifangContent = duifangContent;
        this.selfContent = selfContent;
        this.duifangYuyinGo = duifangYuyinGo;
        this.duifangYuyinBtn = duifangYuyinBtn;
        this.duifangYuyinTimeText = duifangYuyinTimeText;
        this.selfYuyinGo = selfYuyinGo;
        this.selfYuyinBtn = selfYuyinBtn;
        this.selfYuyinTimeText = selfYuyinTimeText;
    }

    public void Init(){
        UIVerticalLayout = this.transform.GetComponent<VerticalLayoutGroup>();
        contentVerticalLayout = transform.Find("chatVertical").GetComponent<VerticalLayoutGroup>();

        if (transform.Find("CommonItemUI82_82") != null)
        {
            headItem = transform.Find("CommonItemUI82_82").gameObject.AddComponent<CommonItemUI>();
            headItem.Init();
        }
        Transform headIcon = transform.Find("CommonItemUI82_82/Icon"); 
        if (headIcon != null)
        {
            this.headIcon = headIcon.GetComponent<Image>();
        }
        Transform vipsignt = transform.Find("CommonItemUI82_82/vipsign");
        if (vipsignt!=null)
        {
            this.vipsign = vipsignt.GetComponent<Image>();
        }
        if (vipsign != null) vipsign.gameObject.SetActive(false);
        Transform channelName = transform.Find("chatVertical/title/channelTitle");
        if (channelName != null)
        {
            this.channelName = channelName.GetComponent<Text>();
        }
        
        Transform roleName = transform.Find("chatVertical/title/playerNameText");
        if (roleName != null)
        {
            this.roleName = roleName.GetComponent<Text>();
        }
        
        Transform duifangMsgGo = transform.Find("chatVertical/chatMsg");
        if (duifangMsgGo != null)
        {
            this.duifangMsgGo = duifangMsgGo.GetComponent<VerticalLayoutGroup>();
        }
        
        Transform selfMsgGo = transform.Find("chatVertical/chatMsg 1");
        if (selfMsgGo != null)
        {
            this.selfMsgGo = selfMsgGo.GetComponent<VerticalLayoutGroup>();
        }
        
        Transform duifangContent1 = transform.Find("chatVertical/chatMsg/content");
        if (duifangContent1 != null)
        {
            this.duifangContent = duifangContent1.gameObject;
        }

        Transform selfContent1 = transform.Find("chatVertical/chatMsg 1/content");
        if (selfContent1 != null)
        {
            this.selfContent = selfContent1.gameObject;
        }
        
        Transform duifangYuyinGo = transform.Find("chatVertical/chatMsg/yuyin");
        if (duifangYuyinGo != null)
        {
            this.duifangYuyinGo = duifangYuyinGo.gameObject;
        }
        
        Transform duifangYuyinBtn = transform.Find("chatVertical/chatMsg/yuyin/duifangyuyinBtn");
        if (duifangYuyinBtn != null)
        {
            this.duifangYuyinBtn = duifangYuyinBtn.GetComponent<GameUUButton>();
        }
        
        Transform duifangYuyinTimeText = transform.Find("chatVertical/chatMsg/yuyin/duifangyuyinBtn/Text");
        if (duifangYuyinTimeText != null)
        {
            this.duifangYuyinTimeText = duifangYuyinTimeText.GetComponent<Text>();
        }
        
        Transform selfYuyinGo = transform.Find("chatVertical/chatMsg 1/yuyin 1");
        if (selfYuyinGo != null)
        {
            this.selfYuyinGo = selfYuyinGo.gameObject;
        }
        
        Transform selfYuyinBtn = transform.Find("chatVertical/chatMsg 1/yuyin 1/selfYuyinBtn");
        if (selfYuyinBtn != null)
        {
            this.selfYuyinBtn = selfYuyinBtn.GetComponent<GameUUButton>();
        }
        
        Transform selfYuyinTimeText = transform.Find("chatVertical/chatMsg 1/yuyin 1/selfYuyinBtn/Text");
        if (selfYuyinTimeText != null)
        {
            this.selfYuyinTimeText = selfYuyinTimeText.GetComponent<Text>();
        }
    }
    /*
    public void Init(int k){
       UIVerticalLayout = this.transform.GetComponent<VerticalLayoutGroup>();
        contentVerticalLayout = transform.Find("chatVertical").gameObject.AddComponent<VerticalLayoutGroup>();
        // headIcon 
        channelName = transform.Find("chatVertical/title/channelTitle").GetComponent<Text>();
        roleName = transform.Find("chatVertical/title/playerNameText").GetComponent<Text>();
        duifangMsgGo = transform.Find("chatVertical/chatMsg").gameObject.AddComponent<VerticalLayoutGroup>();
        // selfMsgGo
        duifangContent = transform.Find("chatVertical/chatMsg/content").GetComponent<Text>();
        // selfContent
        // duifangYuyinGo
        // duifangYuyinBtn
        // duifangYuyinTimeText
        // selfYuyinGo
        // selfYuyinBtn
        // selfYuyinTimeText
        
    }
    */
}
