using System.Collections;
using System.Collections.Generic;
using app.human;
using app.jingjichang;
using app.net;
using app.nvsn;
using UnityEngine;
using UnityEngine.UI;
using app.bangpaiBoss;
using app.role;
using app.xianhu;

namespace app.paihang
{
    public class PaiHangBangView : BaseWnd
    {
        //[Inject(ui = "PaiHangBangUI")]
        //public GameObject ui;

        /// <summary>
        /// 服务器数据对象
        /// </summary>
        public PaiHangModel paihangModel;

        public JingJiChangModel jingjichangModel;

        public NvsNModel nvnModel;

        public PaiHangBangUI UI;

        private List<string> daleiList;
        private Dictionary<string, List<string>> xiaoleiList;

        private List<ToggleWithArrow> daleiItemList;
        private List<int> xiaoleiType;
        private List<GameUUToggle> xiaoleiItemList;
        private ScrollRectControl scrollRect;
        public Dictionary<int, bool> hasRequestDic;
        //当前的排行榜数据
        private List<RankInfo> dataList;

        //排行的item列表
        private List<PaiHangItemScript> itemList = new List<PaiHangItemScript>();
        //当前选择的排行类型
        private int currentPaihangType = 0;
        private TabButtonGroup currentTBG;
        private PaiHangItemUI currentMyItem;
        private ScrollRect currentScrollRect;
        //自己的排行
        private PaiHangItemScript mydengjiRank;
        private PaiHangItemScript myzhanliRank;
        private PaiHangItemScript mychongwuRank;
        private PaiHangItemScript currentMyRank;

        private PaiHangItemScript jingjichangRank;
        private PaiHangItemScript nvnliansaiRank;

        private PaiHangItemScript myBangpaiBossJindu;
        private PaiHangItemScript mybangpaiBossCishu;

        private PaiHangItemScript myxianhuRank;

        public PaiHangBangView()
        {
            uiName = "PaiHangBangUI";
        }

        public override void initWnd()
        {
            base.initWnd();

            paihangModel = PaiHangModel.Ins;
            paihangModel.addChangeEvent(PaiHangModel.UPDATE_PAIHANG_lIST, updatePaiHang);
            BangPaiBossModel.Ins.addChangeEvent(BangPaiBossModel.UPDATE_RANK_LIST, updatePaiHang);
            XianHuModel.Ins.addChangeEvent(XianHuModel.UPDATE_RANK_LIST, updatePaiHang);
            jingjichangModel = JingJiChangModel.Ins;
            nvnModel = NvsNModel.Ins;

            UI = ui.AddComponent<PaiHangBangUI>();
            UI.Init();
            UI.CloseBtn.SetClickCallBack(closePanel);

            initLeftList();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void initLeftList()
        {
            daleiList = new List<string>();
            daleiList.Add("个人排行");
            daleiList.Add("职业排行");
            daleiList.Add("竞技榜");
            daleiList.Add("帮派Boss");
            daleiList.Add("仙葫榜");

            xiaoleiList = new Dictionary<string, List<string>>();
            List<string> geren = new List<string>();
            geren.Add(LangConstant.LEVEL_NAME);
            geren.Add("战力");
            geren.Add("宠物");
            xiaoleiList.Add("个人排行", geren);
            List<string> zhiye = new List<string>();
            zhiye.Add("侠客");
            zhiye.Add("刺客");
            zhiye.Add("术士");
            zhiye.Add("修真");
            xiaoleiList.Add("职业排行", zhiye);
            List<string> jingji = new List<string>();
            jingji.Add("竞技场");
            jingji.Add("NvN联赛");
            xiaoleiList.Add("竞技榜", jingji);

            List<string> bangpaiBoss = new List<string>();
            bangpaiBoss.Add("帮派Boss进度");
            bangpaiBoss.Add("帮派Boss次数");
            xiaoleiList.Add("帮派Boss", bangpaiBoss);

            List<string> xianhuBang = new List<string>();
            xianhuBang.Add("祈福仙葫(今日)");
            xianhuBang.Add("祈福仙葫(昨日)");
            xianhuBang.Add("灵犀仙葫(今日)");
            xianhuBang.Add("灵犀仙葫(昨日)");
            xianhuBang.Add("灵犀仙葫(本周)");
            xianhuBang.Add("灵犀仙葫(上周)");
            xiaoleiList.Add("仙葫榜", xianhuBang);

            hasRequestDic = new Dictionary<int, bool>();
            hasRequestDic.Add(PaiHangBangType.ROLE_LEVEL, false);
            hasRequestDic.Add(PaiHangBangType.ROLE_ZHANLI, false);
            hasRequestDic.Add(PaiHangBangType.PET_PINGFEN, false);
            hasRequestDic.Add(PaiHangBangType.XIAKE_ZHANLI, false);
            hasRequestDic.Add(PaiHangBangType.CIKE_ZHANLI, false);
            hasRequestDic.Add(PaiHangBangType.SHUSHI_ZHANLI, false);
            hasRequestDic.Add(PaiHangBangType.XIUZHEN_ZHANLI, false);
            hasRequestDic.Add(PaiHangBangType.JINGJICHANG, false);
            hasRequestDic.Add(PaiHangBangType.NVSNLIANSAI, false);
            hasRequestDic.Add(PaiHangBangType.BANGPAI_BOSS_CISHU, false);
            hasRequestDic.Add(PaiHangBangType.BANGPAI_BOSS_JINDU, false);
            hasRequestDic.Add(PaiHangBangType.QIFU_XIANHU_JINRI, false);
            hasRequestDic.Add(PaiHangBangType.QIFU_XIANHU_ZUORI, false);

            hasRequestDic.Add(PaiHangBangType.LINGXI_XIANHU_JINRI, false);
            hasRequestDic.Add(PaiHangBangType.LINGXI_XIANHU_ZUORI, false);
            hasRequestDic.Add(PaiHangBangType.LINGXI_XIANHU_THISWEEK, false);
            hasRequestDic.Add(PaiHangBangType.LINGXI_XIANHU_LASTWEEK, false);


            UI.defaultDaLeiToggle.gameObject.SetActive(false);
            UI.defaultXiaoleiToggle.gameObject.SetActive(false);
            //创建大类
            UI.daleiTBG.ClearToggleList();
            UI.daleiTBG.TabChangeHandler = selectDalei;
            daleiItemList = new List<ToggleWithArrow>();
            xiaoleiType = new List<int>();
            xiaoleiItemList = new List<GameUUToggle>();
            for (int i = 0; i < daleiList.Count; i++)
            {
                ToggleWithArrow twa = GameObject.Instantiate(UI.defaultDaLeiToggle);
                twa.btnText.text = daleiList[i];
                twa.transform.SetParent(UI.toggleParent.transform);
                twa.transform.localScale = Vector3.one;
                daleiItemList.Add(twa);
                twa.gameObject.SetActive(true);
                //twa.toggle.isOn = false;
                UI.daleiTBG.AddToggle(twa.toggle);
                twa.InitListener();
            }
            UI.daleiTBG.SelectDefault = false;
            UI.daleiTBG.AllTabCloseHandler = hideAllXiaolei;
            //创建小类
            UI.xiaoleiTBG.ClearToggleList();
            UI.xiaoleiTBG.TabChangeHandler = selectXiaoLei;
            UI.xiaoleiTBG.SelectDefault = false;
            UI.defaultXiaoleiToggle.gameObject.SetActive(true);
            for (int i = 0; i < geren.Count; i++)
            {
                GameUUToggle toggle = GameObject.Instantiate(UI.defaultXiaoleiToggle);
                toggle.transform.SetParent(UI.toggleParent.transform);
                toggle.transform.localScale = Vector3.one;
                Text txt = toggle.GetComponentInChildren<Text>();
                if (txt != null) txt.text = geren[i];
                xiaoleiItemList.Add(toggle);
                UI.xiaoleiTBG.AddToggle(toggle);
                toggle.gameObject.SetActive(false);
                toggle.isOn = false;
                xiaoleiType.Add(0);
            }
            for (int i = 0; i < zhiye.Count; i++)
            {
                GameUUToggle toggle = GameObject.Instantiate(UI.defaultXiaoleiToggle);
                toggle.transform.SetParent(UI.toggleParent.transform);
                toggle.transform.localScale = Vector3.one;
                Text txt = toggle.GetComponentInChildren<Text>();
                if (txt != null) txt.text = zhiye[i];
                xiaoleiItemList.Add(toggle);
                UI.xiaoleiTBG.AddToggle(toggle);
                toggle.gameObject.SetActive(false);
                toggle.isOn = false;
                xiaoleiType.Add(1);
            }

            for (int i = 0; i < jingji.Count; i++)
            {
                GameUUToggle toggle = GameObject.Instantiate(UI.defaultXiaoleiToggle);
                toggle.transform.SetParent(UI.toggleParent.transform);
                toggle.transform.localScale = Vector3.one;
                Text txt = toggle.GetComponentInChildren<Text>();
                if (txt != null) txt.text = jingji[i];
                xiaoleiItemList.Add(toggle);
                UI.xiaoleiTBG.AddToggle(toggle);
                toggle.gameObject.SetActive(false);
                toggle.isOn = false;
                xiaoleiType.Add(2);
            }

            for (int i = 0; i < bangpaiBoss.Count; i++)
            {
                GameUUToggle toggle = GameObject.Instantiate(UI.defaultXiaoleiToggle);
                toggle.transform.SetParent(UI.toggleParent.transform);
                toggle.transform.localScale = Vector3.one;
                Text txt = toggle.GetComponentInChildren<Text>();
                if (txt != null) txt.text = bangpaiBoss[i];
                xiaoleiItemList.Add(toggle);
                UI.xiaoleiTBG.AddToggle(toggle);
                toggle.gameObject.SetActive(false);
                toggle.isOn = false;
                xiaoleiType.Add(3);
            }

            for (int i = 0; i < xianhuBang.Count; i++)
            {
                GameUUToggle toggle = GameObject.Instantiate(UI.defaultXiaoleiToggle);
                toggle.transform.SetParent(UI.toggleParent.transform);
                toggle.transform.localScale = Vector3.one;
                Text txt = toggle.GetComponentInChildren<Text>();
                if (txt != null) txt.text = xianhuBang[i];
                xiaoleiItemList.Add(toggle);
                UI.xiaoleiTBG.AddToggle(toggle);
                toggle.gameObject.SetActive(false);
                toggle.isOn = false;
                xiaoleiType.Add(4);
            }

            UI.defaultXiaoleiToggle.gameObject.SetActive(false);

            UI.GerenDengjiItem.gameObject.SetActive(false);
            UI.GerenZhanliItem.gameObject.SetActive(false);
            UI.GerenChongwuItem.gameObject.SetActive(false);
            UI.JingJiChangItem.gameObject.SetActive(false);
            UI.NvnItem.gameObject.SetActive(false);
            UI.bangpaiBossJinduItem.gameObject.SetActive(false);
            UI.bangpaiBossCishuItem.gameObject.SetActive(false);
            UI.mybangpaiBossCishuItem.gameObject.SetActive(false);
            UI.mybangpaiBossJinduItem.gameObject.SetActive(false);
            UI.myxianhuItem.gameObject.SetActive(false);
            UI.xianhuItem.gameObject.SetActive(false);
        }

        private void hideAllXiaolei()
        {
            for (int i = 0; i < xiaoleiItemList.Count; i++)
            {
                xiaoleiItemList[i].gameObject.SetActive(false);
            }
        }

        private void closePanel()
        {
            hide();
        }

        private bool HasRequested(int paihangbangType)
        {
            bool value = false;
            hasRequestDic.TryGetValue(paihangbangType, out value);
            return value;
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.Show();
            int selectTab = PaiHangBangType.ROLE_LEVEL;
            if (e != null)
            {
                object selecttab = WndParam.GetWndParam(e, WndParam.SelectTab);
                if (selecttab != null)
                {
                    int.TryParse(selecttab.ToString(), out selectTab);
                }
            }
            switch (selectTab)
            {
                //1个人等级排行
                case PaiHangBangType.ROLE_LEVEL:
                    UI.daleiTBG.SetIndexWithCallBack(0);
                    UI.xiaoleiTBG.SetIndexWithCallBack(0);
                    break;
                //2个人战力排行
                case PaiHangBangType.ROLE_ZHANLI:
                    UI.daleiTBG.SetIndexWithCallBack(0);
                    UI.xiaoleiTBG.SetIndexWithCallBack(1);
                    break;
                //3个人宠物评分
                case PaiHangBangType.PET_PINGFEN:
                    UI.daleiTBG.SetIndexWithCallBack(0);
                    UI.xiaoleiTBG.SetIndexWithCallBack(2);
                    break;
                //4侠客职业战力排行
                case PaiHangBangType.XIAKE_ZHANLI:
                    UI.daleiTBG.SetIndexWithCallBack(1);
                    UI.xiaoleiTBG.SetIndexWithCallBack(3);
                    break;
                //5刺客职业战力排行
                case PaiHangBangType.CIKE_ZHANLI:
                    UI.daleiTBG.SetIndexWithCallBack(1);
                    UI.xiaoleiTBG.SetIndexWithCallBack(4);
                    break;
                //6术士职业战力排行
                case PaiHangBangType.SHUSHI_ZHANLI:
                    UI.daleiTBG.SetIndexWithCallBack(1);
                    UI.xiaoleiTBG.SetIndexWithCallBack(5);
                    break;
                //7修真职业战力排行
                case PaiHangBangType.XIUZHEN_ZHANLI:
                    UI.daleiTBG.SetIndexWithCallBack(6);
                    UI.xiaoleiTBG.SetIndexWithCallBack(3);
                    break;
                //8竞技场
                case PaiHangBangType.JINGJICHANG:
                    UI.daleiTBG.SetIndexWithCallBack(2);
                    UI.xiaoleiTBG.SetIndexWithCallBack(7);
                    break;
                //9nvn联赛
                case PaiHangBangType.NVSNLIANSAI:
                    UI.daleiTBG.SetIndexWithCallBack(2);
                    UI.xiaoleiTBG.SetIndexWithCallBack(8);
                    break;
                //10帮派Boss进度
                case PaiHangBangType.BANGPAI_BOSS_JINDU:
                    UI.daleiTBG.SetIndexWithCallBack(3);
                    UI.xiaoleiTBG.SetIndexWithCallBack(9);
                    break;
                //11帮派Boss次数
                case PaiHangBangType.BANGPAI_BOSS_CISHU:
                    UI.daleiTBG.SetIndexWithCallBack(3);
                    UI.xiaoleiTBG.SetIndexWithCallBack(10);
                    break;
                //12祈福仙葫(今日)
                case PaiHangBangType.QIFU_XIANHU_JINRI:
                    UI.daleiTBG.SetIndexWithCallBack(4);
                    UI.xiaoleiTBG.SetIndexWithCallBack(11);
                    break;
                //13祈福仙葫(昨日)
                case PaiHangBangType.QIFU_XIANHU_ZUORI:
                    UI.daleiTBG.SetIndexWithCallBack(4);
                    UI.xiaoleiTBG.SetIndexWithCallBack(12);
                    break;
                //14灵犀仙葫(今日)
                case PaiHangBangType.LINGXI_XIANHU_JINRI:
                    UI.daleiTBG.SetIndexWithCallBack(4);
                    UI.xiaoleiTBG.SetIndexWithCallBack(13);
                    break;
                //15灵犀仙葫(昨日)
                case PaiHangBangType.LINGXI_XIANHU_ZUORI:
                    UI.daleiTBG.SetIndexWithCallBack(4);
                    UI.xiaoleiTBG.SetIndexWithCallBack(14);
                    break;
                //16灵犀仙葫(本周)
                case PaiHangBangType.LINGXI_XIANHU_THISWEEK:
                    UI.daleiTBG.SetIndexWithCallBack(4);
                    UI.xiaoleiTBG.SetIndexWithCallBack(15);
                    break;
                //17灵犀仙葫(上周)
                case PaiHangBangType.LINGXI_XIANHU_LASTWEEK:
                    UI.daleiTBG.SetIndexWithCallBack(4);
                    UI.xiaoleiTBG.SetIndexWithCallBack(16);
                    break;
                default:
                    UI.daleiTBG.SetIndexWithCallBack(0);
                    UI.xiaoleiTBG.SetIndexWithCallBack(0);
                    break;
            }
            app.main.GameClient.ins.OnBigWndShown();
        }

        public override void hide(RMetaEvent e = null)
        {
            ScrollerManager.Ins.DisposeScroll(scrollRect);
            scrollRect = null;
            //for (int i = PaiHangBangType.ROLE_LEVEL; i <= PaiHangBangType.NVSNLIANSAI; i++)
            //{
            //    hasRequestDic[i] = false;
            //}
            //每次打开界面，重新请求
            for (int i = 0; i < hasRequestDic.Count; i++)
            {
                hasRequestDic[i] = false;
            }
            app.main.GameClient.ins.OnBigWndHidden();
            base.hide(e);
            UI.Hide();
        }

        public void selectDalei(int tab)
        {
            for (int i = 0; i < xiaoleiItemList.Count; i++)
            {
                xiaoleiItemList[i].transform.SetAsLastSibling();
            }
            int showNum = 0;
            int startSibling = 2 + tab + 1;
            for (int i = 0; i < xiaoleiItemList.Count; i++)
            {
                xiaoleiItemList[i].isOn = false;
                if (xiaoleiType[i] == tab)
                {
                    xiaoleiItemList[i].gameObject.SetActive(true);
                    xiaoleiItemList[i].transform.SetSiblingIndex(startSibling + showNum);
                    showNum++;
                }
                else
                {
                    xiaoleiItemList[i].gameObject.SetActive(false);
                }
                xiaoleiItemList[i].isOn = false;
            }
        }

        public void selectXiaoLei(int tab)
        {
            if (xiaoleiItemList == null)
            {
                return;
            }
            if (tab >= xiaoleiItemList.Count || UI.daleiTBG.index < 0)
            {
                return;
            }
            GameObject defaultItem = null;
            ScrollRect scroll = null;
            GameObject itemGrid = null;
            switch (UI.daleiTBG.index)
            {
                case 0:
                    //个人排行
                    switch (tab)
                    {
                        case 0:
                            //个人等级
                            currentPaihangType = PaiHangBangType.ROLE_LEVEL;
                            defaultItem = UI.GerenDengjiItem.gameObject;
                            scroll = UI.dengjiScrollRect;
                            itemGrid = UI.dengjiItemGrid.gameObject;
                            currentTBG = UI.dengjiItemTBG;
                            currentScrollRect = UI.dengjiScrollRect;
                            currentMyItem = UI.myDengjiItem;
                            UI.gerendengji.gameObject.SetActive(true);
                            UI.gerenzhanli.gameObject.SetActive(false);
                            UI.gerenchongwu.gameObject.SetActive(false);
                            UI.jingjichang.gameObject.SetActive(false);
                            UI.nvnliansai.gameObject.SetActive(false);
                            UI.bangpaiBossCishu.SetActive(false);
                            UI.bangpaiBossJindu.SetActive(false);
                            UI.xianhuBang.SetActive(false);
                            if (mydengjiRank == null)
                            {
                                mydengjiRank = new PaiHangItemScript(UI.myDengjiItem, UI.dengjiScrollRect);
                            }
                            currentMyRank = mydengjiRank;
                            break;
                        case 1:
                            //个人战力
                            currentPaihangType = PaiHangBangType.ROLE_ZHANLI;
                            defaultItem = UI.GerenZhanliItem.gameObject;
                            scroll = UI.zhanliScrollRect;
                            itemGrid = UI.zhanliItemGrid.gameObject;
                            currentTBG = UI.zhanliItemTBG;
                            currentScrollRect = UI.zhanliScrollRect;
                            currentMyItem = UI.myZhanLiItem;
                            UI.gerendengji.gameObject.SetActive(false);
                            UI.gerenzhanli.gameObject.SetActive(true);
                            UI.gerenchongwu.gameObject.SetActive(false);
                            UI.jingjichang.gameObject.SetActive(false);
                            UI.nvnliansai.gameObject.SetActive(false);
                            UI.bangpaiBossCishu.SetActive(false);
                            UI.bangpaiBossJindu.SetActive(false);
                            UI.xianhuBang.SetActive(false);
                            if (myzhanliRank == null)
                            {
                                myzhanliRank = new PaiHangItemScript(UI.myZhanLiItem, UI.zhanliScrollRect);
                            }
                            currentMyRank = myzhanliRank;
                            break;
                        case 2:
                            //个人宠物
                            currentPaihangType = PaiHangBangType.PET_PINGFEN;
                            defaultItem = UI.GerenChongwuItem.gameObject;
                            scroll = UI.chongwuScrollRect;
                            itemGrid = UI.chongwuItemGrid.gameObject;
                            currentTBG = UI.chongwuItemTBG;
                            currentScrollRect = UI.chongwuScrollRect;
                            UI.gerendengji.gameObject.SetActive(false);
                            UI.gerenzhanli.gameObject.SetActive(false);
                            UI.gerenchongwu.gameObject.SetActive(true);
                            UI.jingjichang.gameObject.SetActive(false);
                            UI.nvnliansai.gameObject.SetActive(false);
                            UI.bangpaiBossCishu.SetActive(false);
                            UI.bangpaiBossJindu.SetActive(false);
                            UI.xianhuBang.SetActive(false);
                            if (mychongwuRank == null)
                            {
                                mychongwuRank = new PaiHangItemScript(UI.myChongwuItem, UI.chongwuScrollRect);
                            }
                            currentMyRank = mychongwuRank;
                            break;
                    }
                    break;
                case 1:
                    //职业排行
                    switch (tab)
                    {
                        case 3:
                            currentPaihangType = PaiHangBangType.XIAKE_ZHANLI;
                            break;
                        case 4:
                            currentPaihangType = PaiHangBangType.CIKE_ZHANLI;
                            break;
                        case 5:
                            currentPaihangType = PaiHangBangType.SHUSHI_ZHANLI;
                            break;
                        case 6:
                            currentPaihangType = PaiHangBangType.XIUZHEN_ZHANLI;
                            break;
                    }
                    defaultItem = UI.GerenZhanliItem.gameObject;
                    scroll = UI.zhanliScrollRect;
                    itemGrid = UI.zhanliItemGrid.gameObject;
                    currentTBG = UI.zhanliItemTBG;
                    currentScrollRect = UI.zhanliScrollRect;
                    currentMyItem = UI.myZhanLiItem;
                    UI.gerendengji.gameObject.SetActive(false);
                    UI.gerenzhanli.gameObject.SetActive(true);
                    UI.gerenchongwu.gameObject.SetActive(false);
                    UI.jingjichang.gameObject.SetActive(false);
                    UI.nvnliansai.gameObject.SetActive(false);
                    if (myzhanliRank == null)
                    {
                        myzhanliRank = new PaiHangItemScript(UI.myZhanLiItem, UI.zhanliScrollRect);
                    }
                    currentMyRank = myzhanliRank;
                    break;
                case 2:
                    //竞技榜
                    switch (tab)
                    {
                        case 7:
                            //竞技场
                            currentPaihangType = PaiHangBangType.JINGJICHANG;
                            defaultItem = UI.JingJiChangItem.gameObject;
                            scroll = UI.jingjichangScrollRect;
                            itemGrid = UI.jingjichangItemGrid.gameObject;
                            currentTBG = UI.jingjichangItemTBG;
                            currentScrollRect = UI.jingjichangScrollRect;
                            currentMyItem = UI.myJingJiChangItem;
                            UI.gerendengji.gameObject.SetActive(false);
                            UI.gerenzhanli.gameObject.SetActive(true);
                            UI.gerenchongwu.gameObject.SetActive(false);
                            UI.jingjichang.gameObject.SetActive(true);
                            UI.nvnliansai.gameObject.SetActive(false);
                            UI.bangpaiBossCishu.SetActive(false);
                            UI.bangpaiBossJindu.SetActive(false);
                            UI.xianhuBang.SetActive(false);
                            if (jingjichangRank == null)
                            {
                                jingjichangRank = new PaiHangItemScript(UI.myJingJiChangItem, UI.jingjichangScrollRect);
                            }
                            currentMyRank = jingjichangRank;
                            break;
                        case 8:
                            //NvN联赛
                            currentPaihangType = PaiHangBangType.NVSNLIANSAI;
                            defaultItem = UI.NvnItem.gameObject;
                            scroll = UI.nvnScrollRect;
                            itemGrid = UI.nvnItemGrid.gameObject;
                            currentTBG = UI.nvnItemTBG;
                            currentScrollRect = UI.nvnScrollRect;
                            currentMyItem = UI.myNvnItem;
                            UI.gerendengji.gameObject.SetActive(false);
                            UI.gerenzhanli.gameObject.SetActive(true);
                            UI.gerenchongwu.gameObject.SetActive(false);
                            UI.jingjichang.gameObject.SetActive(false);
                            UI.nvnliansai.gameObject.SetActive(true);
                            UI.bangpaiBossCishu.SetActive(false);
                            UI.bangpaiBossJindu.SetActive(false);
                            UI.xianhuBang.SetActive(false);
                            if (nvnliansaiRank == null)
                            {
                                nvnliansaiRank = new PaiHangItemScript(UI.myNvnItem, UI.nvnScrollRect);
                            }
                            currentMyRank = nvnliansaiRank;
                            break;
                    }
                    break;
                    //帮派Boss
                case 3:
                    switch (tab)
                    {
                            //帮派Boss进度
                        case 9:
                            currentPaihangType = PaiHangBangType.BANGPAI_BOSS_JINDU;
                            defaultItem = UI.bangpaiBossJinduItem.gameObject;
                            scroll = UI.bangpaiBossJinduScrollRect;
                            itemGrid = UI.bangpaiBossJinduItemGrid.gameObject;
                            currentTBG = UI.bangpaiBossJinduItemTBG;
                            currentScrollRect = UI.bangpaiBossJinduScrollRect;
                            currentMyItem = UI.mybangpaiBossJinduItem;
                            UI.gerendengji.gameObject.SetActive(false);
                            UI.gerenzhanli.gameObject.SetActive(false);
                            UI.gerenchongwu.gameObject.SetActive(false);
                            UI.jingjichang.gameObject.SetActive(false);
                            UI.nvnliansai.gameObject.SetActive(false);
                            UI.bangpaiBossCishu.SetActive(false);
                            UI.bangpaiBossJindu.SetActive(true);
                            UI.xianhuBang.SetActive(false);
                            
                            if (myBangpaiBossJindu == null)
                            {
                                myBangpaiBossJindu = new PaiHangItemScript(UI.mybangpaiBossJinduItem,UI.bangpaiBossJinduScrollRect);
                            }

                            currentMyRank = myBangpaiBossJindu;
                            
                            break;
                            //帮派Boss次数
                        case 10:
                            currentPaihangType = PaiHangBangType.BANGPAI_BOSS_CISHU;
                            defaultItem = UI.bangpaiBossCishuItem.gameObject;
                            scroll = UI.bangpaiBossCishuScrollRect;
                            itemGrid = UI.bangpaiBossCishuItemGrid.gameObject;
                            currentTBG = UI.bangpaiBossCishuItemTBG;
                            currentScrollRect = UI.bangpaiBossCishuScrollRect;
                            currentMyItem = UI.mybangpaiBossCishuItem;
                            UI.gerendengji.gameObject.SetActive(false);
                            UI.gerenzhanli.gameObject.SetActive(false);
                            UI.gerenchongwu.gameObject.SetActive(false);
                            UI.jingjichang.gameObject.SetActive(false);
                            UI.nvnliansai.gameObject.SetActive(false);
                            UI.bangpaiBossCishu.SetActive(true);
                            UI.bangpaiBossJindu.SetActive(false);
                            UI.xianhuBang.SetActive(false);
                            if (mybangpaiBossCishu == null)
                            {
                                mybangpaiBossCishu = new PaiHangItemScript(UI.mybangpaiBossCishuItem, UI.bangpaiBossCishuScrollRect);
                            }
                            currentMyRank = mybangpaiBossCishu;
                            break;
                    }
                    break;
                    //仙葫榜
                case 4:

                    currentPaihangType = tab + 1;

                    defaultItem = UI.xianhuItem.gameObject;
                    scroll = UI.xianhuScrollRect;
                    itemGrid = UI.xianhuItemGrid.gameObject;
                    currentTBG = UI.xianhuItemTBG;
                    currentScrollRect = UI.xianhuScrollRect;
                    currentMyItem = UI.myxianhuItem;
                    UI.gerendengji.gameObject.SetActive(false);
                    UI.gerenzhanli.gameObject.SetActive(false);
                    UI.gerenchongwu.gameObject.SetActive(false);
                    UI.jingjichang.gameObject.SetActive(false);
                    UI.nvnliansai.gameObject.SetActive(false);
                    UI.bangpaiBossCishu.SetActive(false);
                    UI.bangpaiBossJindu.SetActive(false);
                    UI.xianhuBang.SetActive(true);
                    if (myxianhuRank == null)
                    {
                        myxianhuRank = new PaiHangItemScript(UI.myxianhuItem, UI.xianhuScrollRect);
                    }
                    currentMyRank = myxianhuRank;
                    break;
            }
            //是否直接打开宠物面板
            if (UI.daleiTBG.index == 0 && tab == 2)
            {
                PopRoleInfoWnd.Ins.mCurStatue = PopRoleInfoWnd.EStatue.CheckPet;
            }
            else
            {
                PopRoleInfoWnd.Ins.mCurStatue = PopRoleInfoWnd.EStatue.NoQiecuo;
            }

            if (currentPaihangType != 0 && !HasRequested(currentPaihangType))
            {
                long questTime;
                switch (currentPaihangType)
                {
                    case PaiHangBangType.JINGJICHANG:
                        //请求数据
                        ArenaCGHandler.sendCGArenaTopRankList();
                        break;
                    case PaiHangBangType.NVSNLIANSAI:
                        //请求数据
                        NvnCGHandler.sendCGNvnTopRankList();
                        break;
                    case PaiHangBangType.BANGPAI_BOSS_CISHU:
                        CorpsbossCGHandler.sendCGCorpsbossCountRankList();
                        break;
                    case PaiHangBangType.BANGPAI_BOSS_JINDU:
                        CorpsbossCGHandler.sendCGCorpsbossRankList();
                        break;
                    case PaiHangBangType.QIFU_XIANHU_JINRI:
                        //请求数据
                        HumanCGHandler.sendCGXianhuRankList((int)XianhuRankType.QIFU_XIANHU_JINRI);
                        break;
                    case PaiHangBangType.QIFU_XIANHU_ZUORI:
                        //请求数据
                        HumanCGHandler.sendCGXianhuRankList((int)XianhuRankType.QIFU_XIANHU_ZUORI);
                        break;
                    case PaiHangBangType.LINGXI_XIANHU_JINRI:
                        //请求数据
                        HumanCGHandler.sendCGXianhuRankList((int)XianhuRankType.LINGXI_XIANHU_JINRI);
                        break;
                    case PaiHangBangType.LINGXI_XIANHU_ZUORI:
                        //请求数据
                        HumanCGHandler.sendCGXianhuRankList((int)XianhuRankType.LINGXI_XIANHU_ZUORI);
                        break;
                    case PaiHangBangType.LINGXI_XIANHU_THISWEEK:
                        //请求数据
                        HumanCGHandler.sendCGXianhuRankList((int)XianhuRankType.LINGXI_XIANHU_THISWEEK);
                        break;
                    case PaiHangBangType.LINGXI_XIANHU_LASTWEEK:
                        //请求数据
                        HumanCGHandler.sendCGXianhuRankList((int)XianhuRankType.LINGXI_XIANHU_LASTWEEK);
                        break;
                    default:
                        //请求数据
                        questTime = paihangModel.GetRankTimeyType(currentPaihangType);
                        RankCGHandler.sendCGRankApply(currentPaihangType, questTime);
                        break;
                }
                hasRequestDic[currentPaihangType] = true;
            }
            else
            {
                //设置数据
                currentTBG.ClearToggleList();
                if (scrollRect != null)
                {
                    scrollRect.DisPose();
                }
                switch (currentPaihangType)
                {
                    case PaiHangBangType.JINGJICHANG:
                        if (jingjichangModel.RankList != null && jingjichangModel.RankList.Count > 0)
                        {
                            scrollRect = ScrollerManager.Ins.createScroll(scroll, defaultItem, itemGrid, addOnePage);
                            scrollRect.setItemNum(9, jingjichangModel.RankList.Count);
                        }
                        ArenaMemberData myJJCrankinfo = new ArenaMemberData();
                        myJJCrankinfo.rank = jingjichangModel.MyRankListInfo.getMyRank();
                        myJJCrankinfo.name = Human.Instance.getName();
                        myJJCrankinfo.tplId = Human.Instance.PetModel.getLeader().getTplId();
                        myJJCrankinfo.fightPower = Human.Instance.PetModel.getLeader().getFightPower();
                        myJJCrankinfo.corpsName = jingjichangModel.MyRankListInfo.getMyCorpsName();
                        currentMyRank.UI.gameObject.SetActive(true);
                        currentMyRank.setRankInfo(myJJCrankinfo);
                        break;
                    case PaiHangBangType.NVSNLIANSAI:
                        if (nvnModel.RankList != null && nvnModel.RankList.Length > 0)
                        {
                            scrollRect = ScrollerManager.Ins.createScroll(scroll, defaultItem, itemGrid, addOnePage);
                            scrollRect.setItemNum(9, nvnModel.RankList.Length);
                        }
                        NvnRankInfo myNVNrankinfo = new NvnRankInfo();
                        myNVNrankinfo.rank = nvnModel.MyrankInfo.getMyRank();
                        myNVNrankinfo.name = Human.Instance.getName();
                        myNVNrankinfo.tplId = Human.Instance.PetModel.getLeader().getTplId();
                        myNVNrankinfo.conWinNum = nvnModel.MyrankInfo.getMyConWinNum();
                        myNVNrankinfo.score = nvnModel.MyrankInfo.getMyScore();
                        currentMyRank.UI.gameObject.SetActive(true);
                        currentMyRank.setRankInfo(myNVNrankinfo);
                        break;
                    case PaiHangBangType.BANGPAI_BOSS_CISHU:
                        if (BangPaiBossModel.Ins.corpsBossCountRankList != null && BangPaiBossModel.Ins.corpsBossCountRankList.getCbCountRankInfoList().Length > 0)
                        {
                            scrollRect = ScrollerManager.Ins.createScroll(scroll, defaultItem, itemGrid, addOnePage);
                            scrollRect.setItemNum(9, BangPaiBossModel.Ins.corpsBossCountRankList.getCbCountRankInfoList().Length);
                        }
                        int mhasCorp1 = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.HAS_CORPS);
                        if (BangPaiBossModel.Ins.corpsBossCountRankList == null || mhasCorp1 <= 0)
                        {
                            CorpsBossCountRankInfo temp = null;                           
                            currentMyRank.setRankInfo(temp);
                        }
                        else
                        {
                            currentMyRank.setRankInfo(BangPaiBossModel.Ins.corpsBossCountRankList.getCbCountRankInfo());
                        }
                        break;
                    case PaiHangBangType.BANGPAI_BOSS_JINDU:
                        if (BangPaiBossModel.Ins.corpsBossRankList != null && BangPaiBossModel.Ins.corpsBossRankList.getCbRankInfoList().Length > 0)
                        {
                            scrollRect = ScrollerManager.Ins.createScroll(scroll, defaultItem, itemGrid, addOnePage);
                            scrollRect.setItemNum(9, BangPaiBossModel.Ins.corpsBossRankList.getCbRankInfoList().Length);
                        }
                         int mhasCorp = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.HAS_CORPS);
                
                        if (BangPaiBossModel.Ins.corpsBossRankList == null || mhasCorp <= 0)
                        {
                            CorpsBossRankInfo temp = null;
                            currentMyRank.setRankInfo(temp);
                        }
                        else
                        {
                            currentMyRank.setRankInfo(BangPaiBossModel.Ins.corpsBossRankList.getCbRankInfo());
                        }
                        break;
                    case PaiHangBangType.QIFU_XIANHU_JINRI:
                    case PaiHangBangType.QIFU_XIANHU_ZUORI:
                    case PaiHangBangType.LINGXI_XIANHU_JINRI:
                    case PaiHangBangType.LINGXI_XIANHU_ZUORI:
                    case PaiHangBangType.LINGXI_XIANHU_THISWEEK:
                    case PaiHangBangType.LINGXI_XIANHU_LASTWEEK:
                        GCXianhuRankList xianhuranklist = XianHuModel.Ins.GetXianHuRankList(currentPaihangType - 11);
                        if (xianhuranklist != null && xianhuranklist.getXianhuRankInfoList().Length > 0)
                        {
                            scrollRect = ScrollerManager.Ins.createScroll(scroll, defaultItem, itemGrid, addOnePage);
                            scrollRect.setItemNum(9, xianhuranklist.getXianhuRankInfoList().Length);
                        }
                        if (null != xianhuranklist)
                        {
                            XianhuRankInfo xianhuinfo = new XianhuRankInfo();
                            xianhuinfo.rank = xianhuranklist.getMyRank();
                            xianhuinfo.roleId = Human.Instance.PetModel.getLeader().Id;
                            xianhuinfo.name = Human.Instance.getName();
                            xianhuinfo.tplId = Human.Instance.PetModel.getLeader().getTplId();
                            xianhuinfo.corpsId = xianhuranklist.getMyCorpsId();
                            xianhuinfo.corpsName = xianhuranklist.getMyCorpsName();
                            xianhuinfo.num = xianhuranklist.getMyNum();
                            currentMyRank.UI.gameObject.SetActive(true);
                            currentMyRank.setRankInfo(xianhuinfo);
                        }
                        //TODO::设置数据
                        break;
                    default:
                        dataList = paihangModel.GetRankListByType(currentPaihangType);
                        for (int i = 0; dataList != null && i < dataList.Count; i++)
                        {
                            if (dataList[i].rank < 0)
                            {
                                dataList.RemoveAt(i);
                            }
                        }
                        
                        RankInfo myrank = paihangModel.GetMyRankByType(currentPaihangType);
                        if (myrank != null && myrank.rank == -1)
                        {
                            currentMyRank.UI.gameObject.SetActive(false);
                        }
                        else
                        {
                            currentMyRank.UI.gameObject.SetActive(true);
                            currentMyRank.setRankInfo(myrank, currentPaihangType);
                        }
                        if (dataList != null && dataList.Count > 0 && null != myrank)
                        {
                            if (dataList[dataList.Count - 1] == myrank)
                            {
                                dataList.RemoveAt(dataList.Count - 1);
                            }
                        }
                        if (dataList != null && dataList.Count > 0)
                        {
                            scrollRect = ScrollerManager.Ins.createScroll(scroll, defaultItem, itemGrid, addOnePage);
                            scrollRect.setItemNum(9, dataList.Count);
                        }
                        break;
                }
            }
        }

        private IEnumerator addOnePage(int startIndex, int count)
        {
            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (i >= itemList.Count)
                {
                    PaiHangItemScript script = new PaiHangItemScript(scrollRect.goList[i].GetComponent<PaiHangItemUI>(), currentScrollRect);
                    itemList.Add(script);
                    //script.UI.ScrollRect = UI.dengjiItemGrid.transform.parent.GetComponent<ScrollRect>();
                }
                itemList[i].UI = scrollRect.goList[i].GetComponent<PaiHangItemUI>();
                itemList[i].UI.gameObject.SetActive(true);
                itemList[i].UI.SetIndex(i);
                GameUUToggle toggle = itemList[i].UI.GetComponent<GameUUToggle>();
                toggle.isOn = false;
                currentTBG.AddToggle(toggle);
                int paiming = 0;
                switch (currentPaihangType)
                {
                    case PaiHangBangType.JINGJICHANG:
                        itemList[i].setRankInfo(jingjichangModel.RankList[i]);
                        paiming = jingjichangModel.RankList[i].rank;
                        break;
                    case PaiHangBangType.NVSNLIANSAI:
                        itemList[i].setRankInfo(nvnModel.RankList[i]);
                        paiming = nvnModel.RankList[i].rank;
                        break;
                    case PaiHangBangType.BANGPAI_BOSS_CISHU:
                        itemList[i].setRankInfo(BangPaiBossModel.Ins.corpsBossCountRankList.getCbCountRankInfoList()[i]);
                        paiming = BangPaiBossModel.Ins.corpsBossCountRankList.getCbCountRankInfoList()[i].rank;
                        break;
                    case PaiHangBangType.BANGPAI_BOSS_JINDU:
                        itemList[i].setRankInfo(BangPaiBossModel.Ins.corpsBossRankList.getCbRankInfoList()[i]);
                        paiming = BangPaiBossModel.Ins.corpsBossRankList.getCbRankInfoList()[i].rank;
                        break;
                    case PaiHangBangType.QIFU_XIANHU_JINRI:
                    case PaiHangBangType.QIFU_XIANHU_ZUORI:
                    case PaiHangBangType.LINGXI_XIANHU_JINRI:
                    case PaiHangBangType.LINGXI_XIANHU_ZUORI:
                    case PaiHangBangType.LINGXI_XIANHU_THISWEEK:
                    case PaiHangBangType.LINGXI_XIANHU_LASTWEEK:
                        itemList[i].setRankInfo(XianHuModel.Ins.GetXianHuRankList(currentPaihangType - 11).getXianhuRankInfoList()[i]);
                        paiming = XianHuModel.Ins.GetXianHuRankList(currentPaihangType - 11).getXianhuRankInfoList()[i].rank;
                        break;
                    default:
                        itemList[i].setRankInfo(dataList[i], currentPaihangType);
                        paiming = dataList[i].rank;
                        break;
                }
                if (itemList[i].UI.qiansan)
                {
                    //itemList[i].UI.qiansan.gameObject.SetActive(false);
                    itemList[i].UI.qiansan.enabled = false;
                }

                if (paiming >= 1 && paiming <= 3)
                {
                    if (itemList[i].UI.qiansan == null)
                    {
                        continue;
                    }

                    if (paiming == 1)
                    {
                        PathUtil.Ins.SetSprite(itemList[i].UI.qiansan, "1st", PathUtil.Ins.uiDependenciesPath,true);
                    }
                    if (paiming == 2)
                    {
                        PathUtil.Ins.SetSprite(itemList[i].UI.qiansan, "2nd", PathUtil.Ins.uiDependenciesPath, true);
                    }
                    if (paiming == 3)
                    {
                        PathUtil.Ins.SetSprite(itemList[i].UI.qiansan, "3rd", PathUtil.Ins.uiDependenciesPath, true);
                    }
                    itemList[i].UI.paiming.gameObject.SetActive(false);
                    //itemList[i].UI.qiansan.gameObject.SetActive(true);
                    itemList[i].UI.qiansan.enabled = true;
                }
                if (i % 6 == 0)
                {
                    yield return 0;
                }
            }
        }

        public void updatePaiHang(RMetaEvent e)
        {
            selectXiaoLei(UI.xiaoleiTBG.index);
        }

        public override void Destroy()
        {
            paihangModel.removeChangeEvent(PaiHangModel.UPDATE_PAIHANG_lIST, updatePaiHang);
            BangPaiBossModel.Ins.removeChangeEvent(BangPaiBossModel.UPDATE_RANK_LIST, updatePaiHang);
            XianHuModel.Ins.removeChangeEvent(XianHuModel.UPDATE_RANK_LIST, updatePaiHang);
            daleiList = null;
            xiaoleiList = null;

            for (int i = 0; daleiItemList != null && i < daleiItemList.Count; i++)
            {
                GameObject.DestroyImmediate(daleiItemList[i].gameObject, true);
            }
            if (daleiItemList != null) daleiItemList.Clear();
            daleiItemList = null;

            for (int i = 0; xiaoleiItemList != null && i < xiaoleiItemList.Count; i++)
            {
                GameObject.DestroyImmediate(xiaoleiItemList[i].gameObject, true);
            }
            if (xiaoleiItemList != null) xiaoleiItemList.Clear();
            xiaoleiItemList = null;

            scrollRect = null;
            if (hasRequestDic != null) hasRequestDic.Clear();
            hasRequestDic = null;
            if (dataList != null) dataList.Clear();
            dataList = null;

            for (int i = 0; itemList != null && i < itemList.Count; i++)
            {
                itemList[i] = null;
            }
            if (itemList != null) itemList.Clear();
            itemList = null;

            currentTBG = null;
            currentMyItem = null;
            currentScrollRect = null;
            if (mydengjiRank != null) mydengjiRank.Destroy();
            mydengjiRank = null;
            if (myzhanliRank != null) myzhanliRank.Destroy();
            myzhanliRank = null;
            if (mychongwuRank != null) mychongwuRank.Destroy();
            mychongwuRank = null;
            if (currentMyRank != null) currentMyRank.Destroy();
            currentMyRank = null;
            if (jingjichangRank != null) jingjichangRank.Destroy();
            jingjichangRank = null;
            if (nvnliansaiRank != null) nvnliansaiRank.Destroy();
            nvnliansaiRank = null;
            if (myxianhuRank!=null) myxianhuRank.Destroy();
            myxianhuRank = null;

            UI = null;
            base.Destroy();
        }

    }


}
