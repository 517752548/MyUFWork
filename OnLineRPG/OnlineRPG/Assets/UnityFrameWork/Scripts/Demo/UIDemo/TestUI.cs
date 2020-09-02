using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using BetaFramework;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using Newtonsoft.Json;
using UnityEngine.ResourceManagement.AsyncOperations;
using com.forads.sdk;

public class TestUI : MonoBehaviour
{
	public AsyncOperationHandle<TextAsset> op;

	private void Start()
	{
		
	}

	void Instance_KeyboardAction(string obj)
	{
		Debug.LogError("click keyboard " + obj);
	}

	public void RewardAd()
	{
		if (FORADS.getInstance().isLoaded("141") == false) {
			FORADS.getInstance().loadAd("141");
		} else {
			FORADS.getInstance().displayAd("141");
		}
	}

	public void BtnAction() {
		Debug.LogError("---------------------");
		var categoryIds = new List<int>() { 1, 2, 3 };
		AppEngine.SSystemManager.GetSystem<WorLibrarySystem>().GetDailyLevel(categoryIds, (obj) => {
			Dictionary<int, string> result = new Dictionary<int, string>();
			Dictionary<int, int> counts = new Dictionary<int, int>();
			for (int i = 0; i < categoryIds.Count; i++) {
				result[categoryIds[i]] = "";
				counts[categoryIds[i]] = 0;
			}
			foreach (var x in obj) {
				result[x.CategoryID] = string.Format("{0},{1}", result[x.CategoryID], x.ID);
				counts[x.CategoryID] += 1;
			}
			foreach (var kvp in result) {
				Debug.LogError(string.Format("<color=#942192>获取到 {0},{1},共{2}个</color>", kvp.Key, kvp.Value, counts[kvp.Key]));
			}
		});
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A)) {
			//var oper = Addressables.LoadAssetAsync<CategotyQuestionContainer>("Category_1_1.asset");
			//Debug.Log("oper status " + oper.Status);
			//oper.Completed += (obj) => {
			//	if (((AsyncOperationHandle<CategotyQuestionContainer>)obj).Status == AsyncOperationStatus.Succeeded) {
			//		var xx = Addressables.LoadAssetAsync<CategotyQuestionContainer>("Category_1_1.asset");
			//		Debug.Log("xx status " + xx.Status);
			//	}
			//};
			Debug.LogError("---------------------");
			var categoryIds = new List<int>() { 1};
			AppEngine.SSystemManager.GetSystem<WorLibrarySystem>().GetDailyLevel(categoryIds, (obj) => {
				if (obj != null) {
					Dictionary<int, string> result = new Dictionary<int, string>();
					Dictionary<int, int> counts = new Dictionary<int, int>();
					for (int i = 0; i < categoryIds.Count; i++) {
						result[categoryIds[i]] = "";
						counts[categoryIds[i]] = 0;
					}
					foreach (var x in obj) {
						result[x.CategoryID] = string.Format("{0},{1}", result[x.CategoryID], x.ID);
						counts[x.CategoryID] += 1;
					}
					foreach (var kvp in result) {
						Debug.LogError(string.Format("<color=#942192>获取到 {0},{1},共{2}个</color>", kvp.Key, kvp.Value, counts[kvp.Key]));
					}
				}
			});
		}

		if (Input.GetKeyDown(KeyCode.B)) {
			List<NotEnoughCateory> allNEC = new List<NotEnoughCateory>();
			NotEnoughCateory notEnoughCateory = new NotEnoughCateory();
			if (allNEC.Contains(notEnoughCateory)) {
				allNEC.Remove(notEnoughCateory);
			} else {
				Debug.Log("别费劲了，他不包含");
			}
		}
	}
	struct NotEnoughCateory
	{
		public int categoryId;
		public int beginEntityIndex;//总是获取把该实体看成位于整个词库列表的位置的索引（从0开始）
		public int selectEntityCount;
		public bool entityLow;//实体数目小于OneFileEntityCount,认定是最后一个文件
		public int lowFileEntityCount;
	};
}