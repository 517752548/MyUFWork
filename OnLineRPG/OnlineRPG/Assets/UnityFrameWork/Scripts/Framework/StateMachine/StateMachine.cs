using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using BetaFramework;
using BetaFramework.Variable;
// using BetaFramework.Variable;
using DG.Tweening;

namespace BetaFramework
{
    public class StateMachine : MonoBehaviour
    {
        public const string Event_CompleteCurState = "CompleteCurState";

        [SerializeField] private string CurState;
        protected bool autoStart = false;
        protected BaseState currentState;
        protected Dictionary<BaseState, List<BaseState>> stateLink;
        private List<BaseState> headStates;
        private Dictionary<string, BaseState> allStates;
        private Action lastStateCompletedCallback;
        private bool pause = false;
        private Dictionary<string, bool> triggerState;
        private Dictionary<string, IVariable> m_Datas;

        public virtual void InitStateMachine()
        {
            pause = false;
            currentState = null;
            CurState = "";
            lastStateCompletedCallback = null;
            headStates = new List<BaseState>();
            stateLink = new Dictionary<BaseState, List<BaseState>>();
            allStates = new Dictionary<string, BaseState>();
            triggerState = new Dictionary<string, bool>();
            m_Datas = new Dictionary<string, IVariable>();
            OnInit();
            if (autoStart)
                StartRun();
        }

        public bool IsReady()
        {
            return headStates != null && headStates.Count > 0;
        }

        public bool IsPaused => pause;

        public virtual void Release()
        {
            currentState?.Leave();
            currentState = null;
            CurState = "";
            lastStateCompletedCallback = null;
            headStates = null;
            stateLink = null;
            allStates.Clear();
            triggerState.Clear();
            m_Datas.Clear();
        }

        public void StartRun()
        {
            pause = false;
            if (currentState != null)
                currentState.Enter();
            else
            {
                foreach (BaseState state in headStates)
                {
                    if (state.CheckCondition())
                    {
                        currentState = state;
                        CurState = currentState.GetType().FullName;
                        currentState.Enter();
                        break;
                    }
                }
            }
        }

        public void Pause()
        {
            pause = true;
        }

        protected virtual void OnInit()
        {
            //autoStart = true;
            //State state = new State();
            //AddHeadState();
            //LinkState();
        }

        public List<BaseState> AllStates => new List<BaseState>(allStates.Values);

        public T GetState<T>(string tag = "") where T : BaseState
        {
            string key = typeof(T).FullName + "_" + tag;
            if (allStates.ContainsKey(key))
                return (T)allStates[key];
            return null;
        }

        public BaseState GetState(string tag)
        {
            foreach (var state in allStates)
            {
                if (state.Value.Tag.Equals(tag))
                    return state.Value;
            }
            return null;
        }

        public void AddState(BaseState state)
        {
            if (state == null)
                return;
            string key = state.GetType().FullName + "_" + state.Tag;
            if (!allStates.ContainsKey(key))
                allStates.Add(key, state);
            if (headStates.Count == 0)
                headStates.Add(state);
        }

        public void LinkState(BaseState current, BaseState next)
        {
            AddState(current);
            if (stateLink.ContainsKey(current))
            {
                stateLink[current].Add(next);
            }
            else
            {
                var list = new List<BaseState> { next };
                stateLink.Add(current, list);
            }
            AddState(next);
        }

        public void BreakLinkState(BaseState current, BaseState next)
        {
            if (stateLink.ContainsKey(current))
            {
                stateLink[current].Remove(next);
            }
        }

        public void AddHeadState(BaseState headState)
        {
            headStates.Add(headState);
            AddState(headState);
        }

        public T CreateState<T>(string tag = "") where T : BaseState, new()
        {
            return (T)new T().Init(this, tag);
        }

        public bool IsCurrentState(BaseState state)
        {
            return currentState == state;
        }

        protected int ForeachCurNext(Func<BaseState, bool> access)
        {
            if (currentState == null || !stateLink.ContainsKey(currentState))
                return 0;
            var list = stateLink[currentState];
            foreach (BaseState state in list)
            {
                if (access(state))
                {
                    break;
                }
            }
            return list.Count;
        }

        protected bool CurNextContain(BaseState state)
        {
            if (currentState == null)
                return true;
            return stateLink.ContainsKey(currentState) && stateLink[currentState].Contains(state);
        }

        public void SetState(BaseState state, bool forceTo = false)
        {
            if (!forceTo && currentState != null && !currentState.CanExit)
                return;
            ChangeState(state);
        }

        protected void ChangeState(BaseState state)
        {
            if (state == null)
                return;
            currentState?.Leave();
            state.SetLastState(currentState);
            currentState = state;
            CurState = currentState.GetType().FullName;
            if (!pause)
                currentState.Enter();
        }

        public virtual void Next()
        {
            if (currentState == null)
            {
                OnLastStateCompleted();
                return;
            }
            if (!currentState.CanExit)
                return;
            var count = ForeachCurNext(s =>
            {
                if (!s.CheckCondition()) return false;
                ChangeState(s);
                return true;
            });
            if (count == 0)
                OnLastStateCompleted();
        }

        protected virtual void OnLastStateCompleted()
        {
            lastStateCompletedCallback?.Invoke();
        }

        public void OnLastStateCompleted(Action callback)
        {
            lastStateCompletedCallback = callback;
        }

        public virtual void TriggerEvent(string eventName)
        {
            currentState?.HandleEvent(eventName);
            if (eventName != null && eventName.Equals(Event_CompleteCurState))
            {
                currentState?.Complete();
            }
        }

        public void SetTrigger(string trigger)
        {
            if (!string.IsNullOrEmpty(trigger))
                triggerState[trigger] = true;
            Next();
        }

        public bool IsTrigger(string trigger)
        {
            if (!string.IsNullOrEmpty(trigger) && triggerState.ContainsKey(trigger))
                return triggerState[trigger];
            return false;
        }

        public void ResetTrigger(string trigger)
        {
            if (!string.IsNullOrEmpty(trigger))
                triggerState[trigger] = false;
        }

        /// <summary>
        /// 是否存在有限状态机数据。
        /// </summary>
        /// <param name="name">有限状态机数据名称。</param>
        /// <returns>有限状态机数据是否存在。</returns>
        public bool HasData(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            return m_Datas.ContainsKey(name);
        }

        /// <summary>
        /// 获取有限状态机数据。
        /// </summary>
        /// <typeparam name="TData">要获取的有限状态机数据的类型。</typeparam>
        /// <param name="name">有限状态机数据名称。</param>
        /// <returns>要获取的有限状态机数据。</returns>
        public TData GetData<TData>(string name, TData defVar) where TData : IVariable
        {
            var data = (TData)GetData(name);
            if (data == null)
                return defVar;
            return data;
        }

        /// <summary>
        /// 获取有限状态机数据。
        /// </summary>
        /// <param name="name">有限状态机数据名称。</param>
        /// <returns>要获取的有限状态机数据。</returns>
        public IVariable GetData(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            IVariable data = null;
            if (m_Datas.TryGetValue(name, out data))
            {
                return data;
            }

            return null;
        }

        /// <summary>
        /// 设置有限状态机数据。
        /// </summary>
        /// <typeparam name="TData">要设置的有限状态机数据的类型。</typeparam>
        /// <param name="name">有限状态机数据名称。</param>
        /// <param name="data">要设置的有限状态机数据。</param>
        public void SetData<TData>(string name, TData data) where TData : IVariable
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            m_Datas[name] = data;
        }

        /// <summary>
        /// 设置有限状态机数据。
        /// </summary>
        /// <param name="name">有限状态机数据名称。</param>
        /// <param name="data">要设置的有限状态机数据。</param>
        public void SetData(string name, IVariable data)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            m_Datas[name] = data;
        }

        /// <summary>
        /// 移除有限状态机数据。
        /// </summary>
        /// <param name="name">有限状态机数据名称。</param>
        /// <returns>是否移除有限状态机数据成功。</returns>
        public bool RemoveData(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            return m_Datas.Remove(name);
        }
    }

    public class BaseState
    {
        public string Tag { get; private set; }
        protected StateMachine stateMachine;
        public bool IsBusying { get; private set; }
        public bool CanExit { get; protected set; }

        protected BaseState lastState;

        public virtual BaseState Init(StateMachine stateMachine, string tag = "")
        {
            this.stateMachine = stateMachine;
            IsBusying = false;
            Tag = tag;
            return this;
        }

        public virtual void HandleEvent(string eventName)
        {

        }

        public virtual bool CheckCondition()
        {
            return true;
        }

        public virtual void Enter()
        {
            //LoggerHelper.Exception(new NotImplementedException("### Enter state " + this));
            IsBusying = true;
            CanExit = false;
        }

        public virtual void Leave()
        {
            IsBusying = false;
            CanExit = false;
        }

        public virtual void Finish()
        {
            IsBusying = false;
            CanExit = true;
        }

        public virtual void Complete()
        {
            OnCompleted();
        }

        protected virtual void OnCompleted()
        {
            IsBusying = false;
            CanExit = true;
            if (stateMachine.IsCurrentState(this))
                stateMachine.Next();
            // if (stateMachine.IsCurrentState(this))
            // {
            //     DOTween.Sequence().InsertCallback(0.2f, OnCompleted);
            // }
        }

        protected void RunOnMainThread(Action task)
        {
            Loom.QueueOnMainThread(task);
            //new System.Threading.Thread((runBody)=> {
            //    ((Action)runBody).Invoke();
            //}).Start(task);
        }

        protected void RunOnThread(Action task)
        {
            Loom.RunAsync(task);
            //new System.Threading.Thread((runBody)=> {
            //    ((Action)runBody).Invoke();
            //}).Start(task);
        }

        protected Coroutine StartCoroutine(IEnumerator task)
        {
            return ReferenceEquals(stateMachine.gameObject, null) ?
                AppThreadController.instance.StartCoroutine(task) : stateMachine.StartCoroutine(task);
        }

        protected void StopCoroutine(IEnumerator task)
        {
            if (ReferenceEquals(stateMachine.gameObject, null))
            {
                AppThreadController.instance.StopCoroutine(task);
            }
            else
                stateMachine.StopCoroutine(task);
        }

        protected void StopCoroutine(Coroutine routine)
        {
            if (ReferenceEquals(stateMachine.gameObject, null))
            {
                AppThreadController.instance.StopCoroutine(routine);
            }
            else
                stateMachine.StopCoroutine(routine);
        }

        protected void RunOnCoroutine(Action task)
        {
            StartCoroutine(RunActionCoroutine(task));
        }

        private IEnumerator RunActionCoroutine(Action task)
        {
            task?.Invoke();
            yield break;
        }

        public void SetLastState(BaseState lastState)
        {
            this.lastState = lastState;
        }
    }

    public class CommQueueStateMachine : StateMachine
    {
        private bool isInited = false;
        private BaseState lastQueueState = null;

        public void AddQueueState(BaseState state)
        {
            if (!isInited)
                InitStateMachine();
            if (lastQueueState == null)
                AddHeadState(state);
            else
                LinkState(lastQueueState, state);
            lastQueueState = state;
        }

        protected override void OnInit()
        {
            autoStart = false;
            base.OnInit();
            isInited = true;
        }
    }

    public class CommTaskState : BaseState
    {
        enum TaskType { mainThread, thread, coroutine }

        TaskType taskType;
        private Action body;
        IEnumerator enumerator_body;

        public CommTaskState(StateMachine stateMachine, Action body, bool thread = false)
        {
            this.body = body;
            taskType = thread ? TaskType.thread : TaskType.mainThread;
            Init(stateMachine);
        }

        public CommTaskState(StateMachine stateMachine, IEnumerator body)
        {
            enumerator_body = body;
            taskType = TaskType.coroutine;
            Init(stateMachine);
        }

        public override void Enter()
        {
            base.Enter();
            switch (taskType)
            {
                case TaskType.mainThread:
                    body?.Invoke();
                    OnCompleted();
                    break;
                case TaskType.thread:
                    RunOnThread(TaskThread);
                    break;
                case TaskType.coroutine:
                    StartCoroutine(TaskCoroutine());
                    break;
            }
        }

        private IEnumerator TaskCoroutine()
        {
            yield return enumerator_body;
            OnCompleted();
            yield break;
        }

        private void TaskThread()
        {
            body?.Invoke();
            RunOnMainThread(OnCompleted);
        }
    }
}
