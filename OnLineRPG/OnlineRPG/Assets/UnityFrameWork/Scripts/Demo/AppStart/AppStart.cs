using BetaFramework;
using UnityEngine;

public class AppStart : AppEntry
{
    protected override void Awake()
    {
        base.Awake();


        Application.lowMemory += OnLowMemory;
    }

    private void OnLowMemory()
    {
    }

    private void OnLogError(string condition, string stackTrace, LogType type)
    {
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        Application.lowMemory -= OnLowMemory;
    }
}