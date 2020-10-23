using System;
using System.Xml.Linq;
using UnityEngine;

namespace init
{
    public class ServerConfig
    {
        public readonly static string ConfigPath = "config/serverconfig.xml";
        
        private static ServerConfig _instance;

        public static ServerConfig instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServerConfig();
                }
                return _instance;
            }
        }
        
        public string serverId { get; private set; }
        public string gameServer { get; private set; }
        public string gamePort { get; private set; }
        
        public string assetsConfigUrl { get; private set; }

        private string mConfigStr = null;

        public void ParseConfig(string configStr)
        {
            mConfigStr = configStr;
            if (string.IsNullOrEmpty(configStr))
            {
                Debug.LogError("#ServerConfig#parseConfigStr#configStr is null or empty!");
                return;
            }
            try
            {
                XElement root = XElement.Parse(configStr);
                serverId = root.Element("server_id").Value;
                gameServer = root.Element("game_server").Value;
                gamePort = root.Element("game_port").Value;
                if (root.Element("assets_config_url") != null)
                {
                    assetsConfigUrl = root.Element("assets_config_url").Value;
                }
            }
            catch (Exception e)
            {
                Debug.LogError("#ServerConfig#parse#Exception!e=" + e.ToString());
            }
            Debug.Log(ServerConfig.instance);
        }
        public override string ToString()
        {
            return mConfigStr;
        }
    }
}