using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class GameRoot : BaseRoot
{

    private GamePlay _GamePlay;

    public override void Init()
    {
        base.Init();
        _GamePlay = transform.Find("GameRoot").GetComponent<GamePlay>();
    }

    public override void Show(Action<bool> callback)
    {
        GetComponent<Canvas>().enabled = true;
        _GamePlay.CreatGame(callback);
    }

    public override void Hidden()
    {
        GetComponent<Canvas>().enabled = false;
        _GamePlay.DestroyGame();
    }

    public override bool IsVisible()
    {
        return _GamePlay != null && _GamePlay.transform.childCount > 0;
    }
    

}