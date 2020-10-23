using System;
using System.Collections;
using System.Collections.Generic;

public class Singleton
{
    private static Dictionary<Type, BaseUI> map = new Dictionary<Type, BaseUI>();

    public static BaseUI GetObj(Type type)
    {
        if (map.ContainsKey(type) == false)
        {
            BaseUI obj = Activator.CreateInstance(type) as BaseUI;
            map[type] = obj;
        }
        return map[type];
    }

    public static void RemoveObj(Type type)
    {
        if (HasObj(type))
        {
            map.Remove(type);
        }
    }

    public static bool HasObj(Type type)
    {
        return map.ContainsKey(type);
    }

    public static void DestroyAll()
    {
        List<BaseUI> uis = new List<BaseUI>();
        IDictionaryEnumerator enumerator = map.GetEnumerator();
        while (enumerator.MoveNext())
        {
			uis.Add(enumerator.Value as BaseUI);
        }
		map.Clear();
        
        int len = uis.Count;
        for (int i = 0; i < len; i++)
        {
            if (uis[i] != null)
            {
                uis[i].Destroy();
            }
        }
    }

    public static void LogObjs()
    {
        ClientLog.LogError("==========Singleton objs==========");
        IDictionaryEnumerator enumerator = map.GetEnumerator();
        int count = 0;
        while (enumerator.MoveNext())
        {
            ClientLog.LogError(((Type)(enumerator.Key)).ToString());
            count++;
        }
        ClientLog.LogError("objsCount:" + count);
    }
}