using System;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace init
{
    public class LocalVersionConfig
    {
        private static LocalVersionConfig ins;

        public static LocalVersionConfig Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new LocalVersionConfig();
                }
                return ins;
            }
        }

        private LocalVersionConfig()
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
            Debug.Log(LocalVersionConfig.Ins);
        }

        public string GetDBMD5()
        {
            return mDBMD5;
        }

        public void SetDBMD5(string value)
        {
            mDBMD5 = value;
            UpdateLocalAssetsVersionConfig();
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

        public void SetAppVersion(string v)
        {
            mAppVersion = v;
            ParseAppVersion();
            UpdateLocalAssetsVersionConfig();
        }
        
        private void ParseAppVersion()
        {
            string[] res = Util.ParseAppVersion(mAppVersion);
            mBaseVersion = res[0];
            mAssetsVersion = res[1];
        }

        private void UpdateLocalAssetsVersionConfig()
        {
            Debug.LogWarning("UpdateLocalAssetsVersionConfig");
            try
            {
                if (!Directory.Exists(VerifyAssets.ins.extFilesRoot + "/Assets"))
                {
                    Directory.CreateDirectory(VerifyAssets.ins.extFilesRoot + "/Assets");
                }

                if (!Directory.Exists(VerifyAssets.ins.extFilesRoot + "/Assets/config"))
                {
                    Directory.CreateDirectory(VerifyAssets.ins.extFilesRoot + "/Assets/config");
                }

                StreamWriter ws = File.CreateText(VerifyAssets.ins.extFilesRoot + "/Assets/config/versionConfig.xml");
                ws.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                ws.WriteLine("<config>");
                ws.WriteLine("    <db_md5>" + mDBMD5 + "</db_md5>");
                ws.WriteLine("    <app_version>" + mAppVersion + "</app_version>");
                ws.WriteLine("</config>");

                ws.Flush();
                ws.Close();
                ws.Dispose();

                Debug.Log("UpdateLocalAssetsVersionConfig OK! " + VerifyAssets.ins.extFilesRoot + "/Assets/config/assetsMd5Config.xml");
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }


        public override string ToString()
        {
            return mConfigStr;
        }
    }
}