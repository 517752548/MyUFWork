using System.Collections.Generic;
using UnityEngine;
using app.net;
using app.pet;
using app.human;
using app.db;

namespace app.partnerformation
{
    public class PartnerUIScript
    {
        public PetModel petModel;
        public List<PartnerListItemUIScript> allPartnersList { get; private set; }
        private PetFriendUnlockInfo[] mPetFriendUnlockInfos = null;
        private PartnerFormationPUI mUI;
        private bool mIsShown = false;

        public PartnerUIScript(PartnerFormationPUI ui)
        {
            mUI = ui;
            petModel = PetModel.Ins;
            petModel.addChangeEvent(PetModel.UPDATE_PET_FRIEND_ARRAY, OnPetFriendArrayInfoUpdated);
            ui.partnerTypes.TabChangeHandler = OnPartnerTypeChanged;
        }

        public void Show()
        {
            mUI.gameObject.SetActive(true);

            if (allPartnersList == null)
            {
                CreateAllPartnersList();
            }

            if (mUI.partnerTypes.index == -1)
            {
                mUI.partnerTypes.SetIndexWithCallBack(0);
            }

            PetCGHandler.sendCGPetOpenFriendPanel();

            mIsShown = true;
        }

        public void Hide()
        {
            mIsShown = false;
        }

        private void OnPartnerTypeChanged(int idx)
        {
            if (allPartnersList == null)
            {
                return;
            }

            int curShowingTpye = PetJobType.NONE;
            switch (idx)
            {
                case 0:
                    //全部职业。
                    curShowingTpye = PetJobType.ALL;
                    break;
                case 1:
                    //侠客。
                    curShowingTpye = PetJobType.XIAKE;
                    break;
                case 2:
                    //刺客。
                    curShowingTpye = PetJobType.CIKE;
                    break;
                case 3:
                    //术士。
                    curShowingTpye = PetJobType.SHUSHI;
                    break;
                case 4:
                    //修真。
                    curShowingTpye = PetJobType.XIUZHEN;
                    break;
            }

            int len = allPartnersList.Count;
            for (int i = 0; i < len; i++)
            {
                PartnerListItemUIScript item = allPartnersList[i];
                item.SetActive(item.tpl != null && (curShowingTpye == PetJobType.ALL || item.tpl.jobId == curShowingTpye));
            }
            
            if (mUI.partnerListContainer.localPosition.y != 0)
            {
                mUI.partnerListContainer.localPosition = Vector3.zero;
            }
            else
            {
                mUI.partnerListContainer.localPosition = new Vector3(0, 1, 0);
            }
        }

        public void OnPetFriendUnlockInfoReceived(PetFriendUnlockInfo[] list)
        {
            mPetFriendUnlockInfos = list;
            int unlockInfoLen = list.Length;
            int allPartnersLen = allPartnersList.Count;
            for (int i = 0; i < unlockInfoLen; i++)
            {
                for (int j = 0; j < allPartnersLen; j++)
                {
                    if (allPartnersList[j].GetData().Id == list[i].tplId)
                    {
                        allPartnersList[j].leftTime = list[i].leftTime;
                        break;
                    }
                }
            }

            SortAllPartnersList();
            OnPartnerTypeChanged(mUI.partnerTypes.index);
            

            if (PartnerFormationModel.ins.partnerInfoView != null && PartnerFormationModel.ins.partnerInfoView.isShown)
            {
                PartnerFormationModel.ins.partnerInfoView.UpdateView();
            }
        }

        private void CreateAllPartnersList()
        {
            allPartnersList = new List<PartnerListItemUIScript>();
            foreach (KeyValuePair<int, PetFriendTemplate> pair in PetFriendTemplateDB.Instance.getIdKeyDic())
            {
                PartnerListItemUI itemUI = GameObject.Instantiate(mUI.partnerListItemUI);
                itemUI.gameObject.transform.SetParent(mUI.partnerListItemUI.gameObject.transform.parent);
                itemUI.gameObject.transform.localScale = mUI.partnerListItemUI.gameObject.transform.localScale;
                itemUI.gameObject.SetActive(true);
                PartnerListItemUIScript item = new PartnerListItemUIScript(itemUI);

                item.SetData(pair.Value);
                item.isOnFight = GetIsPartnerOnFight(pair.Value);
                item.leftTime = GetPartnerLeftTime(pair.Value);
                allPartnersList.Add(item);
            }
        }

        private void DestroyAllPartnersList()
        {
            int len = allPartnersList.Count;
            for (int i = 0; i < len; i++)
            {
                allPartnersList[i].Destroy();
            }

            allPartnersList = null;
        }

        private void OnPetFriendArrayInfoUpdated(RMetaEvent e)
        {
            if (allPartnersList != null)
            {
                int partnersLen = allPartnersList.Count;
                for (int i = 0; i < partnersLen; i++)
                {
                    allPartnersList[i].isOnFight = GetIsPartnerOnFight(allPartnersList[i].GetData());
                }

                SortAllPartnersList();
                OnPartnerTypeChanged(mUI.partnerTypes.index);
            }

            if (PartnerFormationModel.ins.partnerInfoView != null && PartnerFormationModel.ins.partnerInfoView.isShown)
            {
                PartnerFormationModel.ins.partnerInfoView.UpdateView();
            }
        }

        private void SortAllPartnersList()
        {
            allPartnersList.Sort();
            int len = allPartnersList.Count;
            for (int i = 0; i < len; i++)
            {
                allPartnersList[i].ui.gameObject.transform.SetSiblingIndex(i);
            }
        }

        private bool GetIsPartnerOnFight(PetFriendTemplate tpl)
        {
            PetFriendArrayInfo[] petFriendArrayInfoList = Human.Instance.PetModel.petFriendArrayInfoList;
            if (petFriendArrayInfoList == null)
            {
                return false;
            }

            PetFriendArrayInfo petFriendArrayInfo = petFriendArrayInfoList[Human.Instance.PetModel.curPetFriendArrayIdx];
            int len = petFriendArrayInfo.tplIdList.Length;
            for (int j = 0; j < len; j++)
            {
                if (petFriendArrayInfo.tplIdList[j] == tpl.Id)
                {
                    return true;
                }
            }
            return false;
        }

        private long GetPartnerLeftTime(PetFriendTemplate tpl)
        {
            if (mPetFriendUnlockInfos != null)
            {
                int len = mPetFriendUnlockInfos.Length;
                for (int i = 0; i < len; i++)
                {
                    if (mPetFriendUnlockInfos[i].tplId == tpl.Id)
                    {
                        return mPetFriendUnlockInfos[i].leftTime;
                    }
                }
            }
            return tpl.needUnlock == 1 ? 0 : -1;
        }

        public PartnerListItemUIScript GetPartnerListItemUIScript(int tplId)
        {
            int len = allPartnersList.Count;
            for (int i = 0; i < len; i++)
            {
                if (allPartnersList[i].tpl != null && allPartnersList[i].tpl.Id == tplId)
                {
                    return allPartnersList[i];
                }
            }

            return null;
        }

        public int GetPartnerItemIndex(int tplId)
        {
            int len = allPartnersList.Count;
            for (int i = 0; i < len; i++)
            {
                if (allPartnersList[i].tpl != null && allPartnersList[i].tpl.Id == tplId)
                {
                    return i;
                }
            }

            return -1;
        }

        public void ResetPartnerItemStatus()
        {
            int len = allPartnersList.Count;
            for (int i = 0; i < len; i++)
            {
                allPartnersList[i].ui.shangBtn.gameObject.SetActive(false);
            }
        }

        public void ShowUpBtn()
        {
            int len = allPartnersList.Count;
            for (int i = 0; i < len; i++)
            {
                PartnerListItemUIScript item = allPartnersList[i];
                //item.ui.shangBtn.gameObject.SetActive(item.leftTime != 0 && !item.isOnFight);
                PetFriendArrayInfo curOperArrayInfo = Human.Instance.PetModel.petFriendArrayInfoList[PartnerFormationModel.ins.curOperFormationIndex];
                bool isCurArrayInfoHasId = false;
                int tplListLen = curOperArrayInfo.tplIdList.Length;
                for (int j = 0; j < tplListLen; j++)
                {
                    if (curOperArrayInfo.tplIdList[j] == item.GetData().Id)
                    {
                        isCurArrayInfoHasId = true;
                        break;
                    }
                }
                item.ui.shangBtn.gameObject.SetActive(item.leftTime != 0 && !isCurArrayInfoHasId);
            }
        }
        
        public void Destroy()
        {
            petModel.removeChangeEvent(PetModel.UPDATE_PET_FRIEND_ARRAY, OnPetFriendArrayInfoUpdated);
            GameObject.DestroyImmediate(mUI.gameObject, true);
            mUI = null;
        }
    }
}