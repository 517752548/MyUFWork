using BetaFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using NPOI.SS.UserModel;

public class LevelExcelCheckImage : EditorWindow
{
    private const string AssetsPath_CardImage = "Assets/AssetsPackage/WordContent/KnowledgeCards/Images/";
    private ExcelReader m_ExcelReader;
    private string levelsPath;
    private List<List<ICell>> cardSheets;
    private string classicLevelExcelPathLocal;

    private Dictionary<string, string> imagePair = new Dictionary<string, string>();

    private List<string> knowledges = new List<string>();
    private bool show = false;
    private string imageName = "", imageName1 = "", imageName2 = "", imageName3 = "", imageName4 = "", imageName5 = "";
    [MenuItem("Tools/关卡文件监测")]
    public static void ShowWindow()
    {
        EditorWindow editorWindow = GetWindow(typeof(LevelExcelCheckImage));
        editorWindow.autoRepaintOnSceneChange = true;
        editorWindow.position = new Rect(50, 50, 800, 400);
        editorWindow.Show();
        editorWindow.titleContent = new GUIContent("关卡Excel检查");
    }

    private void OnEnable()
    {
        levelsPath = Application.dataPath + "/WordCody/Levels/";
        m_ExcelReader = new ExcelReader();
    }

    private void OnGUI()
    {
        GUILayout.Space(20);

        EditorGUILayout.BeginVertical();
        {
            ShowClassicLevelAreaLocal();
            if (show)
                ShowKnowledge(imageName,imageName1,imageName2,imageName3,imageName4,imageName5);
        }
        EditorGUILayout.EndVertical();
    }

    private void ShowClassicLevelAreaLocal()
    {
        GUILayout.Space(20);
        GUILayout.Label("检查");
        GUIStyle helpBoxStyle = EditorStyleUtils.GetHelpBoxStyle();
        EditorGUILayout.BeginVertical(helpBoxStyle);
        {
            GUIStyle textFieldStyle = EditorStyleUtils.GetTextFieldStyle();
            textFieldStyle.fontSize = 13;
            textFieldStyle.alignment = TextAnchor.MiddleLeft;

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.TextField(classicLevelExcelPathLocal, textFieldStyle, GUILayout.Width(600),
                    GUILayout.Height(30));
                // GUI.color = Color.green;
                if (GUILayout.Button("Choose Excel", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    classicLevelExcelPathLocal = EditorUtility.OpenFilePanel("Select Excel Path", levelsPath, "xlsx");
                    if (!string.IsNullOrEmpty(classicLevelExcelPathLocal))
                    {
                        Dictionary<string, List<List<ICell>>> sheets = m_ExcelReader.Load(classicLevelExcelPathLocal);
                        foreach (KeyValuePair<string, List<List<ICell>>> keyPair in sheets)
                        {
                            string sheetName = keyPair.Key;
                            if (sheetName.Equals("card"))
                            {
                                cardSheets = keyPair.Value;
                            }
                        }
                    }
                }

                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("检查", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    FindImages();
                    ConvertClassicLevel(cardSheets);
                    CheckPair();
                }
                if (GUILayout.Button("刷新", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    CheckNext();
                }
                GUILayout.Space(10);
                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }

    private void CheckNext()
    {
        if (knowledges.Count > 0)
        {
            string names = knowledges[0];
            List<SimilarData> similarDatas = new List<SimilarData>();
            foreach (string imagePairKey in imagePair.Keys)
            {
                float cimal = GetSimilarityWith(names, imagePairKey);
                similarDatas.Add(new SimilarData(){name = imagePairKey,similar = cimal});
            }

            similarDatas = similarDatas.OrderByDescending(x => x.similar).ToList();
            string name1 = "";
            if (similarDatas.Count > 1)
            {
                name1 = similarDatas[0].name;
            }
            string name2 = "";
            if (similarDatas.Count > 2)
            {
                name2 = similarDatas[1].name;
            }
            string name3 = "";
            if (similarDatas.Count > 3)
            {
                name3 = similarDatas[2].name;
            }
            string name4 = "";
            if (similarDatas.Count > 4)
            {
                name4 = similarDatas[3].name;
            }
            string name5 = "";
            if (similarDatas.Count > 5)
            {
                name5 = similarDatas[4].name;
            }
            imageName = names;
            imageName1 = name1;
            imageName2 = name2;
            imageName3 = name3;
            imageName4 = name4;
            imageName5 = name5;
            show = true;
        }
        else
        {
            show = false;
        }
    }
     private void ShowKnowledge(string name,string name1,string name2,string name3,string name4,string name5)
    {
        GUILayout.Space(20);
        GUILayout.Label(name);
        GUIStyle helpBoxStyle = EditorStyleUtils.GetHelpBoxStyle();
        EditorGUILayout.BeginVertical(helpBoxStyle);
        {
            GUIStyle textFieldStyle = EditorStyleUtils.GetTextFieldStyle();
            textFieldStyle.fontSize = 13;
            textFieldStyle.alignment = TextAnchor.MiddleLeft;

            EditorGUILayout.BeginHorizontal();
            {
                if(!string.IsNullOrEmpty(name1))
                if (GUILayout.Button(name1, GUILayout.Width(100), GUILayout.Height(30)))
                {
                    ChangeName(name,name1);
                    knowledges.Remove(name);
                    imagePair.Remove(name1);
                    CheckNext();
                }
                if(!string.IsNullOrEmpty(name2))
                if (GUILayout.Button(name2, GUILayout.Width(100), GUILayout.Height(30)))
                {
                    ChangeName(name,name2);
                    knowledges.Remove(name);
                    imagePair.Remove(name2);
                    CheckNext();
                }
                if(!string.IsNullOrEmpty(name3))
                if (GUILayout.Button(name3, GUILayout.Width(100), GUILayout.Height(30)))
                {
                    ChangeName(name,name3);
                    knowledges.Remove(name);
                    imagePair.Remove(name3);
                    CheckNext();
                }
                if(!string.IsNullOrEmpty(name4))
                    if (GUILayout.Button(name4, GUILayout.Width(100), GUILayout.Height(30)))
                    {
                        ChangeName(name,name4);
                        knowledges.Remove(name);
                        imagePair.Remove(name4);
                        CheckNext();
                    }
                if(!string.IsNullOrEmpty(name5))
                    if (GUILayout.Button(name5, GUILayout.Width(100), GUILayout.Height(30)))
                    {
                        ChangeName(name,name5);
                        knowledges.Remove(name);
                        imagePair.Remove(name5);
                        CheckNext();
                    }
                if (GUILayout.Button("跳过", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    knowledges.Remove(name);
                    CheckNext();
                }
                GUI.color = Color.white;
            }
            
            
        }
        EditorGUILayout.EndVertical();
    }

     private void ChangeName(string name,string oldname)
     {
         string filePath = string.Format("{2}/{0}/{1}_1.jpg", AssetsPath_CardImage,oldname,Application.dataPath.Replace("/Assets",""));
         string newFilePath = string.Format("{2}/{0}/{1}_1.jpg", AssetsPath_CardImage,name,Application.dataPath.Replace("/Assets",""));
         FileInfo file = new FileInfo(filePath);
         if (file.Exists)
         {
             File.Move(filePath,newFilePath);
         }
         else
         {
             Debug.LogError("文件不存在" + filePath);  
         }
     }
    private void FindImages()
    {
        imagePair.Clear();
        string[] images = Directory.GetFileSystemEntries(AssetsPath_CardImage);
        string name;
        string[] names;
        for (int i = 0; i < images.Length; i++)
        {
            name = images[i].Replace('\\', '/');
            names = name.Split('/');
            name = names[names.Length - 1];
            if (name.EndsWith(".jpg"))
            {
                imagePair.Add(name.Replace("_1.jpg",""), "0");//
            }
        }

    }

    private void ConvertClassicLevel(List<List<ICell>> cardSheet)
    {
        bool allIsRight = true;
        string msg = "";
        bool oldData = false;
        int rowIndex = 0;
        cardSheet.ForEach(row =>
        {
            if (rowIndex == 0)
            {
                rowIndex++;
                return;
            }

            string filename = GetStr(row, 2, "");
            if (!string.IsNullOrEmpty(filename))
            {
                knowledges.Add(filename.Trim().Replace(" ",""));
            }

        });

    }

    private void CheckPair()
    {
        List<string> needDelete = new List<string>();
        for (int i = 0; i < knowledges.Count; i++)
        {
            if (imagePair.ContainsKey(knowledges[i]))
            {
                imagePair.Remove(knowledges[i]);
                needDelete.Add(knowledges[i]);
            }
        }

        for (int i = 0; i < needDelete.Count; i++)
        {
            knowledges.Remove(needDelete[i]);
        }
        Debug.LogError(knowledges.Count);
        Debug.LogError(imagePair.Count);
    }
    public string GetStr(List<ICell> row, int col, string defVal = null)
    {
        ICell cell = col > row.Count ? null : row[col - 1];
        if (cell == null)
            return defVal;
        if (cell.CellType != CellType.String)
            return defVal;
        string str = cell.StringCellValue;
        if (string.IsNullOrEmpty(str))
            return defVal;
        str = str.Trim();
        return str;
    }

    /// <summary>
    /// 获取两个字符串的相似度
    /// </summary>
    /// <param name=”sourceString”>第一个字符串</param>
    /// <param name=”str”>第二个字符串</param>
    /// <returns></returns>
    public float GetSimilarityWith(string sourceString, string str)
    {
        float Kq = 2;
        float Kr = 1;
        float Ks = 1;

        char[] ss = sourceString.ToCharArray();
        char[] st = str.ToCharArray();

//获取交集数量
        int q = ss.Intersect(st).Count();
        int s = ss.Length - q;
        int r = st.Length - q;

        return Kq * q / (Kq * q + Kr * r + Ks * s);
    }
    
}

public class SimilarData
{
    public string name;
    public float similar;
    
}