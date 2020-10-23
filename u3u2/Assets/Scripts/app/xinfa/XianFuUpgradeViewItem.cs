using UnityEngine.Events;
using app.item;

namespace app.xinfa
{
    public class XianFuUpgradeViewItem : CommonItemScript
    {
        private UnityAction<XianFuUpgradeViewItem> mClickHander = null;

        public XianFuUpgradeViewItem(CommonItemUI ui, UnityAction<XianFuUpgradeViewItem> clickHandler) : base(ui)
        {
            base.clickItemHandler = OnItemClicked;
            mClickHander = clickHandler;
        }

        private void OnItemClicked(ItemDetailData data)
        {
            if (mClickHander != null)
            {
                mClickHander(this);
            }
        }
    }
}