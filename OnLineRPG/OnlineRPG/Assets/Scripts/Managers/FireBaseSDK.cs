using BetaFramework;
using UnityEngine;

public class FireBaseSDK
{

    public void Start()
    {
#if UNITY_AMAZON
        return;
#endif
        #if !UNITY_EDITOR
        FireBaseGragh.Init();
        #endif
    }
}