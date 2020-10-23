using UnityEngine;
using UnityEngine.UI;

public class XianFuUpgradeUI : MonoBehaviour
{
    public Text title;
    public Text lv;
    public Text desc;
    public GameUUButton closeBtn;
    public CommonItemUINoClick xianfuItem;
    public ProgressBar expBar;
    public GameUUButton upgradeBtn;
    public RectTransform content;
    public CommonItemUI defaultListItem;
    public PageTurner pageTurner;

    public void Init()
    {
        title = transform.Find("title").GetComponent<Text>();
        lv = transform.Find("lv").GetComponent<Text>();
        desc = transform.Find("desc").GetComponent<Text>();
        closeBtn = transform.Find("CloseButton").GetComponent<GameUUButton>();
        xianfuItem = transform.Find("xianfuItem").gameObject.AddComponent<CommonItemUINoClick>();
        xianfuItem.Init();
        expBar = transform.Find("expBar").gameObject.AddComponent<ProgressBar>();
        expBar.Init(366);
        upgradeBtn = transform.Find("upgradeBtn").GetComponent<GameUUButton>();
        content = transform.Find("content").GetComponent<RectTransform>();
        defaultListItem = transform.Find("content/grid/xianfuItem").gameObject.AddComponent<CommonItemUI>();
        defaultListItem.Init();
        pageTurner = transform.Find("PageTurner").gameObject.AddComponent<PageTurner>();
        pageTurner.Init();
        defaultListItem.gameObject.SetActive(false);
    }
}

