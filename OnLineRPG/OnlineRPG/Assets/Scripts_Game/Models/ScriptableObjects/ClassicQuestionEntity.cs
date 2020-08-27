using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PathC;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

public class ClassicQuestionEntity : BaseQuestionEntity
{
    public int SolutionWordIndex;
    public List<int> PreLetterIndex;
    public Sprite ImageSprite;
    public string SpriteName;
    
    //public KnowledgeCardEntity _Card { get; set;}

    public void SetShowLettersStr(string letters)
    {
        PreLetterIndex = new List<int>();
        if (!string.IsNullOrEmpty(letters))
        {
            string[] arr = letters.Split('|');
            foreach (string index in arr)
            {
                PreLetterIndex.Add(int.Parse(index));
            }
        }
    }

    public void LoadImage(Action<bool> ok)
    {
        CommUtil.LoadCachedImage(SpriteName, (sp) =>
        {
            if (sp != null)
            {
                ImageSprite = sp;
                ok.Invoke(true);
            }
            else
            {
                Debug.Log(SpriteName);
                ok.Invoke(false);
            }
            
        });
    }
    public Task LoadLocalImage(Action<bool> ok)
    {
        var load =Addressables.LoadAssetAsync<Sprite>(SpriteName);
        load.Completed += op =>
        {
            ImageSprite = op.Result;
            ok?.Invoke(true);
        };
        return load.Task;
          
    }
}
