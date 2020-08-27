using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

[CustomEditor(typeof (LocalizationSettings))]
public class LocalizationSettingsEditor : Editor
{
    private LocalizationSettings localizationSettings;
    private  string path = "Assets/MultiLanguage/";
    private string currentLanguage;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if (GUILayout.Button("切换语言", GUILayout.Width(150)))
        {
            BetaFramework.LoggerHelper.Log("切换语言");
            ChangeLanguage();
        }
        EditorGUILayout.Space();
        
        GUILayout.Label("当前项目语言是：" + currentLanguage);
        GUILayout.Label("↓");
        EditorGUILayout.Space();
        
        //GUILayout.Box("使用说明:",GUILayout.Width(260));
    }


    private void ChangeLanguage()
    {
        if (localizationSettings == null)
        {
           // localizationSettings = GameObject.FindObjectOfType<LocalizationSettings>();
            localizationSettings = target as LocalizationSettings;
        }
        BetaFramework.LoggerHelper.Log("ChangeLanguage");
        //localizationSettings.LanguageItems
//        foreach (LocalizationSettings.LanguageItem item in localizationSettings.LanguageItems)
//        {
//            if (item.Name.Contains(localizationSettings.defaultLangCode))
//            {
//                CopyFile(localizationSettings.LanguageItems[0].file, localizationSettings.MainFile);
//                ChangeFont(item);
//            }
//        }
        
    }

    private void CopyFile(UnityEngine.Object from,UnityEngine.Object to)
    {
        path = "Assets/MultiLanguage/" + localizationSettings.defaultLangCode + "/";
        BetaFramework.LoggerHelper.Log(path + from.name);
        if (Directory.Exists(path + from.name))
        {
            BetaFramework.LoggerHelper.Log("cunzai");
            DirectoryInfo direction = new DirectoryInfo(path + from.name);
            FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);
            BetaFramework.LoggerHelper.Log(files.Length);
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.EndsWith(".meta"))
                {
                    continue;
                }
                 File.Copy(files[i].FullName, GetTargetFolderName(files[i].FullName), true);
             // BetaFramework.LoggerHelper.Log(GetTargetFolderName(files[i].FullName));  //GetTargetFolderName(files[i].FullName);
            }
            currentLanguage = localizationSettings.defaultLangCode;
        }
        else
        {
            BetaFramework.LoggerHelper.Log("文件夹不存在");
        }
        
    }

    private string GetTargetFolderName(string str)
    {
        return str.Replace(localizationSettings.defaultLangCode, "Main");
    }

    private void ChangeFont(LocalizationSettings.LanguageItem item)
    {
        foreach (GameObject gam in localizationSettings.texts)
        {
            gam.GetComponent<Text>().font = item.font;
            gam.GetComponent<Text>().fontSize = 12;

        }
    }
}
