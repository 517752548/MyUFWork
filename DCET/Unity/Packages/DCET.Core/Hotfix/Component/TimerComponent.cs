using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DCET
{
	public interface ITimer
	{
		void Run();
	}
    
    [ObjectSystem]
	public class OnceWaitTimerAwakeSystem : AwakeSystem<OnceWaitTimer, TaskCompletionSource<bool>>
	{
		public override void Awake(OnceWaitTimer self, TaskCompletionSource<bool> callback)
		{
			self.Callback = callback;
		}
	}
	
	public class OnceWaitTimer: Entity, ITimer
	{
		public TaskCompletionSource<bool> Callback { get; set; }
		
		public void Run()
		{
			var tcs = Callback;
			GetParent<TimerComponent>().Remove(Id);
			tcs.SetResult(true);
		}
	}
	
	[ObjectSystem]
	public class OnceTimerAwakeSystem : AwakeSystem<OnceTimer, Action>
	{
		public override void Awake(OnceTimer self, Action callback)
		{
			self.Callback = callback;
		}
	}
	
	public class OnceTimer: Entity, ITimer
	{
		public Action Callback { get; set; }
		
		public void Run()
		{
			try
			{
				Callback.Invoke();
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}
	}
	
	[ObjectSystem]
	public class RepeatedTimerAwakeSystem : AwakeSystem<RepeatedTimer, long, Action>
	{
		public override void Awake(RepeatedTimer self, long repeatedTime, Action callback)
		{
			self.Awake(repeatedTime, callback);
		}
	}
	
	public class RepeatedTimer: Entity, ITimer
	{
		public void Awake(long repeatedTime, Action callback)
		{
			StartTime = TimeHelper.CurrentLocalMilliseconds();
			RepeatedTime = repeatedTime;
			Callback = callback;
			Count = 1;
		}
		
		private long StartTime { get; set; }
		
		private long RepeatedTime { get; set; }

		// 下次一是第几次触发
		private int Count { get; set; }
		
		public Action Callback { private get; set; }
		
		public void Run()
		{
			++Count;
			TimerComponent timerComponent = GetParent<TimerComponent>();
			long tillTime = StartTime + RepeatedTime * Count;
			timerComponent.AddToTimeId(tillTime, Id);

			try
			{
				Callback.Invoke();
			}
			catch (Exception e)
			{
				Log.Exception(e);
			}
		}

		public override void Dispose()
		{
			if (IsDisposed)
			{
				return;
			}
			
			long id = Id;

			if (id == 0)
			{
				Log.Error($"RepeatedTimer可能多次释放了");
				return;
			}
			
			base.Dispose();

			StartTime = 0;
			RepeatedTime = 0;
			Callback = null;
			Count = 0;
		}
	}
	
	[ObjectSystem]
	public class TimerComponentAwakeSystem : AwakeSystem<TimerComponent>
	{
		public override void Awake(TimerComponent self)
		{
			TimerComponent.Instance = self;
		}
	}

	[ObjectSystem]
	public class TimerComponentUpdateSystem : UpdateSystem<TimerComponent>
	{
		public override void Update(TimerComponent self)
		{
			self.Update();
		}
	}

	public class TimerComponent : Entity
	{
		public static TimerComponent Instance { get; set; }
		
		private readonly Dictionary<long, ITimer> timers = new Dictionary<long, ITimer>();

		/// <summary>
		/// key: time, value: timer id
		/// </summary>
		public readonly MultiMap<long, long> TimeId = new MultiMap<long, long>();

		private readonly Queue<long> timeOutTime = new Queue<long>();
		
		private readonly Queue<long> timeOutTimerIds = new Queue<long>();

		// 记录最小时间，不用每次都去MultiMap取第一个值
		private long minTime;

		public void Update()
		{
			if (TimeId.Count == 0)
			{
				return;
			}

			long timeNow = TimeHelper.CurrentLocalMilliseconds();

			if (timeNow < minTime)
			{
				return;
			}
			
			foreach (KeyValuePair<long, List<long>> kv in TimeId.GetDictionary())
			{
				long k = kv.Key;
				if (k > timeNow)
				{
					minTime = k;
					break;
				}
				timeOutTime.Enqueue(k);
			}

			while(timeOutTime.Count > 0)
			{
				long time = timeOutTime.Dequeue();
				foreach(long timerId in TimeId[time])
				{
					timeOutTimerIds.Enqueue(timerId);	
				}
				TimeId.Remove(time);
			}

			while(timeOutTimerIds.Count > 0)
			{
				long timerId = timeOutTimerIds.Dequeue();
				ITimer timer;
				if (!timers.TryGetValue(timerId, out timer))
				{
					continue;
				}
				
				timer.Run();
			}
		}

		public Task WaitTillAsync(long tillTime, CancellationToken cancellationToken)
		{
			if (TimeHelper.CurrentLocalMilliseconds() > tillTime)
			{
				return Task.CompletedTask;
			}

			var tcs = new TaskCompletionSource<bool>();

			OnceWaitTimer timer = EntityFactory.CreateWithParent<OnceWaitTimer, TaskCompletionSource<bool>>(this, tcs);
			timers[timer.Id] = timer;
			AddToTimeId(tillTime, timer.Id);
			cancellationToken.Register(() => { Remove(timer.Id); });
			return tcs.Task;
		}

		public Task WaitTillAsync(long tillTime)
		{
			if (TimeHelper.CurrentLocalMilliseconds() > tillTime)
			{
				return Task.CompletedTask;
			}
			var tcs = new TaskCompletionSource<bool>();
			OnceWaitTimer timer = EntityFactory.CreateWithParent<OnceWaitTimer, TaskCompletionSource<bool>>(this, tcs);
			timers[timer.Id] = timer;
			AddToTimeId(tillTime, timer.Id);
			return tcs.Task;
		}

		public Task WaitAsync(long time, CancellationToken cancellationToken)
		{
			long tillTime = TimeHelper.CurrentLocalMilliseconds() + time;

            if (TimeHelper.CurrentLocalMilliseconds() > tillTime)
            {
                return Task.CompletedTask;
            }

            var tcs = new TaskCompletionSource<bool>();
			OnceWaitTimer timer = EntityFactory.CreateWithParent<OnceWaitTimer, TaskCompletionSource<bool>>(this, tcs);
			timers[timer.Id] = timer;
			AddToTimeId(tillTime, timer.Id);
			cancellationToken.Register(() => { Remove(timer.Id); });
			return tcs.Task;
		}

		public Task WaitAsync(long time)
		{
			long tillTime = TimeHelper.CurrentLocalMilliseconds() + time;
			var tcs = new TaskCompletionSource<bool>();
			OnceWaitTimer timer = EntityFactory.CreateWithParent<OnceWaitTimer, TaskCompletionSource<bool>>(this, tcs);
			timers[timer.Id] = timer;
			AddToTimeId(tillTime, timer.Id);
			return tcs.Task;
		}

		/// <summary>
		/// 创建一个RepeatedTimer
		/// </summary>
		/// <param name="time"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public long NewRepeatedTimer(long time, Action action)
		{
			if (time < 30)
			{
				throw new Exception($"repeated time < 30");
			}
			long tillTime = TimeHelper.CurrentLocalMilliseconds() + time;
			RepeatedTimer timer = EntityFactory.CreateWithParent<RepeatedTimer, long, Action>(this, time, action);
			timers[timer.Id] = timer;
			AddToTimeId(tillTime, timer.Id);
			return timer.Id;
		}
		
		public RepeatedTimer GetRepeatedTimer(long id)
		{
			if (!timers.TryGetValue(id, out ITimer timer))
			{
				return null;
			}
			return timer as RepeatedTimer;
		}
		
		public void Remove(long id)
		{
			if (id == 0)
			{
				return;
			}
			ITimer timer;
			if (!timers.TryGetValue(id, out timer))
			{
				return;
			}
			timers.Remove(id);
			
			(timer as IDisposable)?.Dispose();
		}
		
		public long NewOnceTimer(long tillTime, Action action)
		{
			OnceTimer timer = EntityFactory.CreateWithParent<OnceTimer, Action>(this, action);
			timers[timer.Id] = timer;
			AddToTimeId(tillTime, timer.Id);
			return timer.Id;
		}
		
		public OnceTimer GetOnceTimer(long id)
		{
			if (!timers.TryGetValue(id, out ITimer timer))
			{
				return null;
			}
			return timer as OnceTimer;
		}

		public void AddToTimeId(long tillTime, long id)
		{
			TimeId.Add(tillTime, id);
			if (tillTime < minTime)
			{
				minTime = tillTime;
			}
		}
	}
}