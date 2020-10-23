using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XinFaFuzhuJinengUI : MonoBehaviour 
{
    public GameObject objDefaultSkillItem;
    public SimpleSkillItemUI SkillItemUI;
    public Transform tfSkillGrid;
    public Text text_skillName;
    public GameObject objDazao;
    public GameObject objPengren;
    public Text textDazaoLevel;
    public GameUUButton btnDazaoLeftArrow;
    public GameUUButton btnDazaoRightArrow;
    public CommonItemUI[] pengrenUIs;

    public MoneyItemUI moneyItemUI1;
    public MoneyItemUI moneyItemUI2;
    public MoneyItemUI moneyItemUI_huoli;
    public GameUUButton btnZhizuo;
    public GameUUButton btnLearnSkill;

    public TabButtonGroup skillButtonGroup;

    public void Init()
    {
        tfSkillGrid = transform.Find("skillListCanvas/skillList/grid");
        skillButtonGroup = tfSkillGrid.gameObject.AddComponent<TabButtonGroup>();
        objDefaultSkillItem = tfSkillGrid.transform.Find("Toggle").gameObject;
        SkillItemUI = objDefaultSkillItem.AddComponent<SimpleSkillItemUI>();
        SkillItemUI.Init();
        text_skillName = transform.Find("BiaoTiText_22").GetComponent<Text>();
        objDazao = transform.Find("dazao").gameObject;
        objPengren = transform.Find("pengren").gameObject;
        textDazaoLevel = objDazao.transform.Find("Text_level").GetComponent<Text>();
        btnDazaoLeftArrow = objDazao.transform.Find("btn_leftArrow").GetComponent<GameUUButton>();
        btnDazaoRightArrow = objDazao.transform.Find("btn_rightArrow").GetComponent<GameUUButton>();

        pengrenUIs = new CommonItemUI[10];
        for (int i = 0; i < pengrenUIs.Length; i++)
        {
            pengrenUIs[i] = objPengren.transform.Find("item_" + (i + 1)).gameObject.AddComponent<CommonItemUI>();
            pengrenUIs[i].Init();
        }

        moneyItemUI_huoli = transform.Find("shengji/Text_huoli").gameObject.AddComponent<MoneyItemUI>();
        moneyItemUI_huoli.Init(null,moneyItemUI_huoli.GetComponent<Text>(),null);
        moneyItemUI1 = transform.Find("shengji/ZZMoneyItem").gameObject.AddComponent<MoneyItemUI>();
        moneyItemUI1.Init();
        moneyItemUI2 = transform.Find("shengji/ZZMoneyItem_1").gameObject.AddComponent<MoneyItemUI>();
        moneyItemUI2.Init();
        btnZhizuo = transform.Find("shengji/shengjiBtn").GetComponent<GameUUButton>();
        btnLearnSkill = transform.Find("shengji/yijianshiciiBtn").GetComponent<GameUUButton>();

    }
}
