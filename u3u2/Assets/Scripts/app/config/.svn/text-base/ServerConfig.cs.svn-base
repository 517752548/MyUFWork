using System;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace app.config
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
        public string assetsDownloadUrlBase { get; private set; }
        public string appVersion { get; private set; }
        public string canPay { get; private set; }
        /// <summary>
        /// 当前是否通过审核
        /// </summary>
        public bool IsPassedCheck { get; private set; }
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
                canPay = root.Element("can_pay").Value;

                IsPassedCheck = false;
                if (root.Element("IsPassedCheck")!=null)
                {
                    if(int.Parse(root.Element("IsPassedCheck").Value)==1)
                    {
                        IsPassedCheck = true;
                    }
                }
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

            //serverId = GetSelectServerId();
        }

        /*

        /// <summary>
        /// 获得 选择的服务器的serverid
        /// </summary>
        /// <returns></returns>
        private string GetSelectServerId()
        {
            if (File.Exists(GetPathViaPlatform(PathUtil.Ins.extFilesRoot + "/defaultServer.xml")))
            {
                string str = File.ReadAllText(GetPathViaPlatform(PathUtil.Ins.extFilesRoot + "/defaultServer.xml"));
                XElement root = XElement.Parse(str);
                string serverid = root.Element("url").Attribute("serverid").Value;
                return serverid;
            }
            return "";
        }

        private string GetPathViaPlatform(string path)
        {
            string pre = "file://";
            if (path.IndexOf("file://") == 0)
            {
                path = path.Substring(7);
                return pre + path.Replace('/', System.IO.Path.DirectorySeparatorChar);
            }
            return path.Replace('/', System.IO.Path.DirectorySeparatorChar);
        }
        */

        public override string ToString()
        {
            return mConfigStr;
        }
    }
}