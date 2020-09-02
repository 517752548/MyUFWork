using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public class SDKManager : IModule
{
    public FaceBookSDK facebookSdk;
    public FireBaseSDK firebaseSdk;

    public SDKManager()
    {
        facebookSdk = new FaceBookSDK();
        firebaseSdk = new FireBaseSDK();
    }

    public override void Init()
    {
        GameSetting.Init();
        PlatformUtil.Init();

        facebookSdk.Init();
        firebaseSdk.Start();
        facebookSdk.Start(null);
    }

    public override void Shut()
    {
        facebookSdk.OnDestroy();
    }

    public override void Pause(bool pause)
    {
    }
}