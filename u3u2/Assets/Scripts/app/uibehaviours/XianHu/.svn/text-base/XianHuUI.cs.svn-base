using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XianHuUI : UIMonoBehaviour
{
    public GameUUButton closeBtn;
    public GameUUButton m_kaiqizhufu;
    public GameUUButton m_kaiqiqifu;
    public Text m_zhufu_num;
    public Text m_qifu_num;
    public GameObject m_fugui_item;
    public GameObject m_zhizun_item;
    public GameObject m_zq_default_item;
    public GameObject m_fugui_deafult_item;
    public GameObject m_zhizun_default_item;

    public override void Init()
    {
        base.Init();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        m_kaiqizhufu = transform.Find("right/zhufuxianhu/kaiqiBtn").gameObject.GetComponent<GameUUButton>();
        m_kaiqiqifu = transform.Find("right/qifuxianhu/kaiqiBtn").gameObject.GetComponent<GameUUButton>();

        m_zhufu_num = transform.Find("right/zhufuxianhu/bg/num").gameObject.GetComponent<Text>();
        m_qifu_num = transform.Find("right/qifuxianhu/bg/num").gameObject.GetComponent<Text>();

        m_fugui_item = transform.Find("right/fugui").gameObject;
        m_zhizun_item = transform.Find("right/zhizun").gameObject;

        m_zq_default_item = transform.Find("left/fuscrollRect/grid/CommonItemUI").gameObject;

        m_fugui_deafult_item = transform.Find("right/fuguiscrollRect/grid/CommonItemUI").gameObject;
        m_zhizun_default_item = transform.Find("right/zhizunscrollRect/grid/CommonItemUI").gameObject;
    }
}
