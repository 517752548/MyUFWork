﻿using app.state;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

public class Logger : AbsMonoBehaviour
{
    private static string LogFile = "log";
    private bool flag = true;
    private int MaxNum = 50;

    private Queue<string> logQueue = new Queue<string>();

    private static Logger _ins;
    public static Logger Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new Logger();
            }
            return _ins;
        }
    }

    public void Log(string logStr)
    {
        EnqueueLog(logStr);
    }

    public string getLogDir()
    {
        string path = "";
        switch (Application.platform)
        {
            case RuntimePlatform.IPhonePlayer:
                path = Application.persistentDataPath;
                break;
            case RuntimePlatform.Android:
                path = Application.persistentDataPath;
                break;
            case RuntimePlatform.OSXPlayer:
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.WindowsEditor:
                path = Application.dataPath + "/Editor";
                break;
            default:
                break;
        }
        return path;
    }

    /// <summary>
    /// 在指定位置创建文件   如果文件已经存在则追加文件内容
    /// </summary>
    /// <param name='path'>
    /// 路径
    /// </param>
    /// <param name='name'>
    /// 文件名
    /// </param>
    /// <param name='info'>
    /// 文件内容
    /// </param>
    private void createORwriteConfigFile(string path, string name, string info)
    {
        StreamWriter sw;
        FileInfo t = new FileInfo(path + "/" + name);

        if (!t.Exists)
        {
            sw = t.CreateText();
        }
        else
        {
            sw = t.AppendText();
        }
        sw.WriteLine(info);
        sw.Close();
        sw.Dispose();

        if (UGUIConfig.UICanvas != null&&LogPanel.Ins.ui!=null)
        {
            LogPanel.Ins.AddLog(LogPanelType.Log, info);
        }
    }

    public void WriteLogToFile(string file, string info)
    {
        StreamWriter sw;
        FileInfo t = new FileInfo(file);

        if (!t.Exists)
        {
            sw = t.CreateText();
        }
        else
        {
            sw = t.AppendText();
        }
        sw.WriteLine(info);
        sw.Close();
        sw.Dispose();
    }

    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name='path'>
    /// Path.
    /// </param>
    /// <param name='name'>
    /// Name.
    /// </param>
    public void DeleteFile(string path, string name)
    {
        File.Delete(path + "/" + name);
    }

    /// <summary>
    /// 读取文件内容  仅读取第一行
    /// </summary>
    /// <param name='path'>
    /// Path.
    /// </param>
    /// <param name='name'>
    /// Name.
    /// </param>
    private string LoadFile(string path, string name)
    {
        FileInfo t = new FileInfo(path + "/" + name);
        if (!t.Exists)
        {
            return "error";
        }
        StreamReader sr = null;
        sr = File.OpenText(path + "/" + name);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            break;
        }
        sr.Close();
        sr.Dispose();
        return line;
    }

    private string DequeueLog()
    {
        lock (logQueue)
        {
            if (logQueue.Count > 0)
            {
                return logQueue.Dequeue();
            }
        }
        return null;
    }

    private void EnqueueLog(string logStr)
    {
        lock (logQueue)
        {
            logQueue.Enqueue(logStr);
        }
    }

    // Update is called once per frame
    public override void DoUpdate(float deltaTime)
    {
        try
        {
            if (flag)
            {
                int i = 0;
                for (; i < MaxNum; i++)
                {
                    string log = DequeueLog();
                    if (null != log)
                    {
                        createORwriteConfigFile(getLogDir(), LogFile, log);
                    }
                    if (log!=null&&StateManager.Ins.getCurState() != null &&
                        StateManager.Ins.getCurState().state == StateDef.login)
                    {
                        EventCore.dispathRMetaEventByParms(GlobalConstDefine.PRINT_LOGIN_LOG, log);
                    }
                }
            }
        }
        catch (Exception e)
        {
            ClientLog.LogError("Logger Update Exception!e=" + e.ToString());
            flag = false;
        }
    }

}

