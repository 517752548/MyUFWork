using app.item;

namespace app.qianghua
{

    public class EquipChongZhuItemScript
    {
        public EquipChongZhuItemUI UI;
        public ItemDetailData itemDetailData;
        public CommonItemScript itemscript;

        public EquipChongZhuItemScript(EquipChongZhuItemUI ui)
        {
            UI = ui;
            itemscript = new CommonItemScript(UI.item);
        }

        public void setData(ItemDetailData itemdata)
        {
            itemDetailData = itemdata;
            UI.equipName.text = itemDetailData.equipItemTemplate.name;
            UI.equipLevel.text = "Lv " + itemDetailData.equipItemTemplate.level;
            UI.equipType.text = ItemDefine.ItemTypeDefine.GetItemTypeName(itemDetailData.itemTemplate.itemTypeId);
            UI.item.icon.gameObject.SetActive(false);
            UI.item.biangkuang.gameObject.SetActive(false);
            itemscript.setData(itemDetailData);
        }

        public void setEmpty()
        {
            itemscript.setEmpty();
            itemDetailData = null;
            UI.gameObject.SetActive(false);
        }
    }
}