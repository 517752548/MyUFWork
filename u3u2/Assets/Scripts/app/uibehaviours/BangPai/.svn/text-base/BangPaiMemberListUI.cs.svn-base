using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BangPaiMemberListUI : MonoBehaviour 
{
    public GameUUToggle xianshiOnLine;
    public GameUUButton bianhaoBtn;
    public GameUUButton mingchengBtn;
    public GameUUButton dengjiBtn;
    public GameUUButton zhiyeBtn;
    public GameUUButton zhiwuBtn;
    public GameUUButton banggongBtn;
    public GameUUButton lishiBanggongBtn;
    public GameUUButton zuihouzaixianBtn;

    public GridLayoutGroup listGrid;
    public TabButtonGroup listTBG;
    public BangPaiListItemUI defaultMemberItemUI;

    public GameObject bangzhuBtnsGo;
    public List<GameUUButton> bangzhuBtns;
    public GameObject jiesanDaojishiGo;
    public Text daojishiText;
    public GameObject fubangzhuBtnsGo;
    public List<GameUUButton> fubangzhuBtns;
    public GameObject bangzhongBtnsGo;
    public List<GameUUButton> bangzhongBtns;

    public BangPaiQunFaMailUI sendMailGo;

    public Transform tfopreateListBg;

    public GameObject OperateListGo;
    public GameUUButton LiaoTianBtn;
    public GameUUButton RMJingYingBtn;
    public GameUUButton RMFuBangZhuBtn;
    public GameUUButton ZHRBangZhuBtn;
    public GameUUButton JWBangZhongBtn;
    public GameUUButton QLBangPai;
    
    public void Init()
    {
        xianshiOnLine = transform.Find("zaixianToggle").GetComponent<GameUUToggle>();
        mingchengBtn = transform.Find("bangpaiList/topBtnList/mingcheng").GetComponent<GameUUButton>();
        dengjiBtn = transform.Find("bangpaiList/topBtnList/dengji").GetComponent<GameUUButton>();
        zhiyeBtn = transform.Find("bangpaiList/topBtnList/zhiye").GetComponent<GameUUButton>();
        zhiwuBtn = transform.Find("bangpaiList/topBtnList/zhiwu").GetComponent<GameUUButton>();
        banggongBtn = transform.Find("bangpaiList/topBtnList/benzhoubanggong").GetComponent<GameUUButton>();
        lishiBanggongBtn = transform.Find("bangpaiList/topBtnList/lishibanggong").GetComponent<GameUUButton>();
        zuihouzaixianBtn = transform.Find("bangpaiList/topBtnList/zuihouzaixian").GetComponent<GameUUButton>();
        
        listGrid = transform.Find("bangpaiList/scrollList/Image/grid").GetComponent<GridLayoutGroup>();
        listTBG = transform.Find("bangpaiList/scrollList/Image/grid").gameObject.AddComponent<TabButtonGroup>();
        defaultMemberItemUI = transform.Find("bangpaiList/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<BangPaiListItemUI>();
        defaultMemberItemUI.Init(
            defaultMemberItemUI.transform,
            null, null,
            defaultMemberItemUI.transform.Find("mingcheng"),
            defaultMemberItemUI.transform.Find("dengji"),
            null, null,
            defaultMemberItemUI.transform.Find("Toggle"),
            defaultMemberItemUI.transform.Find("zhiye"),
            defaultMemberItemUI.transform.Find("zhiwu"),
            defaultMemberItemUI.transform.Find("benzhoubanggong"),
            defaultMemberItemUI.transform.Find("lishibanggong"),
            defaultMemberItemUI.transform.Find("zuihouzaixian"),
            null, null, null,
            defaultMemberItemUI.transform.Find("Background"),
            defaultMemberItemUI.transform.Find("Background 1")
        );
        defaultMemberItemUI.scrollRect = listTBG.transform.parent.GetComponent<ScrollRect>();
        bangzhuBtnsGo = transform.Find("funcBtns/bangzhu").gameObject;
        
        bangzhuBtns = new List<GameUUButton>();
        bangzhuBtns.Add(transform.Find("funcBtns/bangzhu/btns/jiesanBtn").GetComponent<GameUUButton>());
        bangzhuBtns.Add(transform.Find("funcBtns/bangzhu/btns/querenJiesan").GetComponent<GameUUButton>());
        bangzhuBtns.Add(transform.Find("funcBtns/bangzhu/btns/quxiaoJiesan").GetComponent<GameUUButton>());
        bangzhuBtns.Add(transform.Find("funcBtns/bangzhu/btns/tichu").GetComponent<GameUUButton>());
        bangzhuBtns.Add(transform.Find("funcBtns/bangzhu/btns/querentichu").GetComponent<GameUUButton>());
        bangzhuBtns.Add(transform.Find("funcBtns/bangzhu/btns/quxiaotichu").GetComponent<GameUUButton>());
        bangzhuBtns.Add(transform.Find("funcBtns/bangzhu/btns/liebiao").GetComponent<GameUUButton>());
        bangzhuBtns.Add(transform.Find("funcBtns/bangzhu/btns/quanfaMsg").GetComponent<GameUUButton>());
        
        jiesanDaojishiGo = transform.Find("funcBtns/bangzhu/jiesanDaojishi").gameObject;
        daojishiText =  transform.Find("funcBtns/bangzhu/jiesanDaojishi/Text 1").GetComponent<Text>();
        
        fubangzhuBtnsGo = transform.Find("funcBtns/fubangzhu").gameObject;
        fubangzhuBtns = new List<GameUUButton>();
        fubangzhuBtns.Add(transform.Find("funcBtns/fubangzhu/tuichuBangPai").GetComponent<GameUUButton>());
        fubangzhuBtns.Add(transform.Find("funcBtns/fubangzhu/tichu").GetComponent<GameUUButton>());
        fubangzhuBtns.Add(transform.Find("funcBtns/fubangzhu/querentishu").GetComponent<GameUUButton>());
        fubangzhuBtns.Add(transform.Find("funcBtns/fubangzhu/quxiaotichu").GetComponent<GameUUButton>());
        fubangzhuBtns.Add(transform.Find("funcBtns/fubangzhu/liebiao").GetComponent<GameUUButton>());
        fubangzhuBtns.Add(transform.Find("funcBtns/fubangzhu/quanfaMsg").GetComponent<GameUUButton>());
        
        bangzhongBtnsGo = transform.Find("funcBtns/bangzhong").gameObject;
        bangzhongBtns = new List<GameUUButton>();
        bangzhongBtns.Add(transform.Find("funcBtns/bangzhong/tuichuBangPai").GetComponent<GameUUButton>());
        bangzhongBtns.Add(transform.Find("funcBtns/bangzhong/liebiao").GetComponent<GameUUButton>());
        
        sendMailGo = transform.Find("qunfayoujian").gameObject.AddComponent<BangPaiQunFaMailUI>();
        sendMailGo.Init();
        sendMailGo.gameObject.SetActive(false);
        OperateListGo = transform.Find("bangpaiList/ZZOperationList").gameObject;
        tfopreateListBg = transform.Find("bangpaiList/ZZOperationList/opreationListBg");
        
        LiaoTianBtn = transform.Find("bangpaiList/ZZOperationList/downListBg/downList/Button").GetComponent<GameUUButton>();
        RMJingYingBtn = transform.Find("bangpaiList/ZZOperationList/downListBg/downList/Button 1").GetComponent<GameUUButton>();
        RMFuBangZhuBtn = transform.Find("bangpaiList/ZZOperationList/downListBg/downList/Button 2").GetComponent<GameUUButton>();
        ZHRBangZhuBtn = transform.Find("bangpaiList/ZZOperationList/downListBg/downList/Button 3").GetComponent<GameUUButton>();
        JWBangZhongBtn = transform.Find("bangpaiList/ZZOperationList/downListBg/downList/Button 4").GetComponent<GameUUButton>();
        QLBangPai = transform.Find("bangpaiList/ZZOperationList/downListBg/downList/Button 5").GetComponent<GameUUButton>();
    }
}

