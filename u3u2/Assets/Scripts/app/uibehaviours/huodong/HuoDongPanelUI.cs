using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HuoDongPanelUI : MonoBehaviour
{
    public Text titleText;
    public GameUUButton closeBtn;
    public TabButtonGroup huodongTBG ;
    public Text shuaxinText;

    public HorizontalLayoutGroup itemListParent;
    public ScrollRect scrollrect;
    public HuoDongListItem defaultHuoDongItem;

    public HuoDongRewardItem rewardItem;

    public ProgressBar jinduBar;
    public GameObject jinduDot;
    public Text jinduDotText;

    public void Init()
    {
        titleText=transform.Find("title").GetComponent<UnityEngine.UI.Text>();
        huodongTBG=transform.Find("btngrid 1").gameObject.AddComponent<TabButtonGroup>();
        huodongTBG.AddToggle(transform.Find("btngrid 1/richang").GetComponent<GameUUToggle>());
        huodongTBG.AddToggle(transform.Find("btngrid 1/xianshi").GetComponent<GameUUToggle>());
        huodongTBG.AddToggle(transform.Find("btngrid 1/jijiangkaiqi").GetComponent<GameUUToggle>());

        shuaxinText=transform.Find("Text").GetComponent<UnityEngine.UI.Text>();
        itemListParent=transform.Find("grid/Image/container").GetComponent<UnityEngine.UI.HorizontalLayoutGroup>();
        scrollrect = transform.Find("grid/Image/").GetComponent<ScrollRect>();
        defaultHuoDongItem=transform.Find("grid/Image/container/huodongItem").gameObject.AddComponent<HuoDongListItem>();
        defaultHuoDongItem.Init();
        rewardItem=transform.Find("jindu/jiangliItem").gameObject.AddComponent<HuoDongRewardItem>();
        rewardItem.Init();
        jinduBar=transform.Find("ZZProgress Bar 1").gameObject.AddComponent<ProgressBar>();
        jinduBar.Init
        (
            jinduBar.transform.Find("background").GetComponent<Image>(), 
            jinduBar.transform.Find("background/foreground").GetComponent<Image>(),
            jinduBar.transform.Find("Text").GetComponent<Text>(), 810
        );
        jinduDot=transform.Find("Image").gameObject;
        jinduDotText=transform.Find("Image/Text").GetComponent<UnityEngine.UI.Text>();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        rewardItem.gameObject.SetActive(false);

    }

}
