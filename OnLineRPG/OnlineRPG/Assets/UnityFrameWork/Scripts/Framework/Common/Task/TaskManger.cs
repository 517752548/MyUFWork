using UnityEngine;
using System.Collections;

namespace BetaFramework
{
    public class TaskManger : IModule
    {
        public void AddTaskToQueue(Task task, string queueName)
        {

        }

        public override void Execute(float deltaTime)
        {
            base.Execute(deltaTime);
        }

        public override void Init()
        {
            base.Init();
        }

        public override void Pause(bool pause)
        {
            base.Pause(pause);
        }

        public override void Shut()
        {
            base.Shut();
        }
    } 
}
