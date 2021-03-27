using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
	/// 摇杆箭头
	public GameObject joystickArrow;

	/// 摇杆整体UI,方便Active
	public GameObject joystickUI;

	/// 摇杆重心
	public RectTransform joyCenter;

	/// 摇杆背景
	public RectTransform joyBackground;

	/// 摇杆出现的范围
	public RectTransform joystickRect;

	/// 摇杆滑动的范围
	public RectTransform joystickDragRect;

	// 箭头
	private RectTransform arrow;

	/// <summary>
	/// 半径
	/// </summary>
	private float joyRadius;

	// 摇杆角度
	[HideInInspector]
	public float angle = 0.0f;

	// 摇杆的x量
	[HideInInspector]
	public float xRange = 0.0f;

	// 摇杆的y量
	[HideInInspector]
	public float yRange = 0.0f;

	// 是否在移动
	[HideInInspector]
	public bool isMove = false;

	//摇杆外围起始位置
	private Vector2 joyRangeBeginPos;

	//摇杆中心起始位置
	private Vector2 joyCenterBeginPos;

	// 摇杆原始位置
	private Vector2 originalPos;

	// 鼠标的pos
	private Vector2 mousePos = new Vector2();

	// 方向
	public Vector3 targetDirection = new Vector3();

	// 鼠标点
	private PointerEventData eventData;

	// Use this for initialization
	void Start()
	{
		joyRadius = joyBackground.sizeDelta.x * 0.5f - joyCenter.rect.width * 0.5f;

		//joystickUI.SetActive(false);
		joystickArrow.SetActive(false);

		originalPos = joyBackground.anchoredPosition;

		arrow = joystickArrow.transform.parent.transform as RectTransform;
	}


	public void OnPointerDown(PointerEventData eventData)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickRect, eventData.position, eventData.pressEventCamera, out mousePos);

		if (mousePos.x > joystickRect.rect.xMax || mousePos.y > joystickRect.rect.yMax)
			return;

		this.eventData = eventData;
		isMove = true;

		//joyCenterBeginPos = Vector2.zero;
		//joyRangeBeginPos = mousePos;

		//将摇杆的中心位置设置为鼠标点击的位置，即动态变化摇杆位置
		//joyCenter.anchoredPosition = joyCenterBeginPos;
		//joyBackground.anchoredPosition = joyRangeBeginPos;

		//joystickUI.SetActive(true);
	}

	public void OnDrag(PointerEventData eventData)
	{
		this.eventData = eventData;

		
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		//joyRangeBeginPos = Vector2.Lerp(originalPos, joyRangeBeginPos, 0.2f);
		//joyBackground.anchoredPosition = joyRangeBeginPos;

		joyCenter.anchoredPosition = Vector2.zero;

		isMove = false;
		xRange = 0;
		yRange = 0;
		angle = 0;
		targetDirection = Vector3.zero;

		joystickArrow.SetActive(false);
		//joystickUI.SetActive(false);
	}

	//void UpdateJoyCenter(PointerEventData eventData, ref bool isMaxDir)
	void UpdateJoyCenter(PointerEventData eventData)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(joyBackground, eventData.position, eventData.pressEventCamera, out mousePos);

		//拖拽方向
		Vector2 dragDir = mousePos - joyCenterBeginPos;

		//拖拽距离
		if (dragDir.magnitude <= joyRadius)
		{
			joyCenter.anchoredPosition = mousePos;
			//isMaxDir = false;
		}
		else
		{
			joyCenter.anchoredPosition = dragDir.normalized * joyRadius;
			//isMaxDir = true;
		}

		// 获取拖动的delta值 （-1<DeltaX<1，-1<DeltaY<1）
		xRange = dragDir.normalized.x;
		yRange = dragDir.normalized.y;

		targetDirection.Set(xRange, 0, yRange);
		angle = Vector3.Angle(targetDirection, Vector3.forward);

		if (xRange > 0)
			angle = 360 - angle;

		if (arrow)
		{
			arrow.eulerAngles = new Vector3(0, 0, angle);
		}

		if (joystickArrow && (dragDir.magnitude > joyRadius * 0.4))
		{
			joystickArrow.SetActive(true);
		}
	}


	public void LateUpdate()
	{
		if (!isMove)
			return;

		// 更新摇杆中心点位置
		UpdateJoyCenter(eventData);

		
		//bool isMaxFar = false;
		//UpdateJoyCenter(eventData, ref isMaxFar);

		//if (!isMaxFar)
		//	return;

		//RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickDragRect, eventData.position, eventData.pressEventCamera, out mousePos);

		//if (mousePos.x > joystickDragRect.rect.xMax)
		//{
		//	mousePos.x = joystickDragRect.rect.xMax;
		//}

		//if (mousePos.y > joystickDragRect.rect.yMax)
		//{
		//	mousePos.y = joystickDragRect.rect.yMax;
		//}

		//joyRangeBeginPos = Vector2.Lerp(joyRangeBeginPos, mousePos, 0.06f);
		//joyBackground.anchoredPosition = joyRangeBeginPos;
	}





	/// 获取某个点（pos）某个朝向(dir)上的某个距离（dis）的点的坐标
	void GetPosByDis(ref Vector2 pos, float dir, float dis)
	{
		pos.x = pos.x + dis * Mathf.Sin(dir);
		pos.y = pos.y - dis * Mathf.Cos(dir);
	}

	bool GetLineIntersection(Vector2 line1_begin, Vector2 line1_end, Vector2 line2_begin, Vector2 line2_end, ref Vector2 pos)
	{
		float s02_x, s02_y, s10_x, s10_y, s32_x, s32_y, s_numer, t_numer, denom, t;

		s10_x = line1_end.x - line1_begin.x;
		s10_y = line1_end.y - line1_begin.y;

		s32_x = line2_end.x - line2_begin.x;
		s32_y = line2_end.y - line2_begin.y;

		denom = s10_x * s32_y - s32_x * s10_y;

		if (denom == 0)//平行或共线
			return false; // Collinear

		bool denomPositive = denom > 0;

		s02_x = line1_begin.x - line2_begin.x;
		s02_y = line1_begin.y - line2_begin.y;

		s_numer = s10_x * s02_y - s10_y * s02_x;
		if ((s_numer < 0) == denomPositive)//参数是大于等于0且小于等于1的，分子分母必须同号且分子小于等于分母
			return false; // No collision

		t_numer = s32_x * s02_y - s32_y * s02_x;
		if ((t_numer < 0) == denomPositive)
			return false; // No collision

		if (Mathf.Abs(s_numer) > Mathf.Abs(denom) || Mathf.Abs(t_numer) > Mathf.Abs(denom))
			return false; // No collision

		// Collision detected
		t = t_numer / denom;

		pos.x = line1_begin.x + (t * s10_x);
		pos.y = line1_begin.y + (t * s10_y);

		return true;
	}


	/// <summary>
	/// 改变图片alpha值
	/// </summary>
	/// <param name="alphaValue"></param>
	void ChangeAlpha(float alphaValue)
	{
		joyBackground.GetComponent<Image>().color = new Color(1, 1, 1, alphaValue);
		joyCenter.GetComponent<Image>().color = new Color(1, 1, 1, alphaValue);
	}

}
