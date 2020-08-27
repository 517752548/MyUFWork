using System;
using BetaFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts_Game.Views
{
    public class TimeDisplay : MonoBehaviour
    {
        public TextMeshProUGUI hour1Text, hour2Text, minute1Text, minute2Text, second1Text, second2Text;
        public Animator hour1Ani, hour2Ani, minute1Ani, minute2Ani, second1Ani, second2Ani;
        
        private TimeData _timeData;

        private void Start()
        {
            hour1Ani.gameObject.AddComponent<AniEvent>().SetAction(() =>
            {
                hour1Text.text = _timeData.h1.ToString();
            });
            hour2Ani.gameObject.AddComponent<AniEvent>().SetAction(() =>
            {
                hour2Text.text = _timeData.h2.ToString();
            });
            minute1Ani.gameObject.AddComponent<AniEvent>().SetAction(() =>
            {
                minute1Text.text = _timeData.m1.ToString();
            });
            minute2Ani.gameObject.AddComponent<AniEvent>().SetAction(() =>
            {
                minute2Text.text = _timeData.m2.ToString();
            });
            second1Ani.gameObject.AddComponent<AniEvent>().SetAction(() =>
            {
                second1Text.text = _timeData.s1.ToString();
            });
            second2Ani.gameObject.AddComponent<AniEvent>().SetAction(() =>
            {
                second2Text.text = _timeData.s2.ToString();
            });
        }

        public void SetTime(int hour, int minute, int second)
        {
            var temp = new TimeData(hour, minute, second);
            
            if (_timeData == null)
            {
                _timeData = temp;
                hour1Text.text = temp.h1.ToString();
                hour2Text.text = temp.h2.ToString();
                minute1Text.text = temp.m1.ToString();
                minute2Text.text = temp.m2.ToString();
                second1Text.text = temp.s1.ToString();
                second2Text.text = temp.s2.ToString();
            }
            else
            {
                if (_timeData.h1 != temp.h1)
                {
                    hour1Ani.SetTrigger("next");
                    //Timer.Schedule(this, 0.2f, () => hour1Text.text = temp.h1.ToString());
                }
                if (_timeData.h2 != temp.h2)
                {
                    hour2Ani.SetTrigger("next");
                    //Timer.Schedule(this, 0.2f, () => hour2Text.text = temp.h2.ToString());
                }
                if (_timeData.m1 != temp.m1)
                {
                    minute1Ani.SetTrigger("next");
                    //Timer.Schedule(this, 0.2f, () => minute1Text.text = temp.m1.ToString());
                }
                if (_timeData.m2 != temp.m2)
                {
                    minute2Ani.SetTrigger("next");
                    //Timer.Schedule(this, 0.2f, () => minute2Text.text = temp.m2.ToString());
                }
                if (_timeData.s1 != temp.s1)
                {
                    second1Ani.SetTrigger("next");
                    //Timer.Schedule(this, 0.2f, () => second1Text.text = temp.s1.ToString());
                }
                if (_timeData.s2 != temp.s2)
                {
                    second2Ani.SetTrigger("next");
                    //Timer.Schedule(this, 0.2f, () => second2Text.text = temp.s2.ToString());
                }
                _timeData.SetTime(temp);
            }
        }

        private class TimeData
        {
            public int h1, h2, m1, m2, s1, s2;

            public TimeData()
            {
            }

            public TimeData(int hour, int minute, int second)
            {
                SetTime(hour, minute, second);
            }

            public void SetTime(int hour, int minute, int second)
            {
                h1 = hour / 10;
                h2 = hour % 10;
                m1 = minute / 10;
                m2 = minute % 10;
                s1 = second / 10;
                s2 = second % 10;
            }

            public void SetTime(TimeData timeData)
            {
                this.h1 = timeData.h1;
                this.h2 = timeData.h2;
                this.m1 = timeData.m1;
                this.m2 = timeData.m2;
                this.s1 = timeData.s1;
                this.s2 = timeData.s2;
            }
        }
    }

    class AniEvent : MonoBehaviour
    {
        private Action onTimeChange;
        public void SetAction(Action onTimeChange)
        {
            this.onTimeChange = onTimeChange;
        }
        
        public void TimeChange()
        {
            onTimeChange?.Invoke();
        }
    }
}