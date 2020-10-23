using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewGuaJiUI : UIMonoBehaviour
{

    public GameUUButton closeBtn;

    public TabButtonGroup m_yudijiange;
    public Text[] m_jiange;

    public Text m_shengyushijian;
    public Text m_suoxudianshu;
    public Text m_changdianshu;
    public Text m_linshidianshu;

    public Dropdown m_renwuDropdown;
    public Dropdown m_chongwuDropdown;
    public Dropdown m_shichangDropdown;

    public UGUISwitchButton m_manguaiSBBtn;
    public UGUISwitchButton m_zantingSBBtn;

    public GameUUButton m_kaishiguaji;
    public GameUUButton m_zantingguaji;
    public GameUUButton m_chongzhi;

    public GameObject m_goumaiobj;
    public GameUUButton m_goumaicloseBtn;
    public InputTextUI m_inputmoney;
    public MoneyItemUI m_costmoney;
    public MoneyItemUI m_allmoney;
    public GameUUButton m_goumaiBtn;

    public override void Init()
    {
        base.Init();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();

        m_yudijiange = transform.Find("left/shijianjiange").gameObject.AddComponent<TabButtonGroup>();
        m_yudijiange.AddToggle(transform.Find("left/shijianjiange/jiange1").gameObject.GetComponent<GameUUToggle>());
        m_yudijiange.AddToggle(transform.Find("left/shijianjiange/jiange2").gameObject.GetComponent<GameUUToggle>());
        m_yudijiange.AddToggle(transform.Find("left/shijianjiange/jiange3").gameObject.GetComponent<GameUUToggle>());

        m_jiange = new Text[3];
        m_jiange[0] = transform.Find("left/shijianjiange/jiange1/BiaoTiText_22").gameObject.GetComponent<Text>();
        m_jiange[1] = transform.Find("left/shijianjiange/jiange2/BiaoTiText_22").gameObject.GetComponent<Text>();
        m_jiange[2] = transform.Find("left/shijianjiange/jiange3/BiaoTiText_22").gameObject.GetComponent<Text>();

        m_renwuDropdown = transform.Find("left/renwuDropdown").GetComponent<Dropdown>();
        m_chongwuDropdown = transform.Find("left/chongwuDropdown").GetComponent<Dropdown>();
        m_shichangDropdown = transform.Find("right/shichangDropdown").GetComponent<Dropdown>();

        m_manguaiSBBtn = transform.Find("left/manguai").gameObject.AddComponent<UGUISwitchButton>();
        m_manguaiSBBtn.Init
        (
            m_manguaiSBBtn.transform.Find("BackButton").GetComponent<GameUUButton>(),
            m_manguaiSBBtn.transform.Find("ForeButton").GetComponent<GameUUButton>(),
            m_manguaiSBBtn.transform.Find("Text").GetComponent<Text>()
        );

        m_zantingSBBtn = transform.Find("left/zanting").gameObject.AddComponent<UGUISwitchButton>();
        m_zantingSBBtn.Init
        (
            m_zantingSBBtn.transform.Find("BackButton").GetComponent<GameUUButton>(),
            m_zantingSBBtn.transform.Find("ForeButton").GetComponent<GameUUButton>(),
            m_zantingSBBtn.transform.Find("Text").GetComponent<Text>()
        );

        m_shengyushijian = transform.Find("right/valueText1").gameObject.GetComponent<Text>();
        m_suoxudianshu = transform.Find("right/valueText2").gameObject.GetComponent<Text>();
        m_changdianshu = transform.Find("right/valueText3").gameObject.GetComponent<Text>();
        m_linshidianshu = transform.Find("right/valueText4").gameObject.GetComponent<Text>();

        m_kaishiguaji = transform.Find("right/kaishiBtn").GetComponent<GameUUButton>();
        m_zantingguaji = transform.Find("right/zantingBtn").GetComponent<GameUUButton>();
        m_chongzhi = transform.Find("right/chongzhiBtn").GetComponent<GameUUButton>();


        m_goumaiobj = transform.Find("chongzhi").gameObject;
        m_goumaicloseBtn = transform.Find("chongzhi/closeBtn").GetComponent<GameUUButton>();
        MoneyItemUI shuliangmoney = transform.Find("chongzhi/goumaishuliang/InputTextUI/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        shuliangmoney.Init();
        m_inputmoney = transform.Find("chongzhi/goumaishuliang").gameObject.AddComponent<InputTextUI>();
        m_inputmoney.Init(
            m_inputmoney.transform.Find("InputTextUI/jianBtn").GetComponent<GameUUButton>(),
            m_inputmoney.transform.Find("InputTextUI/jiaBtn").GetComponent<GameUUButton>(),
            m_inputmoney.transform.Find("InputTextUI/MoneyItem/Text").GetComponent<Text>(),
            shuliangmoney.moneyIcon, shuliangmoney.inputBg
            );
        m_costmoney = transform.Find("chongzhi/MoneyItem1").gameObject.AddComponent<MoneyItemUI>();
        m_costmoney.Init();
        m_allmoney = transform.Find("chongzhi/MoneyItem2").gameObject.AddComponent<MoneyItemUI>();
        m_allmoney.Init();
        m_goumaiBtn = transform.Find("chongzhi/goumaiBtn").gameObject.GetComponent<GameUUButton>();
    }
}
