using System;
using System.Collections;
using System.Collections.Generic;
using PathC;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

public class KnowledgeCardEntity
{
    public string ID;
    public string CardTheme;
    public string Description;
    public string Story;
    public int SeriesID = 1;
    public Sprite Image;
    public string ImageFileName { get; set; }
    
    public void LoadImage(Action<bool> ok,bool usethread = false)
    {
        CommUtil.LoadCachedImage(ImageFileName, sp =>
        {
            if (sp != null)
            {
                Image = sp;
                ok.Invoke(true);
            }
            else
            {
                Debug.Log(ImageFileName);
                ok.Invoke(false);
            }
        },usethread);
        return;
    }

    public void LoadLocalImage(Action<bool> ok)
    {
        Addressables.LoadAssetAsync<Sprite>(ImageFileName).Completed += op =>
        {
            Image = op.Result;
            ok?.Invoke(true);
        };
    }
}
