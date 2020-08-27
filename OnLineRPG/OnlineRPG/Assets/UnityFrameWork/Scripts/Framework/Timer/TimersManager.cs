using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting;

namespace BetaFramework
{
    [Preserve]
    [DisallowMultipleComponent]
    public class TimersManager : IModule
    {
        private static List<Timer> m_Timers;
        private static bool m_bPaused = false;

        public TimersManager()
        {
            m_Timers = new List<Timer>();
        }

        private static void FindAndRemove(UnityAction UnityAction)
        {
            if (m_Timers == null)
                return;

            foreach (Timer elem in m_Timers)
            {
                if (elem == null)
                {
                    m_Timers.Remove(elem);
                    break;
                }

                if (elem.Delegate() == UnityAction)
                {
                    m_Timers.Remove(elem);
                    break;
                }
            }
        }

        public static void SetTimer(Timer timer)
        {
            if (timer.Delegate() != null && timer.Interval() > 0f && timer.LoopsCount() > 0)
            {
                ClearTimer(timer.Delegate());
                m_Timers.Add(timer);
            }
        }

        public static void SetTimer(float interval, uint LoopsCount, UnityAction unityAction)
        {
            LoopsCount = Math.Max(LoopsCount, 1);
            if (unityAction != null && interval > 0f && LoopsCount > 0)
            {
                ClearTimer(unityAction);
                m_Timers.Add(new Timer(interval, LoopsCount, unityAction));
            }
        }

        public static void SetTimer(float interval, UnityAction unityAction)
        {
            if (unityAction != null && interval > 0f)
            {
                ClearTimer(unityAction);
                m_Timers.Add(new Timer(interval, 1, unityAction));
            }
            else if (unityAction != null && interval == 0f)
            {
                unityAction.Invoke();
            }
        }

        public static void SetLoopableTimer(float interval, UnityAction unityAction)
        {
            if (unityAction != null && interval > 0f)
            {
                ClearTimer(unityAction);
                m_Timers.Add(new Timer(interval, Timer.INFINITE, unityAction));
            }
        }

        public static void AddTimers(List<Timer> Timers)
        {
            foreach (Timer timer in Timers)
            {
                if (timer.Interval() > 0f && timer.LoopsCount() > 0)
                {
                    timer.UpdateActionFromEvent();
                    m_Timers.Add(timer);
                }
            }
        }

        /// <summary>
        /// Remove a certain timer
        /// </summary>
        /// <param name="UnityAction">Delegate name</param>
        public static void ClearTimer(UnityAction UnityAction)
        {
            if (UnityAction != null)
                FindAndRemove(UnityAction);
        }

        /// <summary>
        /// Get timer by name (which is the delegate's name)
        /// </summary>
        /// <param name="UnityAction">Delegate name</param>
        public static Timer GetTimerByName(UnityAction UnityAction)
        {
            foreach (Timer elem in m_Timers)
                if (elem.Delegate() == UnityAction)
                    return elem;

            return null;
        }

        public float Interval(UnityAction unityAction)
        {
            Timer timer = GetTimerByName(unityAction);
            return timer == null ? 0f : timer.Interval();
        }

        public uint LoopsCount(UnityAction unityAction)
        {
            Timer timer = GetTimerByName(unityAction);
            return timer == null ? 0 : timer.LoopsCount();
        }

        public uint CurrentLoopsCount(UnityAction unityAction)
        {
            Timer timer = GetTimerByName(unityAction);
            return timer == null ? 0 : timer.CurrentLoopsCount();
        }

        public uint RemainingLoopsCount(UnityAction unityAction)
        {
            Timer timer = GetTimerByName(unityAction);
            return timer == null ? 0 : timer.RemainingLoopsCount();
        }

        public float RemainingTime(UnityAction unityAction)
        {
            Timer timer = GetTimerByName(unityAction);
            return timer == null ? -1f : timer.RemainingTime();
        }

        public float ElapsedTime(UnityAction unityAction)
        {
            Timer timer = GetTimerByName(unityAction);
            return timer == null ? -1f : timer.ElapsedTime();
        }

        public float CurrentCycleElapsedTime(UnityAction unityAction)
        {
            Timer timer = GetTimerByName(unityAction);
            return timer == null ? -1f : timer.CurrentCycleElapsedTime();
        }

        public float CurrentCycleRemainingTime(UnityAction unityAction)
        {
            Timer timer = GetTimerByName(unityAction);
            return timer == null ? -1f : timer.CurrentCycleRemainingTime();
        }

        public bool IsTimerActive(UnityAction unityAction)
        {
            Timer timer = GetTimerByName(unityAction);
            return timer != null;
        }

        public bool IsTimerPaused(UnityAction unityAction)
        {
            Timer timer = GetTimerByName(unityAction);
            return timer == null ? false : timer.IsPaused();
        }

        public void SetPaused(UnityAction unityAction, bool bPause)
        {
            Timer timer = GetTimerByName(unityAction);
            if (timer != null) timer.SetPaused(bPause);
        }

        /// <summary>
        /// Get total duration, (INFINITE if it's constantly looping)
        /// </summary>
        /// <param name="unityAction">Delegate name</param>
        public float Duration(UnityAction unityAction)
        {
            Timer timer = GetTimerByName(unityAction);
            return timer == null ? 0f : timer.Duration();
        }

        public override void Execute(float deltaTime)
        {
            if (m_bPaused)
                return;

            for (int i = 0; i < m_Timers.Count; i++)
            {
                Timer timer = m_Timers[i];
                if (timer == null || timer.ShouldClear())
                {
                    if (m_Timers != null)
                        m_Timers.RemoveAt(i);
                }
                else
                {
                    timer.UpdateTimer();
                }
            }
        }

        public override void Shut()
        {
            m_Timers = null;
            m_bPaused = false;
        }

        public override void Pause(bool pause)
        {
            m_bPaused = pause;
        }
    }
}