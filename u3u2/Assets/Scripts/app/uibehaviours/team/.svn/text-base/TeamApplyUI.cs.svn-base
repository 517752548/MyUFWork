using UnityEngine;
using UnityEngine.UI;

public class TeamApplyUI : UIMonoBehaviour
{
	public TeamPurposeButtonUI dropDownButton;
	public TeamPurposeButtonUI singleButton;
	public TeamPurposeButtonUI dropDownListButton;
	public GameObject dropDownList;
	public TeamApplyListItemUI applyListItem;
	public GameUUButton createTeamBtn;
	public GameUUButton autoMatchBtn;
	public GameUUButton cancelAutoMatchBtn;
	public GameUUButton refreshBtn;
	public GameUUButton closeBtn;

	public ToggleGroup purposeListToggleGroup;
	public TabButtonGroup purposeListTabButtonGroup;

    public override void Init()
    {
        base.Init();
        applyListItem = transform.Find("applyList/itemsList/item").gameObject.AddComponent<TeamApplyListItemUI>();
        applyListItem.Init();
        applyListItem.gameObject.SetActive(false);

        createTeamBtn = transform.Find("createTeamBtn").GetComponent<GameUUButton>();
        autoMatchBtn = transform.Find("autoMatchBtn").GetComponent<GameUUButton>();
        cancelAutoMatchBtn = transform.Find("cancelAutoMatchBtn").GetComponent<GameUUButton>();
        refreshBtn = transform.Find("refreshBtn").GetComponent<GameUUButton>();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        purposeListToggleGroup = transform.Find("purposeList").GetComponent<ToggleGroup>();
        purposeListTabButtonGroup = transform.Find("purposeList").gameObject.AddComponent<TabButtonGroup>();
        singleButton = transform.Find("purposeList/container/singleButton").gameObject.AddComponent<TeamPurposeButtonUI>();
        singleButton.Init
        (
            singleButton.transform.Find("Label").GetComponent<Text>(), 
            null, null, null, 
            singleButton.transform.Find("Image").gameObject
        );
        dropDownButton = transform.Find("purposeList/container/dropDownButton").gameObject.AddComponent<TeamPurposeButtonUI>();
        dropDownButton.Init
        (
            dropDownButton.transform.Find("SingleText").GetComponent<Text>(),
            dropDownButton.transform.Find("DoubleTextMain").GetComponent<Text>(),
            dropDownButton.transform.Find("DoubleTextSub").GetComponent<Text>(), 
            null, null
        );
        dropDownListButton = transform.Find("purposeList/container/dropDownListButton").gameObject.AddComponent<TeamPurposeButtonUI>();
        dropDownListButton.Init
        (
            singleButton.transform.Find("Label").GetComponent<Text>(), 
            null, null, null, 
            singleButton.transform.Find("Image").gameObject
        );
        dropDownList = transform.Find("purposeList/container/dropDownList").gameObject;
        
        dropDownList.SetActive(false);
        singleButton.gameObject.SetActive(false);
        dropDownButton.gameObject.SetActive(false);
        dropDownButton.multLabelMain.gameObject.SetActive(false);
        dropDownButton.multLabelSub.gameObject.SetActive(false);
        dropDownListButton.gameObject.SetActive(false);
        
        autoMatchBtn.gameObject.SetActive(false);
        cancelAutoMatchBtn.gameObject.SetActive(false);
    }
}
