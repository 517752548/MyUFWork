using UnityEngine;
using System.Collections;

public class FubenbpphUI : MonoBehaviour {

    public GameObject m_obj_uiitem;
    public FBbpphItemUI m_mybpui;
    public GameUUButton m_btn_close;

    public void Init()
    {
        m_obj_uiitem=transform.Find("xinxiGo/dengjibang/scrollList/Image/grid/bangpaiItem").gameObject;
        FBbpphItemUI sc = m_obj_uiitem.AddComponent<FBbpphItemUI>();
        sc.Init();
        m_obj_uiitem.AddComponent<GameUUToggle>();
        m_obj_uiitem.transform.parent.gameObject.AddComponent<TabButtonGroup>();

        m_mybpui=transform.Find("xinxiGo/dengjibang/mybp").gameObject.AddComponent<FBbpphItemUI>();
        m_mybpui.Init();
        m_mybpui.gameObject.SetActive(false);
        m_btn_close = transform.Find("ZZBigPopWndWIthSideTab/closeBtn").GetComponent<GameUUButton>();
    }

}
