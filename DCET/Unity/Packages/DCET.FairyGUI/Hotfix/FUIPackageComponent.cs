using FairyGUI;
using System.Collections.Generic;
using DCETRuntime;
using UnityEngine;
using System.Threading.Tasks;

namespace DCET
{
	/// <summary>
	/// 管理所有UI Package
	/// </summary>
	public class FUIPackageComponent : Entity
    {
        public const string FUI_PACKAGE_DIR = "Assets/Bundles/FUI";

        private readonly Dictionary<string, UIPackage> packages = new Dictionary<string, UIPackage>();
		
		
		public void AddPackage(string type)
		{
			if (Define.IsEditorMode)
			{
				UIPackage uiPackage = UIPackage.AddPackage($"{FUI_PACKAGE_DIR}/{type}");
				packages.Add(type, uiPackage);
			}
			else
			{
				string uiBundleDesName = AssetBundleHelper.StringToAB($"{type}_fui");
				string uiBundleResName = AssetBundleHelper.StringToAB(type);
				ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
				resourcesComponent.LoadBundle(uiBundleDesName);
				resourcesComponent.LoadBundle(uiBundleResName);

				AssetBundle desAssetBundle = resourcesComponent.GetAssetBundle(uiBundleDesName);
				AssetBundle resAssetBundle = resourcesComponent.GetAssetBundle(uiBundleResName);
				UIPackage uiPackage = UIPackage.AddPackage(desAssetBundle, resAssetBundle);
				packages.Add(type, uiPackage);
			}
		}
        
		public async Task AddPackageAsync(string type)
		{
			if (Define.IsEditorMode)
			{
				await Task.CompletedTask;

				UIPackage uiPackage = UIPackage.AddPackage($"{FUI_PACKAGE_DIR}/{type}");

				packages.Add(type, uiPackage);
			}
			else
			{
				string uiBundleDesName = AssetBundleHelper.StringToAB($"{type}_fui");
				string uiBundleResName = AssetBundleHelper.StringToAB(type);
				ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
				await resourcesComponent.LoadBundleAsync(uiBundleDesName);
				await resourcesComponent.LoadBundleAsync(uiBundleResName);

				AssetBundle desAssetBundle = resourcesComponent.GetAssetBundle(uiBundleDesName);
				AssetBundle resAssetBundle = resourcesComponent.GetAssetBundle(uiBundleResName);
				UIPackage uiPackage = UIPackage.AddPackage(desAssetBundle, resAssetBundle);

				packages.Add(type, uiPackage);
			}
		}

		public void RemovePackage(string type)
		{
            UIPackage package;

            if(packages.TryGetValue(type, out package))
            {
                var p = UIPackage.GetByName(package.name);

                if (p != null)
                {
                    UIPackage.RemovePackage(package.name);
                }

                packages.Remove(package.name);
            }

			if (!Define.IsEditorMode)
			{
				string uiBundleDesName = AssetBundleHelper.StringToAB($"{type}_fui");
				string uiBundleResName = AssetBundleHelper.StringToAB(type);
				Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle(uiBundleDesName);
				Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle(uiBundleResName);
			}
		}
	}
}