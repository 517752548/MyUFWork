using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class SkipMotionCurveData
{
	[SerializeField]
	public string typeName = "";
	[SerializeField]
	public AnimationCurve curve_x_axial = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 0));
	[SerializeField]
	public AnimationCurve curve_y_axial = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 0));
	[SerializeField]
	public AnimationCurve curve_speed = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 1));
	[SerializeField]
	public AnimationCurve curve_scale = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 1));
	[SerializeField]
	public AnimationCurve curve_alpha = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 1));
	[SerializeField]
	public int duration = 1000;
}
