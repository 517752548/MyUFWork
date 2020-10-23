using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimpleSkillItemUI : MonoBehaviour 
{
    public GameUUToggle toggle;
    public Image imageIcon;
    public Text textSkillName;
    public Text textLevel;

    public int skillId;

    public void Init()
    {
        toggle = transform.GetComponent<GameUUToggle>();
        imageIcon = transform.Find("Background/Icon").GetComponent<Image>();
        textSkillName = transform.Find("BiaoTiText_24").GetComponent<Text>();
        textLevel = transform.Find("ContentText_22").GetComponent<Text>();
    }
}
