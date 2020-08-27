using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.GameInit
{
    public class UpdateDataLoading : MonoBehaviour
    {
        public Slider plane;
        private void Start()
        {
            Invoke("ToMain",0.5f);
        }
        private void Update()
        {
            if (plane != null && load.IsValid())
            {
                plane.value = load.PercentComplete;
            }
        }

        private AsyncOperationHandle<SceneInstance> load;
        private void ToMain()
        {
            load = Addressables.LoadSceneAsync(WordScene.MainScene, LoadSceneMode.Single);
        }
    }
}