using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RidePetUI : MonoBehaviour
{
	public GameUUButton closeBtn;
	public GameObject petModelContainer;
	public Text PetName;
	public RidePetListItemUI petListItemUI;
	public GameUUButton onBtn;
	public GameUUButton offBtn;
	public TabButtonGroup petListItemUIGroup;
	public Text propListItem;
	public List<Text> propList = new List<Text>();

    public void Init()
     {
    petModelContainer=transform.Find("petModelContainer").gameObject;
    PetName=transform.Find("Image 2/Text").GetComponent<UnityEngine.UI.Text>();
    petListItemUI=transform.Find("list/PetList/PetItem").gameObject.AddComponent<RidePetListItemUI>();
 petListItemUI.Init();
    petListItemUI.gameObject.SetActive(false);
    onBtn=transform.Find("onBtn").GetComponent<GameUUButton>();
    offBtn=transform.Find("offBtn").GetComponent<GameUUButton>();
    petListItemUIGroup=transform.Find("list/PetList").gameObject.AddComponent<TabButtonGroup>();
    propListItem=transform.Find("props/propList/Text").GetComponent<UnityEngine.UI.Text>();
    propListItem.gameObject.SetActive(false);
propList=new List<Text>();

        }
}
