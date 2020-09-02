using System;
using System.Collections;
using BetaFramework;
using DG.Tweening;
using Scripts_Game.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts_Game.Controllers.Cup
{
    public class CupCollectProgressBar : MonoBehaviour
    {
        public Transform cupImg;
        public Slider slider;
        public TextMeshProUGUI targetText;
        public TextMeshProUGUI progressText;
        public GameObject newBoxFlag;
        public CupCollectStartBar startBar;

        private float progress, target;
        private int curCup, startCup, targetCup;

        public void Show()
        {
            gameObject.SetActive(true);
            var sys = AppEngine.SSystemManager.GetSystem<CupSystem>();
            curCup = AppEngine.SyncManager.Data.Cup.LastValue;
            startCup = sys.GetLastTarget(curCup);
            progress = curCup - startCup;
            targetCup = sys.GetCurTarget(curCup);
            target = sys.GetCurrentTargetRegion(curCup);
            newBoxFlag.SetActive(!sys.IsTargetClaimed(sys.GetLastTargetID(curCup)));
            targetText.text = "" + target;
            SetProgress(progress);
            AppEngine.SyncManager.Data.Cup.ResetLastValue();
        }

        private void SetProgress(float p)
        {
            progress = p;
            progressText.text = CommUtil.ShortNum(curCup) + "/" + CommUtil.ShortNum(targetCup);
            slider.value = progress / target;
        }

        public void Fly(Action callback)
        {
            ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_CupFly,
                (cupFly) =>
                {
                    StartCoroutine(FlyMultiCup(cupFly, 
                        startBar.cupImg.position, cupImg.position, 10,
                        () =>
                        {
                            OnCupFlyOver();
                            callback?.Invoke();
                        }));
                    startBar.PlayReduceAni(1f);
                    DOTween.Sequence().InsertCallback(0.7f, PlayProgressIncreaseAni);
                });
            // FlyRewardView.instance.FlyCup(startBar.cupImg.position, cupImg.position, 10, () =>
            // {
            //     OnCupFlyOver();
            //     callback?.Invoke();
            // });
            // startBar.PlayReduceAni(1f);
            // DOTween.Sequence().InsertCallback(0.5f, PlayProgressIncreaseAni);
        }

        private void PlayProgressIncreaseAni()
        {
            DOTween.To(() => curCup, x => curCup = x, AppEngine.SyncManager.Data.Cup.Value, 0.5f)
                .OnUpdate(() => { SetProgress(curCup - startCup); }).OnComplete(() =>
                {
                    if (!newBoxFlag.activeSelf)
                        newBoxFlag.SetActive(progress >= target);
                });
        }

        private void OnCupFlyOver()
        {
        }

        private IEnumerator FlyMultiCup(GameObject flyPrefab, Vector3 startPos, Vector3 toPos, int flyNumber,
            Action flyCallBack)
        {
            int flyCount = 0;
            GameObject fly = null;
            for (int i = 0; i < flyNumber; i++)
            {
                fly = Instantiate(flyPrefab);
                fly.transform.SetParent(transform, false);
                fly.transform.position = startPos;
                fly.AddComponent<DlayDestroy>().dlayTime = 1.5f;
                //fly.transform.DOScale(Vector3.one, 0.3f).SetDelay(0.2f);
                AppEngine.SSoundManager.PlaySFX(ViewConst.wav_getcoin);
                fly.GetComponentInChildren<Animator>().SetTrigger("fly");
                fly.transform.DOMove(new Vector3(toPos.x, toPos.y, startPos.z), 0.7f).OnComplete(() =>
                {
                    flyCount++;
                    if (flyCount >= flyNumber)
                    {
                        if (flyCallBack != null)
                        {
                            flyCallBack.Invoke();
                        }
                    }
                });
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}