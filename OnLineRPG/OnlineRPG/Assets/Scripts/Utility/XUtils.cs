using BetaFramework;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class XUtils
{
    public static long GetTimeStamp()
    {
        TimeSpan span = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(span.TotalSeconds);
    }

    public static long GetRealTimeStamp()
    {
        TimeSpan span = AppEngine.STimeHeart.RealTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(span.TotalSeconds);
    }
    
    public static string BuildStringFromCollection(ICollection values, char split = '|')
    {
        string results = "";
        int i = 0;
        foreach (var value in values)
        {
            results += value;
            if (i != values.Count - 1)
            {
                results += split;
            }

            i++;
        }

        return results;
    }

    public static List<T> BuildListFromString<T>(string values, char split = '|')
    {
        List<T> list = new List<T>();
        if (string.IsNullOrEmpty(values.Trim()))
            return list;

        string[] arr = values.Split(split);
        foreach (string value in arr)
        {
            if (string.IsNullOrEmpty(value.Trim())) continue;
            T val = (T) Convert.ChangeType(value.ToUpper(), typeof(T));
            list.Add(val);
        }

        return list;
    }

    public static Vector3 GetMiddlePoint(Vector3 begin, Vector3 end, float delta = 0)
    {
        Vector3 center = Vector3.Lerp(begin, end, 0.5f);
        Vector3 beginEnd = end - begin;
        Vector3 perpendicular = new Vector3(-beginEnd.y, beginEnd.x, 0).normalized;
        Vector3 middle = center + perpendicular * delta;
        return middle;
    }

    /// <summary>
    /// 根据T值，计算贝塞尔曲线上面相对应的点
    /// </summary>
    /// <param name="t"></param>T值
    /// <param name="p0"></param>起始点
    /// <param name="p1"></param>控制点
    /// <param name="p2"></param>目标点
    /// <returns></returns>根据T值计算出来的贝赛尔曲线点
    private static Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }

    /// <summary>
    /// 获取存储贝塞尔曲线点的数组
    /// </summary>
    /// <param name="startPoint"></param>起始点
    /// <param name="controlPoint"></param>控制点
    /// <param name="endPoint"></param>目标点
    /// <param name="segmentNum"></param>采样点的数量
    /// <returns></returns>存储贝塞尔曲线点的数组
    public static Vector3[] GetBeizerList(Vector3 startPoint, Vector3 controlPoint, Vector3 endPoint, int segmentNum)
    {
        Vector3[] path = new Vector3[segmentNum];
        for (int i = 1; i <= segmentNum; i++)
        {
            float t = i / (float) segmentNum;
            Vector3 pixel = CalculateCubicBezierPoint(t, startPoint,
                controlPoint, endPoint);
            path[i - 1] = pixel;
            Debug.Log(path[i - 1]);
        }

        return path;
    }

    public static bool IsOutOfScreen(Vector3 pos, float padding = 0)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);

        return screenPos.x > -padding && screenPos.x < Screen.width + padding
                                      && screenPos.y > -padding && screenPos.y < Screen.height + padding;
    }

    public static void SendEmail()
    {
        string osInfo = SystemInfo.operatingSystem;
        int index = osInfo.IndexOf('/');
        if (index > 0) osInfo = osInfo.Substring(0, index);
        string subject = "";
#if WordCrossyDE
        string tip_begin = "Bitte die folgende Informationen nicht löschen.";
        string tip_end = "Bitte die obene Informationen nicht löschen.";
        string body = string.Format(@"

***{0}***
-----------------------------------------------
Kunden ID：{1}
Gerät：{2}
BS：{3}
Version：{4}
Sprache：{5} / {6}
-----------------------------------------------
***{7}***",
            tip_begin,
            DataSyncManager.DeviceId,
            SystemInfo.deviceModel,
            osInfo,
            PlatformUtil.GetVersionName(),
            Application.systemLanguage, PlatformUtil.GetNativeCountry(),
            tip_end);
#else
        string tip_begin = "Please don't delete the information below.";
        string tip_end = "Please don't delete the information above.";
        string body = string.Format(@"

***{0}***
-----------------------------------------------
UserId：{1}
LoginID:{8}
Device：{2}
OS：{3}
Version：{4}
Language：{5} / {6}
-----------------------------------------------
***{7}***",
            tip_begin,
            DataManager.DeviceData.DeviceId,
            SystemInfo.deviceModel,
            osInfo,
            PlatformUtil.GetVersionName(),
            Application.systemLanguage, PlatformUtil.GetNativeCountry(),
            tip_end, AppEngine.SSystemManager.GetSystem<PlayerLoginSystem>().playerCrazeID.Value);
#endif
        string to = Const.APP_EMAIL;
        PlatformUtil.SendEmail(subject, body, to);
    }

    

    public static bool QuitTimerEnd = false;

    public static string GetActiveTime()
    {
        return Record.GetString("ActiveTime", "");
    }

    public static string GetUserID()
    {
        return Record.GetString("UserID", "");
    }

    public static void SetUserID(string id)
    {
        Record.SetString("UserID", id);
    }

    public static string GetUserIDForBQ()
    {
        if (GetUserID().Length == 0)
        {
            return SystemInfo.deviceUniqueIdentifier;
        }

        return GetUserID();
    }

    public static void SetActiveTime(string ActiveTime)
    {
        Record.SetString("ActiveTime", ActiveTime);
    }

    public static List<Vector3> ListDeepCopy(List<Vector3> source)
    {
        List<Vector3> result = new List<Vector3>();
        foreach (Vector3 vec3 in source)
        {
            result.Add(vec3);
        }

        return result;
    }

    /// <summary>
    /// 获取用户类型，true为付费用户
    /// </summary>
    /// <returns></returns>
    public static string GetUserType()
    {
        bool isShoped = Record.GetBool("shoped_player", false);
        if (isShoped)
        {
            return "true";
        }
        else
        {
            return "false";
        }
    }


    //用户是否是第一次安装，是返回true
    private static bool isFirstOn()
    {
        if (PlayerPrefs.GetString("FirstPlayInstall", "").Length == 0)
        {
            PlayerPrefs.SetString("FirstPlayInstall", "not");
            return true;
        }
        else
        {
            return false;
        }
    }

    #region 每日挑战存档相关的

    /// <summary>
    /// 玩家第一次玩每日挑战,记录日期
    /// </summary>
    public static void PlayerFirstPlayDaily()
    {
        if (Record.HasKey("Player_firstCome_dailyed"))
        {
            return;
        }

        Record.SetBool("Player_firstCome_dailyed", true);
        Record.SetString("Player_first_on_daily", System.DateTime.Now.ToLongDateString());
    }


    public static string DailyChallengeData
    {
        get { return Record.GetString("DailyChallengeData", DateTime.Now.Year + "|" + DateTime.Now.Month); }
        //  get { return 400; }
        set
        {
            if (value.Length == 0) //服务器数据为空 默认本地数据。
            {
                value = Record.GetString("DailyChallengeData", DateTime.Now.Year + "|" + DateTime.Now.Month);
            }

            Record.SetString("DailyChallengeData", value);
        }
    }

    /// <summary>
    /// 这里遇到一个1月和11月12月的bug，修复方案
    /// </summary>
    /// <param name="topstr"></param>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <returns></returns>
    public static string GetDailyChallengeKey(string topstr, int year, int month, int day)
    {
        string key = topstr + year + "" + month + "" + day;
        if ((month == 11 || month == 12) && (day >= 1 && day <= 9))
        {
            key = topstr + year + "" + month + "0" + day;
        }

        return key;
    }

    #endregion 每日挑战存档相关的

    /// <summary>
    /// 获取广告组
    /// </summary>
    /// <returns></returns>
    public static int GetPlayerADGroup()
    {
        return Record.GetInt("PlayerADGroup", 2);
    }

    public static Color ConvertColor(string colorString) //16进制颜色值
    {
        if (string.IsNullOrEmpty(colorString))
            colorString = "8BA0EF";

        int v = int.Parse(colorString, System.Globalization.NumberStyles.HexNumber);
        return new Color()
        {
            a = 1,
            r = Convert.ToByte((v >> 16) & 255) / 255.0f,
            g = Convert.ToByte((v >> 8) & 255) / 255.0f,
            b = Convert.ToByte((v >> 0) & 255) / 255.0f
        };
    }

    //是否是iphonex
    public static bool IsIphoneX()
    {
        return SystemInfo.deviceModel == "iPhone10,3"
               || SystemInfo.deviceModel == "iPhone10,6"
               || SystemInfo.deviceModel == "iPhone11,8"
               || SystemInfo.deviceModel == "iPhone11,2"
               || SystemInfo.deviceModel == "iPhone11,6"
               || SystemInfo.deviceModel == "iPhone11,4"
               || Screen.width == 1125 && Screen.height == 2436;
    }

    /// <summary>
    /// 是否是哪种高比宽特别大的手机 0
    /// </summary>
    /// <returns></returns>
    public static bool IsSpecialScreen()
    {
        return ((float) Screen.height / Screen.width >= 2);
    }

    public static DateTime ConvertTime(string timestring, DateTime defaultTime)
    {
        try
        {
            DateTime time;
            bool ok = DateTime.TryParse(timestring, out time);
            if (!ok)
            {
                time = defaultTime;
            }

            return time;
        }
        catch (Exception)
        {
            return defaultTime;
        }
    }

    public static string GetErrorTypeStr(string errorLog)
    {
        //对错误的log日志取样，取样标准是至少20个字符串，
        if (!string.IsNullOrEmpty(errorLog))
        {
            if (errorLog.Length > 20)
            {
                return errorLog.Substring(0, 18);
            }
            else
            {
                return errorLog;
            }
        }

        return "unknown";
    }

    public static DateTime TimeStampToDateTime(long timeStamp)
    {
        if (timeStamp > 9999999999) timeStamp /= 1000;
        //DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
        DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).ToLocalTime(); // 当地时区
        return startTime.AddSeconds(timeStamp);
    }

    public static DateTime TimeStampToUTCDateTime(long timeStamp)
    {
        if (timeStamp > 9999999999) timeStamp /= 1000;
        DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return startTime.AddSeconds(timeStamp);
    }

    public static long UTCDateTimeToTimeStamp(DateTime dt)
    {
        DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return (int) dt.Subtract(startTime).TotalSeconds;
    }

    private static Material grayMat = null;

    public static Material GetGrayMat()
    {
        if (grayMat == null)
        {
            Shader shader = Shader.Find("Custom/UIGray");
            if (shader == null)
            {
                return null;
            }

            grayMat = new Material(shader);
        }

        return grayMat;
    }

    public static int ParseInt(string arg1, int defaultvalue = 0)
    {
        if (string.IsNullOrEmpty(arg1)) return defaultvalue;
        int result = defaultvalue;
        bool r = int.TryParse(arg1, out result);
        if (r == false)
        {
            result = defaultvalue;
        }

        return result;
    }

    public static int ParseCent(string arg1, int defaultvalue = 0)
    {
        if (string.IsNullOrEmpty(arg1)) return defaultvalue;
        float result = defaultvalue;
        bool r = float.TryParse(arg1, out result);
        if (r == false)
        {
            result = defaultvalue;
        }

        result *= 100;
        return (int) Round(result, 0);
    }

    /// <summary>
    /// 四舍五入
    /// </summary>
    /// <param name="value"></param>
    /// <param name="digit"></param>
    /// <returns></returns>
    public static double Round(float value, int digit)
    {
        double vt = Math.Pow(10, digit);
        //1.乘以倍数 + 0.5
        double vx = value * vt + 0.5;
        //2.向下取整
        double temp = Math.Floor(vx);
        //3.再除以倍数
        return (temp / vt);
    }

    public static int GetDollerCent(string arg1, int defaultvalue = 0)
    {
        if (arg1.Contains("."))
        {
            arg1.Replace(".", "");
            int va = defaultvalue;
            if (int.TryParse(arg1, out va))
            {
                return va;
            }
        }

        return ParseCent(arg1);
    }

    private static Queue q = new Queue();

    public static void DisableClickEvent(Transform transf)
    {
        if (transf == null) return;
        if (!(transf is Transform)) return;
        q.Clear();
        q.Enqueue(transf);
        while (q.Count > 0)
        {
            Transform aT = (Transform) q.Dequeue();
            var txt = aT.GetComponent<Text>();
            var img = aT.GetComponent<Image>();
            if (txt != null)
            {
                txt.raycastTarget = false;
            }

            if (img != null)
            {
                img.raycastTarget = false;
            }

            foreach (Transform t in aT)
            {
                q.Enqueue(t);
            }
        }
    }

    public static DateTime GetDateFromString(string t)
    {
        var x = t.Replace("：", ":");
        DateTime date = System.Convert.ToDateTime(t);
        return date;
    }


    public static string GetFormatTime(long timeSpan)
    {
        TimeSpan span = new TimeSpan(0, 0, (int) timeSpan);
        //Debug.LogError(span.ToString("HH:mm:ss"));
        string hours = span.TotalHours > 9 ? span.TotalHours + "" : "0" + span.TotalHours;
        string Minutes = span.Minutes > 9 ? span.Minutes + "" : "0" + span.Minutes;
        string Seconds = span.Seconds > 9 ? span.Seconds + "" : "0" + span.Seconds;
        return string.Format("{0}:{1}:{2}", hours, Minutes, Seconds);
    }

    // public static List<T> RandomFromList<T>(List<T> list, int count)
    // {
    //     if (list.Count <= count)
    //         return list;
    //     List<T> result = new List<T>();
    //     List<T> temp = new List<T>(list);
    //     System.Random r;
    //     int index;
    //     for (int i = 0; i < count; i++)
    //     {
    //         if (temp.Count == 0)
    //             break;
    //         r = new System.Random((i + 8) * 9);
    //         index = r.Next() % temp.Count;
    //         result.Add(temp[index]);
    //         temp.RemoveAt(index);
    //     }
    //     return result;
    // }
    public static List<T> RandomFromList<T>(List<T> list, int count)
    {
        if (list.Count <= count)
            return list;
        List<T> result = new List<T>();
        List<T> temp = new List<T>(list);
        for (int i = 0; i < count; i++)
        {
            result.Add(RandomOneFromList(ref temp));
        }

        return result;
    }

    private static int randomSeed = -1;

    public static T RandomOneFromList<T>(ref List<T> list)
    {
        if (randomSeed < 0)
            randomSeed = DateTime.Now.Millisecond;
        var r = new System.Random(randomSeed);
        randomSeed += 7;
        var index = r.Next() % list.Count;
        T obj = list[index];
        list.RemoveAt(index);
        return obj;
    }

    public static string GetTimeDes(string time)
    {
        DateTime oldTime = DateTime.Parse(time);
        TimeSpan timeSpan = AppEngine.STimeHeart.RealTime.Subtract(oldTime);
        if (timeSpan.Days > 365)
        {
            return "1 year ago";
        }
        else if (timeSpan.Days > 30)
        {
            int days = timeSpan.Days;
            int months = days / 30;
            return string.Format("{0} month{1} ago", months, months > 1 ? "s" : "");
        }
        else if (timeSpan.Days >= 1)
        {
            return string.Format("{0} day{1} ago", timeSpan.Days, timeSpan.Days > 1 ? "s" : "");
        }
        else if (timeSpan.Hours > 1)
        {
            return string.Format("{0} hour{1} ago", timeSpan.Hours, timeSpan.Hours > 1 ? "s" : "");
        }
        else if (timeSpan.Minutes > 1)
        {
            return string.Format("{0} minute{1} ago", timeSpan.Minutes, timeSpan.Minutes > 1 ? "s" : "");
        }

        return string.Format("1 minute ago");
    }

    public static string GetEmailTimeDesAgo(long time)
    {
        DateTime oldTime = TimeStampToUTCDateTime(time);
        Debug.LogError(oldTime.ToString());
        TimeSpan timeSpan = AppEngine.STimeHeart.ServerTime.Subtract(oldTime);
        Debug.LogError(AppEngine.STimeHeart.ServerTime.ToString());
        if (timeSpan.Days > 365)
        {
            return "1 year ago";
        }
        else if (timeSpan.Days > 30)
        {
            int days = timeSpan.Days;
            int months = days / 30;
            return string.Format("{0} month{1} ago", months, months > 1 ? "s" : "");
        }
        else if (timeSpan.Days >= 1)
        {
            return string.Format("{0} day{1} ago", timeSpan.Days, timeSpan.Days > 1 ? "s" : "");
        }
        else if (timeSpan.Hours > 1)
        {
            return string.Format("{0} hour{1} ago", timeSpan.Hours, timeSpan.Hours > 1 ? "s" : "");
        }

        return string.Format("1 hour ago");
    }

    public static string GetEmailTimeDesExpers(long time)
    {
        DateTime oldTime = TimeStampToUTCDateTime(time);
        TimeSpan timeSpan = oldTime.Subtract(AppEngine.STimeHeart.ServerTime);
        if (timeSpan.Days > 365)
        {
            return "Expires in 1 years";
        }
        else if (timeSpan.Days > 30)
        {
            int days = timeSpan.Days;
            int months = days / 30;
            return string.Format("Expires in {0} year{1}", months, months > 1 ? "s" : "");
        }
        else if (timeSpan.Days >= 1)
        {
            return string.Format("Expires in {0} day{1}", timeSpan.Days, timeSpan.Days > 1 ? "s" : "");
        }
        else if (timeSpan.Hours > 1)
        {
            return string.Format("Expires in {0} hour{1}", timeSpan.Hours, timeSpan.Hours > 1 ? "s" : "");
        }

        return string.Format("Expires in 1 hour");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="date1"></param>
    /// <param name="date2"></param>
    /// <returns>true date2 与 date1 不是同一天 并且 date2 timestamp > date1 time stamp</returns>
    public static bool IsDateAnotherBigDay(DateTime date1, DateTime date2)
    {
        if (date2.Year > date1.Year)
        {
            return true;
        }
        else if (date2.Year == date1.Year)
        {
            if (date2.Month > date1.Month)
            {
                return true;
            }
            else if (date2.Month == date1.Month)
            {
                if (date2.Day > date1.Day)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static int DaysApart(DateTime date1, DateTime date2)
    {
        DateTime short1 = System.Convert.ToDateTime(date1.ToShortDateString());
        TimeSpan ts = date2 - short1;
        return ts.Days;
    }

    public static bool SameDay(DateTime date1, DateTime date2)
    {
        return date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day;
    }

    public static int GetEmailVersion()
    {
        string ver = Const.Version;
        ver = ver.Replace(".", "");
        int version = 1;
        if (int.TryParse(ver, out version))
        {
            return version;
        }

        return version;
    }

    public static string GetFormatFans(int number)
    {
        if (number >= 10000)
        {
            string numb = string.Format("{0:F1}K", Math.Round((number / 1000f), 1));

            return numb.Replace(".0", "");
        }

        return number.ToString();
    }

    public static int GetWordRightNumber(int current)
    {
        switch (current)
        {
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 3;
            case 4:
            case 5:
            case 6:
                return 4;
            case 7:
            case 8:
            case 9:
                return current - 2;
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
                return current - 3;
            default:
                return current;
        }
    }
    public static int GetVoiceWordRightNumber(int current)
    {
        switch (current) {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                return current;
            case 6:
            case 7:
            case 8:
            case 9:
                return current - 1;
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
            case 17:
                return current - 2;
            default:
                return current;
        }
    }

    public static int GetStringCompare(string wordanswer, string wordinput)
    {
        char[] ss = wordanswer.Trim().ToCharArray();
        char[] st = wordinput.Trim().ToCharArray();
        if (ss.Length != st.Length)
        {
            return 0;
        }

        int equalNumber = 0;
        for (int i = 0; i < ss.Length; i++)
        {
            if (ss[i] == st[i])
            {
                equalNumber++;
            }
        }

        return equalNumber;
    }

    public static string GetCellTip(string wordanswer, string wordinput, int order,int index)
    {
        char[] ss = wordanswer.Trim().ToCharArray();
        char[] st = wordinput.Trim().ToCharArray();
        List<char> cells = new List<char>();
        for (int i = 0; i < ss.Length; i++)
        {
            if (ss[i] != st[i])
            {
                cells.Add(ss[i]);
            }
        }

        if (cells.Count > 0)
        {
            return cells[(index % cells.Count)].ToString();
        }

        return "";
    }
}