using BetaFramework;
using UnityEngine;

public class ConsoleManager : MonoBehaviour
{
    private static ConsoleManager instance;

    public static ConsoleManager _instacne
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ConsoleManager>();
            }
            return instance;
        }
    }

    //测试服
    public bool UseTestURL = false;

    public bool ShowAssistAnswer = false;
    public bool AppIsRelease = true;
    public bool OpenActivity = false;

    // Use this for initialization

    public void Init()
    {
        AppIsRelease = PlatformUtil.GetAppIsRelease();
        UseTestURL = !AppIsRelease;
        BetaFramework.LoggerHelper.Log("正式服务器？：" + AppIsRelease);
    }
}