using System;
using System.Collections.Generic;
using System.Text;
using ETModel;
using UnityEngine;
using UnityEngine.Networking;

namespace ETHotfix
{
	[ObjectSystem]
	public class UnityWebRequestUpdateSystem : UpdateSystem<UnityWebRequestAsync>
	{
		public override void Update(UnityWebRequestAsync self)
		{
			self.Update();
		}
	}
	
	public class UnityWebRequestAsync : Component, System.IDisposable
	{

		public UnityWebRequest Request;

		public bool isCancel;

		public ETTaskCompletionSource tcs;
		
		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			base.Dispose();

			this.Request?.Dispose();
			this.Request = null;
			this.isCancel = false;
		}

		public float Progress
		{
			get
			{
				if (this.Request == null)
				{
					return 0;
				}
				return this.Request.downloadProgress;
			}
		}

		public ulong ByteDownloaded
		{
			get
			{
				if (this.Request == null)
				{
					return 0;
				}
				return this.Request.downloadedBytes;
			}
		}

		public void Update()
		{
			if (this.isCancel)
			{
				this.tcs.SetException(new Exception($"request error: {this.Request.error}"));
				return;
			}
			if (!this.Request.isDone)
			{
				return;
			}
			if (!string.IsNullOrEmpty(this.Request.error))
			{
				this.tcs.SetException(new Exception($"request error: {this.Request.error}"));
				return;
			}

			this.tcs.SetResult();
		}

		//text_get
		public ETTask Get(string url)
		{
			this.tcs = new ETTaskCompletionSource();
			
			this.Request = UnityWebRequest.Get(url);
			this.Request.SendWebRequest();
			return this.tcs.Task;
		}
		
		//texture_get
		public ETTask GetTexture(string url)
		{
			this.tcs = new ETTaskCompletionSource();
			
			this.Request = UnityWebRequestTexture.GetTexture(url);
			this.Request.SendWebRequest();
			return this.tcs.Task;
		}
		
		//File_get
		public ETTask GetFile(string url,string filePath)
		{
			this.tcs = new ETTaskCompletionSource();
			this.Request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET);
			this.Request.downloadHandler = new DownloadHandlerFile(filePath);
			this.Request.SendWebRequest();
			return this.tcs.Task;
		}
		
		//assetbundle_get
		public ETTask GetAssetBundle(string url)
		{
			this.tcs = new ETTaskCompletionSource();
			this.Request =  UnityWebRequestAssetBundle.GetAssetBundle(url);
			this.Request.SendWebRequest();
			return this.tcs.Task;
		}
		
		//form post
		public ETTask Post(string url,Dictionary<string, string> headers = null, WWWForm formData = null)
		{
			this.tcs = new ETTaskCompletionSource();
			this.Request =  UnityWebRequest.Post(url, formData);
			if (headers != null)
			{
				foreach (var key in headers.Keys)
				{
					this.Request.SetRequestHeader(key,headers[key]);
				}
			}
			this.Request.SendWebRequest();
			return this.tcs.Task;
		}
		
		//urlencode post
		public ETTask PostUrlEncode(string url,string content,Dictionary<string, string> headers = null )
		{
			this.tcs = new ETTaskCompletionSource();
			this.Request =  CreatUnityWebRequest(url, content, "application/x-www-form-urlencoded");
			if (headers != null)
			{
				foreach (var key in headers.Keys)
				{
					this.Request.SetRequestHeader(key,headers[key]);
				}
			}
			this.Request.SendWebRequest();
			return this.tcs.Task;
		}
		
		//json post
		public ETTask PostJson(string url,string content,Dictionary<string, string> headers = null )
		{
			this.tcs = new ETTaskCompletionSource();
			this.Request =  CreatUnityWebRequest(url, content, "application/json");
			if (headers != null)
			{
				foreach (var key in headers.Keys)
				{
					this.Request.SetRequestHeader(key,headers[key]);
				}
			}
			this.Request.SendWebRequest();
			return this.tcs.Task;
		}
		
		//xml post
		public ETTask PostXml(string url,string content,Dictionary<string, string> headers = null )
		{
			this.tcs = new ETTaskCompletionSource();
			this.Request =  CreatUnityWebRequest(url, content, "text/xml");
			if (headers != null)
			{
				foreach (var key in headers.Keys)
				{
					this.Request.SetRequestHeader(key,headers[key]);
				}
			}
			this.Request.SendWebRequest();
			return this.tcs.Task;
		}
		
		
		private UnityWebRequest CreatUnityWebRequest(string url, string data, string contentType)
		{
			UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
			webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(Encoding.UTF8.GetBytes(data));
			webRequest.uploadHandler.contentType = contentType;
			webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
			return webRequest;
		}
	}
}
