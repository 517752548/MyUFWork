using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using System;

namespace Hybrid.Bundles
{
	[Serializable]
	public class HybridBundlesTreeElement : BaseTreeElement
	{
		[SerializeField]
		private string _path;
		public bool isFolder = false;
		public bool isNew = false;
		[SerializeField]
		private int _folderBundleType = (int)HybridBundlesConsts.BundlePackageType.NONE;
		[SerializeField]
		public string bundleName = "";
		public int folderBundleType
		{
			get
			{
				return _folderBundleType;
			}

			set
			{
				_folderBundleType = value;
				bundleName = HybridBundlesConsts.GetFolderBundleNameForEditor(_path, this);
			}
		}

		public string path
		{
			get
			{
				return _path;
			}

			set
			{
				_path = value;
				bundleName = HybridBundlesConsts.GetFolderBundleNameForEditor(_path, this);
			}
		}

		public HybridBundlesTreeElement(string name, int depth, int id, string _path) : base(name, depth, id)
		{
			path = _path;
		}

		public void SetFolderBundleTypeAndDeepChildren(HybridBundlesConsts.BundlePackageType t)
		{
			folderBundleType = (int)t;
			if (hasChildren)
			{
				foreach (HybridBundlesTreeElement element in children)
				{
					element.SetFolderBundleTypeAndDeepChildren(t);
				}
			}
		}

		public void CopyFrom(HybridBundlesTreeElement source)
		{

			path = source.path;
			folderBundleType = source.folderBundleType;
		}
		
	}
}