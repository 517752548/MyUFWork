﻿using UnityEngine;

namespace ET
{
	public interface IUIFactory
	{
		UI Create(Scene scene, string type, GameObject parent);
		void Remove(string type);
	}
}