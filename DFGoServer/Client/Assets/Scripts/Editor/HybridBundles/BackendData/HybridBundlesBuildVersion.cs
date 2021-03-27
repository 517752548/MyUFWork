using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Hybrid.Bundles
{
	[CreateAssetMenu(fileName = "HybridBundlesBuildVersionData", menuName = "HybridBundlesBuildVersionAsset", order = 1)]
	class HybridBundlesBuildVersion : ScriptableObject
	{
		public string bundleVersion = "";
		public string csharpMD5 = "";
	}
}
