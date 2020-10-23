using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ChargeActivityUI : MonoBehaviour
{
    public GameUUButton closeBtn;
    public Text titleText;
    public TabButtonGroup toggles;
    public ToggleUI defToggleItem;

    public MeiRiChongZhiUI meirichong;
    public ShouChongUI shouchong;
    public YiYuanGouUI yiyuangou;
    public ZhaoCaiJinBaoUI zhaocaijinbao;
    public KaiFuJiJinUI kaifujijin;

    public void Init()
    {
        closeBtn = transform.Find("BigPopWnd/closeBtn").GetComponent<GameUUButton>();
        titleText = transform.Find("BigPopWnd/title").GetComponent<Text>();
        toggles = transform.Find("scrollview/grid").gameObject.AddComponent<TabButtonGroup>();
        toggles.Init();
        defToggleItem = transform.Find("scrollview/grid/activityItem").gameObject.AddComponent<ToggleUI>();
        defToggleItem.Init();
    }

}

public class ToggleUI : MonoBehaviour
{
    public GameUUToggle toggle;
    public Text toggleText;

    public void Init()
    {
        toggle = transform.GetComponent<GameUUToggle>();
        toggleText = transform.Find("name").GetComponent<Text>();
    }
}

