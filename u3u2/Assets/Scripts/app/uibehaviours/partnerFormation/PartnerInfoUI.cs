using UnityEngine;
using UnityEngine.UI;

public class PartnerInfoUI : MonoBehaviour
{
	public GameUUButton closeBtn;
	public Text partnerName;
	public Text partnerCareer;
	public Text partnerLevel;
	public Text partnerTips;
	public GameObject partnerModelContainer;
	public Text qixue;
	public Text sudu;
	public Text wugong;
	public Text fagong;
	public Text wufang;
	public Text fafang;
	public CommonItemUI skillItem;
	public GameUUButton unlockBtn;
	public GameUUButton onBtn;
	public GameUUButton offBtn;
	public GameUUButton prevBtn;
	public GameUUButton nextBtn;

    public void Init()
    {
        closeBtn = transform.Find("CloseButton").GetComponent<GameUUButton>();
        partnerName = transform.Find("Image/Text").GetComponent<UnityEngine.UI.Text>();
        partnerCareer = transform.Find("career").GetComponent<UnityEngine.UI.Text>();
        partnerLevel = transform.Find("level").GetComponent<UnityEngine.UI.Text>();
        partnerTips = transform.Find("tips").GetComponent<UnityEngine.UI.Text>();
        partnerModelContainer = transform.Find("container").gameObject;
        qixue = transform.Find("props/oneProp/qixue").GetComponent<UnityEngine.UI.Text>();
        sudu = transform.Find("props/oneProp 1/sudu").GetComponent<UnityEngine.UI.Text>();
        wugong = transform.Find("props/oneProp 2/wugong").GetComponent<UnityEngine.UI.Text>();
        fagong = transform.Find("props/oneProp 3/wufang").GetComponent<UnityEngine.UI.Text>();
        wufang = transform.Find("props/oneProp 4/fagong").GetComponent<UnityEngine.UI.Text>();
        fafang = transform.Find("props/oneProp 5/fafang").GetComponent<UnityEngine.UI.Text>();
        skillItem = transform.Find("skillsScroll/skillList/CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        skillItem.Init
        (
            skillItem.transform.Find("Image").GetComponent<Image>(),
            skillItem.transform.Find("Icon").GetComponent<Image>(),
            skillItem.transform.Find("BianKuang").GetComponent<Image>(),
            skillItem.transform.Find("Num").GetComponent<Text>(),
            skillItem.transform.Find("Name").GetComponent<Text>(),
            null, null, null, null, null
        );
        unlockBtn = transform.Find("unlockBtn").GetComponent<GameUUButton>();
        onBtn = transform.Find("onBtn").GetComponent<GameUUButton>();
        offBtn = transform.Find("offBtn").GetComponent<GameUUButton>();
        prevBtn = transform.Find("prevBtn").GetComponent<GameUUButton>();
        nextBtn = transform.Find("nextBtn").GetComponent<GameUUButton>();
        skillItem.gameObject.SetActive(false);


    }
}
