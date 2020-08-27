using System;
using System.Collections;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting;

[Preserve]
public class SystemManager : IModule
{
    private Dictionary<string,ISystem> m_systems = new Dictionary<string, ISystem>();
    private CommQueueStateMachine _stateMachine = new CommQueueStateMachine();

    public SystemManager()
    {
        _stateMachine.InitStateMachine();
    }

    /// <summary>
    /// 安装系统
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void InstallSystem<T>() where T : ISystem
    {
        if (!m_systems.ContainsKey(typeof(T).FullName))
        {
            T system = Activator.CreateInstance<T>();
            m_systems.Add(typeof(T).FullName, system);
            system.Init(_stateMachine);
            _stateMachine.AddQueueState(system);
        }
    }

    /// <summary>
    /// 获取相关系统
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetSystem<T>() where T : ISystem
    {
        if (m_systems.ContainsKey(typeof(T).FullName))
        {
            return m_systems[typeof(T).FullName] as T;
        }

        return null;
    }


    public override void Init()
    {
        _stateMachine.StartRun();
        
    }

    public void Complete(Action completeCallback)
    {
        _stateMachine.OnLastStateCompleted(completeCallback); 
    }

    public override void Execute(float deltaTime)
    {
        foreach (ISystem system in m_systems.Values)
        {
            if (system != null)
            {
                system.Execute(deltaTime);
            }
        }
    }

    public override void Shut()
    {
        foreach (ISystem system in m_systems.Values)
        {
            if (system != null)
            {
                system.Shut();
            }
        }
    }

    public override void Pause(bool pause)
    {
        foreach (ISystem system in m_systems.Values)
        {
            if (system != null)
            {
                system.Pause(pause);
            }
        }
    }

    public override void OnEnterUI(GameUI UiToSwitch)
    {
        foreach (ISystem system in m_systems.Values)
        {
            if (system != null)
            {
                system.OnEnterUI(UiToSwitch);
            }
        }
    }
}
