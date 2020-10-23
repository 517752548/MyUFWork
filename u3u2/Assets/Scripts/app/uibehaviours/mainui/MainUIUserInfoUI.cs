using UnityEngine;
using UnityEngine.UI;

public class MainUIUserInfoUI : MonoBehaviour
{
    public GameObject roleInfo;
    public Image roleIcon;
    public ProgressBar roleHp;
    public ProgressBar roleMp;
    public ProgressBar roleSp;
    public Text roleLevel;

    public GameObject petInfo;
    public Image petIcon;
    public ProgressBar petHp;
    public ProgressBar petMp;
    public Text petLevel;

    public Image defaultPetHead;
    public Image m_guajiicon;
    
    public void Init(){
        roleInfo = transform.Find("roleInfo").gameObject;
        roleIcon = transform.Find("roleInfo/ruleHeadImg").GetComponent<Image>();
        roleHp = transform.Find("roleInfo/roleHP").gameObject.AddComponent<ProgressBar>();
        roleHp.Init(roleHp.transform.Find("bg").GetComponent<Image>(), roleHp.transform.Find("fg").GetComponent<Image>(), null, 77);
        
        roleMp = transform.Find("roleInfo/roleMP").gameObject.AddComponent<ProgressBar>();
        roleMp.Init(roleMp.transform.Find("bg").GetComponent<Image>(), roleMp.transform.Find("fg").GetComponent<Image>(), null, 77);
        
        roleSp = transform.Find("roleInfo/roleSP").gameObject.AddComponent<ProgressBar>();
        roleSp.Init(roleSp.transform.Find("bg").GetComponent<Image>(), roleSp.transform.Find("fg").GetComponent<Image>(), null, 77);
        
        roleLevel = transform.Find("roleInfo/roleLv").GetComponent<Text>();
        petInfo = transform.Find("petInfo").gameObject;
        petIcon = transform.Find("petInfo/petHeadImg").GetComponent<Image>();
        petHp = transform.Find("petInfo/petHP").gameObject.AddComponent<ProgressBar>();
        petHp.Init(petHp.transform.Find("bg").GetComponent<Image>(), petHp.transform.Find("fg").GetComponent<Image>(), null, 57);
        
        petMp = transform.Find("petInfo/petMP").gameObject.AddComponent<ProgressBar>();
        petMp.Init(petMp.transform.Find("bg").GetComponent<Image>(), petMp.transform.Find("fg").GetComponent<Image>(), null, 57);
        
        petLevel = transform.Find("petInfo/petLv").GetComponent<Text>();
        defaultPetHead = transform.Find("petInfo/petDefaultHead").GetComponent<Image>();
        m_guajiicon = transform.Find("roleInfo/guajiicon").GetComponent<Image>();
        
    }
    
    
}
