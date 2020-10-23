using app.item;
using UnityEngine;

namespace app.qianghua
{
    public class EquipFenJieItemScript
    {
        public EquipFenJieItemUI UI;
        public ItemDetailData itemDetailData;
        public CommonItemScript itemscript;
        public RMetaEventHandler clickDeleteCallBack;
        public RMetaEventHandler clickSelectedToggleCallBack;

        private int itemIndex;
        public int ItemIndex
        {
            get { return itemIndex; }
            set { itemIndex = value; }
        }

        public EquipFenJieItemScript(EquipFenJieItemUI ui)
        {
            UI = (EquipFenJieItemUI)ui;
            itemscript = new CommonItemScript(UI.item);
            itemscript.setClickFor(CommonItemClickFor.OnlyCallBack);
            if (UI.deleteBtn != null)
            {
                UI.deleteBtn.SetClickCallBack(clickDeleteBtn);
            }
            if (UI.selectToggle != null)
            {
                UI.selectToggle.SetValueChangedCallBack(clickSelectedToggle);
            }
        }

        private void clickDeleteBtn()
        {
            if (clickDeleteCallBack != null)
            {
                clickDeleteCallBack(new RMetaEvent("clickDeleteBtn", this, UI.gameObject));
            }
        }

        private void clickSelectedToggle(bool selected)
        {
            if (clickSelectedToggleCallBack != null)
            {
                clickSelectedToggleCallBack(new RMetaEvent("clickSelectedToggle", this, UI.gameObject));
            }
        }

        public void setData(ItemDetailData itemdata)
        {
            itemDetailData = itemdata;
            if (itemDetailData.equipItemTemplate != null && UI.item.Name != null)
            {
                UI.item.Name.text = itemDetailData.equipItemTemplate.name;
            }
            if (UI.equipLevel != null) UI.equipLevel.text = "Lv " + itemDetailData.equipItemTemplate.level;
            UI.item.icon.gameObject.SetActive(false);
            UI.item.biangkuang.gameObject.SetActive(false);
            if (UI.deleteBtn != null) UI.deleteBtn.gameObject.SetActive(true);
            itemscript.setData(itemDetailData);
        }

        public void setEmpty()
        {
            itemscript.setEmpty();
            itemDetailData = null;
            if (UI.equipLevel != null) UI.equipLevel.text = "";
            if (UI.deleteBtn != null) UI.deleteBtn.gameObject.SetActive(false);
            UI.item.icon.gameObject.SetActive(false);
            UI.item.biangkuang.gameObject.SetActive(false);
            clickDeleteCallBack = null;
            clickSelectedToggleCallBack = null;
        }

        public void setSelected(bool state)
        {
            UI.selectToggle.interactable = false;
            UI.selectToggle.isOn = state;
            UI.selectToggle.interactable = true;
        }

        public void Destroy()
        {
            GameObject.DestroyImmediate(UI.gameObject);
            UI = null;
            itemscript = null;
            itemDetailData = null;
            clickDeleteCallBack = null;
            clickSelectedToggleCallBack = null;
        }
    }
}