using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapTipsUI : MonoBehaviour
{
    public RectTransform m_bg;
    public Text m_map_name;
    public Text m_map_level;
    public Text m_map_desc;

    public CommonItemUI m_defaultitem;

    public GameUUButton m_chuansongBtn;

    public void Init()
    {
        m_bg = transform.Find("bg").GetComponent<RectTransform>();
        m_map_name = transform.Find("mapname").GetComponent<Text>();
        m_map_level = transform.Find("level_value").GetComponent<Text>();
        m_map_desc = transform.Find("desc").GetComponent<Text>();

        m_defaultitem = transform.Find("scrollRect/grid/CommonItemUIWithToggle70_70").gameObject.AddComponent<CommonItemUI>();
        m_defaultitem.Init();
        m_defaultitem.gameObject.SetActive(false);
        m_chuansongBtn = transform.Find("chuansongBtn").gameObject.GetComponent<GameUUButton>();
    }
    
}
