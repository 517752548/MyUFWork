using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UIDrawModelPanelVO : ScriptableObject
{
	[SerializeField]
	public string prefabKey = "";
	[SerializeField]
	public string prefabName = "";
	[SerializeField]
	public int panelType; //UIDrawModelUtil.UIPanelType
	[SerializeField]
	public string textureNodePath = "";
	[SerializeField]
	public List<UIDrawModelData> modelDatas;
	[NonSerialized]
	public string optionName = "";
	[NonSerialized]
	public GameObject textureNodeGameObject;
	[NonSerialized]
	public GameObject panelGameObject;
	[SerializeField]
	public Vector3 lightEulerAngles;
	[SerializeField]
	public Color lightColor;
	[SerializeField]
	public float lightIntensity;
	[SerializeField]
	public float lightShadowStrength;


	public void ShowPanel(Transform parent)
	{
		if (panelGameObject == null)
		{
			return;
		}
		panelGameObject.transform.SetParent(parent, false);
		panelGameObject.transform.localPosition = Vector3.zero;
		panelGameObject.transform.localRotation = Quaternion.identity;
		panelGameObject.transform.localScale = Vector3.one;
	}

	public UIDrawModelData GetModelData(int charType, int modelId)
	{
		foreach (UIDrawModelData data in modelDatas)
		{
			if (data.charType == charType && data.modelId == modelId)
			{
				return data;
			}
		}
		//找不到新创建一个
		UIDrawModelData newData = new UIDrawModelData();
		newData.charType = charType;
		newData.modelId = modelId;
		modelDatas.Add(newData);
		return newData;
	}

	public void ChangeTextureSize(int size)
	{
		((RectTransform)textureNodeGameObject.transform).sizeDelta = new Vector2(size, size);
	}
	public string GetPath()
	{
		return string.Format("Assets/Res/Config/DrawModelData/DrawModelData_{0}.asset", prefabKey);
	}
}
