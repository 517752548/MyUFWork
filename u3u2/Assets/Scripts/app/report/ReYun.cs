using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace app.report
{
    public class ReYun
    {

        private static ReYun _ins;

        public static ReYun Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new ReYun();

                }
                return _ins;
            }

        }

        public enum Gender
        {
            reyun_m = 0,   //男
            reyun_f = 1,  //女
            reyun_o = 2,   //其它

        }

        public enum QuestStatus
        {
            reyun_start = 0,   //开始
            reyun_done = 1,    //结束
            reyun_fail = 2,    //失败

        }

        #if !UNITY_EDITOR&&UNITY_IPHONE
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern void reyunInitWithAppId(string appid, string channelID);// 开启数据统计
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern void reyunSetRegisterWithAccountID(string account, int igender, string age, string serverId, string accountType);//注册成功后调用
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern void reyunSetLoginWithAccountID(string accountId, int igender, string age, string serverId, int level);//登陆成功后调用
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern void reyunSetPayment(string transactionId, string paymentType, string currencyType, float currencyAmount, float virtualCoinAmount, string iapName, int iapAmount, int level);//付费分析,记录玩家充值的金额
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern void reyunSetEconomy(string itemName, int itemAmount, float itemTotalPrice, int level);//经济系统，虚拟交易发生之后调用
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern void reyunSetQuest(string questId, int iquestStatus, string questType);//任务分析，用户接受任务或完成任务时调用
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern void reyunSetEvent(string eventName, string key, string value);//自定义事件分析
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern void reyunSetSdkNameAndVer(string sdkName, string sdkVer);//版本信息
        [DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
        private static extern void reyunGetDeviceId(out string deviceId);//平台信息
        #endif

        public void Game_Init(string appid, string channelID)
        {
            #if !UNITY_EDITOR&&UNITY_IPHONE
            reyunInitWithAppId(appid, channelID);
            #endif
        }

        /// <summary>
        /// 玩家的账号登陆服务器
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="genders">性别</param>
        /// <param name="age">年龄</param>
        /// <param name="serverId">登陆的区服</param>
        /// <param name="level">玩家等级</param>
        public void Game_Login(string account, Gender genders, string age, string serverId, int level)
        {
            #if !UNITY_EDITOR&&UNITY_ANDROID
            AndroidJavaClass reyun = new AndroidJavaClass("com.u3u2.main.UnityActivity");
            reyun.CallStatic("ReYun_Game_Login", account, level, serverId);
            #endif
            #if!UNITY_EDITOR&&UNITY_IPHONE
            reyunSetLoginWithAccountID(account, (int)genders, age, serverId, level);
            #endif
        }

        public void Game_Login(string account,string serverId,int level){
            Game_Login(account,Gender.reyun_o,"age",serverId,level);
        }

        /// <summary>
        /// 玩家服务器注册Android平台重载
        /// </summary>
        /// <param name="account">全局应用上下文</param>
        /// <param name="gender">玩家性别</param>
        /// <param name="age">年龄</param>
        /// <param name="serverId">玩家登陆的区服</param>
        /// <param name="accountType">账号的类型</param>
        /*
        public void Game_Register(string account, string accountType, int age, string serverId, Gender gender = ReYun.Gender.reyun_o)
        {
            #if !UNITY_EDITOR&&UNITY_ANDROID
            AndroidJavaClass reyun = new AndroidJavaClass("com.u3u2.main.UnityActivity");
            reyun.CallStatic("ReYun_Game_Register", account, accountType, age, serverId);
            #endif
            #if!UNITY_EDITOR&&UNITY_IPHONE
            reyunSetRegisterWithAccountID(account, (int)gender, age.ToString(), serverId, accountType);
            #endif
        }
        */
        /// <summary>
        /// 玩家的充值数据(Android重载方法)
        /// </summary>
        /// <param name="transactionId">交易的流水号</param>
        /// <param name="paymentType">支付类型</param>
        /// <param name="currencyType">货币类型</param>
        /// <param name="currencyAmount">支付的真实货币的金额</param>
        /// <param name="virtualCoinAmount">通过充值获得的游戏内货币的数量</param>
        /// <param name="iapName">游戏内购买道具的名称</param>
        /// <param name="iapAmount">游戏内购买道具的数量</param>
        /// <param name="level">玩家的等级</param>
        /*
    public void Game_SetPayment(string transactionId, string paymentType, string currencyType, float currencyAmount, float virtualCoinAmount, string iapName, long iapAmount, int level)
    {
        #if !UNITY_EDITOR&&UNITY_ANDROID
                AndroidJavaClass reyun = new AndroidJavaClass("com.u3u2.main.UnityActivity");
                reyun.CallStatic("ReYun_Game_SetPayMent", transactionId, paymentType, currencyType, currencyAmount, virtualCoinAmount,
                iapName, iapAmount, level);
            #endif
        #if!UNITY_EDITOR&&UNITY_IPHONE
                reyunSetPayment(transactionId, paymentType, currencyType, currencyAmount, virtualCoinAmount, iapName, (int)iapAmount, level);
        #endif
    }
    */
        /// <summary>
        /// 游戏内的虚拟交易数据(Android重载方法)
        /// </summary>
        /// <param name="itemName">游戏内虚拟物品的名称/ID</param>
        /// <param name="itemAmount">交易的数量</param>
        /// <param name="itemTotalPrice">交易的总价</param>
        /// <param name="level">设定玩家的等级</param>
        /*
    public void Game_SetEconomy(string itemName, long itemAmount, float itemTotalPrice, int level)
    {
        #if !UNITY_EDITOR&&UNITY_ANDROID
                AndroidJavaClass reyun = new AndroidJavaClass("com.u3u2.main.UnityActivity");
                reyun.CallStatic("ReYun_Game_SetEconomy", itemName, itemAmount, itemTotalPrice, level);
            #endif
        #if!UNITY_EDITOR&&UNITY_IPHONE
                reyunSetEconomy(itemName, (int)itemAmount, itemTotalPrice, level);
            #endif
    }
    */
        /// <summary>
        /// 玩家的任务、副本数据android平台重载方法
        /// </summary>
        /// <param name="questId">当前任务/关卡/副本的编号或名称</param>
        /// <param name="questStatu">当前任务/关卡/副本的状态</param>
        /// <param name="questType">当前任务/关卡/副本的类型</param>
        /// <param name="level">设定玩家等级</param>
        // public void Game_Quest(string questId, string status, string questType, int level)
        // {
        //     if (Application.platform == RuntimePlatform.Android)
        //     {
        //         AndroidJavaClass reyun = new AndroidJavaClass("com.reyun.sdk.ReYun");
        //        reyun.CallStatic("setNQuest", questId, status, questType, level);
        //     }
        // }

        /// <summary>
        /// 统计玩家的自定义事件
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Game_SetEvent(string eventName, string key, string value)
        {
            ClientLog.LogWarning("======ReYun_Game_SetEvent: " + "eventName:" + eventName + ", key:" + key + ", value:" + value + "======");
            #if !UNITY_EDITOR&&UNITY_ANDROID
            AndroidJavaClass reyun = new AndroidJavaClass("com.u3u2.main.UnityActivity");
            reyun.CallStatic("ReYun_Game_SetEvent", eventName, key, value);
            #endif
            #if!UNITY_EDITOR&&UNITY_IPHONE
            reyunSetEvent(eventName, key, value);
            #endif
        }

        public string Game_GetDeviceID(){

            string re = "unknown";
            #if !UNITY_EDITOR&&UNITY_ANDROID
            AndroidJavaClass reyun = new AndroidJavaClass("com.u3u2.main.UnityActivity");
            re = reyun.CallStatic<string>("ReYun_Game_GetDeviceId");
            #endif
            #if!UNITY_EDITOR&&UNITY_IPHONE
            reyunGetDeviceId(out re);
            #endif
            return re;
        }
        public string Game_GetDeviceType(){
            string re = "-1";
            #if !UNITY_EDITOR&&UNITY_ANDROID
            re = "android"; 
            #endif
            #if!UNITY_EDITOR&&UNITY_IPHONE
            re = "iphone"; 
            #endif
            return re;
        }
    }
}