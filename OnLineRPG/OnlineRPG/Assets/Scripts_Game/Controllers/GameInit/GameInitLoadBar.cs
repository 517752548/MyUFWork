using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.GameInit
{
    public class GameInitLoadBar : MonoBehaviour
    {
        public Image loading;
        public GameObject plane;
        public GameObject loadingGameobject;
        public TextMeshProUGUI loadingText;
        
        public static float CurMaxProgress = 0f;
        public static float DebugProgress = 0f;
        public static bool ShowLoadBar = false;
        
        private float currentProgress = 0;
        private bool loadFinish = false;
        private float planeStartPosX = -1000f;
        private bool firstLoad = false;

        private void Start()
        {
            StartCoroutine(LoadingAnim());
        }

        IEnumerator LoadingAnim()
        {
            var loading = new WaitForSeconds(0.5f);
            while (true)
            {
                yield return loading;
                loadingText.text = "LOADING.";
                yield return loading;
                loadingText.text = "LOADING..";
                yield return loading;
                loadingText.text = "LOADING...";
            }
        }
        
        private void Update()
        {
            if (ShowLoadBar && !loadingGameobject.activeSelf)
            {
                loadingGameobject.SetActive(true);
                ShowLoadBar = false;
            }
            if (currentProgress <= CurMaxProgress)
            {
                currentProgress += 0.04f;
                loading.fillAmount = currentProgress;
                //progressText.text = $"{(int) (loading.fillAmount * 100)}%";
                if (planeStartPosX < -500f)
                    planeStartPosX = plane.transform.localPosition.x;
                float deltaX = ((RectTransform) loading.transform).sizeDelta.x * currentProgress;
                plane.transform.DOLocalMoveX(deltaX + planeStartPosX, 0.1f);
                if (currentProgress >= 1 && !loadFinish && !firstLoad)
                {
                    loadFinish = true;
                    Addressables.LoadSceneAsync(WordScene.MainScene,LoadSceneMode.Single);
                }
                else if (currentProgress >= 1 && !loadFinish && firstLoad)
                {
                    loadFinish = true;
                    FirstGoToGame();
                }
            }
        }

        public void LoadScene(bool first)
        {
            //Debug.LogError("第一次玩游戏" + first);
            firstLoad = first;
            if (first)
            {
                DataManager.ProcessData.firstGoToGameScene = true;
                DataManager.ProcessData._GameMode = GameMode.Classic;
            }
            else
            {
               //Addressables.LoadSceneAsync($"{WordScene.MainScene}", LoadSceneMode.Single, false);
                //sceneload.allowSceneActivation = false;
            }
        }
        private void FirstGoToGame()
        {
            UIManager.OpenUIAsync(ViewConst.prefab_GameLoadingWindow, (ui, para) =>
            {
                DataManager.ProcessData.firstGoToGameScene = true;
                DataManager.ProcessData._GameMode = GameMode.Classic;
                Addressables.LoadSceneAsync(WordScene.MainScene);
                //SceneManager.LoadSceneAsync(string.Format("{0}", WordScene.MainScene), LoadSceneMode.Single);
            });
        }
        

    }
}