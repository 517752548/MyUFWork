using DCETRuntime;
using UnityEditor;
using UnityEngine;

namespace DCETEditor
{
    [CustomEditor(typeof(ReferenceLoader))]
    public class ReferenceLoaderInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (target)
            {
                var referenceLoader = target as ReferenceLoader;

                if (referenceLoader)
                {
                    GUILayout.BeginHorizontal();

                    if (GUILayout.Button("Clear", EditorStyles.miniButtonLeft))
                    {
                        Clear(referenceLoader);
                    }

                    if (GUILayout.Button("Load", EditorStyles.miniButtonRight))
                    {
                        Load(referenceLoader);
                    }

                    GUILayout.EndHorizontal();
                }
            }
        }

        public static GameObject Load(ReferenceLoader referenceLoader)
        {
            Clear(referenceLoader);

            if (referenceLoader && referenceLoader.prefab)
            {
                return Instantiate(referenceLoader.prefab, referenceLoader.transform);
            }

            return null;
        }

        public static void Clear(ReferenceLoader referenceLoader)
        {
            if (!referenceLoader)
            {
                return;
            }

            while (referenceLoader.transform.childCount > 0)
            {
                DestroyImmediate(referenceLoader.transform.GetChild(0).gameObject);
            }
        }
    }
}