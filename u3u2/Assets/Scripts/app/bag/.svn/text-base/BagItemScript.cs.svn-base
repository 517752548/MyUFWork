using UnityEngine;
using UnityEngine.Events;
using app.item;

namespace app.bag
{
    public class BagItemScript : CommonItemScript
    {
        private int bagId;
        private int itemIndex;
        
        public BagItemScript(CommonItemUI ui, UnityAction<ItemDetailData> clickHandler = null) : 
            base(ui, clickHandler)
        {
        }

        public int BagId
        {
            get { return bagId; }
            set { bagId = value; }
        }

        public int ItemIndex
        {
            get { return itemIndex; }
            set { itemIndex = value; }
        }

        protected override void OnStartDragHandler(RMetaEvent rMetaEvent)
        {
            DragManager.Ins.DragData = itemData;
        }

        protected override void OnDropHandler(RMetaEvent rMetaEvent)
        {
            DragManager.Ins.DropData = itemData;
            ItemDetailData cid = DragManager.Ins.DragData as ItemDetailData;

            //ItemCGHandler.sendCGMoveItem(cid.commonItemData.bagId, cid.commonItemData.index,
            //    itemData.commonItemData.bagId, itemData.commonItemData.index, new long());

            if (itemData != null)
            {
                ClientLog.Log("更换位置：！" + cid.commonItemData.bagId + "," + cid.commonItemData.index + ",    " +
                    itemData.commonItemData.bagId + "," + itemData.commonItemData.index);
            }
            else
            {
                ClientLog.Log("更换位置：！" + cid.commonItemData.bagId + "," + cid.commonItemData.index + ",    " +
                    BagId + "," + ItemIndex);
            }
        }
        
        public override void Destroy()
        {
            bagId = 0;
            itemIndex = 0;
            base.Destroy();
            //GameObject.DestroyImmediate(UI, true);
            //UI = null;
        }
    }
}

