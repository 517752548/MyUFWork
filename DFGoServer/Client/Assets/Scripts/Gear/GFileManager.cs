using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using LuaFramework;

namespace Gear
{
	public enum BundleStorageLocation
	{
		NONE = 0,
		STREAMINGASSETS = 1,//存放在包体的StreamingAssets文件夹里，Application.streamingAssetsPath
		STORAGE = 2,//存放在本地存储中，Application.persistentDataPath
		CDN = 3,//保存在CDN上的
	}

	//打包索引，BASIC是放到安装包中的，其他为以后拆分包预留,NET为纯实时下载
	public enum BundlePackage
	{
		NET = -1,
		BASIC = 0,
		PACKAGE_1 = 1,
		PACKAGE_2 = 2,
		PACKAGE_3 = 3,
		PACKAGE_4 = 4,
		PACKAGE_5 = 5,
		PACKAGE_6 = 6,
		PACKAGE_7 = 7,
		PACKAGE_8 = 8,
	}

	public class GFileBundleInfo
	{
		public string name;
		public long byteSize;
		public string crcOrMD5Hash; //bundle文件的时候，这里存crc的值，非bundle的时候存md5。这个在打包的时候有判定
		public BundleStorageLocation location = BundleStorageLocation.NONE;
		public BundlePackage package = BundlePackage.BASIC;

		public void Parse(string s)
		{
			string[] fs = s.Split('|');
			if (fs.Length < 5)
			{
				return;
			}
			name = fs[0];
			long _byteSize = 0;
			if (long.TryParse(fs[1], out _byteSize))
			{
				byteSize = _byteSize;
			}
			crcOrMD5Hash = fs[2];
			int _location = 0;
			if (int.TryParse(fs[3], out _location))
			{
				location = (BundleStorageLocation)_location;
			}
			int _package = 0;
			if (int.TryParse(fs[4], out _package))
			{
				package = (BundlePackage)_package;
			}
		}

		public void Update(GFileBundleInfo newInfo)
		{
			name = newInfo.name;
			byteSize = newInfo.byteSize;
			crcOrMD5Hash = newInfo.crcOrMD5Hash;
			location = newInfo.location;
			package = newInfo.package;
		}

		public string Output()
		{
			return name + "|" + byteSize + "|" + crcOrMD5Hash + "|" + (int)location + "|" + (int)package;
		}
	}

	public class GFileManager : ITicker
	{
		public delegate void OnLoadQueueProgressDelegate(GLoaderQueue queue);
		public delegate void OnLoadQueueCompleteDelegate(GLoaderQueue queue);
		public delegate void OnItemCompleteDelegate();
		public delegate void OnCompleteDelegate();
		public delegate void OnErrorDelegate();
		public delegate void OnCompareCDNResult(GFileBundleInfo[] diffFilesInfo, float totalByteSize);
		public delegate void OnCompareCDNBuildVersionResult(bool needDownload);
		//存储在本地硬盘空间的assetbundle文件
		private Dictionary<string, GFileBundleInfo> _storageBundlesInfo = new Dictionary<string, GFileBundleInfo>();
		//CDN上的assetbundle信息
		private Dictionary<string, GFileBundleInfo> _cdnBundlesInfo = new Dictionary<string, GFileBundleInfo>();
		private static GFileManager _instance;
		private bool _writeBundleInfoDirty = false;
		private float _writeBundleInfoTime = 0f;
		public string cdnBuildVersion = "";
		public static GFileManager GetInstance()
		{
			if (_instance == null)
			{
				_instance = new GFileManager();

			}
			return _instance;
		}

		public Dictionary<string, GFileBundleInfo> StorageBundlesInfo
		{
			get
			{
				return _storageBundlesInfo;
			}

			set
			{
				_storageBundlesInfo = value;
			}
		}

		public Dictionary<string, GFileBundleInfo> CDNBundlesInfo
		{
			get
			{
				return _cdnBundlesInfo;
			}

			set
			{
				_cdnBundlesInfo = value;
			}
		}

		public const string FILENAME_FILES_TXT = "files.txt";
		public const string FILENAME_BUILDVERSION_TXT = "buildversion.txt";
		public const string FILENAME_BUNDLESTABLE_TXT = "bundles_table.txt";
		public const string FILENAME_APPCONFIG_JSON = "app_config.json";
		public string GetBundlesInfoConfigStreamingAssetsPath()
		{
			return Path.Combine(GResManager.GetInstance().GetAssetBundleStreamingAssetsPath(), FILENAME_FILES_TXT);
		}

		public string GetBundlesInfoConfigPersistentDataPath()
		{
			return Path.Combine(Util.DataPath, FILENAME_FILES_TXT);
		}

		public string GetBuildVersionConfigStreamingAssetsPath()
		{
			return Path.Combine(GResManager.GetInstance().GetAssetBundleStreamingAssetsPath(), FILENAME_BUILDVERSION_TXT);
		}

		public string GetBuildVersionConfigPersistentDataPath()
		{
			return Path.Combine(Util.DataPath, FILENAME_BUILDVERSION_TXT);
		}

		public string GetBundlesTableConfigStreamingAssetsPath()
		{
			return Path.Combine(GResManager.GetInstance().GetAssetBundleStreamingAssetsPath(), FILENAME_BUNDLESTABLE_TXT);
		}
		public string GetBundlesTableConfigPersistentDataPath()
		{
			return Path.Combine(Util.DataPath, FILENAME_BUNDLESTABLE_TXT);
		}

		public string GetAppConfigJSONPath()
		{
			return Path.Combine(Application.streamingAssetsPath, FILENAME_APPCONFIG_JSON);
		}

		public void LoadBundlesInfo()
		{
			//解析files.txt获取fileInfo
			if (!PlatformUtil.IsRunInEditor())
			{
				string[] files = File.ReadAllLines(GetBundlesInfoConfigPersistentDataPath());
				for (int i = 0; i < files.Length; i++)
				{
					string file = files[i];
					if (string.IsNullOrEmpty(file))
					{
						continue;
					}
					GFileBundleInfo bundleInfo = new GFileBundleInfo();
					bundleInfo.Parse(file);
					if (!_storageBundlesInfo.ContainsKey(bundleInfo.name))
						_storageBundlesInfo.Add(bundleInfo.name, bundleInfo);
				}
				TickRunner.GetInstance().AddTicker(this);
			}
		}
		public void UpdateStorageBundleInfo(GFileBundleInfo newInfo)
		{
			GFileBundleInfo oldBundleInfo = null;
			if (_storageBundlesInfo.TryGetValue(newInfo.name, out oldBundleInfo))
			{
				oldBundleInfo.Update(newInfo);
			}
			else
			{
				_storageBundlesInfo.Add(newInfo.name, newInfo);
			}
		}

		public void UpdateCDNBundleInfo(GFileBundleInfo newInfo)
		{
			GFileBundleInfo oldBundleInfo = null;
			if (_cdnBundlesInfo.TryGetValue(newInfo.name, out oldBundleInfo))
			{
				oldBundleInfo.Update(newInfo);
			}
			else
			{
				_cdnBundlesInfo.Add(newInfo.name, newInfo);
			}
		}

		public void CompareCDNBuildVersion(string cdnBuildVersionURL, OnCompareCDNBuildVersionResult onCompareResult, OnErrorDelegate onError)
		{
			//检查版本号
			Version cdnVersion = null;
			Version storageVersion = null;
			GLoaderQueue loaderQueue = new GLoaderQueue();
			GTextLoader cdnBuildVersionLoader = new GTextLoader();
			cdnBuildVersionLoader.Url = cdnBuildVersionURL;
			cdnBuildVersionLoader.OnLoadComplete = delegate (GBaseLoader loader)
			{
				cdnVersion = new Version(cdnBuildVersionLoader.Text);
				cdnBuildVersion = cdnVersion.ToString();
			};
			loaderQueue.AddLoader(cdnBuildVersionLoader);
			GTextLoader storageBuildVersionLoader = new GTextLoader();
			storageBuildVersionLoader.Url = GFileManager.GetInstance().GetBuildVersionConfigPersistentDataPath();
			storageBuildVersionLoader.OnLoadComplete = delegate (GBaseLoader loader)
			{
				storageVersion = new Version(storageBuildVersionLoader.Text);
			};
			loaderQueue.AddLoader(storageBuildVersionLoader);
			loaderQueue.OnLoadComplete = delegate (GLoaderQueue queue)
			{
				bool needDownload = false;
				if (cdnVersion != null && storageVersion != null)
				{
					if (storageVersion.Build < cdnVersion.Build)
					{
						needDownload = true;
					}
				}
				if (onCompareResult != null)
				{
					onCompareResult(needDownload);
				}
			};
			loaderQueue.OnLoadError = delegate (GLoaderQueue queue)
			{
				if (onError != null)
				{
					onError();
				}
			};
			loaderQueue.Load();
		}

		public void CompareFiles(string cdnFilesURL, int needPackage, OnCompareCDNResult onCompareResult)
		{
			List<GFileBundleInfo> diffFilesInfoList = new List<GFileBundleInfo>();
			long totalByteSize = 0;
			GTextLoader cdnFilesTxtLoader = new GTextLoader();
			cdnFilesTxtLoader.Url = cdnFilesURL;
			cdnFilesTxtLoader.OnLoadComplete = delegate (GBaseLoader l)
			{
				string cdnFilesStr = cdnFilesTxtLoader.Text;
				string[] cdnFiles = cdnFilesStr.Split('\n');
				for (int i = 0; i < cdnFiles.Length; i++)
				{
					string cdnFile = cdnFiles[i];
					if (string.IsNullOrEmpty(cdnFile))
					{
						continue;
					}
					GFileBundleInfo cdnBundleInfo = new GFileBundleInfo();
					cdnBundleInfo.Parse(cdnFile);
					//解析的时候顺便放入本地存一份CDN上files.txt信息
					UpdateCDNBundleInfo(cdnBundleInfo);
					bool hasDiff = false;
					//获取目前本地的
					GFileBundleInfo oldBundleInfo = GetBundleInfo(cdnBundleInfo.name);
					//如果本地已经有这个记录了
					if (oldBundleInfo != null)
					{
						//先检查存储位置，必须是在streamingPath或者dataPath存储
						if (oldBundleInfo.location == BundleStorageLocation.STORAGE || oldBundleInfo.location == BundleStorageLocation.STREAMINGASSETS)
						{
							//检查这个 bundle的包类型，必须是小于这次比对的needPackage条件，比这个needPackage还大的不在更新范围内
							if ((int)oldBundleInfo.package <= needPackage)
							{
								//最后检查crc是否需要更新
								if (oldBundleInfo.crcOrMD5Hash.Equals(cdnBundleInfo.crcOrMD5Hash) == false)
								{
									hasDiff = true;
								}
							}
						}
					}
					else
					{
						//先检查存储位置，必须是在streamingPath或者dataPath存储
						if (cdnBundleInfo.location == BundleStorageLocation.STORAGE || cdnBundleInfo.location == BundleStorageLocation.STREAMINGASSETS)
						{
							hasDiff = true;
						}
						//如果本地没有，那么查看这个是不是CDN位置的 如果是把记录更新
						if (cdnBundleInfo.location == BundleStorageLocation.CDN)
						{
							UpdateStorageBundleInfo(cdnBundleInfo);
						}
					}
					if (hasDiff)
					{
						GFileBundleInfo newBundleInfo = new GFileBundleInfo();
						newBundleInfo.Update(cdnBundleInfo);
						newBundleInfo.location = BundleStorageLocation.CDN;
						diffFilesInfoList.Add(newBundleInfo);
					}
				}
				for (int i = 0; i < diffFilesInfoList.Count; i++)
				{
					totalByteSize += diffFilesInfoList[i].byteSize;
				}
				if (onCompareResult != null)
				{
					onCompareResult(diffFilesInfoList.ToArray(), (float)totalByteSize);
				}
			};
			cdnFilesTxtLoader.Load();
		}

		public void DownloadFilesByBundleInfo(string prefixURL, GFileBundleInfo[] downloadInfoArray, OnLoadQueueProgressDelegate onProgress, OnLoadQueueCompleteDelegate onComplete)
		{
			GLoaderQueue queue = new GLoaderQueue();
			for (int i = 0; i < downloadInfoArray.Length; i++)
			{
				GFileBundleInfo info = downloadInfoArray[i];
				string fileURL = Path.Combine(prefixURL, info.name);
				GBinaryLoader loader = new GBinaryLoader();
				loader.Name = info.name;
				loader.Url = fileURL;
				loader.OnLoadComplete = delegate (GBaseLoader l)
				{
					GFileBundleInfo finishInfo = GetBundleInfoFormArray(downloadInfoArray, l.Name);
					finishInfo.location = BundleStorageLocation.STORAGE;
					UpdateStorageBundleInfo(finishInfo);
					string path = Path.Combine(Util.DataPath, finishInfo.name);
					if (File.Exists(path)) File.Delete(path);
					File.WriteAllBytes(path, (byte[])l.Content);
				};
				queue.AddLoader(loader);
			}
			queue.OnLoadProgress += delegate (GLoaderQueue q)
			{
				if (onProgress != null)
				{
					onProgress(q);
				}
			};
			queue.OnLoadComplete = delegate (GLoaderQueue q)
			{
				WriteBundlesInfoToFilesTxt();
				if (onComplete != null)
				{
					onComplete(q);
				}
			};
			queue.Load();
		}

		private GFileBundleInfo GetBundleInfoFormArray(GFileBundleInfo[] infoArray, string name)
		{
			for (int i = 0; i < infoArray.Length; i++)
			{
				if (infoArray[i].name.Equals(name))
				{
					return infoArray[i];
				}
			}
			return null;
		}

		public GFileBundleInfo GetBundleInfo(string name)
		{
			GFileBundleInfo bundleInfo = null;
			if (_storageBundlesInfo.TryGetValue(name, out bundleInfo))
			{
				return bundleInfo;
			}
			return null;
		}

		public bool HasBundleInfoOnStorage(string name)
		{
			GFileBundleInfo bundleInfo = GetBundleInfo(name);
			if (bundleInfo != null && (bundleInfo.location == BundleStorageLocation.STORAGE || bundleInfo.location == BundleStorageLocation.STREAMINGASSETS))
			{
				return true;
			}
			return false;
		}

		public void WriteBundlesInfoToFilesTxt()
		{
			List<string> contentList = new List<string>();
			foreach (GFileBundleInfo info in _storageBundlesInfo.Values)
			{
				contentList.Add(info.Output());
			}

			string path = GetBundlesInfoConfigPersistentDataPath();
			if (File.Exists(path)) File.Delete(path);
			File.WriteAllLines(path, contentList.ToArray());
		}

		//每个30秒检查一次是否需要重写写入files.txt
		public void OnTick()
		{
			if (Time.time - _writeBundleInfoTime <= 30)
			{
				return;
			}
			_writeBundleInfoTime = Time.time;
			Debug.Log("GFileManger.OnTick");
			if (_writeBundleInfoDirty)
			{
				_writeBundleInfoDirty = false;
				WriteBundlesInfoToFilesTxt();
			}

		}

		public void OnLateTick() { }

		public void SetWriteBundleInfoDirty()
		{
			_writeBundleInfoDirty = true;
		}

		public void WriteBundleToStorageAndUpdateBundleInfo(string name, GAssetBundleLoader loader)
		{
			if (PlatformUtil.IsRunInEditor())
				return;
			if (loader == null)
				return;
			GFileBundleInfo cdnBundleInfo = null;
			if (_cdnBundlesInfo.TryGetValue(name, out cdnBundleInfo))
			{
				if (cdnBundleInfo.location == BundleStorageLocation.CDN)
				{
					UpdateStorageBundleInfo(cdnBundleInfo);
					GFileBundleInfo storageBundleInfo = GetBundleInfo(name);
					if (storageBundleInfo != null)
					{
						storageBundleInfo.location = BundleStorageLocation.STORAGE;
						SetWriteBundleInfoDirty();
						//本地写文件
						string path = Path.Combine(Util.DataPath, storageBundleInfo.name);
						if (File.Exists(path)) File.Delete(path);
						File.WriteAllBytes(path, (byte[])loader.Content);
					}
				}
			}
		}

		public void CopyFile(string sourceFile, string destFolderPath, OnCompleteDelegate onComplete = null)
		{
			bool isFolder = string.IsNullOrEmpty(Path.GetFileName(destFolderPath)) ? true : false;
			string sourceFilePath = sourceFile;
			string sourceFileName = Path.GetFileName(sourceFilePath);
			string destFile = "";
			if (isFolder)
			{
				destFile = Path.Combine(destFolderPath, sourceFileName);
			}
			else
			{
				destFile = destFolderPath;
			}
			if (File.Exists(destFile)) File.Delete(destFile);
			if (PlatformUtil.IsAndroidPlayer())
			{
				GBinaryLoader fileLoader = new GBinaryLoader();
				fileLoader.Url = sourceFilePath;
				fileLoader.OnLoadComplete = delegate (GBaseLoader loader)
				{
					File.WriteAllBytes(destFile, (byte[])loader.Content);
					if (onComplete != null)
					{
						onComplete();
					}
				};
				fileLoader.Load();
			}
			else
			{
				File.Copy(sourceFilePath, destFile, true);
				if (onComplete != null)
				{
					onComplete();
				}
			}
		}

		public void CopyFiles(string[] sourceFilePathArray, string destFolderPath, OnCompleteDelegate onComplete = null, OnItemCompleteDelegate onItemComplete = null)
		{
			bool isFolder = string.IsNullOrEmpty(Path.GetFileName(destFolderPath)) ? true : false;

			GLoaderQueue queue = new GLoaderQueue();
			for (int i = 0; i < sourceFilePathArray.Length; i++)
			{
				string sourceFilePath = sourceFilePathArray[i];
				string sourceFileName = Path.GetFileName(sourceFilePath);
				string destFile = "";
				if (isFolder)
				{
					destFile = Path.Combine(destFolderPath, sourceFileName);
				}
				else
				{
					destFile = destFolderPath;
				}
				if (File.Exists(destFile)) File.Delete(destFile);
				if (PlatformUtil.IsAndroidPlayer())
				{
					GBinaryLoader fileLoader = new GBinaryLoader();
					fileLoader.Url = sourceFilePath;
					fileLoader.OnLoadComplete = delegate (GBaseLoader loader)
					{
						File.WriteAllBytes(destFile, (byte[])loader.Content);
						if (onItemComplete != null)
						{
							onItemComplete();
						}
					};
					queue.AddLoader(fileLoader);
				}
				else
				{
					File.Copy(sourceFilePath, destFile, true);
				}
			}
			if (PlatformUtil.IsAndroidPlayer())
			{
				queue.OnLoadComplete = delegate (GLoaderQueue q)
				{
					if (onComplete != null)
					{
						onComplete();
					}
				};
				queue.Load();
			}
			else
			{
				if (onComplete != null)
				{
					onComplete();
				}
			}
		}
	}
}