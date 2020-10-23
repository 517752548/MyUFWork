using UnityEngine;
using UnityEngine.UI;

public class PetInfoRightUI : UIMonoBehaviour
{

    public TabButtonGroup infoSkill;

    public GameObject infoObj;
    public GameObject skillObj;
    public GameObject m_useitemObj;
    public GameObject m_zizhidanObj;

    public Text chengzhanglvName;
    public Text chengzhanglvValue;

    public Text wuxingLevel;
    public Text wuxingValue;

    public ProgressBar shoumingPG;
    public RectTransform m_shouming;
    public GameUUButton addShouMing;

    public GridLayoutGroup petPropGrid;
    public GameUUButton fangshengBtn;
    public GameUUButton xiuxiBtn;
    public Text xiuxiBtnText;

    public GameUUButton jiadianBtn;
    public GameObject zizhiPgGrid;
    public Text[] m_zizhidannum;

    public GridLayoutGroup skillGrid;
    public CommonItemUI defaultSkillItem;

    public Text propInfoLabel;

    public GameObject shoumingchiTips;

    public GameObject tujianObj;
    public GridLayoutGroup petTuJianPropGrid;
    public Text propTujianInfoLabel;
    public Text zuoqiTips;
    public Text huoquTujing;
    
    public RectTransform zizhiskillRTF;
    public GameUUButton m_zizhidanshuoming;
    public GameObject m_qichong;
    public ProgressBar m_zhongchengdu;
    public ProgressBar m_qinmidu;
    public RectTransform m_info_bg;

    public GameObject m_lianjieobj;
    public GameUUButton m_lianjieBtn;
    public GameUUButton m_shiyongBtn;

    public RectTransform m_jiadianrect;
    public RectTransform m_linghunrect;

    public override void Init()
    {
        base.Init();
        GameUIBase uiBase = GetComponent<GameUIBase>();
        // infoSkill = transform.Find("infoSkillTabGroup").gameObject.AddComponent<TabButtonGroup>();
        infoSkill = uiBase.gameObjects[0].AddComponent<TabButtonGroup>();
        infoSkill.Init();
        infoSkill.AddToggle(uiBase.toggles[0]);
        infoSkill.AddToggle(uiBase.toggles[1]);
        infoSkill.AddToggle(uiBase.toggles[2]);
        // infoSkill.AddToggle(infoSkill.transform.Find("xinxi").GetComponent<GameUUToggle>());
        // infoSkill.AddToggle(infoSkill.transform.Find("zizhijineng").GetComponent<GameUUToggle>());
        infoObj = uiBase.gameObjects[1];
        skillObj = uiBase.gameObjects[2];
        m_zizhidanObj = uiBase.gameObjects[18];
        m_useitemObj = uiBase.gameObjects[23];
        // infoObj = transform.Find("info").gameObject;
        // skillObj = transform.Find("zizhiSkill").gameObject;

        // chengzhanglvName
        // chengzhanglvValue
        // wuxingLevel
        // wuxingValue
        //shoumingPG = transform.Find("info/shoumingchi/ZZProgress Bar 1").gameObject.AddComponent<ProgressBar>();
        shoumingPG = uiBase.gameObjects[3].AddComponent<ProgressBar>();
        shoumingPG.Init
        (
            //shoumingPG.transform.Find("background").GetComponent<Image>(),
            //shoumingPG.transform.Find("background/foreground").GetComponent<Image>(),
            //shoumingPG.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[0],
            uiBase.images[1],
            uiBase.texts[0],
           210
        );
        m_shouming = uiBase.gameObjects[3].GetComponent<RectTransform>();
        //addShouMing = transform.Find("info/shoumingchi/addShouMing").GetComponent<GameUUButton>();
        addShouMing = uiBase.buttons[0];
        petPropGrid = uiBase.gridLayoutGroups[0];
        //petPropGrid = transform.Find("info/scroller/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        fangshengBtn = uiBase.buttons[1];
        // fangshengBtn = transform.Find("fangsheng").GetComponent<GameUUButton>();
        xiuxiBtn = uiBase.buttons[2];
        // xiuxiBtn = transform.Find("canzhanORxiuxi").GetComponent<GameUUButton>();
        xiuxiBtnText = uiBase.texts[1];
        //xiuxiBtnText = transform.Find("canzhanORxiuxi/Text").GetComponent<UnityEngine.UI.Text>();
        jiadianBtn = uiBase.buttons[3];
        m_jiadianrect = uiBase.buttons[3].GetComponent<RectTransform>();
        m_zizhidanshuoming = uiBase.buttons[4];
        // jiadianBtn = transform.Find("info/jiadian").GetComponent<GameUUButton>();
        // zizhiPgGrid = transform.Find("zizhiSkill/pgGrid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        zizhiPgGrid = uiBase.gameObjects[11];
        
        ProgressBar qiangzhuangBar = uiBase.gameObjects[4].AddComponent<ProgressBar>();
        // ProgressBar qiangzhuangBar = zizhiPgGrid.transform.Find("qiangzhuang/ZZProgress Bar 1").gameObject.AddComponent<ProgressBar>();
        qiangzhuangBar.Init
        (
            //qiangzhuangBar.transform.Find("background").GetComponent<Image>(),
            //qiangzhuangBar.transform.Find("background/foreground").GetComponent<Image>(),
            //qiangzhuangBar.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[2],
            uiBase.images[3],
            uiBase.texts[2],
           210
        );

        //ProgressBar minjieBar = zizhiPgGrid.transform.Find("minjie/ZZProgress Bar 1").gameObject.AddComponent<ProgressBar>();
        ProgressBar minjieBar = uiBase.gameObjects[5].AddComponent<ProgressBar>();
        minjieBar.Init
        (
            //minjieBar.transform.Find("background").GetComponent<Image>(),
            //minjieBar.transform.Find("background/foreground").GetComponent<Image>(),
            //minjieBar.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[4],
            uiBase.images[5],
            uiBase.texts[3],
            210
        );

        //ProgressBar zhiliBar = zizhiPgGrid.transform.Find("zhili/ZZProgress Bar 1").gameObject.AddComponent<ProgressBar>();
        ProgressBar zhiliBar = uiBase.gameObjects[6].AddComponent<ProgressBar>();
        zhiliBar.Init
        (
            //zhiliBar.transform.Find("background").GetComponent<Image>(),
            //zhiliBar.transform.Find("background/foreground").GetComponent<Image>(),
            //zhiliBar.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[6],
            uiBase.images[7],
            uiBase.texts[4],
           210
        );

        // ProgressBar xinyangBar = zizhiPgGrid.transform.Find("xinyang/ZZProgress Bar 1").gameObject.AddComponent<ProgressBar>();
        ProgressBar xinyangBar = uiBase.gameObjects[7].AddComponent<ProgressBar>();
        xinyangBar.Init
        (
            // xinyangBar.transform.Find("background").GetComponent<Image>(),
            // xinyangBar.transform.Find("background/foreground").GetComponent<Image>(),
            // xinyangBar.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[8],
            uiBase.images[9],
            uiBase.texts[5],
            210
        );

        // ProgressBar nailiBar = zizhiPgGrid.transform.Find("naili/ZZProgress Bar 1").gameObject.AddComponent<ProgressBar>();
        ProgressBar nailiBar = uiBase.gameObjects[8].AddComponent<ProgressBar>();
        nailiBar.Init
        (
            // nailiBar.transform.Find("background").GetComponent<Image>(),
            // nailiBar.transform.Find("background/foreground").GetComponent<Image>(),
            // nailiBar.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[10],
            uiBase.images[11],
            uiBase.texts[6],
           210
        );

        m_zizhidannum = new Text[5];
        m_zizhidannum[0] = uiBase.texts[11];
        m_zizhidannum[1] = uiBase.texts[12];
        m_zizhidannum[2] = uiBase.texts[13];
        m_zizhidannum[3] = uiBase.texts[14];
        m_zizhidannum[4] = uiBase.texts[15];

        //skillGrid = transform.Find("zizhiSkill/petList 1/Image/scrollRect/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        skillGrid = uiBase.gridLayoutGroups[1];
        zizhiskillRTF = skillGrid.transform.parent.GetComponent<RectTransform>();
        //defaultSkillItem = transform.Find("zizhiSkill/petList 1/Image/scrollRect/grid/ZZCommonItemUI").gameObject.AddComponent<CommonItemUI>();
        defaultSkillItem = uiBase.gameObjects[9].AddComponent<CommonItemUI>();
        defaultSkillItem.Init();
        
        //propInfoLabel = transform.Find("info/scroller/grid/Text").GetComponent<UnityEngine.UI.Text>();
        propInfoLabel = uiBase.texts[7];

        // shoumingchiTips = transform.Find("shoumingchiTips").gameObject;
        shoumingchiTips = uiBase.gameObjects[10];
        //shoumingchiTips.gameObject.SetActive(false);
        //skillObj.gameObject.SetActive(false);
        //addShouMing.gameObject.SetActive(false);
        //propInfoLabel.gameObject.SetActive(false);
        tujianObj = uiBase.gameObjects[12];
        petTuJianPropGrid = uiBase.gridLayoutGroups[2];
        propTujianInfoLabel = uiBase.texts[8];
        zuoqiTips = uiBase.texts[9];
        huoquTujing = uiBase.texts[10];

        m_qichong = uiBase.gameObjects[19];
        m_zhongchengdu = uiBase.gameObjects[3].AddComponent<ProgressBar>();
        m_zhongchengdu.Init
        (
            //shoumingPG.transform.Find("background").GetComponent<Image>(),
            //shoumingPG.transform.Find("background/foreground").GetComponent<Image>(),
            //shoumingPG.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[13],
            uiBase.images[14],
            uiBase.texts[16],
           210
        );
        m_qinmidu = uiBase.gameObjects[3].AddComponent<ProgressBar>();
        m_qinmidu.Init
        (
            //shoumingPG.transform.Find("background").GetComponent<Image>(),
            //shoumingPG.transform.Find("background/foreground").GetComponent<Image>(),
            //shoumingPG.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[15],
            uiBase.images[16],
            uiBase.texts[17],
           210
        );
        m_info_bg = uiBase.images[12].GetComponent<RectTransform>();

        m_lianjieobj = uiBase.gameObjects[22];
        m_lianjieBtn = uiBase.buttons[5];
        m_shiyongBtn = uiBase.buttons[6];
        m_linghunrect = uiBase.buttons[5].GetComponent<RectTransform>();
    }

}
