using UnityEngine;
using UnityEngine.UI;

public class TeamInviteListUI : MonoBehaviour
{
	public Text title;
	public GameUUButton closeBtn;
	public TeamInviteListItemUI invitelistItem;
    public void Init()
    {
        title = transform.Find("Text").GetComponent<Text>();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        invitelistItem = transform.Find("Image 2/GameObject/TeamInviteListItem").gameObject.AddComponent<TeamInviteListItemUI>();
        invitelistItem.Init();
        invitelistItem.gameObject.SetActive(false);

    }
}
