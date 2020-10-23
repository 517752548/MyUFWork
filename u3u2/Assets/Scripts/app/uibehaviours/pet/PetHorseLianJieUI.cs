using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PetHorseLianJieUI : MonoBehaviour 
{
    public Image m_closebtn;
    public GameUUButton m_savebtn;
    public GameUUButton m_quxiaobtn;
    public PetHorseLianJiePackUI m_pack;

    public void Init()
    {
        m_closebtn = transform.Find("closebg").GetComponent<Image>();
        RectTransform zujiebgrect = m_closebtn.GetComponent<RectTransform>();
        zujiebgrect.sizeDelta = new Vector2(UGUIConfig.ScreenWidth, UGUIConfig.ScreenHeight);
        m_savebtn = transform.Find("ZZButton0").GetComponent<GameUUButton>();
        m_quxiaobtn = transform.Find("ZZButton1").GetComponent<GameUUButton>();

        m_pack = transform.Find("scrollRect/grid/ZZCommonItemUI").gameObject.AddComponent<PetHorseLianJiePackUI>();
    }

    public void show()
    {
        this.gameObject.SetActive(true);
    }
    public void hide()
    {
        this.gameObject.SetActive(false);
    }
}
