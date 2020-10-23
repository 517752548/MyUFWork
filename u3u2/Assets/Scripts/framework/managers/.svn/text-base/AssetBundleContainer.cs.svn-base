using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public class AssetBundleContainerAssetRequest : Object
{
    private AssetBundleContainer mBundleContainer = null;
    private AssetBundleRequest mRequest = null;
    private string mAssetName;
    private bool mIsDone = false;
    public AssetBundleContainerAssetRequest(AssetBundleContainer bundleContainer, string assetName)
    {
        mBundleContainer = bundleContainer;
        mAssetName = assetName;
        mRequest = bundleContainer.assetBundle.LoadAssetAsync(assetName);
    }
    
    public bool isDone
    {
        get
        {
            if (!mIsDone)
            {
                bool v = mRequest.isDone;
                if (mIsDone != v)
                {
                    mIsDone= v;
                    if (mIsDone)
                    {
                        mBundleContainer.OnAssetLoadCompleted(mAssetName, mRequest.asset);
                    }
                }
            }
            return mIsDone;
        }
    }
}

public class AssetBundleContainer
{
    public LoadArgs loadArgs { get; set; }

    private int mReferenceCount = 0;
    private string mBundleName;
    private AssetBundle mAssetBundle;
    private Object mMainAsset;
    private Dictionary<string, Object> mAssets = new Dictionary<string, Object>();
    private byte[] mBytes = null;
    private string mText = null;
    private int mAssetsNoLoadCount = 0;
    private string[] mAllAssetsNames = null;

    public int referenceCount
    {
        get
        {
            return mReferenceCount;
        }
        set
        {
            mReferenceCount = value;
        }
    }

    public AssetBundleContainer(string bundleName, AssetBundle assetBundle, LoadArgs loadArgs)
    {
        this.mBundleName = bundleName;
        this.mAssetBundle = assetBundle;
        this.loadArgs = loadArgs;
        if (loadArgs == LoadArgs.SLIMABLE || loadArgs == LoadArgs.SLIMABLE_INIT_MAIN_ASSET)
        {
            this.mAllAssetsNames = assetBundle.GetAllAssetNames();
            this.mAssetsNoLoadCount = this.mAllAssetsNames.Length;

            if (loadArgs == LoadArgs.SLIMABLE_INIT_MAIN_ASSET)
            {
                InitMainAsset();
            }
        }
    }

    public void SlimableNow()
    {
        for (int i = 0; i < mAssetsNoLoadCount; i++)
        {
            Object asset = mAssetBundle.LoadAsset(mAllAssetsNames[i]);
            mAssets.Add(asset.name, asset);
            //GetAssetByName(mAllAssetsNames[i]);
        }
        mAssetsNoLoadCount = 0;
        Unload(false);
    }

    public AssetBundleContainer(string bundleName, byte[] bytes)
    {
        mBytes = bytes;
    }

    public byte[] bytes
    {
        get
        {
            return mBytes;
        }
    }

    public AssetBundleContainer(string bundleName, string text)
    {
        mText = text;
    } 

    public string text
    {
        get
        {
            return mText;
        }
    }

    public bool IsListEmpty()
    {
        return (referenceCount <= 0);
    }

    public void Unload(bool destroy)
    {
        if (destroy)
        {
            if (mMainAsset != null)
            {
                GameObject.DestroyImmediate(mMainAsset, true);
                this.mMainAsset = null;
            }

            IDictionaryEnumerator enumerator = this.mAssets.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string key = (string)enumerator.Key;
                GameObject.DestroyImmediate((Object)enumerator.Value, true);
            }

            this.mAssets.Clear();

            if (this.mAssetBundle != null)
            {
                this.mAssetBundle.Unload(true);
            }
            this.mAssetBundle = null;
            this.mBytes = null;
            this.referenceCount = 0;
        }
        else
        {
            if (this.mAssetBundle != null)
            {
                this.mAssetBundle.Unload(false);
                this.mAssetBundle = null;
            }
        }
    }

    public string bundleName
    {
        get
        {
            return this.mBundleName;
        }
        set
        {
            this.mBundleName = value;
        }
    }

    public AssetBundle assetBundle
    {
        get
        {
            return this.mAssetBundle;
        }
        set
        {
            this.mAssetBundle = value;
        }
    }

    public Object GetMainAsset()
    {
        InitMainAsset();
        return mMainAsset;
    }

    public void InitMainAsset()
    {
        if (mMainAsset == null)
        {
            mMainAsset = mAssetBundle.mainAsset;
            if (mMainAsset == null)
            {
                mMainAsset = new Object();
                ClientLog.LogError(mBundleName + " 没有mainAsset!");
            }
            else
            {
                mAssetsNoLoadCount = 0;
                OneAssetLoaded();
            }
        }
    }

    public Object GetAssetByName(string name, bool async = false)
    {
        if (mAssets.ContainsKey(name))
        {
            return mAssets[name];
        }
        
        if (async)
        {
            return new AssetBundleContainerAssetRequest(this, name);
        }
        if (mAssetBundle == null)
        {
            return null;
        }
        Object asset = mAssetBundle.LoadAsset(name);
        OnAssetLoadCompleted(name, asset);
        return asset;
    }
    
    public void OnAssetLoadCompleted(string name, Object asset)
    {
        mAssets.Add(name, asset);
        if (asset != null)
        {
            OneAssetLoaded();
        }
    }
    
    public void InitAssets(string[] assetNames)
    {
        int len = assetNames.Length;
        for (int i = 0; i < len; i++)
        {
            GetAssetByName(assetNames[i]);
        }
    }

    public void OneAssetLoaded()
    {
        if (loadArgs == LoadArgs.SLIMABLE || loadArgs == LoadArgs.SLIMABLE_INIT_MAIN_ASSET)
        {
            mAssetsNoLoadCount--;

            if (mAssetsNoLoadCount <= 0)
            {
                Unload(false);
            }
        }
    }
}