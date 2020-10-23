using UnityEngine;
using UnityEngine.UI;

public delegate void CallBackSwitchButton(UGUISwitchButton sb = null);

public class UGUISwitchButton : UnityEngine.MonoBehaviour
{
    public GameUUButton BackButton;
    public GameUUButton ForeButton;
    public Text UILabel;

    /// <summary>
    /// 当前是否选中
    /// </summary>
    private bool _IsSelected = false;
    /// <summary>
    /// 点击回调
    /// </summary>
    private CallBackSwitchButton _clickCallBack;
    public CallBackSwitchButton ClickCallBack
    {
        set { _clickCallBack = value; }
    }

    // Use this for initialization
    public void Init(GameUUButton backBtn, GameUUButton foreBtn, Text label)
    {
        BackButton = backBtn;
        ForeButton = foreBtn;
        UILabel = label;

        if (BackButton != null && ForeButton != null)
        {
            //EventTriggerListener.Get(BackButton.gameObject).onClick = DoClick;
            //EventTriggerListener.Get(ForeButton.gameObject).onClick = DoClick;
            BackButton.SetClickCallBack(DoClick);
            ForeButton.SetClickCallBack(DoClick);
            DoClick(null);
        }
    }

    /// <summary>
    /// 设置选中
    /// </summary>
    /// <param name="valuev"></param>
    private void SetSelected(bool valuev)
    {
        if (BackButton != null)
        {
            BackButton.gameObject.SetActive(valuev);
        }

        if (ForeButton != null)
        {
            ForeButton.gameObject.SetActive(!valuev);
        }

        _IsSelected = valuev;
    }

    private void DoClick(GameObject go)
    {
        if (go == BackButton.gameObject)
        {
            SetSelected(false);
        }
        else
        {
            SetSelected(true);
        }
        if (go != null && _clickCallBack != null)
        {
            _clickCallBack(this);
        }
    }

    /// <summary>
    /// 设置按钮的可用状态
    /// </summary>
    public bool isEnabled
    {
        set
        {
            if (value)
            {
                if (UILabel != null) UILabel.color = new Color(1f, (float)242 / 255, (float)207 / 255, 1);
            }
            else
            {
                if (UILabel != null) UILabel.color = Color.gray;
            }
            this.isEnabled = value;
        }
    }
    /// <summary>
    /// 设置按钮的文本内容
    /// </summary>
    public string Label
    {
        get
        {
            if (UILabel != null)
            {
                return UILabel.text;
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (UILabel != null) UILabel.text = value;
        }
    }

    /// <summary>
    /// 当前是否选中
    /// </summary>
    public bool IsSelected
    {
        get
        {
            return _IsSelected;
        }
        set
        {
            SetSelected(value);
        }
    }

}
