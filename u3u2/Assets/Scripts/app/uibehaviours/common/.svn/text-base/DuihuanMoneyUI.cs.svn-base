using UnityEngine;
using UnityEngine.UI;

public class DuihuanMoneyUI:MonoBehaviour
{
    public Text title;
    public GameUUButton closeBtn;
    public TabButtonGroup tbg;
    public InputTextUI shuliang;
    public MoneyItemUI huafei;
    public MoneyItemUI yongyou;
    public GameUUButton duihuanBtn;
    public Text tipsTxt;

    public void Init()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        title = transform.Find("title").GetComponent<Text>();
        GameObject toggleg = transform.Find("tabGroup").gameObject;
        tbg = toggleg.AddComponent<TabButtonGroup>();
        GameUUToggle tg1 = transform.Find("tabGroup/toggles/yinzi").GetComponent<GameUUToggle>();
        tbg.AddToggle(tg1);
        GameUUToggle tg2 = transform.Find("tabGroup/toggles/yinpiao").GetComponent<GameUUToggle>();
        tbg.AddToggle(tg2);
        GameUUToggle tg3 = transform.Find("tabGroup/toggles/guajidian").GetComponent<GameUUToggle>();
        tbg.AddToggle(tg3);

        shuliang=transform.Find("duihuanshuliang/InputTextUI").gameObject.AddComponent<InputTextUI>();
        MoneyItemUI m1 = shuliang.transform.Find("MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        m1.Init();
        shuliang.Init
        (
            shuliang.transform.Find("jianBtn").GetComponent<GameUUButton>(),
            shuliang.transform.Find("jiaBtn").GetComponent<GameUUButton>(),
            shuliang.transform.Find("MoneyItem/Text").GetComponent<Text>(),
            m1.moneyIcon, m1.inputBg
        );
        huafei = transform.Find("huafei/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        huafei.Init();
        yongyou = transform.Find("yongyou/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        yongyou.Init();
        duihuanBtn = transform.Find("duihuanbtn").GetComponent<GameUUButton>();
        tipsTxt = transform.Find("tips").GetComponent<Text>();

    }
}
