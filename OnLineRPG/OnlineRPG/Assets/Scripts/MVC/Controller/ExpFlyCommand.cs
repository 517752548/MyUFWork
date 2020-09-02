using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using DG.Tweening;
using EventUtil;
using UnityEngine;
using Object = UnityEngine.Object;

internal class ExpFlyCommand : ICommand
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
        SingleCoinsFly();
    }

    public void SingleCoinsFly()
    {
        
        //Loom.Current.StartCoroutine(SingleCoinFly.FlyGolds(position.inTransform.position, false));
    }

    public void Release()
    {
    }

}
