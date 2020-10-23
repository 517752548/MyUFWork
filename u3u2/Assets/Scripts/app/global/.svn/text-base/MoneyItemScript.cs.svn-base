using app.bag;
using app.db;
using app.pet;
using UnityEngine;
using app.human;
using app.utils;

public class MoneyItemScript
{
    private MoneyItemUI UI;

    private bool isEnough;

    private int _currencyType;
    private long _currencyValue;
    private int itemTplId;
    private bool CheckEnough;
    private bool ShowHaveIfCheckEnough;

    public PetModel petModel;

    public BagModel bagModel;
    //输入完的后缀，比如“两”、"文" 等
    private string suffixStr = "";

    public MoneyItemScript(MoneyItemUI ui,string suffixstr="")
    {
        UI = ui;
        suffixStr = suffixstr;
        petModel = PetModel.Ins;
        bagModel = BagModel.Ins;
        if(UI.moneyIcon!=null)UI.moneyIcon.gameObject.SetActive(false);
        AddListener();
    }

    public void AddListener()
    {
        petModel.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateMoney);
    }

    public void RemoveListener()
    {
        petModel.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateMoney);
    }

    public bool IsEnough
    {
        get { return isEnough; }
    }

    public int CurrencyType
    {
        get { return _currencyType; }
    }

    public long CurrencyValue
    {
        get { return _currencyValue; }
    }

    public void updateMoney(RMetaEvent e)
    {
        if (CurrencyType == CurrencyTypeDef.ITEM)
        {
            setItemData(itemTplId, (int)CurrencyValue, CheckEnough);
        }
        else if (CurrencyValue != 0)
        {
            SetMoney(CurrencyType, CurrencyValue, CheckEnough, ShowHaveIfCheckEnough);
        }
    }

    /// <summary>
    /// 设置moneyItemUI的数据
    /// </summary>
    /// <param name="currencyType"></param>
    /// <param name="currencyValue"></param>
    /// <returns></returns>
    public void SetMoney(int currencyType, long currencyValue, bool checkEnough = true, bool showHaveIfCheckEnough = true,int forceEnough=0)
    {
        if (CurrencyType != currencyType)
        {
            _currencyType = currencyType;
            if (UI.moneyIcon != null)
            {
                string moneyIconName = CurrencyTypeDef.GetCurrencyIcon(currencyType);
                if (!string.IsNullOrEmpty(moneyIconName))
                {
                    /*
                    Texture2D t = SourceManager.Ins.GetSingleCommonTexture(moneyIconPath);
                    if (t != null)
                    {
                        UI.moneyIcon.texture = t;
                        UI.moneyIcon.gameObject.SetActive(true);
                        UI.moneyIcon.SetNativeSize();
                    }
                    else
                    {
                        UI.moneyIcon.gameObject.SetActive(false);
                    }
                    */
                    PathUtil.Ins.SetSprite(UI.moneyIcon, moneyIconName, PathUtil.Ins.uiDependenciesPath, true);
                }
                else
                {
                    UI.moneyIcon.gameObject.SetActive(false);
                }
            }
            //AddListener();
        }

        long havemoney = Human.Instance.GetCurrencyValue(currencyType);

        if (checkEnough)
        {
            string colorstr;
            bool moneyEnough;
            if (havemoney >= currencyValue)
            {
                colorstr = ColorUtil.GREEN;
                moneyEnough = true;
            }
            else
            {
                colorstr = ColorUtil.RED;
                moneyEnough = false;
            }
            if (forceEnough==1)
            {
                colorstr = ColorUtil.GREEN;
                moneyEnough = true;
            }
            else if(forceEnough==2)
            {
                colorstr = ColorUtil.RED;
                moneyEnough = false;
            }
            isEnough = moneyEnough;

            if (showHaveIfCheckEnough)
            {
                UI.moneyText.text = ColorUtil.getColorText(colorstr, Human.Instance.GetCurrencyValue(currencyType).ToString());
                UI.moneyText.text += (" / " + currencyValue) + suffixStr;
            }
            else
            {
                UI.moneyText.text = ColorUtil.getColorText(colorstr, currencyValue.ToString()) + suffixStr;
            }
        }
        else
        {
            UI.moneyText.text = currencyValue.ToString() + suffixStr;
            isEnough = false;
        }
        _currencyValue = currencyValue;
        CheckEnough = checkEnough;
        ShowHaveIfCheckEnough = showHaveIfCheckEnough;
    }
    /// <summary>
    /// 设置需要物品的数量
    /// </summary>
    /// <param name="itemTplId"></param>
    /// <param name="needItemNum"></param>
    /// <param name="checkEnough"></param>
    public void setItemData(int itemTplIdv, int needItemNum, bool checkEnough = true)
    {
        if (itemTplIdv == 0)
        {
            ClientLog.LogError("MoneyItemScript setItemData 错误的物品模板id！" + itemTplIdv);
            return;
        }
        UI.moneyIcon.rectTransform.sizeDelta = Vector2.one * 48;
        _currencyType = CurrencyTypeDef.ITEM;
        itemTplId = itemTplIdv;
        _currencyValue = needItemNum;
        CheckEnough = checkEnough;
        ShowHaveIfCheckEnough = false;
        if (UI.moneyIcon != null)
        {
            ItemTemplate it = ItemTemplateDB.Instance.getTempalte(itemTplId);
            if (it != null)
            {
                //PathUtil.Ins.SetRawImageSource(UI.moneyIcon,itemTplId.ToString(),PathUtil.TEXTUER_ITEM);
                PathUtil.Ins.SetItemIcon(UI.moneyIcon, it.icon);
            }
        }
        int haveitemnum = bagModel.getHasNum(itemTplId);
        bool moneyEnough = haveitemnum >= needItemNum;
        UI.moneyText.text = ColorUtil.getColorText(moneyEnough, CurrencyValue.ToString()) + suffixStr;
        isEnough = moneyEnough;

        //AddListener();
    }

    /// <summary>
    /// 只显示图标和数量,只做先使用
    /// </summary>
    /// <param name="itemTplId"></param>
    /// <param name="needItemNum"></param>
    /// <param name="checkEnough"></param>
    private void setData(int type, int itemTplIdv, int Num)
    {
        if (UI.moneyIcon != null && type != CurrencyType)
        {
            _currencyType = type;
            if (type == CurrencyTypeDef.ITEM)
            {
                if (itemTplIdv == 0)
                {
                    ClientLog.LogError("MoneyItemScript setItemData 错误的物品模板id！" + itemTplIdv);
                    return;
                }
                UI.moneyIcon.rectTransform.sizeDelta = Vector2.one * 48;
                itemTplId = itemTplIdv;
                if (UI.moneyIcon != null)
                {
                    ItemTemplate it = ItemTemplateDB.Instance.getTempalte(itemTplId);
                    if (it != null)
                    {
                        //PathUtil.Ins.SetRawImageSource(UI.moneyIcon, itemTplId.ToString(), PathUtil.TEXTUER_ITEM);
                        PathUtil.Ins.SetItemIcon(UI.moneyIcon, itemTplId.ToString());
                    }
                }
            }
            else
            {
                string moneyIconName = CurrencyTypeDef.GetCurrencyIcon(type);
                PathUtil.Ins.SetSprite(UI.moneyIcon, moneyIconName, PathUtil.Ins.uiDependenciesPath, true);
            }
        }
        
        _currencyValue = Num;
        UI.moneyText.text = Num.ToString() + suffixStr;
    }

    public void setEmpty()
    {
        //string colorstr = ColorUtil.WHITE;
        //UI.moneyText.text = "";
        //CurrencyValue = 0;
        //SetMoney(CurrencyTypeDef.GOLD, 0, false, false);
        setData(CurrencyType==0?CurrencyTypeDef.GOLD:CurrencyType, 0, 0);
        //RemoveListener();
    }

    public string GetCurrencyName()
    {
        return CurrencyTypeDef.GetCurrencyName(CurrencyType);
    }

    public void Destroy()
    {
        //setEmpty();
        RemoveListener();
        if (UI!=null&&UI.moneyIcon!=null) UI.moneyIcon.sprite = null;
        if(UI!=null)GameObject.DestroyImmediate(UI.gameObject, true);
        UI = null;
    }
}