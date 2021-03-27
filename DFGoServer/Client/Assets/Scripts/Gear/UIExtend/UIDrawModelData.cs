using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class UIDrawModelData
{
	[SerializeField]
	public int charType = 0;//这个和global.lua中的CharType对应
	[SerializeField]
	public int modelId = 0;
	[SerializeField]
	public int textureSize = 700;
	[SerializeField]
	public Vector3 cameraPos = Vector3.zero;
	[SerializeField]
	public Vector3 cameraEulerAngles = new Vector3(0, 0, 0);
	[SerializeField]
	public Vector3 cameraPosGap = Vector3.zero;
}