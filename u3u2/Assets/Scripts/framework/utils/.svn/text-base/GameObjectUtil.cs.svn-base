using UnityEngine;

public class GameObjectUtil
{
    public static void Bind(Transform child, Transform parent, bool resetPos = true, bool resetRot = false)
    {
        if (child != null)
        {
            child.SetParent(parent);
            if (resetPos)
            {
                child.position = Vector3.zero;
                child.localPosition = Vector3.zero;
            }
            if (resetRot)
            {
                child.eulerAngles = Vector3.zero;
                child.localEulerAngles = Vector3.zero;
            }
        }
    }

    public static void SetLayer(GameObject obj, int layer)
    {
        obj.layer = layer;
        foreach (Transform tran in obj.GetComponentsInChildren<Transform>(true))
        {
            //遍历当前物体及其所有子物体
            tran.gameObject.layer = layer;//更改物体的Layer层
        }
    }

    public static Transform GetTransformByName(GameObject go, string name)
    {
        if (go == null || string.IsNullOrEmpty(name))
        {
            return null;
        }
        Transform[] ts = go.GetComponentsInChildren<Transform>(true);
        int len = ts.Length;
        for (int i = 0; i < len; i++)
        {
            Transform child = ts[i];
            if (child.name == name)
            {
                return child;
            }
        }
        return null;
    }

    public static void DestroyChild(int start, Transform t)
    {
        for (int i = start; i < t.childCount; i++)
        {
            GameObject.DestroyImmediate(t.GetChild(i), true);
        }
    }

}