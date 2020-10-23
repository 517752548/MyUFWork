using System.Text;
using app.zone;
using UnityEngine;
using app.system;

public class ZoneMapEffect : ZoneNPC
{
    public ZoneMapEffect()
    {
    }

    public override void Init(long uuid, string displayModelId, string name, Vector3 pos, Vector3 angle, bool showShadow = true,
        bool isEnableRidePet = true, bool isEnableWing = true, bool isEnableWeapon = true, bool particlesWritable = true)
    {
        SetActive(SystemSettings.ins.isShowParticleEffects);
        base.Init(uuid,displayModelId, name, pos, angle, false, false, false, false, particlesWritable);
    }

    public override AnimationState PlayAnimation(string name, float speed = 1, float corssFadeTime = 0.2f,bool force = false,bool throwError=true)
    {
        return null;
    }

    public override string[] GetDisplayModelPath()
    {
        string[] res = new string[1];
        res[0] = PathUtil.Ins.GetMapEffectPath(displayModelId);
        return res;
    }
}