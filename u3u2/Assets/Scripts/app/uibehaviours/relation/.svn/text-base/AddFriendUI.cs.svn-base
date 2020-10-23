using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddFriendUI : MonoBehaviour
{

    public GameUUButton closeBtn;
    public Image inputBg;
    public GameUUButton findBtn;

    public GameUUButton refreshBtn;
    public GridLayoutGroup friendListGrid;
    public AddFriendItemUI defaultFriendItem;

    public void Init()
    {
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        inputBg = transform.Find("input/Image").GetComponent<UnityEngine.UI.Image>();
        findBtn = transform.Find("input/chazhaoBtn").GetComponent<GameUUButton>();
        refreshBtn = transform.Find("huanyipiBtn").GetComponent<GameUUButton>();
        friendListGrid = transform.Find("list/Image 1/scrollRect/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        defaultFriendItem = transform.Find("list/Image 1/scrollRect/grid/Item").gameObject.AddComponent<AddFriendItemUI>();
        defaultFriendItem.Init();

    }
}
