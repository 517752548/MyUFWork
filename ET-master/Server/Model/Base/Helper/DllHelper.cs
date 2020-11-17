using System.IO;
using System.Reflection;

namespace ET
{
    public static class DllHelper
    {
        public static Assembly GetHotfixAssembly()
        {
            var dllBytes = File.ReadAllBytes("./Hotfix.dll");
            var pdbBytes = File.ReadAllBytes("./Hotfix.pdb");
            Assembly assembly = Assembly.Load(dllBytes, pdbBytes);
            return assembly;
        }
    }
}