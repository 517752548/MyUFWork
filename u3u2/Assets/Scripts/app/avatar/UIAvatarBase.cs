using UnityEngine;
using app.db;
using app.pet;
using app.role;
using app.utils;

namespace app.avatar
{
    public class UIAvatarBase : AvatarBase
    {
        private BaseUI mUI = null;
        private PetTemplate mTpl = null;
        private Pet mPet = null;
        private string mDisplayModelId = null;
        private Vector3 mPos = Vector3.zero;
        private Vector3 mRot = Vector3.zero;
        private Vector3 mScale = Vector3.one;
        private Transform mParent = null;

        private EquipItemTemplate mWeaponTpl;

        private float mAvatarPlayIdleTime = 0;
        private bool mAvatarTouched = false;
        private float mAvatarTouchPosX = 0;
        private float mAvatarTouchRotY = 0;
        private bool mShowVariatedSkin = false;

        public UIAvatarBase(BaseUI ui)
        {
            mUI = ui;
        }

        public void Init(string displayModelId, Vector3 pos, Vector3 rot, Vector3 scale, Transform parent,EquipItemTemplate weaponTpl,bool showShadow = true, bool showVariatedSkin = false)
        {
            mTpl = null;
            mPet = null;
            mWeaponTpl = weaponTpl;
            mShowVariatedSkin = showVariatedSkin;
            Show(displayModelId, pos, rot, scale, parent, showShadow);
        }

        public void Init(Pet pet, Vector3 pos, Vector3 rot, Vector3 scale, Transform parent, EquipItemTemplate weaponTpl = null,bool showShadow = true)
        {
            mTpl = null;
            mPet = pet;
            mShowVariatedSkin = (mPet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GENE_TYPE) == 1) && (mPet.getTpl().petpetTypeId != 2);
            mWeaponTpl = weaponTpl;
            Show(pet.getTpl().modelId, pos, rot, scale, parent, showShadow);
        }

        public void Init(PetTemplate tpl, Vector3 pos, Vector3 rot, Vector3 scale, Transform parent, EquipItemTemplate weaponTpl = null, bool showShadow = true, bool showVariatedSkin = false)
        {
            mTpl = tpl;
            mPet = null;
            mShowVariatedSkin = showVariatedSkin;
            mWeaponTpl = weaponTpl;
            Show(tpl.modelId, pos, rot, scale, parent, showShadow);
        }

        private void Show(string displayModelId, Vector3 pos, Vector3 rot, Vector3 scale, Transform parent, bool showShadow)
        {
            mPos = pos;
            mRot = rot;
            mScale = scale;
            mParent = parent;
            mAvatarTouched = false;
            mAvatarTouchPosX = 0;
            mAvatarTouchRotY = 0;
            if (mDisplayModelId != displayModelId)
            {
                mDisplayModelId = displayModelId;
                //base.Init(displayModelId, showShadow);
                base.Init(displayModelId, mPos, getAvatarRotation(), mParent, showShadow);
            }
            else
            {
                if (!mUI.isShown)
                {
                    SetActive(false);
                }
                else
                {
                    SetActive(true);
                }
                setVariationColor();
            }
        }

        public override int GetLayer()
        {
            return mParent.gameObject.layer;
        }

        public override void InitDisplayModel(RMetaEvent e)
        {
            if (isDestroied)
            {
                return;
            }
            base.InitDisplayModel(e);

            if (displayModel != null && displayModel.avatar != null)
            {
                /*
                displayModel.avatar.transform.SetParent(mParent);
                GameObjectUtil.SetLayer(displayModel.avatar, mParent.gameObject.layer);
                displayModel.avatar.transform.localPosition = mPos;
                displayModel.avatar.transform.localEulerAngles = getAvatarRotation();
                */
                displayModel.avatar.transform.localScale = mScale * getAvatarScaleRate();
            }

            setVariationColor();
            PlayAnimation(AvatarBase.ANIM_NAME_IDLE);
            mAvatarPlayIdleTime = Time.time;

            if (!mUI.isShown)
            {
                SetActive(false);
            }
            else
            {
                SetActive(true);
            }

            if (mWeaponTpl != null)
            {
                ShowWeapon(mWeaponTpl);
            }
        }

        private Vector3 getAvatarRotation()
        {
            if (mTpl != null)
            {
                return PetDef.GetRoleModelRotation(mTpl.Id);
            }
            else
            {
                return mRot;
            }
        }

        private float getAvatarScaleRate()
        {
            if (mTpl != null)
            {
                if (string.IsNullOrEmpty(mTpl.modelScale))
                {
                    return 1.0f;
                }
                return float.Parse(mTpl.modelScale);
            }
            else if (mPet != null)
            {
                if (string.IsNullOrEmpty(mPet.getTpl().modelScale))
                {
                    return 1.0f;
                }
                return float.Parse(mPet.getTpl().modelScale);
            }
            return 1.0f;
        }

        private void setVariationColor()
        {
            if (mShowVariatedSkin)
            {
                if (displayModel != null)
                {
                    displayModel.SetIsVariant(true);
                }
            }
            else
            {
                if (displayModel != null)
                {
                    displayModel.SetIsVariant(false);
                }
            }
        }

        public override string[] GetDisplayModelPath()
        {
            return PathUtil.Ins.GetCharacterDisplayModelPath(this.displayModelId);
        }

        public override bool Update()
        {
            if (base.Update() )
            {
                if (mUI.avatarPlayAnim)
                {
                    if (displayModel != null && displayModel.avatar != null && displayModelId == mDisplayModelId)
                    {
                        if (curAnimName == AvatarBase.ANIM_NAME_IDLE)
                        {
                            if (Time.time - mAvatarPlayIdleTime >= 5)
                            {
                                if (HasAnimation(AvatarBase.ANIM_NAME_ATTACK))
                                {
                                    PlayAnimation(AvatarBase.ANIM_NAME_ATTACK);
                                }
                            }
                        }
                        else if (curAnimName == AvatarBase.ANIM_NAME_ATTACK && mAnim != null &&
                                 mAnim[AvatarBase.ANIM_NAME_ATTACK] != null)
                        {
                            if (mAnim[AvatarBase.ANIM_NAME_ATTACK].time >= mAnim[AvatarBase.ANIM_NAME_ATTACK].length)
                            {
                                PlayAnimation(AvatarBase.ANIM_NAME_IDLE);
                                mAvatarPlayIdleTime = Time.time;
                            }
                        }
                    }
                }
                if (mUI.avatarRotatable)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Vector3 mScreenPos = Input.mousePosition;
                        Camera cam = mUI.GetMyLayerCamera();
                        Ray mRay = cam.ScreenPointToRay(mScreenPos);
                        RaycastHit[] mHits;
                        mHits = Physics.RaycastAll(mRay);
                        int len = mHits.Length;
                        for (int i = 0; i < len; i++)
                        {
                            RaycastHit mHit = mHits[i];
                            GameObject hitGameObj = mHit.transform.gameObject;
                            if (hitGameObj == displayModel.avatar)
                            {
                                mAvatarTouched = true;
                                mAvatarTouchPosX = Input.mousePosition.x;
                                mAvatarTouchRotY = displayModel.avatar.transform.localEulerAngles.y;
                                break;
                            }
                        }
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        if (mAvatarTouched)
                        {
                            mAvatarTouched = false;
                        }
                    }

                    if (mAvatarTouched)
                    {
                        displayModel.avatar.transform.localEulerAngles = new Vector3(0,
                            mAvatarTouchRotY + (mAvatarTouchPosX - Input.mousePosition.x), 0);
                    }
                }
                return true;
            }
            return false;
        }

        public void ResetRot()
        {
            if (displayModel != null && displayModel.avatar != null)
            {
                displayModel.avatar.transform.localEulerAngles = getAvatarRotation();
            }
        }

        public bool IsAvatarRotating()
        {
            return mAvatarTouched;
        }

        public override void Destroy()
        {
            mUI = null;
            mTpl = null;
            mPet = null;
            mDisplayModelId = null;
            mPos = Vector3.zero;
            mRot = Vector3.zero;
            mScale = Vector3.one;
            mParent = null;

            mAvatarPlayIdleTime = 0;
            mAvatarTouched = false;
            mAvatarTouchPosX = 0;
            mAvatarTouchRotY = 0;
            base.Destroy();
        }
    }
}