using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class XinFaUIXinfaJineng : UIMonoBehaviour
{
    public Dropdown m_XinFaDropdown;
    public TabButtonGroup m_JinengTBG;
    public List<GameUUToggle> m_XinfaSkills;
    public Text m_XinfaName;
    public Text m_XinfaLevel;
    public Text m_XinfaDetail;
    public List<GameObject> m_QuickSkills;

    public ProgressBar m_ShulianduBar;
    public Text m_Ceng;
    public Text m_daoju;
    public GameUUButton shengjiBtn;
    public GameUUButton tishengshulianBtn;
    public GameUUButton shuomingBtn;

    public GameObject leftobj;
    public GameObject rightobj;
    public GameObject m_dropclone;
    public GameObject m_tishengclone;
    public GameObject m_tishengclone1;

    public override void Init()
    {
        base.Init();
        leftobj = transform.Find("skill").gameObject;
        rightobj = transform.Find("rightInfo").gameObject;
        m_XinFaDropdown = transform.Find("Dropdown").GetComponent<Dropdown>();
        m_XinfaSkills = new List<GameUUToggle>();
        m_JinengTBG = transform.Find("skill/skilllist/grid").gameObject.AddComponent<TabButtonGroup>();
        for (int i = 1; i < 5; ++i)
        {
            GameUUToggle toggle = transform.Find("skill/skilllist/grid/Toggle" + i).GetComponent<GameUUToggle>();
            m_JinengTBG.AddToggle(toggle);
            m_XinfaSkills.Add(toggle);
        }

        m_XinfaName = transform.Find("rightInfo/xiaoguo/BiaoTiText_22").GetComponent<Text>();
        m_XinfaLevel = transform.Find("rightInfo/xiaoguo/BiaoTiText_23").GetComponent<Text>();
        m_XinfaDetail = transform.Find("rightInfo/detail").GetComponent<Text>();

        m_QuickSkills = new List<GameObject>();
        for (int i = 1; i < 6; ++i)
        {
            m_QuickSkills.Add(transform.Find("rightInfo/skilllist/Toggle" + i).gameObject);
        }

        m_ShulianduBar = transform.Find("rightInfo/shengji/shuliandu").gameObject.AddComponent<ProgressBar>();
        m_ShulianduBar.Init
        (
            m_ShulianduBar.transform.Find("background").GetComponent<Image>(),
            m_ShulianduBar.transform.Find("foreground").GetComponent<Image>(),
            m_ShulianduBar.transform.Find("Text").GetComponent<Text>(), 260
        );
        m_Ceng = transform.Find("rightInfo/shengji/shuliandu/ceng").GetComponent<Text>();
        m_daoju = transform.Find("rightInfo/shengji/daojutext").GetComponent<Text>();
        shengjiBtn = transform.Find("rightInfo/shengji/shengjiBtn").GetComponent<GameUUButton>();
        tishengshulianBtn = transform.Find("rightInfo/shengji/tishengshulianBtn").GetComponent<GameUUButton>();
        shuomingBtn = transform.Find("rightInfo/shengji/btnShuoming").GetComponent<GameUUButton>();

        m_dropclone = transform.Find("Dropdownclone").gameObject;
        m_tishengclone = transform.Find("rightInfo/shengji/tishengshulianBtnclone").gameObject;
        m_tishengclone1 = transform.Find("rightInfo/shengji/tishengshulianBtnclone1").gameObject;
    }
}
