using UnityEngine;
using System.Collections;

public class HUDBloodQuad : HUDQuad
{
	protected Vector2[] uvs = new Vector2[4];

	public override Vector2[] GetVert()
	{
		verts[0].x = start_vert_x;
		verts[0].y = start_vert_y;

		verts[1].x = start_vert_x + GetVertWidth() * rate;
		verts[1].y = start_vert_y;

		verts[2].x = start_vert_x;
		verts[2].y = start_vert_y - GetVertHeight();

		verts[3].x = start_vert_x + GetVertWidth() * rate;
		verts[3].y = start_vert_y - GetVertHeight();

		CalcVertScale();

		return verts;
	}

	public override Vector2[] GetUV()
	{
		uvs[0].x = sprite.uv[0].x;
		uvs[0].y = sprite.uv[0].y;

		uvs[1].x = sprite.uv[0].x + (sprite.uv[1].x - sprite.uv[0].x) * rate;
		uvs[1].y = sprite.uv[1].y;

		uvs[2].x = sprite.uv[2].x;
		uvs[2].y = sprite.uv[2].y;

		uvs[3].x = sprite.uv[2].x + (sprite.uv[3].x - sprite.uv[2].x) * rate;
		uvs[3].y = sprite.uv[3].y;
		return uvs;
	}

	public override void Destroy()
	{
		uvs = null;
		base.Destroy();
	}
}
