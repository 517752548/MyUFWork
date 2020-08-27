using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CoinFly : MonoBehaviour
{

	private int minOffset = 10;

	private int maxOffset = 250;

	private int minRot = 5;

	private int maxRot = 20;

	private int speed = 0;

	private int rot = 0;

	private Vector3 rotrandom;

	public Transform content;

	private int rotSpeed = 0;

	private float rotAngle = 5;
	// Use this for initialization

	public void Fly(Transform targetpos)
	{
		content.localScale = Vector3.zero;
		Timer.Schedule(this,Random.Range(0,0.1f), () =>
		{
			content.localScale = new Vector3(100,100,100);
			content.localRotation = new Quaternion(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360),0);
			rotrandom = new Vector3(Random.Range(-1.0f,1f),Random.Range(-1.0f,1f),Random.Range(-1.0f,1f));
			rotSpeed = Random.Range(15, 20);
			content.localPosition = new Vector3(Random.Range(-minOffset, minOffset),Random.Range(0, minOffset),Random.Range(0, minOffset) - 300);
			float timedruction = Random.Range(0.25f, 0.35f);
			content.DOScale(Vector3.one * 500, timedruction);
			content.DOLocalMove(new Vector3(Random.Range(-maxOffset, maxOffset), Random.Range(0, maxOffset), Random.Range(0, maxOffset) - 300),timedruction ).SetEase(Ease.OutCubic).OnComplete(
				() =>
				{
					
					content.DOScale(new Vector3(300, 300, 300), 0.5f).SetEase(Ease.InCirc);
					content.DOMove(new Vector3(targetpos.position.x,targetpos.position.y,content.position.z), 0.8f).SetEase(Ease.InCubic).OnComplete(() =>
					{
						Destroy(gameObject,0.02f);
					}); });
		});

	}

	
	// Update is called once per frame
	void Update () {
		content.Rotate( rotrandom* rotSpeed * Time.deltaTime, rotAngle);
	}
}
