using System;
using System.Xml.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace init
{
    public class ServerVersionConfig
    {
        private static ServerVersionConfig ins;

        public static ServerVersionConfig Ins
        {
            get
            {
                if (ins == null)
                {
                    ins = new ServerVersionConfig();
                }
                return ins;
            }
        }

        private ServerVersionConfig()
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
        public string appVersion { get; private set; }
        public string baseVersion { get; private set; }
        public string assetsVersion { get; private set; }
        public string assetsDownloadUrlBase { get; private set; }
        public string dbUrl { get; private set; }
        public string dbMD5 { get; private set; }
		public string forceupdateurl { get; set; }
		public bool needforceupdate{ get; set; }

        private Dictionary<string, List<string[]>> mAssetsVersionList = new Dictionary<string, List<string[]>>();

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
			needforceupdate = false;
            mConfigStr = configStr;
            if (string.IsNullOrEmpty(configStr))
            {
                Debug.LogError("#ClientConfig#parseConfigStr#configStr is null or empty!");
                return;
            }
            try
            {
                mAssetsVersionList.Clear();
                XElement root = XElement.Parse(configStr);

                appVersion = root.Element("app_version").Value;
                string[] versionArr = Util.ParseAppVersion(appVersion);
                baseVersion = versionArr[0];
                assetsVersion = versionArr[1];
                assetsDownloadUrlBase = root.Element("assets_download_url_base").Value;
                dbUrl = root.Element("db_url").Attribute("url").Value;
                dbMD5 = root.Element("db_url").Attribute("md5").Value;
                IEnumerable<XElement> elems = root.Element("arts").Elements("art");
                foreach (XElement elem in elems)
                {
                    string ver = elem.Attribute("version").Value;
                    string name = elem.Attribute("name").Value;
                    string md5 = elem.Attribute("md5").Value;
                    string size = elem.Attribute("size").Value;

					if( elem.Attribute("needupdate")!= null && !string.IsNullOrEmpty(elem.Attribute("needupdate").Value) && elem.Attribute("needupdate").Value=="1"){
						needforceupdate = true;
					}

                    if (!mAssetsVersionList.ContainsKey(baseVersion))
                    {
                        mAssetsVersionList.Add(baseVersion, new List<string[]>());
                    }
                    mAssetsVersionList[baseVersion].Add(new string[] { ver, name, md5, size });
                }
				if(needforceupdate){
					forceupdateurl = root.Element("fupdate").Attribute("url").Value;
				}

            }
            catch (Exception e)
            {
                Debug.LogError("#ClientConfig#parse#Exception!e=" + e.ToString());
            }
            Debug.Log(ServerVersionConfig.Ins);
        }

        public List<string[]> GetAssetsDownloadList(string baseVersion)
        {
            if (mAssetsVersionList.ContainsKey(baseVersion))
            {
                return mAssetsVersionList[baseVersion];
            }
            return new List<string[]>();
        }

        public string GetAssetsZipMD5(string appVersion)
        {
            string[] versionArr = Util.ParseAppVersion(appVersion);
            baseVersion = versionArr[0];
            assetsVersion = versionArr[1];
            List<string[]> list = mAssetsVersionList[baseVersion];
            int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                if (list[i][0] == appVersion)
                {
                    return list[i][2];
                }
            }
            return null;
        }

        public override string ToString()
        {
            return mConfigStr;
        }
    }
}