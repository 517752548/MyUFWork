using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToggle : MonoBehaviour {

	private bool _isOn;

	private Animator m_ani
	{
		get
		{
			if (_ani == null)
			{
				_ani = transform.GetComponent<Animator>();
			}

			return _ani;
		}
	}
	private Animator _ani;
	protected bool m_inited = false;

	public bool IsOn {
		get {
			return _isOn;
		}
		set {
			if (value != _isOn) {
				_isOn = value;
				if (m_inited) {
					UpdateUI();
				}
			}
		}
	}

	public void SetStatus(bool on)
	{
		m_ani.SetBool("ON", on);
		m_inited = false;
	}
	private void UpdateUI()
	{
		if (IsOn) {
			m_ani.SetTrigger("OFFtoON");
		} else {
			m_ani.SetTrigger("ONtoOFF");
		}
	}

	protected virtual void Awake()
	{
		_ani = transform.GetComponent<Animator>();
		m_inited = true;
	}

	private void OnEnable()
	{
		
	}

	private void OnDisable()
	{
		
	}

	protected virtual void Start()
	{
		
	}

}
