using UnityEngine;
using app.net;
using app.db;
using app.pet;
using app.utils;

namespace app.team
{
    public class TeamMemberListItem:BaseUI
    {
        private TeamMemberListItemUI mUI = null;

        private TeamMemberInfo mData = null;

        public TeamMemberListItem(TeamMemberListItemUI UI)
        {
            mUI = UI;
            ui = UI.gameObject;
            //mShowPos = ui.transform.localPosition;
            ignorePositionShow = true;
            if (mUI.applyBtn != null)
            {
                mUI.applyBtn.SetClickCallBack(OnApplyBtnClicked);
            }
            //initUILayer();
        }

        public void SetData(TeamMemberInfo data)
        {
            if (data != null)
            {
                if (mData == null || data == null || mData.tplId != data.tplId)
                {
                    if (data != null)
                    {
                        PetTemplate petTpl = PetTemplateDB.Instance.getTemplate(data.tplId);
                        if (petTpl != null)
                        {
                            if (data.isFriend==1)
                            {
                                AddAvatarModelToUI(Vector3.zero, new Vector3(5, 162, 358), Vector3.one,petTpl.modelId, mUI.modelContainer);
                            }
                            else
                            {
                                AddRoleModelToUI(Vector3.zero, Vector3.one, petTpl, mUI.modelContainer);
                            }
                            
                            ShowAvatarModel();
                            
                            if (PropertyUtil.IsLegalID(data.equipWeaponId))
                            {
                                EquipItemTemplate weaponTpl = ItemTemplateDB.Instance.getTempalte(data.equipWeaponId) as EquipItemTemplate;
                                if (weaponTpl != null)
                                {
                                    avatarBase.ShowWeapon(weaponTpl);
                                }
                            }
                        }
                    }
                }
                mUI.uuid = data.uuid;
                mUI.tplId = data.tplId;
                mUI.level = data.level;
            }
            else
            {
                mUI.uuid = 0;
                mUI.tplId = 0;
                mUI.level = 0;
                RemoveAvatarModel();
            }

            if (mUI.nameTxt != null)
            {
                mUI.nameTxt.text = (data == null ? "" : data.name);
            }

            if (mUI.lvTxt != null)
            {
                mUI.lvTxt.text = (data == null ? "" : "Lv " + data.level);
            }

            if (mUI.careerTxt != null)
            {
                mUI.careerTxt.text = (data == null ? "" : PetJobType.GetJobName(data.jobTypeId));
            }

            if (mUI.duizhang != null)
            {
                mUI.duizhang.SetActive(data == null ? false : data.isLeader != 0);
            }

            if (mUI.zhuzhan != null)
            {
                mUI.zhuzhan.SetActive(data == null ? false : data.isFriend != 0);
            }

            if (mUI.zanli != null)
            {
                mUI.zanli.SetActive(data == null ? false : data.status == 2);
            }

            if (mUI.haodi != null)
            {
                mUI.haodi.SetActive(data == null ? false : data.isFriend == 0);
            }

            if (mUI.one != null)
            {
                mUI.one.SetActive(data == null ? false : (data.isFriend == 0 && data.position == 1));
            }

            if (mUI.two != null)
            {
                mUI.two.SetActive(data == null ? false : (data.isFriend == 0 && data.position == 2));
            }

            if (mUI.three != null)
            {
                mUI.three.SetActive(data == null ? false : (data.isFriend == 0 && data.position == 3));
            }

            if (mUI.four != null)
            {
                mUI.four.SetActive(data == null ? false : (data.isFriend == 0 && data.position == 4));
            }

            if (mUI.five != null)
            {
                mUI.five.SetActive(data == null ? false : (data.isFriend == 0 && data.position == 5));
            }

            mData = data;
        }

        public TeamMemberInfo GetData()
        {
            return mData;
        }

        private void OnApplyBtnClicked()
        {
            TeamCGHandler.sendCGTeamApplyAgree(mData.uuid);
        }

        public void Show()
        {
            mUI.gameObject.SetActive(true);
        }

        public void Hide()
        {
            mUI.gameObject.SetActive(false);
        }
    }
}