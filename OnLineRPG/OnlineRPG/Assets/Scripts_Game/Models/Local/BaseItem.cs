using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bag
{
    public class BaseItem
    {
        public int Count;

        public BaseItem()
        {
            
        }
    }

    public class BaseHint : BaseItem
    {
        public bool IsUnlocked;
    }

    public class Hint1 : BaseHint
    {
    
    }

    public class Hint2 : BaseHint
    {
    
    }
    public class Hint3 : BaseHint
    {
    
    }

    public class Hint4 : BaseHint
    {
    
    }
    public class Coin : BaseItem
    {
    
    }
    
}

