using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaiHangBangUI : UIMonoBehaviour
{
    public GameUUButton CloseBtn;
    public VerticalLayoutGroup toggleParent;

    public TabButtonGroup daleiTBG;
    public TabButtonGroup xiaoleiTBG;

    public ToggleWithArrow defaultDaLeiToggle;
    public GameUUToggle defaultXiaoleiToggle;

    public GameObject gerendengji;
    public GameObject gerenzhanli;
    public GameObject gerenchongwu;
    public GameObject jingjichang;
    public GameObject nvnliansai;
    public GameObject bangpaiBossJindu;
    public GameObject bangpaiBossCishu;
    public GameObject xianhuBang;

    public List<GameUUButton> gerendengjiBtns;
    public List<GameUUButton> gerenzhanliBtns;
    public List<GameUUButton> gerenchongwuBtns;
    public List<GameUUButton> jingjichangBtns;
    public List<GameUUButton> nvnliansaiBtns;

    public ScrollRect dengjiScrollRect;
    public GridLayoutGroup dengjiItemGrid;
    public TabButtonGroup dengjiItemTBG;

    public ScrollRect zhanliScrollRect;
    public GridLayoutGroup zhanliItemGrid;
    public TabButtonGroup zhanliItemTBG;

    public ScrollRect chongwuScrollRect;
    public GridLayoutGroup chongwuItemGrid;
    public TabButtonGroup chongwuItemTBG;

    public ScrollRect jingjichangScrollRect;
    public GridLayoutGroup jingjichangItemGrid;
    public TabButtonGroup jingjichangItemTBG;

    public ScrollRect nvnScrollRect;
    public GridLayoutGroup nvnItemGrid;
    public TabButtonGroup nvnItemTBG;

    public ScrollRect bangpaiBossJinduScrollRect;
    public GridLayoutGroup bangpaiBossJinduItemGrid;
    public TabButtonGroup bangpaiBossJinduItemTBG;

    public ScrollRect bangpaiBossCishuScrollRect;
    public GridLayoutGroup bangpaiBossCishuItemGrid;
    public TabButtonGroup bangpaiBossCishuItemTBG;

    public ScrollRect xianhuScrollRect;
    public GridLayoutGroup xianhuItemGrid;
    public TabButtonGroup xianhuItemTBG;

    public PaiHangItemUI GerenDengjiItem;
    public PaiHangItemUI GerenZhanliItem;
    public PaiHangItemUI GerenChongwuItem;
    public PaiHangItemUI JingJiChangItem;
    public PaiHangItemUI NvnItem;
    public PaiHangItemUI bangpaiBossJinduItem;
    public PaiHangItemUI bangpaiBossCishuItem;
    public PaiHangItemUI xianhuItem;

    public PaiHangItemUI myDengjiItem;
    public PaiHangItemUI myZhanLiItem;
    public PaiHangItemUI myChongwuItem;
    public PaiHangItemUI myJingJiChangItem;
    public PaiHangItemUI myNvnItem;
    public PaiHangItemUI mybangpaiBossJinduItem;
    public PaiHangItemUI mybangpaiBossCishuItem;
    public PaiHangItemUI myxianhuItem;


    public override void Init()
    {
        base.Init();
        CloseBtn = transform.Find("ZZBigPopWndWIthSideTab/closeBtn").GetComponent<GameUUButton>();
        toggleParent = transform.Find("xinxiGo/xinxi/ScrollRect/Image/grid").GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
        daleiTBG = transform.Find("xinxiGo/xinxi/ScrollRect/Image").gameObject.AddComponent<TabButtonGroup>();


        xiaoleiTBG = transform.Find("xinxiGo/xinxi/ScrollRect/Image/grid").gameObject.AddComponent<TabButtonGroup>();
        xiaoleiTBG.Init();
        defaultDaLeiToggle = transform.Find("xinxiGo/xinxi/ScrollRect/Image/grid/ToggleWithArrow").gameObject.AddComponent<ToggleWithArrow>();
        defaultDaLeiToggle.Init(
            defaultDaLeiToggle.transform.GetComponent<GameUUToggle>(),
            defaultDaLeiToggle.transform.Find("up").GetComponent<Image>(),
            defaultDaLeiToggle.transform.Find("down").GetComponent<Image>(),
            defaultDaLeiToggle.transform.Find("right").GetComponent<Image>(),
            defaultDaLeiToggle.transform.Find("Text").GetComponent<Text>(),
            ToggleWithArrowDirection.Vertical
        );
        defaultDaLeiToggle.toggle.isOn = false;

        //TODO
        defaultXiaoleiToggle = transform.Find("xinxiGo/xinxi/ScrollRect/Image/grid/ToggleItem").GetComponent<GameUUToggle>();
        gerendengji = transform.Find("xinxiGo/dengjibang").gameObject;

        gerenzhanli = transform.Find("xinxiGo/zhanlibang").gameObject;

        gerenchongwu = transform.Find("xinxiGo/chongwupingfen").gameObject;

        jingjichang = transform.Find("xinxiGo/jingjichang").gameObject;

        nvnliansai = transform.Find("xinxiGo/nvnbang").gameObject;

        bangpaiBossJindu = transform.Find("xinxiGo/bangpaiBossJindu").gameObject;
        bangpaiBossCishu = transform.Find("xinxiGo/bangpaiBossCishu").gameObject;
        xianhuBang = transform.Find("xinxiGo/xianhubang").gameObject;

        gerendengjiBtns = new List<GameUUButton>();
        GameUUButton gd1 = transform.Find("xinxiGo/dengjibang/topBtnList/paiming").GetComponent<GameUUButton>();
        GameUUButton gd2 = transform.Find("xinxiGo/dengjibang/topBtnList/juese").GetComponent<GameUUButton>();
        GameUUButton gd3 = transform.Find("xinxiGo/dengjibang/topBtnList/zhiye").GetComponent<GameUUButton>();
        GameUUButton gd4 = transform.Find("xinxiGo/dengjibang/topBtnList/dengji").GetComponent<GameUUButton>();
        GameUUButton gd5 = transform.Find("xinxiGo/dengjibang/topBtnList/bangpai").GetComponent<GameUUButton>();
        gerendengjiBtns.Add(gd1);
        gerendengjiBtns.Add(gd2);
        gerendengjiBtns.Add(gd3);
        gerendengjiBtns.Add(gd4);
        gerendengjiBtns.Add(gd5);

        gerenzhanliBtns = new List<GameUUButton>();
        GameUUButton gz1 = transform.Find("xinxiGo/zhanlibang/topBtnList/paiming").GetComponent<GameUUButton>();
        GameUUButton gz2 = transform.Find("xinxiGo/zhanlibang/topBtnList/juese").GetComponent<GameUUButton>();
        GameUUButton gz3 = transform.Find("xinxiGo/zhanlibang/topBtnList/zhiye").GetComponent<GameUUButton>();
        GameUUButton gz4 = transform.Find("xinxiGo/zhanlibang/topBtnList/zhanli").GetComponent<GameUUButton>();
        GameUUButton gz5 = transform.Find("xinxiGo/zhanlibang/topBtnList/bangpai").GetComponent<GameUUButton>();
        gerenzhanliBtns.Add(gz1);
        gerenzhanliBtns.Add(gz2);
        gerenzhanliBtns.Add(gz3);
        gerenzhanliBtns.Add(gz4);
        gerenzhanliBtns.Add(gz5);

        gerenchongwuBtns = new List<GameUUButton>();
        GameUUButton gc1 = transform.Find("xinxiGo/chongwupingfen/topBtnList/paiming").GetComponent<GameUUButton>();
        GameUUButton gc2 = transform.Find("xinxiGo/chongwupingfen/topBtnList/chongwuming").GetComponent<GameUUButton>();
        GameUUButton gc3 = transform.Find("xinxiGo/chongwupingfen/topBtnList/yongyouzhe").GetComponent<GameUUButton>();
        GameUUButton gc4 = transform.Find("xinxiGo/chongwupingfen/topBtnList/pingfen").GetComponent<GameUUButton>();
        gerenchongwuBtns.Add(gc1);
        gerenchongwuBtns.Add(gc2);
        gerenchongwuBtns.Add(gc3);
        gerenchongwuBtns.Add(gc4);

        jingjichangBtns = new List<GameUUButton>();
        GameUUButton gzl1 = transform.Find("xinxiGo/jingjichang/topBtnList/paiming").GetComponent<GameUUButton>();
        GameUUButton gzl2 = transform.Find("xinxiGo/jingjichang/topBtnList/juese").GetComponent<GameUUButton>();
        GameUUButton gzl3 = transform.Find("xinxiGo/jingjichang/topBtnList/zhiye").GetComponent<GameUUButton>();
        GameUUButton gzl4 = transform.Find("xinxiGo/jingjichang/topBtnList/zhanli").GetComponent<GameUUButton>();
        GameUUButton gzl5 = transform.Find("xinxiGo/jingjichang/topBtnList/bangpai").GetComponent<GameUUButton>();
        jingjichangBtns.Add(gzl1);
        jingjichangBtns.Add(gzl2);
        jingjichangBtns.Add(gzl3);
        jingjichangBtns.Add(gzl4);
        jingjichangBtns.Add(gzl5);

        nvnliansaiBtns = new List<GameUUButton>();
        GameUUButton nsb1 = transform.Find("xinxiGo/nvnbang/topBtnList/paiming").GetComponent<GameUUButton>();
        GameUUButton nsb2 = transform.Find("xinxiGo/nvnbang/topBtnList/juese").GetComponent<GameUUButton>();
        GameUUButton nsb3 = transform.Find("xinxiGo/nvnbang/topBtnList/zhiye").GetComponent<GameUUButton>();
        GameUUButton nsb4 = transform.Find("xinxiGo/nvnbang/topBtnList/liansheng").GetComponent<GameUUButton>();
        GameUUButton nsb5 = transform.Find("xinxiGo/nvnbang/topBtnList/jifen").GetComponent<GameUUButton>();
        nvnliansaiBtns.Add(nsb1);
        nvnliansaiBtns.Add(nsb2);
        nvnliansaiBtns.Add(nsb3);
        nvnliansaiBtns.Add(nsb4);
        nvnliansaiBtns.Add(nsb5);

        dengjiScrollRect = transform.Find("xinxiGo/dengjibang/scrollList/Image").GetComponent<UnityEngine.UI.ScrollRect>();
        dengjiItemGrid = transform.Find("xinxiGo/dengjibang/scrollList/Image/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        dengjiItemTBG = transform.Find("xinxiGo/dengjibang/scrollList/Image/grid").gameObject.AddComponent<TabButtonGroup>();
        dengjiItemTBG.Init();

        zhanliScrollRect = transform.Find("xinxiGo/zhanlibang/scrollList/Image").GetComponent<UnityEngine.UI.ScrollRect>();
        zhanliItemGrid = transform.Find("xinxiGo/zhanlibang/scrollList/Image/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        zhanliItemTBG = transform.Find("xinxiGo/zhanlibang/scrollList/Image/grid").gameObject.AddComponent<TabButtonGroup>();
        zhanliItemTBG.Init();

        chongwuScrollRect = transform.Find("xinxiGo/chongwupingfen/scrollList/Image").GetComponent<UnityEngine.UI.ScrollRect>();
        chongwuItemGrid = transform.Find("xinxiGo/chongwupingfen/scrollList/Image/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        chongwuItemTBG = transform.Find("xinxiGo/chongwupingfen/scrollList/Image/grid").gameObject.AddComponent<TabButtonGroup>();
        chongwuItemTBG.Init();

        jingjichangScrollRect = transform.Find("xinxiGo/jingjichang/scrollList/Image").GetComponent<UnityEngine.UI.ScrollRect>();
        jingjichangItemGrid = transform.Find("xinxiGo/jingjichang/scrollList/Image/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        jingjichangItemTBG = transform.Find("xinxiGo/jingjichang/scrollList/Image/grid").gameObject.AddComponent<TabButtonGroup>();
        jingjichangItemTBG.Init();

        nvnScrollRect = transform.Find("xinxiGo/nvnbang/scrollList/Image").GetComponent<UnityEngine.UI.ScrollRect>();
        nvnItemGrid = transform.Find("xinxiGo/nvnbang/scrollList/Image/grid").GetComponent<UnityEngine.UI.GridLayoutGroup>();
        nvnItemTBG = transform.Find("xinxiGo/nvnbang/scrollList/Image/grid").gameObject.AddComponent<TabButtonGroup>();
        nvnItemTBG.Init();

        bangpaiBossJinduScrollRect = transform.Find("xinxiGo/bangpaiBossJindu/scrollList/Image").GetComponent<ScrollRect>();
        bangpaiBossJinduItemGrid = transform.Find("xinxiGo/bangpaiBossJindu/scrollList/Image/grid").GetComponent<GridLayoutGroup>();
        bangpaiBossJinduItemTBG = transform.Find("xinxiGo/bangpaiBossJindu/scrollList/Image/grid").gameObject.AddComponent<TabButtonGroup>();

        bangpaiBossCishuScrollRect = transform.Find("xinxiGo/bangpaiBossCishu/scrollList/Image").GetComponent<ScrollRect>();
        bangpaiBossCishuItemGrid = transform.Find("xinxiGo/bangpaiBossCishu/scrollList/Image/grid").GetComponent<GridLayoutGroup>();
        bangpaiBossCishuItemTBG = transform.Find("xinxiGo/bangpaiBossCishu/scrollList/Image/grid").gameObject.AddComponent<TabButtonGroup>();

        xianhuScrollRect = transform.Find("xinxiGo/xianhubang/scrollList/Image").GetComponent<ScrollRect>();
        xianhuItemGrid = transform.Find("xinxiGo/xianhubang/scrollList/Image/grid").GetComponent<GridLayoutGroup>();
        xianhuItemTBG = transform.Find("xinxiGo/xianhubang/scrollList/Image/grid").gameObject.AddComponent<TabButtonGroup>();

        GerenDengjiItem = transform.Find("xinxiGo/dengjibang/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<PaiHangItemUI>();
        GerenDengjiItem.Init();

        GerenZhanliItem = transform.Find("xinxiGo/zhanlibang/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<PaiHangItemUI>();
        GerenZhanliItem.Init();

        GerenChongwuItem = transform.Find("xinxiGo/chongwupingfen/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<PaiHangItemUI>();
        GerenChongwuItem.Init();

        JingJiChangItem = transform.Find("xinxiGo/jingjichang/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<PaiHangItemUI>();
        JingJiChangItem.Init();

        NvnItem = transform.Find("xinxiGo/nvnbang/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<PaiHangItemUI>();
        NvnItem.Init();

        bangpaiBossCishuItem = transform.Find("xinxiGo/bangpaiBossCishu/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<PaiHangItemUI>();
        bangpaiBossCishuItem.Init();

        bangpaiBossJinduItem = transform.Find("xinxiGo/bangpaiBossJindu/scrollList/Image/grid/bangpaiItem").gameObject.AddComponent<PaiHangItemUI>();
        bangpaiBossJinduItem.Init();

        xianhuItem = transform.Find("xinxiGo/xianhubang/scrollList/Image/grid/xianhuItem").gameObject.AddComponent<PaiHangItemUI>();
        xianhuItem.Init();

        myDengjiItem = transform.Find("xinxiGo/dengjibang/myPaiMing").gameObject.AddComponent<PaiHangItemUI>();
        myDengjiItem.Init();
        myZhanLiItem = transform.Find("xinxiGo/zhanlibang/myPaiMing").gameObject.AddComponent<PaiHangItemUI>();
        myZhanLiItem.Init();
        myChongwuItem = transform.Find("xinxiGo/chongwupingfen/myPetPaiMing").gameObject.AddComponent<PaiHangItemUI>();
        myChongwuItem.Init();
        myJingJiChangItem = transform.Find("xinxiGo/jingjichang/myPaiMing").gameObject.AddComponent<PaiHangItemUI>();
        myJingJiChangItem.Init();
        myNvnItem = transform.Find("xinxiGo/nvnbang/myPaiMing").gameObject.AddComponent<PaiHangItemUI>();
        myNvnItem.Init();
        mybangpaiBossCishuItem = transform.Find("xinxiGo/bangpaiBossCishu/myPaiMing").gameObject.AddComponent<PaiHangItemUI>();
        mybangpaiBossCishuItem.Init();
        mybangpaiBossJinduItem = transform.Find("xinxiGo/bangpaiBossJindu/myPaiMing").gameObject.AddComponent<PaiHangItemUI>();
        mybangpaiBossJinduItem.Init();
        myxianhuItem = transform.Find("xinxiGo/xianhubang/myPaiMing").gameObject.AddComponent<PaiHangItemUI>();
        myxianhuItem.Init();
        

        gerendengji.gameObject.SetActive(false);
        gerenzhanli.gameObject.SetActive(false);
        gerenchongwu.gameObject.SetActive(false);
        jingjichang.gameObject.SetActive(false);
        nvnliansai.gameObject.SetActive(false);
        bangpaiBossCishu.SetActive(false);
        bangpaiBossJindu.SetActive(false);
        xianhuBang.SetActive(false);

    }


}
