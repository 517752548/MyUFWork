using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/Gradient")]
public class Gradient : BaseMeshEffect
{
    [SerializeField] private Color32 topColor = Color.white;

    [SerializeField] private Color32 bottomColor = Color.black;

    [SerializeField] private bool _Horizontal = false;

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive())
        {
            return;
        }

        var vertexList = new List<UIVertex>();
        vh.GetUIVertexStream(vertexList);
        int count = vertexList.Count;
        if (count == 0)
        {
            return;
        }
        if (_Horizontal == false)
        {
            ApplyGradient(vertexList, 0, count);
        }
        else
        {
            ApplyGradientX(vertexList, 0, count);
        }

        vh.Clear();
        vh.AddUIVertexTriangleStream(vertexList);
    }

    private void ApplyGradient(List<UIVertex> vertexList, int start, int end)
    {
        float bottomY = vertexList[0].position.y;
        float topY = vertexList[0].position.y;
        for (int i = start; i < end; ++i)
        {
            float y = vertexList[i].position.y;
            if (y > topY)
            {
                topY = y;
            }
            else if (y < bottomY)
            {
                bottomY = y;
            }
        }

        float uiElementHeight = topY - bottomY;
        for (int i = start; i < end; ++i)
        {
            UIVertex uiVertex = vertexList[i];
            uiVertex.color = Color32.Lerp(bottomColor, topColor, (uiVertex.position.y - bottomY) / uiElementHeight);
            vertexList[i] = uiVertex;
        }
    }

    private void ApplyGradientX(List<UIVertex> vertexList, int start, int end)
    {
        float bottomX = vertexList[0].position.x;
        float topX = vertexList[0].position.x;
        for (int i = start; i < end; ++i)
        {
            float x = vertexList[i].position.x;
            if (x > topX)
            {
                topX = x;
            }
            else if (x < bottomX)
            {
                bottomX = x;
            }
        }

        float uiElementWidth = topX - bottomX;
        for (int i = start; i < end; ++i)
        {
            UIVertex uiVertex = vertexList[i];
            uiVertex.color = Color32.Lerp(bottomColor, topColor, (uiVertex.position.x - bottomX) / uiElementWidth);
            vertexList[i] = uiVertex;
        }
    }
}