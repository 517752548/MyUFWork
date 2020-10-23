using UnityEngine;
using app.net;

namespace app.partnerformation
{
	public class FormationListItemUIScript
	{
		private FormationListItemUI mUI = null;
		
		private PetFriendArrayInfo mData = null;
		
		private FormationPartnerItemUIScript[] partnerItems = null;
		
		public FormationListItemUIScript(FormationListItemUI ui)
		{
			mUI = ui;
			partnerItems = new FormationPartnerItemUIScript[4];
			for (int i = 0; i < 4; i++)
			{
				partnerItems[i] = new FormationPartnerItemUIScript(ui.partnerItemUIs[i]);
			}
		}
		
		public void SetData(PetFriendArrayInfo data, int index)
		{
			mData = data;
			for (int i = 0; i < 4; i++)
			{
				partnerItems[i].SetData(index, i, data.tplIdList[i]);
			}
		}
		
		public void ResetPartnerItemStatus()
		{
			for (int i = 0; i < 4; i++)
			{
				partnerItems[i].ResetStatus();
			}
		}
		
		public void ShowPartnerItemSwitchBtn(int partnerIdx)
		{
			partnerItems[partnerIdx].ui.zhuanBtn.gameObject.SetActive(true);
		}
		
		public void Destroy()
		{
			for (int i = 0; i < 4; i++)
			{
				partnerItems[i].Destroy();
			}
			GameObject.DestroyImmediate(mUI.gameObject, true);
			mUI = null;
		}
	}
}