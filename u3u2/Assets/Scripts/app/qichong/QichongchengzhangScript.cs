using UnityEngine;
using System.Collections;
using app.pet;
using app.net;
using app.db;
using app.role;
using app.utils;
using app.bag;

namespace app.qichong
{
    public class QichongchengzhangScript
    {
        private QichongchengzhangUI mUI;
        private Pet mPet = null;

        PetLianhuaXiaohaoItem mPutongXiaohao = null;
        PetLianhuaXiaohaoItem mWanmeiXiaohao = null;
        public QichongchengzhangScript(QichongchengzhangUI chengzhangUI)
        {
            this.mUI = chengzhangUI;
            mUI.lianhuaBtn.SetClickCallBack(OnLianhuaBtnClick);
            mUI.tishengBtn.SetClickCallBack(OnTishengBtnClick);

            PetHorseArtificeTemplate putong = PetHorseArtificeTemplateDB.Instance.getTemplate(1);
            PetHorseArtificeTemplate wanmei = PetHorseArtificeTemplateDB.Instance.getTemplate(2);
            if (null != putong)
            {
                mPutongXiaohao = new PetLianhuaXiaohaoItem(mUI.putongXiaohao, putong.itemId, putong.itemNum);
            }
            else
            {
                mPutongXiaohao = new PetLianhuaXiaohaoItem(mUI.putongXiaohao, 0,0);
            }
            if (null != wanmei)
            {
                mWanmeiXiaohao = new PetLianhuaXiaohaoItem(mUI.wanmeiXiaohao, wanmei.itemId, wanmei.itemNum);
            }
            else
            {
                mWanmeiXiaohao = new PetLianhuaXiaohaoItem(mUI.wanmeiXiaohao, 0,0);
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
                PetQuality petQuality = (PetQuality)(pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PET_HORSE_GROWTH_COLOR));
                if ((int) petQuality != 0)
                {
                    PetGrowthTemplate pgt = PetGrowthTemplateDB.Instance.getTemplate((int) petQuality);
                    if (pgt != null)
                    {
                        mUI.chengzhanglv.text = ColorUtil.getColorText((int) petQuality, pgt.name) + " " +
                                                ColorUtil.getColorText(ColorUtil.GREEN_ID,
                                                    "(" + (pgt.add/ClientConstantDef.PET_DIV_BASE*100) + "%)");
                    }
                }
               

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
            PetCGHandler.sendCGPetHorseArtifice(mPet.Id);
        }

        private void OnTishengBtnClick()
        {
            PetCGHandler.sendCGPetHorseArtifice(mPet.Id);
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