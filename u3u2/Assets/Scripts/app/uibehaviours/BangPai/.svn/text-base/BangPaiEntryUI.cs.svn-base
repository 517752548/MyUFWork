using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BangPaiEntryUI : UIMonoBehaviour
{
    public GameUUButton closeBtn;
    public TabButtonGroup listTBG;
    public GridLayoutGroup liebiaoGrid;
    public BangPaiListItemUI defaultListItemUI;
    public Text gongGaoText;
    public GameUUButton yijianShenqing;
    public Text shenqingBtnText;
    public GameUUButton shenqingJiaru;
    public GameUUButton lianxiBangzhu;
    public GameUUButton chuangjianBangPai;
    public Image inputTextBg;
    public GameUUButton chazhaoBtn;
    public CreateBangPaiUI createUI;
    public GameUUButton clearSearchBtn;
    public PageTurner pageturner;

    public override void Init()
    {
        base.Init();
        closeBtn = transform.Find("ZZBigPopWnd/closeBtn").GetComponent<GameUUButton>();
        listTBG = transform.Find("bangpaiList/scrollList/Image/grid").gameObject.AddComponent<TabButtonGroup>();
        liebiaoGrid = transform.Find("bangpaiList/scrollList/Image/grid").GetComponent<GridLayoutGroup>();
        defaultListItemUI = transform.Find("bangpaiList/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<BangPaiListItemUI>();
        defaultListItemUI.Init(defaultListItemUI.transform,
            defaultListItemUI.transform.Find("yishengqing"),
            defaultListItemUI.transform.Find("bianhao"),
            defaultListItemUI.transform.Find("mingcheng"),
            defaultListItemUI.transform.Find("dengji"),
            defaultListItemUI.transform.Find("renshu"),
            defaultListItemUI.transform.Find("bangzhu"),
            null, null, null, null, null, null, null, null, null,
            defaultListItemUI.transform.Find("danshuBg"),
            defaultListItemUI.transform.Find("shuangshuBg"));
        defaultListItemUI.scrollRect = liebiaoGrid.transform.parent.GetComponent<ScrollRect>();
        gongGaoText = transform.Find("gonggaoGo/scrollRect/Text").GetComponent<Text>();
        yijianShenqing = transform.Find("btnList/yijianshenqing").GetComponent<GameUUButton>();
        shenqingJiaru = transform.Find("btnList/shenqingjiaru").GetComponent<GameUUButton>();
        shenqingBtnText = transform.Find("btnList/shenqingjiaru/Text").GetComponent<Text>();
        lianxiBangzhu = transform.Find("btnList/lianxibangzhu").GetComponent<GameUUButton>();
        chuangjianBangPai = transform.Find("btnList/chuangjian").GetComponent<GameUUButton>();

        inputTextBg = transform.Find("input/Image").GetComponent<Image>();
        chazhaoBtn = transform.Find("input/chaozhao").GetComponent<GameUUButton>();

        createUI = transform.Find("createPanel").gameObject.AddComponent<CreateBangPaiUI>();
        createUI.Init();

        clearSearchBtn = transform.Find("input/clearSearchBut").GetComponent<GameUUButton>();
        createUI.gameObject.SetActive(false);

        pageturner = transform.Find("PageTurner").gameObject.AddComponent<PageTurner>();
        pageturner.Init(pageturner.transform.Find("leftButton").GetComponent<GameUUButton>()
            , pageturner.transform.Find("rightButton").GetComponent<GameUUButton>(),
        pageturner.transform.Find("Text").GetComponent<Text>());
    }
}
