using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DownLoadResSystem : ISystem
{
    public override void InitSystem()
    {
        base.InitSystem();
    }

    public override void OnEnterUI(GameUI UiToSwitch)
    {
        if (UiToSwitch == GameUI.Home)
        {
            // if (AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value > 5)
            // {
            //     LoadBG();
            // }
        }
    }


    private async void LoadBG()
    {
      var bg =  Addressables.GetDownloadSizeAsync("OnlineBG");
      await bg.Task;
        if (bg.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("BG：" + bg.Result);
            if (bg.Result > 0)
            {
                Addressables.DownloadDependenciesAsync("OnlineBG").Completed+= (op) =>
                {
                    Debug.Log("OnlineBG下载完毕");
                };
            }
        }
    }
}
