using app.db;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using app.utils;
using app.tips;

namespace app.item
{
    public class CommonItemScript
    {
        public CommonItemUI UI;
        public CommonItemUINoClick UINoClick;
        public ItemDetailData itemData;
        private ItemTemplate templateData;
        protected UnityAction<ItemDetailData> clickItemHandler;
        protected UnityAction<ItemTemplate> clickItemHandler1;
        public DragMe dragme;
        public DropMe dropme;
        private Vector2 lastNativeSize=Vector2.zero;
        private RectTransform iconRtf;
        private string mIconPathStr;
        //private string mBiankuangPathStr;

        /// <summary>
        /// 是否显示获取途径
        /// </summary>
        private bool isShowhqtj = false;
        /// <summary>
        /// 点击CommonItem 要做什么,默认为显示tips
        /// </summary>
        private CommonItemClickFor clickForWhat = CommonItemClickFor.ShowTips;
        /// <summary>
        /// 按钮按下的时候的放大倍数
        /// </summary>
        //private float pressedScale = 0.8f;

        // Use this for initialization
        public CommonItemScript(CommonItemUI ui, UnityAction<ItemDetailData> clickHandler)
        {
            UI = ui;
            clickItemHandler1 = null;
            clickItemHandler = clickHandler;
            UI.ClickCommonItemHandler = onClick;
        }

        public CommonItemScript(CommonItemUI ui, UnityAction<ItemTemplate> clickHandler)
        {
            UI = ui;
            clickItemHandler = null;
            clickItemHandler1 = clickHandler;
            UI.ClickCommonItemHandler = onClick;
        }

        public CommonItemScript(CommonItemUI ui)
        {
            UI = ui;
            clickItemHandler = null;
            clickItemHandler1 = null;
            UI.ClickCommonItemHandler = onClick;
        }

        public CommonItemScript(CommonItemUINoClick ui)
        {
            clickItemHandler = null;
            clickItemHandler1 = null;
            UINoClick = ui;
        }

        /// <summary>
        /// 点击CommonItem 要做什么,默认为显示tips
        /// </summary>
        public CommonItemClickFor ClickForWhat
        {
            get { return clickForWhat; }
        }

        public void setClickFor(CommonItemClickFor clickfor, ToggleGroup toggleGroup = null)
        {
            clickForWhat = clickfor;
            if (clickForWhat == CommonItemClickFor.Selected && toggleGroup != null)
            {
                UI.SelectedToggle.group = toggleGroup;
            }
        }
        /// <summary>
        /// 设置是否显示获取途径
        /// </summary>
        /// <param name="b"></param>
        public void setShowhqtj(bool b)
        {
            isShowhqtj = b;
        }

        //private void onPressDown(GameObject go)
        //{
        //    //按下     
        //    iTween.ScaleTo(UI.gameObject, pressedScale * Vector3.one, 0.1f);
        //}

        //private void onPressUp(GameObject go)
        //{
        //    //弹起            
        //    iTween.ScaleTo(UI.gameObject, Vector3.one, 0.1f);
        //}

        private void onClick()
        {
            //调用点击的处理
            if (clickItemHandler != null)
            {
                clickItemHandler(itemData);
            }

            if (clickItemHandler1 != null)
            {
                clickItemHandler1(templateData);
            }
            switch (clickForWhat)
            {
                case CommonItemClickFor.ShowTips:
                    if (itemData != null)
                    {
                        if (itemData.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP)
                        {
                            EquipTips.Ins.ShowTips(itemData);
                        }
                        else
                        {
                            ItemTips.Ins.ShowTips(itemData, isShowhqtj);
                        }
                    }
                    else
                    {
                        if (templateData != null)
                        {
                            ItemTips.Ins.ShowTips(templateData, isShowhqtj);
                        }
                    }
                    break;
                case CommonItemClickFor.Selected:
                    //UI.SelectedImage.gameObject.SetActive(true);
                    break;
                case CommonItemClickFor.OnlyCallBack:
                    break;
                case CommonItemClickFor.ShowTipsOnlyView:
                    if (itemData != null)
                    {
                        if (itemData.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP)
                        {
                            EquipTips.Ins.ShowTips(itemData, true, TipsBtnType.ONLYVIEW);
                        }
                        else
                        {
                            ItemTips.Ins.ShowTips(itemData, isShowhqtj,TipsBtnType.ONLYVIEW);
                        }
                    }
                    else
                    {
                        if (templateData != null)
                        {
                            ItemTips.Ins.ShowTips(templateData, isShowhqtj,TipsBtnType.ONLYVIEW);
                        }
                    }
                    break;
                case CommonItemClickFor.ShowTipsForExhibition:
                    if (itemData != null)
                    {
                        if (itemData.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP)
                        {
                            EquipTips.Ins.ShowTips(itemData,true, TipsBtnType.EXHIBITION);
                        }
                        else
                        {
                            ItemTips.Ins.ShowTips(itemData, isShowhqtj,TipsBtnType.EXHIBITION);
                        }
                    }
                    else
                    {
                        if (templateData != null)
                        {
                            ItemTips.Ins.ShowTips(templateData, isShowhqtj,TipsBtnType.EXHIBITION);
                        }
                    }
                    break;
                    
            }
            ClientLog.Log("!!点击了~");
        }

        public void setNumText(string str)
        {
            if (UI != null)
            {
                UI.num.text = str;
            }
            else
            {
                UINoClick.num.text = str;
            }
        }

        public void setNumText(int currentHava, int needNum)
        {
            string color;
            if (currentHava >= needNum)
            {
                color = ColorUtil.GREEN;
            }
            else
            {
                color = ColorUtil.RED;
            }
            if (UI != null)
            {
                if (UI.num != null)
                {
                    UI.num.text = ColorUtil.getColorText(color, currentHava + "/" + needNum);
                }
            }
            else
            {
                if (UINoClick.num != null)
                {
                    UINoClick.num.text = ColorUtil.getColorText(color, currentHava + "/" + needNum);
                }
            }
        }

        public void setCurrencyItem(int currencyType)
        {
            Sprite icontexture = null;
            string moneyIconPath = CurrencyTypeDef.GetCurrencyIcon(currencyType);
            if (!string.IsNullOrEmpty(moneyIconPath))
            {
                icontexture = SourceManager.Ins.GetAsset<Sprite>(PathUtil.Ins.uiDependenciesPath, moneyIconPath);
            }
            if (UI != null)
            {
                if (UI.Name != null)
                {
                    UI.Name.text = CurrencyTypeDef.GetCurrencyName(currencyType);
                }
                if (UI.icon != null)
                {
                    UI.icon.sprite = icontexture;
                    UI.icon.gameObject.SetActive(true);
                    if (lastNativeSize == Vector2.zero)
                    {
                        iconRtf = UI.icon.gameObject.GetComponent<RectTransform>();
                        if (iconRtf != null) lastNativeSize = iconRtf.sizeDelta;
                    }
                    UI.icon.SetNativeSize();
                }
                if (UI.biangkuang != null)
                {
                    UI.biangkuang.gameObject.SetActive(false);
                }
            }
            else
            {
                if (UINoClick.Name != null)
                {
                    UINoClick.Name.text = CurrencyTypeDef.GetCurrencyName(currencyType);
                }
                if (UINoClick.icon != null)
                {
                    UINoClick.icon.gameObject.SetActive(true);
                    UINoClick.icon.sprite = icontexture;
                    if (lastNativeSize == Vector2.zero)
                    {
                        iconRtf = UINoClick.icon.gameObject.GetComponent<RectTransform>();
                        if (iconRtf != null) lastNativeSize = iconRtf.sizeDelta;
                    }
                    UINoClick.icon.SetNativeSize();
                }
                if (UINoClick.biangkuang != null)
                {
                    UINoClick.biangkuang.gameObject.SetActive(false);
                }
            }
        }

        public void setTemplate(ItemTemplate itemTemplate)
        {
            itemData = null;
            setTemplateData(itemTemplate);
        }

        private void setTemplateData(ItemTemplate itemTemplate, bool setKuangNativeSize = false)
        {
            if (itemTemplate == null)
            {
                return;
            }
            templateData = itemTemplate;
            if (UI != null)
            {
                if (UI.Name != null)
                {
                    UI.Name.text = itemTemplate.name;
                }
                if (UI.icon != null)
                {
                    UI.icon.gameObject.SetActive(false);
                    loadCompleteHandler();
                    //mIconPathStr = PathUtil.Ins.GetUITexturePath(itemTemplate.icon, PathUtil.TEXTUER_ITEM);
                    //SourceLoader.Ins.load(mIconPathStr, loadCompleteHandler, null);
                }
                if (UI.biangkuang != null)
                {
                    if (itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.GEM)
                    {
                        UI.biangkuang.gameObject.SetActive(false);
                    }
                    else
                    {
                        int color = itemData != null ? itemData.GetItemColorInt() : itemTemplate.rarityId;
                        if (color > 0)
                        {
                            Sprite t = SourceManager.Ins.GetBiankuang(color);
                            if (t != null)
                            {

                                UI.biangkuang.sprite = t;
                                UI.biangkuang.gameObject.SetActive(true);
                                if (setKuangNativeSize)
                                {
                                    UI.biangkuang.SetNativeSize();
                                }
                            }
                            else
                            {
                                UI.biangkuang.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            UI.biangkuang.gameObject.SetActive(false);
                        }
                    }
                }
                //是否已装备
                if (itemData != null && UI.yizhuangbei != null) { UI.yizhuangbei.gameObject.SetActive(itemData.commonItemData.wearerId != 0); }
            }
            else
            {
                if (UINoClick != null)
                {
                    if (UINoClick.Name != null)
                    {
                        UINoClick.Name.text = itemTemplate.name;
                    }
                    if (UINoClick.icon != null)
                    {
                        UINoClick.icon.gameObject.SetActive(false);
                        //mIconPathStr = PathUtil.Ins.GetUITexturePath(itemTemplate.icon, PathUtil.TEXTUER_ITEM);
                        //SourceLoader.Ins.load(mIconPathStr, loadCompleteHandler, null);
                        loadCompleteHandler();
                    }
                    if (UINoClick.biangkuang != null)
                    {
                        if (itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.GEM)
                        {
                            UINoClick.biangkuang.gameObject.SetActive(false);
                        }
                        else
                        {
                            int color = itemData != null ? itemData.GetItemColorInt() : itemTemplate.rarityId;
                            if (color > 0)
                            {
                                //mBiankuangPathStr = PathUtil.Ins.GetUITexturePath(color.ToString(), PathUtil.ITEM_BIANKUANG);
                                //UINoClick.biangkuang.texture = SourceManager.Ins.GetAsset<Texture>(mBiankuangPathStr);
                                Sprite t = SourceManager.Ins.GetBiankuang(color);
                                if (t != null)
                                {
                                    UINoClick.biangkuang.sprite = t;
                                    UINoClick.biangkuang.gameObject.SetActive(true);
                                    if (setKuangNativeSize)
                                    {
                                        UINoClick.biangkuang.SetNativeSize();
                                    }
                                }
                                else
                                {
                                    UINoClick.biangkuang.gameObject.SetActive(false);
                                }
                            }
                            else
                            {
                                UINoClick.biangkuang.gameObject.SetActive(false);
                            }
                        }
                    }
                }
            }
        }

        public void setName(string namestr)
        {
            if (UI)
            {
                if (UI.Name != null)
                {
                    UI.Name.text = namestr;
                }
            }
            else if (UINoClick)
            {
                if (UINoClick.Name)
                {
                    UINoClick.Name.text = namestr;
                }
            }
        }

        public void setTemplate(int templateId, bool setKuangNativeSize = false)
        {
            itemData = null;
            ItemTemplate itemTemplate = ItemTemplateDB.Instance.getTempalte(templateId);
            templateData = itemTemplate;
            setTemplateData(itemTemplate, setKuangNativeSize);
        }
        /// <summary>
        /// 设置 装备位 星数
        /// </summary>
        /// <param name="xing"></param>
        public void setEquipGridXing(int xing)
        {
            if (xing > 0)
            {
                if (UI != null)
                {
                    if (UI.Xing != null)
                    {
                        UI.Xing.SetActive(true);
                        if (UI.XingTxt != null)
                        {
                            UI.XingTxt.text = xing.ToString();
                        }
                    }
                }
            }
            else
            {
                if (UI != null && UI.Xing != null)
                {
                    UI.Xing.SetActive(false);
                }
            }
        }

        public virtual void setData(ItemDetailData data,bool setKuangNativeSize=false)
        {
            if (UI != null)
            {
                UI.gameObject.SetActive(true);
            }
            else
            {
                UINoClick.gameObject.SetActive(true);
            }
            itemData = data;

            if (data == null)
            {
                setEmpty();
            }
            else
            {
                if (UI != null)
                {
                    if (UI.num != null)
                    {
                        if (itemData.commonItemData.count > 1)
                        {
                            UI.num.text = itemData.commonItemData.count.ToString();
                        }
                        else
                        {
                            UI.num.text = "";
                        }
                    }
                    //是否已装备
                    if (UI.yizhuangbei != null) { UI.yizhuangbei.gameObject.SetActive(itemData.commonItemData.wearerId != 0); }
                }
                else
                {
                    if (UINoClick.num != null)
                    {
                        if (itemData.commonItemData.count > 1)
                        {
                            UINoClick.num.text = itemData.commonItemData.count.ToString();
                        }
                        else
                        {
                            UINoClick.num.text = "";
                        }
                    }
                }
                setTemplateData(itemData.itemTemplate, setKuangNativeSize);
            }
        }

        public void setEmpty()
        {
            itemData = null;
            templateData = null;
            if (UI != null)
            {
                if (UI.num != null) UI.num.text = "";
                if (UI.Name != null) UI.Name.text = "";
                if (UI.icon != null)
                {
                    if (mIconPathStr != null)
                    {
                        SourceManager.Ins.removeReference(mIconPathStr);
                    }
                    UI.icon.sprite = null;
                    UI.icon.gameObject.SetActive(false);
                }
                if (UI.biangkuang != null)
                {
                    /*
                    if (mBiankuangPathStr != null)
                    {
                        SourceManager.Ins.removeReference(mBiankuangPathStr);
                    }
                    */
                    UI.biangkuang.sprite = null;
                    UI.biangkuang.gameObject.SetActive(false);
                }
                if (UI.yizhuangbei != null)
                {
                    UI.yizhuangbei.gameObject.SetActive(false);
                }
            }
            else
            {
                if (UINoClick.num != null) UINoClick.num.text = "";
                if (UINoClick.Name != null) UINoClick.Name.text = "";
                if (UINoClick.icon != null)
                {
                    if (mIconPathStr != null)
                    {
                        SourceManager.Ins.removeReference(mIconPathStr);
                    }
                    UINoClick.icon.sprite = null;
                    UINoClick.icon.gameObject.SetActive(false);
                }
                if (UINoClick.biangkuang != null)
                {
                    /*
                    if (mBiankuangPathStr != null)
                    {
                        SourceManager.Ins.removeReference(mBiankuangPathStr);
                    }
                    */
                    UINoClick.biangkuang.sprite = null;
                    UINoClick.biangkuang.gameObject.SetActive(false);
                }
            }

            setEquipGridXing(0);
        }

        public void clearData()
        {
            itemData = null;
            templateData = null;
        }

        public void showSelected()
        {
            UI.SelectedToggle.isOn = true;
        }

        public void AddDragMe()
        {
            dragme = UI.gameObject.AddComponent<DragMe>();
            dragme.dragImageTemplateId = itemData.itemTemplate.icon;
            dragme.OnStartDragHandler = OnStartDragHandler;
        }

        protected virtual void OnStartDragHandler(RMetaEvent rMetaEvent)
        {

        }

        public void AddDropMe()
        {
            dropme = UI.gameObject.AddComponent<DropMe>();
            dropme.containerImage = UI.bg;

            dropme.receiveImage = UI.biangkuang;
            dropme.OnDropHandler = OnDropHandler;
        }

        protected virtual void OnDropHandler(RMetaEvent rMetaEvent)
        {

        }

        private void loadCompleteHandler(RMetaEvent e = null)
        {
            string icon = "";
            if (itemData != null && itemData.itemTemplate != null)
            {
                icon = itemData.itemTemplate.icon;
            }
            else if (templateData != null)
            {
                icon = templateData.icon;
            }

            //Texture2D t = SourceManager.Ins.GetAsset<Texture2D>(
            //    PathUtil.Ins.GetUITexturePath(icon, PathUtil.TEXTUER_ITEM)
            //);

            //Texture2D t = PathUtil.Ins.GetItemIcon(icon);
            if (UI != null)
            {
                if (lastNativeSize != Vector2.zero)
                {
                    iconRtf.sizeDelta = lastNativeSize;
                }
                PathUtil.Ins.SetItemIcon(UI.icon, icon);
                /*
                if (t != null)
                {
                    UI.icon.texture = t;
                    UI.icon.gameObject.SetActive(true);
                }
                else
                {
                    UI.icon.gameObject.SetActive(false);
                }
                */
            }
            else
            {
                if (lastNativeSize != Vector2.zero)
                {
                    iconRtf.sizeDelta = lastNativeSize;
                }
                PathUtil.Ins.SetItemIcon(UINoClick.icon, icon);
                /*
                if (t != null)
                {
                    UINoClick.icon.texture = t;
                    UINoClick.icon.gameObject.SetActive(true);
                }
                else
                {
                    UINoClick.icon.gameObject.SetActive(false);
                }
                */
            }
        }

        public virtual void Destroy()
        {
            if (itemData != null)
            {
                //SourceManager.Ins.removeReference(PathUtil.Ins.GetUITexturePath(itemData.itemTemplate.icon, PathUtil.TEXTUER_ITEM));
            }
            GameObject.DestroyImmediate(dragme, true);
            GameObject.DestroyImmediate(dropme, true);
            dragme = null;
            dropme = null;
            itemData = null;
            if (UI != null && UI.gameObject != null)
            {
                UI.gameObject.SetActive(false);
            }
        }

    }
    /// <summary>
    /// 点击CommonItem 要做什么
    /// </summary>
    public enum CommonItemClickFor
    {
        //显示tips
        ShowTips,
        //选中
        Selected,
        //只回调
        OnlyCallBack,
        //看tips
        ShowTipsOnlyView,
        //显示tips，只有展示按钮
        ShowTipsForExhibition
    }
}