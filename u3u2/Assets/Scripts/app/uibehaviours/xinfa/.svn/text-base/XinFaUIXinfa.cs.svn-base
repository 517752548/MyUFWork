using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class XinFaUIXinfa : UIMonoBehaviour
{
    public SlideButton slideBtn;
    public TabButtonGroup m_XinfaTBG;
    public List<GameUUToggle> m_XinfaItems;
    public Text m_XinfaName;
    public Text m_XinfaLevel;
    public Text m_XinfaDetail;
    public Text m_XinfaOrder;
    public List<GameObject> m_XinfaSkills;
    public MoneyItemUI costMoney1;
    public MoneyItemUI costMoney2;

    public GameUUButton shengjiBtn;
    public GameUUButton shengjishiciBtn;

    public GameObject leftobj;
    public GameObject rightobj;

    public override void Init()
    {
        base.Init();
        leftobj = transform.Find("xinfa").gameObject;
        rightobj = transform.Find("rightInfo").gameObject;
        slideBtn = transform.Find("xinfa/ZZSlideButton").gameObject.AddComponent<SlideButton>();
        slideBtn.Init
        (
            slideBtn.transform.Find("Button").GetComponent<GameUUButton>(),
            slideBtn.transform.Find("Button/BiaoTiText_24").GetComponent<Text>(),
            slideBtn.transform.Find("BiaoTiText_24").GetComponent<Text>(),
            "", "", new Vector3(-52, 0, 0), new Vector3(52, 0, 0)
        );

        m_XinfaTBG = transform.Find("xinfa/xinfalist").gameObject.AddComponent<TabButtonGroup>();
        m_XinfaItems = new List<GameUUToggle>();
        for (int i = 1; i < 5; ++i)
        {
            GameUUToggle toggle = transform.Find("xinfa/xinfalist/Toggle"+i).GetComponent<GameUUToggle>();
            m_XinfaTBG.AddToggle(toggle);
            m_XinfaItems.Add(toggle);
        }

        m_XinfaName = transform.Find("rightInfo/xiaoguo/BiaoTiText_22").GetComponent<Text>();
        m_XinfaLevel = transform.Find("rightInfo/xiaoguo/BiaoTiText_23").GetComponent<Text>();
        m_XinfaDetail = transform.Find("rightInfo/detail").GetComponent<Text>();
        m_XinfaOrder = transform.Find("rightInfo/orderinfo").GetComponent<Text>();

        costMoney1 = transform.Find("rightInfo/shengji/ZZMoneyItem").gameObject.AddComponent<MoneyItemUI>();
        costMoney1.Init
        (
            costMoney1.transform.Find("Image").GetComponent<Image>(),
            costMoney1.transform.Find("Text").GetComponent<Text>(),
            null
        );
        costMoney2 = transform.Find("rightInfo/shengji/ZZMoneyItem 1").gameObject.AddComponent<MoneyItemUI>();
        costMoney2.Init
        (
            costMoney2.transform.Find("Image").GetComponent<Image>(),
            costMoney2.transform.Find("Text").GetComponent<Text>(),
            null
        );
        shengjiBtn = transform.Find("rightInfo/shengji/shengjiBtn").GetComponent<GameUUButton>();
        shengjishiciBtn = transform.Find("rightInfo/shengji/shengjishiciBtn").GetComponent<GameUUButton>();

        m_XinfaSkills = new List<GameObject>();
        for (int i = 1; i < 5; ++i)
        {
            m_XinfaSkills.Add(transform.Find("rightInfo/skilllist/Toggle" + i).gameObject);
        }
    }
}
