using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class XinFaItemUI : MonoBehaviour
{
    public GameUUToggle toggle;
    public Image icon;
    public Text xinfaName;
    public Text xinfaDesc;
    public Text xinfaLevel;

    public void Init()
    {
        toggle = GetComponent<GameUUToggle>();
        transform.Find("CommonItemUI/BianKuang").gameObject.SetActive(false);
        icon = transform.Find("CommonItemUI/Icon").GetComponent<Image>();
        xinfaName = transform.Find("BiaoTiText_24").GetComponent<Text>();
        xinfaDesc = transform.Find("ContentText_22").GetComponent<Text>();
    }
}
