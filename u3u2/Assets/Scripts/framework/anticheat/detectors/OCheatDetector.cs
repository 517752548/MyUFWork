using UnityEngine.Events;

namespace anticheat
{
    public class OCheatDetector : ActDetectorBase
    {
        //private const string COMPONENT_NAME = "Obscured Cheating Detector";
        public float floatEpsilon = 0.0001f;
        private static OCheatDetector instance;
        internal static bool isRunning = false;
        public float quaternionEpsilon = 0.1f;
        public float vector2Epsilon = 0.1f;
        public float vector3Epsilon = 0.1f;

        private OCheatDetector()
        {
        }

        public override void Awake()
        {
            if (this.Init(instance, "Obscured Cheating Detector"))
            {
                instance = this;
            }
        }

        public static void Dispose()
        {
            Instance.DisposeInternal();
        }

        protected override void DisposeInternal()
        {
            base.DisposeInternal();
            instance = null;
        }

        internal void OnCheatingDetected()
        {
            ClientLog.LogError("#ObscuredCheatingDetector#OnCheatingDetected#");
            if (base.onDetection != null)
            {
                base.onDetection.Invoke();
                //if (base.autoDispose)
                //{
                //    Dispose();
                //}
                //else
                //{
                //    StopDetection();
                //}
            }
        }

        public void StartDetection(UnityAction callback)
        {
            Instance.StartDetectionInternal(callback);
        }

        private void StartDetectionInternal(UnityAction callback)
        {
            if (isRunning)
            {
                ClientLog.LogWarning("[ACT] Obscured Cheating Detector already running!");
            }
            else
            {
                base.onDetection = callback;
                isRunning = true;
            }
        }

        public void StopDetection()
        {
            Instance.StopDetectionInternal();
        }

        protected override void StopDetectionInternal()
        {
            if (isRunning)
            {
                base.onDetection = null;
                isRunning = false;
            }
        }

        public static OCheatDetector Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                instance = new OCheatDetector();
                //ObscuredCheatingDetector detector = UnityEngine.Object.FindObjectOfType(typeof(ObscuredCheatingDetector)) as ObscuredCheatingDetector;
                //if (detector == null)
                //{
                //    detector = new GameObject("Obscured Cheating Detector").AddComponent<ObscuredCheatingDetector>();
                //}
                return instance;
            }
        }
    }
}

