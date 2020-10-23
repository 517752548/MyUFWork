using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QichongUI : UIMonoBehaviour {

    public QichongXinxiUI xinxiUI;
   // public QichongLeftInfoUI leftInfoUI;
    public GameUUButton closeBtn;
    public TabButtonGroup tabs;
    public Text textTitle;
    public GameObject objQiChongLeftInfo;
    public Transform tfLeftInfoContainer;

    public override void Init()
    {
        base.Init();
        xinxiUI = transform.Find("qichongXinxi").gameObject.AddComponent<QichongXinxiUI>();
        xinxiUI.Init();
       // leftInfoUI = transform.Find("leftinfo").gameObject.AddComponent<QichongLeftInfoUI>();
        //leftInfoUI.Init();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        tabs = transform.Find("tabGroup").gameObject.AddComponent<TabButtonGroup>();
        tabs.Init();
        tabs.AddToggle(tabs.transform.Find("toggles/xinxi").GetComponent<GameUUToggle>());
        textTitle = transform.Find("title").GetComponent<Text>();
        tfLeftInfoContainer = transform.Find("qichongLeftInfoContainer");

           
    }

}
