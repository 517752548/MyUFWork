using UnityEngine;
using DG.Tweening;
using UnityEditor;

public static class HybridUITweenMenuItems
{
	[MenuItem("GameObject/Play Children HybridUI Tween", false, 30)]
	public static void PlayChildrenHybridUITween()
	{
		GameObject go = Selection.activeGameObject;
		if (go == null)
			return;
		HybridUITween[] ht = go.GetComponentsInChildren<HybridUITween>();
		for (int i = 0; i < ht.Length; i++)
		{

			if (!ht[i].IsPlaying)
			{
				Tween t = ht[i].Execute();
			}
		}
	}
}
