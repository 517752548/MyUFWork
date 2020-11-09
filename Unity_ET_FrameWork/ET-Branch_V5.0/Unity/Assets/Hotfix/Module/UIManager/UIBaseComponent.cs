﻿using System;
using System.Net;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
	
	public class UIBaseComponent: Component
	{
		private GameObject account;
		private GameObject loginBtn;
		protected ReferenceCollector rc;

		public virtual void Init(GameObject obj)
		{
			this.GameObject = obj;
			rc = this.GetParent<UIBase>().GameObject.GetComponent<ReferenceCollector>();
			this.GetParent<UIBase>().OnOpenInvoke += this.OnOpen;
			this.GetParent<UIBase>().ReEnableInvoke += this.ReEnable;
			this.GetParent<UIBase>().HiddenInvoke += this.OnHidden;
			this.GetParent<UIBase>().OnCloseInvoke += this.OnClose;
			this.OnOpen();
		}

		public virtual void OnOpen()
		{
			
		}
		public virtual void ReEnable()
		{
			
		}
		public virtual void OnHidden()
		{
			
		}
		public virtual void OnClose()
		{
			
		}

		public void OnLogin()
		{
			LoginHelper.OnLoginAsync(this.account.GetComponent<InputField>().text).Coroutine();
		}
	}
}
