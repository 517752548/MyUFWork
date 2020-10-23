using UnityEngine;
using app.net;
using app.pet;
using app.human;

namespace app.partnerformation
{
	public class FormationListUIScript
	{
        public PetModel petModel;
		
		private PartnerFormationFUI mUI = null;
		
		private FormationListItemUIScript[] mFormationList = null;
		
		private bool mIsShown = false;
		
		public FormationListUIScript(PartnerFormationFUI ui)
		{
			mUI = ui;
			petModel = PetModel.Ins;
			petModel.addChangeEvent(PetModel.UPDATE_PET_FRIEND_ARRAY, OnPetFriendArrayInfoUpdated);
			ui.formationListItemUIGroup.TabChangeHandler = OnCurFormationChanged;
			mFormationList = new FormationListItemUIScript[3];
			for (int i = 0; i < 3; i++)
			{
				FormationListItemUIScript item = new FormationListItemUIScript(ui.formationListItemUIs[i]);
				mFormationList[i] = item;
			}
		}
		
		public void Show()
		{
			mIsShown = true;
		}
		
		public void Hide()
		{
			mIsShown = false;
		}
		
		private void OnCurFormationChanged(int idx)
		{
			for (int i = 0; i < 3; i++)
			{
				mUI.formationListItemUIs[i].backgorund.SetActive(idx != i);
				mUI.formationListItemUIs[i].checkmark.SetActive(idx == i);
			}
			
			if (idx != Human.Instance.PetModel.curPetFriendArrayIdx)
			{
				PetCGHandler.sendCGPetFriendChangeArray(idx);
			}
		}
		
		private void OnPetFriendArrayInfoUpdated(RMetaEvent e)
		{
			for (int i = 0; i < 3; i++)
			{
				mFormationList[i].SetData(Human.Instance.PetModel.petFriendArrayInfoList[i], i);
			}
			
			if (mUI.formationListItemUIGroup.index == Human.Instance.PetModel.curPetFriendArrayIdx)
			{
				OnCurFormationChanged(mUI.formationListItemUIGroup.index);
			}
			else
			{
				mUI.formationListItemUIGroup.SetIndexWithCallBack(Human.Instance.PetModel.curPetFriendArrayIdx);
			}
		}
		
		public void ResetPartnerItemsStatus(int formationIdx)
		{
			mFormationList[formationIdx].ResetPartnerItemStatus();
		}
		
		public void ShowPartnerItemSwitchBtn(int formationIdx, int partnerIdx)
		{
			mFormationList[formationIdx].ShowPartnerItemSwitchBtn(partnerIdx);
		}
		
		public void Destroy()
		{
			petModel.removeChangeEvent(PetModel.UPDATE_PET_FRIEND_ARRAY, OnPetFriendArrayInfoUpdated);
			int len = mFormationList.Length;
			for (int i = 0; i < len; i++)
			{
				if (mFormationList[i] != null)
				{
					mFormationList[i].Destroy();
					mFormationList[i] = null;
				}
			}
			
			GameObject.DestroyImmediate(mUI.gameObject, true);
			mUI = null;
		}
	}
}