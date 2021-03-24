using System.IO;
using UnityEditor;
using UnityEngine;
public class ModelEditorProcessor : AssetPostprocessor
{
	public void OnPreprocessModel()
	{
		ModelImporter importer = (ModelImporter)assetImporter;
		//importer.importMaterials = false;
		//importer.importTangents = ModelImporterTangents.None;
		//importer.importNormals = ModelImporterNormals.None;
	}
}

