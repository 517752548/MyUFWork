using UnityEngine;
using UnityEngine.UI;

public class SkillTipsUI : MonoBehaviour
{
	public Image icon;
	public Image frame;
	public Text nameTxt;
	public Text levelTxt;
	public Text costTxt;
	public Text descTxt;

    public void Init()
    {
        icon = transform.Find("background/up/icon").GetComponent<Image>();
        frame = transform.Find("background/up/frame").GetComponent<Image>();
        nameTxt = transform.Find("background/up/name").GetComponent<Text>();
        levelTxt = transform.Find("background/up/level").GetComponent<Text>();
        costTxt = transform.Find("background/up/cost").GetComponent<Text>();
        descTxt = transform.Find("background/down/desc").GetComponent<Text>();
    }
}
