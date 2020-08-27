using IFix.Core;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class IFixMgr
{
    public const string patchName = "Assembly-CSharp.patch.bytes";
    public static async void Init(Action callback)
    {
        var patch = ResourceManager.LoadAsync<TextAsset>(patchName);
        await patch.Task;
        if (patch.Status == AsyncOperationStatus.Succeeded)
        {
#if !UNITY_EDITOR
            if (patch.Result != null && patch.Result.bytes != null)
            {
                PatchManager.Load(new MemoryStream(patch.Result.bytes));
                PatchHolder();
            }
#endif
            callback.Invoke();
        }
    }

    [IFix.Patch]
    static void PatchHolder()
    {
        Debug.LogError("PatchHolder");
    }
}