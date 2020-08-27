using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 空image   不渲染  只有image的功能
/// </summary>
public class EmptyImage : MaskableGraphic
{
    protected EmptyImage ()
    {
        useLegacyMeshGeneration = false;
    }

    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        toFill.Clear();
    }
}
