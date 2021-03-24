using UnityEngine;
using System.Collections.Generic;
using System;

public class HUDBaseContent
{
	protected HUDBaseMesh _parentMesh;
	private SkipMotionCurveData _curveData;
	protected bool _isStop = false;
	protected Vector3 _screenPos = Vector3.zero;
	protected Vector3 _startVertPos = Vector3.zero;
	public List<HUDQuad> quads = new List<HUDQuad>();
	protected Queue<HUDQuad> recycleQuadList = new Queue<HUDQuad>();
	protected int lastQuadsCount = 0;
	protected bool _isStopRender = false;
	protected int vertBufferNum = 0;
	public Vector3[] verts;
	protected int _vertUsedNum = 0;
	public Vector2[] uvs;
	protected int _uvUsedNum = 0;
	public Color32[] color32;
	protected int _color32UsedNum = 0;
	public int[] triangles;
	protected int _trianglesUsedNum = 0;

	private int currCol = 0;
	private int currRow = 0;
	//记录了行的最大宽度(x)和最大高度(y),最大支持20行 
	private Vector2[] rowMaxSize = new Vector2[20];

	protected int _renderVertBeginIndex = 0;

	//curve动画相关
	private Vector3 v_axial = Vector3.zero;
	private float speed = 1f;
	private byte alpha = 255;
	private float scale = 1f;
	private float duration = 1f;
	private float curTime = 0f;
	protected Rect _rect = new Rect();
	protected float _rectMaxWidth = 0f;
	protected float _rectMaxHeight = 0f;
	public int VertUsedNum
	{
		get
		{
			return _vertUsedNum;
		}

		set
		{
			_vertUsedNum = value;
		}
	}

	public int UvUsedNum
	{
		get
		{
			return _uvUsedNum;
		}

		set
		{
			_uvUsedNum = value;
		}
	}

	public int Color32UsedNum
	{
		get
		{
			return _color32UsedNum;
		}

		set
		{
			_color32UsedNum = value;
		}
	}

	public int TrianglesUsedNum
	{
		get
		{
			return _trianglesUsedNum;
		}

		set
		{
			_trianglesUsedNum = value;
		}
	}

	public int RenderVertBeginIndex
	{
		get
		{
			return _renderVertBeginIndex;
		}

		set
		{
			_renderVertBeginIndex = value;
		}
	}

	public bool IsStop
	{
		get
		{
			return _isStop;
		}

		set
		{
			_isStop = value;
		}
	}

	public Rect GetRect()
	{
		_rect.x = _startVertPos.x - _rectMaxWidth / 2f;
		_rect.y = _startVertPos.y;
		_rect.width = _rectMaxWidth;
		_rect.height = _rectMaxHeight;
		return _rect;
	}



	public HUDBaseContent()
	{
		AllocateBuffer(30);
	}

	public void SetParentMesh(HUDBaseMesh _pm)
	{
		_parentMesh = _pm;
	}
	//为了简化计算量，虽然说这里如果传入一个世界坐标，然后进行[世界坐标-屏幕坐标-屏幕meshVert坐标] 这样的转换也不会耗费太大性能。但为了保险 这里直接使用[meshVert坐标]这样的形式来存储起始坐标了，随后的curve动画也是根据meshVert坐标系计算
	public void SetStartVertPos(float x, float y)
	{
		_startVertPos.x = x;
		_startVertPos.y = y;
	}

	public void SetCurveData(SkipMotionCurveData data)
	{
		_curveData = data;
		_curveData.curve_x_axial.preWrapMode = WrapMode.Loop;
		_curveData.curve_x_axial.postWrapMode = WrapMode.Loop;

		_curveData.curve_y_axial.preWrapMode = WrapMode.Loop;
		_curveData.curve_y_axial.postWrapMode = WrapMode.Loop;

		_curveData.curve_scale.preWrapMode = WrapMode.Loop;
		_curveData.curve_scale.postWrapMode = WrapMode.Loop;

		_curveData.curve_speed.preWrapMode = WrapMode.Loop;
		_curveData.curve_speed.postWrapMode = WrapMode.Loop;

		_curveData.curve_alpha.preWrapMode = WrapMode.Loop;
		_curveData.curve_alpha.postWrapMode = WrapMode.Loop;

		duration = (float)_curveData.duration / 1000f;
	}

	protected virtual void AllocateBuffer(int num)
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

	protected virtual void CheckAndResizeBuffer()
	{
		int nextVertNum = quads.Count * 4;
		if (nextVertNum >= vertBufferNum)
		{
			AllocateBuffer(vertBufferNum + 30);
		}
	}

	protected virtual HUDQuad GetTemporary()
	{
		HUDQuad quad = null;
		if (recycleQuadList.Count > 0)
		{
			quad = recycleQuadList.Dequeue();
			return quad;
		}
		quad = new HUDQuad();
		return quad;
	}

	public void ReleaseTemporary(HUDQuad quad)
	{
		quads.Remove(quad);
		quad.Clear();
		recycleQuadList.Enqueue(quad);
	}

	public virtual void Append(string spriteName)
	{
		Sprite sprite = null;
		_parentMesh.allSprite.TryGetValue(spriteName, out sprite);
		if (sprite != null)
		{
			HUDQuad quad = GetTemporary();
			quad.SetSprite(sprite);
			quad.SetColRow(currCol, currRow);
			rowMaxSize[currRow].x += quad.GetVertWidth();
			rowMaxSize[currRow].y = Mathf.Max(quad.GetVertHeight(), rowMaxSize[currRow].y);
			quads.Add(quad);

			CheckAndResizeBuffer();

			currCol++;
		}
	}

	public void InsertNewLine()
	{
		currRow++;
	}

	public virtual void CalcQuadsVert()
	{
		_rectMaxWidth = 0f;
		_rectMaxHeight = 0f;
		for (int i = 0; i < rowMaxSize.Length; i++)
		{
			_rectMaxWidth = Mathf.Max(_rectMaxWidth, rowMaxSize[i].x);
			_rectMaxHeight += rowMaxSize[i].y;
		}
		float centerX = _startVertPos.x;
		float centerY = _startVertPos.y;
		float startY = _startVertPos.y;
		for (int r = 0; r <= currRow; r++)
		{
			float startX = _startVertPos.x;
			for (int i = 0; i < quads.Count; i++)
			{
				HUDQuad quad = quads[i];
				if (quad.GetRow() == r)
				{
					quad.SetCenterPosInContent(centerX, centerY);
					quad.SetStartVert(startX - rowMaxSize[quad.GetRow()].x / 2f, startY - (rowMaxSize[quad.GetRow()].y / 2f) + (quad.GetVertHeight() / 2f) + (_rectMaxHeight / 2f));
					startX += quad.GetVertWidth();
				}
			}
			startY -= rowMaxSize[r].y;
		}
	}

	public virtual void Update()
	{
		if (_isStop)
		{
			return;
		}
		if (curTime >= duration)
		{
			_isStop = true;
			return;
		}
		_isStopRender = false;
		speed = _curveData.curve_speed.Evaluate(curTime);
		v_axial.x = _curveData.curve_x_axial.Evaluate(curTime) * speed;
		v_axial.y = _curveData.curve_y_axial.Evaluate(curTime) * speed;
		alpha = (byte)(_curveData.curve_alpha.Evaluate(curTime) * 255);
		scale = _curveData.curve_scale.Evaluate(curTime) * speed;
		DrawBuffer();
		CleanUpBuffer();
		curTime = curTime + Time.deltaTime;
	}

	public virtual void DrawBuffer()
	{
		int quadsCount = quads.Count;
		for (int i = 0; i < quadsCount; i++)
		{
			HUDQuad quad = quads[i];
			quad.SetScale(scale);
			Vector2[] quadVert = quad.GetVert();
			verts[i * 4].x = quadVert[0].x + v_axial.x;
			verts[i * 4].y = quadVert[0].y - v_axial.y;
			verts[i * 4].z = 0;
			verts[i * 4 + 1].x = quadVert[1].x + v_axial.x;
			verts[i * 4 + 1].y = quadVert[1].y - v_axial.y;
			verts[i * 4 + 1].z = 0;
			verts[i * 4 + 2].x = quadVert[2].x + v_axial.x;
			verts[i * 4 + 2].y = quadVert[2].y - v_axial.y;
			verts[i * 4 + 2].z = 0;
			verts[i * 4 + 3].x = quadVert[3].x + v_axial.x;
			verts[i * 4 + 3].y = quadVert[3].y - v_axial.y;
			verts[i * 4 + 3].z = 0;
			_vertUsedNum = i * 4 + 3 + 1;

			Vector2[] quadUV = quad.GetUV();
			uvs[i * 4].x = quadUV[0].x;
			uvs[i * 4].y = quadUV[0].y;
			uvs[i * 4 + 1].x = quadUV[1].x;
			uvs[i * 4 + 1].y = quadUV[1].y;
			uvs[i * 4 + 2].x = quadUV[2].x;
			uvs[i * 4 + 2].y = quadUV[2].y;
			uvs[i * 4 + 3].x = quadUV[3].x;
			uvs[i * 4 + 3].y = quadUV[3].y;
			_uvUsedNum = i * 4 + 3 + 1;

			color32[i * 4].r = 255;
			color32[i * 4].g = 255;
			color32[i * 4].b = 255;
			color32[i * 4].a = alpha;
			color32[i * 4 + 1].r = 255;
			color32[i * 4 + 1].g = 255;
			color32[i * 4 + 1].b = 255;
			color32[i * 4 + 1].a = alpha;
			color32[i * 4 + 2].r = 255;
			color32[i * 4 + 2].g = 255;
			color32[i * 4 + 2].b = 255;
			color32[i * 4 + 2].a = alpha;
			color32[i * 4 + 3].r = 255;
			color32[i * 4 + 3].g = 255;
			color32[i * 4 + 3].b = 255;
			color32[i * 4 + 3].a = alpha;
			_color32UsedNum = i * 4 + 3 + 1;

			triangles[i * 6] = _renderVertBeginIndex + (i * 4);
			triangles[i * 6 + 1] = _renderVertBeginIndex + (i * 4 + 1);
			triangles[i * 6 + 2] = _renderVertBeginIndex + (i * 4 + 2);
			triangles[i * 6 + 3] = _renderVertBeginIndex + (i * 4 + 2);
			triangles[i * 6 + 4] = _renderVertBeginIndex + (i * 4 + 1);
			triangles[i * 6 + 5] = _renderVertBeginIndex + (i * 4 + 3);
			_trianglesUsedNum = i * 6 + 5 + 1;
		}
	}

	public virtual void CleanUpBuffer()
	{
		int quadsCount = quads.Count;
		//清空Buffer中没使用的部分 相对于上一帧的
		for (int j = quadsCount; j < lastQuadsCount; j++)
		{
			verts[j * 4].x = 0;
			verts[j * 4].y = 0;
			verts[j * 4].z = 0;
			verts[j * 4 + 1].x = 0;
			verts[j * 4 + 1].y = 0;
			verts[j * 4 + 1].z = 0;
			verts[j * 4 + 2].x = 0;
			verts[j * 4 + 2].y = 0;
			verts[j * 4 + 2].z = 0;
			verts[j * 4 + 3].x = 0;
			verts[j * 4 + 3].y = 0;
			verts[j * 4 + 3].z = 0;

			uvs[j * 4].x = 0;
			uvs[j * 4].y = 0;
			uvs[j * 4 + 1].x = 0;
			uvs[j * 4 + 1].y = 0;
			uvs[j * 4 + 2].x = 0;
			uvs[j * 4 + 2].y = 0;
			uvs[j * 4 + 3].x = 0;
			uvs[j * 4 + 3].y = 0;

			color32[j * 4].r = 255;
			color32[j * 4].g = 255;
			color32[j * 4].b = 255;
			color32[j * 4].a = 255;
			color32[j * 4 + 1].r = 255;
			color32[j * 4 + 1].g = 255;
			color32[j * 4 + 1].b = 255;
			color32[j * 4 + 1].a = 255;
			color32[j * 4 + 2].r = 255;
			color32[j * 4 + 2].g = 255;
			color32[j * 4 + 2].b = 255;
			color32[j * 4 + 2].a = 255;
			color32[j * 4 + 3].r = 255;
			color32[j * 4 + 3].g = 255;
			color32[j * 4 + 3].b = 255;
			color32[j * 4 + 3].a = 255;

			triangles[j * 6] = 0;
			triangles[j * 6 + 1] = 0;
			triangles[j * 6 + 2] = 0;
			triangles[j * 6 + 3] = 0;
			triangles[j * 6 + 4] = 0;
			triangles[j * 6 + 5] = 0;
		}

		lastQuadsCount = quadsCount;
	}

	public void StopRender()
	{
		_vertUsedNum = 0;
		_uvUsedNum = 0;
		_color32UsedNum = 0;
		_trianglesUsedNum = 0;
		_isStopRender = true;
	}

	public virtual void RecoverRender()
	{
		_isStopRender = false;
	}

	public virtual void Clear()
	{
		_parentMesh = null;
		_curveData = null;
		currCol = 0;
		currRow = 0;
		curTime = 0;
		_isStop = false;
		for (int i = 0; i < rowMaxSize.Length; i++)
		{
			rowMaxSize[i].x = 0;
			rowMaxSize[i].y = 0;
		}
		for (int i = quads.Count - 1; i >= 0; i--)
		{
			ReleaseTemporary(quads[i]);
		}
	}

	public virtual void Destroy()
	{
		_parentMesh = null;
		_curveData = null;
		for (int i = 0; i < quads.Count; i++)
		{
			quads[i].Destroy();
		}
		quads = null;
		while (recycleQuadList.Count > 0)
		{
			HUDQuad q = recycleQuadList.Dequeue();
			q.Destroy();
		}
		recycleQuadList = null;
		verts = null;
		uvs = null;
		color32 = null;
		triangles = null;
		rowMaxSize = null;

	}
}
