using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FsmManager
{
    protected FsmState currentState;
    protected Dictionary<string, FsmState> allStates = new Dictionary<string, FsmState>();

    public void TransTo(string statesId)
    {

        if (!allStates.ContainsKey(statesId))
        {
            allStates.Add(statesId, GetTargetBase(statesId));
        }

        if (currentState != allStates[statesId])
        {
            if (currentState != null)
            {
                currentState.Leave();
            }
            currentState = allStates[statesId];
            currentState.Enter(); 
        }
    }

    public void UpdateData()
    {
        if (currentState != null)
            currentState.UpdateData();
    }

    public string CurStateId { get { return currentState != null ? currentState.StateId : "null"; } }

    public abstract FsmState GetTargetBase(string statesId);
}
