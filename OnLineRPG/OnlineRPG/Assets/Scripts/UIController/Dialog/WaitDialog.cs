using System;
using System.Collections;
using BetaFramework;
using UnityEngine;
using UnityEngine.UI;

public class WaitDialog : UIWindowBase
{
    public Text LoadText;

    private float outTime = -1;
    private Action callback;
    private bool endWait = false;

    public static bool isShowing = false;

    public override void OnOpen()
    {
        base.OnOpen();
        if (objs != null && objs.Length > 0)
        {
            if (LoadText != null && objs[0] != null)
            {
                LoadText.text = (string)objs[0];
                LoadText.gameObject.SetActive(true);
            }
            if (objs.Length > 2)
            {
                outTime = (float)objs[1];
                callback = (Action)objs[2];
                StartCoroutine(DoWaitTime());
            }
            else
            {
                outTime = -1;
                callback = null;
            }
        }
        endWait = false;
    }

    private IEnumerator DoWaitTime()
    {
        yield return new WaitForSeconds(outTime);
        if (!endWait)
        {
            EndWait();
            if (callback != null)
                callback();
        }
    }

    public override IEnumerator EnterAnim(params object[] objs)
    {
        OpenSuccess();
        yield break;
    }

    public override IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
    {
        ExitSuccess();
        yield break;
    }

    public override void Close()
    {
        endWait = true;
        base.Close();
    }

    private static UIWindowBase dlg = null;

    public static void StartWait(string text = null)
    {
        Debug.LogError("开启");
        EndWait();
        UIManager.OpenUIAsync(ViewConst.prefab_WaitDialog, (UIWindowBase UI, object[] objs) =>
        {
            dlg = UI;
            isShowing = true;
        }, text);
    }

    public static void StartWait(float time, Action timeOutCallback, string text = null)
    {
        EndWait();
        UIManager.OpenUIAsync(ViewConst.prefab_WaitDialog, (UIWindowBase UI, object[] objs) =>
        {
            dlg = UI;
        }, text, time, timeOutCallback);
    }

    public static void EndWait()
    {
        Debug.LogError("关闭");
        if (dlg != null)
        {
            UIManager.CloseUIWindow(dlg);
            isShowing = false;
            dlg = null;
        }
    }

    public static bool IsWaitEnd()
    {
        return dlg == null;
    }
}