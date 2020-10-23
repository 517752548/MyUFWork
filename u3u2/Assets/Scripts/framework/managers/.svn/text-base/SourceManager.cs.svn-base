using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 资源管理
/// 传入的路径 都是相对于Assets\StreamingAssets\的路径
/// TODO:获取动态资源，需要先加载再赋值
/// </summary>
public class SourceManager : AbsMonoBehaviour
{
    public Font defaultFont { get; set; }

    /// <summary>
    /// 资源字典，索引为资源路径
    /// </summary>
    private Dictionary<string, AssetBundleContainer> assetBundles = new Dictionary<string, AssetBundleContainer>();
    /// <summary>
    /// 定时 检查 的时间间隔，单位:s
    /// </summary>
    private int checkInterval = 120;
    /// <summary>
    /// 上次检查的时间
    /// </summary>
    private float lastCheckTime = 0;
    /// <summary>
    /// 忽略回收的列表
    /// </summary>
    private Dictionary<string, bool> ignoreDisposeList = new Dictionary<string, bool>();

    public static int MAX_UNLOAD_COUNT_ONE_TIME = 10;

    public SourceManager()
    {
        
    }

    private static SourceManager _ins;
    public static SourceManager Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new SourceManager();
                //UnityEngine.Object.DontDestroyOnLoad(_ins);                    
            }
            return _ins;
        }
    }

    /// <summary>
    /// 资源字典，索引为资源路径
    /// </summary>
    public Dictionary<string, AssetBundleContainer> AssetBundles
    {
        get { return assetBundles; }
    }

    public override void DoUpdate(float deltaTime)
    {
        /*
        if (Time.unscaledTime - lastCheckTime > checkInterval)
        {//固定时间间隔 检测
            CheckForUnusedBundles();
            lastCheckTime = Time.unscaledTime;
        }
        */
    }

    public override void Start()
    {
        lastCheckTime = Time.unscaledTime;
    }

    /// <summary>
    /// 存储资源
    /// </summary>
    /// <param name="bundlePath">资源路径</param>
    /// <param name="assetBundle">资源内容</param>
    public AssetBundleContainer SaveBundle(string bundlePath, AssetBundle assetBundle, LoadArgs loadArgs)
    {
        string finalPath = PathUtil.Ins.GetFinalPath(bundlePath);
        if (this.assetBundles.ContainsKey(finalPath))
        {
            DestroyAssetBundle(bundlePath);
        }
        AssetBundleContainer container = new AssetBundleContainer(finalPath, assetBundle, loadArgs);
        this.assetBundles.Add(finalPath, container);
        ClientLog.Log("SaveBundle:" + finalPath);
        return container;
    }

    public AssetBundleContainer SaveBytes(string bundlePath, byte[] bytes)
    {
        string finalPath = PathUtil.Ins.GetFinalPath(bundlePath);
        if (this.assetBundles.ContainsKey(finalPath))
        {
            DestroyAssetBundle(bundlePath);
        }
        AssetBundleContainer container = new AssetBundleContainer(finalPath, bytes);
        this.assetBundles.Add(finalPath, container);
        ClientLog.Log("SaveBundle:" + finalPath);
        return container;
    }

    public AssetBundleContainer SaveText(string bundlePath, string text)
    {
        string finalPath = PathUtil.Ins.GetFinalPath(bundlePath);
        if (this.assetBundles.ContainsKey(finalPath))
        {
            DestroyAssetBundle(bundlePath);
        }
        AssetBundleContainer container = new AssetBundleContainer(finalPath, text);
        this.assetBundles.Add(finalPath, container);
        ClientLog.Log("SaveBundle:" + bundlePath);
        return container;
    }

    /// <summary>
    /// 添加引用
    /// </summary>
    /// <param name="bundlePath"></param>
    /// <param name="instantiatedObject"></param>
    public void addReference(string bundlePath)
    {
        bundlePath = PathUtil.Ins.GetFinalPath(bundlePath);
        if (!this.assetBundles.ContainsKey(bundlePath))
        {
            ClientLog.LogWarning("addReference:AssetsBundle has not been in the Dictionary!!! urlPath:" + bundlePath);
        }
        else
        {
            AssetBundleContainer container2 = (AssetBundleContainer)this.assetBundles[bundlePath];
            if (container2 != null)
            {
                container2.referenceCount++;
            }
            else
            {
                ClientLog.LogError("AssetsBundle in the Dictionary,But can not getValue!!! urlPath:" + bundlePath);
            }
        }
    }
    /// <summary>
    /// 移除对资源的引用，并销毁传入的对象
    /// </summary>
    /// <param name="bundlePath">引用用到的资源路径</param>
    /// <param name="instantiatedObject">引用对象</param>
    public void removeReference(string bundlePath, Object go = null, bool clearRefCount = false)
    {
        if (string.IsNullOrEmpty(bundlePath) || !IsFileNameValid(bundlePath))
        {
            return;
        }
        bundlePath = PathUtil.Ins.GetFinalPath(bundlePath);
        if (!this.assetBundles.ContainsKey(bundlePath))
        {
            ClientLog.LogWarning("removeReference:AssetsBundle has not been in the Dictionary!!! urlPath:" + bundlePath);
        }
        else
        {
            AssetBundleContainer container2 = (AssetBundleContainer)this.assetBundles[bundlePath];
            //this.assetBundles.TryGetValue(bundlePath, out container2);
            if (container2 != null)
            {
                UnityEngine.Object.DestroyImmediate(go, true);
                go = null;
                if (clearRefCount)
                {
                    container2.referenceCount = 0;
                }
                else
                {
                    container2.referenceCount--;
                }
                ClientLog.LogWarning("removeReference " + bundlePath + "  curRefCount:" + container2.referenceCount);
                //if (container2.referenceCount < 1 && !isIgnored(bundlePath))
                //{
                //    container2.Unload();
                //    assetBundles.Remove(bundlePath);
                //}
            }
            else
            {
                ClientLog.LogError("AssetsBundle in the Dictionary,But can not getValue!!! urlPath:" + bundlePath);
            }
        }
    }

    /// <summary>
    /// 清理空引用
    /// </summary>
    public void CheckForUnusedBundles()
    {
        if (this.assetBundles.Count > 0)
        {
            List<string> list = new List<string>();

            IDictionaryEnumerator enumerator = this.assetBundles.GetEnumerator();
            int count = 0;
            while (enumerator.MoveNext())
            {
                string key = (string)enumerator.Key;
                AssetBundleContainer value = (AssetBundleContainer)(enumerator.Value);
                if (!isIgnored(key) && value.IsListEmpty())
                {
                    value.Unload(true);
                    list.Add(key);
                    count++;
                    /*
                    if (count >= MAX_UNLOAD_COUNT_ONE_TIME)
                    {
                        break;
                    }
                    */
                }
            }

            /*
            foreach (DictionaryEntry pair in this.assetBundles)
            {
                string key = (string)pair.Key;
                AssetBundleContainer value = (AssetBundleContainer)(pair.Value);
                if (!isIgnored(key) && value.IsListEmpty())
                {
                    value.Unload();
                    list.Add(key);
                }
            }
            */

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    this.assetBundles.Remove(list[i]);
                }
                list.Clear();
                //Resources.UnloadUnusedAssets();
                //GC.Collect();
            }
        }
    }
    /// <summary>
    /// 获取资源AssetsBundle
    /// </summary>
    /// <param name="bundlePath">资源路径</param>
    /// <returns></returns>
    public T GetAsset<T>(string bundlePath, string name = null, bool async = false) where T : UnityEngine.Object
    {
        if (string.IsNullOrEmpty(bundlePath)) return null;
        string totalbundlePath = PathUtil.Ins.GetFinalPath(bundlePath);
        AssetBundleContainer container = null;
        //(AssetBundleContainer)this.assetBundles[totalbundlePath];
        this.assetBundles.TryGetValue(totalbundlePath, out container);
        T t = null;
        if (container != null)
        {
            //addReference(bundlePath);
            container.referenceCount++;
            if (string.IsNullOrEmpty(name))
            {
                //t = container.ThisAssetBundle.mainAsset as T;
                t = container.GetMainAsset() as T;
            }
            else
            {
                //t = container.ThisAssetBundle.LoadAsset<T>(name);
                t = container.GetAssetByName(name, async) as T;
            }

#if UNITY_EDITOR
            if (t is GameObject)
            {
                ResetShader(t as GameObject);
            }
#endif
            return t;
        }

        ClientLog.LogError(bundlePath + " 资源不存在!");
        return null;
    }

    public byte[] GetBytes(string bundlePath)
    {
        if (string.IsNullOrEmpty(bundlePath)) return null;
        string totalbundlePath = PathUtil.Ins.GetFinalPath(bundlePath);
        AssetBundleContainer container = null;
        //(AssetBundleContainer)this.assetBundles[totalbundlePath];
        this.assetBundles.TryGetValue(totalbundlePath, out container);
        if (container != null)
        {
            //addReference(bundlePath);
            container.referenceCount++;
            return container.bytes;
        }

        ClientLog.LogError(bundlePath + " 资源不存在!");
        return null;
    }

    public string GetText(string bundlePath)
    {
        if (string.IsNullOrEmpty(bundlePath)) return null;
        string totalbundlePath = PathUtil.Ins.GetFinalPath(bundlePath);
        AssetBundleContainer container = null;
        //(AssetBundleContainer)this.assetBundles[totalbundlePath];
        this.assetBundles.TryGetValue(totalbundlePath, out container);
        if (container != null)
        {
            //addReference(bundlePath);
            container.referenceCount++;
            return container.text;
        }

        ClientLog.LogError(bundlePath + " 资源不存在!");
        return null;
    }

    /*
    public Texture2D GetSingleCommonTexture(string name)
    {
        return GetAsset<Texture2D>(PathUtil.Ins.GetSingleCommonTexturesPath(), name);
    }
    */

    public Sprite GetBiankuang(int id)
    {
        return GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, "biankuang" + id);
    }
    /*
    public Texture2D GetImageText(string id)
    {
        return GetSingleCommonTexture(id);
    }
    */

    public UnityEngine.Object GetCommonUI(string name)
    {
        return GetAsset<UnityEngine.Object>(PathUtil.Ins.GetUIPath("CommonUI"), name);
    }

    /// <summary>
    /// 获取资源AssetsBundle,引用计数会＋1
    /// </summary>
    /// <param name="bundlePath">资源路径</param>
    /// <returns></returns>
    public AssetBundleContainer GetBundleConainer(string bundlePath)
    {
        //AssetBundleContainer container = null;
        string totalbundlePath = PathUtil.Ins.GetFinalPath(bundlePath);
        AssetBundleContainer container = null;
        this.assetBundles.TryGetValue(totalbundlePath, out container);
        if (container != null)
        {
            container.referenceCount++;
            //addReference(bundlePath);
            return container;
        }
        return null;
    }

    public bool hasAssetBundle(string bundlePath)
    {
        bundlePath = PathUtil.Ins.GetFinalPath(bundlePath);
        return assetBundles.ContainsKey(bundlePath);
    }

    private void DestroyAssetBundle(string bundlePath)
    {
        //ClearAllReference(bundlePath);
        bundlePath = PathUtil.Ins.GetFinalPath(bundlePath);

        if (assetBundles.ContainsKey(bundlePath))
        {
            AssetBundleContainer bundleContainer = (AssetBundleContainer)assetBundles[bundlePath];
            if (bundleContainer != null)
            {
                //bundleContainer.referenceCount = 0;
                bundleContainer.Unload(true);
            }
            assetBundles.Remove(bundlePath);
        }
    }

    public void UnloadAssetBundle(string bundlePath, bool destroy = true)
    {
        if (destroy)
        {
            DestroyAssetBundle(bundlePath);
        }
        else
        {
            AssetBundleContainer bundleContainer = GetBundleConainer(bundlePath);
            if (bundleContainer != null)
            {
                bundleContainer.Unload(false);
            }
        }
    }

    /// <summary>
    /// 从AssetsBundle创建对象
    /// </summary>
    /// <param name="bundlePath">AssetsBundle资源路径</param>
    /// <param name="name">AssetsBundle内 资源名称 带后缀</param>
    /// <returns></returns>        
    public GameObject createObjectFromAssetBundle(string bundlePathv, string name = null)
    {
        UnityEngine.Object asset = GetAsset<UnityEngine.Object>(bundlePathv, name);
        if (asset == null)
        {
            return new GameObject("empty");
        }

        GameObject gameObj = (GameObject)UnityEngine.Object.Instantiate(asset);

        if (gameObj == null)
        {
            return new GameObject("empty");
        }

        ResetShader(gameObj);
        return gameObj;

        /*
        UnityEngine.Object original = null;
        AssetBundle abc = GetBundle(bundlePathv);
        if (abc == null)
        {
            ClientLog.LogWarning("createObjectFromAssetBundle:Can not GetAssetBundle!!! bundlePath:" + PathUtil.Ins.GetFinalPath(bundlePathv));
            GameObject emptyObj = new GameObject("empty");
            return emptyObj;
        }
        if (name != null)
        {
            original = abc.LoadAsset(name);
        }
        else
        {
            //获取主资源，相当于Load()
            original = abc.mainAsset;
        }
        //if (abc.ThisAssetBundle.mainAsset is Texture2D)
        //{
        //    instantObj = (GameObject)(original);
        //}
        //else
        //{
        //addReference(bundlePathv);
        GameObject gameObj = (GameObject)UnityEngine.Object.Instantiate(original);
        ResetShader(gameObj);
        if (gameObj == null)
        {
            gameObj = new GameObject("empty");
        }
        return gameObj;
        //}           
        */
    }
    /// <summary>
    /// 在win和mac下 重新设置shader
    /// </summary>
    /// <param name="go"></param>
    private void ResetShader(GameObject go)
    {
#if UNITY_EDITOR
        {
            foreach (Renderer mrc in go.GetComponents<MeshRenderer>())
            {
                foreach (Material mat in mrc.sharedMaterials)
                {
                    if (mat != null)
                    {
                        mat.shader = Shader.Find(mat.shader.name);
                    }
                }
            }
            foreach (Renderer mrc in go.GetComponentsInChildren<MeshRenderer>(true))
            {
                foreach (Material mat in mrc.sharedMaterials)
                {
                    if (mat != null)
                    {
                        mat.shader = Shader.Find(mat.shader.name);
                    }
                }
            }

            foreach (Renderer mrc in go.GetComponents<SkinnedMeshRenderer>())
            {
                foreach (Material mat in mrc.sharedMaterials)
                {
                    if (mat != null)
                    {
                        mat.shader = Shader.Find(mat.shader.name);
                    }
                }
            }
            foreach (Renderer mrc in go.GetComponentsInChildren<SkinnedMeshRenderer>(true))
            {
                foreach (Material mat in mrc.sharedMaterials)
                {
                    if (mat != null)
                    {
                        mat.shader = Shader.Find(mat.shader.name);
                    }
                }
            }

            foreach (ParticleSystemRenderer psr in go.GetComponents<ParticleSystemRenderer>())
            {
                foreach (Material mat in psr.sharedMaterials)
                {
                    mat.shader = Shader.Find(mat.shader.name);
                }
            }

            foreach (ParticleSystemRenderer psr in go.GetComponentsInChildren<ParticleSystemRenderer>(true))
            {
                foreach (Material mat in psr.sharedMaterials)
                {
                    if (mat != null)
                    {
                        mat.shader = Shader.Find(mat.shader.name);
                    }
                }
            }

        }
#endif
    }

    /// <summary>
    /// 忽略回收
    /// 如果忽略目录，要从根目录开始，不能只传子目录名
    /// </summary>
    /// <param name="urlPathes"></param>
    public void ignoreDispose(string[] urlPathes)
    {
        int len = urlPathes.Length;
        for (int i = 0; i < len; i++)
        {
            ignoreDispose(urlPathes[i]);
        }
    }

    /// <summary>
    /// 忽略回收
    /// 如果忽略目录，要从根目录开始，不能只传子目录名
    /// </summary>
    /// <param name="urlPath"></param>
    public void ignoreDispose(string urlPath)
    {
        urlPath = PathUtil.Ins.GetFinalPath(urlPath);
        ignoreDisposeList[urlPath] = true;
    }
    /// <summary>
    /// 取消忽略回收
    /// </summary>
    /// <param name="urlPath"></param>
    public void unignoreDispose(string urlPath)
    {
        urlPath = PathUtil.Ins.GetFinalPath(urlPath);
        if (ignoreDisposeList.ContainsKey(urlPath))
        {
            ClientLog.LogWarning("unignoreDispose " + urlPath + " OK!");
            ignoreDisposeList.Remove(urlPath);
        }
    }
    /// <summary>
    /// 获取 资源是否被忽略
    /// </summary>
    /// <param name="urlpath">全路径</param>
    /// <returns></returns>
    private bool isIgnored(string urlpath)
    {
        //string[] split = new string[1];
        //split[0] = PathUtil.Ins.assets_root;
        if (ignoreDisposeList.ContainsKey(urlpath))
        {
            return true;
        }
        //string[] urlary = urlpath.Split(split,System.StringSplitOptions.RemoveEmptyEntries);
        //urlpath = urlary[0];
        //检查目录

        IDictionaryEnumerator enumerator = this.ignoreDisposeList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            string key = (string)enumerator.Key;
            if (urlpath.Contains(key) && urlpath.IndexOf(key) == 0)
            {
                return true;
            }
        }

        /*
        foreach (DictionaryEntry pair in ignoreDisposeList)
        {
            string key = (string)pair.Key;
            if (urlpath.Contains(key) && urlpath.IndexOf(key) == 0)
            {
                return true;
            }
        }
        */
        return false;
    }
    /// <summary>
    /// 判断资源路径中文件名是否合法
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private bool IsFileNameValid(string path)
    {
        if (path.Contains("/.") || path.Contains("\\."))
        {
            return false;
        }
        return true;
    }
    /// <summary>
    /// 清空所有相同前缀的 资源 的引用
    /// </summary>
    /// <param name="path">前缀为相对路径</param>
    public void ClearAllReference(string path)
    {
        ClientLog.LogWarning("ClearAllReference:" + path);
        path = PathUtil.Ins.GetFinalPath(path);
        IDictionaryEnumerator enumerator = this.assetBundles.GetEnumerator();
        while (enumerator.MoveNext())
        {
            string key = (string)enumerator.Key;
            AssetBundleContainer value = (AssetBundleContainer)(enumerator.Value);
            if (key.Contains(path) && key.IndexOf(path) == 0)
            {
                value.referenceCount = 0;
                ClientLog.LogWarning("ClearAllReference OK!");
            }
        }
    }

    public void Clear()
    {
        ignoreDisposeList.Clear();
        IDictionaryEnumerator enumerator = this.assetBundles.GetEnumerator();
        while (enumerator.MoveNext())
        {
            AssetBundleContainer value = (AssetBundleContainer)(enumerator.Value);
            value.Unload(true);
        }
        assetBundles.Clear();
        defaultFont = null;
    }

    public void LogAssetBundles()
    {
        ClientLog.LogError("==========SourceManager assetBundles==========");
        int count = 0;
        IDictionaryEnumerator enumerator = this.assetBundles.GetEnumerator();
        while (enumerator.MoveNext())
        {
            string key = (string)enumerator.Key;
            AssetBundleContainer value = (AssetBundleContainer)(enumerator.Value);
            count++;
            ClientLog.LogError("name:" + key + " refCount:" + value.referenceCount);
        }
        ClientLog.LogError("total count:" + count);
    }
}