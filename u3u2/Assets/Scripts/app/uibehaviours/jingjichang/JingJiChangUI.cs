using UnityEngine;
using UnityEngine.UI;

public class JingJiChangUI : UIMonoBehaviour
{
    public GameUUButton closeBtn;
    public Text roleName;
    public Text levelText;
    public Text zhanliText;
    public MoneyItemUI rongyu;
    public GameObject modelContainer;

    public Text paiming;
    public GameUUButton guizeBtn;
    public GameUUButton zhanbaoBtn;
    public GameUUButton paihangbangBtn;
    public GameUUButton paimingJiangliBtn;
    public GridLayoutGroup memberGrid;
    public JingJiChangItemUI defaultItemUI;
    public Text cishuText;
    public GameUUButton addBtn;
    public GameObject dengdaiObj;
    public Text dengdaiText;
    public GameUUButton shuxinBtn;
    public GameUUButton qingchuBtn;
    public MoneyItemUI qingchuCost;

    public GameObject zhanbaoGo;
    public GridLayoutGroup zhanbaoGrid;
    public JingJiChangZhanBaoItemUI defaultZhanbaoItem;
    public GameUUButton zhanbaoClose;

    public override void Init()
    {
        base.Init();
        closeBtn = transform.Find("closeBtn").GetComponent<GameUUButton>();
        guizeBtn = transform.Find("guizeBtn").GetComponent<GameUUButton>();
        zhanbaoBtn = transform.Find("zhanbaoBtn").GetComponent<GameUUButton>();
        paihangbangBtn = transform.Find("paihangbangBtn").GetComponent<GameUUButton>();
        paimingJiangliBtn = transform.Find("paimingJiangliBtn").GetComponent<GameUUButton>();
        addBtn = transform.Find("cishu/addCiShuBtn").GetComponent<GameUUButton>();
        shuxinBtn = transform.Find("shuaxinBtn").GetComponent<GameUUButton>();
        qingchuBtn = transform.Find("clearCdBtn").GetComponent<GameUUButton>();
        zhanbaoClose = transform.Find("zhanbaoGo/closeBtn ").GetComponent<GameUUButton>();

        roleName=transform.Find("Image/mingzi").GetComponent<UnityEngine.UI.Text>();
        levelText=transform.Find("Image/dengji").GetComponent<UnityEngine.UI.Text>();
        zhanliText=transform.Find("zhandouli").GetComponent<UnityEngine.UI.Text>();
        rongyu=transform.Find("MoneyItem").gameObject.AddComponent<MoneyItemUI>();
        rongyu.Init();
        modelContainer=transform.Find("modelContainer").gameObject;
        paiming=transform.Find("Image (2)/paiming").GetComponent<UnityEngine.UI.Text>();
        memberGrid=transform.Find("ScrollViewVertical/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        defaultItemUI=transform.Find("ScrollViewVertical/grid/duishouItem").gameObject.AddComponent<JingJiChangItemUI>();
        defaultItemUI.Init();
        cishuText=transform.Find("cishu/Image/cishuText").GetComponent<UnityEngine.UI.Text>();
        dengdaiObj=transform.Find("dengdaitiaozhan").gameObject;
        dengdaiText=transform.Find("dengdaitiaozhan/Image/Text").GetComponent<UnityEngine.UI.Text>();
        qingchuCost=transform.Find("clearCdBtn/ZZMoneyItem").gameObject.AddComponent<MoneyItemUI>();
        qingchuCost.Init();
        zhanbaoGo=transform.Find("zhanbaoGo").gameObject;
        zhanbaoGrid=transform.Find("zhanbaoGo/ScrollViewVertical (1)/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        defaultZhanbaoItem=transform.Find("zhanbaoGo/ScrollViewVertical (1)/grid/zhanbaoitem").gameObject.AddComponent<JingJiChangZhanBaoItemUI>();
        defaultZhanbaoItem.Init();
        zhanbaoGo.gameObject.SetActive(false);

    }

}
