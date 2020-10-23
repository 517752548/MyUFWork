using app.story;

namespace app.state
{
	public class StoryState : StateBase
	{
		public StoryState()
		{
			this.state = StateDef.storyState;
		}

		public override bool canEnter()
		{
			return true;
		}

		public override bool canLeave()
		{
			return true;
		}

		public override void onEnter()
		{
			base.onEnter();
            StoryManager.ins.OnEnter();
		}

		public override void onLeave(StateDef nextState)
		{
			base.onLeave(nextState);
            StoryManager.ins.OnLeave();
		}

		public override void onUpdate()
		{
			base.onUpdate();
            StoryManager.ins.Update();
		}

		public override void onFixedUpdate()
		{
			base.onFixedUpdate();
            StoryManager.ins.FixedUpdate();
		}

		public override void onLateUpdate()
		{
			base.onLateUpdate();
			StoryManager.ins.LateUpdate();
		}

		public override void DoUpdate(float deltaTime)
		{
			base.DoUpdate(deltaTime);
		}
	}
}

