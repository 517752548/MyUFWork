using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using BetaFramework;
using PathC;
using UnityEngine;
using UnityEngine.Networking;

public static class CommUtil
{
    public static Vector3 GetMiddlePoint(Vector3 begin, Vector3 end, float delta = 0)
    {
        Vector3 center = Vector3.Lerp(begin, end, 0.5f);
        Vector3 beginEnd = end - begin;
        Vector3 perpendicular = new Vector3(-beginEnd.y, beginEnd.x, 0).normalized;
        Vector3 middle = center + perpendicular * delta;
        return middle;
    }

    public static bool IsOutOfScreen(Vector3 pos, float padding = 0)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);

        return screenPos.x > -padding && screenPos.x < Screen.width + padding
                                      && screenPos.y > -padding && screenPos.y < Screen.height + padding;
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
        return (int) result;
    }

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

    public static bool IsPad()
    {
        return (float) Screen.height / Screen.width < 1.4f;
    }

    public static string GetClassicResName()
    {
        if (CommUtil.IsPad())
        {
            //只要这个活动按钮显示了，那么进入局内就应该有局内图标
            if (AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().GameActivityIng())
            {
                return ViewConst.prefab_FRClassicGame;
            }
            else
            {
                return ViewConst.prefab_ClassicGame;
            }
        }
        else
        {
            if (AppEngine.SSystemManager.GetSystem<FastRacePlaySystem>().GameActivityIng())
            {
                return ViewConst.prefab_FRClassicGame;
            }
            else
            {
                return ViewConst.prefab_ClassicGame;
            }
        }

        return "";
    }

    public static void DestroyAll(this Transform transform)
    {
        int count = transform.childCount;
        //Debug.LogError(count);
        for (int i = count - 1; i >= 0; i--)
        {
            //Debug.Log(i);
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }

    public static void DestroyAllIm(this Transform transform)
    {
        int count = transform.childCount;
        for (int i = count - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    public static void SetActive(this Component go, bool b)
    {
        go.gameObject.SetActive(b);
    }

    public static void SetParentActive(this Component go, bool b)
    {
        go.transform.parent.gameObject.SetActive(b);
    }

    public static void SetParent2Active(this Component go, bool b)
    {
        go.transform.parent.parent.gameObject.SetActive(b);
    }
    
    public static int[] GetWordSplit(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return new int[] { };
        }

        if (!word.Contains(","))
        {
            int index = 0;
            if (int.TryParse(word, out index))
            {
                if (index < 1)
                {
                    return new int[] { };
                }

                return new int[] {index};
            }
        }

        string[] words = word.Split(',');
        List<int> indexs = new List<int>();
        int currentindex = 0;
        for (int i = 0; i < words.Length; i++)
        {
            if (int.TryParse(words[i], out currentindex))
            {
                indexs.Add(currentindex);
            }
            else
            {
                return new int[] { };
            }
        }

        int max = 0;
        for (int i = 0; i < indexs.Count; i++)
        {
            max += indexs[i];
            indexs[i] = max;
        }

        indexs.RemoveAt(indexs.Count - 1);
        return indexs.ToArray();
    }

    public static bool HasCacheText(string fileName)
    {
        return Scripts_Game.Utils.Comm.FileUtils.CheckFileExists(Scripts_Game.Utils.Comm.FileUtils.TextPathName,
            fileName);
    }
    public static string LoadCacheCard(string fileName)
    {
        if (Scripts_Game.Utils.Comm.FileUtils.CheckFileExists(Scripts_Game.Utils.Comm.FileUtils.TextPathName,
            fileName))
        {
            try
            {
                return Scripts_Game.Utils.Comm.FileUtils.LoadCacheText(fileName);
            }
            catch (Exception e)
            {
                Scripts_Game.Utils.Comm.FileUtils.DeleteFile(
                    Scripts_Game.Utils.Comm.FileUtils.TextPathName,
                    fileName);
            }
           
        }
        return null;
    }

    public static void SaveCacheText(string fileName,byte[] text)
    {
        try
        {
            Scripts_Game.Utils.Comm.FileUtils.CreateFile(
                Scripts_Game.Utils.Comm.FileUtils.TextPathName, fileName, text);
        }
        catch (Exception e)
        {
        }
        
    }
    
    public static void LoadTittleOrCache(string fileName, Action<Sprite> imageback)
    {
        if (!Scripts_Game.Utils.Comm.FileUtils.CheckFileExists(Scripts_Game.Utils.Comm.FileUtils.TittleImagePath,
            fileName))
        {
            WebRequestGetUtility.Instance.GetTexture(PathLevelConst.ServerImageURL.Replace("/Image/","/Tittle/") + fileName, (op) =>
            {
                if (op.isDone && !op.isHttpError && !op.isNetworkError)
                {
                    DownloadHandlerTexture textureloadhandler = (DownloadHandlerTexture) op.downloadHandler;
                    Texture2D d = textureloadhandler.texture;
                    if (d != null)
                    {
                        var Image = Sprite.Create(d, new Rect(0, 0, d.width, d.height),
                            new Vector2(0.5f, 0.5f));
                        imageback.Invoke(Image);
                        byte[] rawImage = op.downloadHandler.data;
                        Loom.RunAsync(() =>
                        {
                            try
                            {
                            
                                Scripts_Game.Utils.Comm.FileUtils.CreateFile(
                                    Scripts_Game.Utils.Comm.FileUtils.ImagePathName, fileName, rawImage);
                            }
                            catch (Exception e)
                            {
                                Debug.LogError("保存失败");
                                if (Scripts_Game.Utils.Comm.FileUtils.CheckFileExists(
                                    Scripts_Game.Utils.Comm.FileUtils.ImagePathName,
                                    fileName))
                                {
                                    Scripts_Game.Utils.Comm.FileUtils.DeleteFile(
                                        Scripts_Game.Utils.Comm.FileUtils.ImagePathName,
                                        fileName);
                                }
                            }
                        });
                        
                    }
                    else
                    {
                        imageback.Invoke(null);
                    }
                }
                else
                {
                    Debug.Log("Url错误" + PathLevelConst.ServerImageURL.Replace("/Image/","/Tittle/") + fileName);
                    imageback.Invoke(null);
                }
            });
        }
        else
        {
            var d = Scripts_Game.Utils.Comm.FileUtils.LoadTexture(fileName);
            if (d != null)
            {
                var Image = Sprite.Create(d, new Rect(0, 0, d.width, d.height),
                    new Vector2(0.5f, 0.5f));
                imageback.Invoke(Image);
            }
            else
            {
                imageback.Invoke(null);
            }
        }
    }
    public static void LoadCachedImage(string fileName, Action<Sprite> imageback, bool usethread = false)
    {
        if (!Scripts_Game.Utils.Comm.FileUtils.CheckFileExists(Scripts_Game.Utils.Comm.FileUtils.ImagePathName,
            fileName))
        {
            WebRequestGetUtility.Instance.GetTexture(PathLevelConst.ServerImageURL + fileName, (op) =>
            {
                if (op.isDone && !op.isHttpError && !op.isNetworkError)
                {
                    DownloadHandlerTexture textureloadhandler = (DownloadHandlerTexture) op.downloadHandler;
                    Texture2D d = textureloadhandler.texture;
                    if (d != null)
                    {
                        var Image = Sprite.Create(d, new Rect(0, 0, d.width, d.height),
                            new Vector2(0.5f, 0.5f));
                        imageback.Invoke(Image);
                        byte[] rawImage = op.downloadHandler.data;
                        Loom.RunAsync(() =>
                        {
                            try
                            {
                            
                                Scripts_Game.Utils.Comm.FileUtils.CreateFile(
                                    Scripts_Game.Utils.Comm.FileUtils.ImagePathName, fileName, rawImage);
                            }
                            catch (Exception e)
                            {
                                Debug.LogError("保存失败");
                                if (Scripts_Game.Utils.Comm.FileUtils.CheckFileExists(
                                    Scripts_Game.Utils.Comm.FileUtils.ImagePathName,
                                    fileName))
                                {
                                    Scripts_Game.Utils.Comm.FileUtils.DeleteFile(
                                        Scripts_Game.Utils.Comm.FileUtils.ImagePathName,
                                        fileName);
                                }
                            }
                        });
                        
                    }
                    else
                    {
                        imageback.Invoke(null);
                    }
                }
                else
                {
                    Debug.Log("Url错误" + PathLevelConst.ServerImageURL + fileName);
                    imageback.Invoke(null);
                }
            });
        }
        else
        {
            if (usethread)
            {
                Loom.RunAsync(() =>
                {
                    var d = Scripts_Game.Utils.Comm.FileUtils.LoadTexture(fileName);
                    if (d != null)
                    {
                        var Image = Sprite.Create(d, new Rect(0, 0, d.width, d.height),
                            new Vector2(0.5f, 0.5f));
                        Loom.QueueOnMainThread(() =>
                        {
                            imageback.Invoke(Image);
                        });
                    }
                    else
                    {
                        Loom.QueueOnMainThread(() => { imageback.Invoke(null); });
                    }
                });
            }
            else
            {
                var d = Scripts_Game.Utils.Comm.FileUtils.LoadTexture(fileName);
                if (d != null)
                {
                    var Image = Sprite.Create(d, new Rect(0, 0, d.width, d.height),
                        new Vector2(0.5f, 0.5f));
                    imageback.Invoke(Image);
                }
                else
                {
                    imageback.Invoke(null);
                }
            }
        }
    }
}