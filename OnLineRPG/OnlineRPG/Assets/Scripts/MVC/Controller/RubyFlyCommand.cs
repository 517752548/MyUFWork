using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using UnityEngine;
using Object = UnityEngine.Object;

internal class RubyFlyCommand : ICommand
{
    //传入的必须是个transform类型
    public object Data { get; set; }

    private List<GameObject> m_RubyList;
    private GameObject m_Prefab;
    private Vector3 m_BegainPos;

    public void Initilize()
    {
        m_RubyList = new List<GameObject>();
    }

    public void Execute()
    {
        RubyFlyData position = ((RubyFlyData)Data);
        switch (position.rubyType)
        {
            case RubyType.single:
                SingleCoinsFly();
                break;

            case RubyType.stack:
                LoadPrefab_3d();
                break;
        }
    }

    public void SingleCoinsFly()
    {
        RubyFlyData position = ((RubyFlyData)Data);
        Loom.Current.StartCoroutine(SingleCoinFly.FlyGolds(position.inpos, false));
    }

    public void Release()
    {
    }

    private void LoadPrefab_3d()
    {
        RubyFlyData position = ((RubyFlyData)Data);
        CurrencyBallance[] currencyBallance = CurrencyBallance._CurrencyBallances.ToArray();
        
        Transform targetPos = currencyBallance[0].transform;
        if (currencyBallance[currencyBallance.Length - 1].coinPos != null)
        {
            targetPos = currencyBallance[currencyBallance.Length - 1].coinPos;
        }

        ResourceManager.LoadAsync<GameObject>(ViewConst.prefab_coinFly, ( go) =>
        {
            for (int i = 0; i < 12; i++)
            {
                Transform prefab = AppEngine.SObjectPoolManager.Spawn<Transform>(ViewConst.prefab_singlecoinFly, go.transform);
                prefab.transform.SetParent(UIManager.UIManagerGo.transform.Find("DefaultUI/TopBar"), false);
                prefab.GetComponent<CoinFly>().Fly(targetPos);
                prefab.transform.position = position.inpos;
            }
            for (int i = 0; i < currencyBallance.Length; i++)
            {
                currencyBallance[i].DoFadeAnim(position.coin);
            }
            
            AppThreadController.instance.StartCoroutine(Play3DSound());
        });
    }

    private IEnumerator Play3DSound()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 6; i++)
        {
            AppEngine.SSoundManager.PlaySFX(ViewConst.wav_getcoin);
            //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_getcoin);
            yield return new WaitForSeconds(0.05f);
        }
    }

    //    private void LoadPrefab()
    //    {
    //        m_BegainPos = ((Transform)Data).position;
    //        ResourceLoadHelper.LoadPrefabAsync<GameObject>(ResourcesKeys.RubyFly, false, (id, go) =>
    //        {
    //            m_Prefab = go;
    //            TimersManager.SetTimer(0.1f, 5, OnLoadSuccess);
    //            TimersManager.SetTimer(1.5f, () => { DestroyCoin(); });
    //        });
    //    }

    private void OnLoadSuccess()
    {
        Vector3 targetPos = GameObject.FindObjectOfType<CurrencyBallance>().transform.position;

        GameObject prefab = GameObject.Instantiate(m_Prefab);
        m_RubyList.Add(prefab);
        prefab.transform.position = m_BegainPos;
        prefab.transform.DOMove(targetPos, 0.5f).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            //if (i == 4)
            {
                //DestroyCoin();
            }
        });
        AppEngine.SSoundManager.PlaySFX(ViewConst.wav_getcoin);
        //CommandChannel.GetInstance().PostCommand(CommonCommandConst.PLAY_SFX, ViewConst.wav_getcoin);
    }

    private void DestroyCoin()
    {
        //CurrencyBallance晃动
        EventDispatcher.TriggerEvent(GlobalEvents.ShopCoinAniPack);
        for (int i = 0; i < m_RubyList.Count; i++)
        {
            GameObject.Destroy(m_RubyList[i]);
        }
    }

    public class RubyFlyData
    {
        public RubyType rubyType = RubyType.single;
        public Vector3 inpos;
        public int coin;

        public RubyFlyData(RubyType rubyType, Vector3 inpos,int coin)
        {
            this.coin = coin;
            this.rubyType = rubyType;
            this.inpos = inpos;
        }
    }
}

public enum RubyType
{
    single,
    stack
}