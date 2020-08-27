using System.Collections.Generic;
using UnityEngine;

public class FlyFlowerPool : MonoBehaviour
{
    public List<GameObject> flyFlowerList;
    public GameObject flyFlowerListPrefab;

    public GameObject GetFlyFlower()
    {
        GameObject go = null;
        if (flyFlowerList.Count > 0)
        {
            go = flyFlowerList[0];
            flyFlowerList.Remove(go);
        }
        else
        {
            go = InitFlyFlower();
        }
        return go;
    }

    private GameObject InitFlyFlower()
    {
        return Instantiate(flyFlowerListPrefab);
    }
}