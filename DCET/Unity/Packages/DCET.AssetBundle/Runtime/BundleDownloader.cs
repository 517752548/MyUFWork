using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DCETRuntime
{
	/// <summary>
	/// 用来对比web端的资源，比较md5，对比下载资源
	/// </summary>
	public class BundleDownloader : IDisposable
	{
		private VersionConfig remoteVersionConfig;

		public Queue<string> bundles;

		public long TotalSize;

		public HashSet<string> downloadedBundles;

		public string downloadingBundle;

		public UnityWebRequestAsync webRequest;

		public BundleDownloader()
		{
			bundles = new Queue<string>();
			downloadedBundles = new HashSet<string>();
			downloadingBundle = string.Empty;
		}

		public void Dispose()
		{
			remoteVersionConfig = null;
			TotalSize = 0;
			bundles = null;
			downloadedBundles = null;
			downloadingBundle = null;
			webRequest?.Dispose();
		}

		public async Task<bool> StartAsync()
		{
			// 获取远程的Version.txt
			string versionUrl = "";

			try
			{
				using (UnityWebRequestAsync webRequestAsync = new UnityWebRequestAsync())
				{
					versionUrl = GlobalConfigComponent.Instance.GlobalProto.GetUrl() + "StreamingAssets/" + "Version.txt";

					var result = await webRequestAsync.DownloadAsync(versionUrl);

					if (string.IsNullOrWhiteSpace(result))
					{
						remoteVersionConfig = MongoHelper.FromJson<VersionConfig>(webRequestAsync.Request.downloadHandler.text);
					}
					else
					{
						Log.Error($"url: {versionUrl}; result:{result}");
						return false;
					}
				}

			}
			catch (Exception e)
			{
				Log.Error($"url: {versionUrl} {e}");
				return false;
			}

			// 获取streaming目录的Version.txt
			VersionConfig streamingVersionConfig = null;

			string versionPath = Path.Combine(PathHelper.AppResPath4Web, "Version.txt");

			using (UnityWebRequestAsync request = new UnityWebRequestAsync())
			{
				var result = await request.DownloadAsync(versionPath);

				if (string.IsNullOrWhiteSpace(result))
				{
					streamingVersionConfig = MongoHelper.FromJson<VersionConfig>(request.Request.downloadHandler.text);
				}
			}

			// 删掉远程不存在的文件
			DirectoryInfo directoryInfo = new DirectoryInfo(PathHelper.AppHotfixResPath);

			if (directoryInfo.Exists)
			{
				FileInfo[] fileInfos = directoryInfo.GetFiles();

				foreach (FileInfo fileInfo in fileInfos)
				{
					if (remoteVersionConfig.FileInfoDict.ContainsKey(fileInfo.Name))
					{
						continue;
					}

					if (fileInfo.Name == "Version.txt")
					{
						continue;
					}

					fileInfo.Delete();
				}
			}
			else
			{
				directoryInfo.Create();
			}

			// 对比MD5
			foreach (FileVersionInfo fileVersionInfo in remoteVersionConfig.FileInfoDict.Values)
			{
				// 对比md5
				string localFileMD5 = GetBundleMD5(streamingVersionConfig, fileVersionInfo.File);

				if (fileVersionInfo.MD5 == localFileMD5)
				{
					continue;
				}

				bundles.Enqueue(fileVersionInfo.File);
				TotalSize += fileVersionInfo.Size;
			}

			return true;
		}

		public static string GetBundleMD5(VersionConfig streamingVersionConfig, string bundleName)
		{
			string path = Path.Combine(PathHelper.AppHotfixResPath, bundleName);

			if (File.Exists(path))
			{
				return MD5Helper.FileMD5(path);
			}

			if (streamingVersionConfig != null && streamingVersionConfig.FileInfoDict.ContainsKey(bundleName))
			{
				return streamingVersionConfig.FileInfoDict[bundleName].MD5;
			}

			return "";
		}

		public int Progress
		{
			get
			{
				if (TotalSize == 0)
				{
					return 0;
				}

				long alreadyDownloadBytes = 0;

				foreach (string downloadedBundle in downloadedBundles)
				{
					long size = remoteVersionConfig.FileInfoDict[downloadedBundle].Size;
					alreadyDownloadBytes += size;
				}

				if (webRequest != null)
				{
					alreadyDownloadBytes += (long)webRequest.Request.downloadedBytes;
				}

				return (int)(alreadyDownloadBytes * 100f / TotalSize);
			}
		}

		public async Task<bool> DownloadAsync()
		{
			var result = true;

			if (bundles.Count == 0 && downloadingBundle == "")
			{
				return result;
			}

			try
			{
				while (true)
				{
					if (bundles.Count == 0)
					{
						break;
					}

					downloadingBundle = bundles.Dequeue();

					while (true)
					{
						try
						{
							using (webRequest = new UnityWebRequestAsync())
							{
								await webRequest.DownloadAsync(GlobalConfigComponent.Instance.GlobalProto.GetUrl() + "StreamingAssets/" + downloadingBundle);
								byte[] data = webRequest.Request.downloadHandler.data;

								string path = Path.Combine(PathHelper.AppHotfixResPath, downloadingBundle);
								
								using (FileStream fs = new FileStream(path, FileMode.Create))
								{
									fs.Write(data, 0, data.Length);
								}
							}
						}
						catch (Exception e)
						{
							Log.Error($"download bundle error: {downloadingBundle}\n{e}");
							result = false;
							continue;
						}

						break;
					}

					downloadedBundles.Add(downloadingBundle);
					downloadingBundle = "";
					webRequest = null;
				}
			}
			catch (Exception e)
			{
				Log.Exception(e);
				result = false;
			}

			return result;
		}
	}
}
