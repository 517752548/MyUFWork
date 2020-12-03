using DCETRuntime;
using UnityEngine;

namespace DCET
{
    public static class UnitFactory
    {
        public static Unit Create(Entity domain, long id)
        {
	        ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
	        GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset("Unit.unity3d", "Unit");
	        GameObject prefab = GameObjectHelper.GetGameObject(bundleGameObject, "Skeleton");
	        
            UnitComponent unitComponent = Game.Scene.GetComponent<UnitComponent>();
            
	        GameObject go = UnityEngine.Object.Instantiate((UnityEngine.Object)prefab) as GameObject;
	        Unit unit = EntityFactory.CreateWithId<Unit, GameObject>(domain, id, go);
	        
			unit.AddComponent<AnimatorComponent>();
	        unit.AddComponent<MoveComponent>();
	        unit.AddComponent<TurnComponent>();
	        unit.AddComponent<UnitPathComponent>();

            unitComponent.Add(unit);
            return unit;
        }
    }
}