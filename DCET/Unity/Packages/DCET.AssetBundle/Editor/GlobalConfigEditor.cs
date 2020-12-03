using DCETRuntime;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace DCETEditor
{
	public class GlobalProtoEditor: EditorWindow
    {
        private const string path = @"./Assets/Res/GlobalProto.txt";
        private GlobalProto globalProto;

        [MenuItem("Tools/Start Global Config")]
        public static void ShowWindow()
        {
            GetWindow<GlobalProtoEditor>();
        }

        public void Awake()
        {
            Load();
        }

        private void Load()
        {
            if(globalProto != null)
            {
                return;
            }

            if (File.Exists(path))
            {
                globalProto = MongoHelper.FromJson<GlobalProto>(File.ReadAllText(path));
            }

            if (globalProto == null)
            {
                globalProto = new GlobalProto();
            }
        }

        public void OnGUI()
        {
            Load();

            globalProto.AssetBundleServerUrl = EditorGUILayout.TextField("资源路径:", globalProto.AssetBundleServerUrl);
            globalProto.Address = EditorGUILayout.TextField("服务器地址:", globalProto.Address);

            if (GUILayout.Button("保存"))
            {
                File.WriteAllText(path, MongoHelper.ToJson(globalProto));
                AssetDatabase.Refresh();
            }
        }
    }
}
