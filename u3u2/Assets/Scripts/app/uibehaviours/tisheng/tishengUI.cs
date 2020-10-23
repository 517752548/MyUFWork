using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TiShengUI : MonoBehaviour 
{
    public GridLayoutGroup grid;
    public tishengItemUI itemUI;

    public void Init()
    {
        grid = transform.Find("Image_mask/scrollRect/itemGrid").GetComponent<GridLayoutGroup>();
        itemUI = transform.Find("Image_mask/scrollRect/itemGrid/RewardItem").gameObject.AddComponent<tishengItemUI>();
        itemUI.Init();
    }
    
}
