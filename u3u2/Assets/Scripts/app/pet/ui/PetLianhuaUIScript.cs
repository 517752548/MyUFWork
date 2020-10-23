using UnityEngine;
using app.net;
using app.role;
using app.db;
using app.utils;
using app.tips;
using app.bag;

namespace app.pet
{
    internal class PetLianhuaXiaohaoItem
    {
        private CommonItemUINoClick mUI = null;
        //private PetArtificeTemplate mCostTpl = null;
        private ItemTemplate mItemTpl = null;
        private int m_need_item_id = 0;
        private int m_need_item_num = 0;

        public PetLianhuaXiaohaoItem(CommonItemUINoClick ui,int itemid,int itemnum)// PetArtificeTemplate costTpl)
        {
            mUI = ui;
            //mCostTpl = costTpl;
            m_need_item_id = itemid;
            m_need_item_num = itemnum;
            if (m_need_item_id>0)
            {
                mUI.icon.gameObject.SetActive(false);
                mItemTpl = ItemTemplateDB.Instance.getTempalte(m_need_item_id);
                if (mItemTpl != null)
                {
                    /*
                    mUI.icon.texture = PathUtil.Ins.GetItemIcon(mItemTpl.icon);
                    mUI.icon.gameObject.SetActive(true);
                    */
                    PathUtil.Ins.SetItemIcon(mUI.icon, mItemTpl.icon);

                    //SourceLoader.Ins.load(PathUtil.Ins.GetUITexturePath(, PathUtil.TEXTUER_ITEM), OnCostIconLoaded);
                    /*
                    if (mItemTpl.rarityId > 0)
                    {
                        Sprite t = SourceManager.Ins.GetBiankuang(mItemTpl.rarityId);
                        if (t != null)
                        {
                            mUI.biangkuang.sprite = t;
                        }
                        else
                        {
                            mUI.biangkuang.gameObject.SetActive(false);
                        }
                    }
                    else
                    {
                        mUI.biangkuang.gameObject.SetActive(false);
                    }
                    */
                    //mUI.Name.text = mItemTpl.name;
                }

                Update();
            }
            else
            {
                mUI.icon.gameObject.SetActive(false);
                //mUI.biangkuang.gameObject.SetActive(false);
                //mUI.Name.text = "";
                //mUI.num.text = "";
                mItemTpl = null;
            }

            EventTriggerListener.Get(mUI.gameObject).onClick = OnXiaohaoItemClicked;
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
                    mUI.icon.texture = t;
                    mUI.icon.gameObject.SetActive(true);
                }
            }
        }
        */

        public void Update()
        {
            //int cost = mCostTpl.itemNum;
            int have = human.Human.Instance.BagModel.getHasNum(m_need_item_id);

            if (have >= m_need_item_num)
            {
                mUI.num.text = ColorUtil.getColorText(ColorUtil.GREEN_ID, have.ToString()) + " / " + m_need_item_num;
            }
            else
            {
                mUI.num.text = ColorUtil.getColorText(ColorUtil.RED_ID, have.ToString()) + " / " + m_need_item_num;
            }
        }

        private void OnXiaohaoItemClicked(GameObject go)
        {
            ItemTips.Ins.ShowTips(mItemTpl, true);
        }
    }

    public class PetLianhuaUIScript
    {
        private PetLianhuaUI mUI = null;
        private Pet mPet = null;

        PetLianhuaXiaohaoItem mPutongXiaohao = null;
        PetLianhuaXiaohaoItem mWanmeiXiaohao = null;

        public PetLianhuaUIScript(PetLianhuaUI ui)
        {
            mUI = ui;
            mUI.lianhuaBtn.SetClickCallBack(OnLianhuaBtnClick);
            mUI.tishengBtn.SetClickCallBack(OnTishengBtnClick);

            PetArtificeTemplate putong = PetArtificeTemplateDB.Instance.getTemplate(1);
            PetArtificeTemplate wanmei = PetArtificeTemplateDB.Instance.getTemplate(2);
            if(null != putong)
            {
                mPutongXiaohao = new PetLianhuaXiaohaoItem(mUI.putongXiaohao, putong.itemId, putong.itemNum);
            }
            else
            {
                mPutongXiaohao = new PetLianhuaXiaohaoItem(mUI.putongXiaohao, 0, 0);
            }
            if (null != wanmei)
            {
                mWanmeiXiaohao = new PetLianhuaXiaohaoItem(mUI.wanmeiXiaohao, wanmei.itemId,wanmei.itemNum);
            }
            else
            {
                mWanmeiXiaohao = new PetLianhuaXiaohaoItem(mUI.wanmeiXiaohao, 0, 0);
            }

            BagModel.Ins.addChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateXiaohaoItemNum);
            BagModel.Ins.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateXiaohaoItemNum);
        }

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
                PetQuality petQuality = (PetQuality)(pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GROWTH_COLOR));
                PetGrowthTemplate pgt = PetGrowthTemplateDB.Instance.getTemplate((int)petQuality);
                mUI.chengzhanglv.text = ColorUtil.getColorText((int)petQuality, pgt.name) + " " + ColorUtil.getColorText(ColorUtil.GREEN_ID, "(" + (pgt.add / ClientConstantDef.PET_DIV_BASE * 100) + "%)");

                PetArtificeTemplate costTpl = null;

                switch (petQuality)
                {
                    case PetQuality.NONE:
                    case PetQuality.PUTONG:
                    case PetQuality.YOUXIU:
                    case PetQuality.JIECHU:
                    case PetQuality.ZHUOYUE:
                        mUI.putong.SetActive(true);
                        mUI.wanmei.SetActive(false);
                        mUI.chaofan.SetActive(false);
                        mPutongXiaohao.Update();
                        break;
                    case PetQuality.WANMEI:
                        mUI.putong.SetActive(false);
                        mUI.wanmei.SetActive(true);
                        mUI.chaofan.SetActive(false);
                        mWanmeiXiaohao.Update();
                        break;
                    case PetQuality.CHAOFAN:
                        mUI.putong.SetActive(false);
                        mUI.wanmei.SetActive(false);
                        mUI.chaofan.SetActive(true);
                        break;
                }
            }
        }

        private void UpdateXiaohaoItemNum(RMetaEvent e)
        {
            mPutongXiaohao.Update();
            mWanmeiXiaohao.Update();
        }

        private void OnLianhuaBtnClick()
        {
            PetCGHandler.sendCGPetArtifice(mPet.Id);
        }

        private void OnTishengBtnClick()
        {
            PetCGHandler.sendCGPetArtifice(mPet.Id);
        }

        public void Destroy()
        {
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateXiaohaoItemNum);
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateXiaohaoItemNum);
            GameObject.DestroyImmediate(mUI.gameObject, true);
            mUI = null;
        }
    }
}

