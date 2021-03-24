using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class CircleList : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
	//item列表
	private List<RectTransform> mItemTransformList = new List<RectTransform>();

	//item辅助列表，用于处理遮挡关系
	private List<RectTransform> mAssistmItemTransformList = new List<RectTransform>();

	//旋转的角度
	private float mRotateAngle = 0;

	//两个item之间的差角
	private float mDeltaAngle = 0;

	//椭圆圆心的横坐标
	public float CenterX;

	//椭圆圆心的纵坐标
	public float CenterY;

	//椭圆的半长轴
	public float RadiusX = 400;

	//椭圆的半短轴
	public float RadiusY = 150;

	//最小缩放比例
	public float MinScale = 0.2f;

	//最大缩放比例
	public float MaxScale = 1.0f;

	//移动速度参数
	[Range(0, 1)]
	public float Speed = 0.3f;

	//调整位置参数
	[Range(0, 1)]
	public float AdjustArg = 0.7f;

	//椭圆的旋转角度
	[Range(-Mathf.PI, Mathf.PI)]
	public float OriginalRotation = 0f;

	//是否自动转动
	public bool IsAutoMove = false;

	//移动速度参数
	[Range(-1, 1)]
	public float AutoMoveSpeed = 0.1f;

	const float SpeedArg = 1.0f / 200;

	// 是否在拖拽中
	bool isDrag = false;

	// 是否点击了
	bool mIsDragging = false;

	private UnityEvent m_ClickEvent = new UnityEvent();
	public UnityEvent OnClick
	{
		get { return m_ClickEvent; }
		set { m_ClickEvent = value; }
	}


	//添加一个item
	public void AddItem(RectTransform item)
	{
		item.SetParent(transform);
		mItemTransformList.Add(item);
		mAssistmItemTransformList.Add(item);
		//重新计算两个item之间的差角
		mDeltaAngle = 2 * Mathf.PI / mItemTransformList.Count;
		//重新设置每个item的位置和缩放
		SetPosiztionByDistance();
	}



	//插入一个item
	public void InsertItem(int index, RectTransform item)
	{
		item.SetParent(transform);
		item.localPosition = new Vector3(0, 0, 0);
		mItemTransformList.Insert(index, item);
		mAssistmItemTransformList.Add(item);
		//重新计算连个item之间的差角
		mDeltaAngle = 2 * Mathf.PI / mItemTransformList.Count;
		//重新设置每个item的位置和缩放
		SetPosiztionByDistance();
	}

	//批量加入item
	public void BatchAddItem(RectTransform[] rectTransformList)
	{
		foreach (var item in rectTransformList)
		{
			item.SetParent(transform);
			item.localPosition = new Vector3(0, 0, 0);
			mItemTransformList.Add(item);
			mAssistmItemTransformList.Add(item);
		}

		//重新计算连个item之间的差角
		mDeltaAngle = 2 * Mathf.PI / mItemTransformList.Count;

		//重新设置每个item的位置和缩放
		SetPosiztionByDistance();
	}

	//移除一个item
	public void RemoveItem(int idx = 0)
	{
		if (mItemTransformList.Count == 0)
			return;

		RectTransform item = mItemTransformList[idx];
		if (item == null)
			return;

		mItemTransformList.Remove(item);
		mAssistmItemTransformList.Remove(item);
		Destroy(item.gameObject);

		//重新计算连个item之间的差角
		mDeltaAngle = 2 * Mathf.PI / mItemTransformList.Count;

		//重新设置每个item的位置和缩放
		SetPosiztionByDistance();
	}

	//移除一个item
	public void RemoveAll()
	{
		foreach (RectTransform item in mItemTransformList)
		{
			Destroy(item.gameObject);
		}

		mItemTransformList.Clear();
		mAssistmItemTransformList.Clear();

	}

	//根据当前的参数设置所有item的位置和缩放
	void SetPosiztionByDistance()
	{
		if (mItemTransformList.Count == 0)
			return;

		//根据当前的旋转角设置每个item的大小和位置
		for (int i = 0; i < mItemTransformList.Count; i++)
		{
			float realAngle = mRotateAngle + mDeltaAngle * i;

			//将每个item的旋转角控制在[0，2π]之间
			if (realAngle > 2 * Mathf.PI)
				realAngle -= 2 * Mathf.PI;

			//根据参数AdjustArg参数调整角度参数
			if (realAngle < Mathf.PI)
			{
				realAngle *= (AdjustArg + (1 - AdjustArg) * realAngle / Mathf.PI);
			}
			else
			{
				realAngle = 2 * Mathf.PI - ((2 * Mathf.PI - realAngle) * (AdjustArg + (1 - AdjustArg) * (2 * Mathf.PI - realAngle) / Mathf.PI));
			}

			float sinValue = Mathf.Sin(realAngle);
			float cosValue = Mathf.Cos(realAngle);

			//根据椭圆的旋转角调整位置
			float originalXPosition = sinValue * RadiusX;
			float originalYPosition = cosValue * RadiusY;
			float xPosition = Mathf.Cos(OriginalRotation) * originalXPosition + Mathf.Sin(OriginalRotation) * originalYPosition + CenterX;
			float yPosition = -Mathf.Sin(OriginalRotation) * originalXPosition + Mathf.Cos(OriginalRotation) * originalYPosition + CenterY;			
			mItemTransformList[i].anchoredPosition = new Vector2(xPosition, yPosition);

			float scaleValue;
			if (realAngle < Mathf.PI)
			{
				scaleValue = MinScale + (MaxScale - MinScale) * realAngle / Mathf.PI;
			}
			else
			{
				scaleValue = MinScale + (MaxScale - MinScale) * (2 * Mathf.PI - realAngle) / Mathf.PI;
			}
			mItemTransformList[i].localScale = Vector3.one * scaleValue;
		}
		//根据缩放大小判断item之间的遮挡关系，重新进行层级的排序
		mAssistmItemTransformList.Sort(assistItemComparison);
		for (int i = 0; i < mAssistmItemTransformList.Count; i++)
		{
			mAssistmItemTransformList[i].SetAsLastSibling();
		}
	}

	//层级比较函数，这里使用item的y坐标进行比较，可以根据需要进行修改
	int assistItemComparison(RectTransform x, RectTransform y)
	{
		if (x.localScale.x - y.localScale.x > 0)
		{
			return 1;
		}
		else if (x.localScale.x - y.localScale.x < 0)
		{
			return -1;
		}
		return 0;
	}

	//将一个角度加到旋转角上，同时要控制旋转角在[0，2π]之间，防止角度过大越界
	public float AddToRotateAngle(float delt)
	{
		mRotateAngle += delt;
		mRotateAngle -= Mathf.FloorToInt(mRotateAngle / 2 / Mathf.PI) * 2 * Mathf.PI;
		return mRotateAngle;
	}

	public void LateUpdate()
	{
		if (IsAutoMove && mIsDragging == false)
		{
			AddToRotateAngle(-AutoMoveSpeed * Time.unscaledDeltaTime);
			SetPosiztionByDistance();
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector2 localCursor;
		if (!RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)transform, eventData.position, eventData.pressEventCamera, out localCursor))
			return;

		Vector2 localPosition = new Vector2(localCursor.x - CenterX, localCursor.y - CenterY);
		Vector2 normal = new Vector2(localPosition.y, -localPosition.x);
		normal.Normalize();

		float speed = Vector2.Dot(eventData.delta, normal);
		speed *= Speed * SpeedArg;
		AddToRotateAngle(speed);
		SetPosiztionByDistance();
	}


	public void OnBeginDrag(PointerEventData eventData)
	{
		isDrag = true;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		isDrag = false;
	}

	public void OnPointerDown(PointerEventData data)
	{
		mIsDragging = true;
	}

	public void OnPointerUp(PointerEventData data)
	{
		mIsDragging = false;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (isDrag == true || mIsDragging == true)
			return;

		OnClick.Invoke();
	}

}
