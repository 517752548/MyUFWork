using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ClassicLevelEntity
{
    public int ID;
    //public string Description;
    public string SolutionWord;
    public int ProbabilityID; 
    public List<ClassicQuestionEntity> Questions;
    public string SolutionCardID;
    public bool IsHardLevel;
    public KnowledgeCardEntity _SolutionCard { get; set; }

    private int maxCard = 0;
    private int requestCount = 0;
    private Action<bool> loadImageBack = null;

    // public async void LoadImage(Action<bool> successful)
    // {
    //     for (int i = 0; i < Questions.Count; i++)
    //     {
    //         if (!string.IsNullOrEmpty(Questions[i].SpriteName))
    //         {
    //             Questions[i].ImageSprite = await Addressables.LoadAssetAsync<Sprite>(Questions[i].SpriteName);
    //         }
    //     }
    //     successful.Invoke(true);
    // }
    public async void LoadLocalImage(Action<bool> ok)
    {
        for (int i = 0; i < Questions.Count; i++)
        {
            if (!string.IsNullOrEmpty(Questions[i].SpriteName))
            {
              await Questions[i].LoadLocalImage(LoadOnLineFinsih);
            }
        }
        ok?.Invoke(true);
    }
    public void LoadOnLineImage(Action<bool> ok)
    {
        this.loadImageBack = ok;
        for (int i = 0; i < Questions.Count; i++)
        {
            if (!string.IsNullOrEmpty(Questions[i].SpriteName))
            {
                requestCount++;
            }
        }
        for (int i = 0; i < Questions.Count; i++)
        {
            if (!string.IsNullOrEmpty(Questions[i].SpriteName))
            {
                Questions[i].LoadImage(LoadOnLineFinsih);
            }
        }
    }

    private void LoadOnLineFinsih(bool ok)
    {
        if (ok)
        {
            requestCount--;
            if (requestCount == 0)
            {
                loadImageBack.Invoke(true);
            }
        }
        else
        {
            loadImageBack.Invoke(false);
        }
    }

    // private void LoadKnowledgeCard(int index,Action<bool> loadCallback)
    // {
    //     Addressables.LoadAssetAsync<KnowledgeCardEntity>($"Card_{Questions[index].CardID}.asset").Completed +=
    //         op =>
    //         {
    //             if (op.Status == AsyncOperationStatus.Succeeded)
    //             {
    //                 maxCard--;
    //                 Questions[index]._Card = op.Result;
    //                 if (maxCard == 0)
    //                 {
    //                     loadCallback.Invoke(true);
    //                 }
    //             }
    //             else
    //             {
    //                 loadCallback.Invoke(false);
    //             }
    //         };
    // }
}
