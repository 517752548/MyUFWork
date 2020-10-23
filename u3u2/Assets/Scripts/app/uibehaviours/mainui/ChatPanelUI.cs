using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChatPanelUI : MonoBehaviour
{

    public GameUUButton CloseBtn;
    public GameUUButton luyingBtn;
    public GameUUButton biaoqingBtn;
    public GameUUButton fasongBtn;

    public Image inputBg;
    public TabButtonGroup channelTBG;
    public UGUISwitchButton suopingSBBtn;

    public VerticalLayoutGroup chatGrid;
    public ChatMsgItemUI defaultMsgItemUI;

    public GameObject fayanGo;
    public GameObject notFayanGo;
    public Text notFaYanText;

    public ChatMsgItemUI defaultSysMsgItemUI;

    //public GameObject biaoqingObj;
    //public TabButtonGroup tabButtonGroup;
    //public UIWrapContent wrapContent;
    public void Init()
    {
        CloseBtn=transform.Find("closeBtn").GetComponent<GameUUButton>();
        luyingBtn=transform.Find("fayanGo/luyin").GetComponent<GameUUButton>();
        biaoqingBtn=transform.Find("fayanGo/biaoqing").GetComponent<GameUUButton>();
        fasongBtn=transform.Find("fayanGo/fasong").GetComponent<GameUUButton>();
        inputBg=transform.Find("fayanGo/inputBg").GetComponent<Image>();
        channelTBG=transform.Find("tabBtnGroup").gameObject.AddComponent<TabButtonGroup>();
        GameUUToggle toggle1 = channelTBG.transform.Find("xitong").GetComponent<GameUUToggle>();
        GameUUToggle toggle2 = channelTBG.transform.Find("shijie").GetComponent<GameUUToggle>();
        GameUUToggle toggle3 = channelTBG.transform.Find("dangqian").GetComponent<GameUUToggle>();
        GameUUToggle toggle4 = channelTBG.transform.Find("bangpai").GetComponent<GameUUToggle>();
        GameUUToggle toggle5 = channelTBG.transform.Find("duiwu").GetComponent<GameUUToggle>();
        GameUUToggle toggle6 = channelTBG.transform.Find("zudui").GetComponent<GameUUToggle>();
        channelTBG.AddToggle(toggle1);
        channelTBG.AddToggle(toggle2);
        channelTBG.AddToggle(toggle3);
        channelTBG.AddToggle(toggle4);
        channelTBG.AddToggle(toggle5);
        channelTBG.AddToggle(toggle6);
        
        suopingSBBtn=transform.Find("suoping/SwitchButton").gameObject.AddComponent<UGUISwitchButton>();
        suopingSBBtn.Init
        (
            suopingSBBtn.transform.Find("BackButton").GetComponent<GameUUButton>(), 
            suopingSBBtn.transform.Find("ForeButton").GetComponent<GameUUButton>(), 
            suopingSBBtn.transform.Find("Text").GetComponent<Text>()
        );
        chatGrid=transform.Find("chatContent/scrollRect/scrollContent").GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
        defaultMsgItemUI=transform.Find("chatContent/scrollRect/scrollContent/chatItem").gameObject.AddComponent<ChatMsgItemUI>();
        defaultMsgItemUI.Init();
        fayanGo=transform.Find("fayanGo").gameObject;
        notFayanGo=transform.Find("notfayanGo").gameObject;
        notFaYanText=transform.Find("notfayanGo/Text").GetComponent<Text>();
        defaultSysMsgItemUI=transform.Find("chatContent/scrollRect/scrollContent/sysMsgItem").gameObject.AddComponent<ChatMsgItemUI>();
        defaultSysMsgItemUI.Init();
        //biaoqingObj=transform.Find("biaoqingUI").gameObject;
        //tabButtonGroup=transform.Find("biaoqingUI/tabBtnGroup").gameObject.AddComponent<TabButtonGroup>();
        //wrapContent = transform.Find("biaoqingUI/UIWrapContent/grid").gameObject.AddComponent<UIWrapContent>();
        //wrapContent.mObjItem = transform.Find("biaoqingUI/UIWrapContent/grid/RawImage").gameObject;
        //biaoqingObj.gameObject.SetActive(false);

    }
}
