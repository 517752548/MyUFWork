using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Xml;

public class JsonToAssetsWindow : EditorWindow
{
    public static string ConfigPath = "Assets/PKResources/Local/Config/";
    public static string MapDataPath = "Assets/PKResources/Local/Level/";
    private Vector2 _scroll = new Vector2();
    private Dictionary<string, string> _businesstexts = new Dictionary<string, string>();
    [MenuItem("Tools/JsonToAssets")]
    public static void ShowWindow()
    {
        EditorWindow editorWindow = GetWindow(typeof(JsonToAssetsWindow));
        editorWindow.autoRepaintOnSceneChange = true;
        editorWindow.Show();
        editorWindow.titleContent = new GUIContent("json转换成Assets");
    }

    private void OnGUI()
    {
        GUILayout.Space(20);


        if (GUILayout.Button("背景特效配置转换"))
        {
            ConvertConfig<LocalBackgroundEffectList>("bgeffect");
        }

        if (GUILayout.Button("蝴蝶配置转换"))
        {

        }

        if (GUILayout.Button("DailyQuestEasy配置转换"))
        {
            ConvertQuestConfig("DailyQuestEasy");
        }

        if (GUILayout.Button("Quests配置转换"))
        {
            ConvertQuestConfig("Quests");
        }
        
//        if (GUILayout.Button("锦标赛默认名字配置转换"))
//        {
//            ConvertConfig<NamePool>("names");
//        }

        if (GUILayout.Button("转换英语多语言配置"))
        {
            ConvertLanguageConfig("EN_Google Sheets");
        }

        if (GUILayout.Button("转换德语多语言配置"))
        {
            ConvertLanguageConfig("De_Google Sheets");
        }

        if (GUILayout.Button("检查词库错误"))
        {
            CheckGameLevelError();
        }

        DrawBusinesssContent();
        DropJsonAreaGUI();
    }

    static void ConvertConfig<T>(string filename) where T: ScriptableObject
    {
        try
        {
            string str = File.ReadAllText(Application.dataPath + string.Format("/Word/Config/{0}.txt", filename));
            T list = JsonConvert.DeserializeObject<T>(str);
            T asset = ScriptableObject.CreateInstance<T>();
            asset = list;
            AssetDatabase.CreateAsset(asset, ConfigPath + string.Format("{0}.asset", filename));
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    static void ConvertMapConfig<T>(string filename) where T : ScriptableObject
    {
        try
        {
            string str = File.ReadAllText(Application.dataPath + string.Format("/Word/Config/{0}.txt", filename));
            T list = JsonConvert.DeserializeObject<T>(str);
            T asset = ScriptableObject.CreateInstance<T>();
            asset = list;
            AssetDatabase.CreateAsset(asset, MapDataPath + string.Format("{0}.asset", filename));
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    static void ConvertQuestConfig(string filename) 
    {
        //try
        //{
        //    string str = File.ReadAllText(Application.dataPath + string.Format("/Word/Config/{0}.txt", filename));
        //    List<List<QuestItem>> list = JsonConvert.DeserializeObject<List<List<QuestItem>>>(str);
        //    QuestItemObject asset = ScriptableObject.CreateInstance<QuestItemObject>();
        //    asset.questItems = list;
        //    AssetDatabase.CreateAsset(asset, ConfigPath + string.Format("{0}.asset", filename));
        //    AssetDatabase.SaveAssets();

        //    EditorUtility.FocusProjectWindow();
        //    Selection.activeObject = asset;
        //}
        //catch (Exception ex)
        //{
        //    Debug.LogException(ex);
        //}
    }

    static void ConvertLanguageConfig(string fileName)
    {
        string str = File.ReadAllText(Application.dataPath + "/Disign/Config/" + fileName + ".xml");

        if (str != "")
        {
            LanguageDataObject languageDataObject = new LanguageDataObject();
            using (XmlReader reader = XmlReader.Create(new StringReader(str)))
            {
                while (reader.ReadToFollowing("entry"))
                {
                    reader.MoveToFirstAttribute();
                    string tag = reader.Value;
                    reader.MoveToElement();
                    string data = reader.ReadElementContentAsString().Trim();
                    data = data.UnescapeXML();

                    languageDataObject.Add(tag, data);
                }
            }

            AssetDatabase.CreateAsset(languageDataObject, "Assets/AssetsPackage/Config/" + string.Format("{0}.asset", fileName));
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = languageDataObject;
        }
    }


    private void DrawBusinesssContent()
    {
        GUILayout.Space(10);

        _scroll = GUILayout.BeginScrollView(_scroll);

        List<string> removeList = new List<string>();

        foreach (string str in _businesstexts.Keys)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(str);

            if (GUILayout.Button("x"))
            {
                removeList.Add(str);
            }
            GUILayout.EndHorizontal();
        }

        for (int i = 0; i < removeList.Count; i++)
        {
            _businesstexts.Remove(removeList[i]);
        }

        removeList.Clear();

        GUILayout.EndScrollView();

        if (_businesstexts.Count <= 0) return;


        if (GUILayout.Button("清空所有"))
        {
            _businesstexts.Clear();
        }

        GUILayout.Space(20);
    }


    public void DropJsonAreaGUI()
    {
        GUILayout.Space(30);

        Event evt = Event.current;
        Rect drop_area = GUILayoutUtility.GetRect(0.0f, 50.0f, GUILayout.ExpandWidth(true));
        GUI.Box(drop_area, "把商业化配置文件拖拽到这儿.");

        switch (evt.type)
        {
            case EventType.DragUpdated:
            case EventType.DragPerform:
                if (!drop_area.Contains(evt.mousePosition))
                    return;

                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                if (evt.type == EventType.DragPerform)
                {
                    DragAndDrop.AcceptDrag();

                    _businesstexts.Clear();

                    int i = 0;
                    foreach (UnityEngine.Object dragged_object in DragAndDrop.objectReferences)
                    {
                        if (!DragAndDrop.paths[i].Contains(".txt"))
                            return;

                        try
                        {
                            if (EditorUtility.DisplayCancelableProgressBar("打开商业化文件", string.Format("正在打开{0}", dragged_object.name),
                                                                   (float)((float)i / (DragAndDrop.objectReferences.Length - 1))))
                            {
                                break;
                            }

                            string str = File.ReadAllText(DragAndDrop.paths[i]);
                            if (!_businesstexts.ContainsKey(dragged_object.name))
                            {
                                _businesstexts.Add(dragged_object.name, str);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.LogException(ex);
                        }


                        i++;

                    }

                    EditorUtility.ClearProgressBar();
                }
                break;
        }
    }

    private void CheckGameLevelError()
    {
        string path = Application.dataPath + "/PKResources/Local/Level/";
        string[] names = Directory.GetFiles(path);

        int i = 0;
		int k = 0;
        foreach (string filename in names)
        {
            string ext = Path.GetExtension(filename);
            if (ext.Equals(".meta") || ext.Equals(".asset")) continue;

            string str = File.ReadAllText(filename);

            var subWordLayout = JsonConvert.DeserializeObject<SubWordLayout>(str);
            if (i==0)
            {
                for (int j=0; j < 12; j ++)
                {
                    int index = subWordLayout.Layouts.FindIndex(x => x.level == j);
                    if (index == -1)
                    {
						k++;
                        Debug.LogError(filename + "缺少关卡 " + j);
                    }
                }
            }
            else
            {
                for (int j = 0; j < 18; j++)
                {
                    int index = subWordLayout.Layouts.FindIndex(x => x.level == j);
                    if (index == -1)
                    {
						k++;
                        Debug.LogError(filename + "缺少关卡 " + j);
                    }
                }
            }

            i++;
        }

		if (k == 0) {
			Debug.Log ("词库没有错误");		
		}
    }
}
