using System;
using UnityEngine;
using UnityEngine.Events;

namespace anticheat
{
    public class SpeedHackDetector : ActDetectorBase
    {
        //private const string COMPONENT_NAME = "Speed Hack Detector";
        public int coolDown = 30;
        private int currentCooldownShots;
        private byte currentFalsePositives;
        private static SpeedHackDetector instance;
        public float interval = 1f;
        internal static bool isRunning;
        public byte maxFalsePositives = 3;
        private long prevIntervalTicks;
        private long prevTicks;
        private const int THRESHOLD = 0x4c4b40;
        private const long TICKS_PER_SECOND = 0x989680L;
        private long ticksOnStart;
        private long vulnerableTicksOnStart;

        private SpeedHackDetector()
        {
        }

        public override void Awake()
        {
            if (this.Init(instance, "Speed Hack Detector"))
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

        private void OnApplicationPause(bool pause)
        {
            if (!pause)
            {
                this.ResetStartTicks();
            }
        }

        private void ResetStartTicks()
        {
            this.ticksOnStart = DateTime.Now.Ticks;
            this.vulnerableTicksOnStart = Environment.TickCount * 0x2710L;
            this.prevTicks = this.ticksOnStart;
            this.prevIntervalTicks = this.ticksOnStart;
        }

        public static void StartDetection(UnityAction callback)
        {
            StartDetection(callback, Instance.interval);
        }

        public static void StartDetection(UnityAction callback, float checkInterval)
        {
            StartDetection(callback, checkInterval, Instance.maxFalsePositives);
        }

        public static void StartDetection(UnityAction callback, float checkInterval, byte falsePositives)
        {
            StartDetection(callback, checkInterval, falsePositives, Instance.coolDown);
        }

        public static void StartDetection(UnityAction callback, float checkInterval, byte falsePositives, int shotsTillCooldown)
        {
            Instance.StartDetectionInternal(callback, checkInterval, falsePositives, shotsTillCooldown);
        }

        private void StartDetectionInternal(UnityAction callback, float checkInterval, byte falsePositives, int shotsTillCooldown)
        {
            if (isRunning)
            {
                ClientLog.LogWarning("[ACT] Speed Hack Detector already running!");
            }
            else
            {
                base.onDetection = callback;
                this.interval = checkInterval;
                this.maxFalsePositives = falsePositives;
                this.coolDown = shotsTillCooldown;
                this.ResetStartTicks();
                this.currentFalsePositives = 0;
                this.currentCooldownShots = 0;
                isRunning = true;
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
                base.onDetection = null;
                isRunning = false;
            }
        }

        public override void Update()
        {
            if (isRunning)
            {
                long num = 0L;
                num = DateTime.Now.Ticks;
                long num2 = num - this.prevTicks;
                if ((num2 < 0L) || (num2 > 0x989680L))
                {
                    if (Debug.isDebugBuild)
                    {
                        ClientLog.LogWarning("[ACT] SpeedHackDetector: System DateTime change or > 1 second game freeze detected!");
                    }
                    this.ResetStartTicks();
                }
                else
                {
                    this.prevTicks = num;
                    long num3 = (long)(this.interval * 1E+07f);
                    if ((num - this.prevIntervalTicks) >= num3)
                    {
                        long num4 = 0L;
                        num4 = Environment.TickCount * 0x2710L;
                        if (Mathf.Abs((float) ((num4 - this.vulnerableTicksOnStart) - (num - this.ticksOnStart))) > 5000000f)
                        {
                            this.currentFalsePositives++;
                            if (this.currentFalsePositives > this.maxFalsePositives)
                            {
                                if (Debug.isDebugBuild)
                                {
                                    ClientLog.LogWarning("[ACT] SpeedHackDetector: final detection!");
                                }
                                ClientLog.LogError("#SpeedHackDetector#Update#onDetection");
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
                                //    StopDetection();
                                //}
                            }
                            else
                            {
                                if (Debug.isDebugBuild)
                                {
                                    ClientLog.LogWarning("[ACT] SpeedHackDetector: detection! Allowed false positives left: " + (this.maxFalsePositives - this.currentFalsePositives));
                                }
                                this.currentCooldownShots = 0;
                                this.ResetStartTicks();
                            }
                        }
                        else if ((this.currentFalsePositives > 0) && (this.coolDown > 0))
                        {
                            if (Debug.isDebugBuild)
                            {
                                ClientLog.LogWarning("[ACT] SpeedHackDetector: success shot! Shots till Cooldown: " + (this.coolDown - this.currentCooldownShots));
                            }
                            this.currentCooldownShots++;
                            if (this.currentCooldownShots >= this.coolDown)
                            {
                                if (Debug.isDebugBuild)
                                {
                                    ClientLog.LogWarning("[ACT] SpeedHackDetector: Cooldown!");
                                }
                                this.currentFalsePositives = 0;
                            }
                        }
                        this.prevIntervalTicks = num;
                    }
                }
            }
        }

        public static SpeedHackDetector Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                instance = new SpeedHackDetector();
                return instance;
                //SpeedHackDetector detector = UnityEngine.Object.FindObjectOfType(typeof(SpeedHackDetector)) as SpeedHackDetector;
                //if (detector == null)
                //{
                //    detector = new GameObject("Speed Hack Detector").AddComponent<SpeedHackDetector>();
                //}
                //return detector;
            }
        }
    }
}

