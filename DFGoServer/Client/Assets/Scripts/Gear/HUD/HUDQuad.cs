using UnityEngine;
using System.Collections;

public class HUDQuad
{
	protected Sprite sprite;

	protected float start_vert_x = 0;
	protected float start_vert_y = 0;
	private int col = 0;
	private int row = 0;
	protected float contentCenterX = 0f;
	protected float contentCenterY = 0f;
	protected Vector2[] verts = new Vector2[4];
	protected float _scale = 1f;
	protected float rate = 1f;

	public void SetSprite(Sprite _sprite)
	{
		sprite = _sprite;
	}

	public int GetRow()
	{
		return row;
	}

	public void SetColRow(int _col, int _row)
	{
		col = _col;
		row = _row;
	}

	public void SetStartVert(float _x, float _y)
	{
		start_vert_x = _x;
		start_vert_y = _y;
	}
	//设置这个Quad所在的Content的中位点，是中心位置的VertPos， 不是单纯的宽度和高度
	public void SetCenterPosInContent(float _x, float _y)
	{
		contentCenterX = _x;
		contentCenterY = _y;
	}

	public void SetScale(float value)
	{
		_scale = value;
	}

	public void SetProgress(float _rate)
	{
		rate = _rate;
	}

	public float GetProgress()
	{
		return rate;
	}

	public float GetVertWidth()
	{
		return Mathf.Abs(sprite.vertices[1].x - sprite.vertices[0].x);
	}

	public float GetVertHeight()
	{
		return Mathf.Abs(sprite.vertices[0].y - sprite.vertices[3].y);
	}

	public virtual Vector2[] GetVert()
	{
		verts[0].x = start_vert_x;
		verts[0].y = start_vert_y;

		verts[1].x = start_vert_x + GetVertWidth();
		verts[1].y = start_vert_y;

		verts[2].x = start_vert_x;
		verts[2].y = start_vert_y - GetVertHeight();

		verts[3].x = start_vert_x + GetVertWidth();
		verts[3].y = start_vert_y - GetVertHeight();

		CalcVertScale();

		return verts;
	}

	protected void CalcVertScale()
	{
		//处理缩放
		verts[0].x = contentCenterX + (verts[0].x - contentCenterX) * _scale;
		verts[0].y = contentCenterY + (verts[0].y - contentCenterY) * _scale;

		verts[1].x = contentCenterX + (verts[1].x - contentCenterX) * _scale;
		verts[1].y = contentCenterY + (verts[1].y - contentCenterY) * _scale;

		verts[2].x = contentCenterX + (verts[2].x - contentCenterX) * _scale;
		verts[2].y = contentCenterY + (verts[2].y - contentCenterY) * _scale;

		verts[3].x = contentCenterX + (verts[3].x - contentCenterX) * _scale;
		verts[3].y = contentCenterY + (verts[3].y - contentCenterY) * _scale;
	}

	public virtual Vector2[] GetUV()
	{
		return sprite.uv;
	}

	public ushort[] GetTriangles()
	{
		return sprite.triangles;
	}

	public void Clear()
	{
		sprite = null;
	}

	public virtual void Destroy()
	{
		sprite = null;
		verts = null;
	}
}
