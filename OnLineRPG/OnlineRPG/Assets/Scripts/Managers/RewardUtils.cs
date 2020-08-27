using System;
using UnityEngine;

public class RewardUtils : MonoBehaviour
{
    public Action UpdateAction;
    public Action OneSecondAction;
    public GameObject[] Gift_Item;
    private static RewardUtils _instance = null;
    private float time = 0;

    public Sprite[] pushAdMaterials;

    public static RewardUtils Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<RewardUtils>();
            }
            return _instance;
        }
    }

    /// <summary>
    /// 获取奖励的对象
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public GameObject GetRewardObj(int type)
    {
        GameObject obj = null;
        if (Gift_Item.Length > type)
        {
            obj = Instantiate(Gift_Item[type]);
        }
        return obj;
    }

    /// <summary>
    /// 获取带数量的奖励对象
    /// </summary>
    /// <param name="type"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    public GameObject GetRewardObj(int type, int num)
    {
        GameObject obj = null;
        if (Gift_Item.Length > type)
        {
            obj = Instantiate(Gift_Item[type]);
//            obj.GetComponent<GiftItem>().SetText(num + "");
        }
        return obj;
    }

    private void Update()
    {
        if (UpdateAction != null) UpdateAction.Invoke();
        time += Time.deltaTime;
        if (time >= 1.0f)
        {
            if (OneSecondAction != null) OneSecondAction.Invoke();
            time = 0;
        }
    }
}