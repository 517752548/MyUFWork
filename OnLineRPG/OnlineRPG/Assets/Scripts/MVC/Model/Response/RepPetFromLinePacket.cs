using System;
using System.Collections.Generic;
using BetaFramework;
using UnityEngine;

public class RepPetFromLinePacket : SerializablePacket
{
    public int code;
    public RepPetFromLineData data;
    
}

public class RepPetFromLineData
{
    public Dictionary<string, int> PetSystem;
    public string CurrentUseId;
}

public class PetInfo
{
    public int pieces;
    public string theme;
}