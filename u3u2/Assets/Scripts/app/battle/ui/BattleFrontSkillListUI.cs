using UnityEngine;
using UnityEngine.Events;
using app.net;
using app.pet;
using app.db;

namespace app.battle
{
    public class BattleFrontSkillListUI
    {
        public BattleFrontSkillListUIBehav UI = null;
        private UnityAction<PetSkillInfo> mOnSkillSelected = null;
        private PetSkillInfo[] mSkillInfos = new PetSkillInfo[5];
        private bool mIsShown = false;

        public BattleFrontSkillListUI(BattleFrontSkillListUIBehav ui, UnityAction<PetSkillInfo> onSkillSelected)
        {
            UI = ui;
            mOnSkillSelected = onSkillSelected;
            for (int i = 0; i < 5; i++)
            {
                ui.btns[i].SetClickCallBack(OnBtnClicked);
            }
            mIsShown = true;
        }

        private void OnBtnClicked(GameObject target)
        {
            string name = target.name;
            int idx = int.Parse(name) - 1;
            if (mOnSkillSelected != null)
            {
                mOnSkillSelected(mSkillInfos[idx]);
            }
        }

        public void SetData(Pet pet)
        {
            for (int i = 0; i < 5; i++)
            {
                mSkillInfos[i] = null;
                UI.icons[i].sprite = null;
                UI.icons[i].enabled = false;
            }
            
            if (pet != null && pet.PetInfo != null)
            {
                int len = pet.PetInfo.shortcutList.Length;
                for (int i = 0; i < len; i++)
                {
                    PetSkillShortcutInfo shortcutInfo = pet.PetInfo.shortcutList[i];
                    if (shortcutInfo.shortcutIndex >= 0 && shortcutInfo.shortcutIndex < 5)
                    {
                        mSkillInfos[shortcutInfo.shortcutIndex] = pet.GetSkillInfo(shortcutInfo.skillId);
                        SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(shortcutInfo.skillId);
                        UI.icons[shortcutInfo.shortcutIndex].enabled = true;
                        PathUtil.Ins.SetSkillIcon(UI.icons[shortcutInfo.shortcutIndex], skillTpl.icon + "-1");
                    }
                }
            }
        }

        public void Show()
        {
            if (!mIsShown)
            {
                UI.gameObject.SetActive(true);
                mIsShown = true;
            }
        }

        public void Hide()
        {
            if (mIsShown)
            {
                UI.gameObject.SetActive(false);
                mIsShown = false;
            }
        }
    }
}