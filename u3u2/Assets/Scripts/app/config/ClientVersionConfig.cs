using System;
using System.Xml.Linq;
using UnityEngine;

namespace app.config
{
    public class ClientVersionConfig
    {
        private static ClientVersionConfig ins;

        public static ClientVersionConfig Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new ClientVersionConfig();
                }
                return ins;
            }
        }
        
        public readonly static string ConfigPath = "config/versionConfig.xml";

        private ClientVersionConfig()
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
        private string mDBMD5;
        private string mBaseVersion;
        private string mAppVersion;
        private string mAssetsVersion;

        //private Dictionary<string, string> mArtsMD5 = new Dictionary<string, string>();

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
                Debug.LogError("#LocalVersionConfig#解析本地版本配置失败，配置字符串为空!");
                return;
            }
            try
            {
                XElement root = XElement.Parse(configStr);
                mDBMD5 = root.Element("db_md5").Value;
                mAppVersion = root.Element("app_version").Value;
                ParseAppVersion();
            }
            catch (Exception e)
            {
                Debug.LogError("#ClientConfig#parse#Exception!e=" + e.ToString());
            }
            Debug.Log(mConfigStr);
        }

        public string GetDBMD5()
        {
            return mDBMD5;
        }

        public string GetAppVersion()
        {
            return mAppVersion;
        }

        public string GetBaseVersion()
        {
            return mBaseVersion;
        }

        public string GetAssetsVersion()
        {
            return mAssetsVersion;
        }
        
        private void ParseAppVersion()
        {
            int idx = mAppVersion.LastIndexOf('.');
            mBaseVersion = mAppVersion.Substring(0, idx);
            mAssetsVersion = mAppVersion.Substring(idx + 1);
        }
        
        public override string ToString()
        {
            return mConfigStr;
        }
    }
}