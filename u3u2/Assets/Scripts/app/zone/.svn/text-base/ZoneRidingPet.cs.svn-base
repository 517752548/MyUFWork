using UnityEngine;
using UnityEngine.Events;
using app.avatar;
using app.utils;
using app.model;
using app.db;

namespace app.zone
{
	public class ZoneRidingPet : AvatarBase
	{
		public PetTemplate tpl { get; private set; }
		public Transform back { get; private set; }
		private UnityAction mOnDisplayModelCreated = null;

		public ZoneRidingPet(UnityAction onDisplayModelCreated)
		{
			mOnDisplayModelCreated = onDisplayModelCreated;
		}

		public void Init(PetTemplate tpl, bool showShadow = true)
		{
			this.tpl = tpl;
			base.Init(tpl.modelId, showShadow);
		}

		public void Init(PetTemplate tpl, Vector3 pos, Vector3 rot, Transform parent, bool showShadow = true)
		{
			this.tpl = tpl;
			base.Init(tpl.modelId, pos, rot, parent, showShadow);
		}
		
		public override void InitDisplayModel(RMetaEvent e)
		{
			if (isDestroied)
			{
				return;
			}
			
			base.InitDisplayModel(e);

			back = GameObjectUtil.GetTransformByName(displayModel.avatar, "p_back");
			if (mOnDisplayModelCreated != null)
			{
				mOnDisplayModelCreated();
			}
			
			if (displayModel != null && displayModel.avatar != null)
			{
				BoxCollider bc = displayModel.avatar.GetComponent<BoxCollider>();
				if (bc != null)
				{
					bc.enabled =false;
				}
			}
		}
		
		public override string[] GetDisplayModelPath()
        {
            return PathUtil.Ins.GetCharacterDisplayModelPath(this.displayModelId);
        }

        public override int GetLayer()
        {
            return SceneModel.ins.zoneModelContainer.layer;
        }
		
		public override void Destroy()
		{
			if (displayModel != null && displayModel.avatar != null)
			{
				BoxCollider bc = displayModel.avatar.GetComponent<BoxCollider>();
				if (bc != null)
				{
					bc.enabled = true;
				}
			}
			base.Destroy();
		}
	}
}