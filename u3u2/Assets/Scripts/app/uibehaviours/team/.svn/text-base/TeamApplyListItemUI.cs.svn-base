using UnityEngine;
using UnityEngine.UI;

public class TeamApplyListItemUI : MonoBehaviour
{
	public int teamId;
	public Text teamLeaderName;
	public Text teamLeaderLv;
	public Text teamLeaderCareer;
	public Text teamPurposeName;
	public ProgressBar teamMemberProgress;
	public GameUUButton applyBtn;
	public GameUUButton appliedBtn;
    public void Init()
    {
        teamLeaderName = transform.Find("leaderName").GetComponent<Text>();
        teamLeaderLv = transform.Find("leaderLv").GetComponent<Text>();
        teamLeaderCareer = transform.Find("leaderCareer").GetComponent<Text>();
        teamPurposeName = transform.Find("purposeName").GetComponent<Text>();
        teamMemberProgress = transform.Find("memberProgress").gameObject.AddComponent<ProgressBar>();
        teamMemberProgress.Init
        (
            teamMemberProgress.transform.Find("background").GetComponent<Image>(), 
            teamMemberProgress.transform.Find("background/foreground").GetComponent<Image>(),
            teamMemberProgress.transform.Find("Text").GetComponent<Text>(), 191
        );
        applyBtn = transform.Find("applyBtn").GetComponent<GameUUButton>();
        appliedBtn = transform.Find("appliedBtn").GetComponent<GameUUButton>();
        appliedBtn.gameObject.SetActive(false);
        applyBtn.gameObject.SetActive(false);

    }
}
