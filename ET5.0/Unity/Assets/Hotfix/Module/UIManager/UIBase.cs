using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
	[ObjectSystem]
	public class UIBaseAwakeSystem : AwakeSystem<UIBase, string, GameObject>
	{
		public override void Awake(UIBase self, string name, GameObject gameObject)
		{
			self.Awake(name, gameObject);
		}
	}
	
	//[HideInHierarchy]
	public sealed class UIBase: Entity
	{
		public GameObject GameObject;
		public object[] paras = null;
		public string UIGuid;
		public Action OnOpenInvoke;
		public Action ReEnableInvoke;
		public Action HiddenInvoke;
		public Action OnCloseInvoke;
		public string Name { get; private set; }

		public Dictionary<string, UIBase> children = new Dictionary<string, UIBase>();
		
		public void Awake(string name, GameObject gameObject)
		{
			this.children.Clear();
			//gameObject.AddComponent<ComponentView>().Component = this;
			gameObject.layer = LayerMask.NameToLayer(LayerNames.UI);
			this.Name = name;
			this.GameObject = gameObject;
		}

		public void OnOpen()
		{
			OnOpenInvoke?.Invoke();
		}
		public void ReEnable()
		{
			ReEnableInvoke?.Invoke();
			GameObject.gameObject.SetActive(true);
		}
		/// <summary>
		/// ui被压栈
		/// </summary>
		public void Hidden()
		{
			HiddenInvoke?.Invoke();
			GameObject.gameObject.SetActive(false);
		}

		public void OnClose()
		{
			OnCloseInvoke?.Invoke();
			this.Dispose();
		}
		public override void Dispose()
		{
			this.OnOpenInvoke = null;
			this.OnCloseInvoke = null;
			this.HiddenInvoke = null;
			this.ReEnableInvoke = null;
			this.paras = null;
			if (this.IsDisposed)
			{
				return;
			}
			
			base.Dispose();

			foreach (UIBase ui in this.children.Values)
			{
				ui.Dispose();
			}
			
			UnityEngine.Object.Destroy(GameObject);
			children.Clear();
		}

		public void SetAsFirstSibling()
		{
			this.GameObject.transform.SetAsFirstSibling();
		}

		public void Add(UIBase ui)
		{
			this.children.Add(ui.Name, ui);
			ui.Parent = this;
		}

		public void Remove(string name)
		{
			UIBase ui;
			if (!this.children.TryGetValue(name, out ui))
			{
				return;
			}
			this.children.Remove(name);
			ui.Dispose();
		}

		public void CloseSelf()
		{
			Game.Scene.GetComponent<UIManagerComponent>().CloseUI(this);
		}
		public UIBase Get(string name)
		{
			UIBase child;
			if (this.children.TryGetValue(name, out child))
			{
				return child;
			}
			GameObject childGameObject = this.GameObject.transform.Find(name)?.gameObject;
			if (childGameObject == null)
			{
				return null;
			}
			child = ComponentFactory.Create<UIBase, string, GameObject>(name, childGameObject);
			this.Add(child);
			return child;
		}
	}
}