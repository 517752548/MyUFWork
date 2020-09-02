using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using Newtonsoft.Json;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#else
using Unity.Notifications.iOS;
#endif
using UnityEngine;

public class NotificationSystem : ISystem
{
#if UNITY_IOS
        List<string> pushIdList = new List<string>();
#elif UNITY_ANDROID
    List<int> pushIdList = new List<int>();
    public const string AndroidChannel = "WordCrazeChannel";

#endif


    public override void InitSystem()
    {
#if UNITY_EDITOR
        base.InitSystem();
        return;
#endif
#if UNITY_IOS
        pushIdList = JsonConvert.DeserializeObject<List<string>>(Record.GetString("PlayerPushNotification"));
        if (pushIdList == null)
        {
            pushIdList = new List<string>();
        }
#elif UNITY_ANDROID
        pushIdList = JsonConvert.DeserializeObject<List<int>>(Record.GetString("PlayerPushNotification"));
        if (pushIdList == null)
        {
            pushIdList = new List<int>();
        }

        var c = new AndroidNotificationChannel()
        {
            Id = AndroidChannel,
            Name = "WordCrazeChannel",
            Importance = Importance.High,
            Description = "WordCraze",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
#endif
        SendNotification();
        base.InitSystem();
        CheckPlayerClickNotifi();
    }


    public void CheckPlayerClickNotifi()
    {
#if  UNITY_ANDROID
        var notificationIntentData = AndroidNotificationCenter.GetLastNotificationIntent();
        if (notificationIntentData != null)
        {
            var id = notificationIntentData.Id;
            var channel = notificationIntentData.Channel;
            var notification = notificationIntentData.Notification;
            GameAnalyze.LogPlayerClickNotification(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(),notificationIntentData.Channel);
        }
        
#elif UNITY_IOS
        var n = iOSNotificationCenter.GetLastRespondedNotification();
        if (n != null)
        {
            var msg = "Last Received Notification : " + n.Identifier + "\n";
            msg += "\n - Notification received: ";
            msg += "\n - .Title: " + n.Title;
            msg += "\n - .Badge: " + n.Badge;
            msg += "\n - .Body: " + n.Body;
            msg += "\n - .CategoryIdentifier: " + n.CategoryIdentifier;
            msg += "\n - .Subtitle: " + n.Subtitle;
            msg += "\n - .Data: " + n.Data;
            Debug.Log(msg);
            GameAnalyze.LogPlayerClickNotification(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(),n.Identifier);
        }
        else
        {
            Debug.Log("No notifications received.");
        }
        
        #endif



    }

    public void NotifiFastrace()
    {
        
    }
    public void SendNotification()
    {
        CancelAll();
        if (!AppEngine.SGameSettingManager.Notification.Value)
        {
            GameAnalyze.LogNotificationState(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(),"0");
            return;
        }
        GameAnalyze.LogNotificationState(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(),"1");
        bool finishFlash1 = AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>()
            .IsDateNodeLevelCompleted(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0));
        bool finishFlash2 = AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>()
            .IsDateNodeLevelCompleted(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0));
#if !UNITY_ANDROID
        SendFlashs(finishFlash1, finishFlash2);
#endif
        SendDaily(finishFlash2);
        SendDailySign();
    }

    private void SendFlashs(bool finishFlash1, bool finishFlash2)
    {
        if (finishFlash1)
        {
            SendFlash(1, 7);
        }
        else
        {
            SendFlash(0, 7);
        }

        if (finishFlash2)
        {
            //推送明天开始的 每天6点的flash1
            SendFlash(1, 18);
        }
        else
        {
            //推送今天开始的每天6点的推送
            SendFlash(0, 18);
        }
        GameAnalyze.LogSendNotification(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(),"Flash");
    }

    private void SendDaily(bool finishFlash2)
    {
        if (finishFlash2)
        {
            //不推送了
        }
        else
        {
            bool unlocked = true;
            bool todayFinished = AppEngine.SyncManager.Data.ToadyFinished.Value;
            if (unlocked && todayFinished)
            {
                //  推送今天的每日挑战
                var ids = new DailyNotification().SendNotification();
                AddPushId(ids);
                GameAnalyze.LogSendNotification(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(),"Daily");
            }
        }
    }

    private void SendFlash(int index, int hour)
    {
        //推送今天开始的每天7点的推送
        DateTime tomorrow = DateTime.Now.AddDays(index);
        //推送明天开始的 每天7点的flash1
        string word1 = AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>()
            .GetDateNodeLevelQuestion(
                new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, hour, 0, 0));
        if (!string.IsNullOrEmpty(word1))
        {
            var ids = new Flash(tomorrow, word1).SendNotification();
            AddPushId(ids);
        }

        tomorrow = DateTime.Now.AddDays(index + 1);
        string word2 = AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>()
            .GetDateNodeLevelQuestion(
                new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, hour, 0, 0));
        if (!string.IsNullOrEmpty(word2))
        {
            var ids = new Flash(tomorrow, word2).SendNotification();
            AddPushId(ids);
        }

        tomorrow = DateTime.Now.AddDays(index + 2);
        string word3 = AppEngine.SSystemManager.GetSystem<DailyOneWordSystem>()
            .GetDateNodeLevelQuestion(
                new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, hour, 0, 0));
        if (!string.IsNullOrEmpty(word3))
        {
            var ids = new Flash(tomorrow, word3).SendNotification();
            AddPushId(ids);
        }
    }

    private void SendDailySign()
    {
        bool getTodaySign = false;
        if (!getTodaySign)
        {
            //  推送今天的每日挑战
            var ids = new DailySignNotification().SendNotification();
            AddPushId(ids);
            GameAnalyze.LogSendNotification(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(),"Daily");
        }
    }

    /// <summary>
    /// 推送当天的答案，玩家每次进入关卡的时候推送
    /// </summary>
    public void SendAnswerTips(string word)
    {
#if UNITY_IOS
        iOSNotificationCenter.RemoveScheduledNotification("AnswerTipNotification");
        iOSNotificationCenter.RemoveScheduledNotification("AnswerTipNotification2");
#elif UNITY_ANDROID
        int[] androids = JsonConvert.DeserializeObject<int[]>(Record.GetString("AnswerTipNotification"));
        if (androids == null)
            androids = new int[0];
        if (androids.Length > 0)
            for (int i = 0; i < androids.Length; i++)
            {
                AndroidNotificationCenter.CancelNotification(androids[i]);
            }
#endif
        var ids = new AnswerTipNotification(word).SendNotification();
#if UNITY_ANDROID
        Record.SetString("AnswerTipNotification", JsonConvert.SerializeObject(ids));
#endif
        GameAnalyze.LogSendNotification(AppEngine.SSystemManager.GetSystem<ClassicGameSystem>().currentLevel.Value.ToString(),"Answer");
    }

    /// <summary>
    /// 取消所有的推送
    /// </summary>
    private void CancelAll()
    {
#if UNITY_IOS
        for (int i = 0; i < pushIdList.Count; i++)
        {
            iOSNotificationCenter.RemoveScheduledNotification(pushIdList[i]);
        }
#elif UNITY_ANDROID
        try
        {
            for (int i = 0; i < pushIdList.Count; i++)
            {
                AndroidNotificationCenter.CancelNotification(pushIdList[i]);
            }
        }
        catch (Exception e)
        {
        }

#endif

        pushIdList.Clear();
        Record.SetString("PlayerPushNotification", JsonConvert.SerializeObject(pushIdList));
    }


#if UNITY_IOS
        /// <summary>
    /// 每次推送都返回一个id，保存起来  随时可以根据id取消
    /// </summary>
    /// <param name="id"></param>
    private void AddPushId(string[] id)
    {
        for (int i = 0; i < id.Length; i++)
        {
            pushIdList.Add(id[i]);
        }

        Record.SetString("PlayerPushNotification", JsonConvert.SerializeObject(pushIdList));
    }
#elif UNITY_ANDROID
    /// <summary>
    /// 每次推送都返回一个id，保存起来  随时可以根据id取消
    /// </summary>
    /// <param name="id"></param>
    private void AddPushId(int[] id)
    {
        for (int i = 0; i < id.Length; i++)
        {
            pushIdList.Add(id[i]);
        }

        Record.SetString("PlayerPushNotification", JsonConvert.SerializeObject(pushIdList));
    }
#endif
}


public class BaseNotification
{
    public string Tittle;
    public string content;

#if UNITY_IOS
        public virtual string[] SendNotification()
    {
        return null;
    }
#elif UNITY_ANDROID
    public virtual int[] SendNotification()
    {
        return null;
    }
#endif
}

public class Flash : BaseNotification
{
    private DateTime timeNotifi;
    private string question;

    public Flash(DateTime timeNotifi, string question)
    {
        this.timeNotifi = timeNotifi;
        this.question = question;
    }
#if UNITY_IOS
    public override string[] SendNotification()
    {

        DateTime time = timeNotifi;
        var calendarTrigger = new iOSNotificationCalendarTrigger()
        {
            Year = time.Year,
            Month = time.Month,
            Day = time.Day,
            Hour = time.Hour,
            Minute = 0,
            // Second = 0
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            // You can optionally specify a custom identifier which can later be 
            // used to cancel the notification, if you don't set one, a unique 
            // string will be generated automatically.
            Identifier = "flash1",
            Title = "Flash Craze",
            Body = string.Format("{0}", question),
            //Subtitle = "Flash Craze",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "flash1",
            ThreadIdentifier = "thread1",
            Trigger = calendarTrigger,
        };
        //Debug.Log("推送" + calendarTrigger.Month + "月" + calendarTrigger.Day + "天" + calendarTrigger.Hour + "时");
        iOSNotificationCenter.ScheduleNotification(notification);

        return new[] {notification.Identifier};

    }
#endif


#if UNITY_ANDROID
    public override int[] SendNotification()
    {
        var notification = new AndroidNotification();
        notification.Title = "Flash Craze";
        notification.Text = string.Format("{0}", question);
        notification.FireTime = new DateTime(timeNotifi.Year, timeNotifi.Month, timeNotifi.Day, timeNotifi.Hour, 0, 0);

        int ids = AndroidNotificationCenter.SendNotification(notification, NotificationSystem.AndroidChannel);
        return new[] {ids};
    }
#endif
}


public class DailyNotification : BaseNotification
{
    public DailyNotification()
    {
    }

#if UNITY_IOS
    public override string[] SendNotification()
    {
        var calendarTrigger = new iOSNotificationCalendarTrigger()
        {
            // Year = 2018,
            // Month = 8,
            //Day = 30,
            Hour = 18,
            Minute = 0,
            // Second = 0
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            // You can optionally specify a custom identifier which can later be 
            // used to cancel the notification, if you don't set one, a unique 
            // string will be generated automatically.
            Identifier = "DailyNotification",
            Title = "Daily Puzzle💪",
            Body = "Put your knowledge to the test! The Daily Puzzle is here!",
            //Subtitle = "📆Daily Challenge",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "DailyNotification",
            ThreadIdentifier = "thread2",
            Trigger = calendarTrigger,
        };
        Debug.Log("推送" + calendarTrigger.Hour + "时");
        iOSNotificationCenter.ScheduleNotification(notification);
        return new string[] {notification.Identifier};
    }
#endif
#if UNITY_ANDROID
    public override int[] SendNotification()
    {
        var notification = new AndroidNotification();
        notification.Title = "Daily Puzzle💪";
        notification.Text = string.Format("Put your knowledge to the test! The Daily Puzzle is here!");
        notification.FireTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0);
        notification.RepeatInterval = new TimeSpan(24, 0, 0);

        int ids = AndroidNotificationCenter.SendNotification(notification, NotificationSystem.AndroidChannel);
        return new[] {ids};
    }
#endif
}


public class DailySignNotification : BaseNotification
{
    public DailySignNotification()
    {
    }

#if UNITY_IOS
    public override string[] SendNotification()
    {
        var calendarTrigger = new iOSNotificationCalendarTrigger()
        {
            // Year = 2018,
            // Month = 8,
            //Day = 30,
            Hour = 20,
            Minute = 0,
            // Second = 0
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            // You can optionally specify a custom identifier which can later be 
            // used to cancel the notification, if you don't set one, a unique 
            // string will be generated automatically.
            Identifier = "DailySignNotification",
            Title = "Care Package🎁",
            Body = "There's a new delivery for you! Let's go take a look!",
            //Subtitle = "Daily Gift",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "DailySignNotification",
            ThreadIdentifier = "thread3",
            Trigger = calendarTrigger,
        };
        Debug.Log("推送" + calendarTrigger.Hour + "时");
        iOSNotificationCenter.ScheduleNotification(notification);
        return new string[] {notification.Identifier};
    }
#endif
#if UNITY_ANDROID
    public override int[] SendNotification()
    {
        var notification = new AndroidNotification();
        notification.Title = "Care Package🎁";
        notification.Text = string.Format("There's a new delivery for you! Let's go take a look!");
        notification.FireTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
        notification.RepeatInterval = new TimeSpan(24, 0, 0);

        int ids = AndroidNotificationCenter.SendNotification(notification, NotificationSystem.AndroidChannel);
        return new[] {ids};
    }
#endif
}

public class AnswerTipNotification : BaseNotification
{
    private string word;

    public AnswerTipNotification(string word)
    {
        this.word = word;
    }

#if UNITY_IOS
    public override string[] SendNotification()
    {
        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new TimeSpan(24, 0, 0),
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            // You can optionally specify a custom identifier which can later be 
            // used to cancel the notification, if you don't set one, a unique 
            // string will be generated automatically.
            Identifier = "AnswerTipNotification",
            Title = "What a Headscratcher🤔",
            Body = string.Format("Hmmm, what could the answer be? Give {0} a try!", word),
            //Subtitle = "AnswerTip",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "AnswerTipNotification",
            ThreadIdentifier = "thread4",
            Trigger = timeTrigger,
        };
        iOSNotificationCenter.ScheduleNotification(notification);
        var timeTrigger168 = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new TimeSpan(168, 0, 0),

            Repeats = false
        };

        var notification168 = new iOSNotification()
        {
            // You can optionally specify a custom identifier which can later be 
            // used to cancel the notification, if you don't set one, a unique 
            // string will be generated automatically.
            Identifier = "AnswerTipNotification2",
            Title = "What a Headscratcher🤔",
            Body = string.Format("Hmmm, what could the answer be? Give {0} a try!", word),
            //Subtitle = "💡 Here's a clue",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "AnswerTipNotification2",
            ThreadIdentifier = "thread4",
            Trigger = timeTrigger168,
        };

        iOSNotificationCenter.ScheduleNotification(notification);
        return new string[] {notification.Identifier, notification168.Identifier};
    }
#endif
#if UNITY_ANDROID
    public override int[] SendNotification()
    {
        var notification = new AndroidNotification();
        notification.Title = "What a Headscratcher🤔";
        notification.Text = string.Format("Hmmm, what could the answer be? Give {0} a try!", word);
        notification.FireTime = DateTime.Now.AddHours(24);
        notification.RepeatInterval = new TimeSpan(168, 0, 0);

        int ids = AndroidNotificationCenter.SendNotification(notification, NotificationSystem.AndroidChannel);
        return new[] {ids};
    }
#endif
}