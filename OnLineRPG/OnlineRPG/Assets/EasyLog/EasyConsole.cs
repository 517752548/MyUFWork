using System.Collections.Generic;
using UnityEngine;

public class EasyConsole : MonoBehaviour {
    struct Log
    {
        public string message;
        public string stackTrace;
        public LogType type;
    }
#region Inspector Settings

    public GUISkin myskin;
    public KeyCode toggleKey = KeyCode.BackQuote;
    public bool shakeToOpen = true;

    public float shakeAcceleration = 3f;
    public bool restrictLogCount = false;

    public int maxLogs = 1000;
#endregion

    readonly List<Log> logs = new List<Log>();
    Vector2 scrollPosition;
    bool visible;
    bool collapse;

    /// <summary>
    /// FPS
    /// </summary>
    private float updateInterval = 0.5f;
    private double lastInterval;
    private int frames = 0;
    private float fps;

    private void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }

    static readonly Dictionary<LogType, Color> logTypeColors = new Dictionary<LogType, Color>
    {
        {LogType.Assert, Color.white },
        {LogType.Error, Color.red },
        {LogType.Exception, Color.red },
        {LogType.Log, Color.white },
        {LogType.Warning, Color.yellow },
    };

    const string windowTitle = "Console";
    const int margin = 60;
    static readonly GUIContent clearLabel = new GUIContent("Clear", "Clear the contents of the console.");
    static readonly GUIContent collapseLabel = new GUIContent("Collapse", "Hide repeated messages");

    readonly Rect titleBarRect = new Rect(0, 0, 10000, 20);
    Rect windowRect = new Rect(margin, margin, Screen.width - (margin * 2), Screen.height - (margin * 2));

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            visible = !visible;
        }

        if (shakeToOpen && Input.acceleration.sqrMagnitude > shakeAcceleration)
        {
            visible = !visible;
        }

        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
        }
    }

    private void OnGUI()
    {
        GUI.skin = myskin;
        if (!visible)
        {
            return;
        }

        windowRect = GUILayout.Window(123456, windowRect, DrawConsoleWindow, windowTitle);
    }

    void DrawConsoleWindow(int windowID)
    {
        DrawLogsList();
        DrawToolbar();

        GUI.DragWindow(titleBarRect);
        GUILayout.Label(" " + fps.ToString("f2"));
    }

    void DrawLogsList()
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);

        for (var i = 0; i < logs.Count; i++)
        {
            var log = logs[i];

            if (collapse && i > 0)
            {
                var previousMessage = logs[i - 1].message;
                if (log.message == previousMessage)
                {
                    continue;
                }
            }

            GUI.contentColor = logTypeColors[log.type];
            GUILayout.Label(log.message);
        }

        GUILayout.EndScrollView();

        GUI.contentColor = Color.white;
    }

    void DrawToolbar()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(clearLabel))
        {
            logs.Clear();
        }

        collapse = GUILayout.Toggle(collapse, collapseLabel, GUILayout.ExpandWidth(true));

        GUILayout.EndHorizontal();
    }

    void HandleLog(string message, string stackTrace, LogType type)
    {
        if (message.Length >= 120)
        {
            message = message.Substring(0, 120);
        }
        if (stackTrace.Length >= 120)
        {
            stackTrace = stackTrace.Substring(0, 120);
        }
        logs.Add(new Log
        {
            message = message,
            stackTrace = stackTrace,
            type = type,
        });

        TrimExcessLogs();
    }

    void TrimExcessLogs()
    {
        if (!restrictLogCount)
        {
            return;
        }

        var amountToRemove = Mathf.Max(logs.Count - maxLogs, 0);
        if (amountToRemove == 0)
        {
            return;
        }

        logs.RemoveRange(0, amountToRemove);
    }
}
