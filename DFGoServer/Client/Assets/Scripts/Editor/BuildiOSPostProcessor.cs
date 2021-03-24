#if UNITY_IOS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEditor.iOS.Xcode;

public class BuildiOSPostProcessor
{
	[PostProcessBuildAttribute(0)]
	public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
	{
		if (target != BuildTarget.iOS)
		{
			return;
		}
		Debug.Log("BuiltProject: " + pathToBuiltProject);
		EditProj(pathToBuiltProject);
	}

	static void EditProj(string pathToBuiltProject)
	{
		string projPath = pathToBuiltProject + "/Unity-iPhone.xcodeproj/project.pbxproj";
		PBXProject pbxProj = new PBXProject();
		pbxProj.ReadFromFile(projPath);
        if (BuildScript.isBuildDebug) {
            SetBuildProperty_Debug(pbxProj);
        } else {
            SetBuildProperty_Release(pbxProj);
        }

        pbxProj.WriteToFile(projPath);
	}

    static void SetBuildProperty_Debug(PBXProject pbxProj) {
        string targetGUID = pbxProj.TargetGuidByName("Unity-iPhone");
        pbxProj.SetBuildProperty(targetGUID, "ENABLE_BITCODE", "NO");
        pbxProj.SetBuildProperty(targetGUID, "CODE_SIGN_STYLE", "Manual");
        pbxProj.SetBuildProperty(targetGUID, "CODE_SIGN_IDENTITY", "iPhone Developer");
        pbxProj.SetBuildProperty(targetGUID, "PROVISIONING_PROFILE_SPECIFIER", "taro2");
        pbxProj.SetBuildProperty(targetGUID, "DEVELOPMENT_TEAM", "43L8T889N2");
    }

    static void SetBuildProperty_Release(PBXProject pbxProj)
    {
        string targetGUID = pbxProj.TargetGuidByName("Unity-iPhone");
        pbxProj.SetBuildProperty(targetGUID, "ENABLE_BITCODE", "NO");
        pbxProj.SetBuildProperty(targetGUID, "CODE_SIGN_STYLE", "Manual");
        pbxProj.SetBuildProperty(targetGUID, "CODE_SIGN_IDENTITY", "iPhone Distribution");
        pbxProj.SetBuildProperty(targetGUID, "PROVISIONING_PROFILE_SPECIFIER", "taro-dis2");
        pbxProj.SetBuildProperty(targetGUID, "DEVELOPMENT_TEAM", "43L8T889N2");
    }

    [MenuItem("LetUs/TestBuildPostProcessorIOS")]
	public static void TestBuildPostProcessorIOS(){
		EditProj(Application.dataPath.Replace("Assets", "") + "Release/iOS/build_project");
	}
}
#endif