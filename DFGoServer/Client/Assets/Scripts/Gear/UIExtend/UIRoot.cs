using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIRoot : MonoBehaviour
{
	public delegate void OnChangeScreenSizeComplete();
	private Transform canvasTSF;
	private Transform uiCameraTSF;
	private Camera uiCamera;
	private CanvasScaler canvasScaler;

	private int _originalWidth = 0;
	private int _originalHeight = 0;
	private Vector2 _fullSizeDelta = Vector2.zero;
	private Vector2 _uiReferenceResolution = new Vector2(1080, 1920);
	private Vector2 _uiCanvasFullSize = Vector2.zero;
	private Vector2 _uiCanvasSafeSize = Vector2.zero;
	private int currLimitWidth = -1;
	public void Init()
	{
		DontDestroyOnLoad(gameObject);

		canvasTSF = transform.Find("Canvas");

		uiCameraTSF = transform.Find("UICamera");
		uiCamera = uiCameraTSF.GetComponent<Camera>();
		canvasScaler = canvasTSF.GetComponent<CanvasScaler>();
		canvasScaler.matchWidthOrHeight = 0;
		//记录下刚开始的游戏分辨率的高度
		_originalWidth = Screen.width;
		_originalHeight = Screen.height;
	}

	public void SetUICameraOrthographicSize(float value)
	{
		if (uiCamera == null)
			return;
		uiCamera.orthographicSize = value;
	}

	public void SetCanvasScalerReferenceResolution(Vector2 value)
	{
		if (canvasScaler == null)
			return;
		canvasScaler.referenceResolution = value;
	}

	public Transform GetStage()
	{
		return canvasTSF;
	}

	public Camera GetStageCamera()
	{
		return uiCamera;
	}

	public Vector2 GetScreenFullSizeDelta()
	{
		return _fullSizeDelta;
	}

	public Vector2 GetUIReferenceResolution()
	{
		return _uiReferenceResolution;
	}

	public Vector2 GetCanvasFullSize()
	{
		return _uiCanvasFullSize;
	}

	public Vector2 GetCanvasSafeSize()
	{
		return _uiCanvasSafeSize;
	}

	public void UpdateScreenSize(int limitWidth = 0, OnChangeScreenSizeComplete onComplete = null)
	{
		if (currLimitWidth == limitWidth)
		{
			return;
		}

		currLimitWidth = limitWidth;
		if (PlatformUtil.IsRunInEditor() || PlatformUtil.IsWindowsPlayer())
		{
			limitWidth = _originalWidth;
		}
		else
		{
			if (PlatformUtil.IsIPhonePlayer())
			{
				limitWidth = limitWidth == 0 ? 1080 : limitWidth;
			}
			else
			{
				limitWidth = limitWidth == 0 ? 1080 : limitWidth;
			}
		}
		//特殊机型强制处理
		string deviceModel = SystemInfo.deviceModel.ToLower();
		Debug.Log("DeviceModel:" + deviceModel);
		if (deviceModel.Equals("meizu mx5"))
		{
			limitWidth = _originalWidth;
		}

		int fullWidth = Mathf.Min(limitWidth, _originalWidth);
		int fullHeight = 0;
		float fullRate = (float)_originalWidth / (float)_originalHeight;
		fullHeight = Mathf.CeilToInt((float)fullWidth / fullRate);
		_fullSizeDelta = new Vector2(fullWidth, fullHeight);
		Screen.SetResolution(fullWidth, fullHeight, true);//设置屏幕分辨率之后 要过一帧才能刷新安全区等



		EnterFrameTimer timer = new EnterFrameTimer(10, 1);
		timer.onComplete = delegate ()
		{
			timer.Dispose();
			timer = null;

			int canvasFullWidth = (int) GetUIReferenceResolution().x; 
			int canvasFullHeight = Mathf.CeilToInt(GetUIReferenceResolution().x / fullRate);
			_uiCanvasFullSize = new Vector2(canvasFullWidth, canvasFullHeight);

			//Rect safeRect = Screen.safeArea; //TODO不使用unity的这个safeArea了，因为和下面这一整套计算方式不匹配。在Android P版本系统还是使用插件返回的刘海高度来计算了
			float safeWidth = fullWidth;
			float safeHeight = fullHeight;
			Debug.Log(string.Format("safeHeight {0} fullHeight {1}", safeHeight, fullHeight));
			if (PlatformUtil.IsAndroidPlayer()) //针对android刘海的判断，如果Screen.safeArea和屏幕的大小一样，说明可能没生效（不是Android P系统），进一步通过JNI获取Notch的大小，然后safeWidth or safeHeight减去这个即可
			{
				int notchHeight = 0;
				AndroidJavaObject currActivity = JProxy.GetCurrentActivity();
				if (currActivity != null)
				{ 
					notchHeight = currActivity.Call<int>("getNotchHeight");
				}
				Debug.Log(string.Format("notchHeight {0}", notchHeight));
				safeHeight -= ((float)notchHeight * 2);
			}
			else if (PlatformUtil.IsIPhonePlayer())
			{
				safeWidth -= 60f;
			}
			float safeRate = safeWidth / safeHeight;

			int canvasSafeWidth = (int)GetUIReferenceResolution().x;
			int canvasSafeHeight = Mathf.CeilToInt(GetUIReferenceResolution().x / safeRate);
			_uiCanvasSafeSize = new Vector2(canvasSafeWidth, canvasSafeHeight);

			SetUICameraOrthographicSize(Mathf.Max(GetUIReferenceResolution().y / 2f / 100f,
				GetScreenFullSizeDelta().y / 2f / 100f));
			SetCanvasScalerReferenceResolution(GetUIReferenceResolution());

			string temp = "CurrentResolution {0} {1} | Fullsize {2} {3} | SafeArea {4} {5} | UIFullsize {6} {7} | UISafesize {8} {9} | ScreenOutput {10} {11} | RecordOriginal {12} {13}";

			Debug.Log(string.Format(temp, Screen.currentResolution.width, Screen.currentResolution.height,
											_fullSizeDelta.x, _fullSizeDelta.y,
											safeWidth, safeHeight,
											_uiCanvasFullSize.x, _uiCanvasFullSize.y,
											_uiCanvasSafeSize.x, _uiCanvasSafeSize.y,
											Screen.width, Screen.height,
											_originalWidth, _originalHeight));

			if (onComplete != null)
			{
				onComplete();
			}
		};
		timer.Start();
	}
}
