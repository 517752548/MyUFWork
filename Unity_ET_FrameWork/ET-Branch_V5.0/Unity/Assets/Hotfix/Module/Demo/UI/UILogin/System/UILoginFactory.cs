﻿using System;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    public static class UILoginFactory
    {
        public static UI Create()
        {
	        try
	        {
		        Log.Info("创建loginui");
				// ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
				// resourcesComponent.LoadBundle(UIType.UILogin.StringToAB());
				// GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(UIType.UILogin.StringToAB(), UIType.UILogin);
				// GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);
		  //
		  //       UI ui = ComponentFactory.Create<UI, string, GameObject>(UIType.UILogin, gameObject, false);
		  //
				// ui.AddComponent<UILoginComponent>();
				// return ui;
				return null;
	        }
	        catch (Exception e)
	        {
				Log.Error(e);
		        return null;
	        }
		}
    }
}