using app.db;
using app.human;
using app.model;
using app.net;
using UnityEngine;

namespace app.vip
{
    public class VIPView:BaseWnd
    {
        public VipUI UI;
        private PageTurner pageTurner;
        private GameObject libaoEffect;

        public VIPView()
        {
            uiName = "VIPUI";
        }

        public override void initWnd()
        {
            base.initWnd();

            UI = ui.AddComponent<VipUI>();
            UI.init();

            UI.pgbar.LabelType = ProgressBarLabelType.CurrentAndMax;
            
            pageTurner = new PageTurner();
            pageTurner.Init(UI.leftBtn,UI.rightBtn,null);
            pageTurner.Loop = true;
            pageTurner.AutoVisible = false;
            pageTurner.PageChangeHandler = changePage;

            pageTurner.MaxValue = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.VIP_MAX_LEVEL);
            pageTurner.Value = 0;

            UI.closeBtn.SetClickCallBack(closePanel);
            UI.chongzhiBtn.SetClickCallBack(openchongzhi);
            EventTriggerListener.Get(UI.libaoBtn).onClick =(clickLingquLibao);
        }

        private void updateVipInfo(RMetaEvent e=null)
        {
            if (!isShown)
            {
                return;
            }
            int myviplevel = PlayerModel.Ins.GetMyVipLevel();

            UI.curVipLevel.text = "V " + myviplevel; 
            
            if (PlayerModel.Ins.IsMyVipMax())
            {
                UI.pgbar.MaxValue = 100;
                UI.pgbar.Value = 100;
                UI.pgbar.label.text = "已达到最大VIP等级!";

                UI.nextVipLevel.text = "";
                UI.zaichongMoney.text = "";
                UI.zaichongLabel.text = "";
            }
            else
            {
                UI.pgbar.MaxValue = VipUpgradeTemplateDB.Instance.GetCurVIPUpgradeNeedChargeTotal(myviplevel);
                UI.pgbar.Value = PlayerModel.Ins.GetMyVipEXP();

                UI.nextVipLevel.text = "V " + (myviplevel+1);
                UI.zaichongMoney.text = (VipUpgradeTemplateDB.Instance.GetCurVIPUpgradeNeedChargeTotal(myviplevel) - PlayerModel.Ins.GetMyVipEXP()).ToString();
                UI.zaichongLabel.text = "再充值               金子，即可成为VIP";
            }
            if (myviplevel == 0)
            {
                UI.tequanTitle.text = "VIP " + 1 + "特权";
                changePage(0);
                pageTurner.Value = 0;
            }
            else
            {
                UI.tequanTitle.text = "VIP " + (myviplevel) + "特权";
                changePage(myviplevel-1);
                pageTurner.Value = (myviplevel-1);
            }

            if (PlayerModel.Ins.MyVipInfo.getCanGetDayReward()==1)
            {
                //今日奖励可领取
                UI.libaoBtn.gameObject.SetActive(true);
                if (libaoEffect == null)
                {
                    GameObject go = SourceManager.Ins.GetAsset<GameObject>(PathUtil.Ins.uiEffectsPath, "libaoTexiao");
                    libaoEffect = GameObject.Instantiate(go);
                    libaoEffect.gameObject.SetActive(true);
                    libaoEffect.transform.SetParent(UI.transform);
                    libaoEffect.transform.localPosition = new Vector3(-235, -110, -10);
                    libaoEffect.transform.localScale = Vector3.one;
                    GameObjectUtil.SetLayer(libaoEffect.gameObject, UI.gameObject.layer);
                }
                else
                {
                     libaoEffect.SetActive(true);
                }
            }
            else
            {
                UI.libaoBtn.gameObject.SetActive(false);
                if (libaoEffect != null)
                {
                    libaoEffect.SetActive(false);
                }
            }
            
        }

        private void changePage(int page)
        {
            page = page + 1;
            ClientLog.Log("vip :" + page);
            UI.tequanTitle.text = "VIP " + page + "特权";

            string shangyijiDesc = "";
            if (page > 1)
            {
                shangyijiDesc = "包含VIP" + (page - 1) + "的所有特权\n";
            }
            string leijichongDesc = "";
            if (page > 0)
            {
                leijichongDesc = "累计充值" + VipUpgradeTemplateDB.Instance.GetCurVIPUpgradeNeedChargeTotal(page-1)
                    + "金子可成为VIP" + page + "\n";
            }
            UI.tequanDesc.text = shangyijiDesc + leijichongDesc + VipConfigTemplateDB.Instance.GetVipTeQuanTextByLevel((page));
            UI.tequanDesc.transform.localPosition = new Vector3(UI.tequanDesc.transform.localPosition.x,0,0);
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            app.main.GameClient.ins.OnBigWndShown();
            Human.Instance.PlayerModel.addChangeEvent(PlayerModel.UPDATE_VIP_INFO, updateVipInfo);
            updateVipInfo();
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            app.main.GameClient.ins.OnBigWndHidden();
            if (libaoEffect != null)
            {
                libaoEffect.SetActive(false);
            }
            Human.Instance.PlayerModel.removeChangeEvent(PlayerModel.UPDATE_VIP_INFO, updateVipInfo);
        }

        private void closePanel()
        {
            hide();
        }

        private void openchongzhi()
        {
            LinkParse.Ins.linkToFunc(FunctionIdDef.CHONGZHI);
        }

        private void clickLingquLibao(GameObject go)
        {
            HumanCGHandler.sendCGVipGetDayReward();
            ClientLog.Log("clickLingquLibao");
        }

        public override void Destroy()
        {
            GameObject.DestroyImmediate(libaoEffect);
            if (UI!=null)
            {
                UI.closeBtn.ClearClickCallBack();
                UI.chongzhiBtn.ClearClickCallBack();
                EventTriggerListener.Get(UI.libaoBtn).onClick = null;
            }
            base.Destroy();

        }

    }
}
