using UnityEngine;
using System.Collections;
using System.Linq;
using System;
//目前只支持单行文字显示
public class HUDTextContent : HUDBaseContent
{
	private bool showShadows = true;
	private Color shadowsColor = Color.black;
	private Vector3 _syncPosition;
	private Vector3[] _tempVerts;
	private int[] _tempTriangles;
	private string _textStr = "";
	private int _fontSize = 0;
	private Color _color = Color.white;
	private FontStyle _fontStyle = FontStyle.Normal;
	private int lastTextLength = 0;
	public HUDTextContent()
	{
	}

	protected override void AllocateBuffer(int num)
	{
		base.AllocateBuffer(num);
		if (_tempVerts != null && _tempVerts.Length < num)
			Array.Resize<Vector3>(ref _tempVerts, num);
		else
			_tempVerts = new Vector3[num];

		if (_tempTriangles != null && _tempTriangles.Length < num * 2)
			Array.Resize<int>(ref _tempTriangles, num * 2);
		else
			_tempTriangles = new int[num * 2];
	}

	protected override void CheckAndResizeBuffer()
	{
		int nextVertNum = _textStr.Length * 4;
		if (showShadows)
		{
			nextVertNum *= 2;
		}
		if (nextVertNum >= vertBufferNum)
		{
			AllocateBuffer(nextVertNum + 30);
		}
	}

	public void SetSyncPosition(Vector3 pos)
	{
		_syncPosition = pos;
	}

	void OnFontTextureRebuilt(Font changedFont)
	{
		if (_parentMesh == null || _parentMesh.font == null)
			return;

		RebuildFontMesh();
	}

	public void SetText(string text, Color color, int fontSize = 18, FontStyle fontStyle = FontStyle.Normal)
	{
		if (_parentMesh == null)
			return;
		if (_parentMesh.font == null)
			return;

		_textStr = text;
		_color = color;
		_fontStyle = fontStyle;
		_fontSize = fontSize;
		CheckAndResizeBuffer();
		Font.textureRebuilt += OnFontTextureRebuilt;
		RebuildFontMesh();
	}

	public override void RecoverRender()
	{
		base.RecoverRender();
		RebuildFontMesh();
	}

	public override void Update()
	{
		if (_isStop)
		{
			return;
		}
		if (_isStopRender)
		{
			return;
		}
		_parentMesh.font.RequestCharactersInTexture(_textStr, _fontSize, _fontStyle);
		for (int i = 0; i < _vertUsedNum; i++)
		{
			verts[i].x = _startVertPos.x + _tempVerts[i].x;
			verts[i].y = _startVertPos.y + _tempVerts[i].y;
			verts[i].z = 0;
		}

		for (int i = 0; i < _trianglesUsedNum; i++)
		{
			triangles[i] = _renderVertBeginIndex + _tempTriangles[i];
		}
		int textLength = _textStr.Length;
		if (showShadows)
		{
			textLength *= 2;
		}
		for (int j = textLength; j < lastTextLength; j++)
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
		lastTextLength = textLength;
	}

	void RebuildFontMesh()
	{
		if (_parentMesh.font == null)
			return;
		if (string.IsNullOrEmpty(_textStr))
			return;

		_parentMesh.font.RequestCharactersInTexture(_textStr, _fontSize, _fontStyle);
		if (showShadows)
		{
			//构建文字阴影
			BuildFontMesh(0, 0, true, shadowsColor);
			//构建文字
			BuildFontMesh(_vertUsedNum, _trianglesUsedNum, false, _color);
		}
		else
		{
			//构建文字
			BuildFontMesh(0, 0, false, _color);
		}
		Update();
	}

	private void BuildFontMesh(int startVertIndex, int startTriangleIndex, bool isBuildShadows, Color c)
	{
		Font font = _parentMesh.font;
		CheckAndResizeBuffer();
		int textLength = _textStr.Length;
		//计算总宽度
		_rectMaxWidth = 0f;
		_rectMaxHeight = 0f;
		for (int i = 0; i < textLength; i++)
		{
			CharacterInfo ch;
			font.GetCharacterInfo(_textStr[i], out ch, _fontSize, _fontStyle);
			_rectMaxWidth += ch.advance;
			_rectMaxHeight = Mathf.Max(_rectMaxHeight, ch.maxY - ch.minY);
		}
		Vector3 pos = Vector3.zero;
		pos.x -= _rectMaxWidth / 2f;

		_rectMaxWidth *= 0.01f;
		_rectMaxHeight *= 0.01f;

		//阴影的偏移问题
		if (isBuildShadows)
		{
			pos.x += 1f;
			pos.y += -1f;
		}
		for (int i = 0; i < textLength; i++)
		{
			CharacterInfo ch;
			font.GetCharacterInfo(_textStr[i], out ch, _fontSize, _fontStyle);

			_tempVerts[startVertIndex + (4 * i + 0)].x = (pos.x + ch.minX) * 0.01f;
			_tempVerts[startVertIndex + (4 * i + 0)].y = (pos.y + ch.maxY) * 0.01f;
			_tempVerts[startVertIndex + (4 * i + 0)].z = 0;

			_tempVerts[startVertIndex + (4 * i + 1)].x = (pos.x + ch.maxX) * 0.01f;
			_tempVerts[startVertIndex + (4 * i + 1)].y = (pos.y + ch.maxY) * 0.01f;
			_tempVerts[startVertIndex + (4 * i + 1)].z = 0;

			_tempVerts[startVertIndex + (4 * i + 2)].x = (pos.x + ch.maxX) * 0.01f;
			_tempVerts[startVertIndex + (4 * i + 2)].y = (pos.y + ch.minY) * 0.01f;
			_tempVerts[startVertIndex + (4 * i + 2)].z = 0;

			_tempVerts[startVertIndex + (4 * i + 3)].x = (pos.x + ch.minX) * 0.01f;
			_tempVerts[startVertIndex + (4 * i + 3)].y = (pos.y + ch.minY) * 0.01f;
			_tempVerts[startVertIndex + (4 * i + 3)].z = 0;
			_vertUsedNum = startVertIndex + (i * 4 + 3 + 1);

			uvs[startVertIndex + (4 * i + 0)] = ch.uvTopLeft;
			uvs[startVertIndex + (4 * i + 1)] = ch.uvTopRight;
			uvs[startVertIndex + (4 * i + 2)] = ch.uvBottomRight;
			uvs[startVertIndex + (4 * i + 3)] = ch.uvBottomLeft;
			_uvUsedNum = startVertIndex + (i * 4 + 3 + 1);

			color32[startVertIndex + (i * 4)] = c;
			color32[startVertIndex + (i * 4 + 1)] = c;
			color32[startVertIndex + (i * 4 + 2)] = c;
			color32[startVertIndex + (i * 4 + 3)] = c;
			_color32UsedNum = startVertIndex + (i * 4 + 3 + 1);

			_tempTriangles[startTriangleIndex + (6 * i + 0)] = startVertIndex + (4 * i + 0);
			_tempTriangles[startTriangleIndex + (6 * i + 1)] = startVertIndex + (4 * i + 1);
			_tempTriangles[startTriangleIndex + (6 * i + 2)] = startVertIndex + (4 * i + 2);
			_tempTriangles[startTriangleIndex + (6 * i + 3)] = startVertIndex + (4 * i + 0);
			_tempTriangles[startTriangleIndex + (6 * i + 4)] = startVertIndex + (4 * i + 2);
			_tempTriangles[startTriangleIndex + (6 * i + 5)] = startVertIndex + (4 * i + 3);
			_trianglesUsedNum = startTriangleIndex + (i * 6 + 5 + 1);

			// Advance character position
			pos.x += ch.advance;
		}
	}

	public override void Clear()
	{
		Font.textureRebuilt -= OnFontTextureRebuilt;
		base.Clear();
	}

	public override void Destroy()
	{
		_tempVerts = null;
		_tempTriangles = null;
		Font.textureRebuilt -= OnFontTextureRebuilt;
		base.Destroy();
	}
}
