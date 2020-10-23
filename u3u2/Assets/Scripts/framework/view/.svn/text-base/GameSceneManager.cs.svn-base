using System;
using UnityEngine;
using UnityEngine.Events;

public class GameSceneManager : MonoBehaviour
{
    public float unitySceneLoadProgress { get; private set; }

    private UnityAction unitySceneLoadingDelegate = null;
    private UnityAction unitySceneLoadedDelegate = null;

    //private BaseScene mCurrentScene = null;
    private String mCurrentUnitySceneName = null;

    private AsyncOperation mAsync = null;
    private bool mIsLoadingUnityScene = false;

    private static GameSceneManager _ins = null;

    public static GameSceneManager Ins
    {
        get
        {
            if (_ins == null)
            {
                //_ins = Singleton.getObj(typeof(GameSceneManager)) as GameSceneManager;
                _ins = GameObject.Find("ScriptsRoot").GetComponent<GameSceneManager>();
                if (_ins == null)
                {
                    _ins = GameObject.Find("ScriptsRoot").AddComponent<GameSceneManager>();
                }
            }
            return _ins;
        }
    }

    public GameSceneManager()
    {
        mCurrentUnitySceneName = Application.loadedLevelName;
        //mCurrentUnitySceneName = SceneManager.GetActiveScene().name;
    }

    /// <summary>
    /// 加载unity场景，返回true说明开始加载，返回false说明当前场景就是要加载的场景。
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="onLoaded"></param>
    /// <param name="isAdditive"></param>
    /// <returns></returns>
    public void LoadUnityScene(String sceneName, UnityAction onLoading, UnityAction onLoaded = null, bool isAdditive = false)
    {
        //if (sceneName != mCurrentUnitySceneName)
        //{
            AudioManager.Ins.DestroyAll();
            this.unitySceneLoadingDelegate = onLoading;
            this.unitySceneLoadedDelegate = onLoaded;
            if (isAdditive)
            {
                mAsync = Application.LoadLevelAdditiveAsync(sceneName);
                //mAsync = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }
            else
            {
                mAsync = Application.LoadLevelAsync(sceneName);
                //mAsync = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            }
            mCurrentUnitySceneName = sceneName;
            
            if (mAsync != null)
            {
                mIsLoadingUnityScene = true;
                unitySceneLoadProgress = 0;
            }
            else
            {
                ClientLog.LogError("异步加载场景" + mCurrentUnitySceneName + "失败!");
            }
            
            //return true;
        //}
        //unitySceneLoadProgress = 100;
        //return false;
    }
    /*
    public void ShowScene(String sceneName, String camName = null)
    {
        HideScene();
        mCurrentScene = (Singleton.getObj(Type.GetType(sceneName)) as BaseScene);
        if (camName != null)
        {
            mCurrentScene.camera = GameObject.Find(camName);
        }
        else
        {
            mCurrentScene.camera = Camera.main.gameObject;
        }

        if (mCurrentScene.camera != null) mCurrentScene.camera.SetActive(true);
        //mCurrentScene.preLoadUI();
    }

    public void HideScene()
    {
        if (mCurrentScene != null)
        {
            mCurrentScene.hide();
            mCurrentScene = null;
        }
    }
    */
    public void Update()
    {
        if (mIsLoadingUnityScene)
        {
            unitySceneLoadProgress = mAsync.progress;

            if (unitySceneLoadingDelegate != null)
            {
                unitySceneLoadingDelegate();
            }
            
            if (mAsync.isDone)
            {
                mIsLoadingUnityScene = false;
                if (unitySceneLoadedDelegate != null)
                {
                    unitySceneLoadedDelegate();
                }
            }
        }
        /*
        if (mCurrentScene != null)
        {
            mCurrentScene.DoUpdate(deltaTime);
        }
        */
    }

    /*
    public override void FixedUpdate()
    {
        if (mCurrentScene != null)
        {
            mCurrentScene.FixedUpdate();
        }
    }

    public override void LateUpdate()
    {
        if (mCurrentScene != null)
        {
            mCurrentScene.LateUpdate();
        }
    }

    public BaseScene currentScene
    {
        get
        {
            return mCurrentScene;
        }
    }

    public String currentUnitySceneName
    {
        get
        {
            return mCurrentUnitySceneName;
        }
    }
    */
}