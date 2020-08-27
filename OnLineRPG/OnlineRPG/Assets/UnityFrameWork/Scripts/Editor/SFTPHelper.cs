using Newtonsoft.Json;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using UnityEditor;
using UnityEngine;

/// <summary>
/// SFTP操作类
/// </summary>
public class SFTPHelper
{
#if UNITY_IOS
        private const string localDir = "./ServerData/iOS/";
        private const string remoteDir = "/data/ossfile/webfiles/activityfiles/CodyLevel/iOS/";
#endif
#if UNITY_ANDROID
    private const string localDir = "./ServerData/Android/";
    private const string remoteDir = "/data/ossfile/webfiles/activityfiles/CodyLevel/Android/";
#endif
    private const string patchName = "patch_assets_assembly-csharp.patch.bytes.bundle";

    public const int maxThread = 6;
    public static int finishCount = 0;
    public static List<string> errorMsgs = new List<string>();

    public static void CleanFiles(string pattern)
    {
        if (Directory.Exists(localDir))
        {
            var files = Directory.GetFiles(localDir, pattern);
            for (int i = 0; i < files.Length; i++)
            {
                File.Delete(files[i]);
            }
        }
    }

    public static void NoticeError()
    {
        if (errorMsgs.Count == 0) return;
        var sb = new StringBuilder("错误通知:\n");
        foreach (var item in errorMsgs)
        {
            sb.Append(item);
        }
        errorMsgs.Clear();
        var data = new
        {
            msgtype = "text",
            text = new { content = sb.ToString() }
        };
        var json = JsonConvert.SerializeObject(data);

        HttpWebRequest web = (HttpWebRequest)WebRequest.Create("https://oapi.dingtalk.com/robot/send?access_token=9fd7a8a1369920ab9878bcd7b1df2a3f8b294bf0193d0e407737590e21d4dde2");
        web.ContentType = "application/json";
        web.Method = "POST";
        byte[] postBytes = Encoding.UTF8.GetBytes(json);
        web.ContentLength = postBytes.Length;
        using (Stream reqStream = web.GetRequestStream())
        {
            reqStream.Write(postBytes, 0, postBytes.Length);
        }
        string html = string.Empty;
        using (HttpWebResponse response = (HttpWebResponse)web.GetResponse())
        {
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
            html = streamReader.ReadToEnd();
        }
    }

    [MenuItem("Framework/Bundle/UploadResources/iOS(Debug)")]
    static void UploadiOSDebug()
    {
        var files = Directory.GetFiles(localDir);
        Put(remoteDir + "Debug/", files);
    }

    [MenuItem("Framework/Bundle/UploadResources/iOS(Release)")]
    static void UploadiOSRelease()
    {
        var files = Directory.GetFiles(localDir);
        Put(remoteDir + "Release/", files);
    }

    [MenuItem("Framework/IFix/UploadPatch/Debug")]
    static void UploadPatchToDebug()
    {
        var files = new string[] { localDir + patchName };
        Put(remoteDir + "Debug/", files);
    }

    [MenuItem("Framework/IFix/UploadPatch/Release")]
    static void UploadPatchToRelease()
    {
        var files = new string[] { localDir + patchName };
        Put(remoteDir + "Release/", files);
    }

    static void Put(string path, string[] files)
    {
        finishCount = 0;
        List<SFTPUpload> threads = new List<SFTPUpload>();
        for (int i = 0; i < maxThread; i++)
        {
            threads.Add(new SFTPUpload(i + 1));
        }

        for (int i = 0; i < files.Length; i++)
        {
            threads[i % maxThread].AddFiles(files[i]);
        }

        for (int i = 0; i < threads.Count; i++)
        {
            threads[i].Start(path, Const.Version);
        }
    }
}

class SFTPUpload
{
    private const string ip = "104.42.155.49";
    private const int port = 22;
    private const string user = "fotoable";
    private const string pwd = "Cloud123456789";
    private string remoteDir;
    public float procent = 0;
    private List<string> files = new List<string>();
    private string version;
    public int current = 0;
    private int id = 0;


    public SFTPUpload(int id)
    {
        this.id = id;
    }

    /// <summary>
    /// SFTP连接状态
    /// </summary>
    bool Connected
    {
        get { return Sftp.IsConnected; }
    }

    SftpClient sftp;

    SftpClient Sftp
    {
        get
        {
            if (sftp == null)
            {
                sftp = new SftpClient(ip, port, user, pwd);
            }

            return sftp;
        }
    }

    public void AddFiles(string file)
    {
        files.Add(file);
    }

    #region 连接SFTP

    /// <summary>
    /// 连接SFTP
    /// </summary>
    /// <returns>true成功</returns>
    bool Connect()
    {
        try
        {
            if (!Connected)
            {
                Sftp.Connect();
            }

            return true;
        }
        catch (Exception ex)
        {
            // TxtLog.WriteTxt(CommonMethod.GetProgramName(), string.Format("连接SFTP失败，原因：{0}", ex.Message));
            throw new Exception(string.Format("连接SFTP失败，原因：{0}", ex.Message));
        }
    }

    #endregion

    #region 断开SFTP

    /// <summary>
    /// 断开SFTP
    /// </summary> 
    public void Disconnect()
    {
        try
        {
            if (Connected)
            {
                Sftp.Disconnect();
            }
        }
        catch (Exception ex)
        {
            // TxtLog.WriteTxt(CommonMethod.GetProgramName(), string.Format("断开SFTP失败，原因：{0}", ex.Message));
            throw new Exception(string.Format("断开SFTP失败，原因：{0}", ex.Message));
        }
    }

    #endregion

    public void Start(string remoteDir, string version)
    {
        this.remoteDir = remoteDir;
        this.version = version;
        Thread start = new Thread(Put);
        start.Start();
    }

    private void Put()
    {
        try
        {
            Connect();
            var dir = remoteDir + version + "/";
            if (!sftp.Exists(dir))
            {
                sftp.CreateDirectory(dir);
            }

            int max = files.Count;
            foreach (var path in files)
            {
                using (var file = File.OpenRead(path))
                {
                    Sftp.UploadFile(file, dir + Path.GetFileName(path));
                }

                current++;
                procent = current * 100f / max;
                Debug.Log(id + "  thread  percent: " + procent);
            }

            Disconnect();
            Debug.LogError(id + "上传成功!");
        }
        catch (Exception ex)
        {
            var msg = $"{id}  thread  上传失败，原因：{ex.Message}\n";
            Debug.LogErrorFormat(msg);
            SFTPHelper.errorMsgs.Add(msg);
        }
        Interlocked.Increment(ref SFTPHelper.finishCount);
        if (SFTPHelper.finishCount >= SFTPHelper.maxThread)
        {
            SFTPHelper.NoticeError();
        }
    }
}