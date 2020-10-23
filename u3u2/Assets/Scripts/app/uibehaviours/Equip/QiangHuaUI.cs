using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QiangHuaUI : UIMonoBehaviour
{
    public GameUUButton closeBtn;
    public TabButtonGroup panelTBG;
    public Text panelTitle;

    public EquipChongZhuUI chongzhuUI;
    public EquipFenJieUI fenjieUI;

    public GameObject chongzhuUIObj;
    public GameObject fenjieUIObj;
    public GameObject xilianUIObj;

    public override void Init()
    {
        base.Init();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        panelTBG = transform.Find("tabGroup").gameObject.AddComponent<TabButtonGroup>();

        GameUUToggle toggle1 = transform.Find("tabGroup/toggles/fenjie").GetComponent<GameUUToggle>();
        panelTBG.AddToggle(toggle1);
        GameUUToggle toggle3 = transform.Find("tabGroup/toggles/chongzhu").GetComponent<GameUUToggle>();
        panelTBG.AddToggle(toggle3);
        GameUUToggle toggle4 = transform.Find("tabGroup/toggles/chuancheng").GetComponent<GameUUToggle>();
        panelTBG.AddToggle(toggle4);
        GameUUToggle toggle5 = transform.Find("tabGroup/toggles/lianhua").GetComponent<GameUUToggle>();
        panelTBG.AddToggle(toggle5);
        panelTitle = transform.Find("titleBg/title").GetComponent<Text>();

        //chongzhuUI = transform.Find("gaizao").gameObject.AddComponent<EquipChongZhuUI>();
        //chongzhuUI.Init();
        //fenjieUI = transform.Find("fenjie").gameObject.AddComponent<EquipFenJieUI>();
        //fenjieUI.Init();
        //xilianUI = transform.Find("xilian").gameObject.AddComponent<EquipXiLianUI>();
        //xilianUI.Init();

        //xilianUI.gameObject.SetActive(false);
        //chongzhuUI.gameObject.SetActive(false);
        //fenjieUI.gameObject.SetActive(false);

    }
}
