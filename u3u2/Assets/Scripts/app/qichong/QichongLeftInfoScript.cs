using UnityEngine;
using System.Collections.Generic;
using app.pet;
using app.net;
using app.human;
using UnityEngine.UI;
using app.role;
using app.confirm;

namespace app.qichong
{
public class QichongLeftInfoScript  
{

        public const string SHOW_PET_UPGRADE_EFFECT = "SHOW_PET_UPGRADE_EFFECT";

        QichongLeftInfoUI UI;
        System.Action<Pet> clickHandler;
        public List<Pet> petList;
        private List<PetItem> petItemList;

        private long currentPetId = 0;

        private RMetaEventHandler clickPetCallBack;

        private QichongView mQichongView;

        public QichongLeftInfoScript(QichongLeftInfoUI UI,System.Action<Pet> clickHandler,QichongView qichongView)
        {
            this.UI = UI;
            this.clickHandler = clickHandler;
            mQichongView = qichongView;
            EventCore.addRMetaEventListener(SHOW_PET_UPGRADE_EFFECT, ShowPetUpgradeEffect);
            init();
        }



        public long CurrentPetId
        {
            get { return currentPetId; }
        }

        private void init()
        {
            UI.expProgress.LabelType = ProgressBarLabelType.CurrentAndMax;
            UI.petRenameBtn.SetClickCallBack(clickRename);
        }

        private void clickRename()
        {
            ConfirmWnd.Ins.ShowInput("请输入新的宠物名字（4-12个字符）", renameHandler);
        }

        private void renameHandler(RMetaEvent e)
        {
            if (e != null && e.data is string && currentPetId != 0)
            {
                PetCGHandler.sendCGPetHorseChangeName(currentPetId, e.data as string);
            }
        }

        public Pet getCurrentPet()
        {
            if (currentPetId != 0)
            {
                Pet pet = Human.Instance.PetModel.getPet(currentPetId);
                if (pet != null)
                {
                    return pet;
                }
            }
            return null;
        }

        public void updatePanel()
        {
            if (UI == null)
            {
                return;
            }
            petList = Human.Instance.PetModel.getPetListByType(PetType.PET_FOR_RIDE,true);
           
            if (petList.Count == 0)
            {
                mQichongView.hide();
                return;
            }

            if (petItemList == null)
            {
                petItemList = new List<PetItem>();
            }
            
            bool hasChuZhan = false;
            int selectedIndex = -1;
            Pet pet = getCurrentPet();
            UI.petListTBG.ClearToggleList();
            UI.petListTBG.TabChangeHandler = clickItemHandler;
            UI.defaultQichongItem.gameObject.SetActive(false);
            for (int i = 0; i < petList.Count; i++)
            {
                PetItem petItem;
                if (i < petItemList.Count)
                {
                    petItem = petItemList[i];
                    //petItem.setEmpty();
                }
                else
                {
                    CommonItemUI bagitem = GameObject.Instantiate(UI.defaultQichongItem);
                    bagitem.gameObject.transform.SetParent(UI.qichongGrid.transform);
                    bagitem.gameObject.transform.localScale = Vector3.one;
                    bagitem.ScrollRect = UI.qichongGrid.transform.parent.GetComponent<ScrollRect>();
                    petItem = new PetItem(bagitem);
                    petItemList.Add(petItem);
                }
                petItem.UI.gameObject.SetActive(true);
                UI.petListTBG.AddToggle(petItem.UI.SelectedToggle);
                petItem.setData(petList[i]);
                petItem.UI.transform.SetSiblingIndex(i);
                //if (pet==null&&petList[i].IsPetOnFight())
                if (pet == null && petList[i].isOnFight)
                {
                    //当前无选中的，则选择正在出战的宠物
                    hasChuZhan = true;
                    selectedIndex = i;
                }
                if (pet != null && pet.Id == petList[i].Id)
                {
                    //当前有选中的，刷新当前宠物
                    selectedIndex = i;
                }
            }
            for (int i = petList.Count; i < petItemList.Count; i++)
            {//删除多余的
                petItemList[i].setEmpty();
                petItemList[i].Dispose();
            }
            if (petItemList.Count > petList.Count)
            {
                petItemList.RemoveRange(petList.Count, petItemList.Count - petList.Count);
            }

            if (pet == null && !hasChuZhan && petList.Count > 0)
            {
                //当前无选中，也没有出战的宠物，默认选择第一个
                selectedIndex = 0;
            }
            if (selectedIndex != -1)
            {
                //当前有选中的，刷新当前宠物
                UI.petListTBG.SetIndexWithCallBack(selectedIndex);
            }
            else
            {
                if (petList.Count == 0)
                {
                    setEmpty();
                    UI.petListTBG.UnSelectAll();
                }
                else
                {
                    selectedIndex = 0;
                    UI.petListTBG.SetIndexWithCallBack(selectedIndex);
                }
            }
        }

        private void clickItemHandler(int index)
        {
            Pet pet = petList[index];
            ClientLog.Log("点击pet了！" + pet.Id);
            currentPetId = pet.Id;

            updateInfo(pet);

            if (clickPetCallBack != null)
            {
                clickPetCallBack(new RMetaEvent("clickpetitem", null));
            }
            if (clickHandler != null)
            {
                clickHandler(getCurrentPet());
            }
        }

        private void setEmpty()
        {
            currentPetId = 0;
            UI.textLevel.text = "";
            UI.textName.text = "没骑宠快去抓";
            UI.expProgress.Percent = 0.1f;
            UI.expProgress.Percent = 0;

            if (clickPetCallBack != null)
            {
                clickPetCallBack(new RMetaEvent("clickpetitem", null));
            }
            if (clickHandler != null)
            {
                clickHandler(getCurrentPet());
            }

        }

        private void updateInfo(Pet pet)
        {
            if (pet == null)
            {
                ClientLog.LogError("pet is null");
                return;
            }
            UI.textLevel.text = "Lv." + pet.getLevel();
            UI.textName.text = pet.getName();
           // UI.bianyi.SetActive(pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GENE_TYPE) == 1);

            PetQuality petQuality = (PetQuality)(pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PET_HORSE_GROWTH_COLOR));
            UI.objPutong.SetActive(petQuality == PetQuality.PUTONG);
            UI.objYouxiu.SetActive(petQuality == PetQuality.YOUXIU);
            UI.objJiechu.SetActive(petQuality == PetQuality.JIECHU);
            UI.objZhuoyue.SetActive(petQuality == PetQuality.ZHUOYUE);
            UI.objChaofan.SetActive(petQuality == PetQuality.CHAOFAN);
            UI.objWanmei.SetActive(petQuality == PetQuality.WANMEI);
            
            //绑定状态
            int bind = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PET_BIND);
            if (bind==0)
            {
                //绑定
                UI.bindtag.gameObject.SetActive(true);
                UI.nobindtag.gameObject.SetActive(false);
            }else if (bind==1)
            {
                //非绑定
                UI.bindtag.gameObject.SetActive(false);
                UI.nobindtag.gameObject.SetActive(true);
            }
            else
            {
                UI.bindtag.gameObject.SetActive(false);
                UI.nobindtag.gameObject.SetActive(false);
            }

            //出战
            UI.tfQiCheng.gameObject.SetActive(pet.isOnFight);

            //EXP
            UI.expProgress.setLongPercent(pet.getExpLimit(), pet.getExp());
        }
        
        private void ShowPetUpgradeEffect(RMetaEvent e)
        {
            UI.shengjiEffect.SetActive(false);
            UI.shengjiEffect.SetActive(true);
        }
        
        public void Destroy()
        {
            EventCore.removeRMetaEventListener(SHOW_PET_UPGRADE_EFFECT, ShowPetUpgradeEffect);
            //GameObject.DestroyImmediate(UI.gameObject, true);
            if (petList != null)
            {
                petList.Clear();
                petList = null;
            }

            if (petItemList != null)
            {
                petItemList.Clear();
                petItemList = null;
            }
            UI = null;
        }
}
}
