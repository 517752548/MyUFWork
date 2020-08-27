using UnityEngine;

namespace BetaFramework
{
    public class AppEntry : MonoBehaviour
    {
        /// <summary>
        /// 启动游戏
        /// </summary>
        protected virtual void Awake()
        {
            //AppEngine.Init();
            DontDestroyOnLoad(gameObject);
        }

        protected virtual void Update()
        {
            AppEngine.Update();
        }

        protected virtual void OnDestroy()
        {
            AppEngine.Destroy();
        }

        protected virtual void OnApplicationPause(bool pause)
        {
            AppEngine.ApplicationPause(pause);
        }
    }
}