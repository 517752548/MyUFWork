using System;
using System.Collections.Generic;
using UnityEngine;

class LoadInfo
{
    public string urlPath;
    public WWW www;
    public RMetaEventHandler completeHandler;
    public RMetaEventHandler progressHandler;
    public DateTime startTime;
    //自己传的参数
    public object param;
    public bool isNetFile;
    public LoadArgs loadArgs;
    public LoadContentType contentType;
    public AssetBundleContainer bundleContainer;
}

class WaitingLoadList
{
    public List<object[]> ary;
    public RMetaEventHandler completeHandler = null;
    public RMetaEventHandler progressHandler = null;
}

/// <summary>
/// 单个资源加载完成后，对此资源的操作。
/// </summary>
public enum LoadArgs
{
    NONE,
    //assetbundle中的素材全部取出并缓存后，删掉assetbundle。
    SLIMABLE,
    //在SLIMABLE的基础上，load完成后立即将assetbundle中的mainAsset取出并缓存。
    SLIMABLE_INIT_MAIN_ASSET
}

/// <summary>
/// 资源类型。
/// </summary>
public enum LoadContentType
{
    //assetbundle
    ABL,
    //文本
    TEXT,
    //二进制数据
    BIN
}

/// <summary>
/// 资源加载
/// 支持加载单个资源、列表资源
/// 如果当前有列表资源正在加载，则不再接受加载列表资源，单个资源不受影响
/// </summary>
public class SourceLoader : MonoBehaviour
{
    /// <summary>
    /// log开关
    /// </summary>
    private bool switchLogWarning = false;
    /// <summary>
    /// log开关
    /// </summary>
    private bool switchLogError = true;
    /// <summary>
    /// 正在加载的资源信息列表
    /// </summary>
    private List<LoadInfo> loadingList = new List<LoadInfo>();
    private List<LoadInfo> addList = new List<LoadInfo>();
    private List<LoadInfo> deleteList = new List<LoadInfo>();
    /// <summary>
    /// 等待加载的资源
    /// </summary>
    private List<LoadInfo> waitingList = new List<LoadInfo>();
    private List<LoadInfo> isInLoadingList = new List<LoadInfo>();
    /// <summary>
    /// 等待加载的列表
    /// </summary>
    private List<WaitingLoadList> loadListWaiting;

    private int limitConnections = 1;
    /// <summary>
    /// 限制的最大连接数 0或-1表示无限制 正数表示限制数
    /// </summary>
    public int LimitConnections
    {
        get { return limitConnections; }
        set { limitConnections = value; }
    }
    /// <summary>
    /// 加载完成事件
    /// </summary>
    public static String LOAD_COMPLETE = "LOAD_COMPLETE";
    /// <summary>
    /// 加载失败事件
    /// </summary>
    public static String LOAD_FAILED = "LOAD_FAILED";
    /// <summary>
    /// 加载进度事件
    /// </summary>
    public static String LOAD_PROGRESS = "LOAD_PROGRESS";

    /**单个资源加载的超时时间，单位秒*/
    private float timeOut = 60f;

    /// <summary>
    /// 是否正在加载列表资源
    /// </summary>
    private bool isLoadingList = false;
    /// <summary>
    /// 当前列表资源中已经加载完的数量
    /// </summary>
    private int listLoadedIndex = 0;
    /// <summary>
    /// 当前列表资源的长度
    /// </summary>
    private int listTotalCount = 0;
    /// <summary>
    /// 列表资源的完成回调
    /// </summary>
    private RMetaEventHandler listCompleteHandler;
    /// <summary>
    /// 列表资源的进度回调
    /// </summary>
    private RMetaEventHandler listProgressHandler;

    /*
    public SourceLoader()
    {

    }
    */

    private static SourceLoader _ins;
    /// <summary>
    /// 单例
    /// </summary>
    public static SourceLoader Ins
    {
        get
        {
            if (_ins == null)
            {
                //_ins = new SourceLoader();
                _ins = GameObject.Find("ScriptsRoot").GetComponent<SourceLoader>();
                if (_ins == null)
                {
                    _ins = GameObject.Find("ScriptsRoot").AddComponent<SourceLoader>();
                }
            }
            return _ins;
        }
    }

    public void Update()
    {
        try
        {
            DateTime now = DateTime.Now;
            deleteList.Clear();
            loadingList.AddRange(addList);
            addList.Clear();
            for (int i = 0; i < loadingList.Count; i++)
            {
                LoadInfo loadinfo = loadingList[i];
                if (loadinfo.www.isDone)
                {//加载完成
                    if (switchLogWarning)
                    {
                        ClientLog.LogWarning("SourceLoader isDone  ! " + loadinfo.urlPath + "  loadDoneTime:" + Time.time);
                    }
                    if (loadinfo.www.error == null && loadinfo.www.bytesDownloaded > 0)
                    {//成功
                        //int lastIndex = loadinfo.urlPath.LastIndexOf('.');
                        //string houzhui = loadinfo.urlPath.Substring(lastIndex, loadinfo.urlPath.Length - lastIndex);
                        //if (houzhui == ".abl")
                        {
                            if (!SourceManager.Ins.hasAssetBundle(loadinfo.urlPath))
                            {
                                try
                                {
                                    AssetBundle bundle = loadinfo.www.assetBundle;

                                    if (loadinfo.contentType == LoadContentType.BIN)
                                    {
                                        loadinfo.bundleContainer = SourceManager.Ins.SaveBytes(loadinfo.urlPath, loadinfo.www.bytes);
                                    }
                                    else if (loadinfo.contentType == LoadContentType.TEXT)
                                    {
                                        loadinfo.bundleContainer = SourceManager.Ins.SaveText(loadinfo.urlPath, loadinfo.www.text);
                                    }
                                    else if (loadinfo.contentType == LoadContentType.ABL)
                                    {
                                        loadinfo.bundleContainer = SourceManager.Ins.SaveBundle(loadinfo.urlPath, bundle, loadinfo.loadArgs);
                                    }
                                    /*
                                    if (bundle != null)
                                    {
                                        loadinfo.bundleContainer = SourceManager.Ins.SaveBundle(loadinfo.urlPath, bundle, loadinfo.slimable);
                                    }
                                    */
                                }
                                catch (Exception e)
                                {
                                    if (switchLogError)
                                    {
                                        ClientLog.LogError("SourceLoader Update LoadComplete Error:" + e.ToString());
                                    }
                                }
                            }
                        }
                        if (loadinfo.completeHandler != null)
                        {
                            loadinfo.completeHandler(new RMetaEvent(LOAD_COMPLETE, loadinfo));
                        }
                        if (switchLogWarning)
                        {
                            ClientLog.LogWarning("SourceLoader load url:" + loadinfo.urlPath + " Success Complete!");
                        }
                        CallIsLoadWaitListComplete(loadinfo, LOAD_COMPLETE);
                    }
                    else if (loadinfo.www.error != null || loadinfo.www.bytesDownloaded <= 0)
                    {//失败
                        if (switchLogError)
                        {
                            ClientLog.LogError("资源加载失败 url:" + loadinfo.urlPath + " Error:" +
                                               loadinfo.www.error);
                        }
                        if (loadinfo.completeHandler != null)
                        {
                            loadinfo.completeHandler(new RMetaEvent(LOAD_FAILED, loadinfo));
                        }
                        CallIsLoadWaitListComplete(loadinfo, LOAD_FAILED);
                    }
                    deleteList.Add(loadinfo);
                }
                else
                {
                    if (loadinfo.progressHandler != null)
                    {
                        loadinfo.progressHandler(new RMetaEvent(LOAD_PROGRESS, loadinfo));
                    }
                    //如果加载超时，则重新添加到列表中 XXX 策略待定，先这样
                    TimeSpan ts = now - loadinfo.startTime;
                    int passTime = (int)Math.Floor(ts.TotalMilliseconds) / 1000;
                    if (passTime > timeOut)
                    {
                        if (switchLogError)
                        {
                            ClientLog.LogError("www load time out!force quit loading!url=" + loadinfo.urlPath);
                        }
                        //强制从loading列表移除
                        deleteList.Add(loadinfo);
                        //重试
                        loadOne(loadinfo.urlPath, loadinfo.completeHandler, loadinfo.progressHandler);
                        if (switchLogWarning)
                        {
                            ClientLog.LogWarning("try reload time out url=" + loadinfo.urlPath);
                        }
                    }
                }
            }
            //移除加载完成的内容
            for (int j = 0; j < deleteList.Count; j++)
            {
                //deleteKeyList[j].www.assetBundle.Unload(true);
                deleteList[j].www.Dispose();
                loadingList.Remove(deleteList[j]);
            }
            //检查等待列表
            if (limitConnections > 0)
            {
                int leftCount = limitConnections - (loadingList.Count + addList.Count);
                int canAddCount = leftCount >= waitingList.Count ? waitingList.Count : leftCount;
                if (canAddCount > 0)
                {//一帧只增加一个连接
                    //for (int k = 0; k < canAddCount; k++)
                    //{
                    LoadInfo loadinfo = waitingList[0];
                    if (switchLogWarning)
                    {
                        ClientLog.LogWarning("Waiting List Start Loading():" + loadinfo.urlPath);
                    }
                    WWW www =
                        new WWW(loadinfo.isNetFile ? loadinfo.urlPath : PathUtil.Ins.GetFinalPath(loadinfo.urlPath));
                    loadinfo.startTime = DateTime.Now;
                    loadinfo.www = www;
                    addList.Add(loadinfo);
                    waitingList.RemoveAt(0);
                    //}
                }
            }
            //检查等待列表
            loadWaitingList();
        }
        catch (Exception e)
        {
            switchLogWarning = false;
            ClientLog.LogError("Exception!!!" + e.ToString());
        }
    }
    /// <summary>
    /// 回调正在加载时新来的加载请求
    /// </summary>
    /// <param name="loadinfo"></param>
    /// <param name="EventType"></param>
    private void CallIsLoadWaitListComplete(LoadInfo loadinfo, string EventType)
    {
        for (int i = 0; i < isInLoadingList.Count; i++)
        {//回调正在等待的
            if (isInLoadingList[i].urlPath == loadinfo.urlPath)
            {
                if (isInLoadingList[i].completeHandler != null)
                {
                    if (switchLogWarning)
                    {
                        ClientLog.LogWarning("callback Waiting LoadComplete ：" + loadinfo.urlPath);
                    }
                    isInLoadingList[i].completeHandler(new RMetaEvent(EventType, isInLoadingList[i]));
                }
                isInLoadingList.RemoveAt(i);
                i--;
            }
        }
    }

    //需传入最终资源全路径
    private void loadOne(String urlPath, RMetaEventHandler completeHandler, RMetaEventHandler progressHandler = null,
        object param = null, bool isNetFile = false, bool loadNow = false, LoadArgs loadArgs = LoadArgs.SLIMABLE, LoadContentType contentType = LoadContentType.ABL)
    {
        if (string.IsNullOrEmpty(urlPath))
        {
            return;
        }
        if (switchLogWarning)
        {
            ClientLog.LogWarning("准备load：" + urlPath);
            ClientLog.LogWarning("CCCCCCount：" + loadingList.Count + "   " + addList.Count + "   " +
                                 waitingList.Count);
        }
        LoadInfo isloadnginfo = GetLoadInfoFromLoadingList(urlPath);
        if (isloadnginfo == null)
        {
            if (!loadNow && limitConnections > 0 && loadingList.Count + addList.Count >= limitConnections)
            {
                //达到连接数上限,等待
                LoadInfo loadinfo = new LoadInfo();
                loadinfo.startTime = DateTime.Now;
                loadinfo.urlPath = urlPath;
                loadinfo.param = param;
                loadinfo.isNetFile = isNetFile;
                loadinfo.completeHandler = completeHandler;
                loadinfo.progressHandler = progressHandler;
                loadinfo.loadArgs = loadArgs;
                loadinfo.contentType = contentType;
                waitingList.Add(loadinfo);
                if (switchLogWarning)
                {
                    ClientLog.LogWarning("放入等待列表：" + urlPath);
                }
            }
            else
            {
                //加载
                if (switchLogWarning)
                {
                    ClientLog.LogWarning("Start Loading():" + urlPath + "  startTime:" + Time.time);
                }
                WWW www = new WWW(isNetFile ? urlPath : PathUtil.Ins.GetFinalPath(urlPath));
                LoadInfo loadinfo = new LoadInfo();
                loadinfo.startTime = DateTime.Now;
                loadinfo.urlPath = urlPath;
                loadinfo.param = param;
                loadinfo.isNetFile = isNetFile;
                loadinfo.www = www;
                loadinfo.completeHandler = completeHandler;
                loadinfo.progressHandler = progressHandler;
                loadinfo.loadArgs = loadArgs;
                loadinfo.contentType = contentType;
                addList.Add(loadinfo);
            }
        }
        else
        {
            //已经在加载列表中
            if (switchLogWarning)
            {
                ClientLog.LogWarning("Is Loading just WaitLoadComplete :" + urlPath);
            }
            bool istheSame = (isloadnginfo.completeHandler == completeHandler);
            //加载同一个资源，并且同一个回调函数，则直接扔掉
            if (!istheSame)
            {
                //同一个资源，不同的回调函数
                //WWW www = new WWW(isNetFile ? urlPath : PathUtil.Ins.GetFinalPath(urlPath));
                LoadInfo loadinfo = new LoadInfo();
                loadinfo.startTime = DateTime.Now;
                loadinfo.urlPath = urlPath;
                loadinfo.param = param;
                loadinfo.isNetFile = isNetFile;
                //loadinfo.www = www;
                loadinfo.completeHandler = completeHandler;
                loadinfo.progressHandler = progressHandler;
                loadinfo.loadArgs = loadArgs;
                loadinfo.contentType = contentType;
                isInLoadingList.Add(loadinfo);
                if (switchLogWarning)
                {
                    ClientLog.LogWarning(" push into waitingLoadComplete List:" + urlPath);
                }
            }
            else
            {
                if (switchLogWarning)
                {
                    ClientLog.LogWarning(" the same url the same callback ,Throw it!" + urlPath);
                }
            }
        }
    }

    /// <summary>
    /// 加载单个网络资源
    /// </summary>
    /// <param name="url">资源路径</param>
    /// <param name="completeHandler">加载完成回调</param>
    /// <param name="progressHandler">加载进度回调</param>
    public void loadNet(String urlPath, RMetaEventHandler completeHandler = null, RMetaEventHandler progressHandler = null, LoadArgs loadArgs = LoadArgs.NONE, LoadContentType contentType = LoadContentType.ABL)
    {
        loadOne(urlPath, completeHandler, progressHandler, null, true, true, loadArgs, contentType);
    }

    /// <summary>
    /// 加载单个内部资源
    /// </summary>
    /// <param name="url">资源路径</param>
    /// <param name="completeHandler">加载完成回调,参数：RMetaEvent(LOAD_COMPLETE, Loadinfo)</param>
    /// <param name="progressHandler">加载进度回调</param>
    /// <param name="loadNow">是否立即加载</loadNow>
    public void load(String url, RMetaEventHandler completeHandler = null,
        RMetaEventHandler progressHandler = null, object param = null, bool loadNow = false, LoadArgs loadArgs = LoadArgs.SLIMABLE, LoadContentType contentType = LoadContentType.ABL)
    {
        AssetBundleContainer bundleContainer = SourceManager.Ins.GetBundleConainer(url);
        if (bundleContainer != null)
        {
            bundleContainer.referenceCount--;
            if (completeHandler != null)
            {
                LoadInfo loadinfo = new LoadInfo();
                loadinfo.urlPath = url;
                loadinfo.bundleContainer = bundleContainer;
                loadinfo.param = param;
                loadinfo.loadArgs = loadArgs;
                loadinfo.contentType = contentType;
                completeHandler(new RMetaEvent(LOAD_COMPLETE, loadinfo));
            }
            if (switchLogWarning)
            {
                ClientLog.LogWarning("SourceLoader.load " + url + " has cache Call Complete!");
            }
            return;
        }
        loadOne(url, completeHandler, progressHandler, param, false, loadNow, loadArgs, contentType);
    }
    /// <summary>
    /// 检查是否有资源缓存，有直接返回，无 则返回false后重新加载
    /// </summary>
    /// <param name="url"></param>
    /// <param name="completeHandler"></param>
    /// <returns></returns>
    private bool checkCache(String url)
    {
        if (SourceManager.Ins.hasAssetBundle(url))
        {//有资源                
            return true;
        }
        return false;
    }

    public bool isAllLoaded(List<string> ary)
    {
        for (int i = 0; i < ary.Count; i++)
        {
            if (!checkCache(ary[i]))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 加载列表资源
    /// </summary>
    /// <param name="ary">资源路径列表List<object[]{url, LoadArgs, LoadContentType}></param>
    /// <param name="completeHandler">列表加载完成回调</param>
    /// <param name="progressHandler">列表加载进度回调</param>
    public void loadList(List<object[]> ary, RMetaEventHandler completeHandler = null, RMetaEventHandler progressHandler = null)
    {
        /*
        int k = 0;
        for (k = 0; k < ary.Count; k++)
        {
            //ClientLog.LogWarning("load:::    "+ary[k]);
        }
        */

        if (ary == null || ary.Count <= 0)
        {
            if (completeHandler != null) completeHandler(new RMetaEvent(SourceLoader.LOAD_COMPLETE, null));
            return;
        }
        int i = 0;
        paichong(ary);
        if (switchLogWarning)
        {
            ClientLog.LogWarning("SourceLoader loadList!!!");
        }
        if (isLoadingList)
        {
            if (loadListWaiting == null)
            {
                loadListWaiting = new List<WaitingLoadList>();
            }
            loadListWaiting.Add(
                new WaitingLoadList
                {
                    ary = ary,
                    completeHandler = completeHandler,
                    progressHandler = progressHandler,
                }
            );
            return;
        }
        isLoadingList = true;
        listLoadedIndex = 0;
        listTotalCount = ary.Count;
        listCompleteHandler = completeHandler;
        listProgressHandler = progressHandler;
        for (i = 0; i < ary.Count; i++)
        {
            string url = (string)ary[i][0];
            LoadArgs loadArgs = (LoadArgs)ary[i][1];
            LoadContentType contentType = (LoadContentType)ary[i][2];
            load(url, onLoadProgressHandler, null, null, false, loadArgs, contentType);
        }
    }

    public void paichong<T>(List<T> ary)
    {
        int i = 0;
        for (i = 0; i < ary.Count; i++)
        {
            for (int j = i + 1; j < ary.Count; j++)
            {
                if (ary[i].Equals(ary[j]))
                {
                    ary.RemoveAt(j);
                    j--;
                }
            }
        }
    }

    private void onLoadProgressHandler(RMetaEvent e)
    {
        listLoadedIndex++;

        if (listProgressHandler != null)
        {
            List<object> ary = new List<object>();
            ary.Add(listLoadedIndex);
            ary.Add(listTotalCount);
            ary.Add(e.data as LoadInfo);
            if (e.type == LOAD_COMPLETE)
            {
                listProgressHandler(new RMetaEvent(LOAD_PROGRESS, ary));
            }
            else if (e.type == LOAD_FAILED)
            {
                listProgressHandler(new RMetaEvent(LOAD_FAILED, ary));
            }
        }

        //ClientLog.LogWarning("SourceLoader LoadList Progress:" + listLoadedIndex + "/" + listTotalCount);
        if (listLoadedIndex == listTotalCount)
        {
            //ClientLog.LogWarning("SourceLoader LoadList Complete!!!");
            listLoadedIndex = 0;
            listTotalCount = 0;
            isLoadingList = false;

            if (listCompleteHandler != null)
            {
                listCompleteHandler(new RMetaEvent(LOAD_COMPLETE, null));
            }
        }
    }

    private void loadWaitingList()
    {
        //列表加载完毕
        if (loadListWaiting != null && loadListWaiting.Count > 0 && (waitingList == null || (waitingList != null && waitingList.Count == 0)))
        {
            WaitingLoadList list = loadListWaiting[0];
            loadList(list.ary, list.completeHandler, list.progressHandler);
            loadListWaiting.RemoveAt(0);
        }
    }

    private LoadInfo GetLoadInfoFromLoadingList(string url)
    {
        for (int i = 0; i < loadingList.Count; i++)
        {
            if (loadingList[i].urlPath == url)
            {
                return loadingList[i];
            }
        }
        for (int i = 0; i < addList.Count; i++)
        {
            if (addList[i].urlPath == url)
            {
                return addList[i];
            }
        }
        for (int i = 0; i < waitingList.Count; i++)
        {
            if (waitingList[i].urlPath == url)
            {
                return waitingList[i];
            }
        }
        return null;
    }

    private LoadInfo getLoadInfo(RMetaEvent e)
    {
        if (e != null && e.data != null)
        {
            LoadInfo loadinfo = e.data as LoadInfo;
            if (loadinfo != null)
            {
                return loadinfo;
            }
            List<object> list = e.data as List<object>;
            if (list != null && list.Count > 2)
            {
                loadinfo = list[2] as LoadInfo;
            }
            if (loadinfo != null)
            {
                return loadinfo;
            }
        }
        return null;
    }

    /**
     * 是否加载成功
     */
    private bool isRequestSuccess(RMetaEvent e)
    {
        LoadInfo loadinfo = null;
        if (e != null && e.type == LOAD_COMPLETE)
        {
            loadinfo = getLoadInfo(e);
            if (loadinfo != null && loadinfo.www != null)
            {
                if (loadinfo.www.isDone)
                {
                    if (loadinfo.www.error == null)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    /**
    * 是否加载成功
    */
    public bool IsLoadSuccess(RMetaEvent e)
    {
        if (e != null && e.type == LOAD_FAILED)
        {
            return false;
        }
        return true;
    }

    /**
     * 获取加载的字节数组
     */
    /*
    public byte[] getRequestBytes(RMetaEvent e)
    {
        LoadInfo loadinfo = null;
        if (e != null && e.type == LOAD_COMPLETE)
        {
            loadinfo = getLoadInfo(e);
        }
        if (isRequestSuccess(e))
        {
            if (loadinfo.www.bytes != null && loadinfo.www.bytes.Length > 0)
            {
                return loadinfo.www.bytes;
            }
        }
        return null;
    }
    */
    /**
     * 获取加载的文本内容
     */
    /*
    public string getRequstText(RMetaEvent e)
    {
        LoadInfo loadinfo = null;
        if (e != null && e.type == LOAD_COMPLETE)
        {
            loadinfo = getLoadInfo(e);
        }
        if (isRequestSuccess(e))
        {
            return loadinfo.www.text;
        }
        return null;
    }
    */
    /**
     * 获取加载错误信息
     */
    public string getRequstError(RMetaEvent e)
    {
        LoadInfo loadinfo = null;
        if (e != null && e.type == LOAD_COMPLETE)
        {
            loadinfo = getLoadInfo(e);
        }
        if (isRequestSuccess(e))
        {
            return loadinfo.www.error;
        }
        return null;
    }
    /**
     * 获取加载进度
     */
    public float getRequstProgress(RMetaEvent e)
    {
        LoadInfo loadinfo = null;
        if (e != null && e.type == LOAD_PROGRESS)
        {
            loadinfo = getLoadInfo(e);
            if (loadinfo != null && loadinfo.www.error == null)
            {
                return loadinfo.www.progress;
            }
        }
        return 0.0f;
    }
}