using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XinFaXiulianJinengUI : MonoBehaviour 
{
    public GameObject objDefaultItem;
    public SimpleSkillItemUI skillItemUI;
    public Transform tfItemGrid;
    public Text textSkillName;
    public Text textSkillDescription;
    public Text textLevel;
    public ProgressBar barExp;
    public MoneyItemUI moneyItem_1;
    public MoneyItemUI moneyItem_2;
    public GameUUButton btnXiulian;
    public GameUUButton btnXiulianshici;

    public TabButtonGroup skillButtonGroup;
    public void Init()
    {
        tfItemGrid = transform.Find("skillListCanvas/skillList/grid");
        skillButtonGroup = tfItemGrid.gameObject.AddComponent<TabButtonGroup>();
        objDefaultItem = tfItemGrid.Find("Toggle").gameObject;
        skillItemUI = objDefaultItem.AddComponent<SimpleSkillItemUI>();
        skillItemUI.Init();
        textSkillName = transform.Find("BiaoTiText_22").GetComponent<Text>();
        textSkillDescription = transform.Find("Text_skillDescription").GetComponent<Text>();
        textLevel = transform.Find("Text_level").GetComponent<Text>();
        barExp = transform.Find("ZZProgress Bar").gameObject.AddComponent<ProgressBar>();
        barExp.Init(
            barExp.transform.Find("background").GetComponent<Image>(),
            barExp.transform.Find("foreground").GetComponent<Image>(),
            barExp.transform.Find("Text").GetComponent<Text>(), 325f,
            0.5f);
        moneyItem_1 = transform.Find("ZZMoneyItem").gameObject.AddComponent<MoneyItemUI>();
        moneyItem_1.Init();
        moneyItem_2 = transform.Find("ZZMoneyItem_1").gameObject.AddComponent<MoneyItemUI>();
        moneyItem_2.Init();
        btnXiulian = transform.Find("xiulianBtn").GetComponent<GameUUButton>();
        btnXiulianshici = transform.Find("xiulianshiciBtn").GetComponent<GameUUButton>();

    }
}
