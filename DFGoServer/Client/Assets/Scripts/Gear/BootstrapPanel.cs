using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LuaFramework;
using Gear;
using System;
public class BootstrapPanel : MonoBehaviour
{
	[HideInInspector]
	public delegate void OnCompleteDelegate();


	public GameObject hotUpdateFrame;
	public Text progressText;
	public Image progressBar;

	public GameObject confrim;
	public Text confrimText;
	public Button confrimOKBtn;
	public OnCompleteDelegate onComplete;

	public void Boot()
	{
		HideConfrim();
		if (PlatformUtil.IsAndroidPlayer() || PlatformUtil.IsIPhonePlayer())
		{
			hotUpdateFrame.SetActive(false);
			EnterFrameTimer timer = new EnterFrameTimer(2000, 1);
			timer.onComplete = delegate ()
			{
				timer.Dispose();
				timer = null;
				hotUpdateFrame.SetActive(true);
				timer = new EnterFrameTimer(1, 1);
				timer.onComplete = delegate ()
				{
					timer.Dispose();
					timer = null;
					CheckEnterGame();
				};
				timer.Start();
			};
			timer.Start();
		}
		else
		{
			CheckEnterGame();
		}
	}
	void CheckEnterGame()
	{
		if (GResManager.GetInstance().GetHotUpdateEnabled() && PlatformUtil.IsRunInEditor() == false)
		{
			OnHotUpdateGame();
		}
		else
		{
			OnEnterGame();
		}
	}
	void OnHotUpdateGame()
	{
		ExecCompareCDNBuildVersion();
	}

	void ExecCompareCDNBuildVersion()
	{
		Debug.Log("HotUpdateCDN URL:" + GResManager.GetInstance().GetAssetBundlesCDNPath());
		SetProgressText("获取最新版本信息");
		GFileManager.GetInstance().CompareCDNBuildVersion(GResManager.GetInstance().GetAssetBundlesCDNPath() + "/" + GFileManager.FILENAME_BUILDVERSION_TXT, delegate (bool needDownload)
		{
			//进行热更新比对，把CDN上的version同步记录下来
			ApplicationKernel.runtimeBuildVersion = GFileManager.GetInstance().cdnBuildVersion;
			if (needDownload)
			{
				//包体有c#代码更新，不能走热更了
				ShowConfrim("游戏有新版本更新，请前往应用商店下载最新版本", delegate ()
				{
					Application.Quit();
				});
				return;
			}
			SetProgressText("正在检查版本文件");
			//进行文件对比
			GFileManager.GetInstance().CompareFiles(GResManager.GetInstance().GetAssetBundlesCDNPath() + "/" + GFileManager.FILENAME_FILES_TXT, 0, delegate (GFileBundleInfo[] diffList, float totalByteSize)
			{
				int diffLength = diffList.Length;
				Debug.Log("Diff Files Count:" + diffLength);
				if (diffLength == 0)
				{
					Debug.Log("no need update files");
					OnEnterGame();
					return;
				}
				double totalMB = Math.Round(totalByteSize / 1024f / 1024f, 2, MidpointRounding.AwayFromZero);
				//有需要热更新的文件
				ShowConfrim(string.Format("游戏有新内容，共{0}MB，点击确定开始下载", totalMB.ToString()), delegate ()
				{
					//开始下载更新文件
					GFileManager.GetInstance().DownloadFilesByBundleInfo(GResManager.GetInstance().GetAssetBundlesCDNPath(), diffList, delegate (GLoaderQueue progress_queue)
					{
						//下载进度更新
						SetProgressText(string.Format("下载中，{0}MB/{1}MB", Math.Round(progress_queue.ProgressByteSize / 1024f / 1024f, 2, MidpointRounding.AwayFromZero), totalMB.ToString()));
						SetProgressBar(progress_queue.ProgressByteSize / totalByteSize);
					}, delegate (GLoaderQueue complete_queue)
					{
						SetProgressBar(1);
						OnEnterGame();
					});
				});
			});
		}, OnCompareCDNBuildVersionError);
	}

	void OnCompareCDNBuildVersionError()
	{
		//请求CDN版本比对失败
		ShowConfrim("获取最新版本信息失败，请检查网络连接，点击确定重试", delegate ()
		{
			Debug.LogError("Get Buildversion Error");
			ExecCompareCDNBuildVersion();
			return;
		});
	}

	void OnEnterGame()
	{
		SetProgressText("游戏正在初始化");

		if (onComplete != null)
		{
			onComplete();
		}
	}

	void SetProgressText(string content)
	{
		progressText.text = content;
	}
	void SetProgressBar(float value)
	{
		progressBar.fillAmount = value;
	}
	void ShowConfrim(string content, OnCompleteDelegate onOKCallBack)
	{
		confrim.SetActive(true);
		confrimText.text = content;
		confrimOKBtn.onClick.AddListener(delegate ()
		{
			HideConfrim();
			if (onOKCallBack != null)
				onOKCallBack();
		});
	}

	void HideConfrim()
	{
		confrimOKBtn.onClick.RemoveAllListeners();
		confrim.SetActive(false);
	}

	public void HideAll()
	{
		hotUpdateFrame.SetActive(false);

		hotUpdateFrame = null;
		progressText = null;
		progressBar = null;
		confrim = null;
		confrimText = null;
		confrimOKBtn = null;
	}
}
