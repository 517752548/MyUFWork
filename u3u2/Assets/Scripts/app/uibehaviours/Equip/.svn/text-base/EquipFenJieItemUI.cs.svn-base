using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EquipFenJieItemUI : MonoBehaviour
{

    public CommonItemUI item;
    public GameUUButton deleteBtn;
    public Text equipLevel;
    public GameUUToggle selectToggle;

    public void Init()
    {
        item = gameObject.AddComponent<CommonItemUI>();
        item.Init();
        if (transform.Find("Button")!=null)
        {
            deleteBtn = transform.Find("Button").GetComponent<GameUUButton>();
        }
        if (transform.Find("Text")!=null)
        {
            equipLevel = transform.Find("Text").GetComponent<Text>();
        }
        if (transform.Find("Toggle") != null)
        {
            selectToggle = transform.Find("Toggle").GetComponent<GameUUToggle>();
        }
    }
}
