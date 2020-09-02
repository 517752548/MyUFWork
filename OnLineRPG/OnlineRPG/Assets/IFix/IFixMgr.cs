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
        var patch = await ResourceManager.LoadAsync<TextAsset>(patchName);
#if !UNITY_EDITOR
        if (patch != null && patch.bytes != null)
        {
            PatchManager.Load(new MemoryStream(patch.bytes));
            PatchHolder();
        }
#endif
        callback.Invoke();
    }

    [IFix.Patch]
    static void PatchHolder()
    {
        Debug.LogError("PatchHolder");
    }
}