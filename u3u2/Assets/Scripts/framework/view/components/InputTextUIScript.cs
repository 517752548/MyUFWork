using app.zone;
using UnityEngine.UI;
using System.Collections.Generic;

public class InputTextUIScript : BaseUI
{
    private InputTextUI UI;
    private int minValue;
    private int maxValue;
    private int perValue;
    private int offset = 0;
    private int currentValue;
    private TabChangeHandler _tabChangeHandler;
    private bool canInput = false;
    private InputField inputField;
    private int defaultValue=1;
    //输入完的后缀，比如“两”、"文" 等
    private string suffixStr = "";

    public InputTextUIScript(InputTextUI ui,string suffixstr="")
    {
        UI = ui;
        suffixStr = suffixstr;
        InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, UI.jiaBtn.gameObject, clickJiaBtn);
        UI.jiaBtn.SetClickCallBack(clickJiaBtn);
        InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, UI.jianBtn.gameObject, clickJianBtn);
        UI.jianBtn.SetClickCallBack(clickJianBtn);
    }

    public void setDefaultValue(int defaultvalue, int currencyType)
    {
        defaultValue = defaultvalue;
        currentValue = defaultvalue;
        UI.inputText.text = defaultvalue.ToString();
        if (inputField != null)
        {
            inputField.text = defaultValue.ToString() + suffixStr;
        }
        string moneyIconPath = CurrencyTypeDef.GetCurrencyIcon(currencyType);
        if (!string.IsNullOrEmpty(moneyIconPath) && UI.moneyIcon!=null)
        {
            PathUtil.Ins.SetSprite(UI.moneyIcon, moneyIconPath, PathUtil.Ins.uiDependenciesPath);
            UI.moneyIcon.SetNativeSize();
            /*
            Texture2D t = SourceManager.Ins.GetSingleCommonTexture(moneyIconPath);
            if (t != null)
            {
                UI.moneyItemUI.moneyIcon.texture = t;
                UI.moneyItemUI.moneyIcon.gameObject.SetActive(true);
                UI.moneyItemUI.moneyIcon.SetNativeSize();
            }
            */
        }
        else
        {
            if (UI.moneyIcon!=null) UI.moneyIcon.gameObject.SetActive(false);
        }
    }

    public void setData(int defaultvalue, int minvalue, int maxvalue, int pervalue, int currencyType = 0)
    {
        defaultValue = defaultvalue;
        currentValue = defaultvalue;
        minValue = minvalue;
        maxValue = maxvalue;
        perValue = pervalue;
        UI.inputText.text = defaultvalue.ToString();
        if (inputField!=null)
        {
            inputField.text = defaultValue.ToString() + suffixStr;
        }
        offset = 0;
        if (UI.moneyIcon!=null) UI.moneyIcon.gameObject.SetActive(false);
        if (currencyType != 0)
        {
            string moneyIconPath = CurrencyTypeDef.GetCurrencyIcon(currencyType);
            if (!string.IsNullOrEmpty(moneyIconPath) && UI.moneyIcon != null)
            {
                PathUtil.Ins.SetSprite(UI.moneyIcon, moneyIconPath, PathUtil.Ins.uiDependenciesPath);
                UI.moneyIcon.SetNativeSize();
                /*
                Texture2D t = SourceManager.Ins.GetSingleCommonTexture(moneyIconPath);
                if (t != null)
                {
                    UI.moneyItemUI.moneyIcon.texture = t;
                    UI.moneyItemUI.moneyIcon.gameObject.SetActive(true);
                    UI.moneyItemUI.moneyIcon.SetNativeSize();
                }
                */
            }
            else
            {
                if (UI.moneyIcon != null) UI.moneyIcon.gameObject.SetActive(false);
            }
        }
    }

    public TabChangeHandler TabChangeHandler
    {
        set { _tabChangeHandler = value; }
    }

    public int CurrentValue
    {
        get { return currentValue; }
    }

    #region 按钮 加减 逻辑

    private void clickJiaBtn(RMetaEvent e)
    {
        dojia();
    }

    private void clickJiaBtn()
    {
        dojia();
    }

    private void dojia()
    {
        if (CurrentValue + perValue > maxValue)
        {
            currentValue = maxValue;
        }
        else
        {
            offset += 1;
            currentValue = CurrentValue + perValue;
        }
        UI.inputText.text = CurrentValue.ToString();
        if (canInput && inputField != null)
        {
            inputField.text = CurrentValue.ToString() + suffixStr;
        }
        if (_tabChangeHandler != null)
        {
            _tabChangeHandler(offset);
        }
    }

    private void clickJianBtn(RMetaEvent e)
    {
        dojian();
    }

    private void clickJianBtn()
    {
        dojian();
    }

    private void dojian()
    {
        if (CurrentValue + (-1) * perValue < minValue)
        {
            currentValue = minValue;
        }
        else
        {
            offset -= 1;
            currentValue = CurrentValue - perValue;
        }
        UI.inputText.text = CurrentValue.ToString();
        if (canInput && inputField != null)
        {
            inputField.text = CurrentValue.ToString() + suffixStr;
        }
        if (_tabChangeHandler != null)
        {
            _tabChangeHandler(offset);
        }
    }

    #endregion

    public void setOnlyShow()
    {
        UI.jiaBtn.gameObject.SetActive(false);
        UI.jianBtn.gameObject.SetActive(false);
        canInput = false;
        if (inputField != null) inputField.gameObject.SetActive(false);
        UI.inputText.gameObject.SetActive(true);
    }

    public void setCanInputNum(int maxlen=8)
    {
        if (UI.inputBg != null)
        {
            canInput = true;
            if (inputField == null)
            {
                inputField = CreateInputField(UI.inputText.color, UI.inputText.fontSize, UI.inputBg, false);
                inputField.onEndEdit.AddListener(doSubmit);
                //inputField.onValueChange.AddListener(OnValueChanged);
                inputField.characterLimit = maxlen;
                inputField.contentType = InputField.ContentType.IntegerNumber;
            }
            inputField.contentType = InputField.ContentType.IntegerNumber;
            inputField.text = currentValue.ToString() + suffixStr;
            inputField.gameObject.SetActive(true);
            UI.inputText.gameObject.SetActive(false);
        }
    }

    private void OnValueChanged(string str)
    {
        int num;
        string beforeContent = inputField.text;
        if (!int.TryParse(str, out num))
        {
            inputField.text = GetIntString(beforeContent) + suffixStr;
        }
    }

    private string GetIntString(string str)
    {
        List<char> chars = new List<char>();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] >= '0' && str[i] <= '9')
            {
                chars.Add(str[i]);
            }
        }
        return chars.ToString();
    }

    private void doSubmit(string str)
    {
        int intvalue = 0;
        if (string.IsNullOrEmpty(str))
        {
            return;
        }
        if (!string.IsNullOrEmpty(suffixStr)&&str.EndsWith(suffixStr))
        {
            str = str.Substring(0, str.LastIndexOf(suffixStr));
        }
        bool isnum = int.TryParse(str, out intvalue);
        if (!isnum)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("输入不合法，请输入数字！");
            if (inputField != null)
            {
                inputField.text = defaultValue.ToString() + suffixStr;
            }
            currentValue = defaultValue;
            if (_tabChangeHandler != null)
            {
                _tabChangeHandler(offset);
            }
            return;
        }
        if (intvalue < minValue)
        {
            intvalue = minValue;
        }
        if (intvalue > maxValue)
        {
            intvalue = maxValue;
        }
        currentValue = intvalue;
        inputField.text = currentValue.ToString() + suffixStr;
        //if (inputField != null)
        //{
        //    inputField.text = defaultValue.ToString();
        //}
        if (_tabChangeHandler != null)
        {
            _tabChangeHandler(offset);
        }
    }

    public void setCanChange()
    {
        UI.jiaBtn.gameObject.SetActive(true);
        UI.jianBtn.gameObject.SetActive(true);
    }
    
    public override void Destroy()
    {
        InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, UI.jiaBtn.gameObject, clickJiaBtn);
        InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, UI.jianBtn.gameObject, clickJianBtn);
    }
}
