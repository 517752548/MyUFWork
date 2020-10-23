using UnityEngine;
using UnityEngine.UI;

public class MainUITeamMemberItemUI : MonoBehaviour
{
    public Image headIcon;
    public GameObject zan;
    public Text nameTxt;
    public Text lvTxt;
    public ProgressBar hp;
    public ProgressBar mp;
    public Image job;
    
    public void Init(){
        headIcon = transform.Find("headIcon").GetComponent<Image>();
        zan = transform.Find("zan").gameObject;
        nameTxt = transform.Find("name").GetComponent<Text>();
        lvTxt = transform.Find("lv").GetComponent<Text>();
        hp = transform.Find("ruleHP").gameObject.AddComponent<ProgressBar>();
        hp.Init(hp.transform.Find("bg").GetComponent<Image>(), hp.transform.Find("fg").GetComponent<Image>(), null, 110);
        mp = transform.Find("ruleMP").gameObject.AddComponent<ProgressBar>();
        mp.Init(mp.transform.Find("bg").GetComponent<Image>(), mp.transform.Find("fg").GetComponent<Image>(), null, 110);
        job = transform.Find("job").GetComponent<Image>();
    }
    
}
