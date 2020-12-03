using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace DCET
{
	[ObjectSystem]
	public class MoveComponentUpdateSystem : UpdateSystem<MoveComponent>
	{
		public override void Update(MoveComponent self)
		{
			self.Update();
		}
	}

	public class MoveComponent : Entity
	{
		public Vector3 Target;

		// 开启移动协程的时间
		public long StartTime;

		// 开启移动协程的Unit的位置
		public Vector3 StartPos;

		public long needTime;
		
		public TaskCompletionSource<bool> moveTcs;


		public void Update()
		{
			if (this.moveTcs == null)
			{
				return;
			}
			
			Unit unit = this.GetParent<Unit>();
			long timeNow = TimeHelper.CurrentLocalMilliseconds();

			if (timeNow - this.StartTime >= this.needTime)
			{
				unit.Position = this.Target;
				var tcs = this.moveTcs;
				this.moveTcs = null;
				tcs.SetResult(true);
				return;
			}

			float amount = (timeNow - this.StartTime) * 1f / this.needTime;
			unit.Position = Vector3.Lerp(this.StartPos, this.Target, amount);
		}

		public Task MoveToAsync(Vector3 target, float speedValue, CancellationToken cancellationToken)
		{
			Unit unit = this.GetParent<Unit>();
			
			if ((target - this.Target).magnitude < 0.1f)
			{
				return Task.CompletedTask;
			}
			
			this.Target = target;

			
			this.StartPos = unit.Position;
			this.StartTime = TimeHelper.CurrentLocalMilliseconds();
			float distance = (this.Target - this.StartPos).magnitude;
			if (Math.Abs(distance) < 0.1f)
			{
				return Task.CompletedTask;
			}
            
			this.needTime = (long)(distance / speedValue * 1000);
			
			this.moveTcs = new TaskCompletionSource<bool>();
			
			cancellationToken.Register(() =>
			{
				this.moveTcs = null;
			});
			return this.moveTcs.Task;
		}
	}
}