using EventUtil;
using Firebase;
using Firebase.Unity.Editor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BetaFramework;
using UnityEngine;

public static class FireBaseGragh
{
    public static bool FireBaseInited = false;
    private static DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    public static void Init()
    {
        try
        {


        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                BetaFramework.LoggerHelper.Error(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
            FireBaseInited = true;
            Debug.Log("Firebase Init Successful");
        });
        }
        catch (Exception e)
        {
            Debug.LogError(e.StackTrace);
            Debug.LogException(e);
        }
    }

    private static void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl(FireBaseConfig.DataURL);
        
        Loom.QueueOnMainThread(() =>
        {
            EventDispatcher.TriggerEvent(GlobalEvents.FirebaseInitSuccess);
        });

        //AppEngine.SSDKManager.firebaseSdk.isLogIn = true;
    }
}