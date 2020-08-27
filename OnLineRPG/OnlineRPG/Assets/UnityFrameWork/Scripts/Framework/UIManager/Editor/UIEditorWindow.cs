using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BetaFramework;
using ExcelConverter.Excel.Editor;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

public class UIEditorWindow : EditorWindow
{
    UIManager m_UIManager;
    private GameObject uimanager;
    UILayerManager m_UILayerManager;

    [MenuItem("Framework/UICreatTool", priority = 600)]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(UIEditorWindow));
    }


    void OnEnable()
    {
        uimanager = GameObject.Find("UIManager");

        if (uimanager)
        {
            m_UILayerManager = uimanager.GetComponent<UILayerManager>();
        }


        FindAllUI();
    }

    void OnGUI()
    {
        titleContent.text = "UI编辑器";

        EditorGUILayout.BeginVertical();

        UIManagerGUI();


        CreateUIGUI();

        CreatUIExcel();

        EditorGUILayout.EndVertical();
    }

    void OnSelectionChange()
    {
        base.Repaint();
    }

    //当工程改变时
    void OnProjectChange()
    {
        FindAllUI();
    }

    #region UIManager

    bool isFoldUImanager = false;
    public Vector2 m_referenceResolution = new Vector2(960, 640);
    public CanvasScaler.ScreenMatchMode m_MatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;

    public bool m_isOnlyUICamera = false;
    public bool m_isVertical = false;

    void UIManagerGUI()
    {
        EditorGUI.indentLevel = 0;
        isFoldUImanager = EditorGUILayout.Foldout(isFoldUImanager, "UIManager:");
        if (isFoldUImanager)
        {
            EditorGUI.indentLevel = 1;
            m_referenceResolution = EditorGUILayout.Vector2Field("参考分辨率", m_referenceResolution);
            m_isOnlyUICamera = EditorGUILayout.Toggle("只有一个UI摄像机", m_isOnlyUICamera);
            m_isVertical = EditorGUILayout.Toggle("是否竖屏", m_isVertical);

            if (GUILayout.Button("创建UIManager"))
            {
                UICreateService.CreatUIManager(m_referenceResolution, m_MatchMode, m_isOnlyUICamera, m_isVertical);
            }

            CreateUICameraGUI();
        }
    }

    #region CreateUICamera

    bool isCreateUICamera = false;
    string cameraKey;
    float cameraDepth = 1;

    void CreateUICameraGUI()
    {
        isCreateUICamera = EditorGUILayout.Foldout(isCreateUICamera, "CreateUICamera:");
        if (isCreateUICamera)
        {
            EditorGUI.indentLevel = 2;
            cameraKey = EditorGUILayout.TextField("Camera Key", cameraKey);
            cameraDepth = EditorGUILayout.FloatField("Camera Depth", cameraDepth);

            if (cameraKey != "")
            {
                if (GUILayout.Button("CreateUICamera"))
                {
                    UICreateService.CreateUICamera(uimanager, cameraKey, cameraDepth, m_referenceResolution,
                        m_MatchMode, m_isOnlyUICamera, m_isVertical);
                    cameraKey = "";
                }
            }
            else
            {
                EditorGUILayout.LabelField("Camera Key 不能为空");
            }
        }
    }

    #endregion

    #endregion

    #region createUI

    bool isAutoCreatePrefab = true;
    bool isFoldCreateUI = false;
    private bool isCreatUIExcel = false;
    string m_UIname = "";
    int m_UICameraKeyIndex = 0;
    string[] cameraKeyList;
    UIType m_UIType = UIType.Normal;

    void CreateUIGUI()
    {
        EditorGUI.indentLevel = 0;
        isFoldCreateUI = EditorGUILayout.Foldout(isFoldCreateUI, "创建UI:");

        if (isFoldCreateUI)
        {
            cameraKeyList = UIManager.GetCameraNames();

            EditorGUI.indentLevel = 1;
            EditorGUILayout.LabelField("提示： 脚本和 UI 名称会自动添加Window后缀");
            m_UIname = EditorGUILayout.TextField("UI Name:", m_UIname);

            m_UICameraKeyIndex = EditorGUILayout.Popup("Camera", m_UICameraKeyIndex, cameraKeyList);

            m_UIType = (UIType) EditorGUILayout.EnumPopup("UI Type:", m_UIType);


            isAutoCreatePrefab = EditorGUILayout.Toggle("自动生成 Prefab", isAutoCreatePrefab);

            if (m_UIname != "")
            {
                string l_nameTmp = m_UIname + "Window";

                Type l_typeTmp = EditorTool.GetType(l_nameTmp);
                if (l_typeTmp != null)
                {
                    if (l_typeTmp.BaseType.Equals(typeof(UIWindowBase)))
                    {
                        if (GUILayout.Button("创建UI"))
                        {
                            UICreateService.CreatUI(l_nameTmp, cameraKeyList[m_UICameraKeyIndex], m_UIType,
                                m_UILayerManager, isAutoCreatePrefab);
                            m_UIname = "";
                        }
                    }
                    else
                    {
                        EditorGUILayout.LabelField("该类没有继承UIWindowBase");
                    }
                }
                else
                {
                    if (GUILayout.Button("创建UI脚本"))
                    {
                        UICreateService.CreatUIScript(l_nameTmp);
                    }
                }
            }
        }
    }

    #endregion

    #region UITemplate

    bool isFoldUITemplate = false;

    #endregion

    #region UIStyle

    bool isFoldUIStyle = false;

    #endregion

    #region UITool

    bool isFoldUITool = false;

    void UIToolGUI()
    {
        EditorGUI.indentLevel = 0;
        isFoldUITool = EditorGUILayout.Foldout(isFoldUImanager, "UITool:");
        if (isFoldUITool)
        {
            EditorGUI.indentLevel = 1;

            if (GUILayout.Button("重设UI sortLayer"))
            {
                ResetUISortLayer();
            }

            if (GUILayout.Button("清除UI sortLayer"))
            {
                CleanUISortLayer();
            }
        }
    }

    void CleanUISortLayer()
    {
    }

    void ResetUISortLayer()
    {
    }

    #endregion

    #region UI

    //所有UI预设
    public static Dictionary<string, GameObject> allUIPrefab;


    /// <summary>
    /// 获取到所有的UIprefab
    /// </summary>
    public void FindAllUI()
    {
        allUIPrefab = new Dictionary<string, GameObject>();
        FindAllUIResources(Application.dataPath + "/" + "AssetsPackage/UI");
    }

    //读取“Resources/UI”目录下所有的UI预设
    public void FindAllUIResources(string path)
    {
        string[] allUIPrefabName = Directory.GetFiles(path);
        foreach (var item in allUIPrefabName)
        {
            string oneUIPrefabName = FileTool.GetFileNameByPath(item);
            if (item.EndsWith(".prefab"))
            {
                string oneUIPrefabPsth = path + "/" + oneUIPrefabName;
                allUIPrefab.Add(oneUIPrefabName,
                    AssetDatabase.LoadAssetAtPath("Assets/" + oneUIPrefabPsth, typeof(GameObject)) as GameObject);
            }
        }

        string[] dires = Directory.GetDirectories(path);

        for (int i = 0; i < dires.Length; i++)
        {
            FindAllUIResources(dires[i]);
        }
    }

    #endregion

    #region CreatUIExcel

    //private bool isFindFile = false;
    private string[] folders = null;
    private Dictionary<string, string[]> files = new Dictionary<string, string[]>();
    private Vector2 scrollVe2;
    private Vector2 buttonVe2;
    private static ExcelData m_ExcelData = null;

    void CreatUIExcel()
    {
        //SaveKeyToExcel
        isCreatUIExcel = EditorGUILayout.Foldout(isCreatUIExcel, "创建UI Excel:");
        if (isCreatUIExcel)
        {
            EditorGUILayout.BeginVertical();
//            if (!isFindFile)
//            {
//                isFindFile = true;
//                 folders = PathUtils.GetDirectorys("Assets/AssetsPackage/UI/");
//                 for (int i = 0; i < folders.Length; i++)
//                 {
//                     files.Add(folders[i],PathUtils.GetDirectoryFileNames(folders[i], new[] {".prefab"}));
//                 }
//            }
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("默认资源名");
            GUILayout.Label("Bundle名");
            GUILayout.Label("资源名");
            EditorGUILayout.EndHorizontal();
            scrollVe2 = EditorGUILayout.BeginScrollView(scrollVe2);
            foreach (string key in files.Keys)
            {
                for (int i = 0; i < files[key].Length; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.Space();
                    GUILayout.Label(key);
                    GUILayout.Label("ui/" + key.ToLower().Replace("Assets/AssetsPackage/UI/".ToLower(), "") + "/" +
                                    files[key][i]);
                    GUILayout.Label(files[key][i]);
                    EditorGUILayout.EndHorizontal();
                }
            }
//            for (int i = 0; i < folders.Length; i++)
//            {
//                string[] files = PathUtils.GetDirectoryFileNames(folders[i], new[] {".prefab"});
//                for (int j = 0; j < files.Length; j++)
//                {
//                    EditorGUILayout.BeginHorizontal();
//                    EditorGUILayout.Space();
//                    GUILayout.Label(folders[i]);
//                    GUILayout.Label("ui/" + folders[i].ToLower().Replace("Assets/AssetsPackage/UI/".ToLower(),"") + "/" + files[j] + ".unity3d");
//                    GUILayout.Label(files[j]);
//                    EditorGUILayout.EndHorizontal();
//                    //EditorGUILayout.TextField(folders[i]);
//                }
//            }

            EditorGUILayout.EndScrollView();
            if (GUILayout.Button("读取目录"))
            {
                folders = PathUtils.GetDirectorys("Assets/AssetsPackage/UI/");
                files.Clear();
                for (int i = 0; i < folders.Length; i++)
                {
                    files.Add(folders[i], PathUtils.GetDirectoryFileNames(folders[i], new[] {".prefab"}));
                }
            }

            if (GUILayout.Button("生成Excel"))
            {
                try
                {
                    //ExcelHelper.CreateExcel("Assets/AssetsPackage/Config/UIConfig.xls");
                    string path = Application.dataPath + "/Disign/Config/UI.xls";
                    FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
                    IWorkbook book;
                    string extension = Path.GetExtension(path);

                    if (extension.Equals(".xls"))
                    {
                        book = new HSSFWorkbook(fs);
                    }
                    else
                    {
                        book = new XSSFWorkbook(fs);
                    }

                    //ExcelData data = (ExcelReader.GetSingleExcelData(path))[0];
                    //ISheet sheet = book.GetSheet(data.SheetName);
                    //if (sheet == null)
                    //{
                    //    sheet = book.CreateSheet(data.SheetName);
                    //}

                    //StringBuilder build = new StringBuilder();

                    //foreach (string key in files.Keys)
                    //{
                    //    for (int i = 0; i < files[key].Length; i++)
                    //    {

                    //        IRow rows = sheet.CreateRow(sheet.LastRowNum + 1);

                    //        rows.CreateCell(0).SetCellValue(files[key][i]);
                    //        rows.CreateCell(1).SetCellValue((
                    //            "ui/" + key.ToLower().Replace("Assets/AssetsPackage/UI/".ToLower(), "") + "/" +
                    //            files[key][i]).ToLower());
                    //        rows.CreateCell(2).SetCellValue(files[key][i].ToLower());
                    //        build.AppendLine(string.Format("Public const string {0} = \"{1}\";",files[key][i],files[key][i]));
                    //    }
                    //}

                    //FileUtils.CreateTextFile("Assets/AssetsPackage/UI/UI.txt", build.ToString());
                    //FileStream fs2 = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    //book.Write(fs2);
                    //fs2.Close();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }

            EditorGUILayout.EndVertical();
        }
    }

    #endregion
}