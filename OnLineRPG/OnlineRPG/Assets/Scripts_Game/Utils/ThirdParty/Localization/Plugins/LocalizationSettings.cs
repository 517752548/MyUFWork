using System;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class LocalizationSettings : ScriptableObject
{
    public string[] sheetTitles;

    public bool useSystemLanguagePerDefault = true;
    public string defaultLangCode = "DE";
#if UNITY_EDITOR
    public List<LanguageItem> LanguageItems;
#endif
    public GameObject[] texts;
    public UnityEngine.Object MainFile;



    //GENERAL
    public static LanguageCode GetLanguageEnum(string langCode)
    {
        langCode = langCode.ToUpper();
        foreach (LanguageCode item in Enum.GetValues(typeof(LanguageCode)))
        {
            if (item + "" == langCode)
            {
                return item;
            }
        }
        BetaFramework.LoggerHelper.Error("ERORR: There is no language: [" + langCode + "]");
        return LanguageCode.EN;
    }
    [Serializable]
    public class LanguageItem
    {
        public string Name;
        public UnityEngine.Object file;
        public Font font;

    }





}
