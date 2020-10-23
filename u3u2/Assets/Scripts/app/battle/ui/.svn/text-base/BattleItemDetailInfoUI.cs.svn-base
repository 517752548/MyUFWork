using app.db;
using app.item;

namespace app.battle
{
    public class BattleItemDetailInfoUI
    {
        public BattleItemDetailInfoUIBehav UI { get; private set; }

        public bool isShown { get; private set; }

        private CommonItemScript mItemScript = null;

        public BattleItemDetailInfoUI(BattleItemDetailInfoUIBehav mUIBehav)
        {
            UI = mUIBehav;
            InitUI();
        }

        private void InitUI()
        {
            mItemScript = new CommonItemScript(UI.commonItem);
            isShown = false;
        }

        public void Show(ItemTemplate itemTpl)
        {
            UI.gameObject.SetActive(true);
            isShown = true;
            mItemScript.setTemplate(itemTpl);
            UI.type.text = ItemDefine.ItemTypeDefine.GetItemTypeName(itemTpl.itemTypeId);
            UI.level.text = itemTpl.level.ToString();
            UI.desc.text = itemTpl.desc;
        }

        public void Hide()
        {
            UI.gameObject.SetActive(false);
            isShown = false;
        }
    }
}