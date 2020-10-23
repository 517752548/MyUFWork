using System.Collections;
using System.Collections.Generic;
using app.db;
using app.pet;
using app.utils;

namespace app.battle
{
    /// <summary>
    /// 回合开始时的角色状态。
    /// </summary>
    public class BatCharacterStatusData
    {
        //public PetTemplate tpl { get; private set; }

        public PetType type { get; private set; }
        /// <summary>
        /// 战斗对象唯一Id。
        /// </summary>
        /// <value>The UUID.</value>
        public string uuidS { get; private set; }
        /// <summary>
        /// 战斗对象唯一Id(怪物为0，目前只做显示隐藏“准备中”用)。
        /// </summary>
        /// <value>The UUID.</value>
        public long uuidL { get; private set; }
        /// <summary>
        /// 所属玩家唯一Id。
        /// </summary>
        /// <value>The UUID.</value>
        public long ownerUUID { get; private set; }

        /// <summary>
        /// 战斗对象模版Id。
        /// </summary>
        /// <value>The tpl identifier.</value>
        //public int tplId { get; private set; }

        public string displayModelId { get; private set; }

        /// <summary>
        /// 名字。
        /// </summary>
        /// <value>The name.</value>
        public string name { get; private set; }

        /// <summary>
        /// 位置，从1开始。
        /// </summary>
        /// <value>The position.</value>
        public int pos { get; private set; }

        public BatCharacterAttackType attackType { get; private set; }

        /// <summary>
        /// 武将等级。
        /// </summary>
        /// <value>The level.</value>
        public int level { get; private set; }

        /// <summary>
        /// 血量。
        /// </summary>
        /// <value>The hp.</value>
        public int hp { get; private set; }

        /// <summary>
        /// 血量上限。
        /// </summary>
        /// <value>The max hp.</value>
        public int maxHp { get; private set; }

        /// <summary>
        /// 魔法。
        /// </summary>
        /// <value>The mp.</value>
        public int mp { get; private set; }

        /// <summary>
        /// 魔法上限。
        /// </summary>
        /// <value>The max mp.</value>
        public int maxMp { get; private set; }

        /// <summary>
        /// 怒气。
        /// </summary>
        /// <value>The sp.</value>
        public int sp { get; private set; }

        /// <summary>
        /// 怒气上限。
        /// </summary>
        /// <value>The max hp.</value>
        public int maxSp { get; private set; }

        public List<BatRoundBuffData> buffDatas { get; private set; }
        
        /// <summary>
        /// 状态。对应BatCharacterStatus。
        /// </summary>
        /// <value>status.</value>
        public int totalStatus { get; private set; }
        
        /// <summary>
        /// 是否可被捕捉。
        /// </summary>
        /// <value>isCanBeChatched.</value>
        public bool isCanBeChatched { get; private set; }
        
        /// <summary>
        /// 是否是变异体。
        /// </summary>
        /// <value>isVariant.</value>
        public bool isVariant { get; private set; }
        
        /// <summary>
        /// 变异后的颜色（RGB）。
        /// </summary>
        /// <value>variantionColor.</value>
        public string variantionColor { get; private set; }
        
        public PetTemplate petTpl { get; private set; }
        
        public EnemyTemplate enemyTpl { get; private set; }
        
        public EquipItemTemplate weaponTpl { get; private set; }

        public bool hasChivalric { get; private set; }

        public int chivalricId { get; private set; }
        
        public BatCharacterStatusData()
        {
            buffDatas = new List<BatRoundBuffData>();
        }

        public void Parse(IDictionary data)
        {
            type = (PetType)(JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_TYPE.ToString(), data));
            uuidS = JsonHelper.GetStringData(BattleReportDef.FIGHTUNIT_ID.ToString(), data);
            uuidL = JsonHelper.GetLongData(BattleReportDef.FIGHTUNIT_PETUUID.ToString(), data);
            ownerUUID = JsonHelper.GetLongData(BattleReportDef.FIGHTUNIT_OWERID.ToString(), data);
            int tplId = JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_TPLID.ToString(), data);
            if (type == PetType.FRIEND || type == PetType.LEADER || type == PetType.PET)
            {
                petTpl = PetTemplateDB.Instance.getTemplate(tplId);
                displayModelId = petTpl.modelId;
                variantionColor = petTpl.petTransColor;
                //variantionColor = variantionColor.Replace("|", ",");
                if (variantionColor == "")
                {
                    variantionColor = null;
                }
                enemyTpl = null;
            }
            else if (type == PetType.MONSTER)
            {
                enemyTpl = EnemyTemplateDB.Instance.getTemplate(tplId);
                displayModelId = enemyTpl.modelId;
                variantionColor = null;
                petTpl = null;
            }
            
            name = JsonHelper.GetStringData(BattleReportDef.FIGHTUNIT_NAME.ToString(), data);
            pos = JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_POSITION.ToString(), data);
            attackType = (BatCharacterAttackType)(JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_ATTACKTYPE.ToString(), data));
            level = JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_LEVEL.ToString(), data);
            hp = JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_HP.ToString(), data);
            maxHp = JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_HP_MAX.ToString(), data);
            mp = JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_MP.ToString(), data);
            maxMp = JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_MP_MAX.ToString(), data);
            sp = JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_SP.ToString(), data);
            maxSp = JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_SP_MAX.ToString(), data);
            totalStatus = JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_STATUS.ToString(), data);
            isCanBeChatched = (JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_CAN_BE_CAUGHT.ToString(), data) > 0);
            isVariant = (JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_GENETYPE.ToString(), data) > 0);
            
            IList buffs = JsonHelper.GetListData(BattleReportDef.REPORT_ITEM_BUFF.ToString(), data);
            buffDatas.Clear();
            if (buffs != null)
            {
                int len = buffs.Count;
                for (int i = 0; i < len; i++)
                {
                    BatRoundBuffData buffData = new BatRoundBuffData(BatRoundStageType.NONE);
                    buffData.Parse((IDictionary)(buffs[i]));
                    buffDatas.Add(buffData);
                }
            }
            
            if (type == PetType.LEADER)
            {
                int weaponTplId = JsonHelper.GetIntData(BattleReportDef.FIGHTUNIT_LEADER_WEAPONID.ToString(), data);
                if (PropertyUtil.IsLegalID(weaponTplId))
                {
                    weaponTpl = ItemTemplateDB.Instance.getTempalte(weaponTplId) as EquipItemTemplate;
                }
            }

            hasChivalric = JsonHelper.GetBoolData(BattleReportDef.REPORT_ITEM_CHIVALRIC.ToString(), data);
            chivalricId = JsonHelper.GetIntData(BattleReportDef.REPORT_ITEM_CHIVALRIC_ID.ToString(), data);
        }

        public bool HasBuff(int id)
        {
            int len = buffDatas.Count;
            for (int i = 0; i < len; i++)
            {
                if (buffDatas[i].id == id)
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool HasStatus(int status)
        {
            return (totalStatus & status) == status;
        }
    }
}