using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LocalBackgroundEffectList : ScriptableObject
{
    [SerializeField]
    public List<LocalBackgroundEffectData> ListEffect = new List<LocalBackgroundEffectData>();

    public string GetEffectNameByLevelId(string levelId)
    {
        for (int i = 0; i < ListEffect.Count; i++)
        {
            if (ListEffect[i].LevelId.Equals(levelId))
            {
                return ListEffect[i].EffectName;
            }
        }

        return "";
    }
}