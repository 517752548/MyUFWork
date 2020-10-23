using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PetSkillUI : UIMonoBehaviour
{
    public TabButtonGroup tabBtnGroup;
    public GameObject skillItems;
    public CommonItemUI bookItem;
    public GameUUButton shengjiBtn;
    public GameUUButton xitianfuBtn;
    public GameUUButton kuozhanjinenglanBtn;
    //public Text putongTxt1;
    public Text putongTxt3;
    public Text putongTxt5;
    public Text tianfuTxt1;
    //public Text tianfuTxt2;
    public Text tianfuTxt3;
    public Text tianfuTxt4;
    public Text tianfuTxt5;
    //public Text tianfuTxt6;
    public Text tianfuTxt7;
    public Text tianfuTxt8;
    public Text jinenglan3;
    public Text jinenglan5;
    public CommonItemUI tianfuCost;
    public CommonItemUI m_jinenglanCost;
    public CommonItemUI defaultSkillItem;
    public RectTransform zizhiskillRTF;
    public GameObject m_tianfuobj;
    public GameObject m_putongobj;
    public GameObject m_jinenglanobj;
    public GameObject m_quickobj;
    public GameObject m_qichongobj;

    public override void Init()
    {
        base.Init();
        tabBtnGroup = transform.Find("petJinengTabGroup").gameObject.AddComponent<TabButtonGroup>();
        tabBtnGroup.Init();
        tabBtnGroup.AddToggle(tabBtnGroup.transform.Find("tianfu").GetComponent<GameUUToggle>());
        tabBtnGroup.AddToggle(tabBtnGroup.transform.Find("putong").GetComponent<GameUUToggle>());
        tabBtnGroup.AddToggle(tabBtnGroup.transform.Find("jinenglan").GetComponent<GameUUToggle>());

        m_tianfuobj = transform.Find("tianfu").gameObject;
        m_putongobj = transform.Find("putong").gameObject;
        m_jinenglanobj = transform.Find("jinenglan").gameObject;
        skillItems = transform.Find("jinenglan/QuickObj/grid").gameObject;

        for (int i = 0; i < 5; i++)
        {
            CommonItemUI itemUI = skillItems.transform.Find(i.ToString()).gameObject.AddComponent<CommonItemUI>();
            itemUI.Init();
        }

        bookItem = transform.Find("putong/bookItem").gameObject.AddComponent<CommonItemUI>();
        bookItem.Init();
        shengjiBtn = transform.Find("putong/shengji").GetComponent<GameUUButton>();
        xitianfuBtn = transform.Find("tianfu/xitianfu").GetComponent<GameUUButton>();
        kuozhanjinenglanBtn = transform.Find("jinenglan/kuozhanjinenglan").GetComponent<GameUUButton>();
        //putongTxt1 = transform.Find("putong/putongTxt1").GetComponent<UnityEngine.UI.Text>();
        putongTxt3 = transform.Find("putong/putongTxt3").GetComponent<UnityEngine.UI.Text>();
        putongTxt5 = transform.Find("putong/putongTxt5").GetComponent<UnityEngine.UI.Text>();
        tianfuTxt1 = transform.Find("tianfu/tianfuTxt1").GetComponent<UnityEngine.UI.Text>();
        //tianfuTxt2 = transform.Find("tianfu/tianfuTxt2").GetComponent<UnityEngine.UI.Text>();
        tianfuTxt3 = transform.Find("tianfu/tianfuTxt3").GetComponent<UnityEngine.UI.Text>();
        tianfuTxt4 = transform.Find("tianfu/tianfuTxt4").GetComponent<UnityEngine.UI.Text>();
        tianfuTxt5 = transform.Find("tianfu/tianfuTxt5").GetComponent<UnityEngine.UI.Text>();
        //tianfuTxt6 = transform.Find("tianfu/tianfuTxt6").GetComponent<UnityEngine.UI.Text>();
        tianfuTxt7 = transform.Find("tianfu/tianfuTxt7").GetComponent<UnityEngine.UI.Text>();
        tianfuTxt8 = transform.Find("tianfu/tianfuTxt8").GetComponent<UnityEngine.UI.Text>();
        jinenglan3 = transform.Find("jinenglan/jinengTxt3").GetComponent<UnityEngine.UI.Text>();
        jinenglan5 = transform.Find("jinenglan/jinengTxt5").GetComponent<UnityEngine.UI.Text>();
        tianfuCost = transform.Find("tianfu/tianfuCost").gameObject.AddComponent<CommonItemUI>();
        tianfuCost.Init();

        m_jinenglanCost = transform.Find("jinenglan/jinenglanCost").gameObject.AddComponent<CommonItemUI>();
        m_jinenglanCost.Init();

        defaultSkillItem = transform.Find("scrollRect/grid/ZZCommonItemUI").gameObject.AddComponent<CommonItemUI>();
        defaultSkillItem.Init();
        zizhiskillRTF = transform.Find("scrollRect").gameObject.GetComponent<RectTransform>();

        m_quickobj = transform.Find("jinenglan/QuickObj").gameObject;
        m_qichongobj = transform.Find("jinenglan/QiChongObj").gameObject;
    }

}
