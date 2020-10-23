using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BangPaiXinXiUI : MonoBehaviour
{
    public Text mingcheng;
    public Text bangzhu;
    public Text dengji;
    public Text renshu;
    public Text jingyan;
    public Text shengjijingyan;
    public Text zijin;
    public Text meiriweihu;

    public Text zongzhiShowText;
    public Image zongzhiBg;
    public GameUUButton xiugaizongzhiBtn;

    public GameUUButton zaixianchengyuanBtn;
    public GameUUButton dengjiBtn;
    public GameUUButton zhiyeBtn;
    public GameUUButton zhiwuBtn;
    public GameUUButton banggongBtn;

    public TabButtonGroup listTBG;
    public GridLayoutGroup grid;
    public BangPaiListItemUI defaultItemUI;

    public Text zaixianrenshu;
    public GameUUButton waijiaoBtn;
    public GameUUButton huidaoBtn;

    public GameObject OperateListGo;
    public GameUUButton liaotianBtn;
    public GameUUButton addFriendBtn;

    public void Init()
    {
        mingcheng = transform.Find("xinxi/mingcheng").GetComponent<Text>();
        bangzhu = transform.Find("xinxi/content_grid/bangzhu").GetComponent<Text>();
        dengji = transform.Find("xinxi/content_grid/dengji").GetComponent<Text>();
        renshu = transform.Find("xinxi/content_grid/renshu").GetComponent<Text>();
        jingyan = transform.Find("xinxi/content_grid/jingyan").GetComponent<Text>();
        shengjijingyan = transform.Find("xinxi/content_grid/shengjijingyan").GetComponent<Text>();
        zijin = transform.Find("xinxi/content_grid/bangpaizijin").GetComponent<Text>();
        meiriweihu = transform.Find("xinxi/content_grid/meiriweihu").GetComponent<Text>();
        zongzhiShowText = transform.Find("xinxi/zongzhi/showText").GetComponent<Text>();
        zongzhiBg = transform.Find("xinxi/zongzhi/Image").GetComponent<Image>();
        xiugaizongzhiBtn = transform.Find("xinxi/zongzhi/bianjiZongzhi").GetComponent<GameUUButton>();
        zaixianchengyuanBtn = transform.Find("bangpaiList/topBtnList/mingcheng").GetComponent<GameUUButton>();
        dengjiBtn = transform.Find("bangpaiList/topBtnList/dengji").GetComponent<GameUUButton>();
        zhiyeBtn = transform.Find("bangpaiList/topBtnList/zhiye").GetComponent<GameUUButton>();
        zhiwuBtn = transform.Find("bangpaiList/topBtnList/zhiwu").GetComponent<GameUUButton>();
        banggongBtn = transform.Find("bangpaiList/topBtnList/banggong").GetComponent<GameUUButton>();
        listTBG = transform.Find("bangpaiList/scrollList/Image/grid").gameObject.AddComponent<TabButtonGroup>();
        grid = transform.Find("bangpaiList/scrollList/Image/grid").GetComponent<GridLayoutGroup>();
        defaultItemUI = transform.Find("bangpaiList/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<BangPaiListItemUI>();
        defaultItemUI.Init(
            defaultItemUI.transform,
            null, null,
            defaultItemUI.transform.Find("mingcheng"),
            defaultItemUI.transform.Find("dengji"),
            null, null, null,
            defaultItemUI.transform.Find("zhiye"),
            defaultItemUI.transform.Find("zhiwu"),
            defaultItemUI.transform.Find("banggong"),
            null, null, null, null, null,
            defaultItemUI.transform.Find("danshuBg"),
            defaultItemUI.transform.Find("shuangshuBg"));
        defaultItemUI.scrollRect = grid.transform.parent.GetComponent<ScrollRect>();
        zaixianrenshu = transform.Find("zaixianrenshu").GetComponent<Text>();
        waijiaoBtn = transform.Find("funcBtns/bangzhong/waiJiaoBangpai").GetComponent<GameUUButton>();
        huidaoBtn = transform.Find("funcBtns/bangzhong/huidaoBangPai").GetComponent<GameUUButton>();
        OperateListGo = transform.Find("ZZOperationList").gameObject;
        liaotianBtn = transform.Find("ZZOperationList/downListBg/downList/liaotian").GetComponent<GameUUButton>();
        addFriendBtn = transform.Find("ZZOperationList/downListBg/downList/jiahaoyou").GetComponent<GameUUButton>();
    }
}
