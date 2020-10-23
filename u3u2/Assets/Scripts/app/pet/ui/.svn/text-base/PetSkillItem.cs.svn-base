using app.net;
using app.db;
using UnityEngine;
using app.utils;

namespace app.pet
{
    public delegate void ClickPetSkillItemHandler(object obj);

    public class PetSkillItem
    {
        public CommonItemUI UI;
        private PetSkillInfo mSkillInfo;
        private SkillTemplate mSkillTpl;
        //private string mIconPathStr;

        private ClickPetSkillItemHandler mClickPetSkillItemHandler;

        public PetSkillItem(CommonItemUI ui, ClickPetSkillItemHandler clickHandler = null)
        {
            UI = ui;
            mClickPetSkillItemHandler = clickHandler;
            if (clickHandler != null)
            {
                UI.ClickCommonItemHandler = onClick;
            }
        }

        public void setEmpty()
        {
            /*
            if (mIconPathStr != null && mSkillTpl!=null)
            {
                SourceManager.Ins.removeReference(mIconPathStr);
            }
            */
            mSkillInfo = null;
            mSkillTpl = null;
            //UI.icon.texture = null;
            UI.icon.sprite = null;
            UI.icon.gameObject.SetActive(false);
            if(UI.biangkuang!=null)UI.biangkuang.gameObject.SetActive(false);
            //UI.num.text = "";
            //UI.num.gameObject.SetActive(false);
            //UI.Name.text = "";
            //UI.Name.gameObject.SetActive(false);
        }

        public void SetData(PetSkillInfo skillInfo)
        {
            mSkillInfo = skillInfo;
            mSkillTpl = SkillTemplateDB.Instance.getTemplate(skillInfo.skillId);
            //UI.Name.gameObject.SetActive(true);
            //UI.Name.text = mSkillTpl.name;
            if (UI.biangkuang != null) UI.biangkuang.gameObject.SetActive(false);
            /*
            UI.icon.gameObject.SetActive(false);
            mIconPathStr = PathUtil.Ins.GetUITexturePath(mSkillTpl.icon, PathUtil.TEXTUER_SKILL);
            SourceLoader.Ins.load(mIconPathStr, loadCompleteHandler);
            */
            PathUtil.Ins.SetSkillIcon(UI.icon, mSkillTpl.icon);
        }

        public void SetData(SkillTemplate skilltpl)
        {
            mSkillInfo = null;
            mSkillTpl = skilltpl;
            //UI.Name.gameObject.SetActive(true);
            //UI.Name.text = mSkillTpl.name;
            if (UI.biangkuang != null) UI.biangkuang.gameObject.SetActive(false);
            /*
            UI.icon.gameObject.SetActive(false);
            mIconPathStr = PathUtil.Ins.GetUITexturePath(mSkillTpl.icon, PathUtil.TEXTUER_SKILL);
            SourceLoader.Ins.load(mIconPathStr, loadCompleteHandler);
            */
            PathUtil.Ins.SetSkillIcon(UI.icon, mSkillTpl.icon);
        }

        public void SetGray(bool isgray)
        {
            if (isgray)
            {
                ColorUtil.Gray(UI.icon);
            }
            else
            {
                ColorUtil.DeGray(UI.icon);
            }
        }

        public PetSkillInfo GetData()
        {
            return mSkillInfo;
        }

        public SkillTemplate GetTplData()
        {
            return mSkillTpl;
        }

        public void onClick()
        {
            //调用点击的处理
            if (mClickPetSkillItemHandler != null )
            {
                if (mSkillInfo != null)
                {
                    mClickPetSkillItemHandler(mSkillInfo);
                }
                else if(mSkillTpl!=null)
                {
                    mClickPetSkillItemHandler(mSkillTpl);
                }
            }
        }
        /*
        private void loadCompleteHandler(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                Texture t = SourceManager.Ins.GetAsset<Texture>(mIconPathStr);
                if (t != null)
                {
                    UI.icon.gameObject.SetActive(true);
                    UI.icon.texture = t;
                }

            }

        }
        */

        public void Destroy()
        {
           GameObject.DestroyImmediate(UI.gameObject);
           UI = null;
           mSkillInfo = null;
           mSkillTpl = null; ;
        }
    }
}

