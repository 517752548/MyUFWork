using UnityEngine;
using System.Collections.Generic;

public class HUDManager : MonoBehaviour
{
	public delegate void OnCreateMeshComplete();
	private Camera _camera;
	private Camera _sceneCamera;
	private HUDBaseMesh _skipMesh;
	private HUDBaseMesh _bloodMesh;
	private HUDBaseMesh _textMesh;
	private bool _enableUpdate = false;
	public Camera Camera
	{
		get
		{
			return _camera;
		}
	}

	public HUDBaseMesh SkipMesh
	{
		get
		{
			return _skipMesh;
		}

	}

	public HUDBaseMesh BloodMesh
	{
		get
		{
			return _bloodMesh;
		}
	}

	public HUDBaseMesh TextMesh
	{
		get
		{
			return _textMesh;
		}
	}

	public Camera SceneCamera
	{
		get
		{
			return _sceneCamera;
		}
	}

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Init();
	}

	private void Init()
	{
		Transform cameraTSF = transform.Find("HUDCamera");
		if (cameraTSF != null)
		{
			_camera = cameraTSF.GetComponent<Camera>();
		}
	}

	public void UpdateSceneCamera(Camera camera)
	{
		_sceneCamera = camera;
		if (_skipMesh != null)
		{
			_skipMesh.sceneCamera = _sceneCamera;
		}
		if (_bloodMesh != null)
		{
			_bloodMesh.sceneCamera = _sceneCamera;
		}
		if (_textMesh != null)
		{
			_textMesh.sceneCamera = _sceneCamera;
		}
	}

	public void CreateSkipMesh(string texturePath, int sortingOrder, OnCreateMeshComplete callback = null)
	{
		if (_skipMesh != null)
		{
			if (callback != null)
			{
				callback();
			}
			return;
		}
		GResManager.GetInstance().LoadTexture2DAsync(texturePath, delegate (Texture2D tex)
		{
			_skipMesh = new HUDBaseMesh(gameObject, _sceneCamera, _camera, "SkipMesh");
			_skipMesh.AddMeshRenderer(tex, sortingOrder);
			GResManager.GetInstance().LoadAllSpriteInAtlasAsync(texturePath, delegate (AtlasInfo atlasInfo)
			{
				_skipMesh.allSprite = atlasInfo.GetSpriteMap();
				if (callback != null)
				{
					callback();
				}
			});
		});
	}

	public void CreateBloodMesh(string texturePath, int sortingOrder, OnCreateMeshComplete callback = null)
	{
		if (_bloodMesh != null)
		{
			if (callback != null)
			{
				callback();
			}
			return;
		}
		GResManager.GetInstance().LoadTexture2DAsync(texturePath, delegate (Texture2D tex)
		{
			_bloodMesh = new HUDBaseMesh(gameObject, _sceneCamera, _camera, "BloodMesh");
			_bloodMesh.AddMeshRenderer(tex, sortingOrder);
			GResManager.GetInstance().LoadAllSpriteInAtlasAsync(texturePath, delegate (AtlasInfo atlasInfo)
			{
				_bloodMesh.allSprite = atlasInfo.GetSpriteMap();
				if (callback != null)
				{
					callback();
				}
			});
		});
	}

	public void CreateTextMesh(string fontPath, int sortingOrder, OnCreateMeshComplete callback = null)
	{
		if (_textMesh != null)
		{
			if (callback != null)
			{
				callback();
			}
			return;
		}
		GResManager.GetInstance().LoadFontAsync(fontPath, delegate (Font font)
		{
			_textMesh = new HUDBaseMesh(gameObject, _sceneCamera, _camera, "TextMesh");
			_textMesh.AddMeshRenderer(font, sortingOrder);
			_textMesh.font = font;
			if (callback != null)
			{
				callback();
			}
		});
	}

	private void LateUpdate()
	{
		if (!_enableUpdate)
		{
			return;
		}
		if (_textMesh != null)
		{
			_textMesh.Update();
		}
		if (_bloodMesh != null)
		{
			_bloodMesh.Update();
		}
		if (_skipMesh != null)
		{
			_skipMesh.Update();
		}
	}

	public void SetEnabled(bool value)
	{
		_enableUpdate = value;
		_camera.enabled = value;
	}

	public void Destroy()
	{
		SetEnabled(false);
		if (_textMesh != null)
		{
			_textMesh.Destroy();
			_textMesh = null;
		}
		if (_bloodMesh != null)
		{
			_bloodMesh.Destroy();
			_bloodMesh = null;
		}
		if (_skipMesh != null)
		{
			_skipMesh.Destroy();
			_skipMesh = null;
		}
		_sceneCamera = null;
	}

	void OnApplicationQuit()
	{
		SetEnabled(false);
		Destroy();
	}
}
