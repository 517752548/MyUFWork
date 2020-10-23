using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using app.pet;

namespace app.battle
{
    public class BattlePetListUI
    {
        public UnityAction<long> onPetSelected = null;
        public bool isShown { get; private set; }
        private BattlePetListUIBehav mUI = null;
        private GameObject mMaskImage = null;
        private List<BattlePetListItem> mPetItems = new List<BattlePetListItem>();

        private class BattlePetListItem
        {
            public BattlePetListItemUI ui { get; private set; }
            public Pet data { get; private set; }
            public BattlePetListItem(BattlePetListItemUI ui)
            {
                this.ui = ui;
            }

            public void SetData(Pet pet)
            {
                if (pet == null)
                {
                    ui.gameObject.SetActive(false);
                }
                else
                {
                    ui.gameObject.SetActive(true);
                    ui.petBloodBar.LabelType = ProgressBarLabelType.None;
                    ui.petUUID = pet.Id;
                    /*
                    if (ui.headIcon.texture == null)
                    {
                        ui.headIcon.enabled = false;
                    }
                    PathUtil.Ins.SetRawImageSource(ui.headIcon, pet.getTpl().modelId, PathUtil.TEXTUER_HEAD, false, delegate () { ui.headIcon.enabled = true; });
                    */
                    PathUtil.Ins.SetHeadIcon(ui.headIcon, pet.getTpl().modelId);
                    ui.petName.text = pet.getName();
                    ui.petLevel.text = "Lv " + pet.getLevel();
                    int maxHp = pet.PropertyManager.getPetIntProp(PetBProperty.HP);
                    int curHp = pet.curHp;
                    ui.petBloodBar.MaxValue = maxHp;
                    ui.petBloodBar.Value = curHp;
                }
                data = pet;
            }
            
            public void Destroy()
            {
                GameObject.DestroyImmediate(ui.gameObject, true);
                ui = null;
                data = null;
            }
        }

        public BattlePetListUI(BattlePetListUIBehav ui, GameObject maskImage)
        {
            mUI = ui;
            mMaskImage = maskImage;
            mUI.closeBtn.AddClickCallBack(Hide);
        }

        public void Show(List<Pet> avaliablePets)
        {
            if (!isShown)
            {
                mUI.gameObject.SetActive(true);
                mMaskImage.SetActive(true);
                UpdateData(avaliablePets);
                isShown = true;
            }
        }

        public void UpdateData(List<Pet> avaliablePets)
        {
            avaliablePets.Sort(PetItemSorter);
            int petCount = avaliablePets.Count;
            int petItemCount = mPetItems.Count;
            for (int i = 0; i < petCount; i++)
            {
                if (i >= petItemCount)
                {
                    BattlePetListItemUI petItemUI = GameObject.Instantiate(mUI.petListItemUI);
                    petItemUI.transform.SetParent(mUI.petListItemUI.transform.parent);
                    petItemUI.transform.localScale = Vector3.one;
                    petItemUI.GetComponent<GameUUButton>().AddClickCallBack(OnPetItemClicked);
                    mPetItems.Add(new BattlePetListItem(petItemUI));
                }
                
                mPetItems[i].SetData(avaliablePets[i]);
            }
            for (int i = petCount; i < petItemCount; i++)
            {
                mPetItems[i].SetData(null);
            }
        }

        private int PetItemSorter(Pet a, Pet b)
        {
            if (a.getLevel() > b.getLevel())
            {
                return -1;
            }
            else if (a.getLevel() < b.getLevel())
            {
                return 1;
            }
            else
            {
                if (a.Id > b.Id)
                {
                    return -1;
                }
                else if (a.Id < b.Id)
                {
                    return 1;
                }
            }
            return 0;
        }

        private void OnPetItemClicked(GameObject go)
        {
            if (onPetSelected != null)
            {
                BattlePetListItemUI itemUI = go.GetComponent<BattlePetListItemUI>();
                onPetSelected(itemUI.petUUID);
            }
            Hide(null);
        }

        public void Hide(GameObject btn)
        {
            if (isShown)
            {
                mUI.gameObject.SetActive(false);
                mMaskImage.SetActive(false);
                isShown = false;
                if (btn != null)
                {
                    BattleUI.ins.UI.manualBtnsTbg.UnSelectAll();
                }
            }
        }
        
        public void Destroy()
        {
            int petItemCount = mPetItems.Count;
            for (int i = 0; i < petItemCount; i++)
            {
                mPetItems[i].Destroy();
            }
            mPetItems.Clear();
            GameObject.DestroyImmediate(mMaskImage, true);
            mMaskImage = null;
            GameObject.DestroyImmediate(mUI, true);
            mUI = null;
        }
    }
}