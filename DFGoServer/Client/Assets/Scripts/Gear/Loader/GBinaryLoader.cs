using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GBinaryLoader : GBaseLoader
{
	protected UnityWebRequest _request;

	public override float Progress
	{
		get
		{
			if (_request == null)
			{
				return 0;
			}
			return _request.downloadProgress;
		}
	}

	public override ulong LoadedBytes
	{
		get
		{
			if (_request == null)
			{
				return 0;
			}
			return _request.downloadedBytes;
		}
	}

	public bool IsHttpError
	{
		get
		{
			if (_request == null)
			{
				return false;
			}
			return _request.isHttpError;
		}
	}


	public bool IsNetworkError
	{
		get
		{
			if (_request == null)
			{
				return false;
			}
			return _request.isNetworkError;
		}
	}

	public string Error
	{
		get
		{
			if (_request == null)
			{
				return "";
			}
			return _request.error;
		}
	}

	public override bool IsFinished
	{
		get
		{
			if (_request == null)
			{
				return false;
			}
			if (_request.downloadHandler == null)
			{
				return false;
			}
			return _request.isDone && _request.downloadHandler.isDone;
		}
	}
	public override object Content
	{
		get
		{
			if (!IsFinished)
			{
				return null;
			}
			return _request.downloadHandler.data;
		}
	}

	protected virtual DownloadHandler GetDownloadHandler()
	{
		return new DownloadHandlerBuffer();
	}

	public virtual void Load(string method, WWWForm form)
	{
		if (_request == null)
		{
			if (method.Equals(UnityWebRequest.kHttpVerbPOST))
			{
				_request = UnityWebRequest.Post(_url, form);
			}
			else if(method.Equals(UnityWebRequest.kHttpVerbGET))
			{
				_request = UnityWebRequest.Get(_url);
			}
		}

		if (_request != null)
		{
			Load();
		}
	}

	public override void Load()
	{
		if (_url == null || _url == string.Empty)
		{
			return;
		}
		if (_request == null)
		{
			_request = new UnityWebRequest();
		}
		_request.disposeDownloadHandlerOnDispose = true;
		if (_url.StartsWith("http") == false && _url.StartsWith("https") == false && _url.StartsWith("jar") == false)
		{
			if (_url.StartsWith("file://") == false)
			{
				_url = "file://" + _url;
			}
		}
		if (_request.url != _url)
		{
			_request.url = _url;
		}
		if (_request.downloadHandler == null)
		{
			_request.downloadHandler = GetDownloadHandler();
		}
		_request.SendWebRequest();
		base.Load();
	}

	public override void Close()
	{
		if (_request != null)
		{
			_request.Abort();
		}
		base.Close();
	}

	public override void OnTick()
	{
		if (_request == null)
		{
			return;
		}
		_loadTime = Time.time - _startLoadStamp;
		if (_request.isHttpError || _request.isNetworkError)
		{
			Close();
			InvokeLoadError();
			if (_autoDispose)
			{
				Dispose();
			}
			return;
		}
		if (_request.downloadProgress != _progress)
		{
			_progress = _request.downloadProgress;
			InvokeLoadProgress();
		}
		if (_request.isDone && _request.downloadHandler.isDone && _request.responseCode == 200)
		{
			Close();
			InvokeLoadComplete();
			if (_autoDispose)
			{
				Dispose();
			}
		}
	}

	public override void OnLateTick()
	{
		
	}

	public override void Dispose()
	{
		Close();
		if (_request != null)
		{
			_request.Dispose();
			_request = null;
		}
		base.Dispose();
	}

}
