using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemTipsUI : MonoBehaviour
{
    public Text itemName;
    public CommonItemUI commonitem;
    public Text typename;
    public Text level;
    public Text desc;
    public GameUUButton leftBtn;
    public Text leftBtnText;
    public GameUUButton rightBtn;
    public Text rightBtnText;
    public GameUUButton midBtn;
    public Text midBtnText;

    public Text title;
    public GameObject detailObj;
    public GridLayoutGroup grid;
    public GameObject detailItem;
    public Text xianfuText;
    public Text xianfuLevel;

    public Text bindText;

    public void Init()
    {
        itemName = transform.Find("itemName").GetComponent<Text>();
        commonitem = transform.Find("CommonItemUI").gameObject.AddComponent<CommonItemUI>();
        commonitem.Init();
        typename = transform.Find("typeName").GetComponent<Text>();
        level = transform.Find("levelText").GetComponent<Text>();
        desc = transform.Find("PropDesc").GetComponent<Text>();
        leftBtn = transform.Find("DownContent 1/leftButton").gameObject.GetComponent<GameUUButton>();
        leftBtnText = transform.Find("DownContent 1/leftButton/name").gameObject.GetComponent<Text>();

        rightBtn = transform.Find("DownContent 1/rightButton").gameObject.GetComponent<GameUUButton>();
        rightBtnText = transform.Find("DownContent 1/rightButton/name").gameObject.GetComponent<Text>();

        title = transform.Find("detail/title").GetComponent<Text>();
        midBtn = transform.Find("DownContent 1/midButton").GetComponent<GameUUButton>();
        midBtnText = transform.Find("DownContent 1/midButton/name").gameObject.GetComponent<Text>();

        detailObj = transform.Find("detail").gameObject;
        grid = transform.Find("detail/scroll/image/grid").GetComponent<GridLayoutGroup>();
        detailItem = transform.Find("detail/scroll/image/grid/item").gameObject;

        xianfuText = transform.Find("xianfuText").GetComponent<Text>();
        xianfuLevel = transform.Find("xianfuLevel").GetComponent<Text>();
        xianfuText.gameObject.SetActive(false);
        xianfuLevel.gameObject.SetActive(false);

        bindText = transform.Find("bindText").GetComponent<Text>();
    }
}
