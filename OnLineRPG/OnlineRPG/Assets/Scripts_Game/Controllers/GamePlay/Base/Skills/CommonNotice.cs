using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommonNotice : UIWindowBase
{
    public TextMeshProUGUI levelText;

    public RectTransform content = null;
    public float moveAniLength = 0.5f;
    private bool autoClose = true;

    public override void OnOpen()
    {
        base.OnOpen();
        if (windowStatus == WindowStatus.Create)
        {
            content = (RectTransform)transform.GetChild(0);
        }

        levelText.text = (objs[0] as string);
    }

    public override IEnumerator EnterAnim(params object[] objs)
    {
        anim.SetTrigger("down");
        yield return new WaitForSeconds(moveAniLength);
        OpenSuccess();
        if (autoClose)
        {
            yield return new WaitForSeconds(2f);
            if (windowStatus == UIWindowBase.WindowStatus.Opened)
                Close();
        }
    }

    public override IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
    {
        anim.SetTrigger("up");
        yield return new WaitForSeconds(moveAniLength);
        ExitSuccess();
        yield break;
    }

    protected override void ShowAnimation()
    {
        anim.SetTrigger("down");
    }

    protected override bool ResponseClick { get { return true; } }

    public override void Close()
    {
        if (windowStatus == WindowStatus.Opening)
        {
            StopAllCoroutines();
        }
        windowStatus = UIWindowBase.WindowStatus.Opened;
        base.Close();
    }

    public override void OnClose()
    {
        KeyEventManager.Instance.RemoveBackPressListener(KeyEventManager.Priority.hppp, onBackPressed);
        EventUtil.EventDispatcher.TriggerEvent(GlobalEvents.CloseUI, UIName);
        m_CloseCallback?.Invoke(this);
    }
}
