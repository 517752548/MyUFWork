using UnityEngine;

public class UpdateWordBankManager : MonoBehaviour
{
    /// <summary>
    /// 检查是否需要更新词库
    /// </summary>
    //public void CheckWordBankNeedUpdate()
    //{
    //    string currentversion = PlatformUtil.GetVersionCode().ToString();
    //    bool needupdate = SubWordLibCanUpdate(currentversion);
    //    if (needupdate)
    //    {
    //        StartCoroutine(LaunchUpdater());
    //    }
    //}

    //private bool SubWordLibCanUpdate(string currentversion)
    //{
    //    try
    //    {
    //        string config = "";
    //        if (Language.settings.defaultLangCode == "EN")
    //        {
    //            config = DataManager.SourceData.FileInit.ENWordABCLibConfig;
    //        }
    //        else if (Language.settings.defaultLangCode == "DE")
    //        {
    //            config = DataManager.SourceData.FileInit.DEWordABCLibConfig;
    //        }
    //        else if (Language.settings.defaultLangCode == "FR")
    //        {
    //            config = DataManager.SourceData.FileInit.FRWordABCLibConfig;
    //        }
    //        BetaFramework.LoggerHelper.Log("词库更新配置:" + config);
    //        DataManager.ProcessData.ABLoadProgress = config;
    //        string[] builds = config.Split(';');
    //        for (int i = 0; i < builds.Length; i++)
    //        {
    //            if (builds[i].Length > 2)
    //            {
    //                string[] buildsAndwordversion = builds[i].Split('|');
    //                if (buildsAndwordversion[0] == currentversion)
    //                {
    //                    if (buildsAndwordversion.Length >= 2)
    //                    {
    //                        return GetCurrentLanguageNeedUpdateNewWordLib(buildsAndwordversion[1]);
    //                    }

    //                }
    //            }
    //        }
    //        if (ConsoleManager._instacne.UseTestURL)
    //        {
    //            Toast.instance.ShowMessage(AssetBundleManager.Instance.Version + "不需要更新" + currentversion + "==>" + config);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        BetaFramework.LoggerHelper.Error(ex.StackTrace);
    //        ReportDataManager.PostUseExceptoin_new("SubWordLibCanUpdate", ex.StackTrace);
    //        // Toast.instance.ShowMessage("解析出错---!");
    //        return false;

    //    }
    //    return false;
    //}

    ///// <summary>
    ///// 判断当前词库group是否需要更新
    ///// </summary>
    ///// <param name="configs"></param>
    ///// <returns></returns>
    //bool GetCurrentLanguageNeedUpdateNewWordLib(string configs)
    //{
    //    string[] config = configs.Split(',');
    //    for (int i = 0; i < config.Length; i++)
    //    {
    //        if (config[i].Length > 2)
    //        {
    //            string[] wordsGroupConfig = config[i].Split(':');
    //            if (wordsGroupConfig.Length > 1)
    //            {
    //                if (wordsGroupConfig[0] == DataManager.PlayerData.PlayerWordGroup)
    //                {
    //                    int wordSerID = 0;
    //                    int.TryParse(wordsGroupConfig[1], out wordSerID);
    //                    if (wordSerID > AssetBundleManager.Instance.Version)
    //                    {
    //                        if (ConsoleManager._instacne.UseTestURL)
    //                        {
    //                            Toast.instance.ShowMessage(String.Format("词库当前版本{0}需要更新到{1}", AssetBundleManager.Instance.Version, wordSerID));
    //                        }
    //                        return true;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    return false;
    //}
    ////是否正在下载中
    ////等待下载
    //private bool loopingWaitforUpdater = true;
    //private IEnumerator LaunchUpdater()
    //{
    //    string uri = Const.WordBankURL + "/" + Const.ServerWordFolderName + "/";
    //    //重构url
    //    string currentversion = PlatformUtil.GetVersionCode().ToString();//ios下获取build号
    //    uri += currentversion + "/" + Language.settings.defaultLangCode.Trim() + "/" + DataManager.PlayerData.PlayerWordGroup;

    //    BetaFramework.LoggerHelper.Log("下载词库链接--->" + uri);

    //    if (ConsoleManager._instacne.UseTestURL)
    //    {
    //        Toast.instance.ShowMessage("词库正在下载");
    //    }

    //    yield return new WaitForSeconds(0.02f);
    //    Updater updater_ = gameObject.GetComponent<Updater>();
    //    if (updater_ == null)
    //        updater_ = gameObject.AddComponent<Updater>();

    //    List<string> url_group = new List<string>();

    //    url_group.Add(uri);
    //    updater_.StartUpdate(url_group);
    //    while (loopingWaitforUpdater)
    //    {
    //        yield return new WaitForSeconds(0.5f);

    //        if (ConsoleManager._instacne.UseTestURL)
    //            DataManager.ProcessData.ABLoadProgress = String.Format("{0}/{1}", updater_.CurrentStateCompleteValue, updater_.CurrentStateTotalValue);

    //        if (updater_ != null && updater_.IsDone && !updater_.IsFailed)
    //        {
    //            loopingWaitforUpdater = false;
    //            BetaFramework.LoggerHelper.Log("AB下载成功" + AssetBundleManager.Instance.Version);
    //            if (ConsoleManager._instacne.UseTestURL)
    //            {
    //                Toast.instance.ShowMessage("词库下载成功");
    //                DataManager.ProcessData.ABLoadProgress = "Finished";
    //            }
    //            yield return new WaitForSeconds(2.0f);
    //            WordStockUtils.LoadWordLib();
    //        }
    //        if (updater_ != null && updater_.IsFailed)
    //        {
    //            loopingWaitforUpdater = false;
    //            BetaFramework.LoggerHelper.Log("AB下载失败" + updater_.ErrorCode);
    //            if (ConsoleManager._instacne.UseTestURL)
    //            {
    //                DataManager.ProcessData.ABLoadProgress = "Error";
    //                Toast.instance.ShowMessage("词库下载失败");
    //            }
    //        }
    //    }
    //}
}