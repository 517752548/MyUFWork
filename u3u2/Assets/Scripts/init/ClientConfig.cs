using System;
using System.Xml.Linq;
using UnityEngine;

namespace init
{
    public class ClientConfig
    {
        private static ClientConfig ins;

        public static ClientConfig Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new ClientConfig();
                }
                return ins;
            }
        }

        public readonly static string ConfigPath = "config/config.xml";

        private ClientConfig()
        {
        }

        /*
        private string dataeyeAppid;
        public string DataeyeAppid
        {
            get { return dataeyeAppid; }
        }

        private string dataeyeChannel;
        public string DataeyeChannel
        {
            get { return dataeyeChannel; }
        }

        private string dataeyeDebug;
        public bool DataeyeDebug
        {
            get { return dataeyeDebug == "1"; }
        }
        */

        public string serverListUrl { get; private set; }

        //public string reyunAppid { get; private set; }

        //public string reyunChannel { get; private set; }

        //public string appVersion { get; private set; }

        public bool externalScripts { get; private set; }
        public bool externalArts { get; private set; }

        public bool debug { get; private set; }

        public string selectedServerName { get; set; }

        private string mConfigStr = null;

        /*
        private void parseOnUpdate(RMetaEvent et = null)
        {
            string configStr = SourceLoader.Ins.getRequstText(et);
            parseConfigStr(configStr);
        }
        */

        public void ParseConfig(string configStr)
        {
            mConfigStr = configStr;
            if (string.IsNullOrEmpty(configStr))
            {
                Debug.LogError("#ClientConfig#parseConfigStr#configStr is null or empty!");
                return;
            }
            try
            {
                XElement root = XElement.Parse(configStr);
                //XXX 新增属性需要从这里解析
                serverListUrl = root.Element("server_list").Value;
                //reyunAppid = root.Element("reyun_appid").Value;
                //reyunChannel = root.Element("reyun_channel").Value;
                //appVersion = root.Element("app_version").Value;
                XElement externalScriptsElem = root.Element("external_scripts");
                if (externalScriptsElem == null)
                {
#if UNITY_ANDROID
                    externalScripts = true;
#elif UNITY_IOS
                externalScripts = false;
#endif
                }
                else
                {
                    externalScripts = (root.Element("external_scripts").Value == "1");
                }

                XElement externalArtsElem = root.Element("external_arts");
                if (externalArtsElem == null)
                {
                    externalArts = true;
                }
                else
                {
                    externalArts = (root.Element("external_arts").Value == "1");
                }
                debug = root.Element("debug").Value == "1";
            }
            catch (Exception e)
            {
                Debug.LogError("#ClientConfig#parse#Exception!e=" + e.ToString());
            }
            Debug.Log(ClientConfig.Ins);
        }

        public string platform
        {
            get
            {
#if UNITY_ANDROID
                return "android";
#elif UNITY_IOS
            return "ios";
#else
            return "other";
#endif
            }
        }

        public override string ToString()
        {
            return mConfigStr;
        }
    }


}