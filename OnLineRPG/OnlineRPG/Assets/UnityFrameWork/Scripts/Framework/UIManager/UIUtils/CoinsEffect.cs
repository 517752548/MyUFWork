using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DG.Tweening;
using UnityEngine;

public class CoinsEffect : MonoBehaviour {

	private Transform targetTransform;
	private ParticleSystem particleSys;
	private ParticleSystem.Particle[] particles;
	private ParticleSystem.MainModule main;
	private bool canMove = false;
	public float speed = 0.006f;
	private Vector3 offset = new Vector3(0,1f,0);
	private Vector3 startOffset = Vector3.zero;
	private bool offsetAdd = true;
	private float maxDistance = 0;
	public void Fly(Transform targetTransform)
	{
		this.particleSys = this.GetComponent<ParticleSystem>();
		if (this.particleSys) 
		{

			
			this.targetTransform = targetTransform;

			StartCoroutine(DoMove());
		}
	}

	IEnumerator DoMove()
	{
		this.particles = new ParticleSystem.Particle[this.particleSys.main.maxParticles];
		//自定义粒子系统的模拟空间
		main = this.particleSys.main;
		main.simulationSpace = ParticleSystemSimulationSpace.Custom;
		main.customSimulationSpace = this.targetTransform;
		particleSys.Play(true);
		yield return new WaitForSeconds(0.5f);
		canMove = true;

	}

	private void Update()
	{
		if (this.particleSys && particleSys.isPlaying && canMove) 
		{
			int count = this.particleSys.GetParticles(this.particles);
			for (int i = 0; i < count; i++) 
			{
				//Vector3.MoveTowards()
				float distance = Vector3.Distance(particles[i].position, Vector3.zero);
				if (distance > maxDistance) maxDistance = distance;
				Debug.LogError(distance);
//				if (distance <= 0.01f)
//				{
//					this.particles[i].remainingLifetime = 0;
//				}
				//朝目标点插值缓动
				this.particles[i].position = Vector3.SlerpUnclamped(this.particles[i].position + startOffset, Vector3.zero, speed);
			}
			speed += 0.008f;
			if (startOffset.y >= 50)
			{
				offsetAdd = false;
				startOffset= Vector3.zero;
			}
			else
			{
				if(offsetAdd)
					startOffset += offset;
			}
			this.particleSys.SetParticles(this.particles, count);
		}
	}
}
