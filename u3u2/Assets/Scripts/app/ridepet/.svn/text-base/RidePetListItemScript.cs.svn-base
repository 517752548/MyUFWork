using UnityEngine;
using app.pet;

namespace app.ridepet
{
    public class RidePetListItemScript
    {
        private RidePetListItemUI mUI = null;
        private Pet mData = null;
        
        private string mHeadIconPath = null;
        public RidePetListItemScript(RidePetListItemUI ui)
        {
            mUI = ui;
        }
        
        public void SetData(Pet data)
        {
            //mUI.rideSign.SetActive(data.IsPetOnFight());
            mUI.rideSign.SetActive(data.isOnFight);
            mUI.petName.text = data.getTpl().name;
            mUI.petLevel.text = "Lv " + data.getLevel().ToString();
            if (mData == null || data.getTpl().modelId != mData.getTpl().modelId)
            {
                //LoadHeadIcon(data.getTpl().modelId);
                PathUtil.Ins.SetHeadIcon(mUI.headIcon, data.getTpl().modelId);
            }
            mData = data;
        }
        
        /*
        private void LoadHeadIcon(string modelId)
        {
            mUI.headIcon.gameObject.SetActive(false);
            mHeadIconPath = PathUtil.Ins.GetUITexturePath(modelId, PathUtil.TEXTUER_HEAD);
            SourceLoader.Ins.load(mHeadIconPath, OnHeadIconLoaded);
        }
        
        private void OnHeadIconLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                Texture2D t = SourceManager.Ins.GetAsset<Texture2D>(mHeadIconPath);
                if (t != null)
                {
                    mUI.headIcon.texture = t;
                    mUI.headIcon.gameObject.SetActive(true);
                }
            }
        }
        */
        
        public Pet GetData()
        {
            return mData;
        }
        
        public void Destroy()
        {
            GameObject.DestroyImmediate(mUI.gameObject, true);
            mUI = null;
            mData = null;
        }
    }
}