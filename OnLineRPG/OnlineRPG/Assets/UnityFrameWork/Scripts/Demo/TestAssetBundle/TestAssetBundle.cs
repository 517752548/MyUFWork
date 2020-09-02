using System;
using System.Collections;
using BetaFramework;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class TestAssetBundle : MonoBehaviour
{
    public AssetReference refrance;
    private AsyncOperationHandle<TextAsset> txtr;
    private void Start()
    { 
        txtr = refrance.LoadAssetAsync<TextAsset>();
        StartCoroutine(load());
    }

    IEnumerator load()
    {
        while (!txtr.IsDone)
        {
            yield return new WaitForSeconds(0.5f);
        }
        //Debug.LogError(txtr.Result.text);
    }
    public void LoadIcon()
    {
        for (int i = 1; i < 10; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                StringBuilder url = new StringBuilder();
                url.AppendFormat("png_icon_{0}_{1}", i, j);

                ResourceManager.LoadAsync<Sprite>(url.ToString(),
                    (Sprite tex) =>
                    {
                        Debug.LogError(tex.name + " load success");
                    });
            }
        }
    }

    public void OnLoad()
    {
        //ModuleManager.FindModule<BetaFramework.ResourceManager>().LoadAssetAsync<GameObject>(AssetName, BundleName, false, OnLoadSuccess);
    }

    public void CheckUpdate()
    {
    }

    public void ReadBundle()
    {
        string path = Application.persistentDataPath + "/config/6.unity3d";
        Debug.LogError(path);
        if (File.Exists(path))
        {
            Debug.LogError("the file is exist");
        }
        //ModuleManager.FindModule<BetaFramework.ResourceManager>().LoadAssetAsync<TextAsset>("6", "config/6.unity3d", false, (id, text) =>
        //{
        //    Debug.LogError(text.ToString());
        //});
    }

    public void ReadWordLibBundle()
    {
        //var fileName = string.Format(Const.LevelText, 11, 1);
        //var path = string.Format("{0}/{1}", Const.LevelFolder, fileName);

        //ResourceManager.LoadAssetAsync<TextAsset>(fileName, path, false, (id, textAsset) =>
        //{
        //    Debug.LogError(textAsset.text);
        //    //var subWordLayout = JsonConvert.DeserializeObject<SubWordLayout>(textAsset.text);
        //});
    }

    private void OnLoadSuccess(int id, GameObject obj)
    {
        GameObject.Instantiate(obj, Vector3.zero, Quaternion.identity);
    }
}