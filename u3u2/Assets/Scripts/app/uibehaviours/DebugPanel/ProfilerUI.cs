using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ProfilerUI : MonoBehaviour
{
    public UGUISwitchButton sb;
    public RectTransform sbrtf;
    public Text contentText;
    public GameObject bg;
    public GameUUButton stopBtn;
    public Text stopBtnText;
    public GameUUButton gcBtn;

    public TabButtonGroup tbg;

    public void Init()
    {
        sb = transform.Find("SwitchButton").gameObject.AddComponent<UGUISwitchButton>();
        sb.Init(
           sb.transform.Find("BackButton").GetComponent<GameUUButton>(),
           sb.transform.Find("ForeButton").GetComponent<GameUUButton>(),
           null
        );
        sbrtf = sb.gameObject.GetComponent<RectTransform>();
        contentText = transform.Find("bg/Text").GetComponent<UnityEngine.UI.Text>();
        bg = transform.Find("bg").gameObject;

        stopBtn = transform.Find("stop").GetComponent<GameUUButton>();
        stopBtnText = transform.Find("stop/Text").GetComponent<Text>();
        gcBtn = transform.Find("GC").GetComponent<GameUUButton>();

        tbg = transform.Find("tabgroup").gameObject.AddComponent<TabButtonGroup>();
        tbg.Init();
        tbg.AddToggle(transform.Find("tabgroup/Normal").gameObject.GetComponent<GameUUToggle>());
        tbg.AddToggle(transform.Find("tabgroup/Detail").gameObject.GetComponent<GameUUToggle>());
    }
}

