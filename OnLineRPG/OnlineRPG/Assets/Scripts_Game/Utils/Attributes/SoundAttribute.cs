using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAttribute : Attribute
{
    private string soundName;
    public SoundAttribute(string soundName)
    {
        this.soundName = soundName;
    }
}
