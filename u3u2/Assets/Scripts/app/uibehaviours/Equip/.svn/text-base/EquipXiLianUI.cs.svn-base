using UnityEngine;
using UnityEngine.UI;

public class EquipXiLianUI : UIMonoBehaviour {

    public EquipChongZhuItemUI gridItem;
    public GridLayoutGroup grid;
    public Text EquipName;

    public GameObject emptyTip;
    public GameObject rightContent;

    //右面面板 上面的装备
    public CommonItemUINoClick RightUpEquip;
    //右面面板 下面的装备
    public CommonItemUI RightDownEquip;
    public Text zhuangbeipingfen;
    public Text zhiyeyaoqiu;
    public Text naijiudu;
    public Text jichushuxinglabel;
    public Text jichushuxingvalue;
    public Text fujiashuxing1;
    public Text fujiashuxing2;
    public MoneyItemUI xiaohaoMoney;
    public MoneyItemUI yongyouMoney;
    public GameUUButton xilianBtn;

    public CanvasRenderer leftInfoRenderer;
    public CanvasRenderer midInfoRenderer;
    public CanvasRenderer downInfoRenderer;

    public override void Init()
    {
        base.Init();
        leftInfoRenderer = transform.Find("leftInfo").GetComponent<CanvasRenderer>();
        gridItem = transform.Find("leftInfo/scroll/grid/equipItem").gameObject.AddComponent<EquipChongZhuItemUI>();
        gridItem.Init();
        grid = transform.Find("leftInfo/scroll/grid").GetComponent<GridLayoutGroup>();
        midInfoRenderer = transform.Find("midInfo").GetComponent<CanvasRenderer>();
        EquipName = transform.Find("midInfo/content/bg/equipname").GetComponent<Text>();
        emptyTip = transform.Find("midInfo/tishi").gameObject;
        rightContent = transform.Find("midInfo/content").gameObject;
        RightUpEquip = transform.Find("midInfo/content/rightupequip").gameObject.AddComponent<CommonItemUINoClick>();
        RightUpEquip.Init();
        downInfoRenderer = transform.Find("downInfo").GetComponent<CanvasRenderer>();
        RightDownEquip = transform.Find("downInfo/CommonItemUI90_90").gameObject.AddComponent<CommonItemUI>();
        RightDownEquip.Init();
        zhuangbeipingfen = transform.Find("midInfo/content/zhuangbeipingfe1/zhuangbeipingfen").GetComponent<Text>();
        zhiyeyaoqiu = transform.Find("midInfo/content/zhiyeyaoqiu/zhiyeyaoqiu").GetComponent<Text>();
        naijiudu = transform.Find("midInfo/content/naijiudu/naijiudu").GetComponent<Text>();
        jichushuxinglabel = transform.Find("midInfo/content/fashuqiangdu/jichushuxinglabel").GetComponent<Text>();
        jichushuxingvalue = transform.Find("midInfo/content/fashuqiangdu/jichushuxingvalue").GetComponent<Text>();

        xiaohaoMoney = transform.Find("downInfo/xiaohaoMoney").gameObject.AddComponent<MoneyItemUI>();
        xiaohaoMoney.Init();
        yongyouMoney = transform.Find("downInfo/yongyouMoney").gameObject.AddComponent<MoneyItemUI>();
        yongyouMoney.Init();
        xilianBtn = transform.Find("downInfo/xilianBtn").GetComponent<GameUUButton>();

        emptyTip.gameObject.SetActive(false);
    }


}
