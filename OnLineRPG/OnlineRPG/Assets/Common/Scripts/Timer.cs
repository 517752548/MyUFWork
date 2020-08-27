﻿using UnityEngine;
using System.Collections;

public class Timer
{
    private static MonoBehaviour behaviour;
    public delegate void Task();

    public static void Schedule(MonoBehaviour _behaviour, float delay, Task task)
    {
        behaviour = _behaviour;
        if (behaviour == null)
        {
            return;
        }
        behaviour.StartCoroutine(DoTask(task, delay));
    }

    private static IEnumerator DoTask(Task task, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (task == null)
        {
            yield break;
        }
        task();
    }
}
