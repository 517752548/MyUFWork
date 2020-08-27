using System;
using BetaFramework;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BeeCountBar : MonoBehaviour
{
    public Image beeImg;
    public TextMeshProUGUI countText;
    

    private void Start()
    {
        gameObject.SetActive(AppEngine.SyncManager.Data.Bee.Value > 0);
        countText.text = AppEngine.SyncManager.Data.Bee.Value.ToString();
        AppEngine.SyncManager.Data.Bee.DataUpdateEvent += Refresh;
    }

    public void Refresh()
    {
        TimersManager.SetTimer(0.5f, () =>
        {
            gameObject.SetActive(AppEngine.SyncManager.Data.Bee.Value > 0);
            countText.text = AppEngine.SyncManager.Data.Bee.Value.ToString();
        });

    }

    public void PlayCountAni(int deltaCount, bool reduce)
    {
        int endCount = AppEngine.SyncManager.Data.Bee.Value;
        int startCount = reduce ? endCount + deltaCount : endCount - deltaCount;
        countText.text = startCount.ToString();
        DOTween.To(() => startCount, x => startCount = x, endCount, 0.5f).OnUpdate(() =>
        {
            countText.text = startCount.ToString();
        });
    }

    public void SlideInOut(int count, Action appearCallback, Action disappearCallback = null)
    {
        gameObject.SetActive(true);
        AppEngine.SyncManager.Data.Bee.DataUpdateEvent -= Refresh;
        float startPosX = transform.localPosition.x;
        countText.text = (AppEngine.SyncManager.Data.Bee.Value + count).ToString();
        transform.DOLocalMoveX(startPosX - 320, 0.5f).OnComplete(() =>
            {
                appearCallback?.Invoke();
                PlayCountAni(count, true);
                transform.DOLocalMoveX(startPosX, 0.5f)
                    .SetDelay(1f)
                    .OnComplete(()=>disappearCallback?.Invoke());
            });
    }

    private void OnDestroy()
    {
        AppEngine.SyncManager.Data.Bee.DataUpdateEvent -= Refresh;
    }
}