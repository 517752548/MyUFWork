using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/TextGradient")]
[RequireComponent(typeof(Text))]
public class UICustomTextGradient : BaseMeshEffect
{
	public Color topColor = Color.white;
	public Color bottomColor = Color.black;

	//�����Լ���ӵĿ��������ƶ����ԣ���ʱ���Ž��䲻˳�ۣ�����ƫ��߻��ߵ��ˣ��Ϳ���ͨ�����ȥ����
	[RangeAttribute(0, 1)]
	public float center = 0.5f;

	public override void ModifyMesh(VertexHelper vh)
	{
		if (!IsActive())
		{
			return;
		}

		var count = vh.currentVertCount;
		if (count == 0)
			return;

		var vertexs = new List<UIVertex>();
		for (var i = 0; i < count; i++)
		{
			var vertex = new UIVertex();
			vh.PopulateUIVertex(ref vertex, i);
			vertexs.Add(vertex);
		}

		var topY = vertexs[0].position.y;
		var bottomY = vertexs[0].position.y;

		for (var i = 1; i < count; i++)
		{
			var y = vertexs[i].position.y;
			if (y > topY)
			{
				topY = y;
			}
			else if (y < bottomY)
			{
				bottomY = y;
			}
		}

		var height = topY - bottomY;
		for (var i = 0; i < count; i++)
		{
			var vertex = vertexs[i];

			//ʹ�ô���������ɫ
			// var color = Color32.Lerp(bottomColor, topColor, (vertex.position.y - bottomY) / height);
			var color = CenterColor(bottomColor, topColor, (vertex.position.y - bottomY) / height);

			vertex.color = color;

			vh.SetUIVertex(vertex, i);
		}
	}
	//����һ������ɫ����ĺ�������Ҫ�������ĵ�λ��
	private Color CenterColor(Color bc, Color tc, float time)
	{
		if (center == 0)
		{
			return bc;
		}
		else if (center == 1)
		{
			return tc;
		}
		else
		{
			var centerColor = Color.Lerp(bottomColor, topColor, 0.5f);
			var resultColor = tc;
			if (time < center)
			{
				resultColor = Color.Lerp(bottomColor, centerColor, time / center);
			}
			else
			{
				resultColor = Color.Lerp(centerColor, topColor, (time - center) / (1 - center));
			}
			return resultColor;
		}
	}
}
