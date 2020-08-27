using BetaFramework;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Aot;
using UnityEditor;
using UnityEngine;

public class LevelExcelToAssets : EditorWindow
{
    const string srcDir = "Assets/WordCody/Levels/";
    private const string AssetsPath_Map = "Assets/AssetsPackage/WordContent/Map/";
    private const string AssetsPath_StoryImage = "Assets/AssetsPackage/WordContent/Map/Images/";

    private const string AssetsPath_LevelOnLine = "Assets/AssetsPackage/WordContent/OnLine/Levels/";
    private const string AssetsPath_CardOnLine = "Assets/AssetsPackage/WordContent/OnLine/KnowledgeCards/";
    private const string AssetsPath_LevelLocal = "Assets/AssetsPackage/WordContent/LocalLevel/";
    private const string AssetsPath_CardLocal = "Assets/AssetsPackage/WordContent/LocalLevel/";

    private const string AssetsPath_CardImage = "Assets/AssetsPackage/WordContent/LocalLevel/";
    private const string AssetsPath_Daily = "Assets/AssetsPackage/WordContent/DailyWordLib/";
    private const string AssetLevelJson = "Levels/";
    private ExcelReader m_ExcelReader;
    private string levelsPath;

    private string classicMapExcelPathA = "";
    private string classicMapExcelPathB = "";
    private bool classicMapCoverAllA = false;
    private bool classicMapCoverAllB = false;
    private List<List<ICell>> mapSheet;
    private List<List<ICell>> packageSheet;
    private List<List<ICell>> VersionSheet;
    private Dictionary<int, string> solutionWordLevels = new Dictionary<int, string>();

    private string classicLevelExcelPathLocal = "";
    private bool classicLevelCoverAllLocal = false;
    private string classicLevelExcelPathOnLine = "";
    private bool classicLevelCoverAllOnLine = false;
    private List<List<ICell>> levelSheet, cardSheet;

    private string dailyLevelExcelPath = "";
    private bool dailyLevelCoverAll = false;
    private Dictionary<string, List<List<ICell>>> dailySheets;
    private Vector2 scrollPos;

    [MenuItem("Tools/关卡转换")]
    public static void ShowWindow()
    {
        EditorWindow editorWindow = GetWindow(typeof(LevelExcelToAssets));
        editorWindow.autoRepaintOnSceneChange = true;
        editorWindow.position = new Rect(50, 50, 800, 600);
        editorWindow.Show();
        editorWindow.titleContent = new GUIContent("关卡Excel转换成Assets");
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
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        {
            ShowExportBtn();
            ShowClassicMapAreaA();
            ShowClassicMapAreaB();
            ShowClassicLevelAreaLocal();
            ShowClassicLevelAreaOnLine();
            ShowDailyLevelArea();
        }
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
    }

    private void ShowExportBtn()
    {
        if (GUILayout.Button("一键导出", GUILayout.Width(100), GUILayout.Height(30)))
        {
            ExportStorys(Const.Android, "A", "A");
            ExportStorys(Const.Android, "B", "B");
            ExportStorys(Const.iOS, "", "");
            ExportLevels(Const.Android);
            ExportLevels(Const.iOS);
        }
        if (GUILayout.Button("一键导出精英关卡", GUILayout.Width(100), GUILayout.Height(30)))
        {
            ExportEliteLevels(Const.Android);
            ExportEliteLevels(Const.iOS);
        }
    }

    void ExportStorys(string platform, string searchExt, string ext)
    {
        var excelDir = $"Assets/WordCody/Levels/{platform}/";
        var excelPaths = Directory.GetFiles(excelDir, $"*_WorldConfig{searchExt}*.xlsx");
        foreach (var item in excelPaths)
        {
            Dictionary<string, List<List<ICell>>> sheets = m_ExcelReader.Load(item);
            mapSheet = sheets["World"];
            packageSheet = sheets["Package"];
            VersionSheet = sheets["Version"];
            ConvertClassicMap(true, $"{platform}_StoryConfig{ext}");
        }
    }
    void ExportLevels(string platform)
    {
        var excelDir = $"Assets/WordCody/Levels/{platform}/";
        var excelPaths = Directory.GetFiles(excelDir, $"{platform}_LocalLevels*.xlsx");
        foreach (var item in excelPaths)
        {
            Dictionary<string, List<List<ICell>>> sheets = m_ExcelReader.Load(item);
            levelSheet = sheets["level"];
            cardSheet = sheets["card"];
            CreatLevelJson(AssetsPath_LevelLocal, AssetsPath_CardLocal, true, platform);
            CreatCards(AssetsPath_LevelLocal, AssetsPath_CardLocal, true, platform);
        }
    }
    void ExportEliteLevels(string platform)
    {
        List<List<ICell>> level, question;
        var excelDir = $"Assets/WordCody/Levels/{platform}/EliteLevel/";
        string[] folders = Directory.GetDirectories(excelDir);
        for (int i = 0; i < folders.Length; i++)
        {
            string pathexcelDir = excelDir + folders[i] + "/";
            var excelPaths = Directory.GetFiles(folders[i], $"*.xlsx");
            foreach (var item in excelPaths)
            {
                Dictionary<string, List<List<ICell>>> sheets = m_ExcelReader.Load(item);
                level = sheets["level"];
                question = sheets["question"];
                CreatEliteLevelJson("EliteLevel/" + platform + "/" + item.Replace(excelDir,""), level,question);
            }
        }
        
    }
    private void ShowClassicMapAreaA()
    {
        GUILayout.Label("主线故事线A");
        GUIStyle helpBoxStyle = EditorStyleUtils.GetHelpBoxStyle();
        EditorGUILayout.BeginVertical(helpBoxStyle);
        {
            GUIStyle textFieldStyle = EditorStyleUtils.GetTextFieldStyle();
            textFieldStyle.fontSize = 13;
            textFieldStyle.alignment = TextAnchor.MiddleLeft;

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.TextField(classicMapExcelPathA, textFieldStyle, GUILayout.Width(600),
                    GUILayout.Height(30));
                // GUI.color = Color.green;
                if (GUILayout.Button("Choose Excel", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    classicMapExcelPathA = EditorUtility.OpenFilePanel("Select Excel Path", levelsPath, "xlsx");
                    if (!string.IsNullOrEmpty(classicMapExcelPathA))
                    {
                        Dictionary<string, List<List<ICell>>> sheets = m_ExcelReader.Load(classicMapExcelPathA);
                        foreach (KeyValuePair<string, List<List<ICell>>> keyPair in sheets)
                        {
                            string sheetName = keyPair.Key;
                            if (sheetName.Equals("World"))
                            {
                                mapSheet = keyPair.Value;
                            }
                            else if (sheetName.Equals("Package"))
                            {
                                packageSheet = keyPair.Value;
                            }
                            else if (sheetName.Equals("Version"))
                            {
                                VersionSheet = keyPair.Value;
                            }
                        }
                    }
                }

                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("转Assets", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    ConvertClassicMap(classicMapCoverAllA, $"{Const.Platform}_StoryConfigA");
                }

                GUILayout.Space(10);
                if (classicMapCoverAllA !=
                    EditorGUILayout.ToggleLeft("Cover All", classicMapCoverAllA, GUILayout.Height(20)))
                {
                    classicMapCoverAllA = !classicMapCoverAllA;
                }

                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }

    private void ShowClassicMapAreaB()
    {
        GUILayout.Label("主线故事线B");
        GUIStyle helpBoxStyle = EditorStyleUtils.GetHelpBoxStyle();
        EditorGUILayout.BeginVertical(helpBoxStyle);
        {
            GUIStyle textFieldStyle = EditorStyleUtils.GetTextFieldStyle();
            textFieldStyle.fontSize = 13;
            textFieldStyle.alignment = TextAnchor.MiddleLeft;

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.TextField(classicMapExcelPathB, textFieldStyle, GUILayout.Width(600),
                    GUILayout.Height(30));
                // GUI.color = Color.green;
                if (GUILayout.Button("Choose Excel", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    classicMapExcelPathB = EditorUtility.OpenFilePanel("Select Excel Path", levelsPath, "xlsx");
                    if (!string.IsNullOrEmpty(classicMapExcelPathB))
                    {
                        Dictionary<string, List<List<ICell>>> sheets = m_ExcelReader.Load(classicMapExcelPathB);
                        foreach (KeyValuePair<string, List<List<ICell>>> keyPair in sheets)
                        {
                            string sheetName = keyPair.Key;
                            if (sheetName.Equals("World"))
                            {
                                mapSheet = keyPair.Value;
                            }
                            else if (sheetName.Equals("Package"))
                            {
                                packageSheet = keyPair.Value;
                            }
                        }
                    }
                }

                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("转Assets", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    ConvertClassicMap(classicMapCoverAllB, $"{Const.Platform}_StoryConfigB");
                }

                GUILayout.Space(10);
                if (classicMapCoverAllB !=
                    EditorGUILayout.ToggleLeft("Cover All", classicMapCoverAllB, GUILayout.Height(20)))
                {
                    classicMapCoverAllB = !classicMapCoverAllB;
                }

                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }

    private void ShowClassicLevelAreaLocal()
    {
        GUILayout.Space(20);
        GUILayout.Label("先主线本地关卡");
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
                            if (sheetName.Equals("level"))
                            {
                                levelSheet = keyPair.Value;
                            }
                            else if (sheetName.Equals("card"))
                            {
                                cardSheet = keyPair.Value;
                            }
                        }
                    }
                }

                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("转Assets", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    CreatLevelJson(AssetsPath_LevelLocal, AssetsPath_CardLocal, true);
                    CreatCards(AssetsPath_LevelLocal, AssetsPath_CardLocal, true);
                    AssetDatabase.Refresh();
                    //ConvertClassicLevel(AssetsPath_LevelLocal, AssetsPath_CardLocal, classicLevelCoverAllLocal);
                    //ConvertLevel_New(AssetsPath_LevelLocal, AssetsPath_CardLocal, classicLevelCoverAllLocal);
                }

                GUILayout.Space(10);
                if (classicLevelCoverAllLocal !=
                    EditorGUILayout.ToggleLeft("Cover All", classicLevelCoverAllLocal, GUILayout.Height(20)))
                {
                    classicLevelCoverAllLocal = !classicLevelCoverAllLocal;
                }

                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }

    private void ShowClassicLevelAreaOnLine()
    {
        GUILayout.Space(20);
        GUILayout.Label("后主线线上关卡");
        GUIStyle helpBoxStyle = EditorStyleUtils.GetHelpBoxStyle();
        EditorGUILayout.BeginVertical(helpBoxStyle);
        {
            GUIStyle textFieldStyle = EditorStyleUtils.GetTextFieldStyle();
            textFieldStyle.fontSize = 13;
            textFieldStyle.alignment = TextAnchor.MiddleLeft;

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.TextField(classicLevelExcelPathOnLine, textFieldStyle, GUILayout.Width(600),
                    GUILayout.Height(30));
                // GUI.color = Color.green;
                if (GUILayout.Button("Choose Excel", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    classicLevelExcelPathOnLine = EditorUtility.OpenFilePanel("Select Excel Path", levelsPath, "xlsx");
                    if (!string.IsNullOrEmpty(classicLevelExcelPathOnLine))
                    {
                        Dictionary<string, List<List<ICell>>> sheets = m_ExcelReader.Load(classicLevelExcelPathOnLine);
                        foreach (KeyValuePair<string, List<List<ICell>>> keyPair in sheets)
                        {
                            string sheetName = keyPair.Key;
                            if (sheetName.Equals("level"))
                            {
                                levelSheet = keyPair.Value;
                            }
                            else if (sheetName.Equals("card"))
                            {
                                cardSheet = keyPair.Value;
                            }
                        }
                    }
                }

                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("转Assets", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    CreatLevelJson(AssetsPath_LevelLocal, AssetsPath_CardLocal, false);
                    CreatCards(AssetsPath_LevelLocal, AssetsPath_CardLocal, false);
                    //ConvertClassicLevel(AssetsPath_LevelOnLine, AssetsPath_CardOnLine, classicLevelCoverAllOnLine);
                    //ConvertLevel_New(AssetsPath_LevelOnLine, AssetsPath_CardOnLine, classicLevelCoverAllOnLine);
                }

                GUILayout.Space(10);
                if (classicLevelCoverAllOnLine !=
                    EditorGUILayout.ToggleLeft("Cover All", classicLevelCoverAllOnLine, GUILayout.Height(20)))
                {
                    classicLevelCoverAllOnLine = !classicLevelCoverAllOnLine;
                }

                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }

    private void ShowDailyLevelArea()
    {
        GUILayout.Space(20);
        GUILayout.Label("每日挑战词库");
        GUIStyle helpBoxStyle = EditorStyleUtils.GetHelpBoxStyle();
        EditorGUILayout.BeginVertical(helpBoxStyle);
        {
            GUIStyle textFieldStyle = EditorStyleUtils.GetTextFieldStyle();
            textFieldStyle.fontSize = 13;
            textFieldStyle.alignment = TextAnchor.MiddleLeft;

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.TextField(dailyLevelExcelPath, textFieldStyle, GUILayout.Width(600),
                    GUILayout.Height(30));
                // GUI.color = Color.green;
                if (GUILayout.Button("Choose Excel", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    dailyLevelExcelPath = EditorUtility.OpenFilePanel("Select Excel Path", levelsPath, "xlsx");
                    if (!string.IsNullOrEmpty(dailyLevelExcelPath))
                    {
                        dailySheets = m_ExcelReader.Load(dailyLevelExcelPath);
                    }
                }

                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("转Assets", GUILayout.Width(100), GUILayout.Height(30)))
                {
                    //ConvertDailyLevel();
                }

                GUILayout.Space(10);
                if (dailyLevelCoverAll !=
                    EditorGUILayout.ToggleLeft("Cover All", dailyLevelCoverAll, GUILayout.Height(20)))
                {
                    dailyLevelCoverAll = !dailyLevelCoverAll;
                }

                GUI.color = Color.white;
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }

    private void ConvertClassicMap(bool classicMapCoverAll, string fileName)
    {
        bool allIsRight = true;
        string msg = "";
        bool oldData = false;
        ClassicWorldContainer allWorlds = new ClassicWorldContainer()
        {
            dataList = new List<ClassicWorldEntity>(),
            ABTestBISymbel = VersionSheet[0][0].ToString()
        };
        allWorlds = CreateAsset(allWorlds, classicMapCoverAll, out oldData, AssetsPath_Map, fileName);
        allWorlds.dataList.Clear();
        ClassicWorldEntity world = null;
        int rowIndex = 0;
        List<ClassicSubWorldEntity> SubWorldList = new List<ClassicSubWorldEntity>();
        int subWorldBaseCol = 10;
        for (int i = 0; i < mapSheet.Count; i++)
        {
            if (rowIndex == 0)
            {
                rowIndex++;
                continue;
            }

            int id = GetInt(mapSheet[i], 1, -1);
            if (id >= 0)
            {
                world = new ClassicWorldEntity
                {
                    ID = id,
                    Name = GetStr(mapSheet[i], 2, ""),
                    HomeImage = GetStr(mapSheet[i], 3, ""),
                    HomeSmall = GetStr(mapSheet[i], 4, ""),
                    HomeMusic = GetStr(mapSheet[i], 5, ""),
                    BGMusic = GetStr(mapSheet[i], 6, ""),
                    WorldState = GetInt(mapSheet[i], 7, 0),
                    StoryEnd = GetStr(mapSheet[i], 8, ""),
                    SubWorldListString = ""
                };
                allWorlds.dataList.Add(world);
                world.name = "World" + world.ID;
                AssetDatabase.AddObjectToAsset(world, allWorlds);
            }

            if (GetInt(mapSheet[i], subWorldBaseCol, 0) <= 1)
            {
                SubWorldList.Clear();
            }

            ClassicSubWorldEntity subworld = new ClassicSubWorldEntity()
            {
                ID = GetInt(mapSheet[i], subWorldBaseCol, 0),
                Name = GetStr(mapSheet[i], subWorldBaseCol + 1, ""),
                //RewardID = GetInt(mapSheet[i], subWorldBaseCol + 2, 0),
                Packages = new List<ClassicPackage>(),
            };
            if (world.WorldState == 1)
            {
                int packageCount = GetInt(mapSheet[i], subWorldBaseCol + 3, 0);
                if (subworld.ID == 0 || packageCount == 0)
                {
                    allIsRight = false;
                    msg += $"World {world.ID} subworld {subworld.ID} package count {packageCount} error\n";
                }
                else
                {
                    int packageBaseCol = subWorldBaseCol + 4;
                    for (int packageCol = packageBaseCol; packageCol < packageBaseCol + packageCount; packageCol++)
                    {
                        int packageId = GetInt(mapSheet[i], packageCol, -1);
                        if (packageId <= 0)
                        {
                            allIsRight = false;
                            msg +=
                                $"World {world.ID} subworld {subworld.ID} package {packageCol - packageBaseCol + 1} ID {packageId} error\n";
                        }
                        else
                            subworld.Packages.Add(GetClassicPackage(packageId, ref allIsRight, ref msg));
                    }
                }
            }

            SubWorldList.Add(subworld);

            world.SubWorldListString = JsonConvert.SerializeObject(SubWorldList);
        }

        if (!allIsRight)
        {
            EditorUtility.DisplayDialog("Error", msg, "Ok");
        }
        else
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            EditorUtility.DisplayDialog("Success", "map excel data to asset successfully .", "OK");
        }
    }

    private ClassicPackage GetClassicPackage(int id, ref bool allIsRight, ref string msg)
    {
        var packageRow = packageSheet.Find(row => GetInt(row, 1, -1) == id);
        if (packageRow == null)
        {
            allIsRight = false;
            msg += $"package id {id} not found\n";
            return new ClassicPackage()
            {
                ID = 0,
                CardPieceMode = 0,
                CardID = "",
                CardLevelID = -1,
                LevelIDs = new List<int>()
            };
        }

        ClassicPackage pack = new ClassicPackage()
        {
            ID = id,
            Des1 = GetStr(packageRow, 2),
            Des2 = GetStr(packageRow, 3),
            CardPieceMode = GetInt(packageRow, 4, -1),
            CardID = GetStr(packageRow, 6, ""),
            CardLevelID = GetInt(packageRow, 7, -1),
            LevelIDs = new List<int>()
        };
        int packLevelCount = GetInt(packageRow, 5, 0) - 1;
        const int baseLevelCol = 8;
        for (int i = 0; i < packLevelCount; i++)
        {
            pack.LevelIDs.Add(GetInt(packageRow, baseLevelCol + i, -1));
        }

        if (!solutionWordLevels.ContainsKey(pack.CardLevelID))
            solutionWordLevels.Add(pack.CardLevelID, pack.CardID);

        return pack;
    }

    void CreatEliteLevelJson(string path,List<List<ICell>> level, List<List<ICell>> question)
    {
        CrossLevelEntity crosslevel = new CrossLevelEntity();
        crosslevel.ID = GetInt(level[1], 1,1);
        crosslevel.SizeRow = GetInt(level[1], 2,1);
        crosslevel.SizeCol = GetInt(level[1], 3,1);
        crosslevel.BeeCount = GetInt(level[1], 4,1);
        crosslevel.ProbabilityID = GetInt(level[1], 5,1);
        crosslevel.Questions = new List<CrossQuestionEntity>();
        int index = 0;
        question.ForEach(querstion =>
        {
            index++;
            if (index > 1)
            {
                CrossQuestionEntity crossquestion = new CrossQuestionEntity();
                crossquestion.Number = GetInt(querstion, 1, 1);
                crossquestion.Horizontal = GetStr(querstion, 2, "") == "True"?true:false;
                crossquestion.Row = GetInt(querstion, 3, 1);
                crossquestion.Col = GetInt(querstion, 4, 1);
                crossquestion.SpriteName = GetStr(querstion, 5, "");
                crossquestion.Answer = GetStr(querstion, 6, "");
                crossquestion.Question = GetStr(querstion, 7, "");
                crossquestion.CategoryID = GetInt(querstion, 8, 1);
                crossquestion.MaxAutoHint = GetInt(querstion, 9, -1);
                crossquestion.Priority = GetInt(querstion, 10, 1);
                crossquestion.SimiWords = GetStr(querstion, 11, "").Split(',').ToList();
                crossquestion.wordSpit = GetStr(querstion, 12, "");
                crosslevel.Questions.Add(crossquestion);
            }
            
        });
        FileUtils.CreateTextFile(Application.dataPath.Replace("Assets", path.Replace(".xlsx",".txt")),
            JsonConvert.SerializeObject(crosslevel));
    }
    public void CreatLevelJson(string Levelpath, string cardPath, bool local, string platform = null)
    {
        platform = platform ?? Const.Platform;
        bool allIsRight = true;
        string msg = "";
        int rowIndex = 0;
        ClassicLevelEntity _level = null;
        rowIndex = 0;
        levelSheet.ForEach(row =>
            {
                if (rowIndex == 0)
                {
                    rowIndex++;
                    return;
                }

                int id = GetInt(row, 1, 0);
                if (id > 0)
                {
                    if (_level != null)
                    {
                        if (local)
                        {
                            SaveLevel(_level, AssetsPath_LevelLocal + $"{platform}_Level_" + _level.ID + ".txt");
                        }
                        else
                        {
#if UNITY_IOS
                            SaveLevel(_level, Application.dataPath.Replace("Assets", "iOSLevels/" + "Level_" + _level.ID + ".txt"));
#else
                            SaveLevel(_level, Application.dataPath.Replace("Assets", "AndroidLevels/" + "Level_" + _level.ID + ".txt"));
#endif

                        }
                    }

                    bool hardLevel = GetInt(row, 20, 0) == 1 || GetStr(row, 20, "") == "1";
                    _level = new ClassicLevelEntity
                    {
                        ID = id,
                        //Description = GetStr(row, 2, ""),
                        SolutionWord = GetStr(row, 3, "").Replace(" ", "").ToUpper(),
                        ProbabilityID = GetInt(row, 4, 0),
                        Questions = new List<ClassicQuestionEntity>(),
                        IsHardLevel = hardLevel,
                    };
                    string SolutionCardID = GetStr(row, 6, "");
                    _level.SolutionCardID = SolutionCardID;

                    //_level = CreateAsset(_level, cover, out oldData, Levelpath, "Level_" + _level.ID);
                    _level.Questions.Clear();
                }

                ClassicQuestionEntity levelAnswer = new ClassicQuestionEntity()
                {
                    ID = GetInt(row, 7, 0),
                    Question = GetStr(row, 8, ""),
                    Answer = GetStr(row, 9, "").ToUpper(),
                    CategoryID = GetInt(row, 10, 0),
                    MaxAutoHint = GetInt(row, 11, -1),
                    Priority = GetInt(row, 12, 0),
                    SolutionWordIndex = GetInt(row, 13, -1),
                    wordSpit = GetStr(row, 19, "")
                };
                string CardID = GetStr(row, 14, null);
                if (!string.IsNullOrEmpty(CardID) && !CardID.Equals("0"))
                {
                    levelAnswer.SpriteName = CardID;
                    if (local)
                    {
                        var sp = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + CardID);
                        if (sp == null)
                        {
                            Debug.LogError("找不到图片" + CardID);
                        }
                    }
                }

                string simiwords = GetPraseStr(row, 18, "");
                if (!string.IsNullOrEmpty(simiwords))
                {
                    List<string> words = simiwords.Split(',').ToList();
                    levelAnswer.SimiWords = new List<string>();
                    for (int i = 0; i < words.Count; i++)
                    {
                        levelAnswer.SimiWords.Add(words[i].Trim());
                    }
                }

                levelAnswer.SetShowLettersStr(GetStr(row, 15, ""));
                if (levelAnswer.Answer.Length > 0)
                {

                    _level.Questions.Add(levelAnswer);
                }

                levelAnswer.name = "Question" + levelAnswer.ID;
            }
        );
        if (local)
        {
            SaveLevel(_level, AssetsPath_LevelLocal + $"{platform}_Level_" + _level.ID + ".txt");
        }
        else
        {
#if UNITY_IOS
            SaveLevel(_level, Application.dataPath.Replace("Assets", "iOSLevels/" + "Level_" + _level.ID + ".txt"));
#else
            SaveLevel(_level, Application.dataPath.Replace("Assets", "AndroidLevels/" + "Level_" + _level.ID + ".txt"));
#endif
        }
    }

    private void SaveLevel(ClassicLevelEntity _level, string Path)
    {
        FileUtils.CreateTextFile(Path, JsonConvert.SerializeObject(_level));
    }

    private void CreatCards(string Levelpath, string cardPath, bool local, string platform = null)
    {
        platform = platform ?? Const.Platform;
        int rowIndex = 0;
        cardSheet.ForEach(row =>
        {
            if (rowIndex == 0)
            {
                rowIndex++;
                return;
            }

            KnowledgeCardEntity card = new KnowledgeCardEntity()
            {
                ID = GetStr(row, 1, "null"),
                CardTheme = GetStr(row, 2, ""),
                Description = GetStr(row, 3, ""),
                SeriesID = GetInt(row, 5, 1),
                Story = GetStr(row, 6, "")
            };
            string filename = GetStr(row, 4, null);
            card.ImageFileName = filename;
            if (local)
            {
                var sp = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + filename);
                if (sp == null)
                {
                    Debug.LogError("找不到图片" + filename);
                }
            }
            if (local)
            {
                FileUtils.CreateTextFile(AssetsPath_LevelLocal + $"{platform}_Card_" + card.ID + ".txt",
                    JsonConvert.SerializeObject(card));
            }
            else
            {
#if UNITY_IOS
                FileUtils.CreateTextFile(Application.dataPath.Replace("Assets", "iOSCards/" + "Card_" + card.ID + ".txt"),
                    JsonConvert.SerializeObject(card));
#else
                FileUtils.CreateTextFile(Application.dataPath.Replace("Assets", "AndroidCards/" + "Card_" + card.ID + ".txt"),
                    JsonConvert.SerializeObject(card));
#endif

            }
        });
    }

#if USEOLD
    public void ConvertLevel_New(string Levelpath, string cardPath, bool cover)
    {
        bool allIsRight = true;
        string msg = "";
        bool oldData = false;
        int rowIndex = 0;
        //所有card先拿到
        Dictionary<string, KnowledgeCardEntity> cardDic = new Dictionary<string, KnowledgeCardEntity>();
        List<string> cardList = new List<string>();
        cardSheet.ForEach(row =>
        {
            if (rowIndex == 0)
            {
                rowIndex++;
                return;
            }

            KnowledgeCardEntity card = new KnowledgeCardEntity()
            {
                ID = GetStr(row, 1, "null"),
                CardTheme = GetStr(row, 2, ""),
                Description = GetStr(row, 3, ""),
                SeriesID = GetInt(row, 5, 1),
                Story = GetStr(row, 6, "")
            };
            string filename = GetStr(row, 4, null);
            card.ImageFileName = filename;
            if (string.IsNullOrEmpty(filename))
            {
                if (string.IsNullOrEmpty(card.Story))
                {
                    card.Image = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + "baseballbat_1.jpg");
                }
                else
                {
                    card.Image = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + "pyramids_1.jpg");
                }
            }
            else
            {
                card.Image = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + filename);
                if (card.Image == null)
                {
                    if (string.IsNullOrEmpty(card.Story))
                    {
                        card.Image = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + "baseballbat_1.jpg");
                    }
                    else
                    {
                        card.Image = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + "pyramids_1.jpg");
                    }
                }
            }

            cardDic.Add(card.ID, card);
            // string localPath = $"{AssetsPath_CardLocal}{"Card_" + card.ID}.asset";
            // if (!File.Exists(localPath))
            // {
            //     KnowledgeCardEntity _card = CreateAsset(card, cover, out oldData, cardPath, "Card_" + card.ID);
            //     cardDic.Add(card.ID, _card);
            // }
            // else
            // {
            //     cardDic.Add(card.ID, card);
            //     Debug.LogError(string.Format("local中存在相同的文件{0}", localPath));
            // }
        });
        ClassicLevelEntity _level = null;
        rowIndex = 0;
        levelSheet.ForEach(row =>
        {
            if (rowIndex == 0)
            {
                rowIndex++;
                return;
            }

            int id = GetInt(row, 1, 0);
            if (id > 0)
            {
                _level = new ClassicLevelEntity
                {
                    ID = id,
                    //Description = GetStr(row, 2, ""),
                    SolutionWord = GetStr(row, 3, "").Replace(" ", "").ToUpper(),
                    ProbabilityID = GetInt(row, 4, 0),
                    Questions = new List<ClassicQuestionEntity>(),
                    IsHardLevel = GetStr(row, 20, "") == "1" ? true : false,
                };
                string SolutionCardID = GetStr(row, 6, "");
                if (solutionWordLevels.ContainsKey(id))
                {
                    if (string.IsNullOrEmpty(SolutionCardID) || SolutionCardID.Equals("0"))
                    {
                        allIsRight = false;
                        msg += string.Format("Solution Level {0} solution card id error\n", id);
                    }
                    else if (!SolutionCardID.Equals(solutionWordLevels[id]))
                    {
                        allIsRight = false;
                        msg += string.Format("Solution Level {0} solution card id {1} not match in Package {2}\n", id,
                            SolutionCardID, solutionWordLevels[id]);
                    }
                    else if (cardDic.ContainsKey(SolutionCardID))
                    {
                        _level.SolutionCardID = SolutionCardID;
                        if (!cardList.Contains(SolutionCardID))
                        {
                            cardList.Add(SolutionCardID);
                        }

                        //CheckCard(cardDic[SolutionCardID], ref allIsRight, ref msg);
                    }
                    else
                    {
                        _level.SolutionCardID = SolutionCardID;
                        if (!cardList.Contains(SolutionCardID))
                        {
                            cardList.Add(SolutionCardID);
                        }

                        allIsRight = false;
                        msg += string.Format("Level {0} solution card id {1} not found the card\n", id, SolutionCardID);
                    }
                }

                _level = CreateAsset(_level, cover, out oldData, Levelpath, "Level_" + _level.ID);
                _level.Questions.Clear();
            }

            if (oldData)
                return;
            ClassicQuestionEntity levelAnswer = new ClassicQuestionEntity()
            {
                ID = GetInt(row, 7, 0),
                Question = GetStr(row, 8, ""),
                Answer = GetStr(row, 9, "").ToUpper(),
                CategoryID = GetInt(row, 10, 0),
                MaxAutoHint = GetInt(row, 11, -1),
                Priority = GetInt(row, 12, 0),
                SolutionWordIndex = GetInt(row, 13, -1),
                wordSpit = GetStr(row, 19, "")
            };
            string CardID = GetStr(row, 14, null);
            if (!string.IsNullOrEmpty(CardID) && !CardID.Equals("0"))
            {
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + CardID);
                //levelAnswer.ImageSprite = sprite;
                levelAnswer.SpriteName = CardID;
                if (levelAnswer.ImageSprite == null)
                {
                    levelAnswer.ImageSprite = null;
                    Debug.LogError(CardID);
                }
            }

            string simiwords = GetPraseStr(row, 18, "");
            if (!string.IsNullOrEmpty(simiwords))
            {
                List<string> words = simiwords.Split(',').ToList();
                levelAnswer.SimiWords = new List<string>();
                for (int i = 0; i < words.Count; i++)
                {
                    levelAnswer.SimiWords.Add(words[i].Trim());
                }
            }

            levelAnswer.SetShowLettersStr(GetStr(row, 15, ""));
            if (levelAnswer.Answer.Length > 0)
            {
                _level.Questions.Add(levelAnswer);
            }

            levelAnswer.name = "Question" + levelAnswer.ID;
            AssetDatabase.AddObjectToAsset(levelAnswer, _level);
        });
        foreach (string cardDicKey in cardDic.Keys)
        {
            if (cardList.Contains(cardDicKey))
            {
                string localPath = $"{AssetsPath_CardLocal}{"Card_" + cardDic[cardDicKey].ID}.asset";
                if (!File.Exists(localPath))
                {
                    KnowledgeCardEntity _card = CreateAsset(cardDic[cardDicKey], cover, out oldData, cardPath,
                        "Card_" + cardDic[cardDicKey].ID);
                    //cardDic.Add(cardDic[cardDicKey].ID, _card);
                }
                else
                {
                    //cardDic.Add(cardDic[cardDicKey].ID, cardDic[cardDicKey]);
                    Debug.LogError(string.Format("local中存在相同的文件{0}", localPath));
                }
            }
        }

        //if (_level != null)
        //    CreateAsset(_level, classicLevelCoverAll, AssetsPath_Level, "Level_" + _level.ID);
        if (!allIsRight && false)
        {
            EditorUtility.DisplayDialog("Error", msg, "Ok");
        }
        else
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            EditorUtility.DisplayDialog("Success", "level excel data to asset successfully .", "OK");
        }
    }


    public void ConvertClassicLevel(string Levelpath, string cardPath, bool cover)
    {
        bool allIsRight = true;
        string msg = "";
        bool oldData = false;
        int rowIndex = 0;
        Dictionary<string, KnowledgeCardEntity> cardDic = new Dictionary<string, KnowledgeCardEntity>();
        cardSheet.ForEach(row =>
        {
            if (rowIndex == 0)
            {
                rowIndex++;
                return;
            }

            KnowledgeCardEntity card = new KnowledgeCardEntity()
            {
                ID = GetStr(row, 1, "null"),
                CardTheme = GetStr(row, 2, ""),
                Description = GetStr(row, 3, ""),
                SeriesID = GetInt(row, 5, 1),
                Story = GetStr(row, 6, "")
            };
            string filename = GetStr(row, 4, null);
            card.ImageFileName = filename;
            if (string.IsNullOrEmpty(filename))
            {
                // allIsRight = false;
                // msg += string.Format("Card {0} image file is null\n", card.ID);
                // Debug.LogError(string.Format("Card {0} Error {1}", card.ID, filename));
                if (string.IsNullOrEmpty(card.Story))
                {
                    card.Image = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + "baseballbat_1.jpg");
                }
                else
                {
                    card.Image = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + "pyramids_1.jpg");
                }
            }
            else
            {
                card.Image = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + filename);
                if (card.Image == null)
                {
                    // allIsRight = false;
                    // msg += string.Format("Card {0} image file {1} not exist\n", card.ID, filename);
                    // Debug.LogError(string.Format("Card {0} Not Found {1}", card.ID, filename));

                    if (string.IsNullOrEmpty(card.Story))
                    {
                        card.Image = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + "baseballbat_1.jpg");
                    }
                    else
                    {
                        card.Image = AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + "pyramids_1.jpg");
                    }
                }
            }

            string localPath = $"{AssetsPath_CardLocal}{"Card_" + card.ID}.asset";
            if (!File.Exists(localPath))
            {
                KnowledgeCardEntity _card = CreateAsset(card, cover, out oldData, cardPath, "Card_" + card.ID);
                cardDic.Add(card.ID, _card);
            }
            else
            {
                cardDic.Add(card.ID, card);
                Debug.LogError(string.Format("local中存在相同的文件{0}", localPath));
            }
        });
        ClassicLevelEntity _level = null;
        rowIndex = 0;
        levelSheet.ForEach(row =>
        {
            if (rowIndex == 0)
            {
                rowIndex++;
                return;
            }

            int id = GetInt(row, 1, 0);
            if (id > 0)
            {
                _level = new ClassicLevelEntity
                {
                    ID = id,
                    //Description = GetStr(row, 2, ""),
                    SolutionWord = GetStr(row, 3, "").Replace(" ", "").ToUpper(),
                    ProbabilityID = GetInt(row, 4, 0),
                    Questions = new List<ClassicQuestionEntity>()
                };
                string SolutionCardID = GetStr(row, 6, "");
                if (solutionWordLevels.ContainsKey(id))
                {
                    if (string.IsNullOrEmpty(SolutionCardID) || SolutionCardID.Equals("0"))
                    {
                        allIsRight = false;
                        msg += string.Format("Solution Level {0} solution card id error\n", id);
                    }
                    else if (!SolutionCardID.Equals(solutionWordLevels[id]))
                    {
                        allIsRight = false;
                        msg += string.Format("Solution Level {0} solution card id {1} not match in Package {2}\n", id,
                            SolutionCardID, solutionWordLevels[id]);
                    }
                    else if (cardDic.ContainsKey(SolutionCardID))
                    {
                        _level.SolutionCardID = SolutionCardID;
                        CheckCard(cardDic[SolutionCardID], ref allIsRight, ref msg);
                    }
                    else
                    {
                        _level.SolutionCardID = SolutionCardID;
                        allIsRight = false;
                        msg += string.Format("Level {0} solution card id {1} not found the card\n", id, SolutionCardID);
                    }
                }

                _level = CreateAsset(_level, cover, out oldData, Levelpath, "Level_" + _level.ID);
                _level.Questions.Clear();
            }

            if (oldData)
                return;
            ClassicQuestionEntity levelAnswer = new ClassicQuestionEntity()
            {
                ID = GetInt(row, 7, 0),
                Question = GetStr(row, 8, ""),
                Answer = GetStr(row, 9, "").ToUpper(),
                CategoryID = GetInt(row, 10, 0),
                MaxAutoHint = GetInt(row, 11, -1),
                Priority = GetInt(row, 12, 0),
                SolutionWordIndex = GetInt(row, 13, -1),
                wordSpit = GetStr(row, 19, "")
            };
            string CardID = GetStr(row, 14, null);
            if (!string.IsNullOrEmpty(CardID) && !CardID.Equals("0"))
            {
                if (cardDic.ContainsKey(CardID))
                {
                    //levelAnswer.CardID = CardID;
                    CheckCard(cardDic[CardID], ref allIsRight, ref msg);
                }
//                    levelAnswer.CardID = cardDic[CardID];
                else
                {
                    allIsRight = false;
                    msg += string.Format("Level {0} quastion {1} card id {2} not found the card\n", _level.ID,
                        levelAnswer.ID, CardID);
                }
            }

            string simiwords = GetPraseStr(row, 18, "");
            if (!string.IsNullOrEmpty(simiwords))
            {
                List<string> words = simiwords.Split(',').ToList();
                levelAnswer.SimiWords = new List<string>();
                for (int i = 0; i < words.Count; i++)
                {
                    levelAnswer.SimiWords.Add(words[i].Trim());
                }
            }

            levelAnswer.SetShowLettersStr(GetStr(row, 15, ""));
            if (levelAnswer.Answer.Length > 0)
            {
                _level.Questions.Add(levelAnswer);
            }

            levelAnswer.name = "Question" + levelAnswer.ID;
            AssetDatabase.AddObjectToAsset(levelAnswer, _level);
        });
        //if (_level != null)
        //    CreateAsset(_level, classicLevelCoverAll, AssetsPath_Level, "Level_" + _level.ID);
        if (!allIsRight && false)
        {
            EditorUtility.DisplayDialog("Error", msg, "Ok");
        }
        else
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            EditorUtility.DisplayDialog("Success", "level excel data to asset successfully .", "OK");
        }
    }
#endif
    private void CheckCard(KnowledgeCardEntity card, ref bool allIsRight, ref string msg)
    {
        if (card.ImageFileName == null)
        {
            allIsRight = false;
            msg += string.Format("Card {0} image file is null\n", card.ID);
            Debug.LogError(string.Format("Card {0} image file is null", card.ID));
        }
        else if (AssetDatabase.LoadAssetAtPath<Sprite>(AssetsPath_CardImage + card.ImageFileName) == null)
        {
            allIsRight = false;
            msg += string.Format("Card {0} image file {1} not exist\n", card.ID, card.ImageFileName);
            Debug.LogError(string.Format("Card {0} Not Found {1}", card.ID, card.ImageFileName));
        }
    }


    public static T CreateAsset<T>(T obj, bool cover, out bool useOldData, string path, string filename)
        where T : ScriptableObject
    {
        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);
        }

        string fullname = path + string.Format("{0}.asset", filename);
        if (!cover)
        {
            T oldAsset = AssetDatabase.LoadAssetAtPath<T>(fullname);
            if (oldAsset != null)
            {
                Debug.Log("已跳过 " + fullname);
                useOldData = true;
                return oldAsset;
            }
        }

        useOldData = false;
        T asset = ScriptableObject.CreateInstance<T>();
        asset = obj;
        AssetDatabase.CreateAsset(asset, fullname);

        //AssetDatabase.SaveAssets();
        //AssetDatabase.Refresh();
        //EditorUtility.FocusProjectWindow();
        //Selection.activeObject = asset;

        return asset;
    }

    public static int GetInt(List<ICell> row, int col, int defVal)
    {
        ICell cell = col > row.Count ? null : row[col - 1];
        if (cell == null)
            return defVal;
        if (cell.CellType == CellType.Numeric)
            return (int)cell.NumericCellValue;
        else
        {
            string str = cell.StringCellValue;
            if (string.IsNullOrEmpty(str))
                return defVal;
            int intVal = defVal;
            str = str.Trim();
            if (int.TryParse(str, out intVal))
                return intVal;
            return defVal;
        }
    }

    public static string GetStr(List<ICell> row, int col, string defVal = null)
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

    public static string GetPraseStr(List<ICell> row, int col, string defVal = null)
    {
        ICell cell = col > row.Count ? null : row[col - 1];
        if (cell == null)
            return defVal;
        if (cell.CellType == CellType.Numeric)
            return ((int)cell.NumericCellValue).ToString();
        if (cell.CellType != CellType.String)
            return defVal;
        string str = cell.StringCellValue;
        if (string.IsNullOrEmpty(str))
            return defVal;
        str = str.Trim();
        return str;
    }
}