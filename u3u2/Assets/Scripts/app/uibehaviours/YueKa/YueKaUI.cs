using UnityEngine;
using UnityEngine.UI;

public class YueKaUI : UIMonoBehaviour
{
    public GameUUButton closeBtn;
    public GameObject m_goumaiobj;
    public GameObject m_lingquobj;
    public MoneyItemUI m_huafei;
    public MoneyItemUI m_huode;
    public GameUUButton m_goumaibtn;
    public GameUUButton m_lingqubtn;
    public Text m_lingqutext;
    public Text m_tian;
    public GameObject m_jinding;
    public GameObject m_jinpiao1;
    public GameObject m_jinpiao2;

    public override void Init()
    {
        base.Init();
        closeBtn = transform.Find("pos/closeBtn").GetComponent<GameUUButton>();

        m_goumaiobj = transform.Find("pos/goumai").gameObject;
        m_lingquobj = transform.Find("pos/lingqu").gameObject;
        m_huafei = transform.Find("pos/goumai/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        m_huafei.Init();
        m_huode = transform.Find("pos/lingqu/MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        m_huode.Init();
        m_goumaibtn = transform.Find("pos/goumai/goumaiBtn").GetComponent<GameUUButton>();
        m_jinding = transform.Find("pos/goumai/jinding_value").gameObject;
        m_jinpiao1 = transform.Find("pos/goumai/jinpiao_value1").gameObject;
        m_jinpiao2 = transform.Find("pos/goumai/jinpiao_value2").gameObject;
        m_lingqubtn = transform.Find("pos/lingqu/lingquBtn").GetComponent<GameUUButton>();
        m_lingqutext = transform.Find("pos/lingqu/lingquBtn/Text").GetComponent<Text>();
        m_tian = transform.Find("pos/lingqu/tian").GetComponent<Text>();
    }
}
