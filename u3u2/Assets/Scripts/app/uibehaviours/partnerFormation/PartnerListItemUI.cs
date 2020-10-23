using UnityEngine;
using UnityEngine.UI;

public class PartnerListItemUI : MonoBehaviour
{
    public Image bg;
    public Image partnerHeadIcon;
    public Text partnerName;
    public Text partnerLevel;
    public Text partnerCareer;
    public Text partnerTips;
    public long uuid=0;
    public int tplId;
    public GameObject zhan;
    public GameObject suo;
    public GameUUButton shangBtn;
    public GameUUButton headIconBtn;

    public void Init()
    {
        bg = transform.Find("Background").GetComponent<UnityEngine.UI.Image>();
        partnerHeadIcon = transform.Find("partnerHeadIcon").GetComponent<Image>();
        partnerName = transform.Find("partnerName").GetComponent<UnityEngine.UI.Text>();
        partnerLevel = transform.Find("partnerLevel").GetComponent<UnityEngine.UI.Text>();
        partnerCareer = transform.Find("partnerCareer").GetComponent<UnityEngine.UI.Text>();
        partnerTips = transform.Find("partnerTips").GetComponent<UnityEngine.UI.Text>();
        zhan = transform.Find("zhan").gameObject;
        suo = transform.Find("suo").gameObject;
        shangBtn = transform.Find("shang").GetComponent<GameUUButton>();
        headIconBtn = transform.Find("partnerHeadIcon").GetComponent<GameUUButton>();

    }
}
