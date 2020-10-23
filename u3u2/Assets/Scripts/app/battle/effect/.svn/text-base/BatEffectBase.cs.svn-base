using UnityEngine;
using app.effect;
using app.model;

namespace app.battle
{
    public class BatEffectBase : EffectBase
    {
        public Vector3 orgPos = Vector3.zero;
        public Vector3 orgAngle = Vector3.zero;

        public override void SetDisplayModel(string effectPath)
        {
            base.SetDisplayModel(effectPath);
            SetLayer(SceneModel.ins.battleModelContainer.layer);
        }
    }
}