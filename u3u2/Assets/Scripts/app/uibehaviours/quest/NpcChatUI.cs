using UnityEngine;
using UnityEngine.UI;

public class NpcChatUI : UIMonoBehaviour
{

    public Text NpcNameText;
    
    public GameObject doThings;
    //public RectTransform doThingsTargetPos;

    //public VerticalLayoutGroup doThingsBtnGrid;
    
    //public GameObject defaultBtnContainer;
    public GameUUButton defaultBtn;
    
    public RectTransform leftNpcBodyRTF;
    //public RectTransform leftNpcBodyTargetPos;
    public Text leftNpcChatText;

    public RectTransform rightNpcBodyRTF;
    //public RectTransform rightNpcBodyTargetPos;
    public Text rightNpcChatText;
    //public GameObject chatContainer;
    //public RectTransform chatContainerTargetPos;

    public int oneButtonHeight=140;

    public int perButtonHeight = 64;
    //public GameObject juqingContainer;
    public GameUUButton tiaoguoJuqing;

    public override void Init()
     {
        base.Init();
        NpcNameText=transform.Find("npcName").GetComponent<UnityEngine.UI.Text>();
        doThings=transform.Find("DoThings").gameObject;
        //doThingsTargetPos = transform.Find("DoThingsTargetPos").GetComponent<UnityEngine.RectTransform>();
        //doThingsBtnGrid=transform.Find("DoThings/Image/GameObject").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        //doThingsBtnGrid=transform.Find("DoThings").GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
        //defaultBtnContainer=transform.Find("DoThings/Image/GameObject/ButtonContainer").gameObject;
        //defaultBtnContainer=doThings;
        defaultBtn = transform.Find("DoThings/Button").GetComponent<GameUUButton>();
        leftNpcBodyRTF = transform.Find("leftNpcBody").GetComponent<UnityEngine.RectTransform>();
        //leftNpcBodyTargetPos = transform.Find("leftNpcBodyTargetPos").GetComponent<UnityEngine.RectTransform>();
        leftNpcChatText=transform.Find("leftNpcChatText").GetComponent<UnityEngine.UI.Text>();
        rightNpcBodyRTF = transform.Find("rightNpcBody").GetComponent<UnityEngine.RectTransform>();
        //rightNpcBodyTargetPos = transform.Find("rightNpcBodyTargetPos").GetComponent<UnityEngine.RectTransform>();
        rightNpcChatText=transform.Find("rightNpcChatText").GetComponent<UnityEngine.UI.Text>();
        //chatContainer=transform.gameObject;
        //chatContainerTargetPos = transform.Find("BgTargetPos").GetComponent<UnityEngine.RectTransform>();
        //juqingContainer=transform.Find("juqingContainer").gameObject;
        tiaoguoJuqing=transform.Find("tiaoguoBtn").GetComponent<GameUUButton>();
        rightNpcChatText.gameObject.SetActive(false);

        GetComponent<RectTransform>().sizeDelta = new Vector2(UGUIConfig.UISpaceWidth, UGUIConfig.UISpaceHeight);
    }

}
