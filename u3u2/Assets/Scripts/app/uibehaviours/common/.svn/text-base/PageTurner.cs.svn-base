using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 翻页回调,索引从0开始
/// </summary>
public delegate void PageChangeHandler(int currentPageIndex);

/// <summary>
/// 翻页组件
/// </summary>
public class PageTurner : MonoBehaviour
{
    /// <summary>
    /// 翻页事件
    /// </summary>
    public static string PAGE_CHANGE_EVENT = "PAGE_CHANGE_EVENT";

    public GameUUButton _leftImgBtn;

    public GameUUButton _rightImgBtn;

    public Text _currentPageText;

    private int _maxValue = 100;
    /// <summary>
    /// 当前页，从0到_maxValue-1
    /// </summary>
    private int _value = 0;
    /// <summary>
    /// 是否循环
    /// </summary>
    private bool _loop = false;
    /// <summary>
    /// 翻页事件回调
    /// </summary>
    private PageChangeHandler _pageChangeHandler;
    /// <summary>
    /// 左右翻页按钮自动隐藏
    /// </summary>
    private bool autoVisible = false;

    public void Init()
    {
        Init(transform.Find("leftButton").GetComponent<GameUUButton>(), 
            transform.Find("rightButton").GetComponent<GameUUButton>(), 
            transform.Find("Text")!=null?transform.Find("Text").GetComponent<Text>():null);
    }

    /// <summary>
    /// 翻页
    /// </summary>
    /// <param name="leftBtn">左按钮</param>
    /// <param name="rightBtn">右按钮</param>
    /// <param name="pageChangeHandler">翻页事件回调</param>
    /// <param name="loop">是否循环</param>
    public void Init(GameUUButton leftBtn, GameUUButton rightBtn, Text pageNum)
    {
        this._leftImgBtn = leftBtn;
        this._rightImgBtn = rightBtn;
        this._currentPageText = pageNum;
        _leftImgBtn.SetClickCallBack(clickLeft);
        _rightImgBtn.SetClickCallBack(clickRight);
    }

    public int MaxValue
    {
        get { return _maxValue; }
        set
        {
            if (value < 1)
            {
                value = 1;
            }
            this._maxValue = value;
            if (this._value > (this._maxValue - 1))
            {
                Value = (this._maxValue - 1);
            }
            this.updateButtonVisible();
        }
    }

    public int Value
    {
        get { return _value; }
        set
        {
            if (Loop)
            {//循环
                if (value < 0)
                {
                    value = (_maxValue + value) % (_maxValue);
                }
                else if (value > (_maxValue - 1))
                {
                    value = value % (_maxValue);
                }
            }
            else
            {//不循环
                if (value < 0)
                {
                    value = 0;
                }
                if (value >= this._maxValue - 1)
                {
                    value = (this._maxValue - 1);
                }
            }
            _value = value;
            if (_currentPageText != null)
            {
                _currentPageText.text = (_value + 1) + "/" + _maxValue;
            }
            this.updateButtonVisible();
        }
    }

    /// <summary>
    /// 是否循环
    /// </summary>
    public bool Loop
    {
        get { return _loop; }
        set { _loop = value; }
    }

    /// <summary>
    /// 翻页事件回调
    /// </summary>
    public PageChangeHandler PageChangeHandler
    {
        set { _pageChangeHandler = value; }
    }

    /// <summary>
    /// 左右翻页按钮自动隐藏
    /// </summary>
    public bool AutoVisible
    {
        set { autoVisible = value; }
    }

    private void clickLeft()
    {
        if (this._value == 0 && (Loop == false))
        {
            return;
        }
        Value = (this._value - 1);
        if (this._pageChangeHandler != null)
        {
            _pageChangeHandler(_value);
        }
    }

    private void clickRight()
    {
        if (this._value >= (this._maxValue - 1) && (Loop == false))
        {
            return;
        }
        Value = this._value + 1;
        if (this._pageChangeHandler != null)
        {
            _pageChangeHandler(_value);
        }
    }

    private void updateButtonVisible()
    {
        if (!Loop && autoVisible)
        {
            if (this._value >= (this._maxValue - 1))
            {
                this._rightImgBtn.gameObject.SetActive(false);
            }
            else
            {
                this._rightImgBtn.gameObject.SetActive(true);
            }
            if (this._value != 0)
            {
                this._leftImgBtn.gameObject.SetActive(true);
            }
            else
            {
                this._leftImgBtn.gameObject.SetActive(false);
            }
        }
        else
        {
            //this._leftImgBtn.isEnabled = true;
            //this._rightImgBtn.isEnabled = true;
        }
    }
    /// <summary>
    /// 销毁
    /// </summary>
    public void dispose()
    {
        _leftImgBtn = null;
        _rightImgBtn = null;
        PageChangeHandler = null;
        _value = 0;
        _maxValue = 1;
        Loop = false;
    }
}