using app.db;
using app.role;
using UnityEngine;

namespace app.pet
{
    /// <summary>
    /// 点击的委托
    /// </summary>
    /// <param name="itemGo">点击的实例对象</param>
    public delegate void ClickPetItemHandler(Pet itemData);

    public class PetItem
    {
        public CommonItemUI UI;
        public Pet itemData;
        public PetTemplate tplData;
        private ClickPetItemHandler clickPetItemHandler;

        /// <summary>
        /// 按钮按下的时候的放大倍数
        /// </summary>
        private float pressedScale = 0.8f;

        //private string mIconPath = null;

        public PetItem(CommonItemUI ui, ClickPetItemHandler clickHandler = null)
        {
            UI = ui;
            clickPetItemHandler = clickHandler;
            if (clickHandler != null)
            {
                EventTriggerListener.Get(ui.gameObject).onClick = onClick;
            }
        }

        private void onClick(GameObject go)
        {
            //调用点击的处理
            if (clickPetItemHandler != null && itemData != null)
            {
                clickPetItemHandler(itemData);
            }
        }

        public void setData(Pet data)
        {
			tplData=null;
            UI.gameObject.SetActive(true);
            UI.icon.gameObject.SetActive(true);
            //UI.biangkuang.gameObject.SetActive(true);
            //UI.num.gameObject.SetActive(true);
            itemData = data;
            //UI.num.text = "";
            //UI.Name.text = data.getName();
            PathUtil.Ins.SetHeadIcon(UI.icon, itemData.getTpl().modelId);
            
            /*
            int colorid = itemData.PropertyManager.getPetIntProp(RoleBaseIntProperties.COLOR);
            if (colorid > 0)
            {
                //string biankuangStr = PathUtil.Ins.GetUITexturePath(colorid.ToString(), PathUtil.ITEM_BIANKUANG);
                Texture2D t = SourceManager.Ins.GetBiankuang(colorid);
                if (t != null)
                {
                    UI.biangkuang.texture = t;
                    UI.biangkuang.gameObject.SetActive(true);
                }
                else
                {
                    UI.biangkuang.gameObject.SetActive(false);
                }
            }
            else
            {
                UI.biangkuang.gameObject.SetActive(false);
            }
            */
            /*
            string iconPathStr = PathUtil.Ins.GetUITexturePath(itemData.getTpl().modelId, PathUtil.TEXTUER_HEAD);
            if (mIconPath != iconPathStr)
            {
                mIconPath = iconPathStr;
                SourceLoader.Ins.load(iconPathStr, loadCompleteHandler, null);
            }
            */
        }

        public void setTplData(PetTemplate data)
        {
			itemData=null;
            UI.gameObject.SetActive(true);
            UI.icon.gameObject.SetActive(true);
            //UI.biangkuang.gameObject.SetActive(true);
            //UI.num.gameObject.SetActive(true);
            tplData = data;
            //UI.num.text = "";
            //UI.Name.text = data.getName();
            PathUtil.Ins.SetHeadIcon(UI.icon, tplData.modelId);

            /*
            int colorid = itemData.PropertyManager.getPetIntProp(RoleBaseIntProperties.COLOR);
            if (colorid > 0)
            {
                //string biankuangStr = PathUtil.Ins.GetUITexturePath(colorid.ToString(), PathUtil.ITEM_BIANKUANG);
                Texture2D t = SourceManager.Ins.GetBiankuang(colorid);
                if (t != null)
                {
                    UI.biangkuang.texture = t;
                    UI.biangkuang.gameObject.SetActive(true);
                }
                else
                {
                    UI.biangkuang.gameObject.SetActive(false);
                }
            }
            else
            {
                UI.biangkuang.gameObject.SetActive(false);
            }
            */
            /*
            string iconPathStr = PathUtil.Ins.GetUITexturePath(tplData.modelId, PathUtil.TEXTUER_HEAD);
            if (mIconPath != iconPathStr)
            {
                mIconPath = iconPathStr;
                SourceLoader.Ins.load(iconPathStr, loadCompleteHandler, null);
            }
            */
        }


        public void setEmpty()
        {
            UI.icon.gameObject.SetActive(false);
            //UI.biangkuang.gameObject.SetActive(false);
            //UI.num.gameObject.SetActive(false);
        }
        
        /*

        private void loadCompleteHandler(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                string iconPath = ((LoadInfo)(e.data)).urlPath;
                if (iconPath == mIconPath)
                {
                    UI.icon.texture = SourceManager.Ins.GetAsset<Texture>(
                        PathUtil.Ins.GetUITexturePath(itemData.getTpl().modelId, PathUtil.TEXTUER_HEAD)
                    );
                }

            }

        }
        */

        public void Dispose()
        {
            /*
            if (itemData != null)
            {
                SourceManager.Ins.removeReference(PathUtil.Ins.GetUITexturePath(itemData.getTpl().modelId, PathUtil.TEXTUER_HEAD));
            }
            */
            itemData = null;
            UI.icon.sprite = null;
            UI.icon.gameObject.SetActive(false);
            UI.gameObject.SetActive(false);
        }
    }
}