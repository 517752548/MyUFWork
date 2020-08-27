using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Linq;

public class WorLibrarySystem : ISystem
{
	private int taskId = 0;

	public class WordLibrarySystemHandleOneFile
	{
		public WordLibrarySystemHandleOneFile(int categoryId, string fileName, int beginEntityIndex, int selectEntityCount, bool recycleRequest, bool isTryingNewFile)
		{
			CategoryId = categoryId;
			FileName = fileName;
			BeginEntityIndex = beginEntityIndex;
			SelectEntityCount = selectEntityCount;
			RecycleRequest = recycleRequest;
			IsTryingNewFile = isTryingNewFile;
		}

		public int CategoryId { get; private set; }
		public string FileName { get; private set; }
		public int BeginEntityIndex { get; private set; }
		public int SelectEntityCount { get; private set; }
		/// <summary>
		/// 在词库末尾由于无法获取下个文件，从头开始获取
		/// </summary>
		public bool RecycleRequest { get; private set; }
		/// <summary>
		/// 正在尝试新的文件，存在误认为是新文件，但是获取到0条数据（最后一个文件不是OneFileEntityCount条数）
		/// </summary>
		public bool IsTryingNewFile { get; private set; }
		/// <summary>
		/// workaround 处理误认为是新文件的情况
		/// </summary>
		public int RecycleBeginIndex { get; set; }
	}
	#region 每一天的Daily关卡
	public class WorLibrarySystemTask {//应对外部多次启动获取dailylevel api;与请求次数是1对1的关系
		int id;
		public List<int> RequestObj { get; private set; }
		public Action<List<DailyQuestionEntity>> CompleteAction { get; private set; }
		public int LoadTaskCount { get; set; }
		public List<WordLibrarySystemHandleOneFile> allRequestFiles;
		public WorLibrarySystemTask ParentTask { get; set; }//表示由于上个任务在处理阶段出现状况；而派生出来的新任务来解决状况的
		/// <summary>
		/// 由于
		/// </summary>
		public int FailedTaskCount;
		public WorLibrarySystemTask Ancestor {
			get {
				if (ParentTask == null) {
					return null;
				}
				var oneP = ParentTask;
				while (oneP.IsChildTask) {
					oneP = oneP.ParentTask;
				}
				return oneP;
			}
		}
		public bool IsChildTask {
			get {
				return ParentTask != null;
			}
		}

		public WorLibrarySystemTask(int id, List<int> requestObj, Action<List<DailyQuestionEntity>> completeAction)
		{
			this.id = id;
			this.RequestObj = requestObj;
			this.CompleteAction = completeAction;
			allRequestFiles = new List<WordLibrarySystemHandleOneFile>();
		}

		public void FinishOneLoadTask(int requestObjOneElement)
		{
			for(int i=0;i<RequestObj.Count;i++) {
				if (RequestObj[i] == requestObjOneElement) {
					LoadTaskCount--;
					break;
				}
			}
		}
	}
	#endregion
	private const int OneCategoryLevelCount = 4;
	private const int OneFileEntityCount = 20;
	private Dictionary<string, CategotyQuestionContainer> containerCache;
	private List<WorLibrarySystemTask> tasks;
	#region 数据
	private WordLibraryDailyData wordLibraryDailyData;
	#endregion
	public override void InitSystem()
	{
		containerCache = new Dictionary<string, CategotyQuestionContainer>();
		tasks = new List<WorLibrarySystemTask>();
		wordLibraryDailyData = new WordLibraryDailyData();
		wordLibraryDailyData.Init();
		base.InitSystem();
	}
	/// <summary>
	/// 获取今日关卡信息
	/// </summary>
	/// <returns></returns>
	public void GetDailyLevel(List<int> someCategoryIds, Action<List<DailyQuestionEntity>> acompleteAction)
	{
		if (someCategoryIds == null) {
			acompleteAction?.Invoke(null);
			return;
		}
		if (someCategoryIds.Count == 0) {
			acompleteAction?.Invoke(null);
			return;
		}
		taskId++;
		var aWordLibrarySystemTask = new WorLibrarySystemTask(taskId, someCategoryIds, acompleteAction);

		foreach (var oneId in someCategoryIds) {
			aWordLibrarySystemTask.LoadTaskCount++;
			var aEntityIndex = wordLibraryDailyData.GetQuestionEntityBeginIndex(oneId);
			var aMaxIndex = wordLibraryDailyData.GetQuestionEntityMaxIndex(oneId);
			bool isInRecycleStage = aEntityIndex > aMaxIndex;//经推演如果是正常可以获取新词库的话，这两个标记会一直相等。
			bool adjustNewFileFailed = false;
			#region 现在是在Recycle阶段，尝试看看是否有新的文件(先处理这种情况);
			//TODO 或者是同个文件的实体数目被扩充了(因为允许最后一个的数目小于OneCategoryLevelCount)
			if (isInRecycleStage) {
				////Debug.LogFormat("<color=#ff0000>尝试判断新文件</color>");
				aEntityIndex = aMaxIndex;
			}
		NewFileFailed:
			if (adjustNewFileFailed) {
				//Debug.LogFormat("<color=#ff0000>进入了label NewFileFailed</color>");
				isInRecycleStage = false;
				aEntityIndex = wordLibraryDailyData.GetQuestionEntityBeginIndex(oneId);
			}
			#endregion
			var aFileIndex = aEntityIndex / OneFileEntityCount + 1;//文件从1开始
			var fileName = string.Format("Category_{0}_{1}.asset", oneId, aFileIndex);
			//Debug.LogFormat("<color=#ff0000>获取daily文件{0}--{1}</color>", fileName, aEntityIndex);
			var operation = Addressables.LoadAssetAsync<CategotyQuestionContainer>(fileName);
			bool recycleRequest = false;
			if (operation.Status == AsyncOperationStatus.Failed) {//假定是文件不存在
				if (isInRecycleStage) {
					adjustNewFileFailed = true;
					goto NewFileFailed;
				}
				var aTempEntityIndex = aEntityIndex % aMaxIndex;//在循环获取的过程中，不能修改真实的BeginIndex
				aFileIndex = aTempEntityIndex / OneFileEntityCount + 1;//文件从1开始
				fileName = string.Format("Category_{0}_{1}.asset", oneId, aFileIndex);
				//Debug.LogFormat("<color=#ff0000>（因为前次词库到头导致失败，）重新调整以获取daily文件{0}--{1} </color>", fileName, aTempEntityIndex);
				operation = Addressables.LoadAssetAsync<CategotyQuestionContainer>(fileName);
				recycleRequest = true;
			}
			if (isInRecycleStage) {
				//Debug.LogFormat("<color=#ff0000>找到了新文件</color>");
			}
			operation.Completed += oper=> LoadCompleted(oper,fileName,oneId);
			var oneFileRequest = new WordLibrarySystemHandleOneFile(oneId, fileName, aEntityIndex, OneCategoryLevelCount, recycleRequest, isInRecycleStage);
			oneFileRequest.RecycleBeginIndex = wordLibraryDailyData.GetQuestionEntityBeginIndex(oneId);
			aWordLibrarySystemTask.allRequestFiles.Add(oneFileRequest);
			wordLibraryDailyData.SetQuestionEntityBeginIndex(oneId, aEntityIndex + OneCategoryLevelCount);
		}
		if (aWordLibrarySystemTask.LoadTaskCount == 0) {
			CalCulateResult(aWordLibrarySystemTask);
		} else {
			tasks.Add(aWordLibrarySystemTask);
		}
	}

	void LoadCompleted(AsyncOperationHandle<CategotyQuestionContainer> obj, string key,int acategoryId)
	{
		//Debug.LogFormat("LoadCompleted key is {0}--{1}", key, obj.Status);
		if (obj.Status == AsyncOperationStatus.Succeeded)
		{
			var r = obj.Result;
			containerCache[key] = r;
			foreach (var oneTask in tasks)
			{
				oneTask.FinishOneLoadTask(r.CategoryID);
			}
		}
		else
		{//一旦出现加载失败，立即停止处理
			Debug.Log(obj.OperationException);
			//TODO 无网状况处理
			if (Application.internetReachability == NetworkReachability.NotReachable) {
				Debug.Log("无网处理");
				if (tasks.Count > 0) {
					var one = tasks[0];
					tasks.Clear();
					var aEntityIndex = wordLibraryDailyData.GetQuestionEntityBeginIndex(acategoryId);
					wordLibraryDailyData.SetQuestionEntityBeginIndex(acategoryId, aEntityIndex - OneCategoryLevelCount);
					one.CompleteAction?.Invoke(null);
				}
				return;
			}
			containerCache[key] = null;
			foreach(var oneTask in tasks)
			{
				oneTask.FinishOneLoadTask(acategoryId);
			}
		}
		var finishes = tasks.FindAll(x => x.LoadTaskCount == 0);
		Debug.Log("finish count " + finishes.Count);
		if (finishes.Count > 0) {
			foreach (var one in finishes) {

				if (one.IsChildTask) {
					CalCulateResult(one.Ancestor);
				} else {
					CalCulateResult(one);
				}
				tasks.Remove(one);
			}
		}
	}

	struct NotEnoughCateory
	{
		public int categoryId;
		public WorLibrarySystemTask task;
		public int beginEntityIndex;//总是获取把该实体看成位于整个词库列表的位置的索引（从0开始）
		public int selectEntityCount;
		public bool entityLow;//实体数目小于OneFileEntityCount,认定是最后一个文件
		public int lowFileEntityCount;
	};

	/// <summary>
	/// aTask是最初调用Api时创立的任务，isChild为false;不是那些因为文件不足而创建的从新文件获取实体的Task
	/// </summary>
	/// <param name="aTask"></param>
	private void CalCulateResult(WorLibrarySystemTask aTask)
	{
		WorLibrarySystemTask handlingTask = aTask;
		List<DailyQuestionEntity> result = new List<DailyQuestionEntity>();
		List<NotEnoughCateory> allNotEnoghs = new List<NotEnoughCateory>();//本个文件不够，需要下个文件里的实体
		Dictionary<int, int> tempDic = new Dictionary<int, int>();//减少GC可以把这个放在全局字段(每次用之前clear()
		var dummyNotEnoghCategory = new NotEnoughCateory();
		NotEnoughCateory gobackWhenOneNotEnoughLoadFileFromMemory = dummyNotEnoghCategory;
		bool isGobackWhenOneNotEnoughLoadFileFromMemory = false;
	CompleteLoadFile:
		if (isGobackWhenOneNotEnoughLoadFileFromMemory) {
			isGobackWhenOneNotEnoughLoadFileFromMemory = false;
			if (allNotEnoghs.Contains(gobackWhenOneNotEnoughLoadFileFromMemory)) {
				allNotEnoghs.Remove(gobackWhenOneNotEnoughLoadFileFromMemory);
			}
			gobackWhenOneNotEnoughLoadFileFromMemory = dummyNotEnoghCategory;
		}
		foreach (var one in handlingTask.allRequestFiles) {//一次迭代处理一个请求文件的结果
			var container = containerCache[one.FileName];
			bool hasNotEhough = false;
			List<DailyQuestionEntity> aSubList = null;
			if (container == null) {
				hasNotEhough = true;
				aSubList = new List<DailyQuestionEntity>();
				goto NotEnoughEntity;
			}
			if (GetProperFileEntityIndex(one,tempDic) + one.SelectEntityCount - 1 < container.Questions.Count) {
				//Debug.LogFormat("尝试获取[{0},{1}]", GetProperFileEntityIndex(one,tempDic), one.SelectEntityCount);
				result.AddRange(container.Questions.GetRange(GetProperFileEntityIndex(one,tempDic), one.SelectEntityCount));
				if (one.RecycleRequest == false)
					OperateTemDic(tempDic, one.CategoryId, one.SelectEntityCount);
			} else {
				//Debug.LogFormat("--尝试获取[{0},{1}]", GetProperFileEntityIndex(one,tempDic), container.Questions.Count - GetProperFileEntityIndex(one,tempDic));
				aSubList = container.Questions.GetRange(GetProperFileEntityIndex(one, tempDic), container.Questions.Count - GetProperFileEntityIndex(one, tempDic));
				result.AddRange(aSubList);
				if (one.RecycleRequest == false)
					OperateTemDic(tempDic, one.CategoryId, aSubList.Count);
				//Debug.LogFormat("--实际获取{0}", aSubList.Count);
				hasNotEhough = true;
			}
		NotEnoughEntity:
			if (hasNotEhough) {
				var aEL = false;
				var aLFEC = 0;
				if (container == null) {
					aEL = true;
				} else {
					aEL = container.Questions.Count < OneFileEntityCount;
					aLFEC = container.Questions.Count;
				}
				NotEnoughCateory notEnoughCateory = new NotEnoughCateory {
					categoryId = one.CategoryId,
					task = handlingTask,
					beginEntityIndex = one.BeginEntityIndex + aSubList.Count,
					selectEntityCount = one.SelectEntityCount - aSubList.Count,
					entityLow = aEL,
					lowFileEntityCount = aLFEC
				};
				if (one.IsTryingNewFile) {
					if (aSubList.Count == 0) {//认为是新文件却没有获取到任何实体
						wordLibraryDailyData.SetQuestionEntityBeginIndex(one.CategoryId, one.RecycleBeginIndex + OneCategoryLevelCount);
						notEnoughCateory.beginEntityIndex = one.RecycleBeginIndex;
					}
				}
				allNotEnoghs.Add(notEnoughCateory);
			}
		}

		if (allNotEnoghs.Count > 0) {
			taskId++;
			var aaCategoryIds = allNotEnoghs.Select(s => s.categoryId).ToList();
			var aWordLibrarySystemTask = new WorLibrarySystemTask(taskId, aaCategoryIds, null);
			foreach (var oneNotEnoghTask in allNotEnoghs) {
				aWordLibrarySystemTask.LoadTaskCount++;
				aWordLibrarySystemTask.ParentTask = oneNotEnoghTask.task;
				int oneId = oneNotEnoghTask.categoryId;
				var aEntityIndex = oneNotEnoghTask.beginEntityIndex;
				var recycle = false;//重新从头开始了 （这部分特殊对待，比如不应该计入现有词库最大个数
				string fileName = "";
				AsyncOperationHandle<CategotyQuestionContainer> operation = Addressables.LoadAssetAsync<CategotyQuestionContainer>(fileName);
				if (oneNotEnoghTask.entityLow) {
					//Debug.LogFormat("<color=#ff0000>最后一个文件校验失败，重置beginIndex-{0}</color>", oneNotEnoghTask.beginEntityIndex);
					////Debug.LogFormat("<color=#ff0000>到达最后一个文件，其文件数目是{0}--补足完整文件个数{1}</color>", oneNotEnoghTask.lowFileEntityCount,OneFileEntityCount);
					//aEntityIndex = aEntityIndex + OneFileEntityCount - oneNotEnoghTask.lowFileEntityCount;
					goto RecycleFile;
				}
				var aFileIndex = aEntityIndex / OneFileEntityCount + 1;//文件从1开始
				fileName = string.Format("Category_{0}_{1}.asset", oneId, aFileIndex);
				//Debug.LogFormat("<color=#ff0000>获取daily文件{0}--{1}</color>", fileName, aEntityIndex);
				operation = Addressables.LoadAssetAsync<CategotyQuestionContainer>(fileName);
			RecycleFile:
				if (recycle == true || operation.Status == AsyncOperationStatus.Failed) {//假定是文件不存在
					recycle = true;
					var aMaxIndex = wordLibraryDailyData.GetQuestionEntityMaxIndex(oneId, 1);
					//TODO workaround:tempdic中缓存了一些暂时不能加入到max中的量
					if (tempDic.ContainsKey(oneNotEnoghTask.categoryId)) {
						aMaxIndex += tempDic[oneNotEnoghTask.categoryId];
					}
					var aTempEntityIndex = oneNotEnoghTask.beginEntityIndex % aMaxIndex;
					aFileIndex = aTempEntityIndex / OneFileEntityCount + 1;//文件从1开始
					fileName = string.Format("Category_{0}_{1}.asset", oneId, aFileIndex);
					//Debug.LogFormat("<color=#ff0000>（因为前次词库到头导致失败，）重新调整以获取daily文件{0}--{1} </color>", fileName, aTempEntityIndex);
					operation = Addressables.LoadAssetAsync<CategotyQuestionContainer>(fileName);
					if (operation.Status == AsyncOperationStatus.Failed) {
						fileName = string.Format("Category_{0}_{1}.asset", oneId, 1);
						//Debug.LogFormat("<color=#ff0000>（因为前次词库到头导致失败，）（因为前次词库到头导致失败，）重新调整以获取daily文件{0}--{1} </color>", fileName, aTempEntityIndex);
						operation = Addressables.LoadAssetAsync<CategotyQuestionContainer>(fileName);
					}
					aEntityIndex = aTempEntityIndex;
				}
				if (operation.Status != AsyncOperationStatus.Succeeded) {
					Debug.Log("尝试获取 " + fileName);
					operation.Completed += oper => LoadCompleted(oper, fileName, oneNotEnoghTask.categoryId);
					var oneFileRequest = new WordLibrarySystemHandleOneFile(oneNotEnoghTask.categoryId, fileName, oneNotEnoghTask.beginEntityIndex, oneNotEnoghTask.selectEntityCount, recycle, false);
					aWordLibrarySystemTask.allRequestFiles.Add(oneFileRequest);
				} else {//这儿假定总是可以在第二次获取到满足需求的数目,需要测试不满足的情况->碰到了假定不成立的情况
					var oneFileRequest = new WordLibrarySystemHandleOneFile(oneNotEnoghTask.categoryId, fileName, oneNotEnoghTask.beginEntityIndex, oneNotEnoghTask.selectEntityCount, recycle, false);
					aWordLibrarySystemTask.allRequestFiles.Add(oneFileRequest);
					isGobackWhenOneNotEnoughLoadFileFromMemory = true;
					gobackWhenOneNotEnoughLoadFileFromMemory = oneNotEnoghTask;
					handlingTask = aWordLibrarySystemTask;
					goto CompleteLoadFile;//此处相当于还有notEnoghTask没有处理；思路是优先处理已经准备好的那个notEnoghTask
				}
			}

			if (aWordLibrarySystemTask.allRequestFiles.Count == 0) {
				OperateTemdicUseToMax(tempDic);
				aTask.CompleteAction?.Invoke(result);
			} else {
				tasks.Add(aWordLibrarySystemTask);
			}
		} else {
			OperateTemdicUseToMax(tempDic);
			aTask.CompleteAction?.Invoke(result);
		}
	}
	
	private int GetProperFileEntityIndex(WordLibrarySystemHandleOneFile oneFile, Dictionary<int, int> aCache)
	{
		if (oneFile.RecycleRequest) {
			var aMaxIndex = wordLibraryDailyData.GetQuestionEntityMaxIndex(oneFile.CategoryId);
			if (aCache.ContainsKey(oneFile.CategoryId)) {
				aMaxIndex += aCache[oneFile.CategoryId];
			}
			return (oneFile.BeginEntityIndex % aMaxIndex) % OneFileEntityCount;
		} else {
			return oneFile.BeginEntityIndex % OneFileEntityCount;
		}
	}	
	
	private void OperateTemDic(Dictionary<int,int> aCache, int akey, int aAddValue)
	{
		if (aCache.ContainsKey(akey)) {
			aCache[akey] = aCache[akey] + aAddValue;
		} else {
			aCache[akey] = aAddValue;
		}
		//wordLibraryDailyData.AddQuestionEntityMaxIndexAdAddd(akey, aAddValue);
	}
	private void OperateTemdicUseToMax(Dictionary<int,int> aCache)
	{
		if (aCache.Keys.Count > 0) {
			foreach (var aKP in aCache) {
				wordLibraryDailyData.AddQuestionEntityMaxIndexAdAddd(aKP.Key, aKP.Value);
			}
		}
	}
}
