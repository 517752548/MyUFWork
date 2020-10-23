using UnityEngine;
using UnityEngine.UI;

public class BattlePetListItemUI : MonoBehaviour
{
	public Image headIcon;
	public Text petName;
	public Text petLevel;
	public ProgressBar petBloodBar;
	public long petUUID;

    public void Init()
    {
        headIcon = transform.Find("headIcon").GetComponent<Image>();
        petName = transform.Find("name").GetComponent<Text>();
        petLevel = transform.Find("level").GetComponent<Text>();
        petBloodBar = transform.Find("Progress Bar").gameObject.AddComponent<ProgressBar>();
        petBloodBar.Init
        (
            petBloodBar.transform.Find("background").GetComponent<Image>(), 
            petBloodBar.transform.Find("foreground").GetComponent<Image>(),
            petBloodBar.transform.Find("Text").GetComponent<Text>(), 78
        );
    }
}
