﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
	public class UIManagerAwakeSystem: AwakeSystem<UIManagerComponent>
	{
		public override void Awake(UIManagerComponent self)
		{
			self.Camera = Entity.Global.transform.Find("UIManager/DefaultUI/UICamera").gameObject;
			self.GameUI = Entity.Global.transform.Find("UIManager/DefaultUI/GameUI");
			self.Fixed = Entity.Global.transform.Find("UIManager/DefaultUI/Fixed");
			self.Normal = Entity.Global.transform.Find("UIManager/DefaultUI/Normal");
			self.TopBar = Entity.Global.transform.Find("UIManager/DefaultUI/TopBar");
			self.PopUp = Entity.Global.transform.Find("UIManager/DefaultUI/PopUp");
			self.GuideUI = Entity.Global.transform.Find("UIManager/DefaultUI/GuideUi");
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

		public async ETTask<T> OpenUIAsync<T>(string UIName,UILayerNew layer = UILayerNew.Normal,UIOpenType openType = UIOpenType.Stack,params object[] objs) where T : UIBaseComponent, new()
		{
			GameObject obj =(GameObject) await Game.Scene.GetComponent<ResourcesComponent>().LoadBundleAsync<GameObject>(UIName);
			UIBase c_ui = UIHelper.Create<T>(UIName, obj,objs);
			UIHelper.HandlerUI(c_ui,layer,openType,this.ui_base);
			return c_ui.GetComponent<T>();
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