using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GAssetBundleLoader : GBinaryLoader
{
	public override AssetBundle AssetBundle
	{
		get
		{
			if (_assetBundle == null)
				_assetBundle = ((DownloadHandlerAssetBundle)_request.downloadHandler).assetBundle;
			return _assetBundle;
		}
	}

	public override void Dispose()
	{
		_assetBundle = null;
		base.Dispose();
	}

	protected override DownloadHandler GetDownloadHandler()
	{
		return new DownloadHandlerAssetBundle(_url, 0);
	}

}
