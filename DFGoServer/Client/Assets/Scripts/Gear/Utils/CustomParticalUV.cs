using UnityEngine;

[ExecuteAlways]
public class CustomParticalUV : MonoBehaviour
{
    private Vector2 lastTiling = Vector2.one;
    private Vector2 lastOffset = Vector2.zero;
    public Vector2 Tiling = Vector2.one;
    public Vector2 Offset = Vector2.zero;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (material)
        {
            if (!lastTiling.Equals(Tiling))
            {
                material.SetTextureScale("_MainTex", Tiling);
                GetComponent<Renderer>().material = material;

            }

            if (!lastOffset.Equals(Offset))
            {
                material.SetTextureOffset("_MainTex", Offset);
                GetComponent<Renderer>().material = material;

            }
        }
    }
}