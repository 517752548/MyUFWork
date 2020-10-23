using UnityEngine;
using app.db;
using app.item;

namespace app.petstore
{
	public class PetStorePetListItem
	{
		private PetStorePetListItemUI mUI = null;
		private MallNormalItemTemplateVO mData = null; 
		
		private CommonItemScript mItemIcon = null;
		
		private MoneyItemScript mCost = null;
				
		public PetStorePetListItem(PetStorePetListItemUI ui)
		{
			mUI = ui;
			mItemIcon = new CommonItemScript(ui.headIcon);
			mCost = new MoneyItemScript(ui.cost);
		}
		
		public MallNormalItemTemplateVO GetData()
		{
			return mData;
		}
		
		public void SetData(MallNormalItemTemplateVO data)
		{
			mData = data;
			ItemTemplate petItemTpl = ItemTemplateDB.Instance.getTempalte(data.normalItemList[0].itemTempId);
			mUI.petName.text = petItemTpl.name;
			mItemIcon.setTemplate(petItemTpl);
            mCost.SetMoney(data.priceList[1].currencyType, data.priceList[1].num, false, false);
		}

        public void SetActive(bool value)
        {
            mUI.gameObject.SetActive(value);
        }
		
		public void Destroy()
		{
		    mData = null; 
		    if(mItemIcon!=null)mItemIcon.Destroy();
		    mItemIcon = null;
            if (mCost!=null)mCost.Destroy();
		    mCost = null;
            if (mUI!=null) GameObject.DestroyImmediate(mUI.gameObject, true);
			mUI = null;

		}
	}
}