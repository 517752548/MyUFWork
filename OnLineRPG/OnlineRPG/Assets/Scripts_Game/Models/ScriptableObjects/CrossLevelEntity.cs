using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CrossLevelEntity
{
    public int ID;
    public int SizeRow, SizeCol;
    public int BeeCount;
    public int ProbabilityID; 
    public List<CrossQuestionEntity> Questions;

    private int requestCount = 0;
    private Action<bool> loadImageBack = null;
    
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

        if (requestCount == 0)
        {
            loadImageBack?.Invoke(true);
            return;
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
    
}
