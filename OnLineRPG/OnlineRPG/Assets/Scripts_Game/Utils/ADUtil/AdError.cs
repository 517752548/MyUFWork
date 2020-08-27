using UnityEngine;
using System.Collections;

public class AdError
{
    private string description;
    private int code;

    public int getErrorCode()
    {
        return code;
    }

    public string getDescription()
    {
        return description;
    }
    
    public AdError(int errorCode, string errorDescription)
    {
        code = errorCode;
        description = errorDescription;
    }

    public override string ToString()
    {
        return code + " : " + description;
    }
}
