using System;
using System.Collections.Generic;
using UnityEngine;

namespace BetaFramework
{
    public class TargetPoint
    {
        public int direct = -1;
        public bool selected = false;
        public int radius = 200;
        public float x;
        public float y;

        public TargetPoint(int direction, float px, float py)
        {
            direct = direction;
            x = px;
            y = py;
        }
    }

    // [RequireComponent(typeof(DebuggerComponent))]
    public class DebuggerGesture : MonoBehaviour
    {
        public static int LEFT_UP = 0;
        public static int MIDDLE_UP = 1;
        public static int RIGHT_UP = 2;
        public static int LEFT_CENTER = 3;
        public static int MIDDLE_CENTER = 4;
        public static int RIGHT_CENTER = 5;
        public static int LEFT_DOWN = 6;
        public static int MIDDLE_DOWN = 7;
        public static int RIGHT_DOWN = 8;
        private static Dictionary<string, Action> m_Commands;
        private static TargetPoint[] m_Targets;
        private string m_SelectCommand = "";
        private bool m_Active = true;
        private CollectPetLocalData m_RandomPetData;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            m_Targets = new TargetPoint[]{
                new TargetPoint(LEFT_UP, 0, Screen.height),
                new TargetPoint(MIDDLE_UP, Screen.width >> 1, Screen.height),
                new TargetPoint(RIGHT_UP, Screen.width, Screen.height),
                new TargetPoint(LEFT_CENTER, 0, Screen.height >> 1),
                new TargetPoint(MIDDLE_CENTER, Screen.width >> 1, Screen.height >> 1),
                new TargetPoint(RIGHT_CENTER, Screen.width, Screen.height >> 1),
                new TargetPoint(LEFT_DOWN, 0, 0),
                new TargetPoint(MIDDLE_DOWN, Screen.width >> 1, 0),
                new TargetPoint(RIGHT_DOWN, Screen.width, 0)
            };
            m_Commands = new Dictionary<string, Action>();
            BindCommand(Active, RIGHT_DOWN + "-" + RIGHT_CENTER + "-" + RIGHT_UP + "-" + MIDDLE_UP + "-" + LEFT_UP + "-" + LEFT_CENTER + "-" + MIDDLE_CENTER + "-" + MIDDLE_DOWN + "-" + LEFT_DOWN);
            BindCommand(ShowLogPanel, LEFT_UP + "-" + MIDDLE_UP + "-" + MIDDLE_CENTER + "-" + MIDDLE_DOWN);
            BindCommand(GetRandomRole, LEFT_UP + "-" + MIDDLE_UP + "-" + RIGHT_UP);
        }

        private void Update1()
        {
            if (Input.GetMouseButton(0))
            {
                for (int i = 0; i < m_Targets.Length; i++)
                {
                    float a2b2 = (Input.mousePosition.x - m_Targets[i].x) * (Input.mousePosition.x - m_Targets[i].x) + (Input.mousePosition.y - m_Targets[i].y) * (Input.mousePosition.y - m_Targets[i].y);
                    float c2 = m_Targets[i].radius * m_Targets[i].radius;
                    if (!m_Targets[i].selected && a2b2 <= c2)
                    {
                        m_Targets[i].selected = true;
                        m_SelectCommand += m_SelectCommand == "" ? m_Targets[i].direct.ToString() : "-" + m_Targets[i].direct;
                        Debug.Log(m_SelectCommand);
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                for (int i = 0; i < m_Targets.Length; i++)
                {
                    if (m_Commands.ContainsKey(m_SelectCommand))
                    {
                        if (m_Active || m_SelectCommand == RIGHT_DOWN + "-" + RIGHT_CENTER + "-" + RIGHT_UP + "-" + MIDDLE_UP + "-" + LEFT_UP + "-" + LEFT_CENTER + "-" + MIDDLE_CENTER + "-" + MIDDLE_DOWN + "-" + LEFT_DOWN)
                        {
                            m_Commands[m_SelectCommand]();
                        }
                    }
                    m_Targets[i].selected = false;
                    m_SelectCommand = "";
                }
            }
        }

        private void Active()
        {
            m_Active = !m_Active;
        }

        private void ShowLogPanel()
        {
            DebuggerComponent debugger = gameObject.GetComponent<DebuggerComponent>();
            if (debugger == null)
            {
                gameObject.AddComponent<DebuggerComponent>();
            }
            debugger.ActiveWindow = true;
        }
//        private CollectPetLocalData GetRandomPetData()
//        {
//            List<CollectPetLocalData> pets = new List<CollectPetLocalData>();
//            Dictionary<string, List<CollectPetLocalData>> petDic = DataManager.CollectPetThemesDataList.petDic;
//            foreach (KeyValuePair<string, List<CollectPetLocalData>> pair in petDic)
//            {
//                for (int i = 0; i < pair.Value.Count; i++)
//                {
//                    if (pair.Value[i].isLock)
//                    {
//                        pets.Add(pair.Value[i]);
//                    }
//                }
//            }
//            // for (int i = 0; i < DataManager.CollectPetThemesDataList.petDic["10001"].Count; i++)
//            // {
//            //     if (DataManager.CollectPetThemesDataList.petDic["10001"][i].isLock)
//            //     {
//            //         pets.Add(DataManager.CollectPetThemesDataList.petDic["10001"][i]);
//            //     }
//            // }
//
//            int petIndex = UnityEngine.Random.Range(0, pets.Count);
//            CollectPetData petData = pets[petIndex];
//            if (petData.isSpecial)
//            {
//                if (petData.pieces > 1)
//                {
//                    petData.currentPieces++;
//                    if (petData.currentPieces >= petData.pieces)
//                    {
//                        petData.currentPieces = petData.pieces;
//                        petData.isLock = false;
//                    }
//                }
//                else
//                {
//                    petData.isLock = false;
//                }
//            }
//            else
//            {
//                petData.isLock = false;
//            }
//            return petData;
//        }
//        private CollectPetThemesData GetThemeData()
//        {
//            List<CollectPetThemesData> themes = DataManager.CollectPetThemesDataList.themes;
//            CollectPetThemesData themeData = null;
//            for (int i = 0; i < themes.Count; i++)
//            {
//                if (m_RandomPetData.themeName == themes[i].themeName)
//                {
//                    themeData = themes[i];
//                    break;
//                }
//            }
//            return themeData;
//        }
        private void GetRandomRole()
        {
            //DataManager.CollectPetThemesDataList.UnLockPets("10001", "15002", 1);
        }

        public static void BindCommand(Action call, params object[] arg)
        {
            string commandStr = "";
            for (int i = 0; i < arg.Length; i++)
            {
                commandStr += commandStr == "" ? arg[i] : "-" + arg[i];
            }
            m_Commands[commandStr] = call;
        }
    }
}