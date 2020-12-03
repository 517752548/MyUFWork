using DCETRuntime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DCET
{
	public static class DependenciesHelper
	{
		// 缓存包依赖，不用每次计算
		public static Dictionary<string, string[]> DependenciesCache = new Dictionary<string, string[]>();

		public static string[] GetDependencies(string assetBundleName)
		{
			string[] dependencies;

			if (DependenciesCache.TryGetValue(assetBundleName, out dependencies))
			{
				return dependencies;
			}

			if (Define.IsAsync)
			{
				dependencies = ResourcesComponent.AssetBundleManifestObject.GetAllDependencies(assetBundleName);
			}
			else
			{
				dependencies = AssetDatabaseHelper.GetAssetBundleDependencies(assetBundleName, true);
			}
			
			if(dependencies != null)
			{
				DependenciesCache.Add(assetBundleName, dependencies);
			}

			return dependencies;
		}

		public static string[] GetSortedDependencies(string assetBundleName)
		{
			var info = new Dictionary<string, int>();
			var parents = new List<string>();

			CollectDependencies(parents, assetBundleName, info);
			
			return info.OrderBy(x => x.Value).Select(x => x.Key).ToArray();
		}

		public static void CollectDependencies(List<string> parents, string assetBundleName, Dictionary<string, int> info)
		{
			parents.Add(assetBundleName);

			var dependencies = GetDependencies(assetBundleName);

			foreach (string parent in parents)
			{
				if (!info.ContainsKey(parent))
				{
					info[parent] = 0;
				}

				if(dependencies != null)
				{
					info[parent] += dependencies.Length;
				}
			}

			if(dependencies != null)
			{
				foreach (string dep in dependencies)
				{
					if (parents.Contains(dep))
					{
						throw new Exception($"包有循环依赖，请重新标记: {assetBundleName} {dep}");
					}

					CollectDependencies(parents, dep, info);
				}
			}
			
			parents.RemoveAt(parents.Count - 1);
		}
	}
}
