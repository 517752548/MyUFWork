using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using UnityEngine;

public class SingleCoinFly
{
    private Ease explodeEase = Ease.InQuart;
    private Ease dropEase = Ease.OutQuart;

    private const float flyTime = 0.7f;

    // Use this for initialization
    public static IEnumerator FlyGolds(Vector3 InPos, bool InIsLocalPos = true)
    {
        CurrencyBallance currencyBallance = GameObject.FindObjectOfType<CurrencyBallance>();
        Transform targetPos = currencyBallance.transform;
        if (currencyBallance.coinPos != null)
        {
            targetPos = currencyBallance.coinPos;
        }

        float[] delay = new[] {0.05f, 0.06f, 0.07f, 0.04f, 0.08f, 0.07f, 0.08f, 0.1f};
        int[] offsetx = new[] {0, 20, -16, 24, -18, 22, -18, 22};
        GameObject coinPrefab = null;

        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_singlecoinFly,
            ( go) => { coinPrefab = go; });

        while (coinPrefab == null)
        {
            yield return null;
        }

        for (int i = 0; i < 8; i++)
        {
            Transform prefab =
                AppEngine.SObjectPoolManager.Spawn<Transform>(ViewConst.prefab_singlecoinFly, coinPrefab.transform);
            prefab.transform.SetParent(UIManager.UIManagerGo.transform.Find("DefaultUI/TopBar"), false);
            DestroyAfterTime destroyAfterTime = prefab.GetComponent<DestroyAfterTime>();
            destroyAfterTime.time = flyTime - 0.05f;
            destroyAfterTime.offsetx = offsetx[i];
            if (InIsLocalPos) prefab.transform.localPosition = InPos;
            else prefab.transform.position = InPos;
            prefab.transform.DOMove(
                new Vector3(targetPos.position.x, targetPos.position.y, prefab.transform.position.z), flyTime);
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_getcoin);
            //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_getcoin);

            yield return new WaitForSeconds(delay[i]);
        }
    }

    public static IEnumerator FlySingleCommonTypeGolds(Vector3 InPos, float flydruction, bool InIsLocalPos = true,
        float delaysound = 0)
    {
        CurrencyBallance currencyBallance = GameObject.FindObjectOfType<CurrencyBallance>();
        Transform targetPos = currencyBallance.transform;
        if (currencyBallance.coinPos != null)
        {
            targetPos = currencyBallance.coinPos;
        }

        GameObject coinPrefab = null;

        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_singlecoinFly, 
            ( go) => { coinPrefab = go; });

        while (coinPrefab == null)
        {
            yield return null;
        }

        Transform prefab =
            AppEngine.SObjectPoolManager.Spawn<Transform>(ViewConst.prefab_coinFly, coinPrefab.transform);
       
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_getcoin);

        prefab.transform.SetParent(UIManager.UIManagerGo.transform.Find("DefaultUI/TopBar/FlyRewards"), false);
        DestroyAfterTime destroyAfterTime = prefab.GetComponent<DestroyAfterTime>();
        destroyAfterTime.time = flydruction + 0.01f;
        destroyAfterTime.offsetx = 0;
        prefab.transform.localScale = Vector3.one;
        prefab.transform.DOScale(Vector3.one, 0.3f).SetDelay(0.2f);
        if (InIsLocalPos) prefab.transform.localPosition = InPos;
        else prefab.transform.position = InPos;

        prefab.transform
            .DOMove(new Vector3(targetPos.position.x, targetPos.position.y, prefab.transform.position.z), flydruction)
            .SetEase(Ease.InOutCubic);
        if (delaysound > 0)
        {
            Debug.LogError("声音");
            yield return new WaitForSeconds(delaysound);
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_getcoin);
        }
        else
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_getcoin);
        }
    }
    
    public static IEnumerator FlySingleGolds(Vector3 InPos, float flydruction, bool InIsLocalPos = true,
        float delaysound = 0)
    {
        CurrencyBallance currencyBallance = GameObject.FindObjectOfType<CurrencyBallance>();
        Transform targetPos = currencyBallance.transform;
        if (currencyBallance.coinPos != null)
        {
            targetPos = currencyBallance.coinPos;
        }

        GameObject coinPrefab = null;

        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_singlecoinFly,
            ( go) => { coinPrefab = go; });

        while (coinPrefab == null)
        {
            yield return null;
        }

        Transform prefab =
            AppEngine.SObjectPoolManager.Spawn<Transform>(ViewConst.prefab_singlecoinFly, coinPrefab.transform);
       
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_getcoin);

        prefab.transform.SetParent(UIManager.UIManagerGo.transform.Find("DefaultUI/TopBar"), false);
        DestroyAfterTime destroyAfterTime = prefab.GetComponent<DestroyAfterTime>();
        destroyAfterTime.time = flydruction + 0.01f;
        destroyAfterTime.offsetx = 0;
        if (InIsLocalPos) prefab.transform.localPosition = InPos;
        else prefab.transform.position = InPos;

        prefab.transform
            .DOMove(new Vector3(targetPos.position.x, targetPos.position.y, prefab.transform.position.z), flydruction)
            .SetEase(Ease.InOutCubic);
        if (delaysound > 0)
        {
            Debug.LogError("声音");
            yield return new WaitForSeconds(delaysound);
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_getcoin);
        }
        else
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_getcoin);
        }
    }

    public static IEnumerator FlySingleACIcons(Vector3 InPos, float flydruction, Transform targetPos,
        bool InIsLocalPos = true)
    {
        GameObject coinPrefab = null;

        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_singleAcIconFly, 
            ( go) => { coinPrefab = go; });

        while (coinPrefab == null)
        {
            yield return null;
        }

        Transform prefab =
            AppEngine.SObjectPoolManager.Spawn<Transform>(ViewConst.prefab_singlecoinFly, coinPrefab.transform);
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_getcoin);
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_getcoin);

        prefab.transform.SetParent(UIManager.UIManagerGo.transform.Find("DefaultUI/TopBar"), false);
        DestroyAfterTime destroyAfterTime = prefab.GetComponent<DestroyAfterTime>();
        destroyAfterTime.time = flydruction + 0.01f;
        destroyAfterTime.offsetx = 0;
        if (InIsLocalPos) prefab.transform.localPosition = InPos;
        else prefab.transform.position = InPos;

        prefab.transform.DOMove(targetPos.position, flydruction).SetEase(Ease.InOutCubic);
    }
}