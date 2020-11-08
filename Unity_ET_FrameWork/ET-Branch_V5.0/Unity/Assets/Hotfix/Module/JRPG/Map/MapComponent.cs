using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETHotfix
{
    public class MapAwakeComponent: AwakeSystem<MapComponent, GameObject>
    {
        public override void Awake(MapComponent self, GameObject a)
        {
            self.Awake(a);
        }
    }
    public class MapComponent : Entity
    {
        public void Awake(GameObject map)
        {
            this.GameObject = map;
        }
        
    }
}

