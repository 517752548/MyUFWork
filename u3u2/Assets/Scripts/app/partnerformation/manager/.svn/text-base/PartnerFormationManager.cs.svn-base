using System;
using app.net;
using app.utils;
using app.human;

namespace app.partnerformation
{
    public class PartnerFormationManager
    {
        private static PartnerFormationManager mIns = new PartnerFormationManager();

        public static PartnerFormationManager ins
        {
            get
            {
                return mIns;
            }
        }

        public PartnerFormationManager()
        {
            if (PartnerFormationManager.ins != null)
            {
                throw new Exception("PartnerFormationManager instance already exists!");
            }
        }
        
        public void OnPetFriendUnlockListReceived(PetFriendUnlockInfo[] list)
        {
            if (PartnerFormationModel.ins.partnerUIScript != null)
            {
                PartnerFormationModel.ins.partnerUIScript.OnPetFriendUnlockInfoReceived(list);
            }
        }
        
        public void OnFormationPartnerItemUIJiaBtnClicked(FormationPartnerItemUIScript item)
        {
            if (PartnerFormationModel.ins.curOperFormationPartnerItem != null)
            {
                PartnerFormationModel.ins.curOperFormationPartnerItem.ResetStatus();
            }
            
            if (PartnerFormationModel.ins.curOperFormationPartnerItem != item)
            {
                PartnerFormationModel.ins.curOperFormationIndex = item.formationIndex;
                PartnerFormationModel.ins.curOperFormationPartnerPosIndex = item.partnerPosIndex;
                PartnerFormationModel.ins.curOperFormationPartnerTplId = item.tpl == null ? 0 : item.tpl.Id;
                PartnerFormationModel.ins.curOperFormationPartnerItem = item;
                item.ui.selected.SetActive(true);
                PartnerFormationModel.ins.partnerUIScript.ShowUpBtn();
            }
            else
            {
                PartnerFormationModel.ins.curOperFormationIndex = -1;
                PartnerFormationModel.ins.curOperFormationPartnerPosIndex = -1;
                PartnerFormationModel.ins.curOperFormationPartnerTplId = 0;
                PartnerFormationModel.ins.curOperFormationPartnerItem = null;
                PartnerFormationModel.ins.partnerUIScript.ResetPartnerItemStatus();
            }
        }
        
        public void OnFormationPartnerItemUIHeadBtnClicked(FormationPartnerItemUIScript item)
        {
            if (PartnerFormationModel.ins.curOperFormationPartnerItem != null)
            {
                PartnerFormationModel.ins.curOperFormationPartnerItem.ResetStatus();
            }
            
            if (PartnerFormationModel.ins.curOperFormationPartnerItem != item)
            {
                PartnerFormationModel.ins.curOperFormationIndex = item.formationIndex;
                PartnerFormationModel.ins.curOperFormationPartnerPosIndex = item.partnerPosIndex;
                PartnerFormationModel.ins.curOperFormationPartnerTplId = item.tpl == null ? 0 : item.tpl.Id;
                PartnerFormationModel.ins.curOperFormationPartnerItem = item;
                item.ui.selected.SetActive(true);
                item.ui.jianBtn.gameObject.SetActive(true);
                PartnerFormationModel.ins.partnerUIScript.ShowUpBtn();
                PetFriendArrayInfo arrayInfo = Human.Instance.PetModel.petFriendArrayInfoList[item.formationIndex];
                int len = arrayInfo.tplIdList.Length;
                for (int i = 0; i < len; i++)
                {
                    if (PropertyUtil.IsLegalID(arrayInfo.tplIdList[i]) && arrayInfo.tplIdList[i] != PartnerFormationModel.ins.curOperFormationPartnerTplId)
                    {
                        PartnerFormationModel.ins.formationListUIScript.ShowPartnerItemSwitchBtn(item.formationIndex, i);
                    }
                }
            }
            else
            {
                PartnerFormationModel.ins.partnerUIScript.ResetPartnerItemStatus();
                PartnerFormationModel.ins.formationListUIScript.ResetPartnerItemsStatus(item.formationIndex);
                
                PartnerFormationModel.ins.curOperFormationIndex = -1;
                PartnerFormationModel.ins.curOperFormationPartnerPosIndex = -1;
                PartnerFormationModel.ins.curOperFormationPartnerTplId = 0;
                PartnerFormationModel.ins.curOperFormationPartnerItem = null;
            }
        }
        
        public void OnFormationPartnerItemUIJianBtnClicked(FormationPartnerItemUIScript item)
        {
            PetCGHandler.sendCGPetFriendOffArray(item.formationIndex, item.partnerPosIndex);
            PartnerFormationModel.ins.curOperFormationIndex = -1;
            PartnerFormationModel.ins.curOperFormationPartnerPosIndex = -1;
            PartnerFormationModel.ins.curOperFormationPartnerTplId = 0;
            PartnerFormationModel.ins.curOperFormationPartnerItem.ResetStatus();
            PartnerFormationModel.ins.curOperFormationPartnerItem = null;
            item.ResetStatus();
            PartnerFormationModel.ins.partnerUIScript.ResetPartnerItemStatus();
        }
        
        public void OnFormationPartnerItemUIZhuanBtnClicked(FormationPartnerItemUIScript item)
        {
            PetCGHandler.sendCGPetFriendChangePosition(item.formationIndex, PartnerFormationModel.ins.curOperFormationPartnerTplId, item.partnerPosIndex);
            PartnerFormationModel.ins.curOperFormationIndex = -1;
            PartnerFormationModel.ins.curOperFormationPartnerPosIndex = -1;
            PartnerFormationModel.ins.curOperFormationPartnerTplId = 0;
            PartnerFormationModel.ins.curOperFormationPartnerItem.ResetStatus();
            PartnerFormationModel.ins.curOperFormationPartnerItem = null;
            item.ResetStatus();
            PartnerFormationModel.ins.partnerUIScript.ResetPartnerItemStatus();
        }
        
        public void OnPartnerListItemShangBtnClicked(int tplId)
        {
            int arrayIndex = PartnerFormationModel.ins.curOperFormationIndex;
            int targetPosIndex = PartnerFormationModel.ins.curOperFormationPartnerPosIndex;
            int targetPosTplId = PartnerFormationModel.ins.curOperFormationPartnerTplId;
            PartnerFormationModel.ins.partnerUIScript.ResetPartnerItemStatus();
            PetCGHandler.sendCGPetFriendPutonArray(arrayIndex, tplId, targetPosIndex);
            PartnerFormationModel.ins.curOperFormationIndex = -1;
            PartnerFormationModel.ins.curOperFormationPartnerPosIndex = -1;
            PartnerFormationModel.ins.curOperFormationPartnerTplId = 0;
            PartnerFormationModel.ins.curOperFormationPartnerItem.ResetStatus();
            PartnerFormationModel.ins.curOperFormationPartnerItem = null;
        }
        
        public void OnPetFriendInfoReceived(GCPetFriendInfo info)
        {
            if (PartnerFormationModel.ins.partnerInfoView != null)
            {
                PartnerFormationModel.ins.partnerInfoView.OnPetFriendInfoReceived(info);
            }
        }
    }
}