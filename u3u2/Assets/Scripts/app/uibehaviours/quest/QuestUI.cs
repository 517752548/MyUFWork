using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public GameUUButton CloseButton;

    public GameUUToggle QuestMainToggle;

    public GameUUToggle QuestChildToggle;

    public GridLayoutGroup toggleGrid;

    public TabButtonGroup tabButtonGroup;
    public GameUUToggle YiJieTab;
    public GameUUToggle WeiJieTab;

    public GameUUButton GiveUpQuestButton;
    public GameUUButton DoItButton;
    public Text DoItButtonText;
    public Text QuestTitleText;

    public Text QuestDescText;

    public ToggleGroup mainToggleGroup;
    public TabButtonGroup mainTabButtonGroup;

    public TabButtonGroup childTabButtonGroup;
    public ToggleGroup childToggleGroup;

    public void Init()
    {
        CloseButton = transform.Find("closeBtn").GetComponent<GameUUButton>();
        QuestMainToggle = transform.Find("leftPanel/ScrollView/ToggleGrid/Toggle").GetComponent<GameUUToggle>();
        QuestChildToggle = transform.Find("leftPanel/ScrollView/ToggleGrid/Toggle 1").GetComponent<GameUUToggle>();
        toggleGrid = transform.Find("leftPanel/ScrollView/ToggleGrid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        tabButtonGroup = transform.Find("tabGroup").gameObject.AddComponent<TabButtonGroup>();
        tabButtonGroup.AddToggle(transform.Find("tabGroup/toggles/yijie").GetComponent<GameUUToggle>());
        tabButtonGroup.AddToggle(transform.Find("tabGroup/toggles/weijie").GetComponent<GameUUToggle>());

        YiJieTab = transform.Find("tabGroup/toggles/yijie").GetComponent<GameUUToggle>();
        WeiJieTab = transform.Find("tabGroup/toggles/weijie").GetComponent<GameUUToggle>();
        GiveUpQuestButton = transform.Find("rightPanel/GiveUpBtn").GetComponent<GameUUButton>();
        DoItButton = transform.Find("rightPanel/DoItButton").GetComponent<GameUUButton>();
        DoItButtonText = transform.Find("rightPanel/DoItButton/Text").GetComponent<UnityEngine.UI.Text>();
        QuestTitleText = transform.Find("rightPanel/QuestTitle").GetComponent<UnityEngine.UI.Text>();
        QuestDescText = transform.Find("rightPanel/QuestDesc").GetComponent<UnityEngine.UI.Text>();
        mainToggleGroup = transform.Find("leftPanel/Image").GetComponent<UnityEngine.UI.ToggleGroup>();
        mainTabButtonGroup = transform.Find("leftPanel/Image").gameObject.AddComponent<TabButtonGroup>();
        childTabButtonGroup = transform.Find("leftPanel/ScrollView/ToggleGrid").gameObject.AddComponent<TabButtonGroup>();
        childToggleGroup = transform.Find("leftPanel/ScrollView/ToggleGrid").GetComponent<UnityEngine.UI.ToggleGroup>();

    }
}
