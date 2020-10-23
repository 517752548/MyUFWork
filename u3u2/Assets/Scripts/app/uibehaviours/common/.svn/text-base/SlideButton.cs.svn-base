using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class SlideButton : UnityEngine.MonoBehaviour
{
    public GameUUButton btn;
    public Text btnText;
    public Text bgText;
    public string leftText;
    public string rightText;
    public Vector3 leftPos;
    public Vector3 rightPos;

    private UnityAction completeCallBack;
    private UnityAction updateCallBack;

    private TabChangeHandler _tabChangeHandler;

    private int _currentTabIndex = 0;
    public bool useTween = true;
    private float usetime = 0.2f;

    public TabChangeHandler TabChangeHandler
    {
        set { _tabChangeHandler = value; }
    }

    public void Init(GameUUButton button, Text btnText, Text bgText, string leftText, string rightText, Vector3 leftPos, Vector3 rightPos)
    {
        this.btn = button;
        this.btnText = btnText;
        this.bgText = bgText;

        this.leftText = leftText;
        this.rightText = rightText;
        this.leftPos = leftPos;
        this.rightPos = rightPos;

        btn.SetClickCallBack(clickBtn);
        EventTriggerListener.Get(bgText.gameObject).onClick = clickBtn;
        updatePos();
    }

    public void MoveTo(GameObject go, Vector3 pos, float time, UnityAction completeCallbackv = null, UnityAction updateCallbackv = null)
    {
        go.transform.DOLocalMove(pos, time).OnComplete(CompleteCallBack).OnUpdate(UpdateCallBack).SetEase(Ease.Linear);
    }

    private void CompleteCallBack()
    {
        if (completeCallBack != null)
        {
            completeCallBack();
        }
    }

    private void UpdateCallBack()
    {
        if (updateCallBack != null)
        {
            updateCallBack();
        }
    }

    private void updatePos()
    {
        //Debug.Log(name + " currentTabIndex updatePos : " + _currentTabIndex);
        switch (_currentTabIndex)
        {
            case 0:
                if (useTween)
                {
                    MoveTo(btn.gameObject, leftPos, usetime);
                }
                else
                {
                    btn.transform.localPosition = leftPos;
                }
                bgText.transform.localPosition = rightPos;
                btnText.text = leftText;
                bgText.text = rightText;
                break;
            case 1:
                if (useTween)
                {
                    MoveTo(btn.gameObject, rightPos, usetime);
                }
                else
                {
                    btn.transform.localPosition = rightPos;
                }
                bgText.transform.localPosition = leftPos;
                btnText.text = rightText;
                bgText.text = leftText;
                break;
        }
    }

    public void UpdateText()
    {
        switch (_currentTabIndex)
        {
            case 0:
                btnText.text = leftText;
                bgText.text = rightText;
                break;
            case 1:
                btnText.text = rightText;
                bgText.text = leftText;
                break;
        }
    }

    private void clickBtn(GameObject go)
    {
        _currentTabIndex = _currentTabIndex == 0 ? 1 : 0;
        updatePos();
        if (_tabChangeHandler != null)
        {
            _tabChangeHandler(_currentTabIndex);
        }
    }

    public int index
    {
        get
        {
            return _currentTabIndex;
        }
        set
        {
            if (_currentTabIndex != value)
            {
                clickBtn(null);
            }
        }
    }
}
