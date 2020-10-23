using UnityEngine;
using app.net;
using app.role;
using app.db;
using app.utils;
using app.bag;
using app.tips;

namespace app.pet
{
    public class PetBianyiUIScript
    {
        public BagModel bagModel;

        private PetBianyiUI mUI = null;
        private Pet mPet = null;

        private PetVariationTemplate mCostTpl = null;
        private ItemTemplate mCostItemTpl = null;

        public PetBianyiUIScript(PetBianyiUI ui)
        {
            mUI = ui;
            bagModel = BagModel.Ins;
            bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateXiaohaoItemNum);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateXiaohaoItemNum);
            mCostTpl = PetVariationTemplateDB.Instance.getTemplate(1);
            mCostItemTpl = ItemTemplateDB.Instance.getTempalte(mCostTpl.itemId);
            /*
            if (mCostItemTpl.rarityId > 0)
            {
                Sprite t = SourceManager.Ins.GetBiankuang(mCostItemTpl.rarityId);
                if (t != null)
                {
                    mUI.xiaohaoItem.biangkuang.sprite = t;
                }
                else
                {
                    mUI.xiaohaoItem.biangkuang.gameObject.SetActive(false);
                }
            }
            else
            {
                mUI.xiaohaoItem.biangkuang.gameObject.SetActive(false);
            }
            */
            //mUI.xiaohaoItem.Name.text = mCostItemTpl.name;

            //mUI.xiaohaoItem.icon.gameObject.SetActive(false);
            //mUI.xiaohaoItem.icon.texture = PathUtil.Ins.GetItemIcon(mCostItemTpl.icon);
            //mUI.xiaohaoItem.icon.gameObject.SetActive(true);
            PathUtil.Ins.SetItemIcon(mUI.xiaohaoItem.icon, mCostItemTpl.icon);

            //SourceLoader.Ins.load(PathUtil.Ins.GetUITexturePath(mCostItemTpl.icon, PathUtil.TEXTUER_ITEM), OnCostIconLoaded);
            //mUI.xiaohaoNum1.text = costTpl.currencyNum.ToString();
            //mUI.xiaohaoNum2.text = costTpl.itemNum.ToString();
            mUI.bianyiBtn.SetClickCallBack(OnBianyiBtnClicked);
            mUI.bianyi10Btn.SetClickCallBack(OnBianyi10BtnClicked);
            
            EventTriggerListener.Get(mUI.xiaohaoItem.gameObject).onClick = OnXiaohaoItemClicked;
        }
        /*
        private void OnCostIconLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                LoadInfo info = (LoadInfo)(e.data);
                string path = info.urlPath;
                Texture t = SourceManager.Ins.GetAsset<Texture>(path);
                if (t != null)
                {
                    mUI.xiaohaoItem.icon.texture = t;
                    mUI.xiaohaoItem.icon.gameObject.SetActive(true);
                }
            }
        }
        */

        public void UpdatePanel(Pet pet)
        {
            mPet = pet;

            if (pet == null)
            {
                mUI.gameObject.SetActive(false);
            }
            else
            {
                mUI.gameObject.SetActive(true);

                if (pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GENE_TYPE) == 1)
                {
                    //已变异。
                    mUI.bianyiBtn.interactable = false;
                    mUI.weibianyidis.SetActive(false);
                    mUI.yibianyidis.SetActive(true);
                    //mUI.yibianyi1dis.SetActive(true);
                }
                else
                {
                    mUI.bianyiBtn.interactable = true;
                    mUI.weibianyidis.SetActive(true);
                    mUI.yibianyidis.SetActive(false);
                }

                UpdateXiaohaoItemNum(null);
            }
        }

        private void UpdateXiaohaoItemNum(RMetaEvent e)
        {
            if (mUI.gameObject.activeInHierarchy)
            {
                int cost = mCostTpl.itemNum;
                int have = human.Human.Instance.BagModel.getHasNum(mCostTpl.itemId);

                if (have >= cost)
                {
                    mUI.xiaohaoItem.num.text = ColorUtil.getColorText(ColorUtil.GREEN_ID, have.ToString()) + " / " + cost;
                }
                else
                {
                    mUI.xiaohaoItem.num.text = ColorUtil.getColorText(ColorUtil.RED_ID, have.ToString()) + " / " + cost;
                }
            }
        }

        private void OnBianyiBtnClicked()
        {
            PetCGHandler.sendCGPetVariation(mPet.Id, 0);
        }

        private void OnBianyi10BtnClicked()
        {
            PetCGHandler.sendCGPetVariation(mPet.Id, 1);
        }
        
        private void OnXiaohaoItemClicked(GameObject go)
        {
            ItemTips.Ins.ShowTips(mCostItemTpl,true);
        }
        
        public void Destroy()
        {
            bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateXiaohaoItemNum);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateXiaohaoItemNum);
            GameObject.DestroyImmediate(mUI.gameObject, true);
            mUI = null;
        }
    }
}