using System;
using UnityEngine;
using System.Collections.Generic;
using app.confirm;

public class InputManager : MonoBehaviour
{
    private static InputManager ins;
    public static InputManager Ins
    {
        get
        {
            if (ins == null)
            {
                ins = GameObject.Find("ScriptsRoot").GetComponent<InputManager>();
                if (ins == null)
                {
                    ins = GameObject.Find("ScriptsRoot").AddComponent<InputManager>();
                }
            }
            return ins;
        }
    }

    public InputManager()
    {
        GameSimpleEventCore.ins.AddListener("show_exit_game_alert", ShowExitGameAlert);
    }

    public const string STATIONARY_EVENT_TYPE = "STATIONARY_EVENT_TYPE";
    public const string CANCEL_STATIONARY_EVENT_TYPE = "CANCEL_STATIONARY_EVENT_TYPE";
    public const string DOWN_EVENT_TYPE = "DOWN_EVENT_TYPE";
    public const string UP_EVENT_TYPE = "UP_EVENT_TYPE";
    public const string MOVE_EVENT_TYPE = "MOVE_EVENT_TYPE";
    public const string CLICK_EVENT_TYPE = "CLICK_EVENT_TYPE";
    public const string DRAG_EVENT_TYPE = "DRAG_EVENT_TYPE";
    public const string SCALE_EVENT_TYPE = "SCALE_EVENT_TYPE";
    public const string ROTATE_EVENT_TYPE = "ROTATE_EVENT_TYPE";

    public const string SCREEN_DOWN_EVENT_TYPE = "SCREEN_DOWN_EVENT_TYPE";
    public const string SCREEN_UP_EVENT_TYPE = "SCREEN_UP_EVENT_TYPE";
    /// <summary>
    /// 开始触发 长按的 时间
    /// </summary>
    private const float STATIONARY_TIME=0.5f;
    /// <summary>
    /// 长按取消操作的 最小滑动距离（像素）
    /// </summary>
    private const float CANCEL_DISTANCE = 50f;
    /// <summary>
    /// 触摸特效
    /// </summary>
    private GameObject touchEffect;
    /// <summary>
    /// 手势监听字典。
    /// </summary>
    private Dictionary<string, Dictionary<GameObject, List<RMetaEvent>>> _listeners = new Dictionary<string, Dictionary<GameObject, List<RMetaEvent>>>();

    /// <summary>
    /// 当前的点击对象
    /// </summary>
    private GameObject currentClickObject;
    
    /// <summary>
    /// 当前拖拽的对象
    /// </summary>
    private GameObject currentDragObject;

    /// <summary>
    /// 当前长按的对象
    /// </summary>
    private GameObject currentStationaryObject;

    /// <summary>
    /// 缩放手势的上次间距
    /// </summary>
    private float lastDistance = -1;

    private Vector2 _dragDeltaPosition;
    /// <summary>
    /// 缩放的触发 阈值
    /// </summary>
    private int scaleThreshold = 50;

    private float _scaleDelta;
    private float _rotateDeltaAngular;

    /// <summary>
    /// 鼠标左键是否按下。
    /// </summary>
    private bool _isLeftMouseDown = false;

    private Vector2 _MouseDownPosition = Vector2.zero;
    /// <summary>
    /// 按下后是否有过滑动操作
    /// </summary>
    private bool _hasDownMove = false;

    public bool HasDownMove()
    {
        return _hasDownMove;
    }

    /// <summary>
    /// 按下后 有过滑动操作，并且滑动的范围超出取消长按的范围
    /// </summary>
    private bool _hasDownStationaryMove = false;
    /// <summary>
    /// 鼠标左键处于按下状态的持续时间（秒）。
    /// </summary>
    private float _leftMouseDownRetainSeconds = 0;

    /// <summary>
    /// 旋转 角度 每帧变化量
    /// </summary>
    public float RotateDeltaAngular
    {
        get { return _rotateDeltaAngular; }
        set { _rotateDeltaAngular = value; }
    }

    /// <summary>
    /// 平面拖拽 每帧变化量
    /// </summary>
    public Vector2 DargDeltaPosition
    {
        get { return _dragDeltaPosition; }
        set { _dragDeltaPosition = value; }
    }

    /// <summary>
    /// 缩放手势的每帧变化量，放大为正，缩小为负
    /// </summary>
    public float ScaleDelta
    {
        get { return _scaleDelta; }
        set { _scaleDelta = value; }
    }

    /// <summary>
    /// 添加 手势的监听
    /// </summary>
    /// <param name="eventType">事件类型，取自本类的静态常量</param>
    /// <param name="go"></param>
    /// <param name="listener"></param>
    public void AddListener(string eventType, GameObject go, RMetaEventHandler handler, System.Object param = null)
    {
        RMetaEvent data = new RMetaEvent(eventType, param, go, handler);
        Dictionary<GameObject, List<RMetaEvent>> listenersForEventType = null;
        if (_listeners.ContainsKey(eventType))
        {
            listenersForEventType = _listeners[eventType];
        }

        if (listenersForEventType == null)
        {
            listenersForEventType = new Dictionary<GameObject, List<RMetaEvent>>();
            _listeners.Add(eventType, listenersForEventType);
        }
        
        if (!listenersForEventType.ContainsKey(go))
        {
            List<RMetaEvent> events = new List<RMetaEvent>();
            events.Add(data);
            listenersForEventType.Add(go, events);
        }
        else
        {
            List<RMetaEvent> events = listenersForEventType[go];
            int len = events.Count;
            for (int i = 0; i < len; i++)
            {
                if (events[i].Handler == handler)
                {
                    return;
                }
            }
            events.Add(data);
        }
    }

    /// <summary>
    /// 移除 手势的监听
    /// </summary>
    /// <param name="eventType">事件类型，取自本类的静态常量</param>
    /// <param name="go"></param>
    public void RemoveListener(string eventType, GameObject go, RMetaEventHandler handler)
    {
        Dictionary<GameObject, List<RMetaEvent>> listenersForEventType = null;
        if (_listeners.ContainsKey(eventType))
        {
            listenersForEventType = _listeners[eventType];
        }
        if (listenersForEventType != null)
        {
            if (listenersForEventType.ContainsKey(go))
            {
                List<RMetaEvent> events = listenersForEventType[go];
                if (events != null)
                {
                    int len = events.Count;
                    for (int i = 0; i < len; i++)
                    {
                        if (events[i].Handler == handler)
                        {
                            events.RemoveAt(i);
                            break;
                        }
                    }
                }

                if (events == null || events.Count == 0)
                {
                    listenersForEventType.Remove(go);
                }
            }
        }
    }

    public void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        checkStationary(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        if (Input.GetAxis("Mouse X") != 0)
        {
            //鼠标滑动了
            doMove();
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            //缩放
            ScaleDelta += Input.GetAxis("Mouse ScrollWheel") * 100;
            //旋转
            _rotateDeltaAngular = Input.GetAxis("Mouse ScrollWheel") * 100;
            //回调所有监听
            TouchEventCallBack(ROTATE_EVENT_TYPE);

            //ClientLog.LogError("scaleDelta:  " + Time.deltaTime + "      " + ScaleDelta);
            if (Math.Abs(ScaleDelta) >= scaleThreshold)
            {
                //回调所有监听
                TouchEventCallBack(SCALE_EVENT_TYPE);
            }
        }
        else
        {
            ScaleDelta = 0;
            _rotateDeltaAngular = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //按下
            doTouchDown(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //弹起
            doTouchUp(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
#else
        #if UNITY_ANDROID
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClientLog.LogWarning("点击返回");
            GameSimpleEventCore.ins.DispatchEvent("exit_game", null);
            return;
        }
        #endif
        if (Input.touchCount == 0)
        {//手势弹起，清空标记
            _isLeftMouseDown = false;
            _leftMouseDownRetainSeconds = 0;
            currentDragObject = null;
            currentClickObject = null;
            currentStationaryObject = null;
            lastDistance = -1;
            ScaleDelta = 0;
            _rotateDeltaAngular = 0;
        }
        else if (Input.touchCount == 1)
        {
            lastDistance=-1;
            ScaleDelta = 0;
            switch (Input.touches[0].phase)
            {
                case TouchPhase.Began://按下
                    doTouchDown(Input.touches[0].position);
                    break;
                case TouchPhase.Moved://滑动
                    doMove();
                    doTouchMoved(Input.touches[0].position);
                    break;
                case TouchPhase.Ended://弹起
                    doTouchUp(Input.touches[0].position);
                    break;
                case TouchPhase.Stationary://长按
                    checkStationary(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
                    break;
                case TouchPhase.Canceled:
                    _isLeftMouseDown = false;
                    _leftMouseDownRetainSeconds = 0;
                    lastDistance = -1;
                    currentDragObject = null;
                    currentClickObject = null;
                    //currentStationaryObject = null;
                    //doTouchUp(Input.touches[0].position);
                    ClientLog.LogWarning("Touch Canceled!!!!!!!!!!");
                    break;
            }
        }
        /*
        else if (Input.touchCount == 2 && _listeners.ContainsKey(SCALE_EVENT_TYPE)&&(_listeners[SCALE_EVENT_TYPE] != null && _listeners[SCALE_EVENT_TYPE].Count > 0)
            && Input.touches[0].phase == TouchPhase.Moved && Input.touches[1].phase == TouchPhase.Moved)
        {
            //缩放
            if (lastDistance == -1)
            {
                lastDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
            }
            else
            {
                float currentDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                ScaleDelta = (lastDistance - currentDistance);
                //lastDistance = currentDistance;
                //ClientLog.LogError("scaleDelta:  "+Time.deltaTime+"      " + ScaleDelta);
                //回调所有监听
                if (Math.Abs(ScaleDelta) >= scaleThreshold*4)
                {
                    TouchEventCallBack(SCALE_EVENT_TYPE);
                }
            }
            //旋转
            _rotateDeltaAngular = SignedAngularGap(Input.touches[0], Input.touches[1], Input.touches[0].rawPosition, Input.touches[1].rawPosition);
            ////回调所有监听
            //TouchEventCallBack(ROTATE_EVENT_TYPE);
        }
        */
#endif
    }

    private void ShowExitGameAlert(object data)
    {
        WndManager.Ins.close(GlobalConstDefine.ConFirmWndView);
        ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, "您确定要退出游戏吗？", sureBtnHandler, cancelBtnHandler);
    }

    private void sureBtnHandler(RMetaEvent e)
    {
        ConfirmWnd.Ins.hide();
        Application.Quit();
    }

    private void cancelBtnHandler(RMetaEvent e)
    {
        ConfirmWnd.Ins.hide();
    }

    private void checkStationary(Vector2 position)
    {
        if (_isLeftMouseDown)
        {
            _leftMouseDownRetainSeconds += Time.unscaledDeltaTime;
            if (_leftMouseDownRetainSeconds >= STATIONARY_TIME)
            {
                doTouchStationary(position);
            }
        }
    }

    private void doTouchDown(Vector2 position)
    {
        _isLeftMouseDown = true;
        _leftMouseDownRetainSeconds = 0;
        _MouseDownPosition = position;

        if ((UGUIConfig.UICamera && UGUIConfig.UICamera.GetComponent<Camera>()))
        {//UI射线
            //从摄像机的原点向鼠标点击的对象身上设法一条射线
            Ray ray = UGUIConfig.UICamera.GetComponent<Camera>().ScreenPointToRay(position);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            //当射线碰撞到对象时
            if (hits != null && hits.Length>0)
            {
                for (int i=0;i<hits.Length;i++)
                {
                    if (hits[i].collider!=null&&hits[i].collider.gameObject!=null)
                    {
                        clickDownUpdateCurrent(hits[i].collider.gameObject);
                        //回调所有监听
                        TouchEventCallBack(DOWN_EVENT_TYPE, hits[i].collider.gameObject);
                    }
                }
            }
        }
        TouchEventCallBack(SCREEN_DOWN_EVENT_TYPE);
    }

    private bool clickDownUpdateCurrent(GameObject hitCollider)
    {
        bool collider = false;
        if (hitCollider != null)
        {
            Dictionary<GameObject, List<RMetaEvent>> _clickListener = null;
            if (_listeners.ContainsKey(CLICK_EVENT_TYPE))
            {
                _clickListener = _listeners[CLICK_EVENT_TYPE];
            }
            Dictionary<GameObject, List<RMetaEvent>> _dragListener = null;
            if (_listeners.ContainsKey(DRAG_EVENT_TYPE))
            {
                _dragListener = _listeners[DRAG_EVENT_TYPE];
            }
            if (_clickListener != null && _clickListener.ContainsKey(hitCollider))
            {
                currentClickObject = hitCollider;
                collider = true;
            }
            if (_dragListener != null && _dragListener.ContainsKey(hitCollider))
            {
                currentDragObject = hitCollider;
                collider = true;
            }
        }
        return collider;
    }

    private void doTouchUp(Vector2 position)
    {
        _isLeftMouseDown = false;
        try
        {
			if ((UGUIConfig.UICamera && UGUIConfig.UICamera.GetComponent<Camera>()))
			{
				//从摄像机的原点向鼠标点击的对象身上设法一条射线
				Ray ray = UGUIConfig.UICamera.GetComponent<Camera>().ScreenPointToRay(position);
				RaycastHit[] hits = Physics.RaycastAll(ray);
				//当射线碰撞到对象时
                if (hits != null && hits.Length>0)
				{
                    for (int i = 0; i < hits.Length; i++)
                    {
                        if (hits[i].collider != null && hits[i].collider.gameObject != null)
                        {
                            if (currentClickObject != null && currentClickObject == hits[i].collider.gameObject && !_hasDownMove)
                            {
                                TouchEventCallBack(CLICK_EVENT_TYPE, currentClickObject);
                            }
                            TouchEventCallBack(UP_EVENT_TYPE, hits[i].collider.gameObject);
                        }
                    }
				}
				else
				{
					if (_leftMouseDownRetainSeconds >= STATIONARY_TIME)
					{
                        if (currentStationaryObject != null && _hasDownStationaryMove && Vector2.Distance(_MouseDownPosition, position) > CANCEL_DISTANCE)
						{
							//取消长按
							TouchEventCallBack(CANCEL_STATIONARY_EVENT_TYPE,currentStationaryObject);
							currentStationaryObject = null;
						}
					}
				}
			}
            TouchEventCallBack(SCREEN_UP_EVENT_TYPE);
            _leftMouseDownRetainSeconds = 0;
        }
        catch (Exception e)
        {
            ClientLog.LogError("doTouchUp::: " + e.ToString());
        }

        _hasDownMove = false;
        _hasDownStationaryMove = false;
        _MouseDownPosition = Vector2.zero;
    }

    private void doMove()
    {
        if (_isLeftMouseDown)
        {
            _hasDownMove = true;
            _hasDownStationaryMove = true;
        }
        if (_leftMouseDownRetainSeconds >= STATIONARY_TIME)
        {
            Vector2 v2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            if (Vector2.Distance(v2, _MouseDownPosition) > CANCEL_DISTANCE)
            {
                _hasDownStationaryMove = true;
            }
            else
            {
                _hasDownStationaryMove = false;
            }
        }
    }

    private void doTouchMoved(Vector2 position)
    {
        //滑动
        if ((UGUIConfig.UICamera && UGUIConfig.UICamera.GetComponent<Camera>()))
        {
            //从摄像机的原点向鼠标点击的对象身上设法一条射线
            Ray ray = UGUIConfig.UICamera.GetComponent<Camera>().ScreenPointToRay(position);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            //当射线碰撞到对象时
            if (hits!=null&&hits.Length>0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].collider != null && hits[i].collider.gameObject != null)
                    {
                        //回调所有监听
                        TouchEventCallBack(MOVE_EVENT_TYPE, hits[i].collider.gameObject);
                    }
                }
            }
        }
        //拖拽或者点击
        _dragDeltaPosition = Input.touches[0].deltaPosition;
        //ClientLog.Log("拖拽:" + _dragDeltaPosition.x + "      " + _dragDeltaPosition.y);
        if (currentDragObject != null && Math.Abs(_dragDeltaPosition.x * 10) > 1)
        {
            //回调所有监听
            TouchEventCallBack(DRAG_EVENT_TYPE, currentDragObject);
            if (currentDragObject == currentClickObject)
            {//当前物体已经处理移动就不再处理点击
                currentClickObject = null;
            }
        }
    }

    private void doTouchStationary(Vector2 position)
    {
        //长按
        if ((UGUIConfig.UICamera && UGUIConfig.UICamera.GetComponent<Camera>()))
        {//UI射线
            //Vector2 position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //从摄像机的原点向鼠标点击的对象身上设法一条射线
            Ray ray = UGUIConfig.UICamera.GetComponent<Camera>().ScreenPointToRay(position);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            //当射线碰撞到对象时
            if (hits!=null&&hits.Length>0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].collider != null && hits[i].collider.gameObject != null)
                    {
                        //ClientLog.LogWarning("长按 22222222"+hit.collider.gameObject.name);
                        if (_listeners.ContainsKey(STATIONARY_EVENT_TYPE) &&
                            _listeners[STATIONARY_EVENT_TYPE].ContainsKey(hits[i].collider.gameObject))
                        {
                            currentStationaryObject = hits[i].collider.gameObject;
                            //回调所有监听
                            TouchEventCallBack(STATIONARY_EVENT_TYPE, hits[i].collider.gameObject);
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 回调所有监听
    /// </summary>
    /// <param name="eventType"></param>
    private void TouchEventCallBack(string eventType, GameObject go = null)
    {
        Dictionary<GameObject, List<RMetaEvent>> listenerList = null;
        if (_listeners.ContainsKey(eventType))
        {
            listenerList = _listeners[eventType];
        }
        if (listenerList != null && listenerList.Count > 0)
        {
            //执行所有拖拽的监听
            foreach (KeyValuePair<GameObject, List<RMetaEvent>> pair in listenerList)
            {
                if ((go == null || (go != null && pair.Key == go)) && pair.Value != null)
                {
                    int len = pair.Value.Count;
                    for (int i = 0; i < len; i++)
                    {
                        RMetaEvent rh = pair.Value[i];
                        rh.Handler(pair.Value[i]);
                        if (!pair.Value.Contains(rh))
                        {
                            //如果在回调中移除了监听
                            i--;
                        }
                    }

                }
            }
        }
        //使用完清空
        switch (eventType)
        {
            case CLICK_EVENT_TYPE:
            case DOWN_EVENT_TYPE:
            case SCREEN_DOWN_EVENT_TYPE:
            case UP_EVENT_TYPE:
            case SCREEN_UP_EVENT_TYPE:
            case MOVE_EVENT_TYPE:
            case STATIONARY_EVENT_TYPE:
            case CANCEL_STATIONARY_EVENT_TYPE:
                break;
            case DRAG_EVENT_TYPE:
                _dragDeltaPosition = Vector2.zero;
                break;
            case SCALE_EVENT_TYPE:
                ScaleDelta = 0;
                break;
            case ROTATE_EVENT_TYPE:
                RotateDeltaAngular = 0;
                break;
        }
    }

    /// <summary>
    /// 播放点击特效
    /// </summary>
    private void playTouchEffect()
    {
        if (touchEffect == null && SourceManager.Ins.hasAssetBundle(PathUtil.Ins.GetUIEffectPath("guangquan")))
        {
            touchEffect = SourceManager.Ins.createObjectFromAssetBundle(PathUtil.Ins.GetUIEffectPath("guangquan"));
            touchEffect.transform.SetParent(UGUIConfig.GetCanvasByWndType(WndType.BUBBLES).transform);
            touchEffect.name = "guangquan";
            touchEffect.layer = LayerConfig.Layer_UI;

            //touchEffectRQ = touchEffect.GetComponent<NGUIRenderQueue>();
        }
        if (touchEffect != null)
        {
            //更新RenderQueue
            //touchEffectRQ.UpdateRQ();
            //更新位置
            Vector3 uiposition = Input.mousePosition;
            //ClientLog.Log("uiposition:::::::" + uiposition + "    Application.platform: " + Application.platform);
            uiposition.z = 0f;
            ParticleSystem[] ps = touchEffect.GetComponentsInChildren<ParticleSystem>();
            touchEffect.transform.localPosition = uiposition;
            for (int i = 0; ps != null && ps.Length > 0 && i < ps.Length; i++)
            {//粒子特效播放
                ps[i].loop = false;
                if (!ps[i].isPlaying)
                {
                    ps[i].Play();
                }
            }
        }
    }
    
    public void Clear()
    {
        _listeners.Clear();
    }

    /// <summary>
    /// 获得两向量之间的角度
    /// </summary>
    /// <param name="dest0"></param>
    /// <param name="dest1"></param>
    /// <param name="raw0"></param>
    /// <param name="raw1"></param>
    /// <returns></returns>
    static float SignedAngularGap(Touch dest0, Touch dest1, Vector2 raw0, Vector2 raw1)
    {
        //单位向量
        Vector2 curDir = (dest0.position - dest1.position).normalized;
        Vector2 refDir = (raw0 - raw1).normalized;
        //旋转角度的对边长度
        float perpDot = (refDir.x * curDir.y) - (refDir.y * curDir.x);
        //旋转角度的临边长度
        float nearDot = Vector2.Dot(refDir, curDir);
        //反正切计算角度
        float signedangle = Mathf.Atan2(perpDot, nearDot);
        //弧度转度
        return Mathf.Rad2Deg * signedangle;
    }

}