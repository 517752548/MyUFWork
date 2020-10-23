using UnityEngine;
using UnityEngine.UI;

public class PartnerFormationUI : MonoBehaviour
{
    public PartnerFormationPUI partnerUI;
    public PartnerFormationFUI formationUI;
    public void Init()
    {
        partnerUI = transform.Find("partnerUI").gameObject.AddComponent<PartnerFormationPUI>();
        partnerUI.Init();
        formationUI = transform.Find("formationUI").gameObject.AddComponent<PartnerFormationFUI>();
        formationUI.Init();

    }
}
