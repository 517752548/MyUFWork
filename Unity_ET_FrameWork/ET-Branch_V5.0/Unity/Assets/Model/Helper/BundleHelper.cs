using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ETModel
{
    public static class BundleHelper
    {
        public static async ETTask DownloadBundle()
        {
            List<string> downloadlist = await Addressables.CheckForCatalogUpdates().Task;
            if (downloadlist.Count > 0)
                await Addressables.DownloadDependenciesAsync(downloadlist).Task;
        }

        public static string GetBundleMD5(VersionConfig streamingVersionConfig, string bundleName)
        {
            string path = Path.Combine(PathHelper.AppHotfixResPath, bundleName);
            if (File.Exists(path))
            {
                return MD5Helper.FileMD5(path);
            }

            if (streamingVersionConfig.FileInfoDict.ContainsKey(bundleName))
            {
                return streamingVersionConfig.FileInfoDict[bundleName].MD5;
            }

            return "";
        }
    }
}