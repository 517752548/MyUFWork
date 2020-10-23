using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace app.report
{
    public class DataReport
    {
		#if !UNITY_EDITOR&&UNITY_IPHONE
		[DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
		private static extern void TalkDataLogin(string account);//login
		[DllImport("__Internal", CallingConvention=CallingConvention.Cdecl)]
		private static extern void TalkDataRegister(string account);//register

		#endif
        private static DataReport _ins;

        public static DataReport Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new DataReport();

                }
                return _ins;
            }
        }

        public void Game_Init()
        {
            ReYun.Instance.Game_Init("", "");
            DataEye.Instance.Game_Init("", "");
        }

        public void Game_Login(string account,string serverId,int level)
        {
            ReYun.Instance.Game_Login(account,serverId,level);
            DataEye.Instance.Game_Login(account, serverId);
			#if !UNITY_EDITOR&&UNITY_IPHONE
				TalkDataLogin(account);
			#endif
        }
		public void Game_Regiester(string name){
			#if !UNITY_EDITOR&&UNITY_IPHONE
				TalkDataRegister(name);
			#endif
		}

        public void Game_Logout()
        {
            DataEye.Instance.Game_Logout();
        }

        public void Game_SetEvent(string eventName, string key, string value)
        {
            ReYun.Instance.Game_SetEvent(eventName, key, value);
            DataEye.Instance.Game_SetEvent(eventName, key, value);
        }

        public void Game_SetEventBeforeLogin(string eventName, string key, string value)
        {
            DataEye.Instance.Game_SetEventBeforeLogin(eventName, key, value);
        }

        public void Game_MainLineQuestAccept(int questId)
        {
            DataEye.Instance.Game_MainLineQuestAccept(questId);
        }

        public void ReportPlayerData(long id,string roleName, string roleLevel, string zoneId, string zoneName,long createTime)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
			data.Add ("roleId", id+"");
            data.Add("roleName", roleName);
            data.Add("roleLevel", roleLevel);
            data.Add("zoneId", zoneId);
            data.Add("zoneName", zoneName);
			data.Add ("createTime", createTime+"");
            GameSimpleEventCore.ins.DispatchEvent ("report_player_data", data);
        }
    }
}

