using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BetaFramework;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Build;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEditor.Build.Pipeline.Utilities;
using UnityEngine;

namespace FastBundle.Editor
{
    public static class AddressablesBundleBuildScript
    {
        //private static Dictionary<string,AddressableAssetGroup> groupDict = new Dictionary<string, AddressableAssetGroup>();

        public static void CreatConfig()
        {
            AddressablesRules rules = new AddressablesRules();
            Dictionary<string, BuildAddressablesData> bundles = rules.GetBuilds();
            SaveJsonManifest(FrameWorkConst.addressAssetsManifesttxt, bundles);
            AssetDatabase.ImportAsset(FrameWorkConst.addressAssetsManifesttxt, ImportAssetOptions.ForceUpdate);
            AssetDatabase.Refresh();
        }

        public static void AddFileToAddressablesDevelop()
        {
            AddressablesRules rules = new AddressablesRules();
            Dictionary<string, BuildAddressablesData> bundles = rules.GetBuilds();
            AddressableAssetSettings aaSettings = AddressableAssetSettingsDefaultObject.GetSettings(false);
            AddressableAssetGroup group = null;
            List<AddressableAssetGroup> needRemove = new List<AddressableAssetGroup>();
            for (int i = 0; i < aaSettings.groups.Count; i++)
            {
                if (aaSettings.groups[i] != null && !aaSettings.groups[i].ReadOnly)
                {
                    aaSettings.groups[i].Name += "_Remove";
                    needRemove.Add(aaSettings.groups[i]);
                }
            }

            //清理重名group
            foreach (string key in bundles.Keys)
            {
                group = aaSettings.groups.Find(x => x.Name == bundles[key].GroupName);
                if (group != null)
                {
                    //group.Name += "_Remove";
                    aaSettings.RemoveGroup(group);
                    group = null;
                }
            }

            foreach (string key in bundles.Keys)
            {
                group = aaSettings.groups.Find(x => x.Name == bundles[key].GroupName);
                if (group == null)
                {
                    group = aaSettings.CreateGroup(bundles[key].GroupName, false, false, false, null);
                    BundledAssetGroupSchema schema = group.AddSchema<BundledAssetGroupSchema>();
                    schema.Compression = BundledAssetGroupSchema.BundleCompressionMode.Uncompressed;
                    schema.BundleMode = BundledAssetGroupSchema.BundlePackingMode.PackSeparately;
                    schema.UseAssetBundleCache = true;
                    schema.UseAssetBundleCrc = true;
                    group = null;
                }
            }


            bool postEvent = false;
            foreach (string key in bundles.Keys)
            {
                int count = 0;
                int MaxCount = bundles[key].entitys.Count;
                group = aaSettings.groups.Find(x => x.Name == bundles[key].GroupName);
                foreach (string entitysKey in bundles[key].entitys.Keys)
                {
                    count++;
                    if (count >= bundles.Count - 5)
                    {
                        postEvent = true;
                    }
                    else
                    {
                        postEvent = false;
                    }

                    if (count % 8 == 0)
                        if (UnityEditor.EditorUtility.DisplayCancelableProgressBar(
                            string.Format("Collecting... [{0}/{1}]", count, MaxCount), entitysKey,
                            count * 1f / MaxCount))
                        {
                            break;
                        }

                    string guid = AssetDatabase.AssetPathToGUID(bundles[key].entitys[entitysKey].filestring);
                    AddressableAssetEntry entity = aaSettings.CreateOrMoveEntry(guid, group, false, postEvent);
                    if (entity.address != entitysKey)
                    {
                        entity.SetAddress(entitysKey, postEvent);
                    }

                    entity.labels.Clear();
                    for (int i = 0; i < bundles[key].Lable.Length; i++)
                    {
                        aaSettings.AddLabel(bundles[key].Lable[i]);
                        entity.labels.Add(bundles[key].Lable[i]);
                        //entity.SetLabel(, true,false,postEvent);
                    }
                }
            }

            for (int i = 0; i < needRemove.Count; i++)
            {
                aaSettings.RemoveGroup(needRemove[i]);
            }

            UnityEditor.EditorUtility.ClearProgressBar();
        }

        public static void BuildBundle()
        {
            AddressablesBundleBuildScript.CreatConfig();
            AddressableAssetSettings.CleanPlayerContent();
            BuildCache.PurgeCache(false);
            AddressableAssetSettingsDefaultObject.Settings.ActivePlayerDataBuilderIndex = 3;
            AddressableAssetSettings.BuildPlayerContent();
            FrameworkMenuTool.MoveToStreaming();
        }
        public static void AddFileToAddressables()
        {
            AddressablesRules rules = new AddressablesRules();
            Dictionary<string, BuildAddressablesData> bundles = rules.GetBuilds();
            AddressableAssetSettings aaSettings = AddressableAssetSettingsDefaultObject.GetSettings(false);
            AddressableAssetGroup group = null;
            //清理错误group
            for (int i = aaSettings.groups.Count - 1; i >= 0; i--)
            {
                var g = aaSettings.groups[i];
                if (g == null || g.entries.Count == 0)
                {
                    aaSettings.RemoveGroup(g);
                }
            }

            foreach (string key in bundles.Keys)
            {
                group = aaSettings.groups.Find(x => x.Name == bundles[key].GroupName);
                if (group == null)
                {
                    group = aaSettings.CreateGroup(bundles[key].GroupName, false, false, false, null);
                }
                BundledAssetGroupSchema schema = group.GetSchema<BundledAssetGroupSchema>();
                if (schema == null)
                {
                    schema = group.AddSchema<BundledAssetGroupSchema>();
                }
                ContentUpdateGroupSchema contentUpdateGroupSchema = group.GetSchema<ContentUpdateGroupSchema>();
                if (contentUpdateGroupSchema == null)
                {
                    contentUpdateGroupSchema = group.AddSchema<ContentUpdateGroupSchema>();
                }
                schema.Compression = BundledAssetGroupSchema.BundleCompressionMode.LZ4;
                if (bundles[key].packageType == "PackSeparately")
                {
                    schema.BundleMode = BundledAssetGroupSchema.BundlePackingMode.PackSeparately;
                }
                else if (bundles[key].packageType == "PackTogether")
                {
                    schema.BundleMode = BundledAssetGroupSchema.BundlePackingMode.PackTogether;
                }
                else if (bundles[key].packageType == "PackTogetherByLabel")
                {
                    schema.BundleMode = BundledAssetGroupSchema.BundlePackingMode.PackTogetherByLabel;
                }
                schema.UseAssetBundleCache = true;
                schema.UseAssetBundleCrc = true;
                schema.UseAssetBundleCrcForCachedBundles = true;

                if (bundles[key].ResType == "online")
                {
                    schema.BuildPath.SetVariableByName(group.Settings, AddressableAssetSettings.kRemoteBuildPath);
                    schema.LoadPath.SetVariableByName(group.Settings, AddressableAssetSettings.kRemoteLoadPath);
                    schema.BundleNaming = BundledAssetGroupSchema.BundleNamingStyle.AppendHash;
                    contentUpdateGroupSchema.StaticContent = false;
                }
                else
                {
                    schema.BuildPath.SetVariableByName(group.Settings, AddressableAssetSettings.kLocalBuildPath);
                    schema.LoadPath.SetVariableByName(group.Settings, AddressableAssetSettings.kLocalLoadPath);
                    schema.BundleNaming = BundledAssetGroupSchema.BundleNamingStyle.NoHash;
                    contentUpdateGroupSchema.StaticContent = true;
                }
            }

            foreach (string key in bundles.Keys)
            {
                int count = 0;
                int MaxCount = bundles[key].entitys.Count;
                group = aaSettings.groups.Find(x => x.Name == bundles[key].GroupName);
                foreach (string entitysKey in bundles[key].entitys.Keys)
                {
                    count++;
                    if (count % 3 == 0)
                        if (UnityEditor.EditorUtility.DisplayCancelableProgressBar(
                            string.Format("Collecting... [{0}/{1}]", count, MaxCount), entitysKey,
                            count * 1f / MaxCount))
                        {
                            break;
                        }

                    string guid = AssetDatabase.AssetPathToGUID(bundles[key].entitys[entitysKey].filestring);
                    AddressableAssetEntry entity = aaSettings.CreateOrMoveEntry(guid, group);
                    entity.SetAddress(entitysKey);
                    for (int i = 0; i < bundles[key].Lable.Length; i++)
                    {
                        if (bundles[key].Lable[i].Contains("#"))
                        {
                            if (!string.IsNullOrEmpty(bundles[key].entitys[entitysKey].folderlabel))
                            {
                                aaSettings.AddLabel(bundles[key].entitys[entitysKey].folderlabel);
                                entity.SetLabel(bundles[key].entitys[entitysKey].folderlabel, true);
                            }
                        }
                        else
                        {
                            aaSettings.AddLabel(bundles[key].Lable[i]);
                            entity.SetLabel(bundles[key].Lable[i], true);
                        }
                    }
                }
            }

            UnityEditor.EditorUtility.ClearProgressBar();
        }

        public static void AddFileToAddressablesHotUpdate()
        {
            AddressablesRules rules = new AddressablesRules();
            Dictionary<string, BuildAddressablesData> bundles = rules.GetBuilds();
            AddressableAssetSettings aaSettings = AddressableAssetSettingsDefaultObject.GetSettings(false);
            AddressableAssetGroup group = null;
            //清理重名group
            // foreach (string key in bundles.Keys)
            // {
            //     group = aaSettings.groups.Find(x => x.Name == bundles[key].GroupName);
            //     if (group != null)
            //     {
            //         aaSettings.RemoveGroup(group);
            //         group = null;
            //     }
            // }

            foreach (string key in bundles.Keys)
            {
                group = aaSettings.groups.Find(x => x.Name == bundles[key].GroupName);
                if (group == null)
                {
                    if (bundles[key].ResType == "online")
                    {
                        group = aaSettings.CreateGroup(bundles[key].GroupName, false, false, false, null);
                        BundledAssetGroupSchema schema = group.AddSchema<BundledAssetGroupSchema>();
                        schema.Compression = BundledAssetGroupSchema.BundleCompressionMode.LZ4;
                        if (bundles[key].packageType == "PackSeparately")
                        {
                            schema.BundleMode = BundledAssetGroupSchema.BundlePackingMode.PackSeparately;
                        }
                        else if (bundles[key].packageType == "PackTogether")
                        {
                            schema.BundleMode = BundledAssetGroupSchema.BundlePackingMode.PackTogether;
                        }
                        else if (bundles[key].packageType == "PackTogetherByLabel")
                        {
                            schema.BundleMode = BundledAssetGroupSchema.BundlePackingMode.PackTogetherByLabel;
                        }
                        schema.BuildPath.SetVariableByName(group.Settings, AddressableAssetSettings.kRemoteBuildPath);
                        schema.LoadPath.SetVariableByName(group.Settings, AddressableAssetSettings.kRemoteLoadPath);
                        schema.UseAssetBundleCache = true;
                        schema.UseAssetBundleCrc = true;
                        schema.Timeout = 200;
                        schema.RetryCount = 5;
                        ContentUpdateGroupSchema contentUpdateGroupSchema = group.AddSchema<ContentUpdateGroupSchema>();
                        contentUpdateGroupSchema.StaticContent = false;
                        group = null;
                    }
                    else
                    {
                        group = aaSettings.CreateGroup(bundles[key].GroupName, false, false, false, null);
                        BundledAssetGroupSchema schema = group.AddSchema<BundledAssetGroupSchema>();
                        schema.Compression = BundledAssetGroupSchema.BundleCompressionMode.LZ4;
                        if (bundles[key].packageType == "PackSeparately")
                        {
                            schema.BundleMode = BundledAssetGroupSchema.BundlePackingMode.PackSeparately;
                        }
                        else if (bundles[key].packageType == "PackTogether")
                        {
                            schema.BundleMode = BundledAssetGroupSchema.BundlePackingMode.PackTogether;
                        }
                        else if (bundles[key].packageType == "PackTogetherByLabel")
                        {
                            schema.BundleMode = BundledAssetGroupSchema.BundlePackingMode.PackTogetherByLabel;
                        }

                        //全部标记静态资源
                        ContentUpdateGroupSchema contentUpdateGroupSchema = group.AddSchema<ContentUpdateGroupSchema>();
                        contentUpdateGroupSchema.StaticContent = true;
                        // if (bundles[key].canUpdate)
                        // {
                        //      ContentUpdateGroupSchema contentUpdateGroupSchema =  group.AddSchema<ContentUpdateGroupSchema>();
                        //      contentUpdateGroupSchema.StaticContent = true;
                        // }

                        schema.UseAssetBundleCache = true;
                        schema.UseAssetBundleCrc = true;
                        group = null;
                    }

                }
            }


            foreach (string key in bundles.Keys)
            {
                int count = 0;
                int MaxCount = bundles[key].entitys.Count;
                group = aaSettings.groups.Find(x => x.Name == bundles[key].GroupName);
                foreach (string entitysKey in bundles[key].entitys.Keys)
                {
                    count++;
                    if (count % 3 == 0)
                        if (UnityEditor.EditorUtility.DisplayCancelableProgressBar(
                            string.Format("Collecting... [{0}/{1}]", count, MaxCount), entitysKey,
                            count * 1f / MaxCount))
                        {
                            break;
                        }

                    string guid = AssetDatabase.AssetPathToGUID(bundles[key].entitys[entitysKey].filestring);
                    AddressableAssetEntry entity = aaSettings.CreateOrMoveEntry(guid, group);
                    entity.SetAddress(entitysKey);
                    for (int i = 0; i < bundles[key].Lable.Length; i++)
                    {
                        aaSettings.AddLabel(bundles[key].Lable[i]);
                        entity.SetLabel(bundles[key].Lable[i], true);
                    }
                }
            }

            UnityEditor.EditorUtility.ClearProgressBar();
        }


        internal static void UpdateWordLibrary()
        {
            string groupName = "WordLibrary";
            UnityEditor.EditorUtility.DisplayCancelableProgressBar("更新词库...", "", 0);
            AddressableAssetSettings aaSettings = AddressableAssetSettingsDefaultObject.GetSettings(false);
            AddressableAssetGroup group = null;
            group = aaSettings.groups.Find(x => x.Name == groupName);
            if (group != null)
            {
                aaSettings.RemoveGroup(group);
                group = null;
            }
            group = aaSettings.CreateGroup(groupName, false, false, false, null);
            group.AddSchema<BundledAssetGroupSchema>();

            string levelDir = string.Format("{0}/AssetsPackage/AnsycLoad/CodyLevel", Application.dataPath);
            if (!Directory.Exists(levelDir))
            {
                Debug.LogError("路径不存在 " + levelDir);
                Directory.CreateDirectory(levelDir);
            }
            else
            {
                var files = Directory.GetFiles(levelDir);
                var index = 0;
                foreach (var item in files)
                {
                    index++;
                    UnityEditor.EditorUtility.DisplayCancelableProgressBar("更新词库...", Path.GetFileName(item), index / (float)files.Length);
                    var extention = Path.GetExtension(item);
                    if (extention.Equals(".txt"))
                    {
                        string guid = AssetDatabase.AssetPathToGUID(string.Format("Assets/AssetsPackage/AnsycLoad/CodyLevel/{0}", Path.GetFileName(item)));
                        AddressableAssetEntry entity = aaSettings.CreateOrMoveEntry(guid, group);
                        entity.SetAddress(Path.GetFileName(item));
                        bool result = entity.SetLabel("WordLibrary", true);
                        Debug.Log("set label result " + result);
                    }
                }
            }

            UnityEditor.EditorUtility.ClearProgressBar();
        }

        static void SaveJsonManifest(string path, Dictionary<string, BuildAddressablesData> bundles)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            AddressablesConfig config = new AddressablesConfig();

            foreach (string bundlesKey in bundles.Keys)
            {
                foreach (string entitysKey in bundles[bundlesKey].entitys.Keys)
                {
                    config.AddGroup(bundles[bundlesKey].GroupName, entitysKey);
                    for (int i = 0; i < bundles[bundlesKey].Lable.Length; i++)
                    {
                        config.AddLable(bundles[bundlesKey].Lable[i], entitysKey);
                    }
                }
            }

            using (var writer = new StreamWriter(path))
            {
                writer.Write(JsonConvert.SerializeObject(config));
                writer.Flush();
                writer.Close();
            }

            CreatAssetViewConst(bundles);
        }

        public static void CreatAssetViewConst(Dictionary<string, BuildAddressablesData> bundles)
        {
            string[] resSpit;
            string labs;
            string temp = "public class ViewConst{0}{1}{2}";
            StringBuilder build = new StringBuilder();
            build.AppendLine("");
            foreach (string bundlesKey in bundles.Keys)
            {
                labs = "";
                for (int i = 0; i < bundles[bundlesKey].Lable.Length; i++)
                {
                    labs += bundles[bundlesKey].Lable[i];
                    labs += ";";
                }

                string des = string.Format("//Group：{0} ;Label:{1}", bundles[bundlesKey].GroupName, labs);
                foreach (string entitysKey in bundles[bundlesKey].entitys.Keys)
                {
                    resSpit = entitysKey.Split('.');
                    build.AppendLine(des);
                    build.AppendLine(string.Format("     public const string {0} = {2}{1}{2};",
                        string.Format("{0}_{1}", resSpit[1].Replace("-", "_"), resSpit[0].Replace("-", "_")), entitysKey, "\""));
                }
            }

            temp = string.Format(temp, "{", build.ToString(), "}");
            if (File.Exists(Application.dataPath + "/ViewConst.cs"))
            {
                File.Delete(Application.dataPath + "/ViewConst.cs");
            }

            FileUtils.CreateTextFile(Application.dataPath + "/ViewConst.cs", temp);
        }
        static public void CopyAssetBundlesTo(string outputPath)
        {
            // Clear streaming assets folder.
            //            FileUtil.DeleteFileOrDirectory(Application.streamingAssetsPath);
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            string outputFolder = "";

            // Setup the source folder for assetbundles.
            var source =
                Path.Combine(Path.Combine(System.Environment.CurrentDirectory, AssetBundleUtility.AssetBundlesOutputPath),
                    outputFolder);
            if (!System.IO.Directory.Exists(source))
                Debug.Log("No assetBundle output folder, try to build the assetBundles first.");

            // Setup the destination folder for assetbundles.
            var destination = System.IO.Path.Combine(outputPath, outputFolder);
            if (System.IO.Directory.Exists(destination))
                FileUtil.DeleteFileOrDirectory(destination);

            FileUtil.CopyFileOrDirectory(source, destination);
        }

    }

}