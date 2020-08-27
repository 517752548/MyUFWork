using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class PetStatesManager
{
    private SkeletonGraphic targetAni;
    private Dictionary<PetBase.PetStates, PetBase> allStates = new Dictionary<PetBase.PetStates, PetBase>();
    public PetBase currentPetStates;

    public PetStatesManager(SkeletonGraphic targetAni)
    {
        this.targetAni = targetAni;
    }

    public void TransTo(PetBase.PetStates states)
    {
        if (currentPetStates != null)
        {
            currentPetStates.Leave();
        }

        if (!allStates.ContainsKey(states))
        {
            allStates.Add(states, GetTargetBase(states));
        }

        currentPetStates = allStates[states];
        allStates[states].Enter();
    }

    PetBase GetTargetBase(PetBase.PetStates states)
    {
        PetBase basePet = null;
        switch (states)
        {

            case PetBase.PetStates.Idle:
                basePet = new PetIdle();
                break;
            case PetBase.PetStates.hint:
                basePet = new PetSkill1();
                break;
            case PetBase.PetStates.click:
                basePet = new PetClick();
                break;
        }

        basePet.Init(targetAni,this);
        return basePet;
    }

    public void Destroy()
    {
        
    }
}