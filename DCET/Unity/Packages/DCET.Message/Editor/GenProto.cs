using DCETRuntime;
using UnityEditor;

namespace DCETEditor
{
	public class GenProto
	{
		[MenuItem("Tools/Gen Proto")]
		public static void Gen()
		{
			ProcessHelper.Run("protogen.bat", null, "../Proto/", false);
			AssetDatabase.Refresh();
		}
	}
}
