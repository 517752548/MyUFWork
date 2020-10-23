using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using app.pet;
using app.net;

namespace app.ridepet
{
    public class RidePetView : BaseUI
    {
        public RidePetUI UI;

        public PetModel petModel;

        private List<RidePetListItemScript> mRidePetList = null;

        private Pet mCurPet = null;

        public RidePetView(RidePetUI ui)
        {
            UI = ui;
            base.ui = ui.gameObject;
            initWnd();
        }

        public void initWnd()
        {
            petModel = PetModel.Ins;
            petModel.addChangeEvent(PetModel.UPDATE_PET_LIST, OnPetListUpdated);
            petModel.addChangeEvent(PetModel.UPDATE_PET_PROP, OnPetUpdated);
            petModel.addChangeEvent(PetModel.UPDATE_PET_INFO, OnPetUpdated);
            petModel.addChangeEvent(PetModel.UPDATE_PET_FIGHT_STATE, OnPetUpdated);

            UI.petListItemUIGroup.TabChangeHandler = OnPetSelected;
            UI.onBtn.SetClickCallBack(On);
            UI.offBtn.SetClickCallBack(Off);
        }

        private bool misShown = false;

        public override void show(RMetaEvent e = null)
        {
            misShown = true;
            if (mRidePetList == null)
            {
                CreateRidePetList();
            }

            if (mRidePetList.Count > 0 && UI.petListItemUIGroup.index == -1)
            {
                UI.petListItemUIGroup.SetIndexWithCallBack(0);
            }
        }

        private void CreateRidePetList()
        {
            mRidePetList = new List<RidePetListItemScript>();
            List<Pet> pets = petModel.getPetListByType(PetType.PET_FOR_RIDE);

            int len = pets.Count;

            for (int i = 0; i < len; i++)
            {
                RidePetListItemUI petItemUI = GameObject.Instantiate(UI.petListItemUI);
                petItemUI.gameObject.transform.SetParent(UI.petListItemUI.gameObject.transform.parent);
                petItemUI.gameObject.transform.localScale = UI.petListItemUI.gameObject.transform.localScale;
                petItemUI.gameObject.SetActive(true);

                RidePetListItemScript petItem = new RidePetListItemScript(petItemUI);
                petItem.SetData(pets[i]);
                UI.petListItemUIGroup.AddToggle(petItemUI.GetComponent<GameUUToggle>());
                mRidePetList.Add(petItem);
            }
        }

        private void DestroyRidePetList()
        {
            if (mRidePetList != null)
            {
                int petListLen = mRidePetList.Count;
                for (int i = 0; i < petListLen; i++)
                {
                    mRidePetList[i].Destroy();
                }
                mRidePetList.Clear();
                mRidePetList = null;
            }
            
            UI.petListItemUIGroup.ClearToggleList();
            RemoveAvatarModel();
            UI.onBtn.gameObject.SetActive(false);
            UI.offBtn.gameObject.SetActive(false);
        }

        public void OnPetListUpdated(RMetaEvent e)
        {
            if (mRidePetList != null)
            {
                DestroyRidePetList();
            }
            if (misShown)
            {
                CreateRidePetList();
            }
        }

        public void OnPetUpdated(RMetaEvent e)
        {
            if (mRidePetList != null)
            {
                long petuuid = 0;
                if (e != null && e.data != null)
                {
                    petuuid = (long)e.data;
                }
                if (petuuid != 0)
                {
                    Pet pet = petModel.getPet(petuuid);
                    int len = mRidePetList.Count;
                    for (int i = 0; i < len; i++)
                    {
                        if (mRidePetList[i].GetData().Id == pet.Id)
                        {
                            mRidePetList[i].SetData(pet);
                            if (mCurPet != null && mCurPet.Id == pet.Id)
                            {
                                SetCurrentPet(pet);
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void OnPetSelected(int idx)
        {
            SetCurrentPet(mRidePetList[idx].GetData());
        }

        private void SetCurrentPet(Pet pet)
        {
            UI.PetName.text = pet.getTpl().name;
            AddPetModelToUI(Vector3.zero, Vector3.zero, Vector3.one, pet, UI.petModelContainer);

            int len = UI.propList.Count;
            int end = PetBProperty._BEGIN + PetBProperty._SIZE;
            int cur = 0;
            for (int i = PetBProperty._BEGIN + 1; i <= end; i++)
            {
                string propName = LangConstant.getPetPropertyName(i);
                int propValue = pet.PropertyManager.getPetIntProp(i);

                Text t = null;
                if (len <= cur)
                {
                    t = GameObject.Instantiate(UI.propListItem);
                    t.gameObject.transform.SetParent(UI.propListItem.gameObject.transform.parent);
                    t.gameObject.transform.localScale = UI.propListItem.gameObject.transform.localScale;
                    UI.propList.Add(t);
                    len++;
                }
                else
                {
                    t = UI.propList[cur];
                }

                t.gameObject.SetActive(true);

                t.text = propName + " " + propValue;

                cur++;
            }

            if (cur < len - 1)
            {
                for (int i = cur + 1; i < len; i++)
                {
                    UI.propList[i].text = "";
                }
            }

            //UI.onBtn.gameObject.SetActive(!pet.IsPetOnFight());
            UI.onBtn.gameObject.SetActive(!pet.isOnFight);
            //UI.offBtn.gameObject.SetActive(pet.IsPetOnFight());
            UI.offBtn.gameObject.SetActive(pet.isOnFight);

            mCurPet = pet;
        }

        private void On()
        {
            PetCGHandler.sendCGPetHorseRide(mCurPet.Id, 1);
        }

        private void Off()
        {
            PetCGHandler.sendCGPetHorseRide(mCurPet.Id, 0);
        }

        public override void Destroy()
        {
            petModel.removeChangeEvent(PetModel.UPDATE_PET_LIST, OnPetListUpdated);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_PROP, OnPetUpdated);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_INFO, OnPetUpdated);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_FIGHT_STATE, OnPetUpdated);
            DestroyRidePetList();
            base.Destroy();
            UI = null;
        }

    }
}