using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class HintCommNotice : UIWindowBase
{
    public Image iconImage;
    public GameObject normalDes, lockDes;
    public TextMeshProUGUI titleText, desText, levelText;
    public Sprite hint1, hint2, hint3, hint4;

    public RectTransform content = null;
    public float moveAniLength = 0.5f;
    public bool autoClose = false;

    public override void OnOpen()
    {
        base.OnOpen();
        if (windowStatus == WindowStatus.Create)
        {
            content = (RectTransform)transform.GetChild(0);
        }

        bool isLocked = objs.Length > 1;
        titleText.text = (objs[0] as BaseHint).GetHintTitle();
        titleText.gameObject.SetActive(false);
        autoClose = isLocked;
        if (objs[0] is SpecificCellHint)
        {
            iconImage.sprite = hint1;
            desText.text = "Select a square, reveals a single letter of your choice";
        }
        else if (objs[0] is KeyboardHint)
        {
            iconImage.sprite = hint2;
            desText.text = "Select a row, clears away letters not in the Answer";
        }
        else if (objs[0] is MultiCellsHint)
        {
            iconImage.sprite = hint3;
        }
        else if (objs[0] is SpecificWordHint)
        {
            iconImage.sprite = hint4;
            desText.text = "Select a row, reveals an entire word";
        }
        if (isLocked)
        {
            levelText.text = string.Format("LEVEL {0}", objs[1]);
        }
        normalDes.SetActive(!isLocked);
        lockDes.SetActive(isLocked);
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
