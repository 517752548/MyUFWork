using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XinFaSkillItemUI : MonoBehaviour
{
    public CommonItemUI icon;
    public Text skillName;
    //public Text skillLevel;
    public Text skillDesc;
    public Text openDesc;
    public Transform m_jiantou;
    public Transform m_change;

    public void Init()
    {
        icon = transform.Find("Background/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        icon.Init
        (
            icon.transform.Find("Image").GetComponent<Image>(),
            icon.transform.Find("Icon").GetComponent<Image>(),
            icon.transform.Find("BianKuang").GetComponent<Image>()
            , null, null, null, null, null, null, null
        );
        skillName = transform.Find("BiaoTiText_24").GetComponent<Text>();
        skillDesc = transform.Find("ContentText_22").GetComponent<Text>();
        openDesc = transform.Find("ContentText_23").GetComponent<Text>();
        if (icon.biangkuang != null)
        {
            icon.biangkuang.gameObject.SetActive(false);
        }

        m_jiantou = transform.Find("jiantou");
        m_change = transform.Find("change");
    }
}
