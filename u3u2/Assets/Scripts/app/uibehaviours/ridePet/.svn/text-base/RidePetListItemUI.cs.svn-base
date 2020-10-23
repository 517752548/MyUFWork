using UnityEngine;
using UnityEngine.UI;

public class RidePetListItemUI : MonoBehaviour
{
    public Image bg;
    public Image selectedBg;
    public GameUUToggle toggle;
    public Image headIcon;
    public Text petName;
    public Text petLevel;
    public GameObject rideSign;
    public long uuid;
    public int tplId;

    public void Init()
    {
        bg = transform.Find("Background").GetComponent<UnityEngine.UI.Image>();
        selectedBg = transform.Find("Background/Checkmark").GetComponent<UnityEngine.UI.Image>();
        toggle = transform.GetComponent<GameUUToggle>();
        headIcon = transform.Find("Icon").GetComponent<UnityEngine.UI.Image>();
        petName = transform.Find("petName").GetComponent<UnityEngine.UI.Text>();
        petLevel = transform.Find("petLevel").GetComponent<UnityEngine.UI.Text>();
        rideSign = transform.Find("rideSign").gameObject;
        uuid = 0;
        tplId = 0;

    }
}
