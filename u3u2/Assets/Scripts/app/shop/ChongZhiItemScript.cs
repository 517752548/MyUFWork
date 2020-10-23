using System.Linq;
using app.config;
using app.db;
using app.model;
using app.net;
using UnityEngine;

namespace app.shop
{
    public class ChongZhiItemScript
    {
        private ChongZhiItem UI;
        private ChargeTemplate chargetTPL;
        private string tuijianSign = "tuijian";
        private string shouchongSign = "shouchong";

        public ChongZhiItemScript(ChongZhiItem ui)
        {
            UI = ui;
            UI.btn.SetClickCallBack(clickCharge);
        }

        public void setData(ChargeTemplate tpl)
        {
            chargetTPL = tpl;
            bool hasShouChong = PlayerModel.Ins.ChargetRecord!=null?PlayerModel.Ins.ChargetRecord.getTplId().Contains(chargetTPL.Id):false;
            UI.jinziText.text = chargetTPL.bond + CurrencyTypeDef.GetCurrencyName(CurrencyTypeDef.BOND);
            UI.jiageText.text = "￥ " + chargetTPL.rmb;
            if (!hasShouChong)
            {//首冲
                if (chargetTPL.firstSysBond > 0)
                {
                    Sprite t = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, shouchongSign);
                    //首冲额外赠送金子
                    UI.biaoqian.sprite = t;
                    UI.biaoqian.SetNativeSize();
                    UI.biaoqian.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);

                    UI.zengsongImage.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);
                    UI.zengsongText.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);
                    UI.zengsongicon.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);
                    UI.zengText.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);

                    UI.zengsongText.text = chargetTPL.firstSysBond + "";
                }
                else if (chargetTPL.giftSysBond > 0)
                {
                    UI.biaoqian.sprite = null;
                    UI.biaoqian.gameObject.SetActive(false);

                    UI.zengsongImage.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);
                    UI.zengsongText.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);
                    UI.zengsongicon.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);
                    UI.zengText.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);

                    UI.zengsongText.text = chargetTPL.giftSysBond + "";
                }
                else
                {
                    UI.biaoqian.sprite = null;
                    UI.biaoqian.gameObject.SetActive(false);

                    UI.zengsongImage.gameObject.SetActive(false);
                    UI.zengsongText.gameObject.SetActive(false);
                    UI.zengsongicon.gameObject.SetActive(false);
                    UI.zengText.gameObject.SetActive(false);
                }
            }
            else
            {//非首冲状态
                if (chargetTPL.firstSysBond > 0)
                {
                    Sprite t = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, tuijianSign);
                    //赠送金子
                    UI.biaoqian.sprite = t;
                    UI.biaoqian.SetNativeSize();
                    UI.biaoqian.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);
                }
                else
                {
                    UI.biaoqian.sprite = null;
                    UI.biaoqian.gameObject.SetActive(false);
                }
                if (chargetTPL.giftSysBond > 0)
                {
                    UI.zengsongImage.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);
                    UI.zengsongText.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);
                    UI.zengsongicon.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);
                    UI.zengText.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);

                    UI.zengsongText.text = chargetTPL.giftSysBond + "";
                }
                else
                {
                    UI.zengsongImage.gameObject.SetActive(false);
                    UI.zengsongText.gameObject.SetActive(false);
                    UI.zengsongicon.gameObject.SetActive(false);
                    UI.zengText.gameObject.SetActive(false);
                }
            }
        }

        private void clickCharge()
        {
            if (chargetTPL != null)
            {
                //HumanCGHandler.sendCGChargeGmTest(chargetTPL.Id);
                app.main.SDKManager.ins.Pay(chargetTPL);
            }
        }

    }
}
