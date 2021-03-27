using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[AddComponentMenu("UI/LongClickToggle")]
public class LongClickToggle : Toggle
{
	private bool isDown = false;
	private bool isDownSen = false;

	private readonly float delay = 0.6f;
	private float lastIsDownTime = 0.0f;

	// 按下
	private UnityEvent _onLongDown = new UnityEvent();
	public UnityEvent OnLongClickDown
	{
		get { return _onLongDown; }
		set { _onLongDown = value; }
	}

	// 抬起
	private UnityEvent _onLongClickUp = new UnityEvent();
	public UnityEvent OnLongClickUp
	{
		get { return _onLongClickUp; }
		set { _onLongClickUp = value; }
	}

	// 退出
	private UnityEvent _onLongClickExit = new UnityEvent();
	public UnityEvent OnLongClickExit
	{
		get { return _onLongClickExit; }
		set { _onLongClickExit = value; }
	}



	private void ResetTime()
	{
		isDown = false;
		isDownSen = false;
	}

	private void Press()
	{
		isDownSen = true;
		if (null != OnLongClickDown)
			OnLongClickDown.Invoke();
	}
	
	private void InvokePressed()
	{
		if (IsPressed())
		{
			Press();
		}
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		if (!IsActive() || !IsInteractable())
			return;

		base.OnPointerDown(eventData);

		Invoke("InvokePressed", delay);

		isDown = true;
		isDownSen = false;

		lastIsDownTime = Time.time;
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		if (!IsActive() || !IsInteractable())
			return;

		base.OnPointerUp(eventData);

		// 在鼠标抬起的时候进行事件触发，时差大于600ms触发
		if (!isDown || !isDownSen)
		{
			ResetTime();
			return;
		}

		if (isDown)
		{
			if (Time.time - lastIsDownTime > delay)
				Press();
			else
				ResetTime();
		}
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		ResetTime();
	}


	///-----------------------------------------
	public override void OnPointerClick(PointerEventData eventData)
	{
		if (isDownSen)
		{
			return;
		}
		base.OnPointerClick(eventData);
	}
}