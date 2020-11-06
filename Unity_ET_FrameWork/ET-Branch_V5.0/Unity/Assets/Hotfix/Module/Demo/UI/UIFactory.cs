using System;
using ETModel;
using Hotfix;
using UnityEngine;

namespace ETHotfix
{
    public static class UIFactory
    {
        public async static ETTask<UI> Create()
        {
	        try
	        {
				ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
				GameObject bundleGameObject = await resourcesComponent.LoadBundleAsync<GameObject>(ViewConst.prefab_UIJLogin);
				 GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);
		         UI ui = ComponentFactory.Create<UI, string, GameObject>(UIType.UILobby, gameObject, false);
				 ui.AddComponent<JLoginCompoent>();
				 return ui;
	        }
	        catch (Exception e)
	        {
				Log.Error(e);
		        return null;
	        }
		}
    }
}