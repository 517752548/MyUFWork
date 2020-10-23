using UnityEngine;
using UnityEngine.UI;

public class PetTrainingUI : UIMonoBehaviour
{
    public GameObject qiangzhuang;
    public GameObject minjie;
    public GameObject zhili;
    public GameObject xinyang;
    public GameObject naili;

    public MoneyItemUI chujiCost;
    public MoneyItemUI zhongjiCost;
    public MoneyItemUI gaojiCost;

    public TabButtonGroup peiyangTypeGroup;

    public GameUUButton peiyangBtn;
    public GameUUButton tihuanBtn;

    public Image zhongjiCheckBox;
    public Image gaojiCheckBox;
    public Text zhongjiLabel;
    public Text gaojiLabel;

    public override void Init()
    {
        base.Init();
        qiangzhuang = transform.Find("peiyangRes/qiangzhuang").gameObject;
        minjie = transform.Find("peiyangRes/minjie").gameObject;
        zhili = transform.Find("peiyangRes/zhili").gameObject;
        xinyang = transform.Find("peiyangRes/xinyang").gameObject;
        naili = transform.Find("peiyangRes/naili").gameObject;
        chujiCost = transform.Find("peiyangType/chuji/cost").gameObject.AddComponent<MoneyItemUI>();
        chujiCost.Init
        (
            chujiCost.transform.Find("Image").GetComponent<Image>(),
            chujiCost.transform.Find("Text").GetComponent<Text>(),
            null
        );
        zhongjiCost = transform.Find("peiyangType/zhongji/cost").gameObject.AddComponent<MoneyItemUI>();
        zhongjiCost.Init
        (
             zhongjiCost.transform.Find("Image").GetComponent<Image>(),
             zhongjiCost.transform.Find("Text").GetComponent<Text>(),
             null
        );
        gaojiCost = transform.Find("peiyangType/gaoji/cost").gameObject.AddComponent<MoneyItemUI>();
        gaojiCost.Init
        (
            gaojiCost.transform.Find("Image").GetComponent<Image>(),
             gaojiCost.transform.Find("Text").GetComponent<Text>(),
             null
        );
        peiyangTypeGroup = transform.Find("peiyangType").gameObject.AddComponent<TabButtonGroup>();
        peiyangTypeGroup.AddToggle(transform.Find("peiyangType/chuji").gameObject.GetComponent<GameUUToggle>());
        peiyangTypeGroup.AddToggle(transform.Find("peiyangType/zhongji").gameObject.GetComponent<GameUUToggle>());
        peiyangTypeGroup.AddToggle(transform.Find("peiyangType/gaoji").gameObject.GetComponent<GameUUToggle>());
        peiyangBtn = transform.Find("peiyangBtn").GetComponent<GameUUButton>();
        tihuanBtn = transform.Find("tihuanBtn").GetComponent<GameUUButton>();

        zhongjiCheckBox = transform.Find("peiyangType/zhongji/Background").GetComponent<Image>();
        gaojiCheckBox = transform.Find("peiyangType/gaoji/Background").GetComponent<Image>();

        zhongjiLabel = transform.Find("peiyangType/zhongji/BiaoTiText_24").GetComponent<Text>();
        gaojiLabel = transform.Find("peiyangType/gaoji/BiaoTiText_24").GetComponent<Text>();
    }

}


