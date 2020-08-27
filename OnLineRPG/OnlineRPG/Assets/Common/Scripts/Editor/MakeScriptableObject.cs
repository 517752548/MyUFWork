using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using Newtonsoft.Json;

public class MakeMyScriptableObject
{
    [MenuItem("Tools/MyTool/Create My Scriptable Object")]
    static void DoIt()
    {
        EditorGameLevel asset = ScriptableObject.CreateInstance<EditorGameLevel>();
        AssetDatabase.CreateAsset(asset, "Assets/MyScriptableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }

   
}