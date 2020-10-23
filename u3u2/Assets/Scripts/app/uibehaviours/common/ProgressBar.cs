using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public enum ProgressBarLabelType
{
    None,
    NoModify,
    Percent,//显示：30%
    CurrentAndMax//显示：30/100
}

public class ProgressBar : MonoBehaviour
{
    /// <summary>
    /// 背景条
    /// </summary>
    public Image backGround;
    /// <summary>
    /// 进度条
    /// </summary>
    public Image forGround;
    /// <summary>
    /// 文本
    /// </summary>
    public Text label;
    
    /// <summary>
    /// 文本类型
    /// </summary>
    private ProgressBarLabelType _labelType;
    /// <summary>
    /// 百分比
    /// </summary>
    private float _percent = 0;
    
    public float progressBarWidth = 0;

    private string _valueStr = "";
    private string _maxValueStr = "";

    private double _value;
    private double _maxValue;

    public void Init(float progressBarWidth, float percent = 0.0f)
    {
        Init(transform.Find("background").GetComponent<Image>(), 
            transform.Find("foreground").GetComponent<Image>(), 
            transform.Find("Text").GetComponent<Text>(), 
            progressBarWidth, 
            percent);
    }

    public void Init(Image background, Image forground, Text label, float progressBarWidth, float percent = 0.0f)
    {
        this.backGround = background;
        this.forGround = forground;
        this.label = label;
        this._percent = percent;
        this.progressBarWidth = progressBarWidth;
        
        /*
        if (zeroProgressPosition == 0f && forGround != null)
        {
            zeroProgressPosition = -forGround.rectTransform.sizeDelta.x;
        }
        */
        //if (_percent == -1)
        //{
            //backGround.gameObject.transform.localPosition = Vector3.zero;
            //forGround.gameObject.transform.localPosition = new Vector3(zeroProgressPosition, 0, 0);
            Vector2 size = forGround.rectTransform.sizeDelta;
            size.x = float.IsNaN(_percent)?0:progressBarWidth * _percent;
            forGround.rectTransform.sizeDelta = size;
        //}
    }

    public double MaxValue
    {
        get { return _maxValue; }
        set { _maxValue = value; _maxValueStr = value.ToString(); }
    }
    
    public void setLongPercent(long maxValue, long curValue)
    {
        _valueStr = curValue.ToString();
        _maxValueStr = maxValue.ToString();
        _maxValue = (double)maxValue;
        _value = (double)curValue;
        float percentf =  _maxValue !=0?(float)((_value * 1.0f) / (_maxValue * 1.0f)):0;
        _percent = percentf;
        setPercent();
    }

    public double Value
    {
        get { return _value; }
        set
        {
            _valueStr = value.ToString();
            if (value > this._maxValue)
            {
                value = this._maxValue;
            }
            if (value < 0)
            {
                value = 0;
            }
            //默认为保留两位
            float percentf = (float)(value / this._maxValue);
            this._value = value;
            _percent = percentf;
            setPercent();
        }
    }

    public float Percent
    {
        get { return _percent; }
        set
        {
            if (_percent == value)
            {
                return;
            }
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 1)
            {
                value = 1;
            }
            _percent = value;
            setPercent();
        }
    }

    private void setPercent()
    {
        if (float.IsInfinity(_percent))
        {
            ClientLog.LogError("进度条百分比为无穷大 maxvalue:" + MaxValue);
            return;
        }
        int percent = (int)(_percent * 100);
        //string percentStr = string.Format("{0:F}", percent * 100);
        if (label != null)
        {
            switch (_labelType)
            {
                case ProgressBarLabelType.None:
                    label.text = "";
                    break;
                case ProgressBarLabelType.Percent:
                    label.text = percent + "%";
                    break;
                case ProgressBarLabelType.CurrentAndMax:
                    label.text = _valueStr + "/" + _maxValueStr;
                    break;
            }
        }
        //设置进度
        //Hashtable moveArgs = new Hashtable();
        //moveArgs.Add("isLocal", true);
        //moveArgs.Add("position", new Vector3(getForgroundWidth(_percent), 0, 0));
        //moveArgs.Add("time", 0.1f);
        //iTween.Stop(forGround.gameObject);
        //iTween.MoveTo(forGround.gameObject, moveArgs);

        /*
        TweenParms tp = new TweenParms();
        tp.Prop("localPosition", new Vector3(getForgroundWidth(_percent), 0, 0));
        HOTween.To(forGround.transform, 0.1f, tp);
        */
        //forGround.transform.DOLocalMove(new Vector3(getForgroundWidth(_percent), 0, 0), 0.1f);
        Vector2 size = forGround.rectTransform.sizeDelta;
        _percent = _percent > 1 ? 1 : _percent;
        size.x = float.IsNaN(_percent)?0:progressBarWidth * _percent;
        forGround.rectTransform.sizeDelta = size;
        
    }

    public ProgressBarLabelType LabelType
    {
        set { _labelType = value; }
    }

    // Use this for initialization

}

