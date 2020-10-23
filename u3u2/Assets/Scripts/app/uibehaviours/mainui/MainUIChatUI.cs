using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainUIChatUI : MonoBehaviour
{

    public GameUUButton openChatPanelBtn;
    public GameUUButton BangPailuyin;
    public GameUUButton Duiwuluyin;

    public UGUISwitchButton shousuoToggle;
    public GameUUButton shezhi;

    public GameObject chatContentText;
    public BoxCollider boxCollider;
    public LayoutElement chatContentLayout;
    public Image chatContentImage;
    public GameObject chatRect;
    public void Init()
    {
        openChatPanelBtn=transform.Find("TabButtonGroup/dakailiaotian").GetComponent<GameUUButton>();
        BangPailuyin=transform.Find("TabButtonGroup/bangpailuyin").GetComponent<GameUUButton>();
        Duiwuluyin=transform.Find("TabButtonGroup/duiwuluyin").GetComponent<GameUUButton>();
        shousuoToggle=transform.Find("Image/SwitchButton").gameObject.AddComponent<UGUISwitchButton>();
        shousuoToggle.Init
        (
            shousuoToggle.transform.Find("BackButton").GetComponent<GameUUButton>(),
            shousuoToggle.transform.Find("ForeButton").GetComponent<GameUUButton>(),
            null
        );
        shezhi=transform.Find("Image/btn/shezhiBtn").GetComponent<GameUUButton>();
        chatContentText=transform.Find("Image/chatRect/questTitleAndDesc").gameObject;
        chatContentLayout=transform.Find("Image").GetComponent<LayoutElement>();
        chatContentImage=transform.Find("Image/chatRect").GetComponent<Image>();

        boxCollider = chatContentLayout.gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        boxCollider.center = new Vector3(125, 45, 0);
        boxCollider.size = new Vector2(250,90);

        chatRect=transform.Find("Image/chatRect").gameObject;
    }
}
