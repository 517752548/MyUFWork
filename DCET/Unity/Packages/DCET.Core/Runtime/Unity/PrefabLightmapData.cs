using System.Collections.Generic;
using UnityEngine;

namespace DCETRuntime
{
    public class PrefabLightmapData : MonoBehaviour
    {
        [System.Serializable]
        public struct MeshRendererLightmapData
        {
            public MeshRenderer renderer;
            public int lightmapIndex;
            public Vector4 lightmapOffsetScale;
            public int realtimeLightmapIndex;
            public Vector4 realtimeLightmapScaleOffset;
        }

        [System.Serializable]
        public struct TerrainLightmapData
        {
            public Terrain terrain;
            public int lightmapIndex;
            public Vector4 lightmapOffsetScale;
            public int realtimeLightmapIndex;
            public Vector4 realtimeLightmapScaleOffset;
        }

        public List<MeshRendererLightmapData> rendererLightmapDatas = new List<MeshRendererLightmapData>();
        public List<TerrainLightmapData> terrainLightmapDatas = new List<TerrainLightmapData>();

        private bool isSet = false;

        void Awake()
        {
            Set();
        }

        public void Clear()
        {
            rendererLightmapDatas.Clear();
            terrainLightmapDatas.Clear();
        }

        public void Save()
        {
            Clear();

            var meshRenderers = GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer r in meshRenderers)
            {
                var data = new MeshRendererLightmapData();
                data.renderer = r;
                data.lightmapOffsetScale = r.lightmapScaleOffset;
                data.lightmapIndex = r.lightmapIndex;
                data.realtimeLightmapIndex = r.realtimeLightmapIndex;
                data.realtimeLightmapScaleOffset = r.realtimeLightmapScaleOffset;
                rendererLightmapDatas.Add(data);
            }

            var terrains = GetComponentsInChildren<Terrain>();

            foreach (var t in terrains)
            {
                var data = new TerrainLightmapData();
                data.terrain = t;
                data.lightmapOffsetScale = t.lightmapScaleOffset;
                data.lightmapIndex = t.lightmapIndex;
                data.realtimeLightmapIndex = t.realtimeLightmapIndex;
                data.realtimeLightmapScaleOffset = t.realtimeLightmapScaleOffset;
                terrainLightmapDatas.Add(data);
            }
        }

        public void Set()
        {
            if (isSet)
            {
                return;
            }

            foreach (var item in rendererLightmapDatas)
            {
                if (!item.renderer)
                {
                    continue;
                }

                item.renderer.lightmapIndex = item.lightmapIndex;
                item.renderer.lightmapScaleOffset = item.lightmapOffsetScale;
                item.renderer.realtimeLightmapIndex = item.realtimeLightmapIndex;
                item.renderer.realtimeLightmapScaleOffset = item.realtimeLightmapScaleOffset;
            }

            foreach (var item in terrainLightmapDatas)
            {
                if (!item.terrain)
                {
                    continue;
                }

                item.terrain.lightmapIndex = item.lightmapIndex;
                item.terrain.lightmapScaleOffset = item.lightmapOffsetScale;
                item.terrain.realtimeLightmapIndex = item.realtimeLightmapIndex;
                item.terrain.realtimeLightmapScaleOffset = item.realtimeLightmapScaleOffset;
            }

            isSet = true;
        }

        public static void Init(Object _object)
        {
            if (_object is GameObject)
            {
                var gameObject = _object as GameObject;

                var datas = gameObject.GetComponentsInChildren<PrefabLightmapData>();

                if (datas != null)
                {
                    foreach (var data in datas)
                    {
                        data.Set();
                    }
                }
            }
        }
    }
}