using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//双击按钮
[AddComponentMenu("UI/DoubleClickButton")]
public class DoubleClickButton : Button
{
	public class DoubleClickedEvent : UnityEvent { }

	private DoubleClickedEvent m_onDoubleClick = new DoubleClickedEvent();

	//这个是双击成功后激活的事件
	public DoubleClickedEvent OnDoubleClick
	{
		get { return m_onDoubleClick; }
		set { m_onDoubleClick = value; }
	}

	private DateTime m_firstTime;
	private DateTime m_secondTime;

	private void Press()
	{
		if (null != OnDoubleClick)
			OnDoubleClick.Invoke();
		ResetTime();
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);
		// 按下按钮时对两次的时间进行记录
		if (m_firstTime.Equals(default(DateTime)))
			m_firstTime = DateTime.Now;
		else
			m_secondTime = DateTime.Now;
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);
		// 在第二次鼠标抬起的时候进行时间的触发,时差小于400ms触发
		if (!m_firstTime.Equals(default(DateTime)) && !m_secondTime.Equals(default(DateTime)))
		{
			var intervalTime = m_secondTime - m_firstTime;
			float milliSeconds = intervalTime.Seconds * 1000 + intervalTime.Milliseconds;
			if (milliSeconds < 400)
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

	private void ResetTime()
	{
		m_firstTime = default(DateTime);
		m_secondTime = default(DateTime);
	}
}