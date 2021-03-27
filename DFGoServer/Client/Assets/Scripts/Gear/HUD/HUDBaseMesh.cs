using UnityEngine;
using System.Collections.Generic;
using System;

public class HUDBaseMesh
{
	private GameObject gameObject;
	public Camera sceneCamera;
	public Camera camera;
	public Font font;
	private MeshFilter meshFilter;
	private MeshRenderer meshRenderer;
	private Mesh mesh;

	private int vertBufferNum = 0;
	private Vector3[] verts;
	private int _vertUsedNum = 0;
	private Vector2[] uvs;
	private int _uvUsedNum = 0;
	public Color32[] color32;
	private int _color32UsedNum = 0;
	private int[] triangles;
	private int _trianglesUsedNum = 0;

	private int _lastVertUsedNum = 0;
	private int _lastUvUsedNum = 0;
	private int _lastColor32UsedNum = 0;
	private int _lastTrianglesUsedNum = 0;

	public Dictionary<string, Sprite> allSprite = new Dictionary<string, Sprite>();
	public List<HUDBaseContent> contentList = new List<HUDBaseContent>();
	private Queue<HUDBaseContent> recycleContentList = new Queue<HUDBaseContent>();
	private List<HUDBaseContent> stopedContentList = new List<HUDBaseContent>();

	public HUDBaseMesh(GameObject parent, Camera _sceneCamera, Camera _camera, string name, int initVertNum = 300)
	{
		gameObject = new GameObject(name);
		gameObject.transform.parent = parent.transform;
		gameObject.transform.localPosition = new Vector3(0, 0, 1);
		gameObject.transform.localRotation = Quaternion.identity;
		gameObject.transform.localScale = Vector3.one;
		gameObject.layer = LayerMask.NameToLayer("HUD");

		sceneCamera = _sceneCamera;
		camera = _camera;
		meshFilter = gameObject.AddComponent<MeshFilter>();

		mesh = new Mesh();
		meshFilter.mesh = mesh;
		mesh.name = name;

		AllocateBuffer(initVertNum);

		mesh.vertices = verts;
		mesh.uv = uvs;
		mesh.triangles = triangles;
	}

	public void AddMeshRenderer(Texture2D texture, int sortingOrder)
	{
		meshRenderer = gameObject.AddComponent<MeshRenderer>();
		meshRenderer.material.shader = Shader.Find("Sprites/Default");
		meshRenderer.material.mainTexture = texture;
		meshRenderer.material.color = Color.white;
		meshRenderer.sortingOrder = sortingOrder;
		meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		meshRenderer.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
		meshRenderer.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
		meshRenderer.receiveShadows = false;
	}

	public void AddMeshRenderer(Font font, int sortingOrder)
	{
		meshRenderer = gameObject.AddComponent<MeshRenderer>();
		meshRenderer.material = font.material;
		meshRenderer.sortingOrder = sortingOrder;
		meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		meshRenderer.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
		meshRenderer.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
		meshRenderer.receiveShadows = false;
	}

	private void AllocateBuffer(int num)
	{
		if (vertBufferNum < num)
		{
			vertBufferNum = num;
			if (verts != null)
				Array.Resize<Vector3>(ref verts, vertBufferNum);
			else
				verts = new Vector3[vertBufferNum];

			if (uvs != null)
				Array.Resize<Vector2>(ref uvs, vertBufferNum);
			else
				uvs = new Vector2[vertBufferNum];

			if (color32 != null)
				Array.Resize<Color32>(ref color32, vertBufferNum);
			else
				color32 = new Color32[vertBufferNum];

			if (triangles != null)
				Array.Resize<int>(ref triangles, vertBufferNum * 2);
			else
				triangles = new int[vertBufferNum * 2];
		}

	}

	private void CheckAndResizeBuffer()
	{
		if (_vertUsedNum >= vertBufferNum)
		{
			int num = _vertUsedNum;
			int mod = num % 3;
			if (mod > 0)
			{
				num += (3 - mod);
			}
			AllocateBuffer(num);
		}
	}

	public HUDSkipContent GetSkipTemporary()
	{
		HUDBaseContent content = null;
		if (recycleContentList.Count > 0)
		{
			content = recycleContentList.Dequeue();
			if (content is HUDSkipContent)
			{
				content.SetParentMesh(this);
				return content as HUDSkipContent;
			}
		}
		content = new HUDSkipContent();
		content.SetParentMesh(this);
		return content as HUDSkipContent;
	}

	public HUDBloodContent GetBloodTemporary()
	{
		HUDBaseContent content = null;
		if (recycleContentList.Count > 0)
		{
			content = recycleContentList.Dequeue();
			if (content is HUDBloodContent)
			{
				content.SetParentMesh(this);
				return content as HUDBloodContent;
			}
		}
		content = new HUDBloodContent();
		content.SetParentMesh(this);
		return content as HUDBloodContent;
	}

	public HUDTextContent GetTextTemporary()
	{
		HUDBaseContent content = null;
		if (recycleContentList.Count > 0)
		{
			content = recycleContentList.Dequeue();
			if (content is HUDTextContent)
			{
				content.SetParentMesh(this);
				return content as HUDTextContent;
			}
		}
		content = new HUDTextContent();
		content.SetParentMesh(this);
		return content as HUDTextContent;
	}

	public HUDSpriteContent GetSpriteTemporary()
	{
		HUDBaseContent content = null;
		if (recycleContentList.Count > 0)
		{
			content = recycleContentList.Dequeue();
			if (content is HUDSpriteContent)
			{
				content.SetParentMesh(this);
				return content as HUDSpriteContent;
			}
		}
		content = new HUDSpriteContent();
		content.SetParentMesh(this);
		return content as HUDSpriteContent;
	}

	public void ReleaseTemporary(HUDBaseContent content)
	{
		contentList.Remove(content);
		content.Clear();
		recycleContentList.Enqueue(content);
	}

	public void AppendContent(HUDBaseContent _content)
	{
		contentList.Add(_content);
	}

	public void Update()
	{
		if (sceneCamera == null)
		{
			return;
		}
		_vertUsedNum = 0;
		_uvUsedNum = 0;
		_color32UsedNum = 0;
		_trianglesUsedNum = 0;
		int oldVertUsedNum = 0;
		int oldUvUsedNum = 0;
		int oldColor32UsedNum = 0;
		int oldTrianglesUsedNum = 0;
		int contentLength = contentList.Count;
		for (int i = 0; i < contentLength; i++)
		{
			HUDBaseContent content = contentList[i];
			if (content.IsStop)
			{
				stopedContentList.Add(content);
				continue;
			}
			//设置这个关系到内部Triangles的索引计算
			content.RenderVertBeginIndex = _vertUsedNum;
			content.Update();

			oldVertUsedNum = _vertUsedNum;
			oldUvUsedNum = _uvUsedNum;
			oldColor32UsedNum = _color32UsedNum;
			oldTrianglesUsedNum = _trianglesUsedNum;
			//刷新已经是用的顶点 uv 三角形数量
			_vertUsedNum += content.VertUsedNum;
			_uvUsedNum += content.UvUsedNum;
			_color32UsedNum += content.Color32UsedNum;
			_trianglesUsedNum += content.TrianglesUsedNum;
			//检查Buffer是否够用，不够就扩容
			CheckAndResizeBuffer();
			//copy顶点 uv 三角形数据去渲染显示
			Array.Copy(content.verts, 0, verts, oldVertUsedNum, content.VertUsedNum);
			Array.Copy(content.uvs, 0, uvs, oldUvUsedNum, content.UvUsedNum);
			Array.Copy(content.color32, 0, color32, oldColor32UsedNum, content.Color32UsedNum);
			Array.Copy(content.triangles, 0, triangles, oldTrianglesUsedNum, content.TrianglesUsedNum);
		}

		//清空Buffer中没使用的部分 相对于上一帧的
		for (int i = _vertUsedNum; i < _lastVertUsedNum; i++)
		{
			verts[i].x = 0;
			verts[i].y = 0;
			verts[i].z = 0;
		}

		for (int i = _uvUsedNum; i < _lastUvUsedNum; i++)
		{
			uvs[i].x = 0;
			uvs[i].y = 0;
		}

		for (int i = _color32UsedNum; i < _lastColor32UsedNum; i++)
		{
			color32[i].r = 255;
			color32[i].g = 255;
			color32[i].b = 255;
			color32[i].a = 255;
		}

		for (int i = _trianglesUsedNum; i < _lastTrianglesUsedNum; i++)
		{
			triangles[i] = 0;
		}
		_lastVertUsedNum = _vertUsedNum;
		_lastUvUsedNum = _uvUsedNum;
		_lastColor32UsedNum = _color32UsedNum;
		_lastTrianglesUsedNum = _trianglesUsedNum;

		//修改mesh渲染
		mesh.vertices = verts;
		mesh.uv = uvs;
		mesh.colors32 = color32;
		mesh.triangles = triangles;
		//从更新列表中移除
		for (int i = stopedContentList.Count - 1; i >= 0; i--)
		{
			HUDBaseContent content = stopedContentList[i];
			stopedContentList.RemoveAt(i);
			ReleaseTemporary(content);
		}
	}

	public void Destroy()
	{
		sceneCamera = null;
		camera = null;
		font = null;
		meshFilter = null;
		meshRenderer = null;
		mesh = null;

		verts = null;
		uvs = null;
		color32 = null;
		triangles = null;
		allSprite = null;
		for (int i = 0; i < contentList.Count; i++)
		{
			contentList[i].Destroy();
		}
		contentList = null;
		while (recycleContentList.Count > 0)
		{
			HUDBaseContent bc = recycleContentList.Dequeue();
			bc.Destroy();
		}
		recycleContentList = null;
		for (int i = 0; i < stopedContentList.Count; i++)
		{
			stopedContentList[i].Destroy();
		}
		stopedContentList = null;
		GameObject.Destroy(gameObject);
	}
}
