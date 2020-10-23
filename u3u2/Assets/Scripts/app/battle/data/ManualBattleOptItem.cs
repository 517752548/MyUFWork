using app.pet;

namespace app.battle
{
    public class ManualBattleOptItem
    {
        public PetType type { get; private set; }
        public int attackerPos;
        public int skillId;
        //public SkillTargetType skillTargetType;
        public int targetPos;
        public int itemTplId;
        public long summonPetUUID;
        public bool needSelectTarget;
        public bool isDone;

        public ManualBattleOptItem(PetType type)
        {
            this.type = type;
        }

        public void Reset()
        {
            attackerPos = 0;
            skillId = 0;
            //skillTargetType = SkillTargetType.NONE;
            targetPos = 0;
            itemTplId = 0;
            summonPetUUID = 0;
            needSelectTarget = false;
            isDone = false;
        }
    }
}

