using UnityEditor;
using DCETRuntime;
using UnityEngine;

namespace DCETEditor
{
    [CustomEditor(typeof(PrefabLightmapData))]
    public class PrefabLightmapDataInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (target)
            {
                var prefabLightmapData = target as PrefabLightmapData;

                if (prefabLightmapData)
                {
                    prefabLightmapData.Set();

                    GUILayout.BeginHorizontal();

                    if (GUILayout.Button("Clear", EditorStyles.miniButtonLeft))
                    {
                        prefabLightmapData.Clear();
                    }

                    if (GUILayout.Button("Save", EditorStyles.miniButtonRight))
                    {
                        prefabLightmapData.Save();
                    }

                    GUILayout.EndHorizontal();
                }
            }
        }
    }
}