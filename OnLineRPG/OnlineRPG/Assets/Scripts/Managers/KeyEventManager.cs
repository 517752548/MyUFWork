using BetaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public class KeyEventManager : IModule
{
    public static KeyEventManager Instance { get; private set; }

    private Dictionary<Priority, List<Func<bool>>> backListenerDic = new Dictionary<Priority, List<Func<bool>>>();
    
    public override void Init()
    {
        Instance = this;
    }
    
    public override void Execute(float deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onBackPressed();
        }
    }

    public override void Shut()
    {

    }

    public override void Pause(bool pause)
    {

    }
    
    private void onBackPressed()
    {
        List<Func<bool>> listeners = null;
        int max = (int)Priority.hppp;
        for (int p = max; p >= 0; p--)
        {
            Priority priority = (Priority)p;
            if (backListenerDic.ContainsKey(priority))
            {
                listeners = backListenerDic[priority];
                foreach (Func<bool> onBack in listeners)
                {
                    if (onBack())
                        return;
                }
            }
        }
    }

    public void AddBackPressListener(Priority priority, Func<bool> onBackListener)
    {
        if (backListenerDic.ContainsKey(priority))
        {
            backListenerDic[priority].Insert(0, onBackListener);
        }
        else
        {
            List<Func<bool>> listeners = new List<Func<bool>>();
            listeners.Add(onBackListener);
            backListenerDic.Add(priority, listeners);
        }
    }

    public void RemoveBackPressListener(Priority priority, Func<bool> onBackListener)
    {
        if (backListenerDic.ContainsKey(priority))
        {
            backListenerDic[priority].Remove(onBackListener);
        }
    }

    public enum Priority
    {
        lower,
        low,
        normal,
        high,
        higher,
        hpp,
        hppp
    }
}