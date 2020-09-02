using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

public class ResourceManager
{
    static Dictionary<string, Task> resDic = new Dictionary<string, Task>();

    public static void Preload<T>(List<string> resList, Action<Dictionary<string, T>> callBack)
    {
        var info = new AssetsLoadInfo<T>(resList, callBack);
        info.StartLoad();
    }
    public static async void LoadAsync<T>(string assetAddress, Action<T> callback, bool persistent = false) where T : Object
    {
        T result = await LoadAsync<T>(assetAddress, persistent);
        callback(result);
    }

    public static async Task<T> LoadAsync<T>(string assetAddress, bool persistent = false) where T : Object
    {
        Task taskObj;
        if (resDic.TryGetValue(assetAddress, out taskObj))
        {
            if (taskObj.IsFaulted)
            {
                Addressables.Release(taskObj);
                resDic.Remove(assetAddress);
            }
            else
            {
                if (!taskObj.IsCompleted)
                {
                    await taskObj;
                }
                Task<T> task = taskObj as Task<T>;
                return task.Result;
            }
        }
        var tTask = Addressables.LoadAssetAsync<T>(assetAddress).Task;
        if (!persistent)
        {
            resDic.Add(assetAddress, tTask);
        }
        return await tTask;
    }

    public static void ReleaseAll()
    {
        foreach (var item in resDic)
        {
            var task = item.Value;
            Addressables.Release(task);
        }
        resDic.Clear();
    }
}
