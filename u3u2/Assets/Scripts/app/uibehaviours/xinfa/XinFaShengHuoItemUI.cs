using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XinFaShengHuoItemUI : MonoBehaviour 
{

    public CommonItemUI icon;
    public Text m_skill_name;
    public Text m_skill_lv;

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
        m_skill_name = transform.Find("BiaoTiText_24").GetComponent<Text>();
        m_skill_lv = transform.Find("ContentText_22").GetComponent<Text>();
    }
}
