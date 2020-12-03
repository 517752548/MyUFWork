using DCETRuntime;
using UnityEditor;

namespace DCETEditor
{
	public static class FileServerEditor
	{

		[MenuItem("Tools/Start Asset Server")]
		public static void OpenFileServer()
		{
			ProcessHelper.Run("dotnet", "FileServer.dll", "../FileServer/");
		}
	}
}
