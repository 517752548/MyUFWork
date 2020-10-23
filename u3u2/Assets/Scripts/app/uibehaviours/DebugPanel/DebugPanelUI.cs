using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugPanelUI : MonoBehaviour
{

    public UGUISwitchButton sb;
    public GameUUButton clearBtn;
    public GameUUButton sendBtn;
    public Text contentText;
    public InputField inputText;
    public GameObject bg;
    public Image inputbg;
    public GameUUButton stopBtn;
   public void Init()
     {
    sb=transform.Find("SwitchButton").gameObject.AddComponent<UGUISwitchButton>();
 sb.Init(
    //  GameUUButton backBtn, GameUUButton foreBtn, Text label
    sb.transform.Find("BackButton").GetComponent<GameUUButton>(),
    sb.transform.Find("ForeButton").GetComponent<GameUUButton>(),
    null
 );
    clearBtn=transform.Find("clearBtn").GetComponent<GameUUButton>();
    sendBtn=transform.Find("sendBtn").GetComponent<GameUUButton>();
    contentText=transform.Find("bg/Text").GetComponent<UnityEngine.UI.Text>();
    bg=transform.Find("bg").gameObject;
    inputbg=transform.Find("inputBg").GetComponent<UnityEngine.UI.Image>();
    stopBtn=transform.Find("stop").GetComponent<GameUUButton>();

        }


}
