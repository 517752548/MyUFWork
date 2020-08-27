using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LanguageDataObject : ScriptableObject
{
    [SerializeField]
    public List<LanguageEntity> Data = new List<LanguageEntity>();

    public void Add(string key, string value)
    {
        LanguageEntity languageEntity = new LanguageEntity();
        languageEntity.Key = key;
        languageEntity.Value = value;

        Data.Add(languageEntity);
    }
}

[Serializable]
public struct LanguageEntity
{
    public string Key;
    public string Value;
}