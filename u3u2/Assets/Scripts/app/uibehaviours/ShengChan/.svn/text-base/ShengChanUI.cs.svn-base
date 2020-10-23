using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShengChanUI : MonoBehaviour
{

    public GameUUButton closeBtn;
    public Text panelTitle;
    public TabButtonGroup panelTBG;

    public CaiKuangUI caikuangUI;

    public void Init()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        panelTitle = transform.Find("titleBg/title").GetComponent<Text>();
        panelTBG = transform.Find("tabGroup").gameObject.AddComponent<TabButtonGroup>();

        GameUUToggle toggle = transform.Find("tabGroup/toggles/caikuang").GetComponent<GameUUToggle>();
        panelTBG.AddToggle(toggle);

        caikuangUI = transform.Find("caikuang").gameObject.AddComponent<CaiKuangUI>();
        caikuangUI.Init();
        PageTurner pageTurner = caikuangUI.gameObject.AddComponent<PageTurner>();
        pageTurner._leftImgBtn = transform.Find("caikuang/leftbtn").GetComponent<GameUUButton>();
        pageTurner._rightImgBtn = transform.Find("caikuang/rightbtn").GetComponent<GameUUButton>();
    }
}
