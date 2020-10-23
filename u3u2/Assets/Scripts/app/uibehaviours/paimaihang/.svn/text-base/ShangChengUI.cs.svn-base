using UnityEngine;
using UnityEngine.UI;

public class ShangChengUI : UIMonoBehaviour
{
    public GameUUButton closeBtn;
    public Text shangchengTitle;
    public TabButtonGroup panelTBG;
    public PaiMaiHangUI paimaihangUI;
    public ShangChengTabUI shangcheng;
    public ChongZhiUI chongzhi;

    public override void Init()
    {
        base.Init();
        closeBtn = transform.Find("BigPopWndWIthSideTab/closeBtn").GetComponent<GameUUButton>();
        shangchengTitle = transform.Find("BigPopWndWIthSideTab/title").GetComponent<UnityEngine.UI.Text>();
        panelTBG = transform.Find("BigPopWndWIthSideTab/tabGroup").gameObject.AddComponent<TabButtonGroup>();
        panelTBG.Init();
        GameUUToggle toggle1 =
            transform.Find("BigPopWndWIthSideTab/tabGroup/toggles/toggle1").GetComponent<GameUUToggle>();

        panelTBG.AddToggle(toggle1);
        panelTBG.AddToggle(transform.Find("BigPopWndWIthSideTab/tabGroup/toggles/toggle2").GetComponent<GameUUToggle>());

        panelTBG.AddToggle(transform.Find("BigPopWndWIthSideTab/tabGroup/toggles/toggle3").GetComponent<GameUUToggle>());

        GameUUToggle toggle4 =
            transform.Find("BigPopWndWIthSideTab/tabGroup/toggles/toggle4").GetComponent<GameUUToggle>();

        panelTBG.AddToggle(toggle4);
        
        /*
        paimaihangUI = transform.Find("paimaihang").gameObject.AddComponent<PaiMaiHangUI>();
        paimaihangUI.Init();

        shangcheng = transform.Find("shangcheng").gameObject.AddComponent<ShangChengTabUI>();
        shangcheng.Init();
        */
        //toggle1.gameObject.SetActive(false);
        toggle4.gameObject.SetActive(false);

        //chongzhi = transform.Find("ShangChengUIchongzhi").gameObject.AddComponent<ChongZhiUI>();
        //chongzhi.init();
        
    }
}
