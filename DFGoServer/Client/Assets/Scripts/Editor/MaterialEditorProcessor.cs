using System.IO;
using UnityEditor;
using UnityEngine;
public class MaterialEditorProcessor : AssetPostprocessor
{
	public void OnPostprocessMaterial(Material material)
	{
		ReleasePreprocess.CleanOneMaterial(material);
	}
}

