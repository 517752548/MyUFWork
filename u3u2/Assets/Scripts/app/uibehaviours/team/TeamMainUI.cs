using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TeamMainUI : MonoBehaviour
{
	/// <summary>
	/// 我的队伍和申请列表按钮组。
	/// </summary>
	public TabButtonGroup myAndApplyBtnGroup;
	/// <summary>
	/// 阵型按钮。
	/// </summary>
	public GameUUButton formBtn;
	public Text formBtnLabel;
	public GameObject teamPurposeHotArea;
	/// <summary>
	/// 队伍目标。
	/// </summary>
	public Text teamPurposeTxt;
	/// <summary>
	/// 队伍的等级限制。
	/// </summary>
	public Text teamLvLimitTxt;
	/// <summary>
	/// 修改队伍目标和等级限制的按钮。
	/// </summary>
	public GameUUButton teamPurposeEditBtn;
	/// <summary>
	/// 自动匹配按钮。
	/// </summary>
	public GameUUButton autoMatchBtn;
	/// <summary>
	/// 取消自动匹配按钮。
	/// </summary>
	public GameUUButton cancelAutoMatchBtn;
	/// <summary>
	/// 邀请按钮。
	/// </summary>
	public GameUUButton inviteBtn;
	/// <summary>
	/// 创建队伍按钮。
	/// </summary>
	public GameUUButton createTeamBtn;
	/// <summary>
	/// 退出队伍按钮。
	/// </summary>
	public GameUUButton exitTeamBtn;
	/// <summary>
	/// 我的伙伴按钮。
	/// </summary>
	public GameUUButton myPartnerBtn;
	/// <summary>
	/// 申请入队按钮。
	/// </summary>
	public GameUUButton applyTeamBtn;
	/// <summary>
	/// 暂时离队按钮。
	/// </summary>
	public GameUUButton leaveTeamBtn;
	/// <summary>
	/// 回到队伍按钮。
	/// </summary>
	public GameUUButton backToTeamBtn;
	/// <summary>
	/// 一键喊话按钮。
	/// </summary>
	public GameUUButton sendNoticeBtn;
	/// <summary>
	/// 清空申请列表按钮。
	/// </summary>
	public GameUUButton clearApplyListBtn;
	/// <summary>
	/// 我的队伍列表。
	/// </summary>
	public GameObject myTeamList;
	/// <summary>
	/// 我的队伍列表背景。
	/// </summary>
	public GameObject myTeamListBg;
	/// <summary>
	/// 我的队伍列表项。
	/// </summary>
	public List<TeamMemberListItemUI> myTeamListItems;
	/// <summary>
	/// 申请列表。
	/// </summary>
	public GameObject teamApplyListScroll;
	/// <summary>
	/// 申请列表背景。
	/// </summary>
	public GameObject teamApplyListBg;
	/// <summary>
	/// 申请列表项。
	/// </summary>
	public TeamMemberListItemUI teamApplyListItemUI;
	/// <summary>
	/// 申请列表为空的提示。
	/// </summary>
	public GameObject noApplyTips;

	public GameUUButton closeBtn;

	/// <summary>
	/// 邀请按钮操作列表。
	/// </summary>
	public GameObject inviteOperList;
	/// <summary>
	/// 邀请好友按钮。
	/// </summary>
	public GameUUButton inviteFriendBtn;
	/// <summary>
	/// 邀请帮派成员按钮。
	/// </summary>
	public GameUUButton inviteGroupPartnerBtn;

	/// <summary>
	/// 队员操作列表。
	/// </summary>
	public GameObject myTeamListItemOperList;
	/// <summary>
	/// 发送消息按钮。
	/// </summary>
	public GameUUButton sendMsgBtn;
	/// <summary>
	/// 加为好友按钮。
	/// </summary>
	public GameUUButton makeFriendBtn;
	/// <summary>
	/// 升为队长按钮。
	/// </summary>
	public GameUUButton makeTeamLeaderBtn;
	/// <summary>
	/// 调整站位按钮。
	/// </summary>
	public GameUUButton changePosBtn;
	/// <summary>
	/// 请离队伍按钮。
	/// </summary>
	public GameUUButton kickOutBtn;
	/// <summary>
	/// 召回队员按钮。
	/// </summary>
	public GameUUButton callBackBtn;

	public GameObject noTeamCreatedTips;

    public void Init()
    {

        myAndApplyBtnGroup = transform.Find("myAndApplyBtnGroup").gameObject.AddComponent<TabButtonGroup>();
        GameUUToggle toggle1 = transform.Find("myAndApplyBtnGroup/myTeam").gameObject.GetComponent<GameUUToggle>();
        myAndApplyBtnGroup.AddToggle(toggle1);
        GameUUToggle toggle2 = transform.Find("myAndApplyBtnGroup/applyList").gameObject.GetComponent<GameUUToggle>();
        myAndApplyBtnGroup.AddToggle(toggle2);


        formBtn = transform.Find("formBtn").GetComponent<GameUUButton>();
        formBtnLabel = transform.Find("formBtn/Text").GetComponent<Text>();
		teamPurposeHotArea = transform.Find("teamPurposeHotArea").gameObject;
        teamPurposeTxt = transform.Find("teamPurposeTxt").GetComponent<Text>();
        teamLvLimitTxt = transform.Find("teamLvLimitTxt").GetComponent<Text>();
        teamPurposeEditBtn = transform.Find("teamPurposeEditButton").GetComponent<GameUUButton>();
        autoMatchBtn = transform.Find("autoMatchBtn").GetComponent<GameUUButton>();
        cancelAutoMatchBtn = transform.Find("cancelAutoMatchBtn").GetComponent<GameUUButton>();
        inviteBtn = transform.Find("inviteBtn").GetComponent<GameUUButton>();
        createTeamBtn = transform.Find("creatTeamBtn").GetComponent<GameUUButton>();
        exitTeamBtn = transform.Find("exitTeamBtn").GetComponent<GameUUButton>();
        myPartnerBtn = transform.Find("myPartnerBtn").GetComponent<GameUUButton>();
        applyTeamBtn = transform.Find("applyTeamBtn").GetComponent<GameUUButton>();
        leaveTeamBtn = transform.Find("leaveTeamBtn").GetComponent<GameUUButton>();
        backToTeamBtn = transform.Find("backToTeamBtn").GetComponent<GameUUButton>();
        sendNoticeBtn = transform.Find("sendNoticeBtn").GetComponent<GameUUButton>();
        clearApplyListBtn = transform.Find("clearApplyListBtn").GetComponent<GameUUButton>();
        teamApplyListItemUI = transform.Find("teamApplyListScroll/teamApplyList/TeamApplyListItem").gameObject.AddComponent<TeamMemberListItemUI>();
        teamApplyListItemUI.Init();
		teamApplyListItemUI.applyBtn.gameObject.SetActive(true);
		myTeamList = transform.Find("myTeamList").gameObject;
		myTeamListBg = transform.Find("myTeamListBg").gameObject;
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        inviteFriendBtn = transform.Find("inviteOperList/downListBg/downList/inviteFriendBtn").GetComponent<GameUUButton>();
        inviteGroupPartnerBtn = transform.Find("inviteOperList/downListBg/downList/inviteGroupPartnerBtn").GetComponent<GameUUButton>();
        sendMsgBtn = transform.Find("myTeamListItemOperList/downListBg/downList/Button").GetComponent<GameUUButton>();
        makeFriendBtn = transform.Find("myTeamListItemOperList/downListBg/downList/Button 1").GetComponent<GameUUButton>();
        makeTeamLeaderBtn = transform.Find("myTeamListItemOperList/downListBg/downList/Button 2").GetComponent<GameUUButton>();
        changePosBtn = transform.Find("myTeamListItemOperList/downListBg/downList/Button 3").GetComponent<GameUUButton>();
        kickOutBtn = transform.Find("myTeamListItemOperList/downListBg/downList/Button 4").GetComponent<GameUUButton>();
        callBackBtn = transform.Find("myTeamListItemOperList/downListBg/downList/Button 5").GetComponent<GameUUButton>();

        myTeamListItems = new List<TeamMemberListItemUI>();
        TeamMemberListItemUI itemui1 = transform.Find("myTeamList/MyTeamListItem 0").gameObject.AddComponent<TeamMemberListItemUI>();
        itemui1.Init();
        myTeamListItems.Add(itemui1);
        TeamMemberListItemUI itemui2 = transform.Find("myTeamList/MyTeamListItem 1").gameObject.AddComponent<TeamMemberListItemUI>();
        itemui2.Init();
        myTeamListItems.Add(itemui2);
        TeamMemberListItemUI itemui3 = transform.Find("myTeamList/MyTeamListItem 2").gameObject.AddComponent<TeamMemberListItemUI>();
        itemui3.Init();
        myTeamListItems.Add(itemui3);
        TeamMemberListItemUI itemui4 = transform.Find("myTeamList/MyTeamListItem 3").gameObject.AddComponent<TeamMemberListItemUI>();
        itemui4.Init();
        myTeamListItems.Add(itemui4);
        TeamMemberListItemUI itemui5 = transform.Find("myTeamList/MyTeamListItem 4").gameObject.AddComponent<TeamMemberListItemUI>();
        itemui5.Init();
        myTeamListItems.Add(itemui5);

		teamApplyListScroll = transform.Find("teamApplyListScroll").gameObject;
		teamApplyListBg = transform.Find("teamApplyListBg").gameObject;
		noApplyTips = transform.Find("noApplyTips").gameObject;
		inviteOperList = transform.Find("inviteOperList").gameObject;
		myTeamListItemOperList = transform.Find("myTeamListItemOperList").gameObject;
		noTeamCreatedTips = transform.Find("noTeamCreateTips").gameObject;
		teamPurposeHotArea.gameObject.SetActive(false);
		teamPurposeTxt.gameObject.SetActive(false);
		teamLvLimitTxt.gameObject.SetActive(false);
		teamPurposeEditBtn.gameObject.SetActive(false);
		autoMatchBtn.gameObject.SetActive(false);
		cancelAutoMatchBtn.gameObject.SetActive(false);
		inviteBtn.gameObject.SetActive(false);
		createTeamBtn.gameObject.SetActive(false);
		exitTeamBtn.gameObject.SetActive(false);
		myPartnerBtn.gameObject.SetActive(false);
		applyTeamBtn.gameObject.SetActive(false);
		leaveTeamBtn.gameObject.SetActive(false);
		backToTeamBtn.gameObject.SetActive(false);
		sendNoticeBtn.gameObject.SetActive(false);
		clearApplyListBtn.gameObject.SetActive(false);
		teamApplyListItemUI.gameObject.SetActive(false);
		myTeamList.gameObject.SetActive(false);
		myTeamListBg.gameObject.SetActive(false);
		itemui1.gameObject.SetActive(false);
		itemui2.gameObject.SetActive(false);
		itemui3.gameObject.SetActive(false);
		itemui4.gameObject.SetActive(false);
		itemui5.gameObject.SetActive(false);
		teamApplyListScroll.gameObject.SetActive(false);
		teamApplyListBg.gameObject.SetActive(false);
		noApplyTips.gameObject.SetActive(false);
		noTeamCreatedTips.gameObject.SetActive(false);
		inviteOperList.SetActive(false);
		myTeamListItemOperList.SetActive(false);
    }
}