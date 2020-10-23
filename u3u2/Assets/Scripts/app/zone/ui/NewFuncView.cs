using UnityEngine;
using UnityEngine.UI;

namespace app.zone
{
    public class NewFuncView:BaseWnd
    {
        private GameUUImageIgnoreRaycast functionIcon;
        private RawImage rawIcon;
        private Text funcnametext;

        private RTimer waitingCloseTimer;
        private int waitingTimems = 2000;

        public NewFuncView()
        {
            isShowBgMask = true;
            uiName = "NewFuncUI";
        }

        public override void initWnd()
        {
            base.initWnd();

            functionIcon = ui.transform.Find("funcIcon").GetComponent<GameUUImageIgnoreRaycast>();
            rawIcon = ui.transform.Find("rawImage").GetComponent<RawImage>();
            functionIcon.gameObject.SetActive(false);
            rawIcon.gameObject.SetActive(false);
            funcnametext = ui.transform.Find("funcnametext").GetComponent<Text>();
            funcnametext.gameObject.SetActive(false);
        }

        protected override void clickSpaceArea(GameObject go)
        {
            return;
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            if (ZoneUI.ins.addNewFuncId!=0)
            {
                string assetname=GetMainUIBtnNameByFuncId(ZoneUI.ins.addNewFuncId);
                
                Object obj = PathUtil.Ins.GetAssetFromUIByName("mainUIPanel", "mainui", assetname);
                Sprite sp = null;
                Texture2D t2 = null;
                if ((obj as Sprite)!=null)
                {
                    sp = obj as Sprite;
                }
                if ((obj as Texture2D) != null)
                {
                    t2 = obj as Texture2D;
                }
                if (sp != null)
                {
                    functionIcon.sprite = sp;
                    functionIcon.gameObject.SetActive(true);
                    functionIcon.SetNativeSize();
                    funcnametext.gameObject.SetActive(false);

                    rawIcon.gameObject.SetActive(false);
                }else if (t2!=null)
                {
                    functionIcon.gameObject.SetActive(false);
                    funcnametext.gameObject.SetActive(false);

                    rawIcon.gameObject.SetActive(true);
                    rawIcon.texture = t2;
                    rawIcon.SetNativeSize();
                }
                else
                {
                    functionIcon.gameObject.SetActive(false);
                    rawIcon.gameObject.SetActive(false);
                    funcnametext.gameObject.SetActive(true);
                    funcnametext.text = FunctionIdDef.GetFuncNameById(ZoneUI.ins.addNewFuncId);
                }
            }
            if (waitingCloseTimer==null)
            {
                waitingCloseTimer = TimerManager.Ins.createTimer(1000, waitingTimems, null, timerend);
                waitingCloseTimer.start();
            }
            else
            {
                waitingCloseTimer.Reset(1000,waitingTimems);
                waitingCloseTimer.Restart();
            }
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            //移除引用
            if (functionIcon != null && functionIcon.isActiveAndEnabled&&functionIcon.sprite != null)
            {
                string referrencepath=PathUtil.Ins.GetFinalPath(PathUtil.Ins.GetUIPath("mainUIPanel"));
                SourceManager.Ins.removeReference(referrencepath);
            }
            if (waitingCloseTimer != null)
            {
                waitingCloseTimer.stop();
            }

            ZoneUI.ins.MoveNewFuncBtn();
        }

        private void timerend(RTimer r)
        {
            hide();
        }

        /// <summary>
        /// 根据功能id，获得 功能icon 的名字（功能icon在 unityart项目的ui2/textures/mainui/目录下）
        /// </summary>
        /// <param name="functionid"></param>
        /// <returns></returns>
        public string GetMainUIBtnNameByFuncId(int functionid)
        {
            string str = null;
            switch (functionid)
            {
                //case FunctionIdDef.RENWU: str = "lvye"; break;//1;//任务
                //case FunctionIdDef.DUIWU: str = "lvye"; break;//2;//队伍
                case FunctionIdDef.HUODONG: str = "huodong"; break;//4;//活动
                case FunctionIdDef.JINGJICHANG: str = "jingjichang"; break;//5;//竞技场
                case FunctionIdDef.JIUGUAN: str = "jiuguan"; break;//6;//酒馆
                case FunctionIdDef.KEJU: str = "keju"; break;//7;//朝云科举
                case FunctionIdDef.XITONG: str = "xitongx"; break;//8;//系统
                //case FunctionIdDef.PETSTORE: str = "lvye"; break;//9;//宠物商店
                //case FunctionIdDef.SHANGHUI: str = "lvye"; break;//10;//商会
                case FunctionIdDef.PAIMAIHANG: str = "shangchengx"; break;//11;//拍卖行
                //case FunctionIdDef.CHONGZHI: str = "shangchengx"; break;//12;//充值
                //case FunctionIdDef.WUXING: str = "lvye"; break;//13;//悟性
                case FunctionIdDef.BEIBAO: str = "beibaox"; break;//14;//背包
                case FunctionIdDef.XINFAJINENG: str = "jinengx"; break;//15;//心法技能
                case FunctionIdDef.BANGPAI: str = "bangpaix"; break;//16;//帮派
                //case FunctionIdDef.HUOBAN: str = "huobanx"; break;//17;//伙伴
                //case FunctionIdDef.ZHENXING: str = "huobanx"; break;//18;//阵型
                case FunctionIdDef.PAIHANG: str = "paihangx"; break;//19;//排行
                case FunctionIdDef.DAZAO: str = "dazao"; break;//20;//打造
                case FunctionIdDef.SHENGXING: str = "shengxing"; break;//21;//升星
                //case FunctionIdDef.XIANGQIAN: str = "dazao"; break;//22;//宝石镶嵌
                //case FunctionIdDef.HECHENG: str = "dazao"; break;//23;//宝石合成
                case FunctionIdDef.QIANGHUA: str = "qianghua"; break;//24;//强化
                //case FunctionIdDef.FENJIE: str = "qianghua"; break;//25;//分解
                //case FunctionIdDef.CHONGZHU: str = "qianghua"; break;//26;//重铸
                //case FunctionIdDef.XILIAN: str = "qianghua"; break;//27;//洗炼
                //case FunctionIdDef.GUANZHU: str = "qianghua"; break;//28;//灌注
                //case FunctionIdDef.CHUANCHENG: str = "qianghua"; break;//29;//传承
                //case FunctionIdDef.QIANDAO: str = "qiandao"; break;//31;//每日签到
                //case FunctionIdDef.DENGLUJIANGLI: str = "huodong"; break;//32;//登陆奖励
                //case FunctionIdDef.ZAIXIANJIANGLI: str = "huodong"; break;//33;//在线奖励
                //case FunctionIdDef.YOUJIAN: str = "friend"; break;//34;//邮件
                case FunctionIdDef.HAOYOU: str = "friend"; break;//35;//好友
                //case FunctionIdDef.CHENGJIU: str = "chengjiux"; break;//36;//成就
                case FunctionIdDef.TISHENG: str = "tisheng"; break;//37;//提升
                //case FunctionIdDef.GMBUCHANG: str = "lvye"; break;//38;//GM补偿
                //case FunctionIdDef.SHENMISHOP: str = "lvye"; break;//39;//神秘商店
                //case FunctionIdDef.JINGCAIHUODONG: str = "huodong"; break;//40;//精彩活动
                case FunctionIdDef.VIP: str = "VIP"; break;//41;//VIP
                //case FunctionIdDef.JINJUANTAOCAN: str = "lvye"; break;//42;//金卷套餐
                //case FunctionIdDef.ZAIXIANLIBAO: str = "lvye"; break;//43;//特殊在线礼包
                case FunctionIdDef.QICHONG: str = "qichong"; break;//44;//骑宠
                //case FunctionIdDef.CAIKUANG: str = "huodong"; break;//45;//采矿
                case FunctionIdDef.CHUBAOANLIANG: str = "chubaoanliang"; break;//46;//除暴安良
                case FunctionIdDef.LVYEXIANZONG: str = "lvye"; break;//47;//绿野仙踪
                case FunctionIdDef.BAOTU: str = "baoturenwu"; break;//48;//宝图任务
                //case FunctionIdDef.BPJS: str = "huodong"; break;//50;//帮派竞赛
                //case FunctionIdDef.YUNLIANG: str = "huodong"; break;//51;//护送粮草
                //case FunctionIdDef.SHITU: str = "lvye"; break;//52;//师徒
                //case FunctionIdDef.HUNYIN: str = "lvye"; break;//53;//结婚
                //case FunctionIdDef.NVSN: str = "huodong"; break;//54;//NVN联赛
                //case FunctionIdDef.CHONGWUDAO: str = "huodong"; break;//55;//宠物岛
                //case FunctionIdDef.CHIBANG: str = "lvye"; break;//56;//翅膀
                //case FunctionIdDef.CORPSTASK: str = "bangpaix"; break;//57;//帮派任务
                //case FunctionIdDef.CORPBUILD: str = "bangpaix"; break;//58;//帮派建设
                //case FunctionIdDef.CORPBENIFIT: str = "bangpaix"; break;//59;//帮派福利
                case FunctionIdDef.TOWER: str = "tongtianta"; break;//61;//通天塔
                case FunctionIdDef.NEWGUAJI: str = "guaijix"; break;//80;//野外挂机
                default:
                    str = null;
                    break;
            }
            return str;
        }

        public override void Destroy()
        {
            if (waitingCloseTimer != null)
            {
                waitingCloseTimer.stop();
            }
            waitingCloseTimer = null;
            
            base.Destroy();
        }
        
    }
}
