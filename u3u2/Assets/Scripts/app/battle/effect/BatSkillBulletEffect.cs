using System.Collections.Generic;
using UnityEngine;

namespace app.battle
{
    /// <summary>
    /// 子弹特效。
    /// </summary>
    public class BatSkillBulletEffect : BatEffectBase
    {
        public List<BatSkillTarget> impactTargets;
        public Vector3 startPos;
        public Vector3 endPos;
        public Vector3 speedV3;
        public float speed;
        public Vector3 curPos;
        public float targetDist;
        public float trackAngle;
        public bool isFired;
        public SkillEffectImpactTargetType impactTargetType;
    }
}

