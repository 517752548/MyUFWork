using UnityEngine;

namespace DCETRuntime
{
	public static class AnimatorHelper
	{
		public static string GetName(this AnimatorControllerParameter animatorControllerParameter)
		{
			if (animatorControllerParameter != null)
			{
				return animatorControllerParameter.name;
			}

			return string.Empty;
		}
	}
}
