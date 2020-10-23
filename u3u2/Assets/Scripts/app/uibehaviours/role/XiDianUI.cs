using UnityEngine;
using System.Collections;

public class XiDianUI : MonoBehaviour
{
    public CommonItemUI itemui;
    public GameUUButton sureBtn;
    public GameUUButton cancelBtn;

    public void Init()
    {
        itemui = transform.Find("CommonItemUI70_70").gameObject.AddComponent<CommonItemUI>();
        itemui.Init();
        sureBtn = transform.Find("sureBtn").GetComponent<GameUUButton>();
        cancelBtn = transform.Find("cancelBtn").GetComponent<GameUUButton>();

    }
}
