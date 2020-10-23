using UnityEngine;
using UnityEngine.UI;

public class ChongZhiUI : UIMonoBehaviour
{
    public Text curVipText;
    public ProgressBar chongzhiPGBar;
    public GameUUButton tequanBtn;
    public MoneyItemUI yongyouJinzi;
    public ChongZhiItem defaultChongZhiItem;
    public GridLayoutGroup grid;
    public CanvasRenderer listRenderer;

    public override void Init()
    {
        base.Init();
        curVipText = transform.Find("curVip").GetComponent<Text>();
        chongzhiPGBar = transform.Find("pgbar").gameObject.AddComponent<ProgressBar>();
        chongzhiPGBar.Init(transform.Find("pgbar/background").GetComponent<Image>(),
            transform.Find("pgbar/foreground").GetComponent<Image>(),
            transform.Find("pgbar/Text").GetComponent<Text>(), 280);
        tequanBtn = transform.Find("tequanbtn").GetComponent<GameUUButton>();
        yongyouJinzi = transform.Find("jinzi").gameObject.AddComponent<MoneyItemUI>();
        yongyouJinzi.Init();
        listRenderer = transform.Find("ScrollViewCanvas").GetComponent<CanvasRenderer>();
        grid = transform.Find("ScrollViewCanvas/ScrollViewVertical/grid").gameObject.GetComponent<GridLayoutGroup>();
        defaultChongZhiItem = transform.Find("ScrollViewCanvas/ScrollViewVertical/grid/sellItem").gameObject.AddComponent<ChongZhiItem>();
        defaultChongZhiItem.init();
        defaultChongZhiItem.gameObject.SetActive(false);
    }
}

public class ChongZhiItem : MonoBehaviour
{
    public Image biaoqian;
    public Text jinziText;
    public Text zengsongText;
    public Image icon;
    public Text jiageText;
    public GameUUButton btn;

    public Image zengsongImage;
    public Text zengText;
    public Image zengsongicon;

    public void init()
    {
        btn = transform.gameObject.GetComponent<GameUUButton>();
        biaoqian = transform.Find("biaoqian").gameObject.GetComponent<Image>();
        jinziText = transform.Find("jinziText").gameObject.GetComponent<Text>();
        zengsongText = transform.Find("zengText").gameObject.GetComponent<Text>();
        icon = transform.Find("icon").gameObject.GetComponent<Image>();
        jiageText = transform.Find("shoujiaText").gameObject.GetComponent<Text>();

        zengsongImage = transform.Find("zengsongbg").gameObject.GetComponent<Image>();
        zengText = transform.Find("zenglabel").gameObject.GetComponent<Text>();
        zengsongicon = transform.Find("zengicon").gameObject.GetComponent<Image>();

    }
}
