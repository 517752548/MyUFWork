using System;

namespace app.report
{
    public class DataEye
    {
        private static DataEye _ins;

        public static DataEye Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new DataEye();

                }
                return _ins;
            }
        }
            
        public void Game_Init(string appid, string channelID)
        {
            DCAgent.setReportMode(DCReportMode.DC_AFTER_LOGIN);
            DCAgent.getInstance().initWithAppIdAndChannelId("", "");
        }

        public void Game_Login(string account,string serverId){
            DCAccount.login(account, serverId);
        }

        public void Game_Logout()
        {
            DCAccount.logout();
        }

        public void Game_SetEvent(string eventName, string key, string value)
        {
            System.Collections.Generic.Dictionary<string, string> dic = new System.Collections.Generic.Dictionary<string, string>();
            dic.Add(key, value);
            DCEvent.onEvent(eventName, dic);
        }

        public void Game_SetEventBeforeLogin(string eventName, string key, string value)
        {
            System.Collections.Generic.Dictionary<string, string> dic = new System.Collections.Generic.Dictionary<string, string>();
            dic.Add(key, value);
            DCEvent.onEventBeforeLogin(eventName, dic, (long)UnityEngine.Time.time);
        }

        public void Game_MainLineQuestAccept(int questId)
        {
            DCTask.begin(questId.ToString(), DCTaskType.DC_MainLine);
        }
    }
}

