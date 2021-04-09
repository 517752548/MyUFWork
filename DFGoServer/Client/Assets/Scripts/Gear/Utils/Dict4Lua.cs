
using System.Collections.Generic;

public class Dict4Lua 
{
    private Dictionary<string,object> temp = new Dictionary<string, object>();

    public void Add(string name,object obj)
    {
        temp[name] = obj;
    }

    public Dictionary<string, object> Get()
    {
        return temp;
    }
}
