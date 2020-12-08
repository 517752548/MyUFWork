using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
	[ObjectSystem]
	public class UIManagerAwakeSystem: AwakeSystem<UIManagerComponent>
	{
		public override void Awake(UIManagerComponent self)
		{
			Transform globle = GameObject.Find("/Global").transform;
			self.Camera = globle.Find("UIManager/DefaultUI/UICamera").gameObject;
			self.GameUI = globle.Find("UIManager/DefaultUI/GameUI");
			self.Fixed = globle.Find("UIManager/DefaultUI/Fixed");
			self.Normal = globle.Find("UIManager/DefaultUI/Normal");
			self.TopBar = globle.Find("UIManager/DefaultUI/TopBar");
			self.PopUp = globle.Find("UIManager/DefaultUI/PopUp");
			self.GuideUI = globle.Find("UIManager/DefaultUI/GuideUi");
		}
	}
	/// <summary>
	/// 管理所有UI
	/// </summary>
	public class UIManagerComponent: Entity
	{
		public GameObject Camera;
		public Transform GameUI;
		public Transform Fixed;
		public Transform Normal;
		public Transform TopBar;
		public Transform PopUp;
		public Transform GuideUI;
		
		private Dictionary<UILayerNew,List<UIBase>> ui_base = new Dictionary<UILayerNew, List<UIBase>>();

		public async ETTask OpenUIAsync<T>(string UIName,UILayerNew layer = UILayerNew.Normal,UIOpenType openType = UIOpenType.Stack,params object[] objs) where T : UIBaseComponent, new()
		{
			await ETModel.Game.Scene.GetComponent<ResourcesComponent>().CacheBundleAsync(UIName);
			GameObject obj = (GameObject)ETModel.Game.Scene.GetComponent<ResourcesComponent>().GetAsset(UIName);
			UIBase c_ui = UIHelper.Create<T>(UIName, obj,objs);
			UIHelper.HandlerUI(c_ui,layer,openType,this.ui_base);
			c_ui.GetComponent<T>();
		}

		public void CloseUI(UIBase UIName)
		{
			UIHelper.CloseUI(UIName,ui_base);
		}
	}

	public enum UIOpenType
	{
		Stack,
		Replace
	}
	public enum UILayerNew
	{
		GameUI,
		Fixed,
		Normal,
		TopBar,
		PopUp,
		GuideUi
	}
}