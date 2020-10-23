using UnityEngine;
using UnityEngine.UI;

public class PetStorePetListItemUI : MonoBehaviour
{
	public GameUUToggle toggle;
	public CommonItemUINoClick headIcon;
	public Text petName;
	public MoneyItemUI cost;
	public GameObject xuqiuSign;

    public void Init()
    {
        toggle=transform.GetComponent<GameUUToggle>();
        headIcon=transform.Find("CommonItemUINoClick90_90").gameObject.AddComponent<CommonItemUINoClick>();
        headIcon.Init();
        petName=transform.Find("Label").GetComponent<UnityEngine.UI.Text>();
        cost=transform.Find("MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        cost.Init();
        xuqiuSign=transform.Find("xuqiuSign").gameObject;
        xuqiuSign.gameObject.SetActive(false);

    }

}
