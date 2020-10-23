using UnityEngine;
using UnityEngine.UI;

public class PartnerFormationPUI : MonoBehaviour
{
	public TabButtonGroup partnerTypes;
	public PartnerListItemUI partnerListItemUI;
	public RectTransform partnerListContainer;

    public void Init()
    {
        partnerTypes = transform.Find("partnerTypes").gameObject.AddComponent<TabButtonGroup>();
        partnerTypes.AddToggle(transform.Find("partnerTypes/toggles/toggle1").gameObject.GetComponent<GameUUToggle>());
        partnerTypes.AddToggle(transform.Find("partnerTypes/toggles/toggle2").gameObject.GetComponent<GameUUToggle>());
        partnerTypes.AddToggle(transform.Find("partnerTypes/toggles/toggle3").gameObject.GetComponent<GameUUToggle>());
        partnerTypes.AddToggle(transform.Find("partnerTypes/toggles/toggle4").gameObject.GetComponent<GameUUToggle>());
        partnerTypes.AddToggle(transform.Find("partnerTypes/toggles/toggle5").gameObject.GetComponent<GameUUToggle>());

        partnerListItemUI = transform.Find("partnerListScroll/PartnerList/PartnerItem").gameObject.AddComponent<PartnerListItemUI>();
        partnerListItemUI.Init();
        partnerListItemUI.gameObject.SetActive(false);
        partnerListContainer = transform.Find("partnerListScroll/PartnerList").GetComponent<UnityEngine.RectTransform>();

    }
}
