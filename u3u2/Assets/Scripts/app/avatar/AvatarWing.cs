using UnityEngine;
using app.utils;
using app.db;

namespace app.avatar
{
    public class AvatarWing : AvatarBase
    {
        public WingTemplate tpl { get; private set; }
        private AvatarBase mHost = null;
        private Vector3 mOrgScale;

        public void Init(WingTemplate tpl, AvatarBase host)
        {
            this.tpl = tpl;
            mHost = host;
            base.Init(tpl.modelId, false);
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
                BoxCollider bc = displayModel.avatar.GetComponent<BoxCollider>();
                if (bc != null)
                {
                    bc.enabled = false;
                }
            }
            
            if (mHost != null && !mHost.isDestroied && mHost.isEnableWing)
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
            return PathUtil.Ins.GetWingPath(this.displayModelId);
        }
        
        private void BindToHost()
        {
            if (displayModel == null)
            {
                ClientLog.LogError("翅膀绑定失败, 翅膀的displayModel为空。翅膀模型：" + displayModelId);
                Destroy();
                return;
            }
            
            if (displayModel.avatar == null)
            {
                ClientLog.LogError("翅膀绑定失败, 翅膀的displayModel.avatar为空。翅膀模型：" + displayModelId);
                Destroy();
                return;
            }

            mOrgScale = displayModel.avatar.transform.localScale;
            
            if (mHost == null)
            {
                ClientLog.LogError("翅膀绑定失败, 角色为空。翅膀模型：" + displayModelId);
                Destroy();
                return;
            }
            
            if (mHost.displayModel == null)
            {
                ClientLog.LogError("翅膀绑定失败, 角色的翅膀的displayModel为空。翅膀模型：" + displayModelId + " 角色模型为：" + mHost.displayModelId);
                Destroy();
                return;
            }
            
            if (mHost.displayModel.avatar == null)
            {
                ClientLog.LogError("翅膀绑定失败, 角色的翅膀的displayModel.avatar为空。翅膀模型：" + displayModelId + " 角色模型为：" + mHost.displayModelId);
                Destroy();
                return;
            }
            
            //displayModel.avatar.transform.eulerAngles = displayModel.avatar.transform.eulerAngles + mHost.displayModel.avatar.transform.eulerAngles;
            Transform avatarBack = GameObjectUtil.GetTransformByName(mHost.displayModel.avatar, "h_back");
            if (avatarBack == null)
            {
                ClientLog.LogError("翅膀绑定失败, 角色角色背部没有绑点。翅膀模型：" + displayModelId + " 角色模型为：" + mHost.displayModelId);
                Destroy();
                return;
            }
            GameObjectUtil.Bind(displayModel.avatar.transform, avatarBack, true, true);
            GameObjectUtil.SetLayer(displayModel.avatar, mHost.displayModel.avatar.layer);
            displayModel.avatar.transform.localScale = Vector3.Scale(mHost.displayModel.avatar.transform.localScale, mOrgScale);
            displayModel.avatar.SetActive(true);
            SetIsHalfOpaque(mHost.isHalfOpaque);
        }

        public override void Destroy()
        {
            //mHost.Destroy();
            if (displayModel != null && displayModel.avatar != null)
            {
                displayModel.avatar.transform.localScale = mOrgScale;
            }
            base.Destroy();
            tpl = null;
            mHost = null;
        }
    }
}