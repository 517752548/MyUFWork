using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace anticheat
{
    public class InjectionDetector : ActDetectorBase
    {
        private AllowedAssembly[] allowedAssemblies;
        //private const string COMPONENT_NAME = "Injection Detector";
        private string[] hexTable;
        private static InjectionDetector instance;
        internal static bool isRunning;
        private bool signaturesAreNotGenuine;

        private string mm = "Black";

        private InjectionDetector()
        {
        }

        private bool AssemblyAllowed(Assembly ass)
        {
            string str = ass.GetName().Name;
            int assemblyHash = this.GetAssemblyHash(ass);
            for (int i = 0; i < this.allowedAssemblies.Length; i++)
            {
                AllowedAssembly assembly = this.allowedAssemblies[i];
                if ((assembly.name == str) && (Array.IndexOf<int>(assembly.hashes, assemblyHash) != -1))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Awake()
        {
            if (this.Init(instance, "Injection Detector"))
            {
                instance = this;
            }
        }

        public void Dispose()
        {
            Instance.DisposeInternal();
        }

        protected override void DisposeInternal()
        {
            base.DisposeInternal();
            instance = null;
        }

        /// <summary>
        /// 生成合法dll的名称集合，加密的txt
        /// FIXME XXX 该方法是个工具，上线时需要注掉
        /// </summary>
        public void genTxt()
        {
            this.hexTable = new string[0x100];
            for (int j = 0; j < 0x100; j++)
            {
                this.hexTable[j] = j.ToString("x2");
            }

            FileStream fs = new FileStream("./Assets/Resources/fndid.txt", FileMode.OpenOrCreate);
            BinaryWriter writer = new BinaryWriter(fs);

            int assNum = AppDomain.CurrentDomain.GetAssemblies().Length;
            writer.Write(assNum);
            foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
            {
                string str = ass.GetName().Name + ":" + this.GetAssemblyHash(ass);
                writer.Write(OString.EncryptDecrypt(str, mm));
                ClientLog.LogWarning(" " + ass.GetName().Name);
            }

            writer.Close();
            fs.Close();
        }

        private bool FindInjectionInCurrentAssemblies()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                //ClientLog.LogWaring("===" + assembly.GetName().Name);
                if (!this.AssemblyAllowed(assembly))
                {
                    return true;
                }
            }
            return false;
        }

        private int GetAssemblyHash(Assembly ass)
        {
            string str;
            AssemblyName name = ass.GetName();
            byte[] publicKeyToken = name.GetPublicKeyToken();
            if (publicKeyToken.Length == 8)
            {
                str = name.Name + this.PublicKeyTokenToString(publicKeyToken);
            }
            else
            {
                str = name.Name;
            }
            int num = 0;
            int num2 = str.Length;
            char[] charArr = str.ToCharArray();
            for (int i = 0; i < num2; i++)
            {

                num += charArr[i];
                num += num << 10;
                num ^= num >> 6;
            }
            num += num << 3;
            num ^= num >> 11;
            return (num + (num << 15));
        }

        private void LoadAndParseAllowedAssemblies()
        {
            //TODO 需要自行构建一个这个资源
            TextAsset asset = Resources.Load("fndid", typeof(TextAsset)) as TextAsset;
            if (asset == null)
            {
                this.signaturesAreNotGenuine = true;
            }
            else
            {
                char[] strArray = new char[] { ':' };
                MemoryStream stream = new MemoryStream(asset.bytes);
                BinaryReader reader = new BinaryReader(stream);
                int num = reader.ReadInt32();
                this.allowedAssemblies = new AllowedAssembly[num];
                for (int i = 0; i < num; i++)
                {
                    string[] strArray2 = OString.EncryptDecrypt(reader.ReadString(), mm).Split(strArray);
                    //string[] strArray2 = reader.ReadString().Split(strArray);
                    int length = strArray2.Length;
                    if (length > 1)
                    {
                        string name = strArray2[0];
                        int[] hashes = new int[length - 1];
                        for (int k = 1; k < length; k++)
                        {
                            hashes[k - 1] = int.Parse(strArray2[k]);
                        }
                        this.allowedAssemblies[i] = new AllowedAssembly(name, hashes);
                    }
                    else
                    {
                        this.signaturesAreNotGenuine = true;
                        reader.Close();
                        stream.Close();
                        return;
                    }
                }
                reader.Close();
                stream.Close();
                Resources.UnloadAsset(asset);
                this.hexTable = new string[0x100];
                for (int j = 0; j < 0x100; j++)
                {
                    this.hexTable[j] = j.ToString("x2");
                }
            }
        }

        private void OnInjectionDetected()
        {
            ClientLog.LogError("#InjectionDetector#OnCheatingDetected#");
            if (base.onDetection != null)
            {
                base.onDetection.Invoke();
            }
            //if (base.autoDispose)
            //{
            //    Dispose();
            //}
            //else
            //{
            //    this.StopDetectionInternal();
            //}
        }

        private void OnNewAssemblyLoaded(object sender, AssemblyLoadEventArgs args)
        {
            if (!this.AssemblyAllowed(args.LoadedAssembly))
            {
                ClientLog.LogError("#InjectionDetector#OnNewAssemblyLoaded#ass=" + args.LoadedAssembly.FullName);
                this.OnInjectionDetected();
            }
        }

        private string PublicKeyTokenToString(byte[] bytes)
        {
            string str = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                str = str + this.hexTable[bytes[i]];
            }
            return str;
        }

        public void StartDetection(UnityAction callback)
        {
            //只检测安卓
            if (Application.platform == RuntimePlatform.Android)
            {
                Instance.StartDetectionInternal(callback);
            }
        }

        private void StartDetectionInternal(UnityAction callback)
        {
            if (isRunning)
            {
                ClientLog.LogWarning("[ACT] Injection Detector already running!");
            }
            else
            {
                base.onDetection = callback;
                if (this.allowedAssemblies == null)
                {
                    this.LoadAndParseAllowedAssemblies();
                }
                if (this.signaturesAreNotGenuine)
                {
                    this.OnInjectionDetected();
                }
                else if (!this.FindInjectionInCurrentAssemblies())
                {
                    AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(this.OnNewAssemblyLoaded);
                    //TODO FIXME
                    //AppDomain.CurrentDomain.add_AssemblyLoad(new AssemblyLoadEventHandler(this.OnNewAssemblyLoaded));
                    isRunning = true;
                }
                else
                {
                    this.OnInjectionDetected();
                }
            }
        }

        public static void StopDetection()
        {
            Instance.StopDetectionInternal();
        }

        protected override void StopDetectionInternal()
        {
            if (isRunning)
            {
                AppDomain.CurrentDomain.AssemblyLoad -= new AssemblyLoadEventHandler(this.OnNewAssemblyLoaded);
                //TODO FIXME
                //AppDomain.CurrentDomain.remove_AssemblyLoad(new AssemblyLoadEventHandler(this.OnNewAssemblyLoaded));
                base.onDetection = null;
                isRunning = false;
            }
        }

        public static InjectionDetector Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                instance = new InjectionDetector();
                return instance;
                //InjectionDetector detector = UnityEngine.Object.FindObjectOfType(typeof(InjectionDetector)) as InjectionDetector;
                //if (detector == null)
                //{
                //    detector = new GameObject("Injection Detector").AddComponent<InjectionDetector>();
                //}
                //return detector;
            }
        }

        private class AllowedAssembly
        {
            public readonly int[] hashes;
            public readonly string name;

            public AllowedAssembly(string name, int[] hashes)
            {
                this.name = name;
                this.hashes = hashes;
            }
        }
    }
}

