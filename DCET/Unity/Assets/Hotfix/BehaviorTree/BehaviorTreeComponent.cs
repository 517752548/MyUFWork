using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DCETRuntime;
using System.Collections.Generic;

namespace DCET
{
	[ObjectSystem]
    public class BehaviorTreeComponentAwakeSystem : AwakeSystem<BehaviorTreeComponent>
    {
        public override void Awake(BehaviorTreeComponent self)
        {
            self.Awake();
        }
    }

    public class BehaviorTreeComponent : Entity
	{
        private Dictionary<HotfixAction, Entity> behaviorTreeActionComponents = new Dictionary<HotfixAction, Entity>();
        private Dictionary<HotfixComposite, Entity> behaviorTreeCompositeComponents = new Dictionary<HotfixComposite, Entity>();
        private Dictionary<HotfixConditional, Entity> behaviorTreeConditionalComponents = new Dictionary<HotfixConditional, Entity>();
        private Dictionary<HotfixDecorator, Entity> behaviorTreeDecoratorComponents = new Dictionary<HotfixDecorator, Entity>();

        public void Awake()
        {
            var behavior = GetParent<BehaviorTree>();

            if (behavior.IsEmptyOrDisposed())
            {
                return;
            }

            var behaviorTree = behavior.Behavior;

            if (!behaviorTree)
            {
                return;
            }

            behaviorTree.StartWhenEnabled = false;
            behaviorTree.ResetValuesOnRestart = false;

            var behaviorTreeController = GameObjectHelper.Ensure(behaviorTree.gameObject, typeof(BehaviorTreeController)) as BehaviorTreeController;

            behaviorTreeController.Init();

            BindHotfixActions(behaviorTreeController, behavior.Parent);
            BindHotfixComposites(behaviorTreeController, behavior.Parent);
            BindHotfixConditionals(behaviorTreeController, behavior.Parent);
            BindHotfixDecorators(behaviorTreeController, behavior.Parent);

            behaviorTree.EnableBehavior();
        }

        private void BindHotfixActions(BehaviorTreeController tasks, Entity parent)
        {
            foreach (var hotfixAction in tasks.hotfixActions)
            {
                var component = BehaviorTreeFactory.Create(parent, hotfixAction);

                if (component != null)
                {
                    behaviorTreeActionComponents.Add(hotfixAction, component);
                }
            }
        }

        private void BindHotfixComposites(BehaviorTreeController tasks, Entity parent)
        {
            foreach (var hotfixComposite in tasks.hotfixComposites)
            {
                var component = BehaviorTreeFactory.Create(parent, hotfixComposite);

                if (component != null)
                {
                    behaviorTreeCompositeComponents.Add(hotfixComposite, component);
                }
            }
        }

        private void BindHotfixConditionals(BehaviorTreeController tasks, Entity parent)
        {
            foreach (var hotfixConditional in tasks.hotfixConditionals)
            {
                var component = BehaviorTreeFactory.Create(parent, hotfixConditional);

                if (component != null)
                {
                    behaviorTreeConditionalComponents.Add(hotfixConditional, component);
                }
            }
        }

        private void BindHotfixDecorators(BehaviorTreeController tasks, Entity parent)
        {
            foreach (var hotfixDecorator in tasks.hotfixDecorators)
            {
                var component = BehaviorTreeFactory.Create(parent, hotfixDecorator);

                if (component != null)
                {
                    behaviorTreeDecoratorComponents.Add(hotfixDecorator, component);
                }
            }
        }

        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            base.Dispose();
            
            foreach (var item in behaviorTreeActionComponents)
            {
                item.Value.Dispose();
            }

            behaviorTreeActionComponents.Clear();

            foreach (var item in behaviorTreeCompositeComponents)
            {
                item.Value.Dispose();
            }

            behaviorTreeCompositeComponents.Clear();

            foreach (var item in behaviorTreeConditionalComponents)
            {
                item.Value.Dispose();
            }

            behaviorTreeConditionalComponents.Clear();

            foreach (var item in behaviorTreeDecoratorComponents)
            {
                item.Value.Dispose();
            }

            behaviorTreeDecoratorComponents.Clear();
        }
    }
}