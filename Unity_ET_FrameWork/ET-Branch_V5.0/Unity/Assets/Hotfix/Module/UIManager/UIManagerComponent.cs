using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
	[ObjectSystem]
	public class UIManagerComponentAwakeSystem : AwakeSystem<UIManagerComponent>
	{
		public override void Awake(UIManagerComponent self)
		{
			GameObject defaultUI = Component.Global.transform.Find("UIManager/DefaultUI").gameObject;
			self.Camera = defaultUI.transform.Find("UICamera").gameObject;
			self.GameUI = defaultUI.transform.Find("GameUI");
			self.Fixed = defaultUI.transform.Find("Fixed");
			self.Normal = defaultUI.transform.Find("Normal");
			self.TopBar = defaultUI.transform.Find("TopBar");
			self.PopUp = defaultUI.transform.Find("PopUp");
			self.GuideUI = defaultUI.transform.Find("GuideUi");
		}
	}
	
	/// <summary>
	/// 管理所有UI
	/// </summary>
	public class UIManagerComponent: Component
	{
		public GameObject Camera;
		public Transform GameUI;
		public Transform Fixed;
		public Transform Normal;
		public Transform TopBar;
		public Transform PopUp;
		public Transform GuideUI;
		
		private Dictionary<UILayer,List<UIBase>> ui_base = new Dictionary<UILayer, List<UIBase>>();

		public async ETTask OpenUIAsync<T>(string UIName,UILayer layer = UILayer.Normal,UIOpenType openType = UIOpenType.Stack) where T : UIBaseComponent, new()
		{
			GameObject obj =(GameObject) await ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadBundleAsync(UIName);
			UIBase c_ui = UIHelper.Create<T>(UIName, obj);
			UIHelper.HandlerUI(c_ui,layer,openType,this.ui_base);
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
	public enum UILayer
	{
		GameUI,
		Fixed,
		Normal,
		TopBar,
		PopUp,
		GuideUi
	}
}