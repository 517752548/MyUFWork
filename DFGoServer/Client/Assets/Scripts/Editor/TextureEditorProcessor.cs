using System.IO;
using UnityEditor;
using UnityEngine;
public class TextureEditorProcessor : AssetPostprocessor
{
	public void OnPreprocessTexture()
	{
		TextureImporter textureImporter = (TextureImporter)assetImporter;
		//处理当拖入UI/Texture目录的图片的设置
		if (assetPath.IndexOf("Res/UI/Texture") >= 0)
		{
			//Set AssetBundleName
			string dir = Path.GetDirectoryName(assetPath);
			string lowerDir = dir.ToLower();
			string _lowerDir = lowerDir.Replace(Path.DirectorySeparatorChar, '_');
			string abName = _lowerDir.Substring(_lowerDir.IndexOf("ui_texture"));
			textureImporter.spritePackingTag = abName;
			BuildScript.SetPlatformUITextureSettings(textureImporter);
		}
		else if (assetPath.IndexOf("Res/Puzzle/Texture") >= 0)
		{
			//Set AssetBundleName
			string dir = Path.GetDirectoryName(assetPath);
			string lowerDir = dir.ToLower();
			string _lowerDir = lowerDir.Replace(Path.DirectorySeparatorChar, '_');
			string abName = _lowerDir.Substring(_lowerDir.IndexOf("puzzle_texture"));
			textureImporter.spritePackingTag = abName;
			BuildScript.SetPlatformUITextureSettings(textureImporter);
		}
		//处理当拖入Icon目录的图片的设置
		else if (assetPath.IndexOf("Res/Icon/") >= 0)
		{
			BuildScript.SetPlatformIconTextureSettings(textureImporter);
		}
		else if (assetPath.IndexOf("Res/Effect/") >= 0)
		{
			BuildScript.SetPlatformTextureSettings(textureImporter);
		}
	}
}

