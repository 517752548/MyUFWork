using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public static class CExtension
{
    public static void SetText(this GameObject obj, string value)
    {
        Text text = obj.GetComponent<Text>();
        if (text != null)
        {
            text.text = value;
        }
    }

    public static void SetText(this Text objText, string value)
    {
        objText.text = value;
    }

    public static void SetTimeText(this Text text, String preFix, int time)
    {
        TimeSpan t = TimeSpan.FromSeconds(time);
        text.text = preFix + string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }

    public static List<int> GetRandomInt(this int count, int num)
    {

        List<int> listInt = new List<int>();
        for (int i = 0; i < count; i++)
        {
            listInt.Add(i);
        }

        int distance = count - num;
        for (int i = 0; i < distance; i++)
        {
            listInt.RemoveAt(Random.Range(0, listInt.Count));
        }
        return listInt;
    }

    public static List<T> GetRandomList<T>(this List<T> list, int num)
    {
        if (num >= list.Count)
        {
            return list;
        }
        else
        {
            List<T> randomList = new List<T>();
            List<int> randomIndex = list.Count.GetRandomInt(num);
            for (int i = 0; i < randomIndex.Count; i++)
            {
                randomList.Add(list[randomIndex[i]]);
            }
            return randomList;
        }
    }
    // <summary>
    /// 查找子物体（递归查找）  
    /// </summary> 
    /// <param name="trans">父物体</param>
    /// <param name="goName">子物体的名称</param>
    /// <returns>找到的相应子物体</returns>
    public static Transform FindChild(this Transform trans, string goName)
    {
        Transform child = trans.Find(goName);
        if (child != null)
            return child;

        Transform go = null;
        for (int i = 0; i < trans.childCount; i++)
        {
            child = trans.GetChild(i);
            go = FindChild(child, goName);
            if (go != null)
                return go;
        }
        return null;
    }
    /// <summary>
    /// 查找子物体（递归查找）  where T : UnityEngine.Object
    /// </summary> 
    /// <param name="trans">父物体</param>
    /// <param name="goName">子物体的名称</param>
    /// <returns>找到的相应子物体</returns>
    public static T SearchChild<T>(this Transform trans, string goName) where T : Transform
    {
        Transform child = trans.Find(goName);
        if (child != null)
        {
            return child.GetComponent<T>();
        }

        Transform go = null;
        for (int i = 0; i < trans.childCount; i++)
        {
            child = trans.GetChild(i);
            go = SearchChild<T>(child, goName);
            if (go != null)
            {
                return go.GetComponent<T>();
            }
        }
        return null;
    }
    
    public static void StartWaitForEndOfFrame(this MonoBehaviour behaviour, Action onEndOfFrame)
    {
        behaviour.StartCoroutine(WaitForEndOfFrame(onEndOfFrame));
    }

    public static IEnumerator WaitForEndOfFrame(Action onEndOfFrame)
    {
        yield return new WaitForEndOfFrame();
        onEndOfFrame?.Invoke();
    }
}