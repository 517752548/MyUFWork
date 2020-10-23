using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PetLeftInfoUI : UIMonoBehaviour
{

    public GameUUButton petRenameBtn;
    public Text petname;
    //public GameObject baobaoImage;
    public GameObject bianyi;
    public GameObject pettype1_xiyou;
    public GameObject pettype1_shenshou;
    public GameObject pettype2;
    public GameObject pettype3;
    public GameObject pettype4;
    public GameObject[] m_petraces;

    public GameObject putong;
    public GameObject youxiu;
    public GameObject jiechu;
    public GameObject zhuoyue;
    public GameObject chaofan;
    public GameObject wanmei;

    public GameObject isChuzhan;
    public GameObject isQiCheng;
    public Text levelText;

    public ProgressBar expProgress;

    public GridLayoutGroup petListGrid;
    public TabButtonGroup petListTBG;
    public CommonItemUI defaultPetItem;

    public GameObject modelContainer;
    public GameObject effectContainer;

    public GameObject shengjiEffect;

    public GameObject lefttopObj;
    public GameObject tujianTypeDropdown;
    public Dropdown tujianDropDown;
    public GameUUToggle bianyiToggle;
    public GameUUButton m_zujieqi;

    public Image bindtag;
    public Image nobindtag;
    public GameUUButton m_petczinfo;
    public GameUUButton m_pethqinfo;
    public GameUUButton m_petraceinfo;

    //private List<CanvasRenderer> mRenderers = new List<CanvasRenderer>();
    public override void Init()
    {
        base.Init();
        GameUIBase uiBase = GetComponent<GameUIBase>();
        petRenameBtn = uiBase.buttons[0];
        m_zujieqi = uiBase.buttons[1];
        // petRenameBtn = transform.Find("changeNameBtn").GetComponent<GameUUButton>();
        petname = uiBase.texts[0];
        //petname = transform.Find("Image/Text").GetComponent<UnityEngine.UI.Text>();
        bianyi = uiBase.gameObjects[0];
        // bianyi = transform.Find("bianyi").gameObject;
        pettype1_xiyou = uiBase.gameObjects[1];
        // pettype1_xiyou = transform.Find("pettype1_xiyou").gameObject;
        pettype1_shenshou = uiBase.gameObjects[2];
        // pettype1_shenshou = transform.Find("pettype1_shenshou").gameObject;
        pettype2 = uiBase.gameObjects[3];
        // pettype2 = transform.Find("pettype2").gameObject;
        pettype3 = uiBase.gameObjects[4];
        // pettype3 = transform.Find("pettype3").gameObject;
        pettype4 = uiBase.gameObjects[5];
        // pettype4 = transform.Find("pettype4").gameObject;
        putong = uiBase.gameObjects[6];
        // putong = transform.Find("putong").gameObject;
        youxiu = uiBase.gameObjects[7];
        // youxiu = transform.Find("youxiu").gameObject;
        jiechu = uiBase.gameObjects[8];
        // jiechu = transform.Find("jiechu").gameObject;
        zhuoyue = uiBase.gameObjects[9];
        // zhuoyue = transform.Find("zhuoyue").gameObject;
        chaofan = uiBase.gameObjects[10];
        // chaofan = transform.Find("chaofan").gameObject;
        wanmei = uiBase.gameObjects[11];
        // wanmei = transform.Find("wanmei").gameObject;
        isChuzhan = uiBase.gameObjects[12];
        isQiCheng = uiBase.gameObjects[20];

        m_petraces = new GameObject[5];
        for (int i = 0; i < m_petraces.Length; ++i)
        {
            m_petraces[i] = uiBase.gameObjects[i + 21];
        }
        // isChuzhan = transform.Find("chuzhan").gameObject;
        bindtag = uiBase.images[2];
        nobindtag = uiBase.images[3];

        levelText = uiBase.texts[1];
        // levelText = transform.Find("Image/level").GetComponent<UnityEngine.UI.Text>();
        expProgress = uiBase.gameObjects[13].AddComponent<ProgressBar>();
        // expProgress = transform.Find("exp/ZZProgress Bar 1").gameObject.AddComponent<ProgressBar>();
        expProgress.Init
        (
            //expProgress.transform.Find("background").GetComponent<Image>(),
            //expProgress.transform.Find("background/foreground").GetComponent<Image>(),
            //expProgress.transform.Find("Text").GetComponent<Text>(),
            uiBase.images[0],
            uiBase.images[1],
            uiBase.texts[2],
            277
        );
        //petListGrid = transform.Find("petList/Image/scrollRect/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        petListGrid = uiBase.gameObjects[14].GetComponent<GridLayoutGroup>();
        petListTBG = petListGrid.gameObject.AddComponent<TabButtonGroup>();
        // petListTBG = transform.Find("petList/Image/scrollRect/grid").gameObject.AddComponent<TabButtonGroup>();
        petListTBG.Init();
        defaultPetItem = uiBase.gameObjects[15].AddComponent<CommonItemUI>();
        //defaultPetItem = transform.Find("petList/Image/scrollRect/grid/CommonItemUIWithToggle70_70").gameObject.AddComponent<CommonItemUI>();
        defaultPetItem.Init();
        modelContainer = uiBase.gameObjects[16];
        effectContainer = uiBase.gameObjects[17];
        // modelContainer = transform.Find("modelContainer").gameObject;
        // shengjiEffect = transform.Find("modelContainer/shengji_chongwu").gameObject;
        //shengjiEffect.gameObject.SetActive(false);
        //pettype2.gameObject.SetActive(false);
        //pettype3.gameObject.SetActive(false);
        //pettype4.gameObject.SetActive(false);

        lefttopObj = uiBase.gameObjects[18];
        tujianTypeDropdown = uiBase.gameObjects[19];
        tujianDropDown = tujianTypeDropdown.GetComponent<Dropdown>();
        bianyiToggle = uiBase.toggles[0];
        m_petczinfo = uiBase.buttons[2];
        m_pethqinfo = uiBase.buttons[3];
        m_petraceinfo = uiBase.buttons[4];

        //mRenderers.Add(petListGrid.transform.parent.GetComponent<CanvasRenderer>());
    }

    
    public override void Show()
    {
        if (!isShown)
        {
            base.Show();
            ClearCanvas();
        }
    }

    public override void Hide()
    {
        if (isShown)
        {
            base.Hide();
            ClearCanvas();
        }
    }

    private void ClearCanvas()
    {
        /*
        int len = mRenderers.Count;
        for (int i = 0; i < len; i++)
        {
            mRenderers[i].Clear();
        }
        */
        Vector3 pos = petListGrid.transform.parent.localPosition;
        if (isShown)
        {
            pos.y = pos.y + 1;
        }
        else
        {
            pos.y = pos.y - 1;
        }

        petListGrid.transform.parent.localPosition = pos;
    }
}
