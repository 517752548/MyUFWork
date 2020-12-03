using UnityEditor;
using UnityEngine;

namespace DCETEditor
{
    public class ClearEditor : UnityEditor.Editor
    {
        [MenuItem("Tools/Clear/清除选中项所有Renderer的阴影投射")]
        public static void SetShadowCastingModeOff()
        {
            var gameObjects = Selection.objects;

            foreach (var go in gameObjects)
            {
                if(go is GameObject)
                {
                    var renderers = (go as GameObject).GetComponentsInChildren<Renderer>(true);

                    foreach (var item in renderers)
                    {
                        item.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    }
                }
            }
        }

        [MenuItem("Tools/Clear/清除选中项所有Renderer的阴影接收")]
        public static void SetReceiveShadowsFalse()
        {
            var gameObjects = Selection.objects;

            foreach (var go in gameObjects)
            {
                if (go is GameObject)
                {
                    var renderers = (go as GameObject).GetComponentsInChildren<Renderer>(true);

                    foreach (var item in renderers)
                    {
                        item.receiveShadows = false;
                    }
                }
            }
        }

        [MenuItem("Tools/Clear/清除选中项所有的空Animator")]
        public static void ClearMissingAnimator()
        {
            var gameObjects = Selection.objects;

            foreach (var go in gameObjects)
            {
                if (go is GameObject)
                {
                    var animators = (go as GameObject).GetComponentsInChildren<Animator>(true);

                    foreach (var item in animators)
                    {
                        if (!item.runtimeAnimatorController)
                        {
                            DestroyImmediate(item);
                        }
                    }
                }
            }
        }

        [MenuItem("Tools/Clear/清除选中项所有的阴影接收和投射、空Animator、丢失的脚本")]
        public static void ClearAll()
        {
            SetReceiveShadowsFalse();
            SetShadowCastingModeOff();
            ClearMissingAnimator();
            ClearMissingScripts();
            ApplyAllPrefab();
        }

        [MenuItem("Tools/Clear/清除丢失的脚本")]
        public static void ClearMissingScripts()
        {
            var gameObjects = Selection.objects;

            foreach (GameObject item in gameObjects)
            {
                ClearMissingScript(item);
            }

            AssetDatabase.Refresh();
        }

        private static void ClearMissingScript(GameObject item)
        {
            if (!item)
            {
                return;
            }

            SerializedObject so = new SerializedObject(item);
            var soProperties = so.FindProperty("m_Component");
            var components = item.GetComponents<Component>();
            int propertyIndex = 0;

            foreach (var c in components)
            {
                if (c == null)
                {
                    soProperties.DeleteArrayElementAtIndex(propertyIndex);
                }

                ++propertyIndex;
            }

            so.ApplyModifiedProperties();

            foreach (Transform t in item.transform)
            {
                ClearMissingScript(t.gameObject);
            }
        }

        [MenuItem("Tools/Clear/保存所有选中项预设")]
        public static void ApplyAllPrefab()
        {
            var gameObjects = Selection.objects;

            foreach (var go in gameObjects)
            {
                PrefabUtility.ApplyPrefabInstance(go as GameObject, InteractionMode.AutomatedAction);
            }

            AssetDatabase.Refresh();
        }
    }
}