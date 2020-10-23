using System;
using UnityEngine;
using Object = System.Object;

public class RMetaEvent
{
    private string _type;

    private Object _data;

    private GameObject _gameObject;

    private RMetaEventHandler _handler;

    public RMetaEvent(String type, Object data, GameObject gameObject=null,RMetaEventHandler handler=null)
    {
        _type = type;
        _data = data;
        _gameObject = gameObject;
        _handler = handler;
    }

    public String type
    {
        get
        {
            return _type;
        }
    }

    public object data
    {
        get
        {
            return _data;
        }
    }

    public GameObject GameObject
    {
        get { return _gameObject; }
    }

    public RMetaEventHandler Handler
    {
        get { return _handler; }
    }
}