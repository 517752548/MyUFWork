using app.bag;
using app.chat;
using app.model;
using app.pet;
using app.role;
using app.net;
using app.yunliang;
using app.zone;
using app.item;
using app.tips;
using app.utils;
using app.avatar;

namespace app.human
{
    public class Human : Role, IBackToLogin
    {
        private static Human _ins;
        public static Human Instance
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new Human();
                }
                return _ins;
            }
        }

        // 唯一id
        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string pid;
        /// <summary>
        /// passportId
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        private string token;
        /// <summary>
        /// 登录token
        /// </summary>
        public string Token
        {
            get { return token; }
            set { token = value; }
        }


		private long createTime;
		/// <summary>
		/// 获取玩家创建时间
		/// </summary>
		/// <value>The create time.</value>
		public long CreateTime{
			get { return createTime; }
			set { createTime = value; }
		}

        /// <summary>
        /// 服务器时间(秒)
        /// </summary>
        /// <value>The server time.</value>
        public float serverTime { get; set; }

        //武将管理器
        private PlayerModel playerModel;
        public PlayerModel PlayerModel
        {
            get { return playerModel; }
        }

        //背包管理器
        private BagModel bagModel;
        public BagModel BagModel
        {
            get { return bagModel; }
        }

        /// <summary>
        /// 属性管理器
        /// </summary>
        private HumanPropertyManager propertyManager;

        public HumanPropertyManager PropertyManager
        {
            get { return propertyManager; }
        }

        //武将管理器
        private PetModel petModel;
        public PetModel PetModel
        {
            get { return petModel; }
        }

        //任务管理器
        private QuestModel questModel;
        public QuestModel QuestModel
        {
            get { return questModel; }
        }

        private YunLiangModel yunliangModel;

        public Human()
            : base(RoleTypes.HUMAN)
        {
            init();
        }

        public void init()
        {
            this.id = 0;
            this.pid = null;
            this.token = null;

            propertyManager = new HumanPropertyManager(this);

            // TODO manager初始化
            // this.petModel = Singleton.getObj(typeof(PetModel)) as PetModel;
            // this.questModel = Singleton.getObj(typeof(QuestModel)) as QuestModel;
            // this.bagModel = Singleton.getObj(typeof(BagModel)) as BagModel;
            // this.playerModel = Singleton.getObj(typeof(PlayerModel)) as PlayerModel;
            this.petModel = PetModel.Ins;
            this.questModel = QuestModel.Ins;
            this.bagModel = BagModel.Ins;
            this.playerModel = PlayerModel.Ins;

        }

        public void onBackToLogin()
        {
            init();
            //继承AbsModel的会在进入登录面板时清除，所以这里就不再调用各个model的onBackToLogin了
        }

        public bool HasEnoughCurrency(int currencyType, long needValue)
        {
            if (needValue <= 0)
            {
                return true;
            }
            switch (currencyType)
            {
                case CurrencyTypeDef.BOND:
                    return propertyManager.getLongProp(RoleBaseStrProperties.ALL_BOND) >= needValue;
                case CurrencyTypeDef.GIFT_BOND:
                    return propertyManager.getLongProp(RoleBaseStrProperties.GIFT_BOND) >= needValue;
                case CurrencyTypeDef.GOLD:
                    return propertyManager.getLongProp(RoleBaseStrProperties.GOLD) >= needValue;
                case CurrencyTypeDef.GOLD_2:
                    return propertyManager.getLongProp(RoleBaseStrProperties.GOLD_2) >= needValue;
                case CurrencyTypeDef.HONOR:
                    return propertyManager.getLongProp(RoleBaseStrProperties.HONOR) >= needValue;
                case CurrencyTypeDef.POWER:
                    return propertyManager.getLongProp(RoleBaseStrProperties.POWER) >= needValue;
                case CurrencyTypeDef.SKILL_POINT:
                    return propertyManager.getLongProp(RoleBaseStrProperties.SKILL_POINT) >= needValue;
                case CurrencyTypeDef.SYS_BOND:
                    return propertyManager.getLongProp(RoleBaseStrProperties.SYS_BOND) >= needValue;
                case CurrencyTypeDef.BANGGONG:
                    return propertyManager.getIntProp(RoleBaseIntProperties.CURRENT_CORPS_CONTRIBUTION) >= needValue;
                case CurrencyTypeDef.HUOLI:
                    return Human.Instance.PropertyManager.getIntProp(RoleBaseStrProperties.HUOLI) >= needValue;
            }
            return false;
        }

        public long GetCurrencyValue(int currencyType)
        {
            switch (currencyType)
            {
                case CurrencyTypeDef.BOND:
                    return propertyManager.getLongProp(RoleBaseStrProperties.ALL_BOND);
                case CurrencyTypeDef.GIFT_BOND:
                    return propertyManager.getLongProp(RoleBaseStrProperties.GIFT_BOND);
                case CurrencyTypeDef.GOLD:
                    return propertyManager.getLongProp(RoleBaseStrProperties.GOLD);
                case CurrencyTypeDef.GOLD_2:
                    return propertyManager.getLongProp(RoleBaseStrProperties.GOLD_2);
                case CurrencyTypeDef.HONOR:
                    return propertyManager.getLongProp(RoleBaseStrProperties.HONOR);
                case CurrencyTypeDef.POWER:
                    return propertyManager.getLongProp(RoleBaseStrProperties.POWER);
                case CurrencyTypeDef.SKILL_POINT:
                    return propertyManager.getLongProp(RoleBaseStrProperties.SKILL_POINT);
                case CurrencyTypeDef.SYS_BOND:
                    return propertyManager.getLongProp(RoleBaseStrProperties.SYS_BOND);
                case CurrencyTypeDef.BANGGONG:
                    return propertyManager.getIntProp(RoleBaseIntProperties.CURRENT_CORPS_CONTRIBUTION);
                case CurrencyTypeDef.HUOLI:
                    int huoli = 0;
                    int.TryParse(Human.Instance.PropertyManager.getStringProp(RoleBaseStrProperties.HUOLI), out huoli);
                    return huoli;
                case CurrencyTypeDef.GUA_JI_POINT1:
                    return propertyManager.getLongProp(RoleBaseStrProperties.GUA_JI_POINT);
                case CurrencyTypeDef.GUA_JI_POINT2:
                    return propertyManager.getLongProp(RoleBaseStrProperties.GUA_JI_POINT2);
            }
            return 0;
        }

        /*
        public bool hasEnoughGold(int needGold)
        {
            if (needGold > 0)
            {
                return getGold() >= needGold;
            }
            return true;
        }
        
        public long getGold()
        {
            return this.propertyManager.getLongProp(RoleBaseStrProperties.GOLD);
        }
        */

        public int getLevel()
        {
            return this.propertyManager.getIntProp(RoleBaseIntProperties.LEVEL);
        }

        public string getName()
        {
            return this.propertyManager.getStringProp(RoleBaseStrProperties.NAME);
        }

        public long getExp()
        {
            return this.propertyManager.getLongProp(RoleBaseStrProperties.EXP);
        }

        public long getExpLimit()
        {
            return this.propertyManager.getLongProp(RoleBaseStrProperties.LEVEL_UP_NEED_EXP);
        }

        public int getSkillPoint()
        {
            return (int)this.propertyManager.getLongProp(RoleBaseStrProperties.SKILL_POINT);
        }

        public string get3DModel()
        {
            if (this.petModel.getLeader() != null)
            {
                return this.petModel.getLeader().getTpl().modelId;
            }
            return null;
        }

        public int getShowChenghao()
        {
            return this.propertyManager.getIntProp(RoleBaseIntProperties.DIS_TITLE);
        }

        public int getChenghao()
        {
            return this.propertyManager.getIntProp(RoleBaseIntProperties.Chenghao_TITLE);
        }

        public string getChenghaoName()
        {
            return this.propertyManager.getStringProp(RoleBaseStrProperties.Chenghao_Name);
        }

        public override void DoUpdate(float deltaTime)
        {
            //if (questModel != null)
            //{
            //    questModel.DoUpdate();
            //}
        }

        public void HumanIntPropertyChangeHandler(KeyValuePairIntData[] propArr)
        {
            if (!playerModel.isLoginFinished)
            {
                return;
            }

            //ClientLog.LogError("==========BubbleHumanIntPropertyChange==========");

            int len = propArr.Length;
            for (int i = 0; i < len; i++)
            {
                KeyValuePairIntData data = propArr[i];
                int oldValue = this.propertyManager.getIntProp(data.key);
                int newValue = data.value;
                int valueChange = newValue - oldValue;
                //ClientLog.LogError("key:" + data.key + " valueChange:" + valueChange);
                ZoneBubbleManager.ins.BubbleHumanIntPropChange(data.key, valueChange);
            }
        }

        public void HumanStrPropertyChangeHandler(KeyValuePairStringData[] propArr)
        {
            if (!playerModel.isLoginFinished)
            {
                return;
            }

            //ClientLog.LogError("==========BubbleHumanStrPropertyChange==========");

            int len = propArr.Length;
            for (int i = 0; i < len; i++)
            {
                KeyValuePairStringData data = propArr[i];
                long oldValue = this.propertyManager.getLongProp(data.key);
                long newValue = 0;
                long.TryParse(data.value, out newValue);
                long valueChange = newValue - oldValue;
                //ClientLog.LogError("key:" + data.key + " valueChange:" + valueChange);
                ZoneBubbleManager.ins.BubbleHumanLongPropChange(data.key, valueChange);
            }
        }

        public void LeaderIntPropertyChangeHandler(KeyValuePairIntData[] propArr)
        {
            if (!playerModel.isLoginFinished)
            {
                return;
            }

            Pet leader = petModel.getLeader();

            //ClientLog.LogError("==========BubblePetIntPropertyChange==========");

            int len = propArr.Length;
            for (int i = 0; i < len; i++)
            {
                KeyValuePairIntData data = propArr[i];
                int oldValue = leader.PropertyManager.getPetIntProp(data.key);
                int newValue = data.value;
                int valueChange = newValue - oldValue;
                ZoneBubbleManager.ins.BubbleLeaderIntPropChange(leader, data.key, valueChange);
            }
        }

        public void LeaderStrPropertyChangeHandler(KeyValuePairStringData[] propArr)
        {
            if (!playerModel.isLoginFinished)
            {
                return;
            }

            Pet leader = petModel.getLeader();

            //ClientLog.LogError("==========BubblePetStrPropertyChange==========");

            int len = propArr.Length;
            for (int i = 0; i < len; i++)
            {
                KeyValuePairStringData data = propArr[i];
                long oldValue = leader.PropertyManager.getPetLongProp(data.key);
                long newValue = 0;
                long.TryParse(data.value, out newValue);
                long valueChange = newValue - oldValue;
                //ClientLog.LogError("pet:" + pet.getName() + "  key:" + data.key + " valueChange:" + valueChange);
                ZoneBubbleManager.ins.BubbleLeaderLongPropChange(leader, data.key, valueChange);
            }
        }

        public void PetIntPropertyChangeHandler(Pet pet, KeyValuePairIntData[] propArr)
        {
            if (!playerModel.isLoginFinished)
            {
                return;
            }

            //ClientLog.LogError("==========BubblePetIntPropertyChange==========");

            int len = propArr.Length;
            for (int i = 0; i < len; i++)
            {
                KeyValuePairIntData data = propArr[i];
                int oldValue = pet.PropertyManager.getPetIntProp(data.key);
                int newValue = data.value;
                int valueChange = newValue - oldValue;
                //ClientLog.LogError("pet:" + pet.getName() + "  key:" + data.key + " valueChange:" + valueChange);
                ZoneBubbleManager.ins.BubblePetIntPropChange(pet, data.key, valueChange);
            }
        }

        public void PetStrPropertyChangeHandler(Pet pet, KeyValuePairStringData[] propArr)
        {
            if (!playerModel.isLoginFinished)
            {
                return;
            }

            //ClientLog.LogError("==========BubblePetStrPropertyChange==========");

            int len = propArr.Length;
            for (int i = 0; i < len; i++)
            {
                KeyValuePairStringData data = propArr[i];
                long oldValue = pet.PropertyManager.getPetLongProp(data.key);
                long newValue = 0;
                long.TryParse(data.value, out newValue);
                long valueChange = newValue - oldValue;
                //ClientLog.LogError("pet:" + pet.getName() + "  key:" + data.key + " valueChange:" + valueChange);
                ZoneBubbleManager.ins.BubblePetLongPropChange(pet, data.key, valueChange);
            }
        }

        public void AddPetHandler(Pet pet)
        {
            if (!playerModel.isLoginFinished)
            {
                return;
            }

            //ClientLog.LogError("==========BubbleAddPet==========");

            //ClientLog.LogError("pet:" + pet.getName());

            ZoneBubbleManager.ins.BubbleAddPet(pet);

            //增加聊天信息
            string str = LangConstant.YOU_HAVE_GOT +  pet.getTpl().name+"x1";
            //系统提示
            SysMsgInfoData sysmsg = new SysMsgInfoData();
            sysmsg.content = str;
            sysmsg.showType = (short)SystemMessageListType.NOTICE_MESSAGE;
            ChatModel.Ins.addSysMessage(sysmsg);

        }

        public void ItemChangeHandler(CommonItemData itemData, int oldValue)
        {
            if (!playerModel.isLoginFinished)
            {
                return;
            }

            //ClientLog.LogError("==========BubbleItemChange==========");
            int newValue = itemData.count;
            int valueChange = newValue - oldValue;

            //ClientLog.LogError("item:" + itemData.tplId + " valueChange:" + valueChange);

            if (itemData.bagId == ItemDefine.BagId.MAIN_BAG && valueChange>0)
            {
                //冒泡和快捷使用只检测主背包。
                ZoneBubbleManager.ins.BubbleItemChange(itemData, valueChange);

                //增加聊天信息
                ItemDetailData detailData = new ItemDetailData();
                detailData.setData(itemData);
                string str = LangConstant.YOU_HAVE_GOT + detailData.itemTemplate.name + "x" + valueChange;
                //系统提示
                SysMsgInfoData sysmsg = new SysMsgInfoData();
                sysmsg.content = str;
                sysmsg.showType = (short)SystemMessageListType.NOTICE_MESSAGE;
                ChatModel.Ins.addSysMessage(sysmsg);

                if (valueChange > 0)
                {
                    //快捷使用
                    ItemDetailData itemDetailData = bagModel.getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByIndex(itemData.index);
                    if (itemDetailData.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP && itemDetailData.equipItemTemplate != null)
                    {
                        //装备
                        long wearerId = itemData.wearerId;
                        if (wearerId == 0)
                        {
                            wearerId = Human.Instance.PetModel.getLeader().Id;
                        }
                        ItemBag equipBag = Human.Instance.PetModel.getEquipItemBag(wearerId);
                        if (equipBag != null)
                        {
                            ItemDetailData equipOnWear = equipBag.getEquipItemDetailByPosition(itemDetailData.equipItemTemplate.positionId);
                            if (equipOnWear != null)
                            {
                                if (equipOnWear.GetItemPropValue(ItemDefine.ItemPropKey.SCORE) >= itemDetailData.GetItemPropValue(ItemDefine.ItemPropKey.SCORE))
                                {
                                    //身上已有此类装备并且评分较高的话不弹快捷使用。
                                    return;
                                }
                            }
                        }

                        Pet wearer = Human.Instance.PetModel.getPet(wearerId);
                        if (wearer != null)
                        {
                            if (PetJobType.ContainJob(itemDetailData.equipItemTemplate.jobLimit, wearer.getTpl().jobId) &&
                                PetSexType.ContainSex(itemDetailData.equipItemTemplate.sexLimit, wearer.getTpl().sexId) &&
                                itemDetailData.equipItemTemplate.level <= wearer.getLevel())
                            {
                                //穿戴者属性复合装备要求的话弹快捷使用。
                                for (int i = 0; i < valueChange; i++)
                                {
                                    PopUseWnd.Ins.ShowInfo(itemDetailData, UseEquip);
                                }
                            }
                        }

                    }
                    else if (itemDetailData.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.CONSUMABLE && itemDetailData.consumeItemTemplate != null)
                    {
                        //可消耗品
                        /*
                        int funcId = itemDetailData.consumeItemTemplate.functionId;
                        int argA = itemDetailData.consumeItemTemplate.argA;
                        if ((funcId == 14 && (argA == 1 || argA == 2 || argA == 3)))
                        {
                            for (int i = 0; i < valueChange; i++)
                            {
                                PopUseWnd.Ins.ShowInfo(itemDetailData, UseItem);
                            }
                        }
                        */
                        if (itemDetailData.consumeItemTemplate.fastUseTip > 0)
                        {
                            for (int i = 0; i < valueChange; i++)
                            {
                                PopUseWnd.Ins.ShowInfo(itemDetailData, UseItem);
                            }
                        }
                    }
                }
            }
        }

        private void UseItem(ItemDetailData item)
        {
            ItemCGHandler.sendCGUseItem(item.commonItemData.bagId, item.commonItemData.index, 1, 1, 0);
        }

        private void UseEquip(ItemDetailData item)
        {
            if (item == null)
            {
                ClientLog.LogError("Human:UseEquip item is null!");
                return;
            }

            if (item.commonItemData == null)
            {
                ClientLog.LogError("Human:UseEquip item.commonItemData is null!");
                return;
            }

            if (Human.Instance.PetModel.getLeader() == null)
            {
                ClientLog.LogError("Human:UseEquip Human.Instance.PetModel.getLeader() is null!");
                return;
            }

            ItemCGHandler.sendCGUseItem(item.commonItemData.bagId, item.commonItemData.index, 1,
                ItemDefine.ItemWearTypeDefine.Pet, Human.Instance.PetModel.getLeader().Id);
        }

        public void UpdatePlayerModel()
        {
            if (playerModel.isLoginFinished && ZoneCharacterManager.ins.self != null)
            {
                string currentModelName = Human.Instance.get3DModel();
                bool isEnableRidePet = true;
                bool isEnableWing = true;
                bool isEnableWeapon = true;

                if (yunliangModel == null)
                {
                    // yunliangModel = Singleton.getObj(typeof(YunLiangModel)) as YunLiangModel;
                    yunliangModel = YunLiangModel.Ins;
                }
                if (yunliangModel.isYunLiangIng())
                {
                    currentModelName = ClientConstantDef.YUNLIANGREN;
                    isEnableRidePet = isEnableWing = isEnableWeapon = false;
                }
                else
                {
                    isEnableWeapon = (Human.Instance.PetModel.getRidePet() == null);
                    int fashionId = Human.Instance.PetModel.GetFashionTplId();
                    string fashionModel = Human.Instance.PetModel.GetFashionModelString();
                    if (PropertyUtil.IsLegalID(fashionId) && PropertyUtil.IsLegalID(fashionModel))
                    {
                        isEnableWeapon = false;
                        currentModelName = fashionModel;
                    }
                }
                if (currentModelName != ZoneCharacterManager.ins.self.displayModelId)
                {
                    ZoneCharacterManager.ins.self.ShiftDisplayModel(currentModelName, isEnableRidePet, isEnableWing, isEnableWeapon);
                    //ZoneCharacterManager.ins.updatePlayerRide();
                    //ZoneCharacterManager.ins.updateWing();
                }

                updateSelfWeapon(ZoneCharacterManager.ins.self);
            }
        }

        public void updateSelfWeapon(AvatarBase selfAvatar)
        {
            if (selfAvatar != null)
            {
                ItemDetailData weaponData = PetModel.getLeaderEquipItemBag().getEquipItemDetailByPosition(ItemDefine.ItemPositionDefine.WEAPON);
                if (weaponData != null)
                {
                    selfAvatar.ShowWeapon(weaponData.equipItemTemplate);
                }
                else
                {
                    selfAvatar.HideWeapon(true);
                }
            }
        }
    }
}