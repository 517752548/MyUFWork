using UnityEngine;
using app.utils;
using app.db;

namespace app.avatar
{
    public class AvatarWeapon : AvatarBase
    {
        public enum WeaponPos
        {
            L,
            R
        }
        public EquipItemTemplate tpl { get; private set; }
        private AvatarBase mHost = null;
        private WeaponPos mPos = 0;
        
        private Vector3 mOrgScale;
        public void Init(EquipItemTemplate tpl, AvatarBase host, WeaponPos pos)
        {
            this.tpl = tpl;
            mHost = host;
            mPos = pos;
            if (mPos == WeaponPos.L)
            {
                base.Init(tpl.leftModel, false);
            }
            else if (mPos == WeaponPos.R)
            {
                base.Init(tpl.rightModel, false);   
            }
        }

        public override void InitDisplayModel(RMetaEvent e)
        {
            if (isDestroied)
            {
                return;
            }

            base.InitDisplayModel(e);

            if (mHost != null && !mHost.isDestroied)
            {
                BindToHost();
            }
            else
            {
                Destroy();
            }
        }

        public override string[] GetDisplayModelPath()
        {
            return new string[] { PathUtil.Ins.GetWeaponPath(this.displayModelId) };
        }

        private void BindToHost()
        {
            if (displayModel == null)
            {
                ClientLog.LogError("武器绑定失败, 武器的displayModel为空。武器模型：" + displayModelId);
                Destroy();
                return;
            }

            if (displayModel.avatar == null)
            {
                ClientLog.LogError("武器绑定失败, 武器的displayModel.avatar为空。武器模型：" + displayModelId);
                Destroy();
                return;
            }
            
            mOrgScale = displayModel.avatar.transform.localScale;

            if (mHost == null)
            {
                ClientLog.LogError("武器绑定失败, 角色为空。武器模型：" + displayModelId);
                Destroy();
                return;
            }

            if (mHost.displayModel == null)
            {
                ClientLog.LogError("武器绑定失败, 角色的武器的displayModel为空。武器模型：" + displayModelId + " 角色模型为：" + mHost.displayModelId);
                Destroy();
                return;
            }

            if (mHost.displayModel.avatar == null)
            {
                ClientLog.LogError("武器绑定失败, 角色的武器的displayModel.avatar为空。武器模型：" + displayModelId + " 角色模型为：" + mHost.displayModelId);
                Destroy();
                return;
            }
            /*
            displayModel.avatar.transform.eulerAngles = displayModel.avatar.transform.eulerAngles + mHost.displayModel.avatar.transform.eulerAngles;
            Transform avatarBack = GameObjectUtil.GetTransformByName(mHost.displayModel.avatar, "h_back");
            if (avatarBack == null)
            {
                ClientLog.LogError("武器绑定失败, 没有找到武器绑点。武器模型：" + displayModelId + " 角色模型为：" + mHost.displayModelId);
                Destroy();
                return;
            }
            */

            Transform bindPoint = null;
            string bindPointName = null;

            if (mPos == WeaponPos.L)
            {
                bindPointName = "h_hand_l";
            }
            else if (mPos == WeaponPos.R)
            {
                bindPointName = "h_hand_r";
            }

            bindPoint = GameObjectUtil.GetTransformByName(mHost.displayModel.avatar, bindPointName);

            if (bindPoint == null)
            {
                ClientLog.LogError("武器绑定失败, 没有找到武器绑点:" + bindPointName + "。武器模型：" + displayModelId + " 角色模型为：" + mHost.displayModelId);
                //GameObjectUtil.Bind(displayModel.avatar.transform, mHost.displayModel.avatar.transform, true, true);
                Destroy();
                return;
            }
            else
            {
                GameObjectUtil.Bind(displayModel.avatar.transform, bindPoint, true, true);
                GameObjectUtil.SetLayer(displayModel.avatar, mHost.displayModel.avatar.layer);
                displayModel.avatar.transform.localScale = Vector3.Scale(mHost.displayModel.avatar.transform.localScale, mOrgScale);
                displayModel.avatar.SetActive(true);
                SetIsHalfOpaque(mHost.isHalfOpaque);
            }
        }

        public override void Destroy()
        {
            //mHost.Destroy();
            if (displayModel != null && displayModel.avatar != null)
            {
                displayModel.avatar.transform.localScale = mOrgScale;
            }
            base.Destroy();
            mHost = null;
        }
    }
}