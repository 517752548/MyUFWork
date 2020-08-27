using BetaFramework;
using System.Collections.Generic;
using UnityEngine;

public class Examples : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    #region 下载器使用方法

    public void DownLoadManagerExample()
    {
        DownLoadListener listener = new DownLoadListener();
        //1.Get方式请求 返回byte[]
        //ModuleManager.FindModule<DownloadManager>().GetBytes(listener, "URL");
        //2.Post方式请求 返回byte[]
        //ModuleManager.FindModule<DownloadManager>().PostBytes(listener, "URL", new Dictionary<string, string>());
    }

    private class DownLoadListener : IDownloadListener
    {
        public void OnError(int transactionId, string errorMessage)
        {
            throw new System.NotImplementedException();
        }

        public void OnSuccess(int transactionId, byte[] bytes)
        {
            throw new System.NotImplementedException();
        }

        public void OnUpdate(int transactionId, float progress)
        {
            throw new System.NotImplementedException();
        }
    }

    #endregion 下载器使用方法

    #region 存储本地数据的方法

    public void UseRecordData()
    {
        //1.在游戏启动的时候，最好是第一帧，越早越好，调用初始化方法
        Record.Init();
        //2.使用getxxx和setxxx方法来存储数据
        Record.GetString("xxx");
        Record.SetString("xxx", "xxxx");
        //3.在调用初始化方法的时候所有的存储的数据都已经自动预加载到内存中了，在使用过程中不需要再做数据缓存
    }

    #endregion 存储本地数据的方法

    #region 上报信息

    /// <summary>
    /// 上报打点的例子
    /// </summary>
    public void ReportExample()
    {
        //GameAnalysis.ReportLogin();
    }

    #endregion 上报信息
}