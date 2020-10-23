using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class XinFaUIShengHuoJinengUI : UIMonoBehaviour
{
    public TabButtonGroup m_JinengTBG;
    public List<GameUUToggle> m_ShenghuoSkills;

    public GameObject[] m_selecticos;
    public Text m_select_name1;
    public Text m_select_name2;
    public Text m_select_lv1;
    public Text m_lv_text1;
    public Text m_select_lv2;
    public Text m_pinzhi_text;
    public Text m_select_pizhi;
    public Text m_select_mp;
    public Text m_next_dianshu;
    public Text m_shengji;
    public ProgressBar m_ShulianduBar;
    public Text m_Ceng;
    public GameUUButton shuomingBtn;
    public GameUUButton m_shiyongBtn;

    public GameObject m_ziyuanobj;
    public GameUUButton ziyuancloseBtn;
    public GameObject leftobj;
    public GameObject rightobj;

    public override void Init()
    {
        base.Init();

        leftobj = transform.Find("skill").gameObject;
        rightobj = transform.Find("rightInfo").gameObject;

        m_ShenghuoSkills = new List<GameUUToggle>();
        m_JinengTBG = transform.Find("skill/skilllist/grid").gameObject.AddComponent<TabButtonGroup>();
        for (int i = 1; i < 5; ++i)
        {
            GameUUToggle toggle = transform.Find("skill/skilllist/grid/Toggle" + i).GetComponent<GameUUToggle>();
            m_JinengTBG.AddToggle(toggle);
            m_ShenghuoSkills.Add(toggle);
        }

        m_selecticos = new GameObject[4];
        for (int i = 1; i < 5; ++i)
        {
            m_selecticos[i - 1] = transform.Find("rightInfo/info/CommonItemUI/Icon"+i).gameObject;
        }
        m_select_name1 = transform.Find("rightInfo/info/Text_Value_0").GetComponent<Text>();
        m_select_name2 = transform.Find("rightInfo/info/Text_Value_1").GetComponent<Text>();
        m_select_lv1 = transform.Find("rightInfo/info/Text_Value_2").GetComponent<Text>();
        m_lv_text1 = transform.Find("rightInfo/info/Text_Value_3").GetComponent<Text>();
        m_select_lv2 = transform.Find("rightInfo/info/Text_Value_4").GetComponent<Text>();
        m_pinzhi_text = transform.Find("rightInfo/info/Text_Value_5").GetComponent<Text>();
        m_select_pizhi = transform.Find("rightInfo/info/Text_Value_6").GetComponent<Text>();
        m_select_mp = transform.Find("rightInfo/info/Text_Value_7").GetComponent<Text>();
        m_next_dianshu = transform.Find("rightInfo/info/Text_Value_8").GetComponent<Text>();
        m_shengji = transform.Find("rightInfo/info/Text_Value_9").GetComponent<Text>();
        m_ShulianduBar = transform.Find("rightInfo/shengji/shuliandu").gameObject.AddComponent<ProgressBar>();
        m_ShulianduBar.Init
        (
            m_ShulianduBar.transform.Find("background").GetComponent<Image>(),
            m_ShulianduBar.transform.Find("foreground").GetComponent<Image>(),
            m_ShulianduBar.transform.Find("Text").GetComponent<Text>(), 260
        );
        m_Ceng = transform.Find("rightInfo/shengji/shuliandu/ceng").GetComponent<Text>();

        shuomingBtn = transform.Find("rightInfo/shengji/btnShuoming").GetComponent<GameUUButton>();
        m_shiyongBtn = transform.Find("rightInfo/shengji/shiyongBtn").GetComponent<GameUUButton>();

        m_ziyuanobj = transform.Find("ziyuan").gameObject;
        ziyuancloseBtn = transform.Find("ziyuan/closeBtn").GetComponent<GameUUButton>();
    }
}
