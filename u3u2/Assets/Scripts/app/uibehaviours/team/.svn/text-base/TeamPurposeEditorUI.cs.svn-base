using UnityEngine;
using UnityEngine.UI;

public class TeamPurposeEditorUI : MonoBehaviour
{
	public GameObject dropDownButton;
	public GameObject singleButton;
	public GameObject dropDownListButton;
	public GameObject dropDownList;
	public ScrollNumberUI minLv;
	public ScrollNumberUI maxLv;
	public Text desc;
	public GameUUToggle autoMatchBtn;
	public GameUUButton okBtn;
	public GameUUButton closeBtn;

	public ToggleGroup purposeListToggleGroup;
	public TabButtonGroup purposeListTabButtonGroup;

    public void Init()
    {
        dropDownButton = transform.Find("purposeList/container/dropDownButton").gameObject;
        TeamPurposeButtonUI dropDownButtonUI = dropDownButton.AddComponent<TeamPurposeButtonUI>();
        dropDownButtonUI.Init
        (
            dropDownButton.transform.Find("SingleText").GetComponent<Text>(),
            dropDownButton.transform.Find("DoubleTextMain").GetComponent<Text>(),
            dropDownButton.transform.Find("DoubleTextSub").GetComponent<Text>(),
            dropDownButton.transform.Find("Background/Checkmark").gameObject,
            null
        );
        dropDownButton.gameObject.SetActive(false);
        singleButton = transform.Find("purposeList/container/singleButton").gameObject;
        TeamPurposeButtonUI singleButtonUI = singleButton.AddComponent<TeamPurposeButtonUI>();
        singleButtonUI.Init
        (
            singleButtonUI.transform.Find("Label").GetComponent<Text>(),
            null, null,
            singleButtonUI.transform.Find("Background/Checkmark").gameObject,
            null
        );
        singleButton.gameObject.SetActive(false);
        dropDownListButton = transform.Find("purposeList/container/dropDownListButton").gameObject;
        TeamPurposeButtonUI dropDownListButtonUI = dropDownListButton.AddComponent<TeamPurposeButtonUI>();
        dropDownListButtonUI.Init
        (
            dropDownListButton.transform.Find("Label").GetComponent<Text>(),
            null, null, null, null
        );
        dropDownListButton.gameObject.SetActive(false);
        dropDownList = transform.Find("purposeList/container/dropDownList").gameObject;
        dropDownList.gameObject.SetActive(false);
        minLv = transform.Find("minLv").gameObject.AddComponent<ScrollNumberUI>();
        minLv.Init();
        maxLv = transform.Find("maxLv").gameObject.AddComponent<ScrollNumberUI>();
        maxLv.Init();
        desc = transform.Find("desc").GetComponent<Text>();
        autoMatchBtn = transform.Find("autoMatchBtn").GetComponent<GameUUToggle>();
        okBtn = transform.Find("okBtn").GetComponent<GameUUButton>();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        purposeListToggleGroup = transform.Find("purposeList").GetComponent<ToggleGroup>();
        purposeListTabButtonGroup = transform.Find("purposeList").gameObject.AddComponent<TabButtonGroup>();


    }
}
