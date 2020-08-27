using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class BaseSideFloatWindow : UIWindowBase
{
    public SideFloatDirection direction = SideFloatDirection.fromTop;
    public RectTransform content = null;
    public TextMeshProUGUI desTextMesh;
    public float moveAniLength = 0.5f;
    public bool autoClose = false;

    private float moveDistance;
    private Vector3 originalLocalPos;
    private Tweener tweener = null;

    protected override void OnUiCreate()
    {
        base.OnUiCreate();
    }

    public override void OnOpen()
    {
        base.OnOpen();
        if (windowStatus == WindowStatus.Create)
        {
            content = (RectTransform)transform.GetChild(0);
            originalLocalPos = content.localPosition;
            switch (direction)
            {
                case SideFloatDirection.fromTop:
                    moveDistance = content.sizeDelta.y;
                    if (XUtils.IsIphoneX())
                        moveDistance += 50;
                    break;
                case SideFloatDirection.fromBottom:
                    moveDistance = content.sizeDelta.y;
                    break;
                case SideFloatDirection.fromLeft:
                    moveDistance = content.sizeDelta.x;
                    break;
                case SideFloatDirection.fromRight:
                    moveDistance = content.sizeDelta.x;
                    break;
            }
        }
        else
            content.localPosition = originalLocalPos;
        InitText();
    }

    protected virtual void InitText()
    {
        desTextMesh.text = (string)objs[0];
    }

    public override IEnumerator EnterAnim(params object[] objs)
    {
        AppearAni();
        yield return new WaitForSeconds(moveAniLength);
        OpenSuccess();
        if (autoClose)
        {
            yield return new WaitForSeconds(1f);
            if (windowStatus == UIWindowBase.WindowStatus.Opened)
                Close();
        }
    }

    public override IEnumerator ExitAnim(UICallBack l_callBack, params object[] objs)
    {
        DisappearAni();
        yield return new WaitForSeconds(moveAniLength);
        ExitSuccess();
        yield break;
    }

    protected override void ShowAnimation()
    {
        AppearAni();
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
        base.OnClose();
        KeyEventManager.Instance.RemoveBackPressListener(KeyEventManager.Priority.hppp, onBackPressed);
        EventUtil.EventDispatcher.TriggerEvent(GlobalEvents.CloseUI, UIName);
        m_CloseCallback?.Invoke(this);
    }

    protected void AppearAni()
    {
        if (tweener != null)
        {
            tweener.Kill();
            tweener = null;
        }
        content.localPosition = originalLocalPos;
        switch (direction)
        {
            case SideFloatDirection.fromTop:
                //tweener = content.DOLocalMove(originalLocalPos - new Vector3(0, moveDistance, 0), moveAniLength);
                anim.SetTrigger("down");
                break;
            case SideFloatDirection.fromBottom:
                tweener = content.DOLocalMove(originalLocalPos + new Vector3(0, moveDistance, 0), moveAniLength);
                break;
            case SideFloatDirection.fromLeft:
                tweener = content.DOLocalMove(originalLocalPos + new Vector3(moveDistance, 0, 0), moveAniLength);
                break;
            case SideFloatDirection.fromRight:
                tweener = content.DOLocalMove(originalLocalPos - new Vector3(moveDistance, 0, 0), moveAniLength);
                break;
        }
    }

    protected void DisappearAni()
    {
        if (tweener != null)
        {
            tweener.Kill();
            tweener = null;
        }
        if (direction == SideFloatDirection.fromTop)
            anim.SetTrigger("up");
        else
            tweener = content.DOLocalMove(originalLocalPos, moveAniLength);
    }
}

public enum SideFloatDirection
{
    fromTop,
    fromBottom,
    fromLeft,
    fromRight
}
