using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ButtonCD : MonoBehaviour
{
    public float cdTime = 1f;

    private Button btn;

    private bool waitRecovery = false;

    // Use this for initialization
    void Start()
    {
        waitRecovery = false;
        btn = gameObject.GetComponent<Button>();
        if (btn == null)
        {
            btn = gameObject.AddComponent<Button>();
            btn.transition = Selectable.Transition.None;
        }
        btn.onClick.AddListener(onClick);
    }
    
    private void OnDisable()
    {
        if (btn != null && waitRecovery)
            btn.interactable = true;
    }

    private void onClick()
    {
        waitRecovery = true;
        DoButtonCD(btn, cdTime, () => waitRecovery = false);
    }

    public static void DoButtonCD(Button btn, float cdTime, Action callback = null)
    {
        if (btn == null)
        {
            callback?.Invoke();
            return;
        }
        btn.interactable = false;
        btn.StartCoroutine(DoButtonCDTask(btn, cdTime, callback));
    }

    private static IEnumerator DoButtonCDTask(Button btn, float cdTime, Action callback)
    {
        yield return new WaitForSeconds(cdTime);
        btn.interactable = true;
        callback?.Invoke();
    }
}
