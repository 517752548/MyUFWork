using UnityEngine;
using UnityEngine.UI;

public class PetStoreUI : MonoBehaviour
{
	public GameUUButton closeBtn;
    public Text m_title;
	public PetStoreLevelListItemUI levelListItemUI;
	public TabButtonGroup levelListGroup;
	public PetStorePetListItemUI petListItemUI;
	public TabButtonGroup petListGroup;
	public MoneyItemUI ownMoney;
	public MoneyItemUI petCost;
	public GameUUButton buyBtn;
    public Text m_tag_title;
    public Text m_des;
    //public Text m_des1;
    //public Text m_des2;

    public void Init()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        m_title = transform.Find("title").gameObject.GetComponent<Text>();
        levelListItemUI=transform.Find("Image 3/levelList/Toggle").gameObject.AddComponent<PetStoreLevelListItemUI>();
        levelListItemUI.Init();
        levelListGroup=transform.Find("Image 3/levelList").gameObject.AddComponent<TabButtonGroup>();
        levelListGroup.Init();
        petListItemUI=transform.Find("Image 5/petList/Toggle").gameObject.AddComponent<PetStorePetListItemUI>();
        petListItemUI.Init();
        petListGroup=transform.Find("Image 5/petList").gameObject.AddComponent<TabButtonGroup>();
        petListGroup.Init();
        ownMoney=transform.Find("MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        ownMoney.Init();
        petCost=transform.Find("MoneyItem 1").gameObject.AddComponent<MoneyItemUI>();
        petCost.Init();
        levelListItemUI.gameObject.SetActive(false);
        petListItemUI.gameObject.SetActive(false);
        buyBtn = transform.Find("buyBtn").GetComponent<GameUUButton>();
        m_tag_title = transform.Find("Image 1/Text").gameObject.GetComponent<Text>();
        m_des = transform.Find("Text").gameObject.GetComponent<Text>();
        //m_des1 = transform.Find("Text 1").gameObject.GetComponent<Text>();
        //m_des2 = transform.Find("Text 2").gameObject.GetComponent<Text>();
    }

}
