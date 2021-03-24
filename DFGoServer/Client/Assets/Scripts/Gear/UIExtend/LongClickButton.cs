using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[AddComponentMenu("UI/LongClickButton")]
public class LongClickButton : Button
{
	private bool isDown = false;
	private bool isDownSen = false;
	private float delay = 0.6f;
	private float lastIsDownTime = 0.0f;

	public class LongClickEvent : UnityEvent {}

	public class LongClickEventEx : UnityEvent<float> {}

	public float Delay
	{
		get { return delay; }
		set { delay = value; }
	}

	// 按下
	[SerializeField]
	private LongClickEvent m_onLongClickDown = new LongClickEvent();
	public LongClickEvent OnLongClickDown
	{
		get { return m_onLongClickDown; }
		set { m_onLongClickDown = value; }
	}

	// 抬起
	[SerializeField]
	private LongClickEventEx m_onLongClickUp = new LongClickEventEx();
	public LongClickEventEx OnLongClickUp
	{
		get { return m_onLongClickUp; }
		set { m_onLongClickUp = value; }
	}


	// 退出
	private LongClickEvent m_onLongClickExit = new LongClickEvent();
	public LongClickEvent OnLongClickExit
	{
		get { return m_onLongClickExit; }
		set { m_onLongClickExit = value; }
	}

	private void ResetTime()
	{
		isDown = false;
		isDownSen = false;
	}

	private void PressDown()
	{
		if (!IsActive() || !IsInteractable())
			return;

		isDownSen = true;
		if (null != OnLongClickDown)
			OnLongClickDown.Invoke();
	}


	private void PressUp(float time)
	{
		if (!IsActive() || !IsInteractable())
			return;

		if (null != OnLongClickUp)
			OnLongClickUp.Invoke(time);
		//ResetTime();

		isDown = false;
	}


	private void PressExit()
	{
		if (!IsActive() || !IsInteractable())
			return;

		if (null != OnLongClickExit)
			OnLongClickExit.Invoke();
		ResetTime();
	}

	void FixedUpdate()
	{
		// 如果按钮是被按下状态
		if (isDown && !isDownSen)
		{
			// 当前时间 -  按钮最后一次被按下的时间 > 延迟时间0.2秒
			if (Time.time - lastIsDownTime > delay)
			{
				// 记录按钮最后一次被按下的时间
				lastIsDownTime = Time.time;
				PressDown();
			}
		}
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);

		isDown = true;
		isDownSen = false;
		lastIsDownTime = Time.time;
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);

		// 在鼠标抬起的时候进行事件触发，时差大于600ms触发
		if (!isDown || !isDownSen)
		{
			ResetTime();
			return;
		}

		PressUp(0);
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		PressExit();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (isDownSen)
		{
			return;
		}
		base.OnPointerClick(eventData);
	}
}
