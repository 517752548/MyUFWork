using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIQuestUI : MonoBehaviour
{
    public GameObject questObj;
    public GameObject questMoveObj;
    public GameUUButton shousuoBtn;
    public GameUUButton showBtn;
    public GameUUToggle questToggle;
    public GameUUToggle teamToggle;
    public TabButtonGroup questTabButtonGroup;
    public GameObject questScroll;
    public GridLayoutGroup questGrid;
    public GameUUButton questItem;
    public GameObject teammembers;
    public List<MainUITeamMemberItemUI> teamMemberItems = new List<MainUITeamMemberItemUI>();
    public GameObject noTeamPanel;
    public GameUUButton noTeamButton;
    public GameObject autoMatchTeamPanel;
    public Text autoMatchTeamPurpose;
    public GameUUButton exitTeamAutoMatchBtn;
    public GameObject teamMemberOperList;
    public GameUUButton leaveTeamBtn;
    public GameUUButton backToTeamBtn;
    public GameUUButton exitTeamBtn;

    public void Init()
    {
        questObj = transform.Find("questInfo/questAndTeamobj").gameObject;
        questMoveObj = transform.Find("questInfo").gameObject;
        shousuoBtn = transform.Find("questInfo/hide").GetComponent<GameUUButton>();
        showBtn = transform.Find("questInfo/show").GetComponent<GameUUButton>();
        questToggle = transform.Find("questInfo/questAndTeamobj/TabButtonGroup 1/questToggle").GetComponent<GameUUToggle>();
        teamToggle = transform.Find("questInfo/questAndTeamobj/TabButtonGroup 1/teamToggle").GetComponent<GameUUToggle>();
        questTabButtonGroup = transform.Find("questInfo/questAndTeamobj/TabButtonGroup 1").gameObject.AddComponent<TabButtonGroup>();
        questTabButtonGroup.AddToggle(transform.Find("questInfo/questAndTeamobj/TabButtonGroup 1/questToggle").GetComponent<GameUUToggle>());
        questTabButtonGroup.AddToggle(transform.Find("questInfo/questAndTeamobj/TabButtonGroup 1/teamToggle").GetComponent<GameUUToggle>());
        questScroll = transform.Find("questInfo/questAndTeamobj/questScroll").gameObject;
        questGrid = transform.Find("questInfo/questAndTeamobj/questScroll/ScrollRect/Grid").GetComponent<GridLayoutGroup>();
        questItem = transform.Find("questInfo/questAndTeamobj/questScroll/ScrollRect/Grid/QuestItem").GetComponent<GameUUButton>();
        teammembers = transform.Find("questInfo/questAndTeamobj/teamMembers").gameObject;
        teamMemberItems = new List<MainUITeamMemberItemUI>();
        MainUITeamMemberItemUI m1 = transform.Find("questInfo/questAndTeamobj/teamMembers/membersList/teamMemberItem 0").gameObject.AddComponent<MainUITeamMemberItemUI>();
        m1.Init();
        MainUITeamMemberItemUI m2 = transform.Find("questInfo/questAndTeamobj/teamMembers/membersList/teamMemberItem 1").gameObject.AddComponent<MainUITeamMemberItemUI>();
        m2.Init();
        MainUITeamMemberItemUI m3 = transform.Find("questInfo/questAndTeamobj/teamMembers/membersList/teamMemberItem 2").gameObject.AddComponent<MainUITeamMemberItemUI>();
        m3.Init();
        MainUITeamMemberItemUI m4 = transform.Find("questInfo/questAndTeamobj/teamMembers/membersList/teamMemberItem 3").gameObject.AddComponent<MainUITeamMemberItemUI>();
        m4.Init();
        MainUITeamMemberItemUI m5 = transform.Find("questInfo/questAndTeamobj/teamMembers/membersList/teamMemberItem 4").gameObject.AddComponent<MainUITeamMemberItemUI>();
        m5.Init();
        teamMemberItems.Add(m1);
        teamMemberItems.Add(m2);
        teamMemberItems.Add(m3);
        teamMemberItems.Add(m4);
        teamMemberItems.Add(m5);
        noTeamPanel = transform.Find("questInfo/questAndTeamobj/noTeamPanel").gameObject;
        noTeamButton = transform.Find("questInfo/questAndTeamobj/noTeamPanel").GetComponent<GameUUButton>();
        autoMatchTeamPanel = transform.Find("questInfo/questAndTeamobj/autoMatchTeamPanel").gameObject;
        autoMatchTeamPurpose = transform.Find("questInfo/questAndTeamobj/autoMatchTeamPanel/autoMatchTeamPurpose").GetComponent<Text>();
        exitTeamAutoMatchBtn = transform.Find("questInfo/questAndTeamobj/autoMatchTeamPanel/exitTeamAutoMatchBtn").GetComponent<GameUUButton>();
        teamMemberOperList = transform.Find("questInfo/questAndTeamobj/teamMembers/OperationList").gameObject;
        leaveTeamBtn = transform.Find("questInfo/questAndTeamobj/teamMembers/OperationList/downListBg/downList/zanli").GetComponent<GameUUButton>();
        backToTeamBtn = transform.Find("questInfo/questAndTeamobj/teamMembers/OperationList/downListBg/downList/huidui").GetComponent<GameUUButton>();
        exitTeamBtn = transform.Find("questInfo/questAndTeamobj/teamMembers/OperationList/downListBg/downList/tuichu").GetComponent<GameUUButton>();
        teamMemberOperList.gameObject.SetActive(false);
        showBtn.gameObject.SetActive(false);



    }
}