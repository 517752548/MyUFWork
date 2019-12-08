using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BundleMenuTool
{
    [MenuItem ("Fast/Bundle/ReInit")]
    static void CopyAssetPath ()
    {
        //生成资源根路径
        DirectoryTool.CreatIfNotExists(Application.dataPath + FrameWorkConst.FastBundleResFolder);
        DirectoryTool.CreatIfNotExists(Application.dataPath + FrameWorkConst.FastBundleResConfigFolder);
        AssetDatabase.Refresh();
    }  
}
