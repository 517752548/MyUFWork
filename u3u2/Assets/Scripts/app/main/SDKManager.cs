using UnityEngine;
using System.Collections.Generic;
using app.net;
using app.state;
using app.model;
using app.zone;
using app.human;
using app.config;
using app.db;

namespace app.main
{
    public class SDKManager
    {
        private ChargeTemplate mChargeTpl = null;
        private static SDKManager mIns = null;

        public static SDKManager ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new SDKManager();
                }
                return mIns;
            }
        }

        public SDKManager()
        {
            GameSimpleEventCore.ins.AddListener("show_login_view", ShowLoginView);
            GameSimpleEventCore.ins.AddListener("bubble_sys_msg", BubbleSysMsg);
            GameSimpleEventCore.ins.AddListener("send_cg_ios_android_charge", SendCGIosAndroidCharge);
            // GameSimpleEventCore.ins.AddListener("switch_account", SendCGIosAndroidCharge);
            GameSimpleEventCore.ins.AddListener("connect_server", ConnectServer);
            GameSimpleEventCore.ins.AddListener("send_cg_player_login", SendCGPlayerLogin);
            GameSimpleEventCore.ins.AddListener("send_cg_player_cookie_login", sendCGPlayerCookieLogin);
            GameSimpleEventCore.ins.AddListener("send_cg_player_tocken_login", sendCGPlayerTockenLogin);
            GameSimpleEventCore.ins.AddListener("received_iapreceipt", SendCGIoschargeCheck);
			GameSimpleEventCore.ins.AddListener("switch_account", SwitchAccount);
        }

        public void ShowLogin()
        {
            GameSimpleEventCore.ins.DispatchEvent("show_login", null);
        }

        public void DoLogin()
        {
            GameSimpleEventCore.ins.DispatchEvent("do_login", null);
        }

        public void ReDoLogin()
        {
            GameSimpleEventCore.ins.DispatchEvent("redo_login", null);
        }

        public void Pay(ChargeTemplate chargeTpl)
        {
            mChargeTpl = chargeTpl;
            PlayerCGHandler.sendCGChargeGenOrderid(PlatForm.Instance.GetAppID(), "{\"product_id\":" + mChargeTpl.Id.ToString() + ", \"product_price\":" + (mChargeTpl.rmb * 100).ToString() + "}");
        }

        public void GotOrderId(string orderId)
        {
            Dictionary<string, string> productInfo = new Dictionary<string, string>();
            productInfo["Product_Id"] = mChargeTpl.Id.ToString();//配置表
            //productInfo["Product_Name"] = "gold";
            productInfo["Product_Price"] = (mChargeTpl.rmb * 100).ToString();//金额到分(配置表col2*100)
            //productInfo["Product_Count"] = "1";
            //productInfo["Coin_Name"] = "元宝";
            //productInfo["Coin_Rate"] = "1";
            productInfo["Role_Id"] = Human.Instance.Pid;
            productInfo["Role_Name"] = Human.Instance.getName();
            productInfo["Role_Grade"] = Human.Instance.getLevel().ToString();
            //productInfo["Role_Balance"] = "1";
            productInfo["Server_Id"] = ServerConfig.instance.serverId;
            productInfo["Order_Id"] = orderId;
            //productInfo["EXT"] = "1";
            GameSimpleEventCore.ins.DispatchEvent("pay", productInfo);
        }

        private void ShowLoginView(object data)
        {
            WndManager.open(GlobalConstDefine.LoginView_Name);
        }

        private void BubbleSysMsg(object data)
        {
            ZoneBubbleManager.ins.BubbleSysMsg(data.ToString());
        }

        private void SendCGIosAndroidCharge(object data)
        {
            PlayerCGHandler.sendCGIosAndroidCharge();
        }

        private void SendCGIoschargeCheck(object data)
        {
            PlayerCGHandler.sendCGIoschargeCheck(data.ToString());
        }


        private void SwitchAccount(object data)
        {
			Debug.Log ("switch_account2");
			StateManager.Ins.SwitchAccount();
        }

        private void ConnectServer(object data)
        {
            LoginModel.Ins.connectServer();
        }

        private void SendCGPlayerLogin(object data)
        {
            PlayerCGHandler.sendCGPlayerLogin(LoginModel.Ins.LoginName, LoginModel.Ins.LoginPwd, LoginModel.Ins.Source);
        }

        private void sendCGPlayerCookieLogin(object data)
        {
            string[] arr = (string[])data;
            PlayerCGHandler.sendCGPlayerCookieLogin(arr[0], arr[1]);
        }

        private void sendCGPlayerTockenLogin(object data)
        {
            if (data == null)
            {
                PlayerCGHandler.sendCGPlayerTokenLogin(PlayerGCHandler.pid, PlayerGCHandler.id, PlayerGCHandler.token, LoginModel.Ins.Source);
            }
            else
            {
                PlayerCGHandler.sendCGPlayerTokenLogin(PlayerGCHandler.pid, PlayerGCHandler.id, PlayerGCHandler.token, (string)data);
            }
        }
        
    }
    
}