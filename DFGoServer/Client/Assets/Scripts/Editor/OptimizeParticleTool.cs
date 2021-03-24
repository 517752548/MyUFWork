using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

class ParticleOpt
{
	GameObject _go;
	string _path;

	public string path { get { return _path; } }

	public ParticleOpt(string path, GameObject go)
	{
		_path = path;
		_go = go;
	}

	public void ExecOpt()
	{
		if (_go == null)
		{
			return;
		}
		ParticleSystem[] pss = _go.GetComponentsInChildren<ParticleSystem>();
		for (int i = 0; i < pss.Length; i++)
		{
			ParticleSystem ps = pss[i];
			ParticleSystemRenderer render = ps.GetComponent<Renderer>() as ParticleSystemRenderer;
			if (render == null)
				continue;
			if (render.sharedMaterial == null)
				continue;
			if (render.sharedMaterial.name.StartsWith("Default-Particle"))
			{
				render.sharedMaterials = new Material[0];
				//GameObject.DestroyImmediate(render.sharedMaterial, true);
			}
			render.enableGPUInstancing = false;
		}
	}
}

public class OptimizeParticleTool
{
	static List<ParticleOpt> _optList = new List<ParticleOpt>();
	static int _Index = 0;

	[MenuItem("LetUs/Release Preprocess/优化Particle")]
	public static void Optimize()
	{
		_optList = FindParticle();
		if (_optList.Count > 0)
		{
			_Index = 0;
			EditorApplication.update = Scan;
		}
	}


	private static void Scan()
	{
		ParticleOpt _opt = _optList[_Index];
		bool isCancel = EditorUtility.DisplayCancelableProgressBar("优化Particle", _opt.path, (float)_Index / (float)_optList.Count);
		_opt.ExecOpt();
		_Index++;
		if (isCancel || _Index >= _optList.Count)
		{
			EditorUtility.ClearProgressBar();
			Debug.Log(string.Format("--优化完成--   总数量: {0}/{1}    ----------输出完毕----------", _Index, _optList.Count));
			Resources.UnloadUnusedAssets();
			GC.Collect();
			AssetDatabase.SaveAssets();
			EditorApplication.update = null;
			_optList.Clear();
			_cachedOpts.Clear();
			_Index = 0;
		}
	}

	static Dictionary<string, ParticleOpt> _cachedOpts = new Dictionary<string, ParticleOpt>();

	static ParticleOpt _GetNewAOpt(string path)
	{
		ParticleOpt opt = null;
		if (!_cachedOpts.ContainsKey(path))
		{
			GameObject go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
			if (go != null)
			{
				opt = new ParticleOpt(path, go);
				_cachedOpts[path] = opt;
			}
		}
		return opt;
	}

	static List<ParticleOpt> FindParticle()
	{
		string[] guids = new string[] { };
		List<string> path = new List<string>();
		List<ParticleOpt> assets = new List<ParticleOpt>();
		UnityEngine.Object[] objs = Selection.GetFiltered(typeof(object), SelectionMode.Assets);
		//有选择的走这里
		if (objs.Length > 0)
		{
			for (int i = 0; i < objs.Length; i++)
			{
				if (objs[i].GetType() == typeof(GameObject))
				{
					string p = AssetDatabase.GetAssetPath(objs[i]);
					ParticleOpt opt = _GetNewAOpt(p);
					if (opt != null)
						assets.Add(opt);
				}
				else
					path.Add(AssetDatabase.GetAssetPath(objs[i]));
			}
			if (path.Count > 0)
				guids = AssetDatabase.FindAssets(string.Format("t:{0}", typeof(GameObject).ToString().Replace("UnityEngine.", "")), path.ToArray());
		}
		else
		{
			//没有选择就是全部遍历
			List<string> files = BuildScript.GetFilesPathList("Res/Effect/Prefab", ".prefab", new string[] { ".meta" });
			for (int i = 0; i < files.Count; i++)
			{
				ParticleOpt opt = _GetNewAOpt(files[i]);
				if (opt != null)
					assets.Add(opt);
			}
		}
		for (int i = 0; i < guids.Length; i++)
		{
			string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
			ParticleOpt opt = _GetNewAOpt(assetPath);
			if (opt != null)
				assets.Add(opt);
		}
		return assets;
	}
}
