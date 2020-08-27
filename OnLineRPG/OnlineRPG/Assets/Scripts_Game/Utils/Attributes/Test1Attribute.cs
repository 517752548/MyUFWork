using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1Attribute : Attribute
{
    public Test1Attribute()
    {
        Debug.LogError("TestAttributes Create");
    }
}
