using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class XinFaUI : UIMonoBehaviour
{
    public Text titleText;
    public GameUUButton closeBtn;
    public TabButtonGroup tabBtnGroup;

    public GameObject objxinfa;
    public GameObject objxinfajineng;
    public GameObject objFuzhuJineng;
    public GameObject objXiulianJineng;

    public override void Init()
    {
        base.Init();
        titleText = transform.Find("title").GetComponent<Text>();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();

        tabBtnGroup = transform.Find("tabGroup").gameObject.AddComponent<TabButtonGroup>();
        GameUUToggle jinengToggle = transform.Find("tabGroup/toggles/jineng").GetComponent<GameUUToggle>();
        tabBtnGroup.AddToggle(jinengToggle);
        jinengToggle.redDotVisible = false;
        GameUUToggle xinfaToggle = transform.Find("tabGroup/toggles/xinfa").GetComponent<GameUUToggle>();
        tabBtnGroup.AddToggle(xinfaToggle);
        xinfaToggle.redDotVisible = false;
        GameUUToggle xiulianToggle = transform.Find("tabGroup/toggles/xiulian").GetComponent<GameUUToggle>();
        tabBtnGroup.AddToggle(xiulianToggle);
        xiulianToggle.redDotVisible = false;
      //  xiulianToggle.gameObject.SetActive(false);
        GameUUToggle fuzhuToggle = transform.Find("tabGroup/toggles/fuzhu").GetComponent<GameUUToggle>();
        tabBtnGroup.AddToggle(fuzhuToggle);
        fuzhuToggle.redDotVisible = false;
      //  fuzhuToggle.gameObject.SetActive(false);
        GameUUToggle xianfuToggle = transform.Find("tabGroup/toggles/xianfu").GetComponent<GameUUToggle>();
        tabBtnGroup.AddToggle(xianfuToggle);
        xianfuToggle.redDotVisible = false;
        GameUUToggle shenghuoToggle = transform.Find("tabGroup/toggles/shenghuo").GetComponent<GameUUToggle>();
        tabBtnGroup.AddToggle(shenghuoToggle);
        shenghuoToggle.redDotVisible = false;

    }
}