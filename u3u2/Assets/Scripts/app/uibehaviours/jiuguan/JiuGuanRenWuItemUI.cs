using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JiuGuanRenWuItemUI : MonoBehaviour
{

    public Text title;
    public Text content;
    public GameObject starGrid;
    public GameObject starhuiGrid;
    //public GridLayoutGroup rewardItem;
    public List<CommonItemUI> itemList;
    public GameUUButton renwuBtn;
    public GameObject rejectedTips;

    public void Init()
    {
        title=transform.Find("BiaoTiText_22").GetComponent<UnityEngine.UI.Text>();
        content=transform.Find("renwuContent").GetComponent<UnityEngine.UI.Text>();
        starGrid=transform.Find("starList").gameObject;
        starhuiGrid = transform.Find("starhuiList").gameObject;
        //rewardItem=transform.Find("rewardItemList").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        itemList = new List<CommonItemUI>();
        CommonItemUI c1 = transform.Find("CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        c1.Init();
        CommonItemUI c2 = transform.Find("CommonItemUI 1").gameObject.AddComponent<CommonItemUI>();
        c2.Init();
        CommonItemUI c3 = transform.Find("CommonItemUI 2").gameObject.AddComponent<CommonItemUI>();
        c3.Init();
        itemList.Add(c1);
        itemList.Add(c2);
        itemList.Add(c3);
        renwuBtn=transform.Find("applyBtn").GetComponent<GameUUButton>();
        rejectedTips=transform.Find("rejectedTips").gameObject;

    }

}
