using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PetUI : UIMonoBehaviour
{
    public Text title;
    //public GameObject petLeftinfo;
    //public GameObject petInfoRight;
    public GameObject petInfoLeft;
    public GameObject petInfoRight;

    public GameObject petJiadian;
    public GameObject petXichong;
    public GameObject petJineng;
    public GameObject petJinengshu;
    public GameObject petPeiyang;
    public GameObject petHuantong;
    public GameObject petBianyi;
    public GameObject petLianhua;
    public GameObject petWuxing;

    public GameUUButton closeBtn;
    public TabButtonGroup tabBtnGroup;

    public GameObject m_zujieobj;
    public GameUUButton m_zujiecloseBtn;
    public GameUUButton m_zujieBtn;
    public Text m_zujietime;
    public CommonItemUI m_zujiecost;
    public Text m_zujiename;
    public Image m_zujiebgclosebtn;

    public override void Init()
    {
        base.Init();
        GameUIBase uiBase = GetComponent<GameUIBase>();
        title = uiBase.texts[0];
        //title = transform.Find("title").GetComponent<UnityEngine.UI.Text>();
        //petInfoLeft = transform.Find("leftinfo").gameObject;
        //petInfoRight = transform.Find("rightinfo").gameObject;

        //petJiadian = transform.Find("jiadian").gameObject;

        //petXichong = transform.Find("petXichong").gameObject;

        //petJineng = transform.Find("petJineng").gameObject;
        //petJinengshu = transform.Find("petJinengshu").gameObject;

        //petPeiyang = transform.Find("petPeiyang").gameObject;

        //petHuantong = transform.Find("petHuantong").gameObject;

        //petBianyi = transform.Find("petBianyi").gameObject;

        //petLianhua = transform.Find("petLianhua").gameObject;

        //petWuxing = transform.Find("petWuxing").gameObject;

        //closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        closeBtn = uiBase.buttons[0];
        m_zujiebgclosebtn = uiBase.images[0];
        RectTransform zujiebgrect = m_zujiebgclosebtn.GetComponent<RectTransform>();
        zujiebgrect.sizeDelta = new Vector2(UGUIConfig.ScreenWidth, UGUIConfig.ScreenHeight);
        GameObject tabGroup = uiBase.gameObjects[0];
        tabBtnGroup = tabGroup.AddComponent<TabButtonGroup>();
        tabBtnGroup.Init();
        tabBtnGroup.AddToggle(uiBase.toggles[0]);
        tabBtnGroup.AddToggle(uiBase.toggles[1]);
        tabBtnGroup.AddToggle(uiBase.toggles[2]);
        tabBtnGroup.AddToggle(uiBase.toggles[3]);
        tabBtnGroup.AddToggle(uiBase.toggles[4]);
        /*
        if (transform.Find("tabGroup").gameObject!=null)
        {
            transform.Find("tabGroup").gameObject.SetActive(true);
            tabBtnGroup = transform.Find("tabGroup").gameObject.AddComponent<TabButtonGroup>();
            tabBtnGroup.Init();
            tabBtnGroup.AddToggle(tabBtnGroup.transform.Find("toggles/xinxi").GetComponent<GameUUToggle>());
            tabBtnGroup.AddToggle(tabBtnGroup.transform.Find("toggles/xichong").GetComponent<GameUUToggle>());
            tabBtnGroup.AddToggle(tabBtnGroup.transform.Find("toggles/jineng").GetComponent<GameUUToggle>());
            tabBtnGroup.AddToggle(tabBtnGroup.transform.Find("toggles/peiyang").GetComponent<GameUUToggle>());
            tabBtnGroup.AddToggle(tabBtnGroup.transform.Find("toggles/tujian").GetComponent<GameUUToggle>());    
        }
        */
        /*
        petInfoRight.gameObject.SetActive(false);
        petJiadian.gameObject.SetActive(false);
        petXichong.gameObject.SetActive(false);
        petJinengshu.gameObject.SetActive(false);
        petPeiyang.gameObject.SetActive(false);
        petHuantong.gameObject.SetActive(false);
        petBianyi.gameObject.SetActive(false);
        petLianhua.gameObject.SetActive(false);
        petWuxing.gameObject.SetActive(false);
        */

        m_zujieobj = uiBase.gameObjects[1];
        m_zujiecloseBtn = uiBase.buttons[1];
        m_zujieBtn = uiBase.buttons[2];
        m_zujietime = uiBase.texts[1];
        m_zujiecost = uiBase.gameObjects[2].AddComponent<CommonItemUI>();
        m_zujiecost.Init();
        m_zujiename = uiBase.texts[2];
    }


}
