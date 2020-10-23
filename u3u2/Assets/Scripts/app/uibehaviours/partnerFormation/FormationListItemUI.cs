using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormationListItemUI : MonoBehaviour
{
    public GameUUToggle checkMark;
    public GameObject backgorund;
    public GameObject checkmark;
    public Text formationIndex;
    public GameUUButton formationBtn;
    public Text formationName;
    public List<FormationPartnerItemUI> partnerItemUIs = new List<FormationPartnerItemUI>();

    public void Init()
    {
        backgorund = transform.Find("Background").gameObject;
        checkmark = transform.Find("Checkmark").gameObject;
        formationIndex = transform.Find("formIdx").GetComponent<UnityEngine.UI.Text>();
        formationBtn = transform.Find("formBtn").GetComponent<GameUUButton>();
        formationName = transform.Find("formBtn/Text").GetComponent<UnityEngine.UI.Text>();
        partnerItemUIs = new List<FormationPartnerItemUI>();
        FormationPartnerItemUI f1 = transform.Find("partnerItem 0").gameObject.AddComponent<FormationPartnerItemUI>();
        f1.Init();
        partnerItemUIs.Add(f1);
        FormationPartnerItemUI f2 = transform.Find("partnerItem 1").gameObject.AddComponent<FormationPartnerItemUI>();
        f2.Init();
        partnerItemUIs.Add(f2);
        FormationPartnerItemUI f3 = transform.Find("partnerItem 2").gameObject.AddComponent<FormationPartnerItemUI>();
        f3.Init();
        partnerItemUIs.Add(f3);
        FormationPartnerItemUI f4 = transform.Find("partnerItem 3").gameObject.AddComponent<FormationPartnerItemUI>();
        f4.Init();
        partnerItemUIs.Add(f4);
        formationBtn.gameObject.SetActive(false);
    }
}
