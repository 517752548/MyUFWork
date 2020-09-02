using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using UnityEngine;

/// <summary>
/// 飞各种奖励的统一view   统一飞的方式，用协成方法FlyAny来执行，起始位置通过类似EXP下的两个Transform来写
/// </summary>
public class FlyRewardView : MonoBehaviour
{
    private static FlyRewardView _instance = null;

    public static FlyRewardView instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<FlyRewardView>();
            }

            return _instance;
        }
    }

    private List<Vector3> startPosLists = new List<Vector3>();
    private bool inloopWaitcoin = false;
    private Vector3 CurrencyBarPos(Vector3 defVal)
    {
        Vector3 to = defVal;
        CurrencyBallance[] coinmanager = FindObjectsOfType<CurrencyBallance>();
        if (coinmanager.Length > 0)
        {
            to = coinmanager[0].coinPos.position;
        }

        return to;
    }

    public void FlyCoin(Vector3 from, Action coinFlyCallBack)
    {
        Vector3 to = CurrencyBarPos(from);

        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_coinFly,
            (go) =>
            {
                StartCoroutine(FlyAny(go, from, to, coinFlyCallBack));
            });
    }

    private IEnumerator FlyAny(GameObject expObj, Vector3 from, Vector3 to, Action expFlyCallBack, int flyNumber = 6)
    {
        int flyCount = 0;
        GameObject expFly = null;
        for (int i = 0; i < flyNumber; i++)
        {
            yield return new WaitForSeconds(0.1f);
            expFly = Instantiate(expObj);
            expFly.transform.SetParent(transform, false);
            expFly.transform.position = from;
            expFly.AddComponent<DlayDestroy>().dlayTime = 0.5f;
            expFly.transform.DOScale(Vector3.one * 0.5f, 0.3f).SetDelay(0.2f);
            expFly.transform.DOMove(new Vector3(to.x, to.y, from.z), 0.5f).OnComplete(() =>
            {
                flyCount++;
                if (flyCount >= flyNumber)
                {
                    if (expFlyCallBack != null)
                    {
                        expFlyCallBack.Invoke();
                    }
                }
            });
        }
    }

    public void RateFlyCoin(List<Vector3> startPosList, Action coinFlyCallBack)
    {
        Vector3 toPos = CurrencyBarPos(Vector3.zero);

        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_coinFly,
            (coinFly) =>
            {
                StartCoroutine(FlyMultiSingle(coinFly, startPosList, toPos, coinFlyCallBack));
            });
    }

    public void FlySingleCoin(List<Vector3> startPosList, Action coinFlyCallBack, float delay)
    {
        Vector3 toPos = CurrencyBarPos(Vector3.zero);

        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_coinFly,
            (coinFly) =>
            {
                StartCoroutine(FlyMultiSingle(coinFly, startPosList, toPos, coinFlyCallBack, delay));
            });
    }

    public int AddSingleCoinToMultiFly(Vector3 startPosList)
    {

        if (!inloopWaitcoin)
        {
            inloopWaitcoin = true;
            TimersManager.SetTimer(0.05f, () =>
            {
                inloopWaitcoin = false;
                ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_coinFly,
                    (coinFly) =>
                    {
                        Vector3 toPos = CurrencyBarPos(Vector3.zero);
                        List<Vector3> ves = new List<Vector3>();
                        for (int i = 0; i < startPosLists.Count; i++)
                        {
                            ves.Add(startPosLists[i]);
                        }
                        startPosLists.Clear();
                        StartCoroutine(FlyMultiSingle(coinFly, ves, toPos, null, 0));
                    });
            });
            startPosLists.Add(startPosList);

        }
        else
        {
            startPosLists.Add(startPosList);
        }
        return startPosLists.Count;
    }

    public void FlyCup(Vector3 startPos, Vector3 endPos, int count, Action flyCallBack)
    {
        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_coinFly,
            (cupFly) =>
            {
                List<Vector3> list = new List<Vector3>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(startPos);
                }
                StartCoroutine(FlyMultiSingle(cupFly, list, endPos, flyCallBack));
            });
    }

    private IEnumerator FlyMultiSingle(GameObject flyPrefab, List<Vector3> startPosList, Vector3 toPos, Action flyCallBack, float delay = 0)
    {
        int flyCount = 0;
        GameObject fly = null;
        int flyNumber = startPosList.Count;
        if (delay > 0)
        {
            yield return new WaitForSeconds(delay);
        }
        for (int i = 0; i < flyNumber; i++)
        {
            yield return new WaitForSeconds(0.1f);
            fly = Instantiate(flyPrefab);
            fly.transform.SetParent(transform, false);
            fly.transform.position = startPosList[i];
            fly.AddComponent<DlayDestroy>().dlayTime = 0.5f;
            fly.transform.DOScale(Vector3.one, 0.3f).SetDelay(0.2f);
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_getcoin);
            fly.transform.DOMove(new Vector3(toPos.x, toPos.y, startPosList[i].z), 0.5f).OnComplete(() =>
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
        }
    }
}