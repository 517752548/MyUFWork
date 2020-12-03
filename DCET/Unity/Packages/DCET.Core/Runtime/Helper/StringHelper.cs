using System.Text;

namespace DCETRuntime
{
	public static class StringHelper
	{
		public static byte[] ToByteArray(this string str)
		{
			return Encoding.Default.GetBytes(str);
		}
	}
}
